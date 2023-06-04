using System;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
    public class DukChest2 : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("宝藏箱");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "宝藏箱");
		}
		public override void SetDefaults()
		{
			base.Item.width = 22;
			base.Item.height = 22;
			base.Item.maxStack = 99;
			base.Item.useTurn = true;
			base.Item.autoReuse = true;
			base.Item.useAnimation = 15;
			base.Item.useTime = 10;
			base.Item.useStyle = 1;
			base.Item.consumable = true;
			base.Item.value = 500;
            base.Item.createTile = base.Mod.Find<ModTile>("Duk宝藏箱2").Type;
		}
	}
}
