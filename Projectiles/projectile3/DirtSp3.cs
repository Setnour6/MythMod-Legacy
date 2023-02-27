using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class DirtSp3 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("土喷泉");
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
            if(projectile.timeLeft < 3598)
            {
                int r2 = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y) - projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.25f,0.25f)) * 0.4f - new Vector2(8, 8), 8, 8, 28, 0, 0, 0, default(Color), 2f);
                Main.dust[r2].velocity.X = 0;
                Main.dust[r2].velocity.Y = 0;
            }
            if (projectile.timeLeft < 3590)
            {
                projectile.tileCollide = true;
                if(projectile.velocity.Y >= 0)
                {
                    projectile.Kill();
                }
            }
            projectile.velocity.Y += 0.15f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    projectile.Kill();
			return false;
		}
        public override void Kill(int timeLeft)
        {
        }
	}
}
