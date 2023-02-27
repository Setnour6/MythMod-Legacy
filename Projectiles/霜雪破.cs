using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200058D RID: 1421
    public class 霜雪破 : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("霜雪破");
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.projectile.width = 6;
			base.projectile.height = 6;
			base.projectile.hostile = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 240;
            base.projectile.friendly = false;
			this.cooldownSlot = 1;
		}

		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
            int ID = Dust.NewDust(projectile.position, 0, 0, 180, projectile.velocity.X * 0.03f, projectile.velocity.Y * 0.03f, 201, default(Color), 1.6f);/*粉尘效果不用管*/
            int ID2 = Dust.NewDust(projectile.position, 0, 0, 187, projectile.velocity.X * 0.03f, projectile.velocity.Y * 0.03f, 201, default(Color), 1.3f);/*粉尘效果不用管*/
            int ID3 = Dust.NewDust(projectile.position, 0, 0, 172, projectile.velocity.X * 0.03f, projectile.velocity.Y * 0.03f, 201, default(Color), 1.6f);/*粉尘效果不用管*/
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
		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
		}
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
		public override void Kill(int timeLeft)
		{
			float num2 = Main.rand.Next(0, 10000) / 2000f;
			Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 20, 1f, 0f);
			for (int k = 0; k <= 6; k++)
			{
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y,(float)Math.Sin(k / 3f * Math.PI + num2) * 7f,(float)Math.Cos(k / 3f * Math.PI + num2) * 7f, base.mod.ProjectileType("霜雪破散裂"), base.projectile.damage / 4, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
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
