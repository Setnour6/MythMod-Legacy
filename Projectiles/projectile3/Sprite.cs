using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class Sprite : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("雪碧");
		}
        private float num = 0;
        public override void SetDefaults()
		{
			base.Projectile.width = 38;
			base.Projectile.height = 38;
			base.Projectile.friendly = true;
			base.Projectile.alpha = 0;
			base.Projectile.penetrate = -1;
			base.Projectile.tileCollide = true;
			base.Projectile.timeLeft = 300;
            base.Projectile.DamageType = DamageClass.Throwing;
            base.Projectile.aiStyle = -1;
		}
        float timer = 0;
        static float j = 0;
        static float m = 0.15f;
        static float n = 0;
        private bool x = false;
        Vector2 pc2 = Vector2.Zero;
        public override void AI()
        {
            if(Projectile.velocity.Length() < 15f)
            {
                Projectile.rotation += 0.15f;
            }
            else
            {
                Projectile.rotation = (float)(Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X)) + (float)Math.PI * 0.25f;
            }
            Projectile.velocity *= 0.98f;
            if (Projectile.velocity.Y < 15f && !x)
            {
                Projectile.velocity.Y += 0.2f;
            }
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item37, new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
            for (int i = 0; i < 60; i++)
            {
                Vector2 v = new Vector2(Main.rand.NextFloat(0, 8f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 16, v.X, v.Y, 100, default(Color), 2f);
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
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
		}
	}
}
