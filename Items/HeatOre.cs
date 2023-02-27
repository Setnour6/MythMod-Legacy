using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items//制作是mod名字
{
    public class HeatOre : ModItem//材料是物品名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("烈日炙烤的凝聚");//教程是物品介绍
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            item.width = 40;//宽
            item.height = 40;//高
            item.rare = 24;//品质
            item.scale = 1f;//大小
            item.value = 8500;
            item.maxStack = 999;
            item.useTime = 14;
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "HeatOre", 2); //需要一个材料
            recipe.AddIngredient(null, "CyanFreezeOre", 2); //需要一个材料
            recipe.requiredTile[0] = 412;
            recipe.SetResult(mod.ItemType("FreFirBar"), 1); //制作一个武器
            recipe.AddRecipe();
        }
    }
}
