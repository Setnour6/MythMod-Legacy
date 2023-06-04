using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class FireSmoke : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("烟火");
        }
		public override void SetDefaults()
		{
			base.Projectile.width = 20;
			base.Projectile.height = 20;
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Melee;
			base.Projectile.penetrate = 1;
			base.Projectile.aiStyle = -1;
			base.Projectile.timeLeft = 60;
            base.Projectile.hostile = true;
		}
        private int T = 0;
        private float H = 0;
        public override void AI()
        {
            if (Projectile.ai[1] != 1)
            {
                if (T == 0)
                {
                    T = 2;
                    H = Projectile.Center.Y;
                }
                int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 188, 0f, 0f, 100, Color.White, (H - Projectile.Center.Y) / 50f + 0.75f);
                Main.dust[num].velocity *= ((H - Projectile.Center.Y) / 50f + 0.75f) * 0.05f;
            }
            else
            {
                int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 188, 0f, 0f, 100, Color.White, (30 - Projectile.timeLeft) / 6f);
            }
            if(Projectile.ai[1] != 1)
            {
                Projectile.velocity.Y += 0.5f;
                if (Projectile.velocity.Y >= 0)
                {
                    Projectile.active = false;
                }
            }
           // Lighting.AddLight((int)projectile.Center.X, (int)projectile.Center.Y, ((H - projectile.Center.Y) / 50f + 0.75f) * 100f, ((H - projectile.Center.Y) / 50f + 0.75f) * 10f, 0);
        }
	}
}
