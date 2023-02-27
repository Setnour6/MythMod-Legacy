using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class Sprite : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("雪碧");
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
            Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 37, 1f, 0f);
            for (int i = 0; i < 60; i++)
            {
                Vector2 v = new Vector2(Main.rand.NextFloat(0, 8f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 16, v.X, v.Y, 100, default(Color), 2f);
                Main.dust[num].noGravity = true;
                Main.dust[num].velocity = v;
                Main.dust[num].fadeIn = 1.5f + (float)Main.rand.Next(20) * 0.1f;
            }
            for (int i = 0; i < 60; i++)
            {
                //int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 15, 0f, 0f, 100, default(Color), 1f);
                //Main.dust[num].noGravity = true;
                //Main.dust[num].noLight = true;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
	}
}
