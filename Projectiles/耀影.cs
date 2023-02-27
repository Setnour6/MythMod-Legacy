using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x02000618 RID: 1560
    public class 耀影 : ModProjectile
	{
		// Token: 0x0600221E RID: 8734 RVA: 0x0000BDFD File Offset: 0x00009FFD
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("耀影");
		}

		// Token: 0x0600221F RID: 8735 RVA: 0x001B7BC8 File Offset: 0x001B5DC8
		public override void SetDefaults()
		{
            base.projectile.width = 20;
            base.projectile.height = 20;
            base.projectile.aiStyle = 27;
            base.projectile.friendly = true;
            base.projectile.melee = true;
            base.projectile.penetrate = 3;
            base.projectile.timeLeft = 300;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 6;
            base.projectile.extraUpdates = 1;
            base.projectile.ignoreWater = true;
		}

		// Token: 0x06002220 RID: 8736 RVA: 0x001B7C54 File Offset: 0x001B5E54
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.3f / 255f, (float)(255 - base.projectile.alpha) * 0.4f / 255f, (float)(255 - base.projectile.alpha) * 1f / 255f);
			if (base.projectile.localAI[1] > 4f)
			{
                int num = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 27, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, default(Color), 2.2f);
				Main.dust[num].velocity *= 0.1f;
				Main.dust[num].noGravity = true;
			}
		}
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition, null, base.projectile.GetAlpha(lightColor), base.projectile.rotation, Utils.Size(texture2D) / 2f, base.projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
		// Token: 0x06002223 RID: 8739 RVA: 0x001B7D7C File Offset: 0x001B5F7C
		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 7; i++)
			{
                int num = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 27, base.projectile.velocity.X * 0f, base.projectile.velocity.Y * 0f, 150, default(Color), 2.2f);
				Main.dust[num].noGravity = true;
			}
		}

		// Token: 0x06002224 RID: 8740 RVA: 0x0000D83A File Offset: 0x0000BA3A
	}
}
