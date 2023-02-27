using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class wineGlass : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("一杯红酒");
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
            base.item.consumable = true;
            base.item.useTurn = true;
            base.item.autoReuse = true;
            base.item.createTile = base.mod.TileType("一杯红酒");
            base.item.UseSound = SoundID.Item8;
			base.item.consumable = true;
            base.item.maxStack = 200;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(2244, 1);
            recipe.requiredTile[0] = mod.TileType("红酒");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
