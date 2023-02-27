using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x020005F4 RID: 1524
    public class PhalaenopsisDust : ModProjectile
	{
		// Token: 0x06002156 RID: 8534 RVA: 0x0000D493 File Offset: 0x0000B693
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("蝴蝶兰粒子");
		}

		// Token: 0x06002157 RID: 8535 RVA: 0x001AC3AC File Offset: 0x001AA5AC
		public override void SetDefaults()
		{
			base.projectile.width = 4;
			base.projectile.height = 4;
			base.projectile.hostile = false;
			base.projectile.friendly = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
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
        // Token: 0x06002158 RID: 8536 RVA: 0x001791F4 File Offset: 0x001773F4
        public override void AI()
		{
            if(projectile.timeLeft < 40 && projectile.timeLeft % 2 == 0)
            {
                u -= 1;
            }
            if(omega == 0)
            {
                omega = Main.rand.NextFloat(-0.035f, 0.035f);
                base.projectile.timeLeft = Main.rand.Next(120,175);
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
                omega += Main.rand.NextFloat(-0.015f, 0.015f);
            }
            projectile.velocity = projectile.velocity.RotatedBy(omega);
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.5f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 0.2f / 255f);
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
            //projectile.velocity *= 0.9f;
		}

		// Token: 0x06002159 RID: 8537 RVA: 0x0000D47A File Offset: 0x0000B67A
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
        // Token: 0x06002159 RID: 8537 RVA: 0x0000D47A File Offset: 0x0000B67A
		// Token: 0x0600215A RID: 8538 RVA: 0x00177FCC File Offset: 0x001761CC
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
				for (int i = 1; i < projectile.oldPos.Length + u; i++)
				{
					Vector2 value3 = Vector2.Normalize(base.projectile.velocity) * (float)i * scaleFactor;
					Color color2 = base.projectile.GetAlpha(color);
					color2 *= (num4 - (float)i) / num4;
					color2.A = 0;
                    Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
                    Vector2 drawPos = projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                    Main.spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/蝴蝶兰粒子尾迹"), drawPos, null, color2, base.projectile.rotation, new Vector2(num3, (float)(base.projectile.height / 2 + num)), base.projectile.scale, effects, 0f);
				}
			}
            return true;
        }
	}
}
