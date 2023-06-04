using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class LavaPipe : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("熔岩加热管");
            // base.Tooltip.SetDefault("");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.width = 22;
            base.Item.height = 38;
            base.Item.rare = 8;
			base.Item.useAnimation = 30;
			base.Item.useTime = 20;
			base.Item.useStyle = 2;
			base.Item.UseSound = SoundID.Item8;
			base.Item.consumable = true;
            base.Item.maxStack = 200;
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(Mod.Find<ModItem>("LavaCrystal").Type, 5);
            recipe.AddIngredient(22, 2);
            recipe.requiredTile[0] = 16;
            recipe.Register();
            Recipe recipe2 = CreateRecipe(1);
            recipe2.AddIngredient(Mod.Find<ModItem>("LavaCrystal").Type, 5);
            recipe2.AddIngredient(704, 2);
            recipe2.requiredTile[0] = 16;
            recipe2.Register();
        }
    }
}
