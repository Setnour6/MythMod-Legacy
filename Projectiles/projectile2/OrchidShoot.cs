using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x02000749 RID: 1865
    public class OrchidShoot : ModProjectile
	{
		// Token: 0x060028BD RID: 10429 RVA: 0x0000D7C0 File Offset: 0x0000B9C0
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("兰花剑气");
		}

		// Token: 0x060028BE RID: 10430 RVA: 0x00208FC8 File Offset: 0x002071C8
		public override void SetDefaults()
		{
			base.projectile.width = 38;
            base.projectile.tileCollide = false;
            base.projectile.height = 38;
			base.projectile.friendly = false;
            base.projectile.hostile = true;
            base.projectile.penetrate = -1;
			base.projectile.timeLeft = 500;
			base.projectile.melee = true;
            base.projectile.aiStyle = 27;
			base.projectile.scale = 1.5f;
		}

		// Token: 0x060028BF RID: 10431 RVA: 0x00208A7C File Offset: 0x00206C7C
		public override void AI()
		{
            projectile.velocity *= 0.99f;
			float num = base.projectile.Center.X;
			float num2 = base.projectile.Center.Y;
            if (projectile.timeLeft > 120 && projectile.timeLeft < 193)
            {
                Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 2f / 255f * projectile.scale, (float)(255 - base.projectile.alpha) * 0.23f * projectile.scale / 255f, (float)(255 - base.projectile.alpha) * 2.55f / 255f * projectile.scale);
            }
            if (projectile.timeLeft <= 120)
            {
                Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 2f / 255f * projectile.scale * projectile.timeLeft / 120f, (float)(255 - base.projectile.alpha) * 0.23f * projectile.scale / 255f * projectile.timeLeft / 120f, (float)(255 - base.projectile.alpha) * 2.55f / 255f * projectile.scale * projectile.timeLeft / 120f);
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
        public override Color? GetAlpha(Color lightColor)
        {
            if (projectile.timeLeft > 60)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color(1 * projectile.timeLeft / 60f, 1 * projectile.timeLeft / 60f, 1 * projectile.timeLeft / 60f, 0));
            }
        }
        // Token: 0x060028C0 RID: 10432 RVA: 0x00208E28 File Offset: 0x00207028
        public override void Kill(int timeLeft)
        {
        }
	}
}
