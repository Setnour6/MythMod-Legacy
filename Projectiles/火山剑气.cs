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
    public class 火山剑气 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("火山剑气");
		}
		public override void SetDefaults()
		{
            base.projectile.width = 20;
            base.projectile.height = 20;
            base.projectile.aiStyle = 27;
            base.projectile.friendly = true;
            base.projectile.melee = true;
            base.projectile.ignoreWater = true;
            base.projectile.penetrate = 1;
            base.projectile.extraUpdates = 1;
            base.projectile.timeLeft = 600;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 1;
		}
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.055f / 255f, (float)(255 - base.projectile.alpha) * 0.64f / 255f, (float)(255 - base.projectile.alpha) * 0.945f / 255f);
            int num9 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4) - base.projectile.velocity * 6f, 0, 0, 55, 0f, 0f, 100, default(Color), 2.6f);
            Main.dust[num9].noGravity = true;
            Main.dust[num9].velocity *= 0.0f;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花爆炸"), (int)projectile.Center.X, (int)projectile.Center.Y);
			base.projectile.position.X = base.projectile.position.X + (float)(base.projectile.width / 2);
			base.projectile.position.Y = base.projectile.position.Y + (float)(base.projectile.height / 2);
			base.projectile.width = 30;
			base.projectile.height = 30;
			base.projectile.position.X = base.projectile.position.X - (float)(base.projectile.width / 2);
			base.projectile.position.Y = base.projectile.position.Y - (float)(base.projectile.height / 2);
			for (int i = 0; i < 36; i++)
			{
				int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 55, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num].velocity *= 3f;
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num].scale = 0.5f;
					Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
				}
			}
			for (int j = 0; j < 50; j++)
			{
				int num2 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 244, 0f, 0f, 100, default(Color), 3f);
				Main.dust[num2].noGravity = true;
				Main.dust[num2].velocity *= 5f;
				num2 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 244, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num2].velocity *= 2f;
			}
            if (base.projectile.owner == Main.myPlayer)
            {
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 0f, 0f, base.mod.ProjectileType("火山爆炸"), base.projectile.damage * 2, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
			for (int k = 0; k <= 10; k++)
			{
				float a = (float)Main.rand.Next(0 , 720) / 360 * 3.141592653589793238f;
				float m = (float)Main.rand.Next(0, 50000);
                float l = (float)Main.rand.Next((int)m , 50000) / 1800;
                int num4 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y,(float)((float)l * Math.Cos((float)a)) * 0.36f, (float)((float)l * Math.Sin((float)a)) * 0.36f, base.mod.ProjectileType("火山溅射"), base.projectile.damage / 2, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
				Main.projectile[num4].scale =  (float)Main.rand.Next(7000, 13000) / 10000f;
			}
            for (int k = 0; k <= 10; k++)
            {
                Vector2 v = new Vector2(0, 40).RotatedByRandom(Math.PI * 2);
                int num4 = Projectile.NewProjectile(base.projectile.Center.X + v.X, base.projectile.Center.Y + v.Y, 0, 0, base.mod.ProjectileType("爆炸效果光"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
        }
	}
}
