using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class WatermelonswKnife : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("西瓜喜糖投刃");
		}
        private float num = 0;
        public override void SetDefaults()
		{
			base.projectile.width = 38;
			base.projectile.height = 38;
			base.projectile.friendly = true;
			base.projectile.alpha = 0;
			base.projectile.penetrate = -1;
			base.projectile.tileCollide = true;
			base.projectile.timeLeft = 300;
            base.projectile.thrown = true;
            base.projectile.aiStyle = -1;
		}
        float timer = 0;
        static float j = 0;
        static float m = 0.15f;
        static float n = 0;
        private bool x = false;
        Vector2 pc2 = Vector2.Zero;
        public override void AI()
        {
            if(projectile.velocity.Length() < 15f)
            {
                projectile.rotation += 0.15f;
            }
            else
            {
                projectile.rotation = (float)(Math.Atan2(projectile.velocity.Y, projectile.velocity.X)) + (float)Math.PI * 0.25f;
            }
            projectile.velocity *= 0.98f;
            if (projectile.velocity.Y < 15f && !x)
            {
                projectile.velocity.Y += 0.2f;
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 12; i++)
            {
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 15, 0f, 0f, 100, default(Color), 1f);
                Main.dust[num].noGravity = true;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
	}
}
