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
			base.Projectile.width = 40;
			base.Projectile.height = 40;
			base.Projectile.friendly = false;
            base.Projectile.hostile = true;
            base.Projectile.alpha = 0;
			base.Projectile.penetrate = -1;
			base.Projectile.tileCollide = true;
			base.Projectile.timeLeft = 3600;
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
            if(j % 3 == 0)
            {
                Vector2 v = new Vector2(0, Main.rand.Next(20, 90)).RotatedByRandom(Math.PI * 2);
                Vector2 v2 = v.RotatedByRandom(Math.PI * 2) / Main.rand.NextFloat(10f, 40f);
                int num4 = Projectile.NewProjectile(base.Projectile.Center.X + v.X, base.Projectile.Center.Y + v.Y, v2.X, v2.Y, base.Mod.Find<ModProjectile>("PoisonFog").Type, 5, 0, base.Projectile.owner, 0f, 0f);
            }
            if(Projectile.timeLeft < 60)
            {
                Projectile.alpha += 5;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.velocity.Length() > 0.5f)
            {
                if (base.Projectile.velocity.X != oldVelocity.X)
                {
                    base.Projectile.velocity.X = -oldVelocity.X * 0.6f;
                }
                if (base.Projectile.velocity.Y != oldVelocity.Y)
                {
                    base.Projectile.velocity.Y = -oldVelocity.Y * 0.6f;
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
        }
        // Token: 0x06001E99 RID: 7833 RVA: 0x00188F8C File Offset: 0x0018718C
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
	}
}
