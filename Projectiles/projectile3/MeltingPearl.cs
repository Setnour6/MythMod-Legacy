﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader.IO;
namespace MythMod.Projectiles.projectile3
{
    public class MeltingPearl : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("熔珠");
        }
        public override void SetDefaults()
        {
            Projectile.width = 50;
            Projectile.height = 50;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 9;
            Projectile.timeLeft = 1000;
            Projectile.alpha = 0;
            Projectile.penetrate = 29;
            Projectile.scale = 1f;
            this.CooldownSlot = 1;
        }
        private bool initialization = true;
        private double X;
        private float Y;
        private float b;
        private float rg = 0;
        public override void AI()
        {
            base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) - (float)Math.PI * 0.5f;
            if (Projectile.timeLeft < 986 && Projectile.timeLeft > 100)
            {
                Vector2 vector = base.Projectile.Center;
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, 174, 50f, 50f, 0, default(Color), (float)Projectile.scale * 0.75f);
                Main.dust[num].velocity *= 0.0f;
                Main.dust[num].noGravity = true;
                Main.dust[num].scale *= 1.2f;
                Main.dust[num].alpha = 200;
            }
            if (Projectile.timeLeft < 100)
            {
                Vector2 vector = base.Projectile.Center;
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, 174, 50f, 50f, 0, default(Color), (float)Projectile.scale * 0.75f * Projectile.timeLeft / 100f);
                Main.dust[num].velocity *= 0.0f;
                Main.dust[num].noGravity = true;
                Main.dust[num].scale *= 1.2f;
                Main.dust[num].alpha = 200;
            }
            if (Projectile.timeLeft < 960)
            {
                Projectile.tileCollide = true;
            }
            Lighting.AddLight(Projectile.Center, -1, -1, -1);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, 0) * ((Projectile.timeLeft) / 1000f));
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 3; i++)
            {
                float num44 = (float)Main.rand.Next(0, 3600) / 1800f * 3.14159265359f;
                double num45 = Math.Cos((float)num44);
                double num46 = Math.Sin((float)num44);
                float num47 = (float)Main.rand.Next(50000, 100000) / 60000f;
                int num40 = Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, (float)num45 * (float)num47 * 0.7f, (float)num46 * (float)num47 * 0.7f, base.Mod.Find<ModProjectile>("熔珠2").Type, Projectile.damage / 2, 2f, Main.myPlayer, 0f, 0);
                Main.projectile[num40].tileCollide = false;
                Main.projectile[num40].timeLeft = 200;
            }
            for (int a = 0; a < 30; a++)
            {
                Vector2 vector = base.Projectile.Center;
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 2.5f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, 174, v.X, v.Y, 0, default(Color), (float)Projectile.scale * 1f);
                Main.dust[num].noGravity = true;
                Main.dust[num].scale *= 1.2f;
                Main.dust[num].alpha = 200;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.timeLeft < 980)
            {
                base.Projectile.penetrate--;
                if (base.Projectile.penetrate <= 0)
                {
                    base.Projectile.Kill();
                }
                else
                {
                    base.Projectile.ai[0] += 0.1f;
                    if (base.Projectile.velocity.X != oldVelocity.X)
                    {
                        base.Projectile.velocity.X = -oldVelocity.X;
                    }
                    if (base.Projectile.velocity.Y != oldVelocity.Y)
                    {
                        base.Projectile.velocity.Y = -oldVelocity.Y;
                    }
                    Projectile.velocity = Projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.4f, 0.4f));
                }
                for (int i = 0; i < 3; i++)
                {
                    float num44 = (float)Main.rand.Next(0, 3600) / 1800f * 3.14159265359f;
                    double num45 = Math.Cos((float)num44);
                    double num46 = Math.Sin((float)num44);
                    float num47 = (float)Main.rand.Next(50000, 100000) / 60000f;
                    int num40 = Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, (float)num45 * (float)num47 * 0.7f, (float)num46 * (float)num47 * 0.7f, base.Mod.Find<ModProjectile>("熔珠2").Type, Projectile.damage / 2, 2f, Main.myPlayer, 0f, 0);
                    Main.projectile[num40].tileCollide = false;
                    Main.projectile[num40].timeLeft = 200;
                }
                for (int a = 0; a < 30; a++)
                {
                    Vector2 vector = base.Projectile.Center;
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 2.5f)).RotatedByRandom(Math.PI * 2);
                    int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, 174, v.X, v.Y, 0, default(Color), (float)Projectile.scale * 1f);
                    Main.dust[num].noGravity = true;
                    Main.dust[num].scale *= 1.2f;
                    Main.dust[num].alpha = 200;
                }
            }
            return false;
        }
    }
}