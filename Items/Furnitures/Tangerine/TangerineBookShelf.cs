using System;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MythMod.Items.Furnitures.Tangerine
{
	public class TangerineBookShelf : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("TangerineBookShelf");
            DisplayName.AddTranslation(GameCulture.Chinese, "年桔木书架");
        }
		public override void SetDefaults()
		{
			base.item.width = 28;
			base.item.height = 20;
			base.item.maxStack = 999;
			base.item.useTurn = true;
			base.item.autoReuse = true;
			base.item.useAnimation = 15;
			base.item.useTime = 10;
			base.item.useStyle = 1;
			base.item.consumable = true;
			base.item.value = 1000;
			base.item.createTile = base.mod.TileType("TangerineBookShelf");
		}
	}
}
