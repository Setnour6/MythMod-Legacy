using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
    public class FireworkStop : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("焰火");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 0;
			base.projectile.height = 0;
			base.projectile.friendly = true;
			base.projectile.magic = true;
			base.projectile.penetrate = -1;
			base.projectile.extraUpdates = 5;
			base.projectile.timeLeft = 1440;
		}
		public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            projectile.velocity.Y += 0.002f;
            Main.player[Main.myPlayer].GetModPlayer<MythPlayer>().FlyCamPosition = projectile.Center - player.Center;
        }
	}
}
