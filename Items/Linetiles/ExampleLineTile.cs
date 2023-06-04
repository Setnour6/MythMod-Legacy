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
            // Tooltip.SetDefault("这个……ta出了点问题,总之,别用, 会坏哒！");
            base.SetStaticDefaults();
            // DisplayName.SetDefault("悬链测试");
        }
        public override void SetDefaults()
		{
			Item.width = 10;
			Item.height = 12;
			Item.maxStack = 99;
			Item.holdStyle = 1;
			Item.noWet = true;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.createTile = Mod.Find<ModTile>("ExampleLineTile").Type;
			Item.flame = true;
			Item.value = 50;
		}
	}
}