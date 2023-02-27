using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile4
{
	public class GoldRoundYoyo : ModProjectile
	{
		private bool M = false;
        private float X = 0;
		public override void SetDefaults()
		{
			base.projectile.CloneDefaults(547);
            base.projectile.width = 16;
			base.projectile.height = 16;
			base.projectile.scale = 1f;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 400f;
        }
        private int K = 0;
        public override void AI()
		{
            K += 1;
            ProjectileExtras.YoyoAI(base.projectile.whoAmI, 60f, 300f, 14f);
            if (K % 15 == 0)
            {
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 0, 0.4f, base.mod.ProjectileType("LightEsclipse"), (int)((double)base.projectile.damage * 3f), base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
        }
    }
}
