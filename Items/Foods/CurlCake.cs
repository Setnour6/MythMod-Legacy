﻿using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
    public class CurlCake : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("长条蛋糕");
            // base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
            base.Item.width = 26;
            base.Item.height = 40;
            base.Item.rare = 0;
            base.Item.useAnimation = 15;
            base.Item.useTime = 10;
            base.Item.useStyle = 1;
            base.Item.consumable = true;
            base.Item.useTurn = true;
            base.Item.autoReuse = true;
            base.Item.createTile = base.Mod.Find<ModTile>("CurlCake").Type;
            base.Item.UseSound = SoundID.Item8;
            base.Item.consumable = true;
            base.Item.maxStack = 200;
        }
	}
}
