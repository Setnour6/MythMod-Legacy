using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
    public class QBChest : ModItem
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
            player.QuickSpawnItem(base.mod.ItemType("QBChest2"), 1);
			//player.QuickSpawnItem(1121, 1);
			//player.QuickSpawnItem(1123, 1);
			//player.QuickSpawnItem(2888, 1);
			//player.QuickSpawnItem(1129, 1);
			//player.QuickSpawnItem(842, 1);
			//player.QuickSpawnItem(843, 1);
			//player.QuickSpawnItem(844, 1);
			//player.QuickSpawnItem(1132, 1);
			//player.QuickSpawnItem(1170, 1);
			//player.QuickSpawnItem(2502, 1);
			//player.QuickSpawnItem(1130, Main.rand.Next(150,499));
			//player.QuickSpawnItem(1134, Main.rand.Next(40,129));
			//player.QuickSpawnItem(2431, Main.rand.Next(80,249));
			//player.QuickSpawnItem(1364, 1);
			//player.QuickSpawnItem(2108, 1);
			//player.QuickSpawnItem(3333, 1);
            if(Main.rand.Next(100) >= 50)
            {
                player.QuickSpawnItem(base.mod.ItemType("SwordQB"), 1);
            }
            player.QuickSpawnItem(base.mod.ItemType("BeeFeather"), 1);
            player.QuickSpawnItem(base.mod.ItemType("HoneyHeart"), 1);
            player.QuickSpawnItem(base.mod.ItemType("HoneyBottle"), 1);
            item.stack--;
        }
	}
}
