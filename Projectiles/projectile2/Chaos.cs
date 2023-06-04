using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x020005F4 RID: 1524
    public class Chaos : ModProjectile
	{
		// Token: 0x06002156 RID: 8534 RVA: 0x0000D493 File Offset: 0x0000B693
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("混乱粒子");
		}

		// Token: 0x06002157 RID: 8535 RVA: 0x001AC3AC File Offset: 0x001AA5AC
		public override void SetDefaults()
		{
			base.Projectile.width = 4;
			base.Projectile.height = 4;
			base.Projectile.hostile = false;
			base.Projectile.friendly = true;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = true;
			base.Projectile.alpha = 255;
			base.Projectile.penetrate = 1;
			base.Projectile.extraUpdates = 1;
			base.Projectile.timeLeft = 150;
			this.CooldownSlot = 1;
            ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 20;
            ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
        }
        private float omega = 0;
        private int u = 0;
        // Token: 0x06002158 RID: 8536 RVA: 0x001791F4 File Offset: 0x001773F4
        public override void AI()
		{
            if(Projectile.timeLeft < 40 && Projectile.timeLeft % 2 == 0)
            {
                u -= 1;
            }
            if(omega == 0)
            {
                omega = Main.rand.NextFloat(-0.035f, 0.035f);
                base.Projectile.timeLeft = Main.rand.Next(120,175);
            }
            if(omega < -0.065f)
            {
                omega += 0.001f;
            }
            if(omega > 0.065f)
            {
                omega -= 0.001f;
            }
            if(omega >= -0.065f && omega <= 0.065f)
            {
                omega += Main.rand.NextFloat(-0.015f, 0.015f) / 6f;
            }
            Projectile.velocity = Projectile.velocity.RotatedBy(omega);
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.5f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0.2f / 255f);
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
            //projectile.velocity *= 0.9f;
		}

		// Token: 0x06002159 RID: 8537 RVA: 0x0000D47A File Offset: 0x0000B67A
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, 0));
		}
        // Token: 0x06002159 RID: 8537 RVA: 0x0000D47A File Offset: 0x0000B67A
		// Token: 0x0600215A RID: 8538 RVA: 0x00177FCC File Offset: 0x001761CC
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
				if (base.Projectile.ai[1] == 1f)
				{
					num4 = (float)((int)base.Projectile.localAI[0]);
				}
				for (int i = 1; i < Projectile.oldPos.Length + u; i++)
				{
					Vector2 value3 = Vector2.Normalize(base.Projectile.velocity) * (float)i * scaleFactor;
					Color color2 = base.Projectile.GetAlpha(color);
					color2 *= (num4 - (float)i) / num4;
					color2.A = 0;
                    Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
                    Vector2 drawPos = Projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                    Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, drawPos, null, color2, base.Projectile.rotation, new Vector2(num3, (float)(base.Projectile.height / 2 + num)), base.Projectile.scale, effects, 0f);
				}
			}
            return true;
        }
	}
}
