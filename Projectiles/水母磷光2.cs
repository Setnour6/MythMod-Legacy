using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200057F RID: 1407
    public class 水母磷光2 : ModProjectile
	{
		// Token: 0x06001EC3 RID: 7875 RVA: 0x0000C81D File Offset: 0x0000AA1D
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("水母磷光");
			Main.projFrames[base.Projectile.type] = 1;
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x0018A990 File Offset: 0x00188B90
		public override void SetDefaults()
		{
			base.Projectile.width = 34;
			base.Projectile.height = 34;
			base.Projectile.hostile = true;
			base.Projectile.friendly = false;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = -1;
			base.Projectile.timeLeft = 240;
			this.CooldownSlot = 1;
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x0018AA00 File Offset: 0x00188C00
		public override void AI()
		{
			base.Projectile.rotation -= (float)Math.Sqrt((float)Projectile.velocity.X * (float)Projectile.velocity.X + (float)Projectile.velocity.Y * (float)Projectile.velocity.Y) * 0.003f;
			if (Math.Abs(base.Projectile.velocity.X) + Math.Abs(base.Projectile.velocity.Y) < 16f)
			{
				base.Projectile.velocity *= 1.005f;
			}
            Projectile.velocity = Projectile.velocity.RotatedBy(-Math.PI / 300f);
            if (Projectile.timeLeft < 100)
            {
                Projectile.scale *= 0.95f;
            }
            if (Projectile.timeLeft < 60)
            {
                Projectile.hostile = false;
            }
			if(Projectile.timeLeft < 90)
			{
				base.Projectile.scale = (float)Projectile.timeLeft / 90;
				base.Projectile.damage = (int)(80 * (float)Projectile.scale);
				base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) + 1.57f;
			    Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.8f / 255f, (float)(255 - base.Projectile.alpha) * 0.04f / 255f, (float)(255 - base.Projectile.alpha) * 0.04f / 255f);
		    	int p = Dust.NewDust( new Vector2(base.Projectile.Center.X , base.Projectile.Center.Y) + base.Projectile.velocity * 1.5f, 0, 0, 183, 0, 0, 0, default(Color), 2f * (float)Projectile.timeLeft / 90);
		    	Main.dust[p].velocity.X = 0;
		    	Main.dust[p].velocity.Y = 0;
		    	Main.dust[p].noGravity = true;
		    	int k = Dust.NewDust( new Vector2(base.Projectile.Center.X , base.Projectile.Center.Y) + base.Projectile.velocity * 1.5f, 0, 0, 262, 0, 0, 0, default(Color), 0.6f * (float)Projectile.timeLeft / 90);
		    	Main.dust[k].noGravity = true;
			}
            else
			{
			    base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) + 1.57f;
			    Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.8f / 255f, (float)(255 - base.Projectile.alpha) * 0.04f / 255f, (float)(255 - base.Projectile.alpha) * 0.04f / 255f);
		    	int p = Dust.NewDust( new Vector2(base.Projectile.Center.X , base.Projectile.Center.Y) + base.Projectile.velocity * 1.5f, 0, 0, 183, 0, 0, 0, default(Color), 2f);
		    	Main.dust[p].velocity.X = 0;
		    	Main.dust[p].velocity.Y = 0;
		    	Main.dust[p].noGravity = true;
		    	int k = Dust.NewDust( new Vector2(base.Projectile.Center.X , base.Projectile.Center.Y) + base.Projectile.velocity * 1.5f, 0, 0, 262, 0, 0, 0, default(Color), 0.6f);
		    	Main.dust[k].noGravity = true;
			}
		}

		// Token: 0x06001EC6 RID: 7878 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
		}

		// Token: 0x06001EC8 RID: 7880 RVA: 0x0018AB58 File Offset: 0x00188D58
		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
			int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
			int y = num * base.Projectile.frame;
			Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
	}
}
