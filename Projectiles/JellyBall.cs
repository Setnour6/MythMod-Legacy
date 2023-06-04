using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
    public class JellyBall : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("凝胶弹球");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 20;
			base.Projectile.height = 20;
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Melee;
			base.Projectile.penetrate = 15;
			base.Projectile.aiStyle = 1;
			base.Projectile.timeLeft = 1200;
            base.Projectile.hostile = false;
		}
		public override void AI()
		{
			base.Projectile.localAI[0] += 1f;
			if (base.Projectile.localAI[0] > 4f)
			{
			}
			this.projTime--;
			if (this.projTime == 0)
			{
				this.projTime = 15;
			}
		}
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
        public override void Kill(int timeLeft)
        {
        }
        public int projTime = 15;
	}
}
