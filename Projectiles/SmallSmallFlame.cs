using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x020005D7 RID: 1495
    public class SmallSmallFlame : ModProjectile
	{
		// Token: 0x060020B3 RID: 8371 RVA: 0x0000C20B File Offset: 0x0000A40B
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("小火球");
		}

		// Token: 0x060020B4 RID: 8372 RVA: 0x001A5BBC File Offset: 0x001A3DBC
		public override void SetDefaults()
		{
			base.projectile.width = 6;
			base.projectile.height = 6;
			base.projectile.hostile = true;
			base.projectile.alpha = 255;
			base.projectile.aiStyle = 1;
			base.projectile.penetrate = -1;
		}

		// Token: 0x060020B5 RID: 8373 RVA: 0x001A5C18 File Offset: 0x001A3E18
		public override void AI()
		{
            int dustID = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.01f, projectile.velocity.Y * 0.01f, 201, default(Color), 1.2f);/*粉尘效果不用管*/
            int dustID2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 87, projectile.velocity.X * 0.01f, projectile.velocity.Y * 0.01f, 201, default(Color), 1f);/*粉尘效果不用管*/
            int dustID3 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, projectile.velocity.X * 0.01f, projectile.velocity.Y * 0.01f, 201, default(Color), 1.2f);/*粉尘效果不用管*/
			base.projectile.velocity.Y = base.projectile.velocity.Y + 0.05f;
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
				Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 6, base.projectile.oldVelocity.X * 0.5f, base.projectile.oldVelocity.Y * 0.5f, 0, default(Color), 1f);
			}
		}
	}
}
