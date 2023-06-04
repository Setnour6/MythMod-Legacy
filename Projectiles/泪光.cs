using System;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200067E RID: 1662
    public class 泪光 : ModProjectile
	{
		// Token: 0x06002466 RID: 9318 RVA: 0x0000D1B0 File Offset: 0x0000B3B0
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("泪光");
		}

		// Token: 0x06002467 RID: 9319 RVA: 0x001D6884 File Offset: 0x001D4A84
		public override void SetDefaults()
		{
			base.Projectile.width = 32;
			base.Projectile.height = 32;
			base.Projectile.friendly = false;
            base.Projectile.hostile = true;
			base.Projectile.alpha = 255;
			base.Projectile.penetrate = -1;
			base.Projectile.tileCollide = false;
			base.Projectile.ignoreWater = true;
			base.Projectile.DamageType = DamageClass.Melee;
			base.Projectile.timeLeft = 600;
		}

		// Token: 0x06002468 RID: 9320 RVA: 0x001D6908 File Offset: 0x001D4B08
		public override void AI()
		{
			base.Projectile.rotation += base.Projectile.velocity.X * 0.02f;
			if (base.Projectile.velocity.X < 0f)
			{
				base.Projectile.rotation -= Math.Abs(base.Projectile.velocity.Y) * 0.02f;
			}
			else
			{
				base.Projectile.rotation += Math.Abs(base.Projectile.velocity.Y) * 0.02f;
			}
			base.Projectile.velocity *= 0.98f;
			base.Projectile.ai[0] += 1f;
			if (base.Projectile.ai[0] >= 60f)
			{
				if (base.Projectile.alpha < 255)
				{
					base.Projectile.alpha += 5;
					if (base.Projectile.alpha > 255)
					{
						base.Projectile.alpha = 255;
						return;
					}
				}
				else if (base.Projectile.owner == Main.myPlayer)
				{
					base.Projectile.Kill();
					return;
				}
			}
			else if (base.Projectile.alpha > 80)
			{
				base.Projectile.alpha -= 30;
				if (base.Projectile.alpha < 80)
				{
					base.Projectile.alpha = 80;
				}
			}
		}
	}
}
