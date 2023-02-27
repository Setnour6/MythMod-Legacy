using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x02000A56 RID: 2646
	public class FluoresceinYoyo2 : ModProjectile
	{
		private bool initialization = true;
        private float X;
		// Token: 0x06003182 RID: 12674 RVA: 0x0000EF18 File Offset: 0x0000D118
		public override void SetDefaults()
		{
			base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.scale = 1f;
            base.projectile.alpha += 75;
            base.projectile.timeLeft = 90;
            base.projectile.friendly = true;
            base.projectile.tileCollide = false;
            base.projectile.penetrate = -1;

        }
		// Token: 0x06002220 RID: 8736 RVA: 0x001B7C54 File Offset: 0x001B5E54
		public override void AI()
		{
            base.projectile.velocity *= 0.8f;
            base.projectile.rotation -= (float)Math.Sqrt((float)projectile.velocity.X * (float)projectile.velocity.X + (float)projectile.velocity.Y * (float)projectile.velocity.Y) * 0.3f + 0.08f;
            base.projectile.alpha += 2;
        }
		// Token: 0x06003183 RID: 12675 RVA: 0x001AA8C0 File Offset: 0x001A8AC0
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(70, 240, true);
		}

		// Token: 0x06003186 RID: 12678 RVA: 0x000064C1 File Offset: 0x000046C1
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.Draw(base.mod.GetTexture("Projectiles/荧光素球_Glow"), base.projectile.Center - Main.screenPosition, null, Color.White * ((255 - projectile.alpha) / 255f), base.projectile.rotation, new Vector2(8f, 8f), 1f, SpriteEffects.None, 0f);
        }
	}
}
