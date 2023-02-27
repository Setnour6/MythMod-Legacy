using System;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MythMod.Items.Furnitures.Tangerine
{
	public class TangerineChandelier : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("TangerineChandelier");
            DisplayName.AddTranslation(GameCulture.Chinese, "年桔木吊灯");
        }
        public override void SetDefaults()
		{
			base.item.width = 36;
			base.item.height = 32;
			base.item.maxStack = 99;
			base.item.useTurn = true;
			base.item.autoReuse = true;
			base.item.useAnimation = 15;
			base.item.useTime = 10;
			base.item.useStyle = 1;
			base.item.consumable = true;
			base.item.value = 0;
			base.item.createTile = base.mod.TileType("TangerineChandelier");
		}
	}
}
