﻿using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods.Drinks
{
    public class B25Drink : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("B-25轰炸机");
            Tooltip.SetDefault("喝下去才知道效果");
        }
		public override void SetDefaults()
		{
			item.width = 14;
            item.height = 26;
            item.rare = 5;
            item.useAnimation = 15;
            item.value = 50000;
            item.useTurn = true;
            item.consumable = true;
            item.maxStack = 30;
            base.item.useAnimation = 17;
            base.item.useTime = 17;
            base.item.useStyle = 2;
            base.item.UseSound = SoundID.Item3;
            item.buffType = mod.BuffType("B25");
            item.buffTime = 14400;
        }
        public override bool CanUseItem(Player player)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (!player.HasBuff(mod.BuffType("B25")))
            {
                player.AddBuff(base.mod.BuffType("B25"), 14400, true);
                item.stack--;
            }
            return player.HasBuff(mod.BuffType("B25"));
        }
        public override void HoldItem(Player player)
        {
            if (Main.mouseRight)
            {
                item.createTile = base.mod.TileType("B25");
                item.buffType = -1;
                item.buffTime = 0;
                item.useStyle = 1;
            }
            else
            {
                item.createTile = -1;
                item.useStyle = 2;
                item.UseSound = SoundID.Item3;
                item.buffType = mod.BuffType("B25");
                item.buffTime = 14400;
            }
            base.HoldItem(player);
        }
    }
}
