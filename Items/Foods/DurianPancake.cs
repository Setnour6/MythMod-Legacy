using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class DurianPancake : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("榴莲班戟");
            base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			base.item.width = 28;
            base.item.height = 16;
            base.item.rare = 5;
			base.item.useAnimation = 20;
			base.item.useTime = 20;
			base.item.useStyle = 1;
			base.item.UseSound = SoundID.Item8;
			base.item.consumable = true;
            base.item.maxStack = 200;
            base.item.autoReuse = true;
            base.item.createTile = base.mod.TileType("榴莲班戟");
        }
        public override void AddRecipes()
        {
        }
	}
}
