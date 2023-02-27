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
            Tooltip.SetDefault("来自海洋");
            DisplayName.AddTranslation(GameCulture.Chinese, "沧流矿");
        }
        public override void SetDefaults()
        {
            base.item.width = 40;
            base.item.height = 40;
            base.item.rare = 8;
            base.item.scale = 1f;
            base.item.createTile = base.mod.TileType("沧流矿");
            base.item.useStyle = 1;
            base.item.useTurn = true;
            base.item.useAnimation = 15;
            base.item.useTime = 10;
            base.item.autoReuse = true;
            base.item.consumable = true;
            base.item.width = 13;
            base.item.height = 10;
            base.item.maxStack = 999;
            base.item.value = 3750;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "OceanBlueOre", 3);
            recipe.requiredTile[0] = 412;
            recipe.SetResult(mod.ItemType("OceanBlueBar"), 1);
            recipe.AddRecipe();
        }
    }
}
