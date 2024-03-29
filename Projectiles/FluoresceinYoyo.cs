﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles
{
	// Token: 0x02000A56 RID: 2646
	public class FluoresceinYoyo : ModProjectile
	{
		private bool initialization = true;
        private float X;
		// Token: 0x06003182 RID: 12674 RVA: 0x0000EF18 File Offset: 0x0000D118
		public override void SetDefaults()
		{
			base.projectile.CloneDefaults(547);
			base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.scale = 1f;
			base.projectile.alpha = 90;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 420f;
        }
		// Token: 0x06002220 RID: 8736 RVA: 0x001B7C54 File Offset: 0x001B5E54
		public override void AI()
		{
            ProjectileExtras.YoyoAI(base.projectile.whoAmI, 60f, 420f, 16f);
            X += 1;
            Vector2 V = new Vector2(0, 25).RotatedBy(Main.rand.Next(0,2000) / 1000f * Math.PI);
            if (X % 5 == 0)
            {
                int num34 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, V.X, V.Y, base.mod.ProjectileType("FluoresceinYoyo2"), base.projectile.damage, 0.2f, Main.myPlayer, 0f, 0f);
            }
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
            spriteBatch.Draw(base.mod.GetTexture("Projectiles/荧光素球_Glow"), base.projectile.Center - Main.screenPosition, null, Color.White * 0.7f, base.projectile.rotation, new Vector2(8f, 8f), 1f, SpriteEffects.None, 0f);
        }
	}
}
