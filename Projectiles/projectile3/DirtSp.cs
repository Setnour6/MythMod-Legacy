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
            // DisplayName.SetDefault("");
		}
		public override void SetDefaults()
		{
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 3600;
            Projectile.tileCollide = true;
        }
        public override void AI()
		{
            Projectile.velocity.Y += 1f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    Projectile.Kill();
			return false;
		}
        public override void Kill(int timeLeft)
        {
            int num4 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y + 30, 0,0, base.Mod.Find<ModProjectile>("DirtSp2").Type, base.Projectile.damage, base.Projectile.knockBack, base.Projectile.owner, 0f, Projectile.ai[1] / 2f);
            Main.projectile[num4].timeLeft = Main.rand.Next(200, 470);
        }
	}
}
