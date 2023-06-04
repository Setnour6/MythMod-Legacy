using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200076F RID: 1903
    public class 西瓜爆炸 : ModProjectile
	{
		// Token: 0x06002989 RID: 10633 RVA: 0x0000C341 File Offset: 0x0000A541
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("西瓜爆炸");
		}

		// Token: 0x0600298A RID: 10634 RVA: 0x002137B8 File Offset: 0x002119B8
		public override void SetDefaults()
		{
			base.Projectile.width = 140;
			base.Projectile.height = 140;
			base.Projectile.friendly = true;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.DamageType = DamageClass.Magic;
			base.Projectile.penetrate = -1;
			base.Projectile.timeLeft = 6;
			base.Projectile.usesLocalNPCImmunity = true;
			base.Projectile.localNPCHitCooldown = 10;
		}

		// Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
		public override void AI()
		{
			float num = (float)Main.rand.Next(240 ,255) * 0.001f;
			num *= Main.essScale;
			Lighting.AddLight(base.Projectile.Center, 1f * num, 0.88f * num, 0.82f * num);
			bool flag = false;
			bool flag2 = false;
			if (base.Projectile.velocity.X < 0f && base.Projectile.position.X < base.Projectile.ai[0])
			{
				flag = true;
			}
			if (base.Projectile.velocity.X > 0f && base.Projectile.position.X > base.Projectile.ai[0])
			{
				flag = true;
			}
			if (base.Projectile.velocity.Y < 0f && base.Projectile.position.Y < base.Projectile.ai[1])
			{
				flag2 = true;
			}
			if (base.Projectile.velocity.Y > 0f && base.Projectile.position.Y > base.Projectile.ai[1])
			{
				flag2 = true;
			}
			if (flag && flag2)
			{
				base.Projectile.Kill();
			}
			float num2 = 25f;
			if (base.Projectile.ai[0] > 180f)
			{
				num2 -= (base.Projectile.ai[0] - 180f) / 2f;
			}
			if (num2 <= 0f)
			{
				num2 = 0f;
				base.Projectile.Kill();
			}
			num2 *= 0.7f;
			base.Projectile.ai[0] += 4f;
			int num3 = 0;
			while ((float)num3 < num2 * 15)
			{
				float num4 = (float)Main.rand.Next(-20, 21);
				float num5 = (float)Main.rand.Next(-20, 21);
				float num6 = (float)Main.rand.Next(4, 8);
				float num7 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
				num7 = num6 / num7;
				num4 *= num7 * 1.4f;
				num5 *= num7 * 1.4f;
                int num8 = Main.rand.Next(5);
                if (num8 == 0)
                {
                    num8 = 115;
                }
                else if (num8 == 1)
                {
                    num8 = 109;
                }
                else if (num8 == 2)
                {
                    num8 = 115;
                }
                else if (num8 == 3)
                {
                    num8 = 183;
                }
                else
                {
                    num8 = 183;
                }
				int num9 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, num8, 0f, 0f, 100, default(Color), 1.8f);
				Main.dust[num9].noGravity = true;
				Main.dust[num9].position.X = base.Projectile.Center.X;
				Main.dust[num9].position.Y = base.Projectile.Center.Y;
				Dust dust = Main.dust[num9];
				dust.position.X = dust.position.X + (float)Main.rand.Next(-10, 11);
				Dust dust2 = Main.dust[num9];
				dust2.position.Y = dust2.position.Y + (float)Main.rand.Next(-10, 11);
				Main.dust[num9].velocity.X = num4;
				Main.dust[num9].velocity.Y = num5;
				num3++;
			}
			for (int i = 0; i < 50; i++)
            {
                int num20 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 61, (float)Math.Cos((2 * (float)i / 45) * 3.14159265358979f) * 2, (float)Math.Sin((2 * (float)i / 45) * 3.14159265358979f) * 7, 150, default(Color), 1.4f);
                Main.dust[num20].noGravity = true;
                Main.dust[num20].velocity.X = (float)Math.Cos((2 * (float)i / 45) * 3.14159265358979f) * 15;
                Main.dust[num20].velocity.Y = (float)Math.Sin((2 * (float)i / 45) * 3.14159265358979f) * 15;
            }
		}
	}
}
