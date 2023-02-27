using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader.IO;

namespace MythMod.Projectiles
{
	// Token: 0x0200067E RID: 1662
    public class 空间粒子流 : ModProjectile
	{
		// Token: 0x06002466 RID: 9318 RVA: 0x0000D1B0 File Offset: 0x0000B3B0
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("空间粒子流");
		}

		// Token: 0x06002467 RID: 9319 RVA: 0x001D6884 File Offset: 0x001D4A84
		public override void SetDefaults()
		{
			base.projectile.width = 1;
			base.projectile.height = 1;
			base.projectile.friendly = false;
            base.projectile.hostile = true;
			base.projectile.alpha = 255;
			base.projectile.penetrate = -1;
			base.projectile.tileCollide = false;
			base.projectile.ignoreWater = true;
			base.projectile.melee = true;
			base.projectile.timeLeft = 2400;
			base.projectile.extraUpdates = 10;
		}

		// Token: 0x06002468 RID: 9320 RVA: 0x001D6908 File Offset: 0x001D4B08
		public override void AI()
		{
            int dustID = Dust.NewDust(projectile.position, projectile.width, projectile.height, 111, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 201, Color.White, 1.2f);/*粉尘效果不用管*/
            Main.dust[dustID].noGravity = true;
			Main.dust[dustID].velocity.X = 0;
			Main.dust[dustID].velocity.Y = 0;
		}
	}
}
