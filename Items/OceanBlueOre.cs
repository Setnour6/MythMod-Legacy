using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria;
namespace MythMod.Items
{
    public class OceanBlueOre : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("来自海洋");
            DisplayName.AddTranslation(GameCulture.Chinese, "沧流矿");
        }
        public override void SetDefaults()
        {
            base.Item.width = 40;
            base.Item.height = 40;
            base.Item.rare = 8;
            base.Item.scale = 1f;
            base.Item.createTile = base.Mod.Find<ModTile>("沧流矿").Type;
            base.Item.useStyle = 1;
            base.Item.useTurn = true;
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.autoReuse = true;
            base.Item.consumable = true;
            base.Item.width = 13;
            base.Item.height = 10;
            base.Item.maxStack = 999;
            base.Item.value = 3750;
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Mod.Find<ModItem>("OceanBlueBar").Type, 1);
            recipe.AddIngredient(null, "OceanBlueOre", 3);
            recipe.requiredTile[0] = 412;
            recipe.Register();
        }
    }
}
