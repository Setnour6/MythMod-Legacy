using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items.Corals//制作是mod名字
{
    public class GorgonianPiece : ModItem//材料是物品名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("柳珊瑚片");
            Tooltip.SetDefault("");//教程是物品介绍
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {
            base.item.width = 40;//宽
            base.item.height = 24;//高
            base.item.rare = 2;//品质
            base.item.scale = 1f;//大小
            base.item.maxStack = 999;
            base.item.value = 3000;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Gorgonian", 1); //需要一个材料
            recipe.SetResult(this, 3); //制作一个武器
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(null, "LargeGorgonian", 1); //需要一个材料
            recipe2.SetResult(this, 5); //制作一个武器
            recipe2.AddRecipe();
            ModRecipe recipe3 = new ModRecipe(mod);
            recipe3.AddIngredient(null, "VastGorgonian", 1); //需要一个材料
            recipe3.SetResult(this, 12); //制作一个武器
            recipe3.AddRecipe();
        }
    }
}
