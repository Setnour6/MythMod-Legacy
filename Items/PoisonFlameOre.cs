using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items//制作是mod名字
{
    public class PoisonFlameOre : ModItem//材料是物品名称
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("毒与火的千年沉淀");//教程是物品介绍
            DisplayName.AddTranslation(GameCulture.Chinese, "毒焰矿");
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            Item.width = 40;//宽
            Item.height = 40;//高
            Item.rare = 24;//品质
            Item.scale = 1f;//大小
            Item.value = 9400;
            Item.maxStack = 999;
            Item.useTime = 14;
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void AddRecipes()
        {
                    Recipe recipe = Recipe.Create(Mod.Find<ModItem>("PoisonFlameBar").Type, 1);//制作一个武器
                    recipe.AddIngredient(null, "PoisonFlameOre", 4); //需要一个材料
                    recipe.requiredTile[0] = 412;
                    recipe.Register();
        }
    }
}
