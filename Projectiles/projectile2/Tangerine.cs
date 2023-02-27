using System;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles.projectile2
{
    public class Tangerine : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("桔子");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 12;
            base.projectile.tileCollide = true;
            base.projectile.height = 12;
			base.projectile.friendly = false;
            base.projectile.hostile = true;
            base.projectile.penetrate = 1;
			base.projectile.timeLeft = 600;
			base.projectile.melee = true;
            base.projectile.aiStyle = -1;
			base.projectile.scale = 1f;
		}
		public override void AI()
		{
            projectile.velocity.Y += 0.15f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
        public override void Kill(int timeLeft)
        {
            for(int i = 0; i < 25; i++)
            {
                int num3 = Dust.NewDust(base.projectile.Center - new Vector2(4, 4), 0, 0, 174, 0, 0, 0, default(Color), 2f);
            }
        }
	}
}
