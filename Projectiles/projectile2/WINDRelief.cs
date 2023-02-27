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
			base.Projectile.width = 16;
			base.Projectile.height = 16;
			base.Projectile.alpha = 255;
			base.Projectile.scale = 1f;
			base.Projectile.friendly = false;
			base.Projectile.DamageType = DamageClass.Magic;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 3600;
            base.Projectile.ignoreWater = false;
            base.Projectile.tileCollide = true;
        }
		public override void AI()
		{
            Projectile.velocity.Y += 1f;
            if(Projectile.wet)
            {
                Projectile.timeLeft = 0;
            }
		}
		public override void Kill(int timeLeft)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, 0, 0, 386, 100, 0.5f, Main.myPlayer, 10f, 25f);
            if(mplayer.Cloud == 0)
            {
                mplayer.Cloud = Projectile.Center.Y;
            }
        }
	}
}
