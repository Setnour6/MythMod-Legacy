using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200058D RID: 1421
    public class 银河破影II : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("银河破影");
			Main.projFrames[base.projectile.type] = 1;
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.projectile.width = 30;
			base.projectile.height = 10;
			base.projectile.hostile = false;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 10;
			base.projectile.alpha = 0;
            base.projectile.friendly = true;
			this.cooldownSlot = 1;
		}
		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.6f / 255f, (float)(255 - base.projectile.alpha) * 0.6f / 255f, (float)(255 - base.projectile.alpha) * 0.6f / 255f);
			base.projectile.spriteDirection = 1;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X);
			base.projectile.velocity *= Main.rand.Next(98, 108) / 100f;
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
			for (int i = 0; i <= 5; i++)
			{
				float num4 = (float)(Main.rand.Next(0, 1000));
			    double num1 = Main.rand.Next(0, 1000) / 500f;
			    double num2 = Math.Sin((double)num1 * Math.PI) * num4 / 150f;
			    double num3 = Math.Cos((double)num1 * Math.PI) * num4 / 150f;
				Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num2, (float)num3, base.mod.ProjectileType("银河碎片"), (int)((double)base.projectile.damage * 1.6f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
			}
		}
	}
}
