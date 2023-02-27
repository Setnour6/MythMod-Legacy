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
			base.Item.width = 36;
			base.Item.height = 32;
			base.Item.maxStack = 99;
			base.Item.useTurn = true;
			base.Item.autoReuse = true;
			base.Item.useAnimation = 15;
			base.Item.useTime = 10;
			base.Item.useStyle = 1;
			base.Item.consumable = true;
			base.Item.value = 0;
			base.Item.createTile = base.Mod.Find<ModTile>("TangerineChandelier").Type;
		}
	}
}
