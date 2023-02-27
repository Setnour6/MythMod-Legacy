using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x0200058D RID: 1421
    public class SulfurBullet : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("硫磺子弹");
			Main.projFrames[base.projectile.type] = 1;
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.projectile.width = 30;
			base.projectile.height = 10;
			base.projectile.hostile = false;
            base.projectile.friendly = true;
            base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 300;
			base.projectile.alpha = 0;
			this.cooldownSlot = 1;
		}
		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.6f / 255f, (float)(255 - base.projectile.alpha) * 0.6f / 255f, (float)(255 - base.projectile.alpha) * 0.6f / 255f);
			base.projectile.spriteDirection = 1;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X);
            int num = Dust.NewDust(new Vector2((float)base.projectile.Center.X - 4, (float)base.projectile.Center.Y - 4), 0, 0, 86, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, Color.White, 0.8f);
            Main.dust[num].noGravity = true;
            int num2 = Dust.NewDust(new Vector2((float)base.projectile.Center.X - 4, (float)base.projectile.Center.Y - 4), 0, 0, 88, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, Color.White, 0.8f);
            Main.dust[num2].noGravity = true;
        }
		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height;
			Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 1f);
			return false;
		}
		public override void Kill(int timeLeft)
		{
		    Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 0, 0, base.mod.ProjectileType("SulfurExplosion"), (int)((double)base.projectile.damage * 0.6f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            for (int j = 0; j < 30; j++)
            {
                int num2 = Dust.NewDust(new Vector2(base.projectile.Center.X - 4, base.projectile.Center.Y - 4), 0, 0, 86, (float)(1.5f * Math.Sin(Math.PI * (float)(j) / 15f)), (float)(1.5f * Math.Cos(Math.PI * (float)(j) / 15f)), 100, default(Color), 1.4f);
                Main.dust[num2].noGravity = true;
                num2 = Dust.NewDust(new Vector2(base.projectile.Center.X - 4, base.projectile.Center.Y - 4), 0, 0, 88, (float)(1.5f * Math.Sin(Math.PI * (float)(j) / 15f)), (float)(1.5f * Math.Cos(Math.PI * (float)(j) / 15f)), 100, default(Color), 1.4f);
                Main.dust[num2].noGravity = true;
            }
        }
	}
}
