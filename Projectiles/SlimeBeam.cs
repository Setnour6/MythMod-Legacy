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
            base.DisplayName.SetDefault("史莱姆剑气");
		}

		// Token: 0x060028BE RID: 10430 RVA: 0x00208FC8 File Offset: 0x002071C8
		public override void SetDefaults()
		{
			base.projectile.width = 18;
			base.projectile.height = 18;
			base.projectile.friendly = true;
            base.projectile.extraUpdates = 3;
			base.projectile.penetrate = 10;
			base.projectile.timeLeft = 3600;
			base.projectile.melee = true;
            base.projectile.aiStyle = 27;
		}

		// Token: 0x060028BF RID: 10431 RVA: 0x00208A7C File Offset: 0x00206C7C
        public override void AI()
        {
            Vector2 vector = (base.projectile.position + base.projectile.Center) / 2;
            int num12 = Dust.NewDust(vector, 0, 0, 33, 0f, 0f, 0, default(Color), 1f);
            Main.dust[num12].velocity *= 0.0f;
            Main.dust[num12].noGravity = true;
            base.projectile.localAI[0] += 1f;
            if (base.projectile.localAI[0] > 4f)
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
            base.projectile.penetrate--;
            if (base.projectile.penetrate <= 0)
            {
                base.projectile.Kill();
            }
            else
            {
                base.projectile.ai[0] += 0.1f;
                if (base.projectile.velocity.X != oldVelocity.X)
                {
                    base.projectile.velocity.X = -oldVelocity.X;
                }
                if (base.projectile.velocity.Y != oldVelocity.Y)
                {
                    base.projectile.velocity.Y = -oldVelocity.Y;
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
