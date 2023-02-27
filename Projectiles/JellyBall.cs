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
            base.DisplayName.SetDefault("凝胶弹球");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 20;
			base.projectile.friendly = true;
			base.projectile.melee = true;
			base.projectile.penetrate = 15;
			base.projectile.aiStyle = 1;
			base.projectile.timeLeft = 1200;
            base.projectile.hostile = false;
		}
		public override void AI()
		{
			base.projectile.localAI[0] += 1f;
			if (base.projectile.localAI[0] > 4f)
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
        public override void Kill(int timeLeft)
        {
        }
        public int projTime = 15;
	}
}
