using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
    public class GreenThornBalll : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("青刺球");
		}
        private float num = 0;
        public override void SetDefaults()
		{
			base.Projectile.width = 38;
			base.Projectile.height = 38;
			base.Projectile.friendly = false;
            base.Projectile.hostile = true;
            base.Projectile.alpha = 0;
			base.Projectile.penetrate = -1;
			base.Projectile.tileCollide = true;
			base.Projectile.timeLeft = 300;
            base.Projectile.DamageType = DamageClass.Ranged;
            base.Projectile.aiStyle = -1;
		}
        float timer = 0;
        static int j = 0;
        static float m = 0.15f;
        static float n = 0;
        private bool x = false;
        Vector2 pc2 = Vector2.Zero;
        // Token: 0x06001E99 RID: 7833 RVA: 0x00188F8C File Offset: 0x0018718C
        public override void AI()
        {
            j += 1;
            Projectile.rotation = (float)System.Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 1.57f + num;
            if(Projectile.timeLeft <= 250 && !x)
            {
                num += 0.15f;
            }
            if(x)
            {
                num += m;
                if(m > 0)
                {
                    m -= 0.005f;
                }
                else
                {
                    m = 0;
                }
            }
            if (Projectile.velocity.Y < 15f && !x)
            {
                Projectile.velocity.Y += 0.2f;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.velocity.Length() > 0.5f)
            {
                if (base.Projectile.velocity.X != oldVelocity.X)
                {
                    base.Projectile.velocity.X = -oldVelocity.X * 0.95f;
                }
                if (base.Projectile.velocity.Y != oldVelocity.Y)
                {
                    base.Projectile.velocity.Y = -oldVelocity.Y * 0.95f;
                }
            }
            else
            {
                base.Projectile.velocity.Y *= 0;
                base.Projectile.velocity.X *= 0;
                x = true;
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            if(Projectile.hostile)
            {
                for (int j = 0; j < 10; j++)
                {
                    Vector2 v = new Vector2(0, 5).RotatedByRandom(Math.PI * 2) * Main.rand.Next(0, 2000) / 1000f;
                    Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, 276, (int)((double)base.Projectile.damage), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                }
            }
            else
            {
                for (int j = 0; j < 10; j++)
                {
                    Vector2 v = new Vector2(0, 5).RotatedByRandom(Math.PI * 2) * Main.rand.Next(0, 2000) / 1000f;
                    int zi = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, 276, (int)((double)base.Projectile.damage), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                    Main.projectile[zi].hostile = false;
                    Main.projectile[zi].friendly = true;
                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
	}
}
