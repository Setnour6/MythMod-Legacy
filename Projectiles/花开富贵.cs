using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles
{
	public class 花开富贵 : ModProjectile
	{
		private bool initialization = true;
        private float X;
		public override void SetDefaults()
		{
			base.Projectile.CloneDefaults(547);
			base.Projectile.width = 16;
			base.Projectile.height = 16;
			base.Projectile.scale = 1f;
			base.Projectile.alpha = 90;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 420f;
        }
		public override void AI()
		{
            ProjectileExtras.YoyoAI(base.Projectile.whoAmI, 60f, 420f, 16f);
            X += 1;
            if (X % 3 == 0)
            {
                Vector2 V = new Vector2(0, 2.5f).RotatedBy(X / 4f);
                int num34 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, V.X, V.Y, base.Mod.Find<ModProjectile>("FireworkRed2").Type, base.Projectile.damage, 0.2f, Main.myPlayer, 0f, 0f);
            }
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(70, 240, true);
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
		public override void PostDraw(Color lightColor)
        {
            spriteBatch.Draw(base.Mod.GetTexture("Projectiles/花开富贵Glow"), base.Projectile.Center - Main.screenPosition, null, new Color(255,255,255,0), base.Projectile.rotation, new Vector2(8f, 8f), 1f, SpriteEffects.None, 0f);
        }
	}
}
