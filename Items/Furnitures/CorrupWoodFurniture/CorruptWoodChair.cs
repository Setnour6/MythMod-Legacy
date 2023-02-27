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
			base.Item.width = 12;
			base.Item.height = 30;
			base.Item.maxStack = 99;
			base.Item.useTurn = true;
			base.Item.autoReuse = true;
			base.Item.useAnimation = 15;
			base.Item.useTime = 10;
			base.Item.useStyle = 1;
			base.Item.consumable = true;
			base.Item.value = 0;
			base.Item.createTile = base.Mod.Find<ModTile>("CorruptWoodChair").Type;
		}
	}
}
