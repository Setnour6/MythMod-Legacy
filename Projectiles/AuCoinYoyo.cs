using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	public class AuCoinYoyo : ModProjectile
	{
		private bool M = false;
        private float X = 0;
		public override void SetDefaults()
		{
			base.Projectile.CloneDefaults(547);
            base.Projectile.width = 16;
			base.Projectile.height = 16;
			base.Projectile.scale = 1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 550f;
        }
		public override void AI()
		{
            ProjectileExtras.YoyoAI(base.Projectile.whoAmI, 60f, 550f, 16f);
            if ((int)(Main.time / 5f) % 15 == 0)
            {
                Vector2 v = new Vector2(0, 7).RotatedByRandom(Math.PI * 2) * Main.rand.Next(0, 80) / 1000f;
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, base.Mod.Find<ModProjectile>("AuCoin").Type, (int)((double)base.Projectile.damage * 0.6f), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            }
        }
        public override void PostDraw(Color lightColor)
        {
            spriteBatch.Draw(base.Mod.GetTexture("Projectiles/金币悠悠球light"), base.Projectile.Center - Main.screenPosition, null, new Color(0.4f, 0.4f, 0.4f, 0), 0, new Vector2(8f, 8f), 1f, SpriteEffects.None, 0f);
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
            X = 100;
            for (int j = 0; j < 5; j++)
            {
                Vector2 v = new Vector2(0, 7).RotatedByRandom(Math.PI * 2) * Main.rand.Next(0, 2000) / 1000f;
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, base.Mod.Find<ModProjectile>("金钱").Type, (int)((double)base.Projectile.damage * 0.6f), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            }
        }
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
            X = 100;
            return false;
		}
	}
}
