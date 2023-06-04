using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x02000749 RID: 1865
    public class BeeBeam : ModProjectile
	{
		// Token: 0x060028BD RID: 10429 RVA: 0x0000D7C0 File Offset: 0x0000B9C0
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("蜜蜂剑气");
		}

		// Token: 0x060028BE RID: 10430 RVA: 0x00208FC8 File Offset: 0x002071C8
		public override void SetDefaults()
		{
			base.Projectile.width = 40;
			base.Projectile.height = 40;
			base.Projectile.friendly = true;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 900;
			base.Projectile.DamageType = DamageClass.Melee;
            base.Projectile.aiStyle = 27;
		}

		// Token: 0x060028BF RID: 10431 RVA: 0x00208A7C File Offset: 0x00206C7C
		public override void AI()
		{
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
		}
		// Token: 0x060028C0 RID: 10432 RVA: 0x00208E28 File Offset: 0x00207028
        public override void Kill(int timeLeft)
        {
            for (int j = 0; j < 6; j++)
            {
                Vector2 v = new Vector2(0, 7).RotatedByRandom(Math.PI * 2) * Main.rand.Next(0, 2000) / 1000f;
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, 181, Projectile.damage / 4, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            }
            for (int j = 0; j < 2; j++)
            {
                Vector2 v = new Vector2(0, 7).RotatedByRandom(Math.PI * 2) * Main.rand.Next(0, 2000) / 1000f;
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, 189, Projectile.damage * 3 / 8, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            }
            for (int j = 0; j < 1; j++)
            {
                Vector2 v = new Vector2(0, 7).RotatedByRandom(Math.PI * 2) * Main.rand.Next(0, 2000) / 1000f;
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, 566, Projectile.damage, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            }
            for (int i = 0; i < 25; i++)
            {
                int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 174, 0f, 0f, 100, default(Color), 2f);
                Main.dust[num].velocity *= 3f;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num].scale = 0.5f;
                    Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                }
            }
        }
	}
}
