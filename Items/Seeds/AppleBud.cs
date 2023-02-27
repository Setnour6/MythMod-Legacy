using System;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Seeds
{
	// Token: 0x02000364 RID: 868
	public class AppleBud : ModItem
	{
		// Token: 0x06000DEF RID: 3567 RVA: 0x0000638B File Offset: 0x0000458B
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("苹果苗");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "苹果苗");
            base.Tooltip.SetDefault("需要较开阔区域");

        }

		// Token: 0x06000DF0 RID: 3568 RVA: 0x0006CAA8 File Offset: 0x0006ACA8
		public override void SetDefaults()
		{
			base.Item.useTurn = true;
			base.Item.autoReuse = true;
			base.Item.useStyle = 1;
			base.Item.useAnimation = 15;
			base.Item.useTime = 10;
			base.Item.maxStack = 99;
			base.Item.consumable = true;
			base.Item.placeStyle = 0;
			base.Item.width = 14;
			base.Item.height = 14;
			base.Item.value = 100;
            base.Item.createTile = base.Mod.Find<ModTile>("苹果树").Type;
		}
	}
}
