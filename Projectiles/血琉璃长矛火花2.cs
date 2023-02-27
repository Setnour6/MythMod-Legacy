using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200057F RID: 1407
    public class 血琉璃长矛火花2 : ModProjectile
	{
		// Token: 0x06001EC3 RID: 7875 RVA: 0x0000C81D File Offset: 0x0000AA1D
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("血琉璃长矛火花2");
			Main.projFrames[base.projectile.type] = 1;
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x0018A990 File Offset: 0x00188B90
		public override void SetDefaults()
		{
			base.projectile.width = 34;
			base.projectile.height = 34;
			base.projectile.hostile = false;
			base.projectile.friendly = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 60;
			this.cooldownSlot = 1;
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x0018AA00 File Offset: 0x00188C00
		public override void AI()
		{
			base.projectile.rotation -= (float)Math.Sqrt((float)projectile.velocity.X * (float)projectile.velocity.X + (float)projectile.velocity.Y * (float)projectile.velocity.Y) * 0.003f;
			base.projectile.velocity *= 0.98f;
			if(projectile.timeLeft < 60)
			{
				base.projectile.scale = (float)projectile.timeLeft / 60;
				base.projectile.damage = (int)(80 * (float)projectile.scale);
				base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;
			    Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.8f / 255f, (float)(255 - base.projectile.alpha) * 0.04f / 255f, (float)(255 - base.projectile.alpha) * 0.04f / 255f);
		    	int p = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 1.5f, 0, 0, 183, 0, 0, 0, default(Color), 2f * (float)projectile.timeLeft / 90);
		    	Main.dust[p].velocity.X = (float)Math.Sin((float)base.projectile.timeLeft / 9f * Math.PI) * 1f;
		    	Main.dust[p].velocity.Y = (float)Math.Cos((float)base.projectile.timeLeft / 9f * Math.PI) * 1f;
		    	Main.dust[p].noGravity = true;
		    	int k = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 1.5f, 0, 0, 262, 0, 0, 0, default(Color), 0.6f * (float)projectile.timeLeft / 90);
		    	Main.dust[k].noGravity = true;
			}
            else
			{
			    base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;
			    Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.8f / 255f, (float)(255 - base.projectile.alpha) * 0.04f / 255f, (float)(255 - base.projectile.alpha) * 0.04f / 255f);
		    	int p = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 1.5f, 0, 0, 183, 0, 0, 0, default(Color), 2f);
		    	Main.dust[p].velocity.X = (float)Math.Sin((float)base.projectile.timeLeft / 9f * Math.PI) * 1f;
		    	Main.dust[p].velocity.Y = (float)Math.Cos((float)base.projectile.timeLeft / 9f * Math.PI) * 1f;
		    	Main.dust[p].noGravity = true;
		    	int k = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 1.5f, 0, 0, 262, 0, 0, 0, default(Color), 0.6f);
		    	Main.dust[k].noGravity = true;
			}
		}

		// Token: 0x06001EC6 RID: 7878 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
		}

		// Token: 0x06001EC8 RID: 7880 RVA: 0x0018AB58 File Offset: 0x00188D58
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
