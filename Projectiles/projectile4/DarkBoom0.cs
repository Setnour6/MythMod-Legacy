using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles.projectile4
{
    public class DarkBoom0 : ModProjectile
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
            projectile.extraUpdates = 12;
            projectile.tileCollide = true;
        }
        private float Y = 0;
        private float X = 0;
        private float ω = 0;
        private bool Orbit = false;
        public override void AI()
		{
        }
        public override void Kill(int timeLeft)
        {
            if (!(timeLeft >= 896))
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("EvilBoom"), 90, 0f, Main.myPlayer, 0f, 0f);
            }
        }
    }
}
