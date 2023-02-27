using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
    public class GlitterRay : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("灿金射线");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 6;
			base.projectile.height = 12;
			base.projectile.hostile = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.alpha = 255;
			base.projectile.penetrate = 1;
			base.projectile.extraUpdates = 1;
			base.projectile.timeLeft = 120;
			this.cooldownSlot = 1;
		}
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.5f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 0.2f / 255f);
			if (base.projectile.ai[0] == 0f)
			{
				base.projectile.ai[0] = 1f;
				Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 12, 1f, 0f);
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
		}
		public override Color? GetAlpha(Color lightColor)
		{
            if (projectile.timeLeft >= 90)
            {
                return new Color?(new Color(255, 255, 0, 0));
            }
            else
            {
                return new Color?(new Color(projectile.timeLeft / 90, projectile.timeLeft / 90, 0, 0));
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 60; i++)
            {
                int num = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 57, base.projectile.velocity.X * 0f, base.projectile.velocity.Y * 0f, 150, new Color(Main.DiscoR, 100, 255), 1.2f);
                Main.dust[num].noGravity = true;
            }
            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 4f, 0f, base.mod.ProjectileType("GlitterRay2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, -4f, 0f, base.mod.ProjectileType("GlitterRay2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 2f, 3.464101615f, base.mod.ProjectileType("GlitterRay2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, -2f, 3.464101615f, base.mod.ProjectileType("GlitterRay2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 2f, -3.464101615f, base.mod.ProjectileType("GlitterRay2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, -2f, -3.464101615f, base.mod.ProjectileType("GlitterRay2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
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
				float num4 = 50f;
				float scaleFactor = 1.5f;
				if (base.projectile.ai[1] == 1f)
				{
					num4 = (float)((int)base.projectile.localAI[0]);
				}
				for (int i = 1; i <= (int)base.projectile.localAI[0]; i++)
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
