﻿using System;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MythMod.Items.Furnitures.Tangerine
{
	public class TangerineLamp : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TangerineLamp");
            DisplayName.AddTranslation(GameCulture.Chinese, "年桔木灯");
        }
        public override void SetDefaults()
		{
			base.item.width = 16;
			base.item.height = 38;
			base.item.maxStack = 99;
			base.item.useTurn = true;
			base.item.autoReuse = true;
			base.item.useAnimation = 15;
			base.item.useTime = 10;
			base.item.useStyle = 1;
			base.item.consumable = true;
			base.item.value = 1000;
			base.item.createTile = base.mod.TileType("TangerineLamp");
		}
	}
}
