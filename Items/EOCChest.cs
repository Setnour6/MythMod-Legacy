using System;
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
    public class EOCChest : ModItem
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
            //this.bossBagNPC = 4;
        }
        public override bool CanRightClick()
        {
            return true;
        }
        public override void RightClick(Player player)
        {
            if (Main.rand.Next(2) == 1)
            {
                player.QuickSpawnItem(base.mod.ItemType("SwordEOC"), 1);
            }
            if (Main.rand.Next(6) == 1)
            {
                player.QuickSpawnItem(base.mod.ItemType("SightEye"), 1);
            }
            //player.QuickSpawnItem(56, Main.rand.Next(340, 652));
            //player.QuickSpawnItem(59, Main.rand.Next(16, 40));
            //player.QuickSpawnItem(47, Main.rand.Next(295, 796));
            //player.QuickSpawnItem(880, Main.rand.Next(340, 652));
            //player.QuickSpawnItem(2171, Main.rand.Next(16, 40));
            //player.QuickSpawnItem(3097, 1);
            //player.QuickSpawnItem(3763, 1);
            //player.QuickSpawnItem(1299, 1);
            //player.QuickSpawnItem(2112, 1);
            //player.QuickSpawnItem(1360, 1);
            //player.QuickSpawnItem(28, Main.rand.Next(80, 140));
            //player.QuickSpawnItem(74, 3);
            //player.QuickSpawnItem(38, Main.rand.Next(12, 23));
            //player.QuickSpawnItem(236, Main.rand.Next(3, 7));
            player.QuickSpawnItem(base.mod.ItemType("EOCChest2"), 1);
            player.QuickSpawnItem(base.mod.ItemType("BloodCryst"), Main.rand.Next(1, 3));
        }
    }
}
