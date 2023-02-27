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
            Tooltip.SetDefault("这奇怪的颜色,看上去似乎有些特别的作用……");
            DisplayName.SetDefault("MysteriesPearl");
            DisplayName.AddTranslation(GameCulture.Chinese, "神秘宝珠");
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.rare = 4;
            item.scale = 1f;
            item.value = 20000;
            item.maxStack = 999;
            item.useTime = 14;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "MysteriesBroken", 3);
            modRecipe.requiredTile[0] = 134;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
