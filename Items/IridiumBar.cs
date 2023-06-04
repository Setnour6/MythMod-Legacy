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
            // base.DisplayName.SetDefault("Iridium Bar");
            // base.Tooltip.SetDefault("''");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "铱金锭");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "'过度锋利'");
        }
        public override void SetDefaults()
        {
            base.Item.width = 20;
            base.Item.height = 20;
            base.Item.maxStack = 999;
            base.Item.value = Item.sellPrice(0, 5, 10, 00);
            base.Item.rare = 11;
            base.Item.autoReuse = true;
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.useStyle = 1;
            base.Item.consumable = true;
            base.Item.createTile = base.Mod.Find<ModTile>("Bars").Type;
            base.Item.placeStyle = 4;
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Mod.Find<ModItem>("IridiumSword").Type, 1);
            recipe.AddIngredient(null, "IridiumBar", 8);
            recipe.requiredTile[0] = 412;
            recipe.Register();
        }
    }
}