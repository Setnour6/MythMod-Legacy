using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class EruptWork : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("喷花");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 12;
			base.projectile.height = 12;
			base.projectile.hostile = true;
			base.projectile.friendly = false;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.alpha = 255;
			base.projectile.penetrate = -1;
			base.projectile.extraUpdates = 1;
			base.projectile.timeLeft = 150;
			this.cooldownSlot = 1;
            ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 20;
            ProjectileID.Sets.TrailingMode[base.projectile.type] = 0;
        }
        private float omega = 0;
        private int u = 0;
        public override void AI()
		{
            projectile.velocity.Y += 0.1f;
            if (projectile.timeLeft < 40 && projectile.timeLeft % 2 == 0)
            {
                u -= 1;
            }
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 1.5f / 255f, (float)(255 - base.projectile.alpha) * 1.2f / 255f, (float)(255 - base.projectile.alpha) * 0.8f / 255f);
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
		}
		public override Color? GetAlpha(Color lightColor)
		{
            if(projectile.timeLeft > 15)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color(projectile.timeLeft / 15f, projectile.timeLeft / 15f, projectile.timeLeft / 15f, 0));
            }
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
				for (int i = 1; i < projectile.oldPos.Length + u; i++)
				{
					Vector2 value3 = Vector2.Normalize(base.projectile.velocity) * (float)i * scaleFactor;
					Color color2 = base.projectile.GetAlpha(color);
					color2 *= (num4 - (float)i) / num4;
					color2.A = 0;
                    Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
                    Vector2 drawPos = projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY) + new Vector2(4, 4);
                    if(i < 5)
                    {
                        Main.spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile3/喷花尾迹"), drawPos, null, color2, base.projectile.rotation, new Vector2(num3, (float)(base.projectile.height / 2 + num)), base.projectile.scale + (5 - i) * 0.05f, effects, 0f);
                    }
                    else
                    {
                        Main.spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile3/喷花尾迹"), drawPos, null, color2, base.projectile.rotation, new Vector2(num3, (float)(base.projectile.height / 2 + num)), base.projectile.scale, effects, 0f);
                    }
				}
			}
            return true;
        }
	}
}
