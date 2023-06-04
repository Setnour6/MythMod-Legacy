using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class KiwiJuice : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("猕猴桃汁");
            // base.Tooltip.SetDefault("看样子很好喝");
		}
		public override void SetDefaults()
		{
			base.Item.width = 20;
            base.Item.height = 34;
            base.Item.rare = 0;
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.useStyle = 1;
            base.Item.consumable = true;
            base.Item.useTurn = true;
            base.Item.autoReuse = true;
            base.Item.createTile = base.Mod.Find<ModTile>("猕猴桃汁").Type;
            base.Item.UseSound = SoundID.Item8;
			base.Item.consumable = true;
            base.Item.maxStack = 200;
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(null, "Kiwi", 1);
            recipe.requiredTile[0] = Mod.Find<ModTile>("榨汁机").Type;
            recipe.Register();
        }
    }
}
