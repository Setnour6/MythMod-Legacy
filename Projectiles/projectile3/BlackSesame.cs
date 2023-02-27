using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class BlackSesame : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("黑芝麻");
        }
		public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 20;
			base.projectile.friendly = true;
			base.projectile.melee = true;
			base.projectile.penetrate = 1;
			base.projectile.aiStyle = -1;
			base.projectile.timeLeft = 300;
            base.projectile.hostile = false;
            projectile.extraUpdates = 5;
		}
		public override void AI()
		{
			base.projectile.localAI[0] += 1f;
			if (base.projectile.localAI[0] > 27f)
			{
				int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 54, 0f, 0f, 100, Color.White, 1.5f);
                if(Main.rand.Next(2) == 1)
                {
                    Main.dust[num].noGravity = true;
                    Main.dust[num].velocity *= 0f;
                }
			}
		}
	}
}
