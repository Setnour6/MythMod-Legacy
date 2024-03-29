﻿using System;
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

namespace MythMod.Projectiles
{
	// Token: 0x02000618 RID: 1560
    public class 远古剑气 : ModProjectile
	{
		// Token: 0x0600221E RID: 8734 RVA: 0x0000BDFD File Offset: 0x00009FFD
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("远古剑气");
		}
        private Vector2 vector2;
		// Token: 0x0600221F RID: 8735 RVA: 0x001B7BC8 File Offset: 0x001B5DC8
		public override void SetDefaults()
		{
            base.projectile.width = 20;
            base.projectile.height = 20;
            base.projectile.aiStyle = 27;
            base.projectile.friendly = true;
            base.projectile.melee = true;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = 2;
            base.projectile.extraUpdates = 1;
            base.projectile.timeLeft = 600;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 1;
		}

		// Token: 0x06002220 RID: 8736 RVA: 0x001B7C54 File Offset: 0x001B5E54
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.055f / 255f, (float)(255 - base.projectile.alpha) * 0.64f / 255f, (float)(255 - base.projectile.alpha) * 0.945f / 255f);
			if (base.projectile.timeLeft >= 595)
			{
				vector2 =  base.projectile.velocity;
			}
		}
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48

        public override void Kill(int timeLeft)
        {
			for (int i = 0; i < 40; i++)
            {
				float num2 = (float)(Main.rand.Next(Main.rand.Next(50,1200),1800) / 900f);
                Vector2 vector = base.projectile.position;
                Vector2 v = new Vector2(0, 6.5f).RotatedByRandom(Math.PI * 2);
		    	int num = Dust.NewDust(vector, 4, 4, mod.DustType("Mud"), (float)vector2.X * (float)num2, (float)vector2.Y * (float)num2, 0, default(Color), 1.8f);
                int num3 = Dust.NewDust(vector, 4, 4, mod.DustType("Mud"), v.X, v.Y, 0, default(Color), 1.8f);
            }
		}
		// Token: 0x06002224 RID: 8740 RVA: 0x0000D83A File Offset: 0x0000BA3A
	}
}
