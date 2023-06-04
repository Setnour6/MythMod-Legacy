using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
    public class GlitterRay : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("灿金射线");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 6;
			base.Projectile.height = 12;
			base.Projectile.hostile = true;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = true;
			base.Projectile.alpha = 255;
			base.Projectile.penetrate = 1;
			base.Projectile.extraUpdates = 1;
			base.Projectile.timeLeft = 120;
			this.CooldownSlot = 1;
		}
		public override void AI()
		{
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.5f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0.2f / 255f);
			if (base.Projectile.ai[0] == 0f)
			{
				base.Projectile.ai[0] = 1f;
				SoundEngine.PlaySound(SoundID.Item12, new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
			}
			if (base.Projectile.alpha > 0)
			{
				base.Projectile.alpha -= 25;
			}
			if (base.Projectile.alpha < 0)
			{
				base.Projectile.alpha = 0;
			}
			float num = 50f;
			float num2 = 1.5f;
			if (base.Projectile.ai[1] == 0f)
			{
				base.Projectile.localAI[0] += num2;
				if (base.Projectile.localAI[0] > num)
				{
					base.Projectile.localAI[0] = num;
					return;
				}
			}
			else
			{
				base.Projectile.localAI[0] -= num2;
				if (base.Projectile.localAI[0] <= 0f)
				{
					base.Projectile.Kill();
				}
			}
		}
		public override Color? GetAlpha(Color lightColor)
		{
            if (Projectile.timeLeft >= 90)
            {
                return new Color?(new Color(255, 255, 0, 0));
            }
            else
            {
                return new Color?(new Color(Projectile.timeLeft / 90, Projectile.timeLeft / 90, 0, 0));
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 60; i++)
            {
                int num = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 57, base.Projectile.velocity.X * 0f, base.Projectile.velocity.Y * 0f, 150, new Color(Main.DiscoR, 100, 255), 1.2f);
                Main.dust[num].noGravity = true;
            }
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, 4f, 0f, base.Mod.Find<ModProjectile>("GlitterRay2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, -4f, 0f, base.Mod.Find<ModProjectile>("GlitterRay2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, 2f, 3.464101615f, base.Mod.Find<ModProjectile>("GlitterRay2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, -2f, 3.464101615f, base.Mod.Find<ModProjectile>("GlitterRay2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, 2f, -3.464101615f, base.Mod.Find<ModProjectile>("GlitterRay2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, -2f, -3.464101615f, base.Mod.Find<ModProjectile>("GlitterRay2").Type, base.Projectile.damage / 20, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
        }
		public override bool PreDraw(ref Color lightColor)
		{
			Color color = Lighting.GetColor((int)((double)base.Projectile.position.X + (double)base.Projectile.width * 0.5) / 16, (int)(((double)base.Projectile.position.Y + (double)base.Projectile.height * 0.5) / 16.0));
			int num = 0;
			int num2 = 0;
			float num3 = (float)(TextureAssets.Projectile[base.Projectile.type].Value.Width - base.Projectile.width) * 0.5f + (float)base.Projectile.width * 0.5f;
			SpriteEffects effects = SpriteEffects.None;
			if (base.Projectile.spriteDirection == -1)
			{
				effects = SpriteEffects.FlipHorizontally;
			}
			Rectangle value = new Rectangle((int)Main.screenPosition.X - 500, (int)Main.screenPosition.Y - 500, Main.screenWidth + 1000, Main.screenHeight + 1000);
			if (base.Projectile.getRect().Intersects(value))
			{
				Vector2 value2 = new Vector2(base.Projectile.position.X - Main.screenPosition.X + num3 + (float)num2, base.Projectile.position.Y - Main.screenPosition.Y + (float)(base.Projectile.height / 2) + base.Projectile.gfxOffY);
				float num4 = 50f;
				float scaleFactor = 1.5f;
				if (base.Projectile.ai[1] == 1f)
				{
					num4 = (float)((int)base.Projectile.localAI[0]);
				}
				for (int i = 1; i <= (int)base.Projectile.localAI[0]; i++)
				{
					Vector2 value3 = Vector2.Normalize(base.Projectile.velocity) * (float)i * scaleFactor;
					Color color2 = base.Projectile.GetAlpha(color);
					color2 *= (num4 - (float)i) / num4;
					color2.A = 0;
					Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, value2 - value3, null, color2, base.Projectile.rotation, new Vector2(num3, (float)(base.Projectile.height / 2 + num)), base.Projectile.scale, effects, 0f);
				}
			}
			return false;
		}
	}
}
