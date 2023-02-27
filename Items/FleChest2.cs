﻿using System;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
    public class FleChest2 : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("Fle宝藏箱2");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "宝藏箱");
		}
		public override void SetDefaults()
		{
			base.item.width = 22;
			base.item.height = 22;
			base.item.maxStack = 99;
			base.item.useTurn = true;
			base.item.autoReuse = true;
			base.item.useAnimation = 15;
			base.item.useTime = 10;
			base.item.useStyle = 1;
			base.item.consumable = true;
			base.item.value = 500;
            base.item.createTile = base.mod.TileType("Fle宝藏箱2");
		}
	}
}
