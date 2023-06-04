using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200057F RID: 1407
    public class 星烛冰海光 : ModProjectile
	{
		// Token: 0x06001EC3 RID: 7875 RVA: 0x0000C81D File Offset: 0x0000AA1D
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("星烛冰海光");
			Main.projFrames[base.Projectile.type] = 1;
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x0018A990 File Offset: 0x00188B90
		public override void SetDefaults()
		{
			base.Projectile.width = 42;
			base.Projectile.height = 42;
			base.Projectile.hostile = false;
			base.Projectile.friendly = true;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 1500;
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
			float num2 = base.Projectile.Center.X;
		    float num3 = base.Projectile.Center.Y;
		    float num4 = 400f;
		    bool flag = false;
			for (int j = 0; j < 200; j++)
			{
                if (Main.npc[j].CanBeChasedBy(base.Projectile, false) && Collision.CanHit(base.Projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    float num7 = Math.Abs(base.Projectile.position.X + (float)(base.Projectile.width / 2) - num5) + Math.Abs(base.Projectile.position.Y + (float)(base.Projectile.height / 2) - num6);
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
				Vector2 vector1 = new Vector2(base.Projectile.position.X + (float)base.Projectile.width * 0.5f, base.Projectile.position.Y + (float)base.Projectile.height * 0.5f);
				float num9 = num2 - vector1.X;
				float num10 = num3 - vector1.Y;
				float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
				num11 = num8 / num11;
				num9 *= num11;
				num10 *= num11;
				base.Projectile.velocity.X = (base.Projectile.velocity.X * 20f + num9) / 21f;
				base.Projectile.velocity.Y = (base.Projectile.velocity.Y * 20f + num10) / 21f;
			}
			base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) + 1.57f;
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 1f / 255f, (float)(255 - base.Projectile.alpha) * 0.05f / 255f, (float)(255 - base.Projectile.alpha) * 0.05f / 255f);
			int p = Dust.NewDust( new Vector2(base.Projectile.Center.X , base.Projectile.Center.Y) + base.Projectile.velocity * 1.5f, 0, 0, 183, 0, 0, 0, default(Color), 2f);
			Main.dust[p].velocity.X = (float)Math.Sin((float)base.Projectile.timeLeft / 30f * Math.PI) * 4f;
			Main.dust[p].velocity.Y = (float)Math.Cos((float)base.Projectile.timeLeft / 30f * Math.PI) * 4f;
			Main.dust[p].noGravity = true;
			int q = Dust.NewDust( new Vector2(base.Projectile.Center.X , base.Projectile.Center.Y) + base.Projectile.velocity * 1.5f, 0, 0, 183, 0, 0, 0, default(Color), 2f);
			Main.dust[q].velocity.X = (float)Math.Sin((float)base.Projectile.timeLeft / 30f * Math.PI + 1.333333333333f * Math.PI) * 4f;
			Main.dust[q].velocity.Y = (float)Math.Cos((float)base.Projectile.timeLeft / 30f * Math.PI + 1.333333333333f * Math.PI) * 4f;
			Main.dust[q].noGravity = true;
			int r = Dust.NewDust( new Vector2(base.Projectile.Center.X , base.Projectile.Center.Y) + base.Projectile.velocity * 1.5f, 0, 0, 183, 0, 0, 0, default(Color), 2f);
			Main.dust[r].velocity.X = (float)Math.Sin((float)base.Projectile.timeLeft / 30f * Math.PI + 0.666666666667f * Math.PI) * 4f;
			Main.dust[r].velocity.Y = (float)Math.Cos((float)base.Projectile.timeLeft / 30f * Math.PI + 0.666666666667f * Math.PI) * 4f;
			Main.dust[r].noGravity = true;
			int k = Dust.NewDust( new Vector2(base.Projectile.Center.X , base.Projectile.Center.Y) + base.Projectile.velocity * 1.5f, 0, 0, 262, 0, 0, 0, default(Color), 0.8f);
			Main.dust[k].noGravity = true;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
		}
		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
			int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
			int y = num * base.Projectile.frame;
			Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
		public override void Kill(int timeLeft)
        {
			float num12 = Main.rand.Next(-10000,10000)/10000f;
            for (int i = 0; i < 3; i++)
            {
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)(Math.Sin(((float)i / 1.5f) * 3.14159265359f + (float)num12) * 3.0), (float)(Math.Cos(((float)i / 1.5f) * 3.14159265359f + (float)num12) * 3.0), base.Mod.Find<ModProjectile>("星烛冰海光2").Type, (int)((double)base.Projectile.damage * 0.1f), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            }
        }
	}
}
