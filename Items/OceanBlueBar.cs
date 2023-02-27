
using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
    public class OceanBlueBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("123");
			base.Tooltip.SetDefault("'456'");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "沧流锭");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "沧流锭");
		}
		public override void SetDefaults()
		{
			base.item.width = 20;
			base.item.height = 20;
			base.item.maxStack = 999;
			base.item.value = Item.sellPrice(0, 2, 50, 0);
			base.item.rare = 10;
			base.item.autoReuse = true;
			base.item.useAnimation = 15;
			base.item.useTime = 10;
			base.item.useStyle = 1;
			base.item.consumable = true;
			base.item.createTile = base.mod.TileType("Bars");
			base.item.placeStyle = 0;
		}
        public override void AddRecipes()
        {
        }	
    }
}


