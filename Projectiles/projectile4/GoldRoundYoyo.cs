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
			base.Projectile.CloneDefaults(547);
            base.Projectile.width = 16;
			base.Projectile.height = 16;
			base.Projectile.scale = 1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 400f;
        }
        private int K = 0;
        public override void AI()
		{
            K += 1;
            ProjectileExtras.YoyoAI(base.Projectile.whoAmI, 60f, 300f, 14f);
            if (K % 15 == 0)
            {
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, 0, 0.4f, base.Mod.Find<ModProjectile>("LightEsclipse").Type, (int)((double)base.Projectile.damage * 3f), base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            }
        }
    }
}
