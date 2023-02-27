using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class StrawberryIcecream : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("草莓雪糕");
            base.Tooltip.SetDefault("看样子很好吃");
		}
		public override void SetDefaults()
		{
            base.item.width = 28;
            base.item.height = 48;
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
            base.item.createTile = base.mod.TileType("草莓雪糕");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Strawberry", 4);
            recipe.AddIngredient(949, 15);
            recipe.requiredTile[0] = 306;
            recipe.SetResult(mod.ItemType("StrawberryIcecream"), 1);
            recipe.AddRecipe();
        }
	}
}
