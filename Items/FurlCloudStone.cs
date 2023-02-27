using System;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
	// Token: 0x02000674 RID: 1652
    public class FurlCloudStone : ModItem
	{
		// Token: 0x06001CB0 RID: 7344 RVA: 0x00009BBE File Offset: 0x00007DBE
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Swirl Cloud Stone");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "卷云岩");
		}

		// Token: 0x06001CB1 RID: 7345 RVA: 0x000B5F1C File Offset: 0x000B411C
		public override void SetDefaults()
		{
			base.Item.width = 16;
			base.Item.height = 16;
			base.Item.maxStack = 999;
			base.Item.value = 0;
			base.Item.rare = 0;
			base.Item.useTurn = true;
			base.Item.autoReuse = true;
			base.Item.useAnimation = 15;
			base.Item.useTime = 10;
			base.Item.useStyle = 1;
			base.Item.consumable = true;
            base.Item.createTile = base.Mod.Find<ModTile>("卷云岩").Type;
		}

		// Token: 0x06001CB2 RID: 7346 RVA: 0x000B5FD0 File Offset: 0x000B41D0
	}
}
