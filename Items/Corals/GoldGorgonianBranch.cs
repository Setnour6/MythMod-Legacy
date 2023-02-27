using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Corals//制作是mod名字
{
    public class GoldGorgonianBranch : ModItem//材料是物品名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("金柳珊瑚枝");
            Tooltip.SetDefault("");//教程是物品介绍
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            base.Item.width = 50;//宽
            base.Item.height = 36;//高
            base.Item.rare = 2;//品质
            base.Item.scale = 1f;//大小
            base.Item.maxStack = 999;
            base.Item.value = 3000;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(3);//制作一个武器
            recipe.AddIngredient(null, "GoldGorgonian", 1); //需要一个材料
            recipe.Register();
            Recipe recipe2 = CreateRecipe(5);//制作一个武器
            recipe2.AddIngredient(null, "LargeGoldGorgonian", 1); //需要一个材料
            recipe2.Register();
        }
    }
}
