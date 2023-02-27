using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class BakedOyster : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("炭烧生蚝");
            base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			base.item.width = 38;
            base.item.height = 28;
            base.item.rare = 0;
			base.item.useAnimation = 30;
			base.item.useTime = 20;
			base.item.useStyle = 1;
			base.item.UseSound = SoundID.Item8;
			base.item.consumable = true;
            base.item.maxStack = 200;
            base.item.createTile = base.mod.TileType("炭烧生蚝");
        }
        public override void AddRecipes()
        {
        }
	}
}
