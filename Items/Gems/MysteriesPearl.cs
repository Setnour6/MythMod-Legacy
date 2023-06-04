using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
namespace MythMod.Items.Gems
{
    public class MysteriesPearl : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("这奇怪的颜色,看上去似乎有些特别的作用……");
            // DisplayName.SetDefault("MysteriesPearl");
            DisplayName.AddTranslation(GameCulture.Chinese, "神秘宝珠");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.rare = 4;
            Item.scale = 1f;
            Item.value = 20000;
            Item.maxStack = 999;
            Item.useTime = 14;
        }
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(null, "MysteriesBroken", 3);
            modRecipe.requiredTile[0] = 134;
            modRecipe.Register();
        }
    }
}
