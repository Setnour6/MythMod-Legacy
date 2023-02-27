using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	public class VortexYoyo : ModProjectile
	{
		private bool initialization = true;
        private float X;
	    private float X1;
		public override void SetDefaults()
		{
			base.Projectile.CloneDefaults(547);
			base.Projectile.width = 16;
			base.Projectile.height = 16;
			base.Projectile.scale = 1f;
			ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 380f;
		}
		public override void AI()
		{
            ProjectileExtras.YoyoAI(base.Projectile.whoAmI, 3600f, 390f, 16f);
            if (initialization)
            {
                X = 0;
				X1 = 0;
				initialization = false;
            }
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			X += 1;
			if(X >= 3)
			{
				int num = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("WaveBallMini").Type, (int)((double)base.Projectile.damage * 3f), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
				Main.projectile[num].timeLeft = 1;
				X = 0;
			}
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
	}
}
