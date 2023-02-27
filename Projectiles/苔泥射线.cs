using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x020007CE RID: 1998
	public class 苔泥射线 : ModProjectile
	{
		// Token: 0x06002B98 RID: 11160 RVA: 0x0000C67F File Offset: 0x0000A87F
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("苔泥射线");
		}

		// Token: 0x06002B99 RID: 11161 RVA: 0x00185908 File Offset: 0x00183B08
		public override void SetDefaults()
		{
			base.projectile.width = 14;
			base.projectile.height = 14;
			base.projectile.friendly = true;
			base.projectile.alpha = 255;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 30;
			base.projectile.magic = true;
		}

		// Token: 0x06002B9A RID: 11162 RVA: 0x002294B4 File Offset: 0x002276B4
		public override void AI()
		{
			Projectile projectile = base.projectile;
			projectile.velocity.X = projectile.velocity.X * 1.01f;
			Projectile projectile2 = base.projectile;
			projectile2.velocity.Y = projectile2.velocity.Y * 1.01f;
			if (base.projectile.ai[0] == 0f)
			{
				base.projectile.ai[0] = base.projectile.velocity.X;
				base.projectile.ai[1] = base.projectile.velocity.Y;
			}
			if (Math.Sqrt((double)(base.projectile.velocity.X * base.projectile.velocity.X + base.projectile.velocity.Y * base.projectile.velocity.Y)) > 2.0)
			{
				base.projectile.velocity *= 0.98f;
			}
			int[] array = new int[20];
			int num = 0;
			float num2 = 300f;
			bool flag = false;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].CanBeChasedBy(base.projectile, false))
				{
					float num3 = Main.npc[i].position.X + (float)(Main.npc[i].width / 2);
					float num4 = Main.npc[i].position.Y + (float)(Main.npc[i].height / 2);
					float num5 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num3) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num4);
					if (num5 < num2 && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[i].Center, 1, 1))
					{
						if (num < 20)
						{
							array[num] = i;
							num++;
						}
						flag = true;
					}
				}
			}
			if (flag)
			{
				int num6 = Main.rand.Next(num);
				num6 = array[num6];
				float num7 = Main.npc[num6].position.X + (float)(Main.npc[num6].width / 2);
				float num8 = Main.npc[num6].position.Y + (float)(Main.npc[num6].height / 2);
				base.projectile.localAI[0] += 1f;
				if (base.projectile.localAI[0] > 24f)
				{
					base.projectile.localAI[0] = 0f;
					float num9 = 6f;
					Vector2 value = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
					value += base.projectile.velocity * 4f;
					float num10 = num7 - value.X;
					float num11 = num8 - value.Y;
					float num12 = (float)Math.Sqrt((double)(num10 * num10 + num11 * num11));
					num12 = num9 / num12;
					num10 *= num12;
					num11 *= num12;
					if (base.projectile.owner == Main.myPlayer)
					{
						Projectile.NewProjectile(value.X, value.Y, num10, num11, base.mod.ProjectileType("苔泥射线"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
					}
				}
			}
		}
	}
}
