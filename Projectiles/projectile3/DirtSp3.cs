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
            // DisplayName.SetDefault("土喷泉");
		}
		public override void SetDefaults()
		{
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 3600;
            Projectile.tileCollide = false;
        }
        public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 1.57f;
            if(Projectile.timeLeft < 3598)
            {
                int r2 = Dust.NewDust(new Vector2(Projectile.Center.X, Projectile.Center.Y) - Projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.25f,0.25f)) * 0.4f - new Vector2(8, 8), 8, 8, 28, 0, 0, 0, default(Color), 2f);
                Main.dust[r2].velocity.X = 0;
                Main.dust[r2].velocity.Y = 0;
            }
            if (Projectile.timeLeft < 3590)
            {
                Projectile.tileCollide = true;
                if(Projectile.velocity.Y >= 0)
                {
                    Projectile.Kill();
                }
            }
            Projectile.velocity.Y += 0.15f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    Projectile.Kill();
			return false;
		}
        public override void Kill(int timeLeft)
        {
        }
	}
}
