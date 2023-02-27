using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
    public class WINDRelief : ModProjectile
	{
		public override void SetDefaults()
		{
			base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.alpha = 255;
			base.projectile.scale = 1f;
			base.projectile.friendly = false;
			base.projectile.magic = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 3600;
            base.projectile.ignoreWater = false;
            base.projectile.tileCollide = true;
        }
		public override void AI()
		{
            projectile.velocity.Y += 1f;
            if(projectile.wet)
            {
                projectile.timeLeft = 0;
            }
		}
		public override void Kill(int timeLeft)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, 386, 100, 0.5f, Main.myPlayer, 10f, 25f);
            if(mplayer.Cloud == 0)
            {
                mplayer.Cloud = projectile.Center.Y;
            }
        }
	}
}
