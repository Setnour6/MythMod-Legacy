using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x020005D7 RID: 1495
    public class 烈火球 : ModProjectile
	{
		// Token: 0x060020B3 RID: 8371 RVA: 0x0000C20B File Offset: 0x0000A40B
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("烈焰毒刺");
		}

		// Token: 0x060020B4 RID: 8372 RVA: 0x001A5BBC File Offset: 0x001A3DBC
		public override void SetDefaults()
		{
			base.projectile.width = 10;
			base.projectile.height = 20;
			base.projectile.hostile = true;
			base.projectile.alpha = 250;
			base.projectile.aiStyle = 1;
			base.projectile.penetrate = -1;
		}

		// Token: 0x060020B5 RID: 8373 RVA: 0x001A5C18 File Offset: 0x001A3E18
		public override void AI()
		{
			projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y,(double)projectile.velocity.X) + 1.57f;
            if (projectile.timeLeft % 3 == 0)
            {
                int dustID = Dust.NewDust(projectile.position, projectile.width, projectile.height, 19, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 201, Color.Orange, 1.2f);/*粉尘效果不用管*/
                int dustID2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 201, Color.Black, 1.8f);/*粉尘效果不用管*/
                Main.dust[dustID].noGravity = true;
            }
			base.projectile.alpha -= 50;
			if (base.projectile.alpha < 0)
			{
				base.projectile.alpha = 0;
			}
			if (base.projectile.ai[1] == 0f)
			{
				base.projectile.ai[1] = 1f;
				Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 17, 1f, 0f);
			}
			base.projectile.ai[0] += 1f;
			if (base.projectile.ai[0] >= 5f)
			{
				base.projectile.ai[0] = 5f;
				base.projectile.velocity.Y = base.projectile.velocity.Y + 0.15f;
			}
		}

		// Token: 0x060020B6 RID: 8374 RVA: 0x0000D160 File Offset: 0x0000B360
		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(24, 360, true);
		}

		// Token: 0x060020B7 RID: 8375 RVA: 0x001A5E00 File Offset: 0x001A4000
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 260, base.projectile.oldVelocity.X * 0.5f, base.projectile.oldVelocity.Y * 0.5f, 0, default(Color), 1f);
			}
		}
	}
}
