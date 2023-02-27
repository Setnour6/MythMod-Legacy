using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
    // Token: 0x0200034A RID: 842
    public class RedDustBar : ModItem
    {
        // Token: 0x06000D75 RID: 3445 RVA: 0x0006A410 File Offset: 0x00068610
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Firesand Bar");
            base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "火沙锭");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "红尘漫天,风沙肆虐");
        }

        // Token: 0x06000D76 RID: 3446 RVA: 0x0006A468 File Offset: 0x00068668
        public override void SetDefaults()
        {
            base.item.width = 20;
            base.item.height = 20;
            base.item.maxStack = 999;
            base.item.value = Item.sellPrice(0, 4, 33, 33);
            base.item.rare = 11;
            base.item.autoReuse = true;
            base.item.useAnimation = 15;
            base.item.useTime = 10;
            base.item.useStyle = 1;
            base.item.consumable = true;
            base.item.createTile = base.mod.TileType("Bars");
            base.item.placeStyle = 3;
        }
    }
}