using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class FireSmoke2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("烟火2");
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
        public override void AI()
		{
            if(T == 0)
            {
                T = Main.rand.Next(20, 150);
                projectile.timeLeft = T;
            }
            if(projectile.timeLeft %3 == 0)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, -12 * Main.rand.NextFloat(0.8f,1.2f), mod.ProjectileType("FireSmoke"), 100, 2f, Main.myPlayer, 0f, 0f);
            }
		}
	}
}
