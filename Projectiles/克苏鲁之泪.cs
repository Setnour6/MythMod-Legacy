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
			base.Projectile.width = 20;
			base.Projectile.height = 20;
			base.Projectile.friendly = false;
			base.Projectile.DamageType = DamageClass.Melee;
			base.Projectile.penetrate = 3;
			base.Projectile.aiStyle = 14;
			base.Projectile.timeLeft = 600;
            base.Projectile.hostile = true;
		}

		// Token: 0x06002461 RID: 9313 RVA: 0x001D65DC File Offset: 0x001D47DC
		public override void AI()
		{
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0.9f / 255f);
			base.Projectile.localAI[0] += 1f;
			if (base.Projectile.localAI[0] > 4f)
			{
				for (int i = 0; i < 10; i++)
				{
					int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 104, 0f, 0f, 100, Color.Blue, 1.5f);
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
			base.Projectile.penetrate--;
			if (base.Projectile.penetrate <= 0)
			{
				base.Projectile.Kill();
			}
			else
			{
				base.Projectile.ai[0] += 0.1f;
				if (base.Projectile.velocity.X != oldVelocity.X)
				{
					base.Projectile.velocity.X = -oldVelocity.X;
				}
				if (base.Projectile.velocity.Y != oldVelocity.Y)
				{
					base.Projectile.velocity.Y = -oldVelocity.Y;
				}
				base.Projectile.velocity *= 0.98f;
			}
			return false;
		}

		// Token: 0x06002463 RID: 9315 RVA: 0x001D67F4 File Offset: 0x001D49F4
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 10; i++)
			{
				Dust.NewDust(base.Projectile.position + base.Projectile.velocity, base.Projectile.width, base.Projectile.height, 104, base.Projectile.oldVelocity.X * 0.5f, base.Projectile.oldVelocity.Y * 0.5f, 0, Color.Blue, 1f);
			}
		}
		public int projTime = 15;
	}
}
