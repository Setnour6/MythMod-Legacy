using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
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
			Main.projFrames[base.Projectile.type] = 4;
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x0018A990 File Offset: 0x00188B90
		public override void SetDefaults()
		{
			base.Projectile.width = 100;
			base.Projectile.height = 100;
			base.Projectile.hostile = true;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 600;
			this.CooldownSlot = 1;
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x0018AA00 File Offset: 0x00188C00
		public override void AI()
		{
			if (Math.Abs(base.Projectile.velocity.X) + Math.Abs(base.Projectile.velocity.Y) < 16f)
			{
				base.Projectile.velocity *= 0.99f;
			}
			if(base.Projectile.timeLeft % 60 == 58)
			{
				int num5 = (int)Player.FindClosest(base.Projectile.Center, 1, 1);
				float num6 = (float)Math.Sqrt((Main.player[num5].Center.X - base.Projectile.Center.X) * (Main.player[num5].Center.X - base.Projectile.Center.X) + (Main.player[num5].Center.Y - base.Projectile.Center.Y) * (Main.player[num5].Center.Y - base.Projectile.Center.Y));
				Vector2 vector = (Main.player[num5].Center - base.Projectile.Center) / num6;
				Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, vector.X, vector.Y, base.Mod.Find<ModProjectile>("水母闪电").Type, 54, 0, Main.myPlayer, 0f, 0f);
				for(int num1 = 0;num1 < 12;num1++)
				{
					Vector2 vector3 = vector.RotatedBy((float)Math.PI * num1 / 6f);
					Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, vector3.X * 2.5f, vector3.Y * 2.5f, base.Mod.Find<ModProjectile>("胭脂射线").Type, 44, 0, Main.myPlayer, 0f, 0f);
				}
			}
			base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) + 1.57f;
			base.Projectile.frameCounter++;
			if (base.Projectile.frameCounter > 4)
			{
				base.Projectile.frame++;
				base.Projectile.frameCounter = 0;
			}
			if (base.Projectile.frame > 3)
			{
				base.Projectile.frame = 0;
			}
			if (Projectile.timeLeft < 85)
            {
                Projectile.alpha += 3;
            }
			if (Projectile.timeLeft < 60)
            {
                Projectile.hostile = false;
            }
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.75f / 255f, (float)(255 - base.Projectile.alpha) * 0.15f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f);
		}

		// Token: 0x06001EC6 RID: 7878 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
			if(Projectile.timeLeft > 100)
			{			
				if(Projectile.timeLeft > 500)
			    {
				    return new Color?(new Color(1 * (600 - Projectile.timeLeft) / 100f, 1 * (600 - Projectile.timeLeft) / 100f, 1 * (600 - Projectile.timeLeft) / 100f, base.Projectile.alpha));
			    }
				else
				{
					return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
				}
			}
			else
			{
				return new Color?(new Color(1 * Projectile.timeLeft / 100f, 1 * Projectile.timeLeft / 100f, 1 * Projectile.timeLeft / 100f, base.Projectile.alpha));
			}
		}

		// Token: 0x06001EC7 RID: 7879 RVA: 0x0000C861 File Offset: 0x0000AA61
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
