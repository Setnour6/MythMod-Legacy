using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
    public class CuFlame : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("铜钱爆炸");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 210;
			base.projectile.height = 210;
			base.projectile.hostile = false;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = -1;
            base.projectile.tileCollide = false;
            base.projectile.timeLeft = 50;
            base.projectile.friendly = true;
			this.cooldownSlot = 1;
            base.projectile.scale = 0;

        }
        private bool boom = false;
		public override void AI()
		{
            if(Main.rand.Next(20) == 1 && !boom)
            {
                boom = true;
            }
            if(boom && base.projectile.scale <= 0.6f)
            {
                base.projectile.scale += 0.05f;
            }
            else
            {
                base.projectile.scale += (float)(1 - base.projectile.scale) / 8f;
            }
		}
		public override Color? GetAlpha(Color lightColor)
		{
            if(base.projectile.timeLeft > 30)
            {
                return new Color?(new Color(95, 95, 95, 0));
            }
            else
            {
                return new Color?(new Color(base.projectile.timeLeft / 30f * (95 / 255f), base.projectile.timeLeft / 30f * (95 / 255f), base.projectile.timeLeft / 30f * (95 / 255f), 0));
            }
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
