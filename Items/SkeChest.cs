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
            base.Item.maxStack = 1;
            base.Item.consumable = false;
            base.Item.width = 24;
            base.Item.height = 24;
            base.Item.rare = 9;
            base.Item.expert = true;
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
                player.QuickSpawnItem(base.Mod.Find<ModItem>("BoneKiller").Type, 1);
            }
            if (Main.rand.Next(100) >= 50)
            {
                player.QuickSpawnItem(base.Mod.Find<ModItem>("SwordSK").Type, 1);
            }
            player.QuickSpawnItem(base.Mod.Find<ModItem>("SkeChest2").Type, 1);
            Item.stack--;
        }
	}
}
