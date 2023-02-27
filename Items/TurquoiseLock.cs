﻿using System;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
	public class TurquoiseLock : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Turquoise Gem Lock");
			base.Tooltip.SetDefault("Right click to place or remove Large Turquoises");
			base.DisplayName.AddTranslation(GameCulture.English, "绿松石宝石锁");
			base.Tooltip.AddTranslation(GameCulture.English, "右键镶嵌或取下大绿松石锁");
		}
		public override void SetDefaults()
		{
			base.Item.width = 26;
			base.Item.height = 26;
			base.Item.maxStack = 99;
			base.Item.useTurn = true;
			base.Item.autoReuse = true;
			base.Item.useAnimation = 14;
			base.Item.useTime = 10;
			base.Item.useStyle = 1;
			base.Item.consumable = true;
			base.Item.createTile = base.Mod.Find<ModTile>("Turquoise").Type;
			base.Item.flame = true;
			base.Item.value = 500;
		}
	}
}
