using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class SalmonSushi : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("三文鱼寿司");
            base.Tooltip.SetDefault("看样子很好吃");
		}
		public override void SetDefaults()
		{
            base.item.width = 40;
            base.item.height = 28;
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
            base.item.createTile = base.mod.TileType("三文鱼寿司");
        }
        public override bool UseItem(Player player)
        {
            MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            if (player.itemAnimation > 0 && player.itemTime == 0)
            {
                player.itemTime = base.item.useTime;
                modPlayer.YangLife += 2;
                player.statLife += 100;
            }
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CookedRice", 1);
            recipe.AddIngredient(2427, 1);
            recipe.requiredTile[0] = 18;
            recipe.SetResult(mod.ItemType("SalmonSushi"), 1);
            recipe.AddRecipe();
        }
    }
}
