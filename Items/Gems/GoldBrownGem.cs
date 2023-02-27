using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria;
namespace MythMod.Items.Gems
{
    public class GoldBrownGem : ModItem//材料是物品名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");
            DisplayName.AddTranslation(GameCulture.Chinese, "金红宝石");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            item.width = 16;//宽
            item.height = 14;//高
            item.rare = 1;//品质
            item.scale = 1f;//大小
            item.value = 10500;
            item.maxStack = 999;
            item.useTime = 14;
        }
    }
}
