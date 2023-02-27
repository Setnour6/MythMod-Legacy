using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class SuperCurseBallWave : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("咒火球冲击波");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 200;
            base.projectile.scale = 0f;
            base.projectile.height = 200;
			base.projectile.hostile = false;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 120;
            base.projectile.friendly = true;
			this.cooldownSlot = 1;
		}
        public override void AI()
        {
            base.projectile.scale += 0.08f;
        }
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(100,100,100, 0) * ((projectile.timeLeft) / 120f)) * (0.25f / projectile.scale);
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
			int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
			int y = num * base.projectile.frame;
			Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
    }
}
