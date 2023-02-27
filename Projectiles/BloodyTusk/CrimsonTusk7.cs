using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.BloodyTusk
{
    public class CrimsonTusk7 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("CrimsonTusk");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 14;
			base.Projectile.height = 62;
			base.Projectile.friendly = false;
            base.Projectile.hostile = true;
			base.Projectile.alpha = 255;
			base.Projectile.penetrate = -1;
			base.Projectile.tileCollide = false;
			base.Projectile.timeLeft = 600;
            base.Projectile.aiStyle = 1;
            this.AIType = 1;
		}
        public override void AI()
        {
            if(base.Projectile.timeLeft >= 583)
            {
                base.Projectile.alpha -= 15;
            }
            base.Projectile.rotation = (float)System.Math.Atan2((double)Projectile.velocity.Y,(double)Projectile.velocity.X) + 1.57f;
            Vector2 vector = (base.Projectile.position + base.Projectile.Center) / 3;
            int num12 = Dust.NewDust(vector, 0, 0, 5, 0f, 0f, 0, default(Color), 1f);
            Main.dust[num12].noGravity = false;
            base.Projectile.velocity.Y += 0.15f;
        }
	}
}
