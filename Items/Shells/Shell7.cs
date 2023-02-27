﻿using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Shells
{
    public class Shell7 : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("女王凤凰螺");
            base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
			base.Item.width = 54;
			base.Item.height = 66;
            base.Item.maxStack = 999;
            base.Item.rare = 8;
            base.Item.value = Item.sellPrice(0, 1, 50, 0);
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.useStyle = 1;
            base.Item.consumable = true;
            base.Item.useTurn = true;
            base.Item.autoReuse = true;
            base.Item.createTile = base.Mod.Find<ModTile>("女王凤凰螺").Type;
        }
	}
}
