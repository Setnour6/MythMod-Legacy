using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x02000749 RID: 1865
    public class SlimeBeam : ModProjectile
	{
		// Token: 0x060028BD RID: 10429 RVA: 0x0000D7C0 File Offset: 0x0000B9C0
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("史莱姆剑气");
		}

		// Token: 0x060028BE RID: 10430 RVA: 0x00208FC8 File Offset: 0x002071C8
		public override void SetDefaults()
		{
			base.Projectile.width = 18;
			base.Projectile.height = 18;
			base.Projectile.friendly = true;
            base.Projectile.extraUpdates = 3;
			base.Projectile.penetrate = 10;
			base.Projectile.timeLeft = 3600;
			base.Projectile.DamageType = DamageClass.Melee;
            base.Projectile.aiStyle = 27;
		}

		// Token: 0x060028BF RID: 10431 RVA: 0x00208A7C File Offset: 0x00206C7C
        public override void AI()
        {
            Vector2 vector = (base.Projectile.position + base.Projectile.Center) / 2;
            int num12 = Dust.NewDust(vector, 0, 0, 33, 0f, 0f, 0, default(Color), 1f);
            Main.dust[num12].velocity *= 0.0f;
            Main.dust[num12].noGravity = true;
            base.Projectile.localAI[0] += 1f;
            if (base.Projectile.localAI[0] > 4f)
            {
                for (int i = 0; i < 10; i++)
                {
                }
            }
            this.projTime--;
            if (this.projTime == 0)
            {
                this.projTime = 15;
            }
        }

        // Token: 0x06002462 RID: 9314 RVA: 0x0018A49C File Offset: 0x0018869C
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.Projectile.penetrate--;
            if (base.Projectile.penetrate <= 0)
            {
                base.Projectile.Kill();
            }
            else
            {
                base.Projectile.ai[0] += 0.1f;
                if (base.Projectile.velocity.X != oldVelocity.X)
                {
                    base.Projectile.velocity.X = -oldVelocity.X;
                }
                if (base.Projectile.velocity.Y != oldVelocity.Y)
                {
                    base.Projectile.velocity.Y = -oldVelocity.Y;
                }
            }
            return false;
        }

        // Token: 0x06002463 RID: 9315 RVA: 0x001D67F4 File Offset: 0x001D49F4
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {
            }
        }
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
        public int projTime = 15;
    }
}
