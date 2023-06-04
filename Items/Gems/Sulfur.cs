using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
namespace MythMod.Items.Gems
{
    public class Sulfur : ModItem//材料是物品名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("来自地狱的结晶");//教程是物品介绍
            // DisplayName.SetDefault("Sulfur");
            DisplayName.AddTranslation(GameCulture.Chinese, "硫磺石");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            base.Item.createTile = base.Mod.Find<ModTile>("硫磺矿").Type;
            base.Item.useStyle = 1;
			base.Item.useTurn = true;
            base.Item.useAnimation = 15;
			base.Item.useTime = 10;
            base.Item.autoReuse = true;
			base.Item.consumable = true;
            Item.width = 32;//宽
            Item.height = 26;//高
            Item.rare = 2;//品质
            Item.scale = 1f;//大小
            Item.value = 6000;
            Item.maxStack = 999;
            Item.useTime = 14;
        }
    }
}
