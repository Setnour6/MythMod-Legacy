using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class BakeDurian : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("烤榴莲");
            base.Tooltip.SetDefault("看样子很好吃,至于闻起来……");
		}
		public override void SetDefaults()
		{
			base.item.width = 46;
            base.item.height = 38;
            base.item.rare = 5;
			base.item.useAnimation = 20;
			base.item.useTime = 20;
			base.item.useStyle = 1;
			base.item.UseSound = SoundID.Item8;
			base.item.consumable = true;
            base.item.maxStack = 200;
            base.item.autoReuse = true;
            base.item.createTile = base.mod.TileType("烤榴莲");
        }
        public override void AddRecipes()
        {
        }
	}
}
