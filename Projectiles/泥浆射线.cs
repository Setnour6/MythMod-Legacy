using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
    public class 泥浆射线 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("泥浆射线");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 4;
			base.projectile.height = 4;
			base.projectile.friendly = true;
			base.projectile.magic = true;
			base.projectile.penetrate = 10;
			base.projectile.extraUpdates = 100;
			base.projectile.timeLeft = 400;
		}
		public override void AI()
		{
            if (base.projectile.timeLeft < 398)
            {
                base.projectile.localAI[0] += 1f;
                if (base.projectile.localAI[0] > 12f)
                {
                    Vector2 vector = base.projectile.position;
                    vector -= base.projectile.velocity;
                    base.projectile.alpha = 255;
                    int num = Dust.NewDust(vector, 4, 4, mod.DustType("Mud"), 0f, 0f, 0, default(Color), 1.5f);
                    Main.dust[num].position = vector;
                    Main.dust[num].scale *= 0.8f;
                    Main.dust[num].velocity *= 0.97f;
                    int num1 = Dust.NewDust(vector, 1, 1, 2, 0f, 0f, 0, default(Color), 1.5f);
                    Main.dust[num1].position = vector;
                    Main.dust[num1].velocity *= 0f;
                    Main.dust[num1].scale *= 0.95f;
                    Main.dust[num1].noGravity = true;
                }
            }
		}
	}
}
