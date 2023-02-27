using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class StarPoisonArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("星渊毒素箭");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 26;
			base.projectile.height = 30;
			base.projectile.friendly = true;
			base.projectile.alpha = 65;
			base.projectile.penetrate = 1;
			base.projectile.tileCollide = true;
			base.projectile.timeLeft = 300;
            base.projectile.ranged = true;
            base.projectile.aiStyle = 1;
            this.aiType = 1;
		}
        float timer = 0;
        static float j = 0;
        static float m = 0;
        static float n = 0;
        Vector2 pc2 = Vector2.Zero;
        public override void AI()
        {
            if (projectile.timeLeft <= 597)
            {
                int num5 = Dust.NewDust(base.projectile.Center - new Vector2(8, 8), 0, 0, 235, 0, 0, 0, default(Color), 1f);
                Main.dust[num5].noGravity = true;
                Main.dust[num5].velocity = new Vector2(0, 0);
                if (Main.rand.Next(8) == 1)
                {
                    int num3 = Dust.NewDust(base.projectile.Center - new Vector2(8, 8), 0, 0, 87, 0, 0, 0, default(Color), 1f);
                    Main.dust[num3].noGravity = true;
                    Main.dust[num3].velocity = new Vector2(0, 0);
                }
            }
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            target.AddBuff(mod.BuffType("XYPoison"), 360, false);
		}
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 25; i++)
            {
                int num3 = Dust.NewDust(base.projectile.Center - new Vector2(8, 8), 0, 0, 235, 0, 0, 0, default(Color), 1f);
                if (Main.rand.Next(8) == 1)
                {
                    int num4 = Dust.NewDust(base.projectile.Center - new Vector2(8, 8), 0, 0, 87, 0, 0, 0, default(Color), 1f);
                }
            }
            projectile.width = 100;
            projectile.height = 100;
            projectile.position = projectile.position - new Vector2(36, 36);
        }
    }
}
