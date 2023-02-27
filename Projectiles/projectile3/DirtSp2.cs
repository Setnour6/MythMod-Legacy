using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class DirtSp2 : ModProjectile
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
            projectile.timeLeft = 600;
            projectile.tileCollide = false;
        }
        public override void AI()
		{
            projectile.velocity *= 0;
            int i = Dust.NewDust(projectile.Center - new Vector2(16,3), 32, 6, 28, 0f, 0f, 0, default(Color), 1f);
            Main.dust[i].noGravity = true;
            int i2 = Dust.NewDust(projectile.Center - new Vector2(16, 3), 32, 6, 28, 0f, 0f, 0, default(Color), 1f);
            Main.dust[i2].noGravity = true;
            int i3 = Dust.NewDust(projectile.Center - new Vector2(16, 3), 32, 6, 28, 0f, 0f, 0, default(Color), 1f);
            Main.dust[i3].noGravity = true;
            if(projectile.timeLeft < 240 && projectile.timeLeft % 12 == 0)
            {
                int num4 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, Main.rand.NextFloat(-0.2f,0.2f), -11f, base.mod.ProjectileType("DirtSp3"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0);
            }
        }
	}
}
