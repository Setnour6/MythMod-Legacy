﻿using System;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace MythMod.Items.Walls
{
    public class DarkGarnetBrickWall : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "黯淡石榴石晶莹宝石墙");
		}
		public override void SetDefaults()
		{
			base.item.width = 24;
			base.item.height = 24;
			base.item.maxStack = 999;
			base.item.useTurn = true;
			base.item.autoReuse = true;
			base.item.useAnimation = 15;
			base.item.useTime = 7;
			base.item.useStyle = 1;
			base.item.consumable = true;
            base.item.createWall = base.mod.WallType("黯淡石榴石晶莹宝石墙");
		}
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "GarnetBrick", 1);
			modRecipe.AddTile(18);
			modRecipe.SetResult(this, 4);
			modRecipe.AddRecipe();
            ModRecipe modRecipe2 = new ModRecipe(base.mod);
            modRecipe2.AddIngredient(this, 4);
            modRecipe2.AddTile(18);
            modRecipe2.SetResult(null, "GarnetBrick", 1);
            modRecipe2.AddRecipe();
        }
    }
}
