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
			base.Projectile.width = 12;
            base.Projectile.tileCollide = true;
            base.Projectile.height = 12;
			base.Projectile.friendly = false;
            base.Projectile.hostile = true;
            base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 600;
			base.Projectile.DamageType = DamageClass.Melee;
            base.Projectile.aiStyle = -1;
			base.Projectile.scale = 1f;
		}
		public override void AI()
		{
            Projectile.velocity.Y += 0.15f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
        public override void Kill(int timeLeft)
        {
            for(int i = 0; i < 25; i++)
            {
                int num3 = Dust.NewDust(base.Projectile.Center - new Vector2(4, 4), 0, 0, 174, 0, 0, 0, default(Color), 2f);
            }
        }
	}
}
