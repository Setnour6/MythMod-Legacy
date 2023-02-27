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
            base.Item.width = 36;
            base.Item.height = 38;
            base.Item.rare = 1;
            base.Item.value = Item.sellPrice(0, 5, 50, 0);
            base.Item.UseSound = SoundID.Item8;
            base.Item.maxStack = 200;
        }
	}
}
