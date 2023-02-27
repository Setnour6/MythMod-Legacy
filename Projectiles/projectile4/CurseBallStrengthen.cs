using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles.projectile4
{
    public class CurseBallStrengthen : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("咒火球");
        }
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.tileCollide = true;
            projectile.timeLeft = 1800;
            projectile.penetrate = 1;
            projectile.scale = 0;
        }
        private bool Down = false;
        private double X;
        private float Omega;
        private float b;
        private float K = 10;

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(0, 0, 0, 0));
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X);
            if(!Down)
            {
                projectile.scale += 0.02f;
            }
            else
            {
                projectile.velocity.Y += 0.01f;
            }
            if(projectile.scale > 0.8f)
            {
                if(Main.rand.Next(300) == 1)
                {
                    Down = true;
                }
            }
            if (projectile.scale > 1.5f)
            {
                if (Main.rand.Next(100) == 1)
                {
                    Down = true;
                }
            }
            if (projectile.scale > 2f)
            {
                Down = true;
            }
            if(!Down)
            {
                int num2 = Dust.NewDust(projectile.Center - new Vector2(4, 4), 8, 8, 75, 0f, 0f, 0, default(Color), 1.2f * projectile.scale);
                Main.dust[num2].velocity *= 0.0f;
            }
            else
            {
                int num2 = Dust.NewDust(projectile.Center - new Vector2(4, 4), 8, 8, 75, 0f, 0f, 0, default(Color), 2.4f * projectile.scale);
                Main.dust[num2].noGravity = true;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
            int y = num * base.projectile.frame;
            SpriteEffects effects = SpriteEffects.None;
            if (base.projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            int frameHeight = 26;
            Vector2 value = new Vector2(base.projectile.Center.X, base.projectile.Center.Y);
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            Vector2 vector2 = value - Main.screenPosition;
            return true;
        }
    }
}