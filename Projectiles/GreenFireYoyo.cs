using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles
{
	public class GreenFireYoyo : ModProjectile
	{
		private bool initialization = true;
        private float X;
		public override void SetDefaults()
		{
			base.projectile.CloneDefaults(547);
			base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.scale = 1f;
			base.projectile.alpha = 90;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 420f;
        }
		public override void AI()
		{
            ProjectileExtras.YoyoAI(base.projectile.whoAmI, 60f, 420f, 16f);
            X += 1;
            if (X % 3 == 0)
            {
                Vector2 V = new Vector2(0, 2.5f).RotatedBy(X / 4f);
                int num34 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, V.X, V.Y, base.mod.ProjectileType("FireworkGreen3"), base.projectile.damage, 0.2f, Main.myPlayer, 0f, 0f);
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
		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.Draw(base.mod.GetTexture("Projectiles/春回大地Glow"), base.projectile.Center - Main.screenPosition, null, new Color(255,255,255,0), base.projectile.rotation, new Vector2(8f, 8f), 1f, SpriteEffects.None, 0f);
        }
	}
}
