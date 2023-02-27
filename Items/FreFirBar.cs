using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
    public class FreFirBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("123");
            base.Tooltip.SetDefault("'456'");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "冰火锭");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "'摸起来冷热交集，挺诡异的'");
        }

        public override void SetDefaults()
        {
            base.Item.width = 20;
            base.Item.height = 20;
            base.Item.maxStack = 999;
            base.Item.value = Item.sellPrice(0, 6, 70, 0);
            base.Item.rare = 10;
            base.Item.autoReuse = true;
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.useStyle = 1;
            base.Item.consumable = true;
            base.Item.createTile = base.Mod.Find<ModTile>("Bars").Type;
            base.Item.placeStyle = 5;
        }
    }
}


