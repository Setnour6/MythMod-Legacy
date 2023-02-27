using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Shaders;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class StarDustMark2 : ModProjectile
	{
		private float num4;
		private bool num5 = true;
		private bool num6 = true;
		private Vector2 vector3;
		private float Distance;
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("星尘光标");
		}
		public override void SetDefaults()
		{
            base.projectile.width = 50;
            base.projectile.height = 50;
            base.projectile.friendly = true;
            base.projectile.timeLeft = 120;
            base.projectile.penetrate = -1;
            base.projectile.minion = true;
            base.projectile.tileCollide = false;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 10;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(projectile.ai[0], projectile.ai[0], projectile.ai[0], 0));
        }
        public override void AI()
        {
            if(projectile.ai[1] > 0)
            {

            }
            if (projectile.ai[0] < 1)
            {
                projectile.ai[0] += 0.01f;
            }
            else
            {
                projectile.ai[0] = 1;
            }
        }
    }
}
