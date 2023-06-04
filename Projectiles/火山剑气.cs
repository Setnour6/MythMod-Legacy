using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
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
            // base.DisplayName.SetDefault("火山剑气");
		}
		public override void SetDefaults()
		{
            base.Projectile.width = 20;
            base.Projectile.height = 20;
            base.Projectile.aiStyle = 27;
            base.Projectile.friendly = true;
            base.Projectile.DamageType = DamageClass.Melee;
            base.Projectile.ignoreWater = true;
            base.Projectile.penetrate = 1;
            base.Projectile.extraUpdates = 1;
            base.Projectile.timeLeft = 600;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 1;
		}
		public override void AI()
		{
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.055f / 255f, (float)(255 - base.Projectile.alpha) * 0.64f / 255f, (float)(255 - base.Projectile.alpha) * 0.945f / 255f);
            int num9 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - new Vector2(4, 4) - base.Projectile.velocity * 6f, 0, 0, 55, 0f, 0f, 100, default(Color), 2.6f);
            Main.dust[num9].noGravity = true;
            Main.dust[num9].velocity *= 0.0f;
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/烟花爆炸"), (int)Projectile.Center.X, (int)Projectile.Center.Y);
			base.Projectile.position.X = base.Projectile.position.X + (float)(base.Projectile.width / 2);
			base.Projectile.position.Y = base.Projectile.position.Y + (float)(base.Projectile.height / 2);
			base.Projectile.width = 30;
			base.Projectile.height = 30;
			base.Projectile.position.X = base.Projectile.position.X - (float)(base.Projectile.width / 2);
			base.Projectile.position.Y = base.Projectile.position.Y - (float)(base.Projectile.height / 2);
			for (int i = 0; i < 36; i++)
			{
				int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 55, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num].velocity *= 3f;
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num].scale = 0.5f;
					Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
				}
			}
			for (int j = 0; j < 50; j++)
			{
				int num2 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 244, 0f, 0f, 100, default(Color), 3f);
				Main.dust[num2].noGravity = true;
				Main.dust[num2].velocity *= 5f;
				num2 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 244, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num2].velocity *= 2f;
			}
            if (base.Projectile.owner == Main.myPlayer)
            {
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, 0f, 0f, base.Mod.Find<ModProjectile>("火山爆炸").Type, base.Projectile.damage * 2, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            }
			for (int k = 0; k <= 10; k++)
			{
				float a = (float)Main.rand.Next(0 , 720) / 360 * 3.141592653589793238f;
				float m = (float)Main.rand.Next(0, 50000);
                float l = (float)Main.rand.Next((int)m , 50000) / 1800;
                int num4 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y,(float)((float)l * Math.Cos((float)a)) * 0.36f, (float)((float)l * Math.Sin((float)a)) * 0.36f, base.Mod.Find<ModProjectile>("火山溅射").Type, base.Projectile.damage / 2, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
				Main.projectile[num4].scale =  (float)Main.rand.Next(7000, 13000) / 10000f;
			}
            for (int k = 0; k <= 10; k++)
            {
                Vector2 v = new Vector2(0, 40).RotatedByRandom(Math.PI * 2);
                int num4 = Projectile.NewProjectile(base.Projectile.Center.X + v.X, base.Projectile.Center.Y + v.Y, 0, 0, base.Mod.Find<ModProjectile>("爆炸效果光").Type, base.Projectile.damage, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
            }
        }
	}
}
