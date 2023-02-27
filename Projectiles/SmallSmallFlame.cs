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
			base.Projectile.width = 6;
			base.Projectile.height = 6;
			base.Projectile.hostile = true;
			base.Projectile.alpha = 255;
			base.Projectile.aiStyle = 1;
			base.Projectile.penetrate = -1;
		}

		// Token: 0x060020B5 RID: 8373 RVA: 0x001A5C18 File Offset: 0x001A3E18
		public override void AI()
		{
            int dustID = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6, Projectile.velocity.X * 0.01f, Projectile.velocity.Y * 0.01f, 201, default(Color), 1.2f);/*粉尘效果不用管*/
            int dustID2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 87, Projectile.velocity.X * 0.01f, Projectile.velocity.Y * 0.01f, 201, default(Color), 1f);/*粉尘效果不用管*/
            int dustID3 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6, Projectile.velocity.X * 0.01f, Projectile.velocity.Y * 0.01f, 201, default(Color), 1.2f);/*粉尘效果不用管*/
			base.Projectile.velocity.Y = base.Projectile.velocity.Y + 0.05f;
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
				Dust.NewDust(base.Projectile.position + base.Projectile.velocity, base.Projectile.width, base.Projectile.height, 6, base.Projectile.oldVelocity.X * 0.5f, base.Projectile.oldVelocity.Y * 0.5f, 0, default(Color), 1f);
			}
		}
	}
}
