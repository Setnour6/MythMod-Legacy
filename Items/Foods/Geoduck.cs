﻿using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class Geoduck : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("北极贝");
            base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
            base.item.width = 36;
            base.item.height = 38;
            base.item.rare = 1;
            base.item.value = Item.sellPrice(0, 5, 50, 0);
            base.item.UseSound = SoundID.Item8;
            base.item.maxStack = 200;
        }
	}
}