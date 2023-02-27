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
            base.DisplayName.SetDefault("高速弹球");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 20;
			base.projectile.friendly = true;
			base.projectile.melee = true;
			base.projectile.penetrate = 300;
			base.projectile.aiStyle = 1;
			base.projectile.timeLeft = 600;
            base.projectile.hostile = false;
		}
		public override void AI()
		{
			base.projectile.localAI[0] += 1f;
            int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 33, 0f, 0f, 100, Color.White, 2f);
            Main.dust[num].noGravity = true;
            Main.dust[num].velocity *= 0f;
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
            for(int i = 0; i < 65;i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0.5f, 4f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 33, 0f, 0f, 100, Color.White, 2f);
            }
        }
        public int projTime = 15;
	}
}
