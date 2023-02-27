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
            DisplayName.SetDefault("桔叶飞刀");
        }
        public override void SetDefaults()
        {
            projectile.width = 16;
            projectile.height = 16;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.extraUpdates = 3;
            projectile.timeLeft = 1000;
            projectile.alpha = 0;
            projectile.penetrate = 1;
            projectile.scale = 1f;
            this.cooldownSlot = 1;
        }
        private bool initialization = true;
        private double X;
        private float Y;
        private float b;
        public override void AI()
        {
            if (initialization)
            {
                X = (float)Math.Sqrt((double)projectile.velocity.X * (double)projectile.velocity.X + (double)projectile.velocity.Y * (double)projectile.velocity.Y);
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
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) - (float)Math.PI * 0.5f;
            if (projectile.timeLeft < 580 && projectile.timeLeft >= 100 + (float)b)
            {
                projectile.scale *= (float)Y;
            }
            if (projectile.timeLeft < 100+ (float)b)
            {
                projectile.scale *= 0.95f;
            }
            if (projectile.timeLeft < 800)
            {
                projectile.velocity.Y += 0.01f;
            }
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0f / 255f * projectile.scale, (float)(255 - base.projectile.alpha) * 0.1f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f * projectile.scale);
        }
        public override void Kill(int timeLeft)
        {
            if (timeLeft != 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(0f, 3f)).RotatedByRandom(Math.PI * 2);
                    int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 3, v.X, v.Y, 100, Color.White, 1f);
                    Main.dust[num].noGravity = false;
                }
            }
        }
    }
}