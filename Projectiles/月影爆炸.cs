using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x02000512 RID: 1298
    public class 月影爆炸 : ModProjectile
	{
		// Token: 0x06001C81 RID: 7297 RVA: 0x0000BBD6 File Offset: 0x00009DD6
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("月影爆炸");
            Main.projFrames[projectile.type] = 1; /*【帧数为6】对应的贴图也要画6帧哦*/
		}

		// Token: 0x06001C82 RID: 7298 RVA: 0x0016F518 File Offset: 0x0016D718
		public override void SetDefaults()
		{
			base.projectile.width = 26;
			base.projectile.height = 30;
			base.projectile.friendly = true;
			base.projectile.alpha = 65;
			base.projectile.penetrate = 5;
			base.projectile.tileCollide = false;
			base.projectile.timeLeft = 3000;
			base.projectile.magic = false;
		}

		// Token: 0x06001C83 RID: 7299 RVA: 0x0016F58C File Offset: 0x0016D78C
		public override void AI()
        {
			float num = base.projectile.Center.X;
			float num2 = base.projectile.Center.Y;
			float num3 = 400f;
			bool flag = false;
			for (int i = 0; i < 200; i++)
			{
				if (Main.npc[i].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[i].Center, 1, 1))
				{
					float num4 = Main.npc[i].position.X + (float)(Main.npc[i].width / 2);
					float num5 = Main.npc[i].position.Y + (float)(Main.npc[i].height / 2);
					float num6 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num4) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num5);
					if (num6 < num3)
					{
						num3 = num6;
						num = num4;
						num2 = num5;
						flag = true;
					}
				}
			}
            int num11 = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("MoonLight"), projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 201, Color.White, 2f);/*粉尘效果不用管*/
			if (flag)
			{
				float num7 = 20f;
				Vector2 vector = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
				float num8 = num - vector.X;
				float num9 = num2 - vector.Y;
				float num10 = (float)Math.Sqrt((double)(num8 * num8 + num9 * num9));
				num10 = num7 / num10;
				num8 *= num10;
				num9 *= num10;
				base.projectile.velocity.X = (base.projectile.velocity.X * 20f + num8) / 21f;
				base.projectile.velocity.Y = (base.projectile.velocity.Y * 20f + num9) / 21f;
				return;
			}
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 0.75f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f);
            int dustID = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("MoonLight"), projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 201, Color.White, 2f);
		}

		// Token: 0x06001C84 RID: 7300 RVA: 0x0016F648 File Offset: 0x0016D848
		public override void Kill(int timeLeft)
		{
		}

		// Token: 0x06001C85 RID: 7301 RVA: 0x0000BBE8 File Offset: 0x00009DE8
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
	}
}
