using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Terraria;
namespace MythMod.Items.Festival//制作是mod名字
{
    public class Mooncake : ModItem//材料是物品名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("未知月饼");//教程是物品介绍
            base.Tooltip.AddTranslation(GameCulture.Chinese, "切开后是什么馅的呢?");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            base.item.width = 18;//宽
            base.item.height = 16;//高
            base.item.rare = 8;//品质
            base.item.scale = 1f;//大小
            base.item.createTile = base.mod.TileType("月饼");
            base.item.useStyle = 1;
            base.item.useTurn = true;
            base.item.useAnimation = 15;
            base.item.useTime = 10;
            base.item.autoReuse = true;
            base.item.consumable = true;
            base.item.maxStack = 999;
            base.item.value = 20000;
        }
        public override void AddRecipes()
        {
            //ModRecipe recipe = new ModRecipe(mod);
            //recipe.AddIngredient(null, "月饼", 1); //需要一个材料
            //recipe.requiredTile[0] = 18;
            //recipe.SetResult(mod.ItemType("五仁月饼"), 2); //制作一个武器
            //recipe.AddRecipe();
            //ModRecipe recipe2 = new ModRecipe(mod);
            //recipe2.AddIngredient(null, "月饼", 1); //需要一个材料
            //recipe2.requiredTile[0] = 18;
            //recipe2.SetResult(mod.ItemType("豆沙月饼"), 2); //制作一个武器
            //recipe2.AddRecipe();
            //ModRecipe recipe3 = new ModRecipe(mod);
            //recipe3.AddIngredient(null, "月饼", 1); //需要一个材料
            //recipe3.requiredTile[0] = 18;
            //recipe3.SetResult(mod.ItemType("蛋黄莲蓉月饼"), 2); //制作一个武器
            //recipe3.AddRecipe();
        }
    }
}
