using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace MythMod.Items.Linetiles
{
	public class ExampleLineTile : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.AddTranslation(GameCulture.Chinese, "");
            Tooltip.SetDefault("这个……ta出了点问题,总之,别用, 会坏哒！");
            base.SetStaticDefaults();
            DisplayName.SetDefault("悬链测试");
        }
        public override void SetDefaults()
		{
			item.width = 10;
			item.height = 12;
			item.maxStack = 99;
			item.holdStyle = 1;
			item.noWet = true;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("ExampleLineTile");
			item.flame = true;
			item.value = 50;
		}
	}
}