using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class EvilSlingshot : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("妖火弹球");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 20;
			base.projectile.friendly = true;
			base.projectile.melee = true;
			base.projectile.penetrate = 15;
			base.projectile.aiStyle = 1;
			base.projectile.timeLeft = 1200;
            base.projectile.hostile = false;
            projectile.penetrate = 1;

        }
		public override void AI()
		{
            int r = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) + base.projectile.velocity * 1.5f + new Vector2(-9, -4), 0, 0, 27, 0, 0, 0, default(Color), 1f);
            Main.dust[r].velocity.X = 0;
            Main.dust[r].velocity.Y = 0;
            Main.dust[r].noGravity = true;
        }
        public override void Kill(int timeLeft)
        {
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(153, 900);
        }
        public int projTime = 15;
	}
}
