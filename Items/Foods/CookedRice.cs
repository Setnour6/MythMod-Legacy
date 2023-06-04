using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class CookedRice : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("饭");
            // base.Tooltip.SetDefault("看样子很好吃");
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
            base.Item.createTile = base.Mod.Find<ModTile>("饭").Type;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(2);
            recipe.AddIngredient(null, "Rice", 1);
            recipe.AddIngredient(356, 1);
            recipe.requiredTile[0] = 96;
            recipe.Register();
        }
	}
}
