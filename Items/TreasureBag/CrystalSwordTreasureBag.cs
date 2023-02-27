﻿using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;

namespace MythMod.Items.TreasureBag
{
    public class CrystalSwordTreasureBag : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Treasure Bag");
            base.Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "宝藏袋");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "右键点击打开");
        }
        public override void SetDefaults()
        {
            base.item.maxStack = 999;
            base.item.consumable = true;
            base.item.width = 24;
            base.item.height = 24;
            base.item.rare = 9;
            base.item.expert = true;
        }
        public override bool CanRightClick()
        {
            return true;
        }
        public override void RightClick(Player player)
        {
            int type = 0;
            switch (Main.rand.Next(1, 8))
            {
                case 1:
                    type = base.mod.ItemType("CrystalBall");
                    break;
                case 2:
                    type = base.mod.ItemType("CrystalBlade");
                    break;
                case 3:
                    type = base.mod.ItemType("CrystalBow");
                    break;
                case 4:
                    type = base.mod.ItemType("CrystalEagle");
                    break;
                case 5:
                    type = base.mod.ItemType("CrystalRose");
                    break;
                case 6:
                    type = base.mod.ItemType("CrystalSwordStaff");
                    break;
                case 7:
                    type = base.mod.ItemType("CrystalThrownKnife");
                    break;
            }
            player.QuickSpawnItem(type, 1);
        }
    }
}
