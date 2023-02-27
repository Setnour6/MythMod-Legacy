using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x02000618 RID: 1560
    public class 血琉璃长矛4 : ModProjectile
	{
		// Token: 0x0600221E RID: 8734 RVA: 0x0000BDFD File Offset: 0x00009FFD
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("血琉璃长矛");
		}
        private bool initialization = true;
        private float X;
		// Token: 0x0600221F RID: 8735 RVA: 0x001B7BC8 File Offset: 0x001B5DC8
		public override void SetDefaults()
		{
            base.projectile.width = 36;
            base.projectile.height = 36;
            base.projectile.aiStyle = 27;
            base.projectile.friendly = true;
            base.projectile.melee = true;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = 5;
            base.projectile.extraUpdates = 1;
            base.projectile.timeLeft = 120;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 1;
		}

		// Token: 0x06002220 RID: 8736 RVA: 0x001B7C54 File Offset: 0x001B5E54
		public override void AI()
		{
            if (initialization)
            {
                X = Main.rand.Next(0,8);
				initialization = false;
            }
			Lighting.AddLight(base.projectile.Center, 0.24f, 0f, 0.04f);
			if (base.projectile.localAI[1] > 70f)
			{
				int num = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 262, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, Color.White, 1.2f);
				Main.dust[num].velocity *= 0.0f;
				Main.dust[num].noGravity = true;
			}
            int num1 = Dust.NewDust(new Vector2((float)base.projectile.position.X + 18f,(float)base.projectile.position.Y + 15f), 0, 0, 183, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 150, Color.White, 1.3f);
            Main.dust[num1].velocity *= 0.0f;
            Main.dust[num1].noGravity = true;
		}
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition, null, base.projectile.GetAlpha(lightColor), base.projectile.rotation, Utils.Size(texture2D) / 2f, base.projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
        }
	}
}
