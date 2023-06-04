using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class EggFriedRice : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("蛋炒饭");
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
            base.Item.createTile = base.Mod.Find<ModTile>("蛋炒饭").Type;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(null, "CookedRice", 1);
            recipe.AddIngredient(null, "Egg", 1);
            recipe.requiredTile[0] = Mod.Find<ModTile>("爆炒锅").Type;
            recipe.Register();
        }
	}
}
