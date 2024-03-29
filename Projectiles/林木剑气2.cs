﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x02000618 RID: 1560
    public class 林木剑气2 : ModProjectile
	{
		// Token: 0x0600221E RID: 8734 RVA: 0x0000BDFD File Offset: 0x00009FFD
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("林木剑气2");
		}

		// Token: 0x0600221F RID: 8735 RVA: 0x001B7BC8 File Offset: 0x001B5DC8
		public override void SetDefaults()
		{
            base.projectile.width = 20;
            base.projectile.height = 20;
            base.projectile.aiStyle = 27;
            base.projectile.friendly = true;
            base.projectile.melee = true;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = 4;
            base.projectile.extraUpdates = 1;
            base.projectile.timeLeft = 600;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.tileCollide = false;
            base.projectile.localNPCHitCooldown = 1;
		}

		// Token: 0x06002220 RID: 8736 RVA: 0x001B7C54 File Offset: 0x001B5E54
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.0157f / 255f, (float)(255 - base.projectile.alpha) * 0.5843f / 255f, (float)(255 - base.projectile.alpha) * 0.08235f / 255f);
			if (base.projectile.localAI[1] > 7f)
			{
				int num = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 110, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, new Color(Main.DiscoR, 100, 255), 1.2f);
				Main.dust[num].velocity *= 0.5f;
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
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 42; i++)
            {
                int num = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 110, base.projectile.velocity.X * 0f, base.projectile.velocity.Y * 0f, 150, new Color(Main.DiscoR, 100, 255), 1.2f);
                Main.dust[num].noGravity = true;
            }
            // Token: 0x06002224 RID: 8740 RVA: 0x0000D83A File Offset: 0x0000BA3A
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int i = 0; i < 188; i++)
            {
                int num = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 110, base.projectile.velocity.X * 0f, base.projectile.velocity.Y * 0f, 150, new Color(Main.DiscoR, 100, 255), 1.2f);
                Main.dust[num].noGravity = true;
            }
            if (target.type == 488)
            {
                return;
            }
            float num1 = (float)damage * 0.04f;
            if ((int)num1 == 0)
            {
                return;
            }
            if (Main.player[Main.myPlayer].lifeSteal <= 0f)
            {
                return;
            }
            Main.player[Main.myPlayer].lifeSteal -= num1;
            int owner = base.projectile.owner;
            
        }
	}
}
