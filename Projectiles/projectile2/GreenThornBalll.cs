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
			base.projectile.width = 38;
			base.projectile.height = 38;
			base.projectile.friendly = false;
            base.projectile.hostile = true;
            base.projectile.alpha = 0;
			base.projectile.penetrate = -1;
			base.projectile.tileCollide = true;
			base.projectile.timeLeft = 300;
            base.projectile.ranged = true;
            base.projectile.aiStyle = -1;
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
            projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f + num;
            if(projectile.timeLeft <= 250 && !x)
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
            if (projectile.velocity.Y < 15f && !x)
            {
                projectile.velocity.Y += 0.2f;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.Length() > 0.5f)
            {
                if (base.projectile.velocity.X != oldVelocity.X)
                {
                    base.projectile.velocity.X = -oldVelocity.X * 0.95f;
                }
                if (base.projectile.velocity.Y != oldVelocity.Y)
                {
                    base.projectile.velocity.Y = -oldVelocity.Y * 0.95f;
                }
            }
            else
            {
                base.projectile.velocity.Y *= 0;
                base.projectile.velocity.X *= 0;
                x = true;
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            if(projectile.hostile)
            {
                for (int j = 0; j < 10; j++)
                {
                    Vector2 v = new Vector2(0, 5).RotatedByRandom(Math.PI * 2) * Main.rand.Next(0, 2000) / 1000f;
                    Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, 276, (int)((double)base.projectile.damage), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                }
            }
            else
            {
                for (int j = 0; j < 10; j++)
                {
                    Vector2 v = new Vector2(0, 5).RotatedByRandom(Math.PI * 2) * Main.rand.Next(0, 2000) / 1000f;
                    int zi = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, 276, (int)((double)base.projectile.damage), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
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
