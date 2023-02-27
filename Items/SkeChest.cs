using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
    public class SkeChest : ModItem
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
            if (Main.rand.Next(6) == 1)
            {
                player.QuickSpawnItem(base.mod.ItemType("BoneKiller"), 1);
            }
            if (Main.rand.Next(100) >= 50)
            {
                player.QuickSpawnItem(base.mod.ItemType("SwordSK"), 1);
            }
            player.QuickSpawnItem(base.mod.ItemType("SkeChest2"), 1);
            item.stack--;
        }
	}
}
