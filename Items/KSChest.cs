using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
    public class KSChest : ModItem
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
            //this.bossBagNPC = 50;
        }
        public override bool CanRightClick()
        {
            return true;
        }
        public override void RightClick(Player player)
        {
            if (Main.rand.Next(2) == 1)
            {
                player.QuickSpawnItem(base.mod.ItemType("SwordKS"), 1);
            }
            if (Main.rand.Next(6) == 1)
            {
                player.QuickSpawnItem(base.mod.ItemType("SlipMagic"), 1);
            }
            //player.QuickSpawnItem(23, Main.rand.Next(1250, 2336));
            //player.QuickSpawnItem(73, Main.rand.Next(1, 99));
            //player.QuickSpawnItem(74, Main.rand.Next(2, 3));
            //player.QuickSpawnItem(256, 1);
            //player.QuickSpawnItem(257, 1);
            //player.QuickSpawnItem(258, 1);
            //player.QuickSpawnItem(2585, 1);
            //player.QuickSpawnItem(998, 1);
            //player.QuickSpawnItem(28, Main.rand.Next(80, 140));
            //player.QuickSpawnItem(2430, 1);
            //player.QuickSpawnItem(2610, 1);
            //player.QuickSpawnItem(2489, 1);
            //player.QuickSpawnItem(2493, 1);
            player.QuickSpawnItem(mod.ItemType("JellySlingshot"), 1);
            player.QuickSpawnItem(base.mod.ItemType("KSChest2"), 1);
            player.QuickSpawnItem(base.mod.ItemType("PureJelly"), Main.rand.Next(2, 5));
            item.stack--;
        }
    }
}
