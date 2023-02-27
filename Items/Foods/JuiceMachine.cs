using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class JuiceMachine : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("榨汁机");
            base.Tooltip.SetDefault("");
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
            base.item.createTile = base.mod.TileType("榨汁机");
        }
        public override void AddRecipes()
        {
        }
	}
}
