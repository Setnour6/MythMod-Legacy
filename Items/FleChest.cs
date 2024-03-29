﻿using System;
using System.Collections.Generic;
using System.IO;
using MythMod.NPCs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace MythMod.Items
{
    public class FleChest : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Treasure Bag");
            base.Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "宝藏箱");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "右键点击打开");
        }
        public override void SetDefaults()
        {
            base.item.maxStack = 1;
            base.item.consumable = false;
            base.item.width = 24;
            base.item.height = 24;
            base.item.rare = 9;
            base.item.expert = true;
            //this.bossBagNPC = 13;
        }
        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            if (Main.rand.Next(2) == 1)
            {
                player.QuickSpawnItem(base.mod.ItemType("SwordWOF"), 1);
            }
            player.QuickSpawnItem(base.mod.ItemType("FleChest2"), 1);
            player.QuickSpawnItem(base.mod.ItemType("BloodHeartStone"), 1);
            player.QuickSpawnItem(base.mod.ItemType("UnstableTranspStaff"), 1);
            if (Main.rand.Next(20) == 1)
            {
                player.QuickSpawnItem(base.mod.ItemType("BloodGoldBlade"), 1);
            }
            item.stack--;
        }
    }
}
