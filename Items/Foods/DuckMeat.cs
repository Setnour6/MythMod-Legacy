using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class DuckMeat : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("鸭肉");
            // base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			base.Item.width = 26;
            base.Item.height = 40;
            base.Item.rare = 0;
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.useStyle = 1;
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(2123, 1);
            recipe.requiredTile[0] = 16;
            recipe.Register();
            Recipe recipe2 = CreateRecipe(1);
            recipe2.AddIngredient(2122, 1);
            recipe2.requiredTile[0] = 16;
            recipe2.Register();
        }
    }
}
