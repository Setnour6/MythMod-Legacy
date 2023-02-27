using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class FIsheggSushi : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("鱼子酱寿司");
            base.Tooltip.SetDefault("看样子很好吃");
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
            base.Item.createTile = base.Mod.Find<ModTile>("鱼子酱寿司").Type;
        }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(Mod.Find<ModItem>("FIsheggSushi").Type, 1);
            recipe.AddIngredient(null, "CookedRice", 1);
            recipe.AddIngredient(null, "FIshegg", 1);
            recipe.requiredTile[0] = 18;
            recipe.Register();
        }
	}
}
