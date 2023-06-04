using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class PearlBullet2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("珍珠弹");
			Main.projFrames[base.Projectile.type] = 1;
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 10;
			base.Projectile.height = 10;
			base.Projectile.hostile = false;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = true;
			base.Projectile.penetrate = 1;
            base.Projectile.alpha = 0;
            base.Projectile.friendly = true;
			this.CooldownSlot = 1;
		}
		public override void AI()
		{
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 173f / 255f / 255f, (float)(255 - base.Projectile.alpha) * 107f / 255f / 255f, (float)(255 - base.Projectile.alpha) * 83f / 255f / 255f);
			base.Projectile.spriteDirection = 1;
			base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X);
            if(Projectile.velocity.Length() < 12f)
            {
                Projectile.velocity *= 12f / Projectile.velocity.Length();
            }
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
		}
		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height;
			Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 1f);
			return false;
		}
        public override void Kill(int timeLeft)
		{
            for (int i = 0; i < 5; i++)
            {
                int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 51, 0f, 0f, 100, default(Color), 0.6f);
                Main.dust[num].velocity *= 0.2f;
            }
        }
    }
}
