using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MythMod.Projectiles.projectile2
{
    public class TuskDamage : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("");
		}

		public override void SetDefaults()
		{
            base.Projectile.width = 40;
            base.Projectile.height = 40;
            base.Projectile.friendly = true;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = 1;
            base.Projectile.timeLeft = 6;
		}
		public override void AI()
		{
            Projectile.velocity.Y += 0.51f;
		}
	}
}
