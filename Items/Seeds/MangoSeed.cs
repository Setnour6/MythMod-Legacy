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
			base.Item.useTurn = true;
			base.Item.autoReuse = true;
			base.Item.useStyle = 1;
			base.Item.useAnimation = 15;
			base.Item.useTime = 10;
			base.Item.maxStack = 99;
			base.Item.consumable = true;
			base.Item.placeStyle = 0;
			base.Item.width = 14;
			base.Item.height = 14;
			base.Item.value = 100;
            base.Item.createTile = base.Mod.Find<ModTile>("芒果树").Type;
		}
	}
}
