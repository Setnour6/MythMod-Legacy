using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200058D RID: 1421
    public class 连线星星 : ModProjectile
	{
		// Token: 0x06001F14 RID: 7956 RVA: 0x0000C97C File Offset: 0x0000AB7C
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("连线星星");
			Main.projFrames[base.projectile.type] = 1;
		}

		// Token: 0x06001F15 RID: 7957 RVA: 0x0018D09C File Offset: 0x0018B29C
		public override void SetDefaults()
		{
			base.projectile.width = 40;
			base.projectile.height = 40;
			base.projectile.hostile = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 600;
			base.projectile.alpha = 0;
			base.projectile.extraUpdates = 2;
            base.projectile.friendly = false;
			this.cooldownSlot = 1;
		}

		// Token: 0x06001F16 RID: 7958 RVA: 0x0018D118 File Offset: 0x0018B318
		public override void AI()
		{
			projectile.velocity *= 0.985f;
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f);
			if (projectile.timeLeft > 100)
            {
		       	int ID = Dust.NewDust(projectile.Center - new Vector2(4, 4), 0, 0, 159, 0, 0, 0, default(Color), 1.4f);/*粉尘效果不用管*/
		    	Main.dust[ID].noGravity = true;
		    	Main.dust[ID].velocity *= 0;
			}
			else
			{
				int ID = Dust.NewDust(projectile.Center - new Vector2(4, 4), 0, 0, 159, 0, 0, 0, default(Color), 1.4f * projectile.timeLeft / 100);/*粉尘效果不用管*/
		    	Main.dust[ID].noGravity = true;
		    	Main.dust[ID].velocity *= 0;
			}
			if (projectile.timeLeft < 100)
            {
                projectile.scale *= 0.95f;
            }
			if (projectile.timeLeft < 60)
            {
                projectile.hostile = false;
            }
			if (projectile.timeLeft > 99 && projectile.timeLeft % 100 == 0)
			{
                projectile.velocity = new Vector2(Main.rand.Next(-140, 140) / 28f, Main.rand.Next(-140, 140) / 28f);
			}
			if (projectile.timeLeft % 100 == 1)
			{
				int num = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y,0, 0, base.mod.ProjectileType("爆炸星星"), 555, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
				Main.projectile[num].timeLeft = 0;
			}
		}

		// Token: 0x06001F17 RID: 7959 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
		}
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
		public override void Kill(int timeLeft)
		{
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
