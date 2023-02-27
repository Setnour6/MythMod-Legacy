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

namespace MythMod.Projectiles
{
    public class PineappleBeam : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("菠萝剑气");
        }

        public override void SetDefaults()
        {
            base.projectile.width = 28;
            base.projectile.height = 28;
            base.projectile.aiStyle = 27;
            base.projectile.friendly = true;
            base.projectile.melee = true;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = 1;
            base.projectile.extraUpdates = 1;
            base.projectile.timeLeft = 600;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 1;
        }

        public override void AI()
        {
            int num9 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4) - base.projectile.velocity * 6f, 0, 0, 87, 0f, 0f, 100, default(Color), 1.2f);
            Main.dust[num9].noGravity = true;
            Main.dust[num9].velocity *= 0.0f;
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.6f / 255f, (float)(255 - base.projectile.alpha) * 0.5f / 255f, (float)(255 - base.projectile.alpha) * 0.0f / 255f);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, base.projectile.alpha));
        }
        public override void Kill(int timeLeft)
        {
            float num60 = (float)Main.rand.Next(0, 10000);
            int num80 = Main.rand.Next(-1000, 1000) / 100;
            double num90 = (double)Math.Sqrt(100 - (int)num80 * (int)num80);
            Vector2 v1 = Vector2.Normalize(new Vector2((float)num80, (float)num90)) * 5f;
            Vector2 mc = Main.screenPosition + new Vector2((float)num80, (float)num90);
            float num100 = (float)Main.rand.Next(0, 10000) / 1000f;
            float T = (float)(Main.rand.Next(0, 10000) / 5000 * Math.PI);
            for (int i = 0; i < 400; i++)
            {
                v1 = v1.RotatedBy(Math.PI / 200f);
                Vector2 v2 = new Vector2(v1.X * (float)num60 / 10000, v1.Y);
                int p = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), 0, 0, 61, (float)num80, (float)num90, 150, default(Color), 1.8f);
                float num1 = (float)(1 + Math.Sin((float)i / 20 * Math.PI) * 0.5f);
                Main.dust[p].velocity = v2.RotatedBy(Math.Atan2((float)num80, (float)num90)) * 3f * (float)num1;
                Main.dust[p].scale = 1.4f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num60 / 2000));
                Main.dust[p].velocity *= 0.8f;
                Main.dust[p].noGravity = true;
                Main.dust[p].scale *= 1.07f;
            }
            int num10 = 0;
            while ((float)num10 < 400)
            {
                float num4 = (float)Main.rand.Next(-25, 26);
                float num5 = (float)Main.rand.Next(-25, 26);
                float num6 = (float)Main.rand.Next(2, 6);
                float num7 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
                num7 = num6 / num7;
                num4 *= num7 * 1.2f;
                num5 *= num7 * 1.2f;
                int num8 = Main.rand.Next(3);
                if (num8 == 0)
                {
                    num8 = 64;
                }
                else if (num8 == 1)
                {
                    num8 = 64;
                }
                else
                {
                    num8 = 87;
                }
                int num9 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, num8, 0f, 0f, 100, default(Color), 2f);
                Main.dust[num9].noGravity = true;
                Main.dust[num9].position.X = base.projectile.Center.X;
                Main.dust[num9].position.Y = base.projectile.Center.Y;
                Dust dust = Main.dust[num9];
                dust.position.X = dust.position.X + (float)Main.rand.Next(-10, 11);
                Dust dust2 = Main.dust[num9];
                dust2.position.Y = dust2.position.Y + (float)Main.rand.Next(-10, 11);
                Main.dust[num9].velocity.X = num4 * 1.8f;
                Main.dust[num9].velocity.Y = num5 * 1.8f;
                num10++;
            }
        }
    }
}
