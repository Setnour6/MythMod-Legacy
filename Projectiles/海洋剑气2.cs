using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x02000618 RID: 1560
    public class 海洋剑气2 : ModProjectile
	{
		// Token: 0x0600221E RID: 8734 RVA: 0x0000BDFD File Offset: 0x00009FFD
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("海洋剑气2");
		}

		// Token: 0x0600221F RID: 8735 RVA: 0x001B7BC8 File Offset: 0x001B5DC8
		public override void SetDefaults()
		{
            base.Projectile.width = 20;
            base.Projectile.height = 20;
            base.Projectile.aiStyle = 27;
            base.Projectile.friendly = true;
            base.Projectile.DamageType = DamageClass.Melee;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = 100;
            base.Projectile.extraUpdates = 1;
            base.Projectile.timeLeft = 600;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 1;
		}

		// Token: 0x06002220 RID: 8736 RVA: 0x001B7C54 File Offset: 0x001B5E54
		public override void AI()
		{
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.055f / 255f, (float)(255 - base.Projectile.alpha) * 0.64f / 255f, (float)(255 - base.Projectile.alpha) * 0.945f / 255f);
			if (base.Projectile.localAI[1] > 7f)
			{
				int num25 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 33, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 150, new Color(Main.DiscoR, 100, 255), 1.2f);
				Main.dust[num25].velocity *= 0.5f;
				Main.dust[num25].noGravity = true;
			}
		}
        // Token: 0x06001E99 RID: 7833 RVA: 0x00188F8C File Offset: 0x0018718C
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 8; i++)
            {
                int num = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 33, base.Projectile.velocity.X * 0f, base.Projectile.velocity.Y * 0f, 150, new Color(Main.DiscoR, 100, 255), 1.2f);
                Main.dust[num].noGravity = true;
            }
        }

		// Token: 0x06002224 RID: 8740 RVA: 0x0000D83A File Offset: 0x0000BA3A
	}
}
