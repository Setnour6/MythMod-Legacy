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
    public class BOCChest : ModItem
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
                   player.QuickSpawnItem(base.mod.ItemType("SwordBOC"), 1);
            }
            //player.QuickSpawnItem(2104, 1);
            //player.QuickSpawnItem(1362, 1);
            //player.QuickSpawnItem(880, Main.rand.Next(488, 796));
            //player.QuickSpawnItem(1329, Main.rand.Next(162, 243));
            //player.QuickSpawnItem(154, 1);
            //player.QuickSpawnItem(28, Main.rand.Next(80, 140));
            //player.QuickSpawnItem(74, 3);
            //player.QuickSpawnItem(3223, 1);
            player.QuickSpawnItem(base.mod.ItemType("BOCChest2"), 1);
			player.QuickSpawnItem(base.mod.ItemType("ElecCell"), Main.rand.Next(4, 12));
        }
	}
}
