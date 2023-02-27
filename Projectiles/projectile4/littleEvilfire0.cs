using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles.projectile4
{
    public class littleEvilfire0 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("影炸弹");
		}
		public override void SetDefaults()
		{
			projectile.width = 12;
			projectile.height = 12;
            projectile.hostile = false;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.alpha = 0;
			projectile.penetrate = 11;
			projectile.timeLeft = 900;
            projectile.extraUpdates = 96;
            projectile.tileCollide = true;
        }
        private float Y = 0;
        private float X = 0;
        private float ω = 0;
        private bool Orbit = false;
        public override void AI()
		{
            projectile.velocity.Y += 0.1f;
        }
        public override void Kill(int timeLeft)
        {
            if (!(timeLeft >= 896))
            {
                if (!(timeLeft <= 10))
                {
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("PurpleFlame"), 20, 0f, Main.myPlayer, projectile.timeLeft / 200f * Main.rand.NextFloat(0.60f, 1.50f), 0f);
                }
            }
        }
    }
}
