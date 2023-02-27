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
    public class RedArrow2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("RedArrow");
        }
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.aiStyle = -1;
            projectile.friendly = false;
            projectile.hostile = true;
            projectile.alpha = 255;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 480;
            projectile.penetrate = 1;
            projectile.scale = 1;
        }
        private bool initialization = true;
        private double X;
        private float Omega;
        private float b;
        private float K = 10;

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color((255 - projectile.alpha) /255f, (255 - projectile.alpha) / 255f, (255 - projectile.alpha) / 255f, 0));
        }
        public override void AI()
        {
            projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X);
            projectile.velocity *= 1.02f;
            if(projectile.alpha > 0)
            {
                projectile.alpha -= 5;
            }
            else
            {
                projectile.alpha = 0;
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