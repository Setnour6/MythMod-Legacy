using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class DirtSp : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("");
		}
		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.friendly = false;
            projectile.hostile = false;
            projectile.aiStyle = -1;
            projectile.penetrate = -1;
            projectile.timeLeft = 3600;
            projectile.tileCollide = true;
        }
        public override void AI()
		{
            projectile.velocity.Y += 1f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    projectile.Kill();
			return false;
		}
        public override void Kill(int timeLeft)
        {
            int num4 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y + 30, 0,0, base.mod.ProjectileType("DirtSp2"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, projectile.ai[1] / 2f);
            Main.projectile[num4].timeLeft = Main.rand.Next(200, 470);
        }
	}
}
