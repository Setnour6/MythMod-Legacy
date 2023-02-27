using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
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
			base.Projectile.width = 10;
			base.Projectile.height = 20;
			base.Projectile.hostile = true;
			base.Projectile.alpha = 250;
			base.Projectile.aiStyle = 1;
			base.Projectile.penetrate = -1;
		}

		// Token: 0x060020B5 RID: 8373 RVA: 0x001A5C18 File Offset: 0x001A3E18
		public override void AI()
		{
			Projectile.rotation = (float)System.Math.Atan2((double)Projectile.velocity.Y,(double)Projectile.velocity.X) + 1.57f;
            if (Projectile.timeLeft % 3 == 0)
            {
                int dustID = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 19, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 201, Color.Orange, 1.2f);/*粉尘效果不用管*/
                int dustID2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 6, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 201, Color.Black, 1.8f);/*粉尘效果不用管*/
                Main.dust[dustID].noGravity = true;
            }
			base.Projectile.alpha -= 50;
			if (base.Projectile.alpha < 0)
			{
				base.Projectile.alpha = 0;
			}
			if (base.Projectile.ai[1] == 0f)
			{
				base.Projectile.ai[1] = 1f;
				SoundEngine.PlaySound(SoundID.Item17, new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
			}
			base.Projectile.ai[0] += 1f;
			if (base.Projectile.ai[0] >= 5f)
			{
				base.Projectile.ai[0] = 5f;
				base.Projectile.velocity.Y = base.Projectile.velocity.Y + 0.15f;
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
				Dust.NewDust(base.Projectile.position + base.Projectile.velocity, base.Projectile.width, base.Projectile.height, 260, base.Projectile.oldVelocity.X * 0.5f, base.Projectile.oldVelocity.Y * 0.5f, 0, default(Color), 1f);
			}
		}
	}
}
