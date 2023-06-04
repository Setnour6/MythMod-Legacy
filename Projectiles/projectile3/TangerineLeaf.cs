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
namespace MythMod.Projectiles.projectile3
{
    public class TangerineLeaf : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("桔叶飞刀");
        }
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 3;
            Projectile.timeLeft = 1000;
            Projectile.alpha = 0;
            Projectile.penetrate = 1;
            Projectile.scale = 1f;
            this.CooldownSlot = 1;
        }
        private bool initialization = true;
        private double X;
        private float Y;
        private float b;
        public override void AI()
        {
            if (initialization)
            {
                X = (float)Math.Sqrt((double)Projectile.velocity.X * (double)Projectile.velocity.X + (double)Projectile.velocity.Y * (double)Projectile.velocity.Y);
                b = Main.rand.Next(-50, 50);
                initialization = false;
                if(Main.rand.Next(0,2) == 1)
                {
                    Y = (float)Math.Sin((double)X / 5f * 3.1415926535f / 1f) / 1000 + 1;
                }
                else
                {
                    Y = (float)Math.Sin(-(double)X / 5f * 3.1415926535f / 1f) / 1000 + 1;
                }
            }
            base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) - (float)Math.PI * 0.5f;
            if (Projectile.timeLeft < 580 && Projectile.timeLeft >= 100 + (float)b)
            {
                Projectile.scale *= (float)Y;
            }
            if (Projectile.timeLeft < 100+ (float)b)
            {
                Projectile.scale *= 0.95f;
            }
            if (Projectile.timeLeft < 800)
            {
                Projectile.velocity.Y += 0.01f;
            }
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0f / 255f * Projectile.scale, (float)(255 - base.Projectile.alpha) * 0.1f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f * Projectile.scale);
        }
        public override void Kill(int timeLeft)
        {
            if (timeLeft != 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(0f, 3f)).RotatedByRandom(Math.PI * 2);
                    int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 3, v.X, v.Y, 100, Color.White, 1f);
                    Main.dust[num].noGravity = false;
                }
            }
        }
    }
}