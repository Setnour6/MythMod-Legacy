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
            if(Projectile.timeLeft < 3594)
            {
                int r2 = Dust.NewDust(new Vector2(Projectile.Center.X, Projectile.Center.Y) - Projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.25f,0.25f)) * 0.4f - new Vector2(4, 4), 0, 0, 28, 0, 0, 0, default(Color), 2f);
                Main.dust[r2].velocity.X = 0;
                Main.dust[r2].velocity.Y = 0;
                Main.dust[r2].noGravity = true;
            }
            if(Projectile.Center.Y >= player.Center.Y)
            {
                Projectile.tileCollide = true;
            }
            if(Projectile.ai[0] != 2)
            {
                Projectile.velocity.Y += 0.5f;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    Projectile.Kill();
			return false;
		}
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0.5f, 4f)).RotatedByRandom(Math.PI * 2);
                int num5 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 28, 0f, 0f, 100, Color.White, 2f);
                Main.dust[num5].velocity = v;
            }
        }
	}
}
