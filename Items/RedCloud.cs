﻿using System;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
    public class RedCloud : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("fire cloud");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "火烧云");
        }
        public override void SetDefaults()
        {
            base.item.width = 16;
            base.item.height = 16;
            base.item.maxStack = 999;
            base.item.value = 0;
            base.item.rare = 0;
            base.item.useTurn = true;
            base.item.autoReuse = true;
            base.item.useAnimation = 15;
            base.item.useTime = 10;
            base.item.useStyle = 1;
            base.item.consumable = true;
            base.item.createTile = base.mod.TileType("火烧云");
        }
    }
}
