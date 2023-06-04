using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x02000749 RID: 1865
    public class CurseFlame : ModProjectile
	{
		// Token: 0x060028BD RID: 10429 RVA: 0x0000D7C0 File Offset: 0x0000B9C0
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("诅咒焰");
		}

		// Token: 0x060028BE RID: 10430 RVA: 0x00208FC8 File Offset: 0x002071C8
		public override void SetDefaults()
		{
			base.Projectile.width = 28;
			base.Projectile.height = 28;
			base.Projectile.friendly = true;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 3600;
			base.Projectile.DamageType = DamageClass.Melee;
            base.Projectile.aiStyle = 27;
			base.Projectile.scale = 1.5f;
		}

		// Token: 0x060028BF RID: 10431 RVA: 0x00208A7C File Offset: 0x00206C7C
		public override void AI()
		{
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.25f / 255f, (float)(255 - base.Projectile.alpha) * 1.5f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f);
            int num3 = Dust.NewDust(base.Projectile.Center - base.Projectile.velocity * 4f - new Vector2(4, 4), 0, 0, 75, 0, 0, 0, default(Color), 1.6f);
			float num = base.Projectile.Center.X;
			float num2 = base.Projectile.Center.Y;
			Main.dust[num3].noGravity = true;
			Main.dust[num3].velocity= new Vector2(0, 0);
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(39, 300, false);
		}
		// Token: 0x060028C0 RID: 10432 RVA: 0x00208E28 File Offset: 0x00207028
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 30; i++)
            {
                int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 75, 0f, 0f, 100, default(Color), 2f);
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
