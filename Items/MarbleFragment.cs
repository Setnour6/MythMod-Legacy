using System;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
    public class MarbleFragment : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("MarbleFragment");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "碎片堆");
		}
		public override void SetDefaults()
		{
			base.item.width = 70;
			base.item.height = 30;
			base.item.maxStack = 99;
			base.item.useTurn = true;
			base.item.autoReuse = true;
            item.rare = 4;
            base.item.useAnimation = 15;
			base.item.useTime = 10;
			base.item.useStyle = 1;
			base.item.consumable = true;
			base.item.value = 500;
            base.item.createTile = base.mod.TileType("MarbleFragment");
		}
	}
}
