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
			base.Item.width = 26;
            base.Item.height = 40;
            base.Item.rare = 0;
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.useStyle = 1;
            base.Item.consumable = true;
            base.Item.useTurn = true;
            base.Item.autoReuse = true;
            base.Item.createTile = base.Mod.Find<ModTile>("一杯红酒").Type;
            base.Item.UseSound = SoundID.Item8;
			base.Item.consumable = true;
            base.Item.maxStack = 200;
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(2244, 1);
            recipe.requiredTile[0] = Mod.Find<ModTile>("红酒").Type;
            recipe.Register();
        }
	}
}
