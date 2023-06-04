using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x0200058D RID: 1421
    public class SulfurBullet : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("硫磺子弹");
			Main.projFrames[base.Projectile.type] = 1;
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.Projectile.width = 30;
			base.Projectile.height = 10;
			base.Projectile.hostile = false;
            base.Projectile.friendly = true;
            base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = true;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 300;
			base.Projectile.alpha = 0;
			this.CooldownSlot = 1;
		}
		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.6f / 255f, (float)(255 - base.Projectile.alpha) * 0.6f / 255f, (float)(255 - base.Projectile.alpha) * 0.6f / 255f);
			base.Projectile.spriteDirection = 1;
			base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X);
            int num = Dust.NewDust(new Vector2((float)base.Projectile.Center.X - 4, (float)base.Projectile.Center.Y - 4), 0, 0, 86, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 150, Color.White, 0.8f);
            Main.dust[num].noGravity = true;
            int num2 = Dust.NewDust(new Vector2((float)base.Projectile.Center.X - 4, (float)base.Projectile.Center.Y - 4), 0, 0, 88, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 150, Color.White, 0.8f);
            Main.dust[num2].noGravity = true;
        }
		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
		}
		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height;
			Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 1f);
			return false;
		}
		public override void Kill(int timeLeft)
		{
		    Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("SulfurExplosion").Type, (int)((double)base.Projectile.damage * 0.6f), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            for (int j = 0; j < 30; j++)
            {
                int num2 = Dust.NewDust(new Vector2(base.Projectile.Center.X - 4, base.Projectile.Center.Y - 4), 0, 0, 86, (float)(1.5f * Math.Sin(Math.PI * (float)(j) / 15f)), (float)(1.5f * Math.Cos(Math.PI * (float)(j) / 15f)), 100, default(Color), 1.4f);
                Main.dust[num2].noGravity = true;
                num2 = Dust.NewDust(new Vector2(base.Projectile.Center.X - 4, base.Projectile.Center.Y - 4), 0, 0, 88, (float)(1.5f * Math.Sin(Math.PI * (float)(j) / 15f)), (float)(1.5f * Math.Cos(Math.PI * (float)(j) / 15f)), 100, default(Color), 1.4f);
                Main.dust[num2].noGravity = true;
            }
        }
	}
}
