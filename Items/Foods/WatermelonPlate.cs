using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class WatermelonPlate : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("西瓜拼盘");
            base.Tooltip.SetDefault("放在身边获得增益,美味等级I");
		}
		public override void SetDefaults()
		{
			base.item.width = 72;
            base.item.height = 40;
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
            base.item.createTile = base.mod.TileType("西瓜拼盘");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WatermenlonPiece", 4);
            recipe.requiredTile[0] = 220;
            recipe.SetResult(mod.ItemType("WatermelonPlate"), 1);
            recipe.AddRecipe();
        }
	}
}
