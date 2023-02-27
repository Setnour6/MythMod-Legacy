using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
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
			base.projectile.width = 6;
			base.projectile.height = 6;
			base.projectile.hostile = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 2400;
            base.projectile.friendly = false;
			this.cooldownSlot = 1;
		}
		public override void AI()
		{
            int ID = Dust.NewDust(projectile.position, 0, 0, 229, projectile.velocity.X * 0.03f, projectile.velocity.Y * 0.03f, 201, default(Color), 1.6f);/*粉尘效果不用管*/
            int ID2 = Dust.NewDust(projectile.position, 0, 0, 229, projectile.velocity.X * 0.03f, projectile.velocity.Y * 0.03f, 201, default(Color), 1.3f);/*粉尘效果不用管*/
            int ID3 = Dust.NewDust(projectile.position, 0, 0, 229, projectile.velocity.X * 0.03f, projectile.velocity.Y * 0.03f, 201, default(Color), 1.6f);/*粉尘效果不用管*/
			Main.dust[ID].noGravity = true;
			Main.dust[ID2].noGravity = true;
			Main.dust[ID3].noGravity = true;
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 0.2f / 255f, (float)(255 - base.projectile.alpha) * 1f / 255f);
			if (base.projectile.velocity.X < 0f)
			{
				base.projectile.rotation = (float)Math.Atan2(-(double)base.projectile.velocity.Y, -(double)base.projectile.velocity.X);
				return;
			}
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X);
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
		}
		public override void Kill(int timeLeft)
		{
            for (int i = 0; i < 18; i++)
            {
                int num = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 229, base.projectile.velocity.X * 0f, base.projectile.velocity.Y * 0f, 150, new Color(Main.DiscoR, 100, 255), 1.8f);
                Main.dust[num].noGravity = true;
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
