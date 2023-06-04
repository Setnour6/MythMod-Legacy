using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles
{
	public class MothYoyo : ModProjectile
	{
		private bool initialization = true;
        private float X;
		public override void SetDefaults()
		{
			base.Projectile.CloneDefaults(547);
			base.Projectile.width = 16;
			base.Projectile.height = 16;
			base.Projectile.scale = 1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 220f;
        }
		public override void AI()
		{
            ProjectileExtras.YoyoAI(base.Projectile.whoAmI, 60f, 220f, 15f);
        }
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
	}
}
