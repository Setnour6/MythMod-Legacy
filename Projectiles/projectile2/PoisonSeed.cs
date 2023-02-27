using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x02000512 RID: 1298
    public class PoisonSeed : ModProjectile
	{
		// Token: 0x06001C81 RID: 7297 RVA: 0x0000BBD6 File Offset: 0x00009DD6
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("剧毒种子");
		}
        private float num = 0;
        // Token: 0x06001C82 RID: 7298 RVA: 0x0016F518 File Offset: 0x0016D718
        public override void SetDefaults()
		{
			base.projectile.width = 40;
			base.projectile.height = 40;
			base.projectile.friendly = false;
            base.projectile.hostile = true;
            base.projectile.alpha = 0;
			base.projectile.penetrate = -1;
			base.projectile.tileCollide = true;
			base.projectile.timeLeft = 3600;
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
            if(j % 3 == 0)
            {
                Vector2 v = new Vector2(0, Main.rand.Next(20, 90)).RotatedByRandom(Math.PI * 2);
                Vector2 v2 = v.RotatedByRandom(Math.PI * 2) / Main.rand.NextFloat(10f, 40f);
                int num4 = Projectile.NewProjectile(base.projectile.Center.X + v.X, base.projectile.Center.Y + v.Y, v2.X, v2.Y, base.mod.ProjectileType("PoisonFog"), 5, 0, base.projectile.owner, 0f, 0f);
            }
            if(projectile.timeLeft < 60)
            {
                projectile.alpha += 5;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.Length() > 0.5f)
            {
                if (base.projectile.velocity.X != oldVelocity.X)
                {
                    base.projectile.velocity.X = -oldVelocity.X * 0.6f;
                }
                if (base.projectile.velocity.Y != oldVelocity.Y)
                {
                    base.projectile.velocity.Y = -oldVelocity.Y * 0.6f;
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
        }
        // Token: 0x06001E99 RID: 7833 RVA: 0x00188F8C File Offset: 0x0018718C
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
	}
}
