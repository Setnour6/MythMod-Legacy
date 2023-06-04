using System;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MythMod.Items.Furnitures.Tangerine
{
	public class TangerineBookShelf : ModItem
	{
		public override void SetStaticDefaults()
		{
            // DisplayName.SetDefault("TangerineBookShelf");
            DisplayName.AddTranslation(GameCulture.Chinese, "年桔木书架");
        }
		public override void SetDefaults()
		{
			base.Item.width = 28;
			base.Item.height = 20;
			base.Item.maxStack = 999;
			base.Item.useTurn = true;
			base.Item.autoReuse = true;
			base.Item.useAnimation = 15;
			base.Item.useTime = 10;
			base.Item.useStyle = 1;
			base.Item.consumable = true;
			base.Item.value = 1000;
			base.Item.createTile = base.Mod.Find<ModTile>("TangerineBookShelf").Type;
		}
	}
}
