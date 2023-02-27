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
            base.DisplayName.SetDefault("鸭肉");
            base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			base.item.width = 26;
            base.item.height = 40;
            base.item.rare = 0;
            base.item.useAnimation = 15;
            base.item.useTime = 10;
            base.item.useStyle = 1;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(2123, 1);
            recipe.requiredTile[0] = 16;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(2122, 1);
            recipe2.requiredTile[0] = 16;
            recipe2.SetResult(this, 1);
            recipe2.AddRecipe();
        }
    }
}
