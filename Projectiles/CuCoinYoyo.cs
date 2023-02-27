using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x02000A56 RID: 2646
	public class CuCoinYoyo : ModProjectile
	{
		private bool M = false;
        private float X = 0;
		// Token: 0x06003182 RID: 12674 RVA: 0x0000EF18 File Offset: 0x0000D118
		public override void SetDefaults()
		{
			base.projectile.CloneDefaults(547);
            base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.scale = 1f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 200f;
        }
		// Token: 0x06002220 RID: 8736 RVA: 0x001B7C54 File Offset: 0x001B5E54
		public override void AI()
		{
            ProjectileExtras.YoyoAI(base.projectile.whoAmI, 60f, 200f, 16f);
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.Draw(base.mod.GetTexture("Projectiles/铜币悠悠球light"), base.projectile.Center - Main.screenPosition, null, new Color(0.4f, 0.4f, 0.4f, 0), 0, new Vector2(8f, 8f), 1f, SpriteEffects.None, 0f);
        }
        // Token: 0x06003183 RID: 12675 RVA: 0x001AA8C0 File Offset: 0x001A8AC0
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            X = 100;
            for (int j = 0; j < 3; j++)
            {
                Vector2 v = new Vector2(0, 5).RotatedByRandom(Math.PI * 2) * Main.rand.Next(0, 2000) / 1000f;
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, base.mod.ProjectileType("CuCoin"), (int)((double)base.projectile.damage * 0.6f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
        }

		// Token: 0x06003186 RID: 12678 RVA: 0x000064C1 File Offset: 0x000046C1
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
            X = 100;
            return false;
		}
	}
}
