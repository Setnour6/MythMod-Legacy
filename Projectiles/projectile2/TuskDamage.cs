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
            base.DisplayName.SetDefault("");
		}

		public override void SetDefaults()
		{
            base.projectile.width = 40;
            base.projectile.height = 40;
            base.projectile.friendly = true;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = 1;
            base.projectile.timeLeft = 6;
		}
		public override void AI()
		{
            projectile.velocity.Y += 0.51f;
		}
	}
}
