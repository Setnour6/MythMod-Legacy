using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x02000A56 RID: 2646
	public class CurseYoyo : ModProjectile
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
		}
        // Token: 0x06002220 RID: 8736 RVA: 0x001B7C54 File Offset: 0x001B5E54
        public override bool PreAI()
        {
            Player player = Main.player[base.projectile.owner];
            ProjectileExtras.YoyoAI(base.projectile.whoAmI, 60f, 270f, 16f);
            Lighting.AddLight(projectile.Center,0, 0.2f, 0);
            return false;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(39, 600, false);
            for (int u = 0; u < 35; u++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0f, 10f)).RotatedByRandom(Math.PI * 2f);
                int num3 = Dust.NewDust(base.projectile.Center, 0, 0, 75, (float)v.X, (float)v.Y, 0, default(Color), 3f);
                Main.dust[num3].noGravity = true;
                Main.dust[num3].velocity = v;
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile2/咒鳞球Glow"), base.projectile.Center - Main.screenPosition, null, Color.White * 0.7f, base.projectile.rotation, new Vector2(8f, 8f), 1f, SpriteEffects.None, 0f);
        }
    }
}
