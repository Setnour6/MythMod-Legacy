using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
    public class PtFlame : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("铂金钱爆炸");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 210;
			base.Projectile.height = 210;
			base.Projectile.hostile = false;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = -1;
            base.Projectile.tileCollide = false;
            base.Projectile.timeLeft = 50;
            base.Projectile.friendly = true;
			this.CooldownSlot = 1;
            base.Projectile.scale = 0;

        }
        private bool boom = false;
		public override void AI()
		{
            if(Main.rand.Next(20) == 1 && !boom)
            {
                boom = true;
            }
            if(boom && base.Projectile.scale <= 0.9f)
            {
                base.Projectile.scale += 0.05f;
            }
            else
            {
                base.Projectile.scale += (float)(1.5f - base.Projectile.scale) / 8f;
            }
		}
		public override Color? GetAlpha(Color lightColor)
		{
            if(base.Projectile.timeLeft > 30)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color(base.Projectile.timeLeft / 30f * (255 / 255f), base.Projectile.timeLeft / 30f * (255 / 255f), base.Projectile.timeLeft / 30f * (255 / 255f), 0));
            }
		}
		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
			int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
			int y = num * base.Projectile.frame;
			Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
	}
}
