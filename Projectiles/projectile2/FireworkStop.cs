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
            // base.DisplayName.SetDefault("焰火");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 0;
			base.Projectile.height = 0;
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Magic;
			base.Projectile.penetrate = -1;
			base.Projectile.extraUpdates = 5;
			base.Projectile.timeLeft = 1440;
		}
		public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            Projectile.velocity.Y += 0.002f;
            Main.player[Main.myPlayer].GetModPlayer<MythPlayer>().FlyCamPosition = Projectile.Center - player.Center;
        }
	}
}
