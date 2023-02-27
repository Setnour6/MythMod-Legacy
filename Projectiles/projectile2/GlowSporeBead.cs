using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
    public class GlowSporeBead : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("夜光孢子珠");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 20;
			base.projectile.friendly = true;
			base.projectile.melee = true;
			base.projectile.aiStyle = 1;
            base.projectile.penetrate = 1;
            base.projectile.timeLeft = 3600;
            base.projectile.hostile = false;
		}
		public override void AI()
		{
            int r = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) + base.projectile.velocity * 1.5f + new Vector2(-9, -4), 0, 0, 44, 0, 0, 0, default(Color), 0.6f);
            Main.dust[r].velocity.X = 0;
            Main.dust[r].velocity.Y = 0;
            Main.dust[r].noGravity = true;
        }
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    base.projectile.Kill();
			return false;
		}
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 27, 0.4f, 0f);
            for (int i = 0; i < 30; i++)
            {
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 44, 0f, 0f, 100, default(Color), 0.8f);
                Main.dust[num].velocity *= 1.1f;
                Main.dust[num].noGravity = true;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num].scale = 0.5f;
                    
                    Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                }
            }
        }
        public int projTime = 15;
	}
}
