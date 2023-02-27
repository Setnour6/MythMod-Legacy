using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile4
{
	public class DarkFire : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("紫冥鬼火");
            Main.projFrames[projectile.type] = 4;
		}
		public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 30;
			base.projectile.friendly = false;
            projectile.hostile = true;
            base.projectile.alpha = 255;
			base.projectile.penetrate = 10;
			base.projectile.tileCollide = false;
			base.projectile.timeLeft = 9000;
		}
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255 - projectile.alpha, 255 - projectile.alpha, 255 - projectile.alpha, 0));
        }
        public float num2 = 0;
        public override void AI()
        {
            if(projectile.timeLeft == 8999)
            {
                projectile.timeLeft = Main.rand.Next(180, 240);
            }
            if(num2 == 0)
            {
                num2 = Main.rand.Next(-100, 100) / 1000f;
            }
            base.projectile.frameCounter++;
            if (base.projectile.frameCounter > 6)
            {
                base.projectile.frame++;
                base.projectile.frameCounter = 0;
            }
            if (base.projectile.frame > 3)
            {
                base.projectile.frame = 0;
            }
            if (projectile.timeLeft >= 60)
            {
                if (projectile.alpha >= 5)
                {
                    projectile.alpha -= 5;
                }
                Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.12f / 255f , (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 0.48f / 255f);
            }
            else
            {
                if (projectile.alpha <= 250)
                {
                    projectile.alpha += 5;
                }
                Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.12f / 255f * projectile.timeLeft / 60f, (float)(255 - base.projectile.alpha) * 0f / 255f * projectile.timeLeft / 60f, (float)(255 - base.projectile.alpha) * 0.48f / 255f * projectile.timeLeft / 60f);
            }
            int pl = (int)Player.FindClosest(base.projectile.Center, 1, 1);
            if(Main.player[pl].velocity.Length() > 0)
            {
                projectile.velocity += (Main.player[pl].Center - projectile.Center) / (Main.player[pl].Center - projectile.Center).Length() * Main.player[pl].velocity.Length() * 0.024f;
            }
            projectile.velocity *= 0.96f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.timeLeft = 60;
            projectile.velocity *= 0;
            return false;
        }
        /*public override Color? GetAlpha(Color lightColor)
        {
            if (projectile.timeLeft > 60)
            {
                return new Color?(new Color(1f,1f,1f,1f));
            }
            else
            {
                return new Color?(new Color(1f * projectile.timeLeft / 60f, 1f * projectile.timeLeft / 60f, 1f * projectile.timeLeft / 60f, 1f * projectile.timeLeft / 60f));
            }
        }*/
        /*public override void Kill(int timeLeft)
		{
            Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 37, 0.5f, 0f);
        }*/
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
            int y = num * base.projectile.frame;
            Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY + projectile.height / 2f), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}
