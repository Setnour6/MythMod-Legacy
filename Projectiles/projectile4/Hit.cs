using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles.projectile4
{
    public class Hit : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("伤害");
		}
		public override void SetDefaults()
		{
			projectile.width = 12;
			projectile.height = 12;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.alpha = 0;
			projectile.penetrate = 1;
			projectile.timeLeft = 1;
            projectile.extraUpdates = 12;
            projectile.tileCollide = true;
        }
        private float Y = 0;
        private float X = 0;
        private float ω = 0;
        private bool Orbit = false;
        public override void AI()
		{
        }
        public override void Kill(int timeLeft)
        {           
        }
    }
}
