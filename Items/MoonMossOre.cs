using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
namespace MythMod.Items//�0�0�0�4���0�8�0�5mod�0�1�0�4���0�0
{
    public class MoonMossOre : ModItem//�0�5�0�2�0�9�0�3�0�8�0�5�0�2�0�7�0�4���0�1�0�4�0�6�0�4
    {
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("�0�6��0�9�0�5�0�0�0�7�0�7�0�2�0�5�0�7�0�0�0�0�0�1�0�8�0�9�0�9");//�0�5�0�0�0�6�0�0�0�8�0�5�0�2�0�7�0�4���0�5���0�7�0�5
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void SetDefaults()
        {

            Item.width = 40;//�0�7��
            Item.height = 40;//�0�0�0�8
            Item.rare = 24;//�0�4���0�0�0�8
            Item.scale = 1f;//�0�7���0�4�0�3
            Item.value = 4500;
            Item.maxStack = 999;
            Item.useTime = 14;
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void AddRecipes()
        {
                    Recipe recipe = Recipe.Create(Mod.Find<ModItem>("MoonMossBar").Type, 1);//�0�0�0�4���0�6�0�3�0�0�0�2�0�2�0�1�0�4��
                    recipe.AddIngredient(null, "MoonMossOre", 3); //�0�4���0�6�0�9�0�6�0�3�0�0�0�2�0�5�0�2�0�9�0�3
                    recipe.requiredTile[0] = 412;
                    recipe.Register();
        }
    }
}
