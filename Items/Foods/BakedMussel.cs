using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class BakedMussel : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("炭烧青口");
            base.Tooltip.SetDefault("看样子很好吃");
		}
		public override void SetDefaults()
		{
			base.item.width = 34;
            base.item.height = 30;
            base.item.rare = 0;
			base.item.useAnimation = 30;
			base.item.useTime = 20;
			base.item.useStyle = 1;
			base.item.UseSound = SoundID.Item8;
			base.item.consumable = true;
            base.item.maxStack = 200;
            base.item.createTile = base.mod.TileType("炭烧青口");
        }
        public override void AddRecipes()
        {
        }
	}
}
