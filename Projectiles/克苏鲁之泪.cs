using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200067D RID: 1661
    public class 克苏鲁之泪 : ModProjectile
	{
		// Token: 0x0600245F RID: 9311 RVA: 0x0000C7BC File Offset: 0x0000A9BC
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("克苏鲁之泪");
		}

		// Token: 0x06002460 RID: 9312 RVA: 0x001D6574 File Offset: 0x001D4774
		public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 20;
			base.projectile.friendly = false;
			base.projectile.melee = true;
			base.projectile.penetrate = 3;
			base.projectile.aiStyle = 14;
			base.projectile.timeLeft = 600;
            base.projectile.hostile = true;
		}

		// Token: 0x06002461 RID: 9313 RVA: 0x001D65DC File Offset: 0x001D47DC
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 0.9f / 255f);
			base.projectile.localAI[0] += 1f;
			if (base.projectile.localAI[0] > 4f)
			{
				for (int i = 0; i < 10; i++)
				{
					int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 104, 0f, 0f, 100, Color.Blue, 1.5f);
					Main.dust[num].noGravity = true;
					Main.dust[num].velocity *= 0f;
				}
			}
			this.projTime--;
			if (this.projTime == 0)
			{
				this.projTime = 15;
			}
		}

		// Token: 0x06002462 RID: 9314 RVA: 0x0018A49C File Offset: 0x0018869C
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			base.projectile.penetrate--;
			if (base.projectile.penetrate <= 0)
			{
				base.projectile.Kill();
			}
			else
			{
				base.projectile.ai[0] += 0.1f;
				if (base.projectile.velocity.X != oldVelocity.X)
				{
					base.projectile.velocity.X = -oldVelocity.X;
				}
				if (base.projectile.velocity.Y != oldVelocity.Y)
				{
					base.projectile.velocity.Y = -oldVelocity.Y;
				}
				base.projectile.velocity *= 0.98f;
			}
			return false;
		}

		// Token: 0x06002463 RID: 9315 RVA: 0x001D67F4 File Offset: 0x001D49F4
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 10; i++)
			{
				Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 104, base.projectile.oldVelocity.X * 0.5f, base.projectile.oldVelocity.Y * 0.5f, 0, Color.Blue, 1f);
			}
		}
		public int projTime = 15;
	}
}
