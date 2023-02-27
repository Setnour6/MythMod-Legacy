using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200057F RID: 1407
    public class 星烛冰海光 : ModProjectile
	{
		// Token: 0x06001EC3 RID: 7875 RVA: 0x0000C81D File Offset: 0x0000AA1D
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("星烛冰海光");
			Main.projFrames[base.projectile.type] = 1;
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x0018A990 File Offset: 0x00188B90
		public override void SetDefaults()
		{
			base.projectile.width = 42;
			base.projectile.height = 42;
			base.projectile.hostile = false;
			base.projectile.friendly = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 1500;
			this.cooldownSlot = 1;
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x0018AA00 File Offset: 0x00188C00
		public override void AI()
		{
			base.projectile.rotation -= (float)Math.Sqrt((float)projectile.velocity.X * (float)projectile.velocity.X + (float)projectile.velocity.Y * (float)projectile.velocity.Y) * 0.003f;
			if (Math.Abs(base.projectile.velocity.X) + Math.Abs(base.projectile.velocity.Y) < 16f)
			{
				base.projectile.velocity *= 1.005f;
			}
			float num2 = base.projectile.Center.X;
		    float num3 = base.projectile.Center.Y;
		    float num4 = 400f;
		    bool flag = false;
			for (int j = 0; j < 200; j++)
			{
                if (Main.npc[j].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    float num7 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num5) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num6);
                    if (num7 < num4)
                    {
                        num4 = num7;
                        num2 = num5;
                        num3 = num6;
                        flag = true;
                    }
                }
			}
			if (flag)
			{
				float num8 = 20f;
				Vector2 vector1 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
				float num9 = num2 - vector1.X;
				float num10 = num3 - vector1.Y;
				float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
				num11 = num8 / num11;
				num9 *= num11;
				num10 *= num11;
				base.projectile.velocity.X = (base.projectile.velocity.X * 20f + num9) / 21f;
				base.projectile.velocity.Y = (base.projectile.velocity.Y * 20f + num10) / 21f;
			}
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 1f / 255f, (float)(255 - base.projectile.alpha) * 0.05f / 255f, (float)(255 - base.projectile.alpha) * 0.05f / 255f);
			int p = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 1.5f, 0, 0, 183, 0, 0, 0, default(Color), 2f);
			Main.dust[p].velocity.X = (float)Math.Sin((float)base.projectile.timeLeft / 30f * Math.PI) * 4f;
			Main.dust[p].velocity.Y = (float)Math.Cos((float)base.projectile.timeLeft / 30f * Math.PI) * 4f;
			Main.dust[p].noGravity = true;
			int q = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 1.5f, 0, 0, 183, 0, 0, 0, default(Color), 2f);
			Main.dust[q].velocity.X = (float)Math.Sin((float)base.projectile.timeLeft / 30f * Math.PI + 1.333333333333f * Math.PI) * 4f;
			Main.dust[q].velocity.Y = (float)Math.Cos((float)base.projectile.timeLeft / 30f * Math.PI + 1.333333333333f * Math.PI) * 4f;
			Main.dust[q].noGravity = true;
			int r = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 1.5f, 0, 0, 183, 0, 0, 0, default(Color), 2f);
			Main.dust[r].velocity.X = (float)Math.Sin((float)base.projectile.timeLeft / 30f * Math.PI + 0.666666666667f * Math.PI) * 4f;
			Main.dust[r].velocity.Y = (float)Math.Cos((float)base.projectile.timeLeft / 30f * Math.PI + 0.666666666667f * Math.PI) * 4f;
			Main.dust[r].noGravity = true;
			int k = Dust.NewDust( new Vector2(base.projectile.Center.X , base.projectile.Center.Y) + base.projectile.velocity * 1.5f, 0, 0, 262, 0, 0, 0, default(Color), 0.8f);
			Main.dust[k].noGravity = true;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
			int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
			int y = num * base.projectile.frame;
			Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
		public override void Kill(int timeLeft)
        {
			float num12 = Main.rand.Next(-10000,10000)/10000f;
            for (int i = 0; i < 3; i++)
            {
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)(Math.Sin(((float)i / 1.5f) * 3.14159265359f + (float)num12) * 3.0), (float)(Math.Cos(((float)i / 1.5f) * 3.14159265359f + (float)num12) * 3.0), base.mod.ProjectileType("星烛冰海光2"), (int)((double)base.projectile.damage * 0.1f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
        }
	}
}
