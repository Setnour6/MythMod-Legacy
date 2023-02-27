using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.Effects
{
    public class RedGemDust2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("红宝石火粒");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 6;
			base.projectile.height = 6;
			base.projectile.hostile = false;
			base.projectile.friendly = false;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.alpha = 255;
			base.projectile.penetrate = 1;
			base.projectile.extraUpdates = 4;
			base.projectile.timeLeft = 60;
			this.cooldownSlot = 1;
		}
		public override void AI()
		{
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 1.2f / 255f * projectile.timeLeft / 60f, (float)(255 - base.projectile.alpha) * 0f / 255f * projectile.timeLeft / 60f, (float)(255 - base.projectile.alpha) * 0f / 255f * projectile.timeLeft / 60f);
            if (base.projectile.ai[0] == 0f)
			{
				base.projectile.ai[0] = 1f;
			}
			if (base.projectile.alpha > 0)
			{
				base.projectile.alpha -= 25;
			}
			if (base.projectile.alpha < 0)
			{
				base.projectile.alpha = 0;
			}
			float num = 50f;
			float num2 = 1.5f;
			if (base.projectile.ai[1] == 0f)
			{
				base.projectile.localAI[0] += num2;
				if (base.projectile.localAI[0] > num)
				{
					base.projectile.localAI[0] = num;
					return;
				}
			}
			else
			{
				base.projectile.localAI[0] -= num2;
				if (base.projectile.localAI[0] <= 0f)
				{
					base.projectile.Kill();
				}
			}
            if (Omega == 0)
            {
                Omega = Main.rand.NextFloat(-0.02f, 0.02f);
            }
            Omega += Main.rand.NextFloat(-0.0008f, 0.0008f);
            projectile.velocity *= 0.92f;
            projectile.velocity = projectile.velocity.RotatedBy((1f / (projectile.velocity.Length() + 0.00001f) * Omega));
        }
        private double Omega = 0;
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(175, 175, 175, 0));
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Color color = Lighting.GetColor((int)((double)base.projectile.position.X + (double)base.projectile.width * 0.5) / 16, (int)(((double)base.projectile.position.Y + (double)base.projectile.height * 0.5) / 16.0));
			int num = 0;
			int num2 = 0;
			float num3 = (float)(Main.projectileTexture[base.projectile.type].Width - base.projectile.width) * 0.5f + (float)base.projectile.width * 0.5f;
			SpriteEffects effects = SpriteEffects.None;
			if (base.projectile.spriteDirection == -1)
			{
				effects = SpriteEffects.FlipHorizontally;
			}
			Rectangle value = new Rectangle((int)Main.screenPosition.X - 500, (int)Main.screenPosition.Y - 500, Main.screenWidth + 1000, Main.screenHeight + 1000);
			if (base.projectile.getRect().Intersects(value))
			{
				Vector2 value2 = new Vector2(base.projectile.position.X - Main.screenPosition.X + num3 + (float)num2, base.projectile.position.Y - Main.screenPosition.Y + (float)(base.projectile.height / 2) + base.projectile.gfxOffY);
				float num4 = 25f;
				if(base.projectile.timeLeft < 60)
				{
					num4 =  25f / 60f * (float)base.projectile.timeLeft;
				}
				float scaleFactor = 1.5f;
				if (base.projectile.ai[1] == 1f)
				{
					num4 = (float)((int)base.projectile.localAI[0]);
				}
				for (int i = 1; i <= (int)(base.projectile.localAI[0] * projectile.velocity.Length() / 2f); i++)
				{
					Vector2 value3 = Vector2.Normalize(base.projectile.velocity) * (float)i * scaleFactor;
					Color color2 = base.projectile.GetAlpha(color);
					color2 *= (num4 - (float)i) / num4;
					color2.A = 0;
					Main.spriteBatch.Draw(Main.projectileTexture[base.projectile.type], value2 - value3, null, color2, base.projectile.rotation, new Vector2(num3, (float)(base.projectile.height / 2 + num)), base.projectile.scale, effects, 0f);
				}
			}
			return false;
		}
	}
}
