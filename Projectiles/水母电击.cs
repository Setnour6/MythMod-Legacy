using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200057F RID: 1407
    public class 水母电击 : ModProjectile
	{
		// Token: 0x06001EC3 RID: 7875 RVA: 0x0000C81D File Offset: 0x0000AA1D
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("水母电击");
			Main.projFrames[base.projectile.type] = 4;
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x0018A990 File Offset: 0x00188B90
		public override void SetDefaults()
		{
			base.projectile.width = 100;
			base.projectile.height = 100;
			base.projectile.hostile = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 600;
			this.cooldownSlot = 1;
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x0018AA00 File Offset: 0x00188C00
		public override void AI()
		{
			if (Math.Abs(base.projectile.velocity.X) + Math.Abs(base.projectile.velocity.Y) < 16f)
			{
				base.projectile.velocity *= 0.99f;
			}
			if(base.projectile.timeLeft % 60 == 58)
			{
				int num5 = (int)Player.FindClosest(base.projectile.Center, 1, 1);
				float num6 = (float)Math.Sqrt((Main.player[num5].Center.X - base.projectile.Center.X) * (Main.player[num5].Center.X - base.projectile.Center.X) + (Main.player[num5].Center.Y - base.projectile.Center.Y) * (Main.player[num5].Center.Y - base.projectile.Center.Y));
				Vector2 vector = (Main.player[num5].Center - base.projectile.Center) / num6;
				Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, vector.X, vector.Y, base.mod.ProjectileType("水母闪电"), 54, 0, Main.myPlayer, 0f, 0f);
				for(int num1 = 0;num1 < 12;num1++)
				{
					Vector2 vector3 = vector.RotatedBy((float)Math.PI * num1 / 6f);
					Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, vector3.X * 2.5f, vector3.Y * 2.5f, base.mod.ProjectileType("胭脂射线"), 44, 0, Main.myPlayer, 0f, 0f);
				}
			}
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;
			base.projectile.frameCounter++;
			if (base.projectile.frameCounter > 4)
			{
				base.projectile.frame++;
				base.projectile.frameCounter = 0;
			}
			if (base.projectile.frame > 3)
			{
				base.projectile.frame = 0;
			}
			if (projectile.timeLeft < 85)
            {
                projectile.alpha += 3;
            }
			if (projectile.timeLeft < 60)
            {
                projectile.hostile = false;
            }
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.75f / 255f, (float)(255 - base.projectile.alpha) * 0.15f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f);
		}

		// Token: 0x06001EC6 RID: 7878 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
			if(projectile.timeLeft > 100)
			{			
				if(projectile.timeLeft > 500)
			    {
				    return new Color?(new Color(1 * (600 - projectile.timeLeft) / 100f, 1 * (600 - projectile.timeLeft) / 100f, 1 * (600 - projectile.timeLeft) / 100f, base.projectile.alpha));
			    }
				else
				{
					return new Color?(new Color(255, 255, 255, base.projectile.alpha));
				}
			}
			else
			{
				return new Color?(new Color(1 * projectile.timeLeft / 100f, 1 * projectile.timeLeft / 100f, 1 * projectile.timeLeft / 100f, base.projectile.alpha));
			}
		}

		// Token: 0x06001EC7 RID: 7879 RVA: 0x0000C861 File Offset: 0x0000AA61
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
