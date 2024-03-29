using Microsoft.Xna.Framework;
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
namespace MythMod.Projectiles.projectile4
{
    public class LightEsclipse : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("日食球");
        }
        public override void SetDefaults()
        {
            projectile.width = 8;
            projectile.height = 8;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.extraUpdates = 30;
            projectile.timeLeft = 1000;
            projectile.alpha = 0;
            projectile.penetrate = 999;
            projectile.scale = 1f;
            this.cooldownSlot = 1;
        }
        private bool initialization = true;
        private double X;
        private float Y;
        private float b;
        private float rg = 0;
        public override void AI()
        {
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) - (float)Math.PI * 0.5f;
            if (projectile.timeLeft < 1000 && projectile.timeLeft > 100)
            {
                projectile.tileCollide = true;
                Vector2 vector = base.projectile.Center;
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, 87, 50f, 50f, 0, default(Color), (float)projectile.scale * 1.2f);
                Main.dust[num].velocity *= 0.0f;
                Main.dust[num].noGravity = true;
                Main.dust[num].scale *= 1.2f;
                Main.dust[num].color = Color.DarkOrange;
                Main.dust[num].alpha = 200;
            }
            if (projectile.timeLeft < 100)
            {
                Vector2 vector = base.projectile.Center;
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, 87, 50f, 50f, 0, default(Color), (float)projectile.scale * 1.2f * projectile.timeLeft / 100f);
                Main.dust[num].velocity *= 0.0f;
                Main.dust[num].noGravity = true;
                Main.dust[num].scale *= 1.2f;
                Main.dust[num].color = Color.DarkOrange;
                Main.dust[num].alpha = 200;
            }
            if (projectile.velocity.Y < 15 && projectile.timeLeft > 50)
            {
                projectile.velocity.Y += 0.01f;
            }
            if(projectile.timeLeft <= 50)
            {
                projectile.scale *= 0.96f;
                projectile.alpha += 1;
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, 0) * ((projectile.timeLeft) / 1000f));
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 3; i++)
            {
                float num44 = (float)Main.rand.Next(0, 3600) / 1800f * 3.14159265359f;
                double num45 = Math.Cos((float)num44);
                double num46 = Math.Sin((float)num44);
                float num47 = (float)Main.rand.Next(50000, 100000) / 60000f;
                //int num40 = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, (float)num45 * (float)num47 * 0.7f, (float)num46 * (float)num47 * 0.7f, base.mod.ProjectileType("暗影光球2"), projectile.damage / 2, 2f, Main.myPlayer, 0f, 0);
               // Main.projectile[num40].tileCollide = false;
                //Main.projectile[num40].timeLeft = 200;
            }
            for (int a = 0; a < 30; a++)
            {
                Vector2 vector = base.projectile.Center;
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 2.5f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, 87, v.X, v.Y, 0, default(Color), (float)projectile.scale * 1.5f);
                Main.dust[num].noGravity = true;
                Main.dust[num].scale *= 1.2f;
                Main.dust[num].alpha = 200;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.timeLeft > 51)
            {
                projectile.timeLeft = 50;
                projectile.velocity *= 0;
            }
            return false;
        }
    }
}