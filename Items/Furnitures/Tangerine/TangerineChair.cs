using System;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MythMod.Items.Furnitures.Tangerine
{
	public class TangerineChair : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TangerineChair");
            DisplayName.AddTranslation(GameCulture.Chinese, "年桔木椅");
        }
        public override void SetDefaults()
		{
			base.Item.width = 12;
			base.Item.height = 30;
			base.Item.maxStack = 99;
			base.Item.useTurn = true;
			base.Item.autoReuse = true;
			base.Item.useAnimation = 15;
			base.Item.useTime = 10;
			base.Item.useStyle = 1;
			base.Item.consumable = true;
			base.Item.value = 1000;
			base.Item.createTile = base.Mod.Find<ModTile>("TangerineChair").Type;
		}
	}
}
