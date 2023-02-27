using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class ChocolateSpring : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("巧克力喷泉");
            base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			base.item.width = 26;
            base.item.height = 40;
            base.item.rare = 0;
            base.item.useAnimation = 15;
            base.item.useTime = 10;
            base.item.useStyle = 1;
            base.item.consumable = true;
            base.item.useTurn = true;
            base.item.autoReuse = true;
            base.item.createTile = base.mod.TileType("ChocolateSpring");
            base.item.UseSound = SoundID.Item8;
			base.item.consumable = true;
            base.item.maxStack = 200;
		}
    }
}
