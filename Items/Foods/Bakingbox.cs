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
            // base.DisplayName.SetDefault("烤箱");
            // base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			base.Item.width = 40;
            base.Item.height = 28;
            base.Item.rare = 1;
            base.Item.value = Item.sellPrice(0, 0, 5, 0);
			base.Item.UseSound = SoundID.Item8;
            base.Item.maxStack = 200;
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.useStyle = 1;
            base.Item.consumable = true;
            base.Item.useTurn = true;
            base.Item.autoReuse = true;
            base.Item.createTile = base.Mod.Find<ModTile>("烤箱").Type;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(Mod.Find<ModItem>("LavaPipe").Type, 2);
            recipe.AddIngredient(22, 15);
            recipe.AddIngredient(170, 3);
            recipe.requiredTile[0] = 16;
            recipe.Register();
            Recipe recipe2 = CreateRecipe(1);
            recipe2.AddIngredient(Mod.Find<ModItem>("LavaPipe").Type, 2);
            recipe2.AddIngredient(704, 15);
            recipe2.AddIngredient(170, 3);
            recipe2.requiredTile[0] = 16;
            recipe2.Register();
        }
    }
}
