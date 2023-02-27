using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
// Token: 0x02000719 RID: 1817
namespace MythMod.Items
{
	// Token: 0x02000719 RID: 1817
    public class TNTBoom : ModItem
	{
		// Token: 0x06001FC4 RID: 8132 RVA: 0x000C4C50 File Offset: 0x000C2E50
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "炸药桶");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "");
		}

		// Token: 0x06001FC5 RID: 8133 RVA: 0x000C4CA8 File Offset: 0x000C2EA8
		public override void SetDefaults()
		{
			base.item.width = 20;
			base.item.height = 20;
			base.item.maxStack = 30;
			base.item.value = 100000;
			base.item.rare = 10;
			base.item.autoReuse = true;
			base.item.useAnimation = 15;
			base.item.useTime = 10;
			base.item.useStyle = 1;
			base.item.consumable = true;
			base.item.createTile = base.mod.TileType("炸药桶");
			base.item.placeStyle = 0;
		}
    }
}


