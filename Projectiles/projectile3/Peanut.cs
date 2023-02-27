using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class Peanut : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("花生");
        }
		public override void SetDefaults()
		{
			base.Projectile.width = 20;
			base.Projectile.height = 20;
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Melee;
			base.Projectile.penetrate = 1;
			base.Projectile.aiStyle = -1;
			base.Projectile.timeLeft = 300;
            base.Projectile.hostile = false;
            Projectile.extraUpdates = 5;
		}
		public override void AI()
		{
			base.Projectile.localAI[0] += 1f;
			if (base.Projectile.localAI[0] > 27f)
			{
				int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 138, 0f, 0f, 100, Color.White, 1.2f);
                if(Main.rand.Next(2) == 1)
                {
                    Main.dust[num].noGravity = true;
                    Main.dust[num].velocity *= 0f;
                }
			}
		}
	}
}
