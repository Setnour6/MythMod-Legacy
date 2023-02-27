using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class DirtBall : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("土球");
		}
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.friendly = false;
            projectile.hostile = true;
            projectile.aiStyle = -1;
            projectile.penetrate = -1;
            projectile.timeLeft = 3600;
            projectile.tileCollide = false;
        }
        public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;
            if(projectile.timeLeft < 3594)
            {
                int r2 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y) - projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.25f,0.25f)) * 0.4f - new Vector2(4, 4), 0, 0, 28, 0, 0, 0, default(Color), 2f);
                Main.dust[r2].velocity.X = 0;
                Main.dust[r2].velocity.Y = 0;
                Main.dust[r2].noGravity = true;
            }
            if(projectile.Center.Y >= player.Center.Y)
            {
                projectile.tileCollide = true;
            }
            if(projectile.ai[0] != 2)
            {
                projectile.velocity.Y += 0.5f;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    projectile.Kill();
			return false;
		}
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0.5f, 4f)).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 28, 0f, 0f, 100, Color.White, 2f);
                Main.dust[num5].velocity = v;
            }
        }
	}
}
