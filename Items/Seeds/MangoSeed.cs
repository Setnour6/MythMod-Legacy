using System;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Seeds
{
	public class MangoSeed : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("芒果种子");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "芒果种子");
		}
		public override void SetDefaults()
		{
			base.item.useTurn = true;
			base.item.autoReuse = true;
			base.item.useStyle = 1;
			base.item.useAnimation = 15;
			base.item.useTime = 10;
			base.item.maxStack = 99;
			base.item.consumable = true;
			base.item.placeStyle = 0;
			base.item.width = 14;
			base.item.height = 14;
			base.item.value = 100;
            base.item.createTile = base.mod.TileType("芒果树");
		}
	}
}
