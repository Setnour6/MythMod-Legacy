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
			base.projectile.CloneDefaults(547);
			base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.scale = 1f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 220f;
        }
		public override void AI()
		{
            ProjectileExtras.YoyoAI(base.projectile.whoAmI, 60f, 220f, 15f);
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
	}
}
