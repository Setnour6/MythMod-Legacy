using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Festival
{
    public class YellowChrysanthemum : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("黄菊");
            base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			base.item.width = 48;
            base.item.height = 48;
            base.item.rare = 2;
            base.item.value = Item.sellPrice(0, 0, 15, 0);
            base.item.UseSound = SoundID.Item8;
            base.item.maxStack = 200;
            base.item.useAnimation = 15;
            base.item.useTime = 10;
            base.item.useStyle = 1;
            base.item.consumable = true;
            base.item.useTurn = true;
            base.item.autoReuse = true;
            base.item.createTile = base.mod.TileType("黄菊");
        }
	}
}
