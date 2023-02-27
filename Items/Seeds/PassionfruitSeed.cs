using System;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Seeds
{
	// Token: 0x02000364 RID: 868
	public class PassionfruitSeed : ModItem
	{
		// Token: 0x06000DEF RID: 3567 RVA: 0x0000638B File Offset: 0x0000458B
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("百香果种子");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "百香果种子");
		}

		// Token: 0x06000DF0 RID: 3568 RVA: 0x0006CAA8 File Offset: 0x0006ACA8
		public override void SetDefaults()
		{
			base.item.useTurn = true;
			base.item.autoReuse = true;
			base.item.useStyle = 1;
			base.item.useAnimation = 15;
			base.item.useTime = 10;
			base.item.maxStack = 99;
			base.item.consumable = true;
			base.item.placeStyle = 0;
			base.item.width = 22;
			base.item.height = 12;
			base.item.value = 100;
            base.item.createTile = base.mod.TileType("百香果藤");
            //base.item.createTile = base.mod.TileType("高阴燃草");
        }
	}
}
