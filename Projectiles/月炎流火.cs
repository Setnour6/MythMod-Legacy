using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
    public class 月炎流火 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("月炎流火");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 6;
			base.Projectile.height = 6;
			base.Projectile.hostile = true;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = true;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 2400;
            base.Projectile.friendly = false;
			this.CooldownSlot = 1;
		}
		public override void AI()
		{
            int ID = Dust.NewDust(Projectile.position, 0, 0, 229, Projectile.velocity.X * 0.03f, Projectile.velocity.Y * 0.03f, 201, default(Color), 1.6f);/*粉尘效果不用管*/
            int ID2 = Dust.NewDust(Projectile.position, 0, 0, 229, Projectile.velocity.X * 0.03f, Projectile.velocity.Y * 0.03f, 201, default(Color), 1.3f);/*粉尘效果不用管*/
            int ID3 = Dust.NewDust(Projectile.position, 0, 0, 229, Projectile.velocity.X * 0.03f, Projectile.velocity.Y * 0.03f, 201, default(Color), 1.6f);/*粉尘效果不用管*/
			Main.dust[ID].noGravity = true;
			Main.dust[ID2].noGravity = true;
			Main.dust[ID3].noGravity = true;
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0.2f / 255f, (float)(255 - base.Projectile.alpha) * 1f / 255f);
			if (base.Projectile.velocity.X < 0f)
			{
				base.Projectile.rotation = (float)Math.Atan2(-(double)base.Projectile.velocity.Y, -(double)base.Projectile.velocity.X);
				return;
			}
			base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X);
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
		}
		public override void Kill(int timeLeft)
		{
            for (int i = 0; i < 18; i++)
            {
                int num = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 229, base.Projectile.velocity.X * 0f, base.Projectile.velocity.Y * 0f, 150, new Color(Main.DiscoR, 100, 255), 1.8f);
                Main.dust[num].noGravity = true;
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
