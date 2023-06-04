using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class EruptWork : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("喷花");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 12;
			base.Projectile.height = 12;
			base.Projectile.hostile = true;
			base.Projectile.friendly = false;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = true;
			base.Projectile.alpha = 255;
			base.Projectile.penetrate = -1;
			base.Projectile.extraUpdates = 1;
			base.Projectile.timeLeft = 150;
			this.CooldownSlot = 1;
            ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 20;
            ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
        }
        private float omega = 0;
        private int u = 0;
        public override void AI()
		{
            Projectile.velocity.Y += 0.1f;
            if (Projectile.timeLeft < 40 && Projectile.timeLeft % 2 == 0)
            {
                u -= 1;
            }
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 1.5f / 255f, (float)(255 - base.Projectile.alpha) * 1.2f / 255f, (float)(255 - base.Projectile.alpha) * 0.8f / 255f);
            if (base.Projectile.ai[0] == 0f)
			{
				base.Projectile.ai[0] = 1f;
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
		}
		public override Color? GetAlpha(Color lightColor)
		{
            if(Projectile.timeLeft > 15)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color(Projectile.timeLeft / 15f, Projectile.timeLeft / 15f, Projectile.timeLeft / 15f, 0));
            }
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
				float num4 = 25f;
				if(base.Projectile.timeLeft < 60)
				{
					num4 =  25f / 60f * (float)base.Projectile.timeLeft;
				}
				float scaleFactor = 1.5f;
				for (int i = 1; i < Projectile.oldPos.Length + u; i++)
				{
					Vector2 value3 = Vector2.Normalize(base.Projectile.velocity) * (float)i * scaleFactor;
					Color color2 = base.Projectile.GetAlpha(color);
					color2 *= (num4 - (float)i) / num4;
					color2.A = 0;
                    Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
                    Vector2 drawPos = Projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY) + new Vector2(4, 4);
                    if(i < 5)
                    {
                        Main.spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile3/喷花尾迹"), drawPos, null, color2, base.Projectile.rotation, new Vector2(num3, (float)(base.Projectile.height / 2 + num)), base.Projectile.scale + (5 - i) * 0.05f, effects, 0f);
                    }
                    else
                    {
                        Main.spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile3/喷花尾迹"), drawPos, null, color2, base.Projectile.rotation, new Vector2(num3, (float)(base.Projectile.height / 2 + num)), base.Projectile.scale, effects, 0f);
                    }
				}
			}
            return true;
        }
	}
}
