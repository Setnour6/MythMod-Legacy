using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class PineappleSeafoodFriedRice : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("菠萝海鲜炒饭");
            base.Tooltip.SetDefault("看样子很好吃");
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
            base.item.createTile = base.mod.TileType("菠萝海鲜炒饭");
        }
        public override void AddRecipes()
        {
        }
	}
}
