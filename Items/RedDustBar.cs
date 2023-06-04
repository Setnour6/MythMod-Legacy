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
            // base.DisplayName.SetDefault("Firesand Bar");
            // base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "火沙锭");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "红尘漫天,风沙肆虐");
        }

        // Token: 0x06000D76 RID: 3446 RVA: 0x0006A468 File Offset: 0x00068668
        public override void SetDefaults()
        {
            base.Item.width = 20;
            base.Item.height = 20;
            base.Item.maxStack = 999;
            base.Item.value = Item.sellPrice(0, 4, 33, 33);
            base.Item.rare = 11;
            base.Item.autoReuse = true;
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.useStyle = 1;
            base.Item.consumable = true;
            base.Item.createTile = base.Mod.Find<ModTile>("Bars").Type;
            base.Item.placeStyle = 3;
        }
    }
}