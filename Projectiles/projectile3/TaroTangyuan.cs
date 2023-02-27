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

namespace MythMod.Projectiles.projectile3
{
    public class TaroTangyuan : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("香芋汤圆");
        }
        public override void SetDefaults()
        {
            base.projectile.width = 28;
            base.projectile.height = 28;
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
        }
        public override void Kill(int timeLeft)
        {
            float num60 = (float)Main.rand.Next(0, 10000);
            int num80 = Main.rand.Next(-1000, 1000) / 100;
            double num90 = (double)Math.Sqrt(100 - (int)num80 * (int)num80);
            Vector2 v1 = Vector2.Normalize(new Vector2((float)num80, (float)num90)) * 5;
            Vector2 mc = Main.screenPosition + new Vector2((float)num80, (float)num90);
            float num100 = (float)Main.rand.Next(0, 10000) / 1000;
            float T = (float)(Main.rand.Next(0, 10000) / 5000 * Math.PI);
            for (int i = 0; i < 250; i++)
            {
                v1 = v1.RotatedBy(Math.PI / 125f);
                Vector2 v2 = new Vector2(v1.X * (float)num60 / 10000, v1.Y);
                int p = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 63, (float)num80, (float)num90, 150, Color.White, 1.8f);
                Main.dust[p].velocity = v2.RotatedBy(Math.Atan2((float)num80, (float)num90)) * 2f;
                Main.dust[p].scale = 1.4f + Math.Abs((float)Math.Atan2(-v1.Y, -v1.X) / (1 + (float)num60 / 2000));
                Main.dust[p].noGravity = true;
            }
            int num10 = 0;
            while ((float)num10 < 200)
            {
                Vector2 v = new Vector2(Main.rand.Next(Main.rand.Next(0, 1000), 1000) / 200f, 0).RotatedByRandom(Math.PI * 2);
                int num8 = Main.rand.Next(3);
                if (num8 == 0)
                {
                    num8 = 171;
                }
                else if (num8 == 1)
                {
                    num8 = 171;
                }
                else
                {
                    num8 = 171;
                }
                int num9 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, num8, 0f, 0f, 100, default(Color), 2f);
                Main.dust[num9].noGravity = true;
                Main.dust[num9].position.X = base.projectile.Center.X;
                Main.dust[num9].position.Y = base.projectile.Center.Y;
                Dust dust = Main.dust[num9];
                dust.position.X = dust.position.X + (float)Main.rand.Next(-10, 11);
                Dust dust2 = Main.dust[num9];
                dust2.position.Y = dust2.position.Y + (float)Main.rand.Next(-10, 11);
                Main.dust[num9].velocity = v;
                num10++;
            }
        }
    }
}
