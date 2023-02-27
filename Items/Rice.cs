using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items//制作是mod名字
{
    public class Rice : ModItem//材料是物品名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("");//教程是物品介绍
            DisplayName.AddTranslation(GameCulture.Chinese, "米饭");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            base.Item.useStyle = 1;
			base.Item.useTurn = true;
            Item.width = 56;//宽
            Item.height = 38;//高
            Item.rare = 2;//品质
            Item.scale = 1f;//大小
            Item.value = 100;
            Item.maxStack = 999;
        }
    }
}
