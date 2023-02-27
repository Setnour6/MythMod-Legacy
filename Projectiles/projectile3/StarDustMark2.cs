﻿using System;
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
            base.Projectile.width = 50;
            base.Projectile.height = 50;
            base.Projectile.friendly = true;
            base.Projectile.timeLeft = 120;
            base.Projectile.penetrate = -1;
            base.Projectile.minion = true;
            base.Projectile.tileCollide = false;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 10;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(Projectile.ai[0], Projectile.ai[0], Projectile.ai[0], 0));
        }
        public override void AI()
        {
            if(Projectile.ai[1] > 0)
            {

            }
            if (Projectile.ai[0] < 1)
            {
                Projectile.ai[0] += 0.01f;
            }
            else
            {
                Projectile.ai[0] = 1;
            }
        }
    }
}
