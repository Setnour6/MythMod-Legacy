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
			base.projectile.width = 14;
			base.projectile.height = 62;
			base.projectile.friendly = false;
            base.projectile.hostile = true;
			base.projectile.alpha = 255;
			base.projectile.penetrate = -1;
			base.projectile.tileCollide = false;
			base.projectile.timeLeft = 600;
            base.projectile.aiStyle = 1;
            this.aiType = 1;
		}
        public override void AI()
        {
            if(base.projectile.timeLeft >= 583)
            {
                base.projectile.alpha -= 15;
            }
            base.projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y,(double)projectile.velocity.X) + 1.57f;
            Vector2 vector = (base.projectile.position + base.projectile.Center) / 3;
            int num12 = Dust.NewDust(vector, 0, 0, 5, 0f, 0f, 0, default(Color), 1f);
            Main.dust[num12].noGravity = false;
            base.projectile.velocity.Y += 0.15f;
        }
	}
}
