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
            base.DisplayName.SetDefault("烟火");
        }
		public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 20;
			base.projectile.friendly = true;
			base.projectile.melee = true;
			base.projectile.penetrate = 1;
			base.projectile.aiStyle = -1;
			base.projectile.timeLeft = 60;
            base.projectile.hostile = true;
		}
        private int T = 0;
        private float H = 0;
        public override void AI()
        {
            if (projectile.ai[1] != 1)
            {
                if (T == 0)
                {
                    T = 2;
                    H = projectile.Center.Y;
                }
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 188, 0f, 0f, 100, Color.White, (H - projectile.Center.Y) / 50f + 0.75f);
                Main.dust[num].velocity *= ((H - projectile.Center.Y) / 50f + 0.75f) * 0.05f;
            }
            else
            {
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 188, 0f, 0f, 100, Color.White, (30 - projectile.timeLeft) / 6f);
            }
            if(projectile.ai[1] != 1)
            {
                projectile.velocity.Y += 0.5f;
                if (projectile.velocity.Y >= 0)
                {
                    projectile.active = false;
                }
            }
           // Lighting.AddLight((int)projectile.Center.X, (int)projectile.Center.Y, ((H - projectile.Center.Y) / 50f + 0.75f) * 100f, ((H - projectile.Center.Y) / 50f + 0.75f) * 10f, 0);
        }
	}
}
