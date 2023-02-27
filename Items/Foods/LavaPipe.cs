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
            base.DisplayName.SetDefault("熔岩加热管");
            base.Tooltip.SetDefault("");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.width = 22;
            base.item.height = 38;
            base.item.rare = 8;
			base.item.useAnimation = 30;
			base.item.useTime = 20;
			base.item.useStyle = 2;
			base.item.UseSound = SoundID.Item8;
			base.item.consumable = true;
            base.item.maxStack = 200;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("LavaCrystal"), 5);
            recipe.AddIngredient(22, 2);
            recipe.requiredTile[0] = 16;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(mod.ItemType("LavaCrystal"), 5);
            recipe2.AddIngredient(704, 2);
            recipe2.requiredTile[0] = 16;
            recipe2.SetResult(this, 1);
            recipe2.AddRecipe();
        }
    }
}
