using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x02000749 RID: 1865
    public class RedBulb : ModProjectile
	{
		// Token: 0x060028BD RID: 10429 RVA: 0x0000D7C0 File Offset: 0x0000B9C0
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("灯头");
		}

		// Token: 0x060028BE RID: 10430 RVA: 0x00208FC8 File Offset: 0x002071C8
		public override void SetDefaults()
		{
			base.Projectile.width = 18;
            base.Projectile.tileCollide = true;
            base.Projectile.height = 18;
			base.Projectile.friendly = true;
			base.Projectile.penetrate = -1;
			base.Projectile.timeLeft = 600;
			base.Projectile.DamageType = DamageClass.Melee;
            base.Projectile.aiStyle = 27;
			base.Projectile.scale = 1f;
		}

		// Token: 0x060028BF RID: 10431 RVA: 0x00208A7C File Offset: 0x00206C7C
		public override void AI()
		{
            Projectile.velocity *= 0.995f;
            Projectile.velocity.Y += 0.15f;
            if (Projectile.timeLeft % 40 == 0)
            {
                Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, 0, 0, Mod.Find<ModProjectile>("RedLED").Type, Projectile.damage / 2, 1, Main.myPlayer, 0f, 0f);
            }
            if (Projectile.timeLeft % 40 == 10)
            {
                Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, 0, 0, Mod.Find<ModProjectile>("BlueLED").Type, Projectile.damage / 2, 1, Main.myPlayer, 0f, 0f);
            }
            if (Projectile.timeLeft % 40 == 20)
            {
                Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, 0, 0, Mod.Find<ModProjectile>("GreenLED").Type, Projectile.damage / 2, 1, Main.myPlayer, 0f, 0f);
            }
            if (Projectile.timeLeft % 40 == 30)
            {
                Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, 0, 0, Mod.Find<ModProjectile>("YellowLED").Type, Projectile.damage / 2, 1, Main.myPlayer, 0f, 0f);
            }
            int num = Dust.NewDust(base.Projectile.Center - new Vector2(4, 4), 0, 0, 16, 0, 0, 0, default(Color), 1.5f);
            Main.dust[num].velocity *= 0;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
        public override Color? GetAlpha(Color lightColor)
        {
            if (Projectile.timeLeft > 60)
            {
                return new Color?(new Color(255, 255, 255, 100));
            }
            else
            {
                return new Color?(new Color(1 * Projectile.timeLeft / 60f, 1 * Projectile.timeLeft / 60f, 1 * Projectile.timeLeft / 60f, 0));
            }
        }
        // Token: 0x060028C0 RID: 10432 RVA: 0x00208E28 File Offset: 0x00207028
        public override void Kill(int timeLeft)
        {
            for(int i = 0; i < 25; i++)
            {
                int num3 = Dust.NewDust(base.Projectile.Center - new Vector2(4, 4) + Projectile.velocity, 8, 8, 127, 0, 0, 0, default(Color), 3f);
            }
        }
	}
}
