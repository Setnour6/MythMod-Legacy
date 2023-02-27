
using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
    // Token: 0x02000719 RID: 1817
    public class PoisonFlameBar : ModItem
    {
        // Token: 0x06001FC4 RID: 8132 RVA: 0x000C4C50 File Offset: 0x000C2E50
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("");
            base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "毒焰锭");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "粘稠毒气与冥火闪电的完美结合");
        }

        // Token: 0x06001FC5 RID: 8133 RVA: 0x000C4CA8 File Offset: 0x000C2EA8
        public override void SetDefaults()
        {
            base.Item.width = 20;
            base.Item.height = 20;
            base.Item.maxStack = 999;
            base.Item.value = Item.sellPrice(0, 8, 0, 0);
            base.Item.rare = 10;
            base.Item.autoReuse = true;
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.useStyle = 1;
            base.Item.consumable = true;
            base.Item.createTile = base.Mod.Find<ModTile>("Bars").Type;
            base.Item.placeStyle = 6;
        }
    }
}


