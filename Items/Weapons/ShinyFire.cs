using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;


namespace MythMod.Items.Weapons
{
    public class ShinyFire : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault(".");
			base.Tooltip.SetDefault(".");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "火树银花");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "让它在夜空中绽放吧!\n威力远远大于普通烟花");
		}
		public override void SetDefaults()
		{
			base.item.damage = 5000;
			base.item.magic = true;
			base.item.mana = 100;
			base.item.width = 28;
			base.item.height = 30;
			base.item.useTime = 48;
			base.item.useAnimation = 48;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 6f;
			base.item.value = 100000;
			base.item.rare = 6;
			base.item.UseSound = SoundID.Item14;
			base.item.autoReuse = true;
			base.item.shoot = base.mod.ProjectileType("焰火");
			base.item.shootSpeed = 2.7f;
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float num = 0.7854f;
			double num2 = Math.Atan2((double)speedX, (double)speedY) - (double)(num / 2f);
			double num3 = (double)(num / 8f);
            for (int i = 0; i < 4; i++)
            {
                double num4 = num2 + num3 * (double)(i + i * i) / 2.0 + (double)(32f * (float)i);
            }
            int num5 = 0;
			for (int j = 0; j < 30; j++)
            {
			int num7 = Main.rand.Next(0, 100000);
			int num8 = Main.rand.Next(0, (int)num7) / 14400;
            int num6 = Dust.NewDust(position, 2, 2, 174, speedX * (float)num8, speedY * (float)num8, 0, Color.Orange, 1.6f);
            Main.dust[num6].noGravity = false;
            Main.dust[num6].scale *=  0.8f;
            Main.dust[num6].alpha = 200;
			}
            Projectile.NewProjectile(position.X, position.Y, speedX * 1.3f + num5, speedY * 1.3f + num5, type, damage, knockBack, Main.myPlayer, 0f, 0f);
			return false;
        }
	}
}
