using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class Bakingbox : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("烤箱");
            base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			base.item.width = 40;
            base.item.height = 28;
            base.item.rare = 1;
            base.item.value = Item.sellPrice(0, 0, 5, 0);
			base.item.UseSound = SoundID.Item8;
            base.item.maxStack = 200;
            base.item.useAnimation = 15;
            base.item.useTime = 10;
            base.item.useStyle = 1;
            base.item.consumable = true;
            base.item.useTurn = true;
            base.item.autoReuse = true;
            base.item.createTile = base.mod.TileType("烤箱");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("LavaPipe"), 2);
            recipe.AddIngredient(22, 15);
            recipe.AddIngredient(170, 3);
            recipe.requiredTile[0] = 16;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(mod.ItemType("LavaPipe"), 2);
            recipe2.AddIngredient(704, 15);
            recipe2.AddIngredient(170, 3);
            recipe2.requiredTile[0] = 16;
            recipe2.SetResult(this, 1);
            recipe2.AddRecipe();
        }
    }
}
