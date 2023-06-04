using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class HighSpeedBall : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("高速弹球");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 20;
			base.Projectile.height = 20;
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Melee;
			base.Projectile.penetrate = 300;
			base.Projectile.aiStyle = 1;
			base.Projectile.timeLeft = 600;
            base.Projectile.hostile = false;
		}
		public override void AI()
		{
			base.Projectile.localAI[0] += 1f;
            int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 33, 0f, 0f, 100, Color.White, 2f);
            Main.dust[num].noGravity = true;
            Main.dust[num].velocity *= 0f;
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
            for(int i = 0; i < 65;i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0.5f, 4f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 33, 0f, 0f, 100, Color.White, 2f);
            }
        }
        public int projTime = 15;
	}
}
