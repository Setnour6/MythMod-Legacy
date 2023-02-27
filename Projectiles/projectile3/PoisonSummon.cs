using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles.projectile3
{
    public class PoisonSummon : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("毒气弹");
			Main.projFrames[base.projectile.type] = 1;
		}
        public override void SetDefaults()
		{
			base.projectile.width = 34;
			base.projectile.height = 34;
			base.projectile.hostile = false;
            base.projectile.friendly = false;
            base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 600;
			base.projectile.alpha = 0;
			this.cooldownSlot = 1;
            ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 50;
            ProjectileID.Sets.TrailingMode[base.projectile.type] = 0;
        }
		public override void Kill(int timeLeft)
		{
            for(int g = 0; g < 30;g++)
            {
                Vector2 v = new Vector2(0, 30).RotatedBy(Math.PI / 15f * g);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, v.X, v.Y, mod.ProjectileType("PoisonGasF"), (int)(projectile.ai[0]), 0f, Main.myPlayer, 0f, 0f);
            }
            if(projectile.ai[1] > 10)
            {
                Projectile.NewProjectile(projectile.Center.X - 15, projectile.Center.Y - 25, 0, 9, mod.ProjectileType("PoisonGasF"), (int)(projectile.ai[0]), 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(projectile.Center.X + 15, projectile.Center.Y - 25, 0, 9, mod.ProjectileType("PoisonGasF"), (int)(projectile.ai[0]), 0f, Main.myPlayer, 0f, 0f);
            }
            if (projectile.ai[1] > 20)
            {
                Projectile.NewProjectile(projectile.Center.X - 30, projectile.Center.Y - 25, 0, 9, mod.ProjectileType("PoisonGasF"), (int)(projectile.ai[0]), 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(projectile.Center.X + 30, projectile.Center.Y - 25, 0, 9, mod.ProjectileType("PoisonGasF"), (int)(projectile.ai[0]), 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(projectile.Center.X - 45, projectile.Center.Y - 25, 0, 9, mod.ProjectileType("PoisonGasF"), (int)(projectile.ai[0]), 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(projectile.Center.X + 45, projectile.Center.Y - 25, 0, 9, mod.ProjectileType("PoisonGasF"), (int)(projectile.ai[0]), 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(projectile.Center.X - 60, projectile.Center.Y - 25, 0, 9, mod.ProjectileType("PoisonGasF"), (int)(projectile.ai[0]), 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(projectile.Center.X + 60, projectile.Center.Y - 25, 0, 9, mod.ProjectileType("PoisonGasF"), (int)(projectile.ai[0]), 0f, Main.myPlayer, 0f, 0f);
            }
        }
	}
}
