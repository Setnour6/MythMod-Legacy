using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
    public class IridiumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Iridium Bar");
            base.Tooltip.SetDefault("''");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "铱金锭");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "'过度锋利'");
        }
        public override void SetDefaults()
        {
            base.item.width = 20;
            base.item.height = 20;
            base.item.maxStack = 999;
            base.item.value = Item.sellPrice(0, 5, 10, 00);
            base.item.rare = 11;
            base.item.autoReuse = true;
            base.item.useAnimation = 15;
            base.item.useTime = 10;
            base.item.useStyle = 1;
            base.item.consumable = true;
            base.item.createTile = base.mod.TileType("Bars");
            base.item.placeStyle = 4;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "IridiumBar", 8);
            recipe.requiredTile[0] = 412;
            recipe.SetResult(mod.ItemType("IridiumSword"), 1);
            recipe.AddRecipe();
        }
    }
}