using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
	// Token: 0x020001E9 RID: 489
    public class XXLYChest : ModItem
	{
		// Token: 0x0600090F RID: 2319 RVA: 0x0004B530 File Offset: 0x00049730
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Treasure Bag");
			base.Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "宝藏箱");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "右键点击打开");
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x0004C6BC File Offset: 0x0004A8BC
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

		// Token: 0x06000911 RID: 2321 RVA: 0x00004588 File Offset: 0x00002788
		public override bool CanRightClick()
		{
			return true;
		}

        public override void RightClick(Player player)
        {
            player.QuickSpawnItem(base.Mod.Find<ModItem>("XXLYChest2").Type, 1);
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
                player.QuickSpawnItem(base.Mod.Find<ModItem>("SwordXXLY").Type, 1);
            }
            player.QuickSpawnItem(base.Mod.Find<ModItem>("TuskLace").Type, 1);
            player.QuickSpawnItem(base.Mod.Find<ModItem>("BrokenBone").Type, 1);
            Item.stack--;
        }
	}
}
