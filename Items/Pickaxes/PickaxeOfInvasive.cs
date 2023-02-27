﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Pickaxes
{
    public class PickaxeOfInvasive : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("海蚀镐");
			base.Tooltip.SetDefault("brush!");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "海蚀镐");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "像海潮一样，冲刷，销蚀");
		}
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "OceanBlueBar", 20);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
        public override void SetDefaults()
		{
			base.item.damage = 70;
			base.item.melee = true;
			base.item.width = 34;
			base.item.height = 34;
			base.item.useTime = 5;
			base.item.useAnimation = 12;
			base.item.useTurn = true;
			base.item.pick = 240;
			base.item.useStyle = 1;
			base.item.knockBack = 9f;
			base.item.value = 40000;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.tileBoost += 4;
            base.item.rare = 8;
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				int num = Main.rand.Next(3);
				if (num == 0)
				{
					num = 33;
				}
				else if (num == 1)
				{
					num = 56;
				}
				else
				{
					num = 277;
				}
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, num, 0f, 0f, 0, default(Color), 1f);
			}
		}
	}
}
