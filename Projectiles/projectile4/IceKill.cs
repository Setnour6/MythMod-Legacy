using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile4
{
	public class IceKill : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("");
            Main.projFrames[projectile.type] = 11;
		}
		public override void SetDefaults()
		{
			base.projectile.width = 410;
			base.projectile.height = 398;
			base.projectile.friendly = true;
			base.projectile.alpha = 0;
			base.projectile.penetrate = 1;
			base.projectile.tileCollide = false;
			base.projectile.timeLeft = 44;
		}
        public float num2 = 0;
        public override void AI()
        {
            base.projectile.frameCounter++;
            if (base.projectile.frameCounter > 3)
            {
                base.projectile.frame++;
                base.projectile.frameCounter = 0;
            }
            if (base.projectile.frame > 10)
            {
                base.projectile.frame = 0;
            }
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0f / 255f * projectile.timeLeft / 60f, (float)(255 - base.projectile.alpha) * 0.15f / 255f * projectile.timeLeft / 60f, (float)(255 - base.projectile.alpha) * 0.72f / 255f * projectile.timeLeft / 60f);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(1f, 1f, 1f, 0));
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
