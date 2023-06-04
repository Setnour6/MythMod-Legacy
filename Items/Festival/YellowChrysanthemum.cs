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
            // base.DisplayName.SetDefault("黄菊");
            // base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			base.Item.width = 48;
            base.Item.height = 48;
            base.Item.rare = 2;
            base.Item.value = Item.sellPrice(0, 0, 15, 0);
            base.Item.UseSound = SoundID.Item8;
            base.Item.maxStack = 200;
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.useStyle = 1;
            base.Item.consumable = true;
            base.Item.useTurn = true;
            base.Item.autoReuse = true;
            base.Item.createTile = base.Mod.Find<ModTile>("黄菊").Type;
        }
	}
}
