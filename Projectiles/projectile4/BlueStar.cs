using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MythMod.Projectiles.projectile4
{
    public class BlueStar : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("魔星");
        }
        public override void SetDefaults()
        {
            base.Projectile.width = 48;
            base.Projectile.height = 48;
            base.Projectile.friendly = true;
            base.Projectile.DamageType = DamageClass.Melee;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = 1;
            base.Projectile.extraUpdates = 1;
            base.Projectile.timeLeft = 40000;
            base.Projectile.tileCollide = false;
        }
        public override void AI()
        {
            if(Projectile.timeLeft == 39999)
            {
                Projectile.timeLeft = Main.rand.Next(20, 600);
            }
            Projectile.rotation += 0.025f * Projectile.velocity.Length();
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 3f / 7650f);
            Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 3.5f)).RotatedByRandom(Math.PI * 2);
            /*int num = Dust.NewDust(projectile.Center - new Vector2(4, 4) + new Vector2(0, 12).RotatedBy(projectile.timeLeft / 4f), 2, 2, mod.DustType("BlueEffect2"), 0, 0, 0, default(Color), 1f);
            Main.dust[num].noGravity = false;
            Main.dust[num].velocity *= 0;
            int num20 = Dust.NewDust(projectile.Center - new Vector2(4, 4) - new Vector2(0, 12).RotatedBy(projectile.timeLeft / 4f), 2, 2, mod.DustType("BlueEffect2"), 0, 0, 0, default(Color), 1f);
            Main.dust[num20].noGravity = false;
            Main.dust[num20].velocity *= 0;
            int num21 = Dust.NewDust(projectile.Center - new Vector2(4, 4), 2, 2, mod.DustType("BlueEffect2"), 0, 0, 0, default(Color), 1.5f);
            Main.dust[num21].velocity *= 0;
            int num22 = Dust.NewDust(projectile.Center - new Vector2(4, 4) + new Vector2(0, Main.rand.NextFloat(0, 8f)).RotatedByRandom(Math.PI * 2), 2, 2, mod.DustType("BlueEffect2"), 0, 0, 0, default(Color), 1.5f);
            Main.dust[num22].velocity *= 0.2f;*/
            Projectile.velocity *= 0.98f;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            if(Projectile.timeLeft > 100)
            {
                return new Color?(new Color(0f, 0.4f / (Projectile.scale + 0.2f) * (float)(0.6f + Math.Sin(Projectile.timeLeft / 30d) * 0.3), 1f / (Projectile.scale + 0.2f) * (float)(0.6f + Math.Sin(Projectile.timeLeft / 30d) * 0.3), 0.5f / (Projectile.scale + 0.2f)) * (float)(0.6f + Math.Sin(Projectile.timeLeft / 30d) * 0.3));
            }
            else
            {
                return new Color?(new Color(0f, 0.4f * Projectile.timeLeft * 0.01f / (Projectile.scale + 0.2f) * (float)(0.6f + Math.Sin(Projectile.timeLeft / 30d) * 0.3), 1f * Projectile.timeLeft * 0.01f / (Projectile.scale + 0.2f) * (float)(0.6f + Math.Sin(Projectile.timeLeft / 30d) * 0.3), 0.5f * Projectile.timeLeft * 0.01f / (Projectile.scale + 0.2f)) * (float)(0.6f + Math.Sin(Projectile.timeLeft / 30d) * 0.3));
            }
        }
        public override void Kill(int timeLeft)
        {
            if(timeLeft > 10)
            {
                /*for (int i = 0; i <= 8; i++)
                {
                    float num4 = (float)(Main.rand.Next(500, 8000)) * ((600 - timeLeft) / 600f + 0.4f);
                    double num1 = Main.rand.Next(0, 1000) / 500f;
                    double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 360f;
                    double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 360f;
                    int num5 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num2 * projectile.scale * 1.5f, (float)num3 * projectile.scale * 1.5f, base.mod.ProjectileType("BlueGemDust"), (int)((double)base.projectile.damage * 0.1f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                    Main.projectile[num5].scale = Main.rand.Next(1150, 2200) / 1000f;
                }*/
                for (int a = 0; a < 4; a++)
                {
                    Vector2 vector = base.Projectile.Center;
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(5f, 16.5f)).RotatedByRandom(Math.PI * 2);
                    int num = Dust.NewDust(vector - new Vector2(4, 4), 2, 2, Mod.Find<ModDust>("BlueEffect2").Type, v.X * Projectile.scale * 1.5f, v.Y * Projectile.scale * 1.5f, 0, default(Color), 2f * Main.rand.NextFloat(0.4f, 1.2f));
                    Main.dust[num].noGravity = false;
                    Main.dust[num].fadeIn = 1f + (float)Main.rand.NextFloat(-0.5f, 0.5f) * 0.1f;
                }
            }
        }
    }
}
