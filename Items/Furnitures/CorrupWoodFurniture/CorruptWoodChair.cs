using System;
using Terraria.ModLoader;

namespace MythMod.Items.Furnitures.CorrupWoodFurniture
{
	public class CorruptWoodChair : ModItem
	{
        public override void SetStaticDefaults()
        {
        }
		public override void SetDefaults()
		{
			base.item.width = 12;
			base.item.height = 30;
			base.item.maxStack = 99;
			base.item.useTurn = true;
			base.item.autoReuse = true;
			base.item.useAnimation = 15;
			base.item.useTime = 10;
			base.item.useStyle = 1;
			base.item.consumable = true;
			base.item.value = 0;
			base.item.createTile = base.mod.TileType("CorruptWoodChair");
		}
	}
}
