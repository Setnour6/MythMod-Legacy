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
            base.DisplayName.SetDefault("泪光");
		}

		// Token: 0x06002467 RID: 9319 RVA: 0x001D6884 File Offset: 0x001D4A84
		public override void SetDefaults()
		{
			base.projectile.width = 32;
			base.projectile.height = 32;
			base.projectile.friendly = false;
            base.projectile.hostile = true;
			base.projectile.alpha = 255;
			base.projectile.penetrate = -1;
			base.projectile.tileCollide = false;
			base.projectile.ignoreWater = true;
			base.projectile.melee = true;
			base.projectile.timeLeft = 600;
		}

		// Token: 0x06002468 RID: 9320 RVA: 0x001D6908 File Offset: 0x001D4B08
		public override void AI()
		{
			base.projectile.rotation += base.projectile.velocity.X * 0.02f;
			if (base.projectile.velocity.X < 0f)
			{
				base.projectile.rotation -= Math.Abs(base.projectile.velocity.Y) * 0.02f;
			}
			else
			{
				base.projectile.rotation += Math.Abs(base.projectile.velocity.Y) * 0.02f;
			}
			base.projectile.velocity *= 0.98f;
			base.projectile.ai[0] += 1f;
			if (base.projectile.ai[0] >= 60f)
			{
				if (base.projectile.alpha < 255)
				{
					base.projectile.alpha += 5;
					if (base.projectile.alpha > 255)
					{
						base.projectile.alpha = 255;
						return;
					}
				}
				else if (base.projectile.owner == Main.myPlayer)
				{
					base.projectile.Kill();
					return;
				}
			}
			else if (base.projectile.alpha > 80)
			{
				base.projectile.alpha -= 30;
				if (base.projectile.alpha < 80)
				{
					base.projectile.alpha = 80;
				}
			}
		}
	}
}
