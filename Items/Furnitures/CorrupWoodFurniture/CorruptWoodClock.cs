using System;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Items.Furnitures.CorrupWoodFurniture
{
	public class CorruptWoodClock : ModItem
	{
		public override void SetStaticDefaults()
		{
		}
		public override void SetDefaults()
		{
			base.Item.width = 26;
			base.Item.height = 22;
			base.Item.maxStack = 99;
			base.Item.useTurn = true;
			base.Item.autoReuse = true;
			base.Item.useAnimation = 15;
			base.Item.useTime = 10;
			base.Item.useStyle = 1;
			base.Item.consumable = true;
			base.Item.value = 0;
			base.Item.createTile = base.Mod.Find<ModTile>("CorruptWoodClock").Type;
		}
		public override void AddRecipes()
		{
			Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
			modRecipe.AddIngredient(22, 3);
			modRecipe.anyIronBar = true;
			modRecipe.AddIngredient(170, 6);
			modRecipe.AddIngredient(null, "WornWood", 10);
			modRecipe.AddTile(16);
			modRecipe.Register();
		}
	}
}
