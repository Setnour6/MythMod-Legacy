using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items//�0�10��0�0�10�6�04�0�3�0�9�0�3�0�0�0�10�6�08�0�10�6�05mod�0�10�6�01�0�10�6�84�0�3�0�9�0�10��0
{
    public class MoonMossOre : ModItem//�0�10��5�0�10�6�02�0�10�6�99�0�10�0�33�0�10�6�08�0�10�6�05�0�10�0�32�0�10�0�77�0�10�6�04�0�3��0�10�6�01�0�10�6�84�0�10��6�0�10�6�04
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("�0�10�6�96�0�3���0�10�0�39�0�10�0�75�0�10�0�30�0�10�6�77�0�10��7�0�10�6�92�0�10�6�75�0�10�6�97�0�10�0�30�0�10��0�0�10�6�01�0�10�6�98�0�10�6�99�0�10�6�09");//�0�10�6�95�0�10�0�30�0�10��6�0�10�0�30�0�10�6�08�0�10�6�05�0�10�0�32�0�10�0�77�0�10�6�04�0�3��0�10�6�95���0�7�0�10�6�07�0�10��5
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            Item.width = 40;//�0�10�6�97���0�9
            Item.height = 40;//�0�10�6�90�0�10��8
            Item.rare = 24;//�0�10�6�04�0�3��0�10��0�0�10�6�08
            Item.scale = 1f;//�0�10��7���0�3�0�10�0�34�0�10�6�73
            Item.value = 4500;
            Item.maxStack = 999;
            Item.useTime = 14;
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void AddRecipes()
        {
                    Recipe recipe = Recipe.Create(Mod.Find<ModItem>("MoonMossBar").Type, 1);//�0�10��0�0�10�6�04�0�3�0�9�0�3�0�0�0�10�0�36�0�10�6�93�0�10�6�90�0�10�6�82�0�10�0�32�0�10�0�71�0�10�6�04�0�3�0�0
                    recipe.AddIngredient(null, "MoonMossOre", 3); //�0�10�0�34�����0�10�0�36�0�10�6�79�0�10�0�36�0�10�6�93�0�10�6�90�0�10�6�82�0�10��5�0�10�6�02�0�10�6�99�0�10�0�33
                    recipe.requiredTile[0] = 412;
                    recipe.Register();
        }
    }
}
