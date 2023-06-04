
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
			// base.DisplayName.SetDefault("123");
			// base.Tooltip.SetDefault("'456'");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "沧流锭");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "沧流锭");
		}
		public override void SetDefaults()
		{
			base.Item.width = 20;
			base.Item.height = 20;
			base.Item.maxStack = 999;
			base.Item.value = Item.sellPrice(0, 2, 50, 0);
			base.Item.rare = 10;
			base.Item.autoReuse = true;
			base.Item.useAnimation = 15;
			base.Item.useTime = 10;
			base.Item.useStyle = 1;
			base.Item.consumable = true;
			base.Item.createTile = base.Mod.Find<ModTile>("Bars").Type;
			base.Item.placeStyle = 0;
		}
        public override void AddRecipes()
        {
        }	
    }
}


