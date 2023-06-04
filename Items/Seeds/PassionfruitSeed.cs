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
			// base.DisplayName.SetDefault("百香果种子");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "百香果种子");
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
			base.Item.width = 22;
			base.Item.height = 12;
			base.Item.value = 100;
            base.Item.createTile = base.Mod.Find<ModTile>("百香果藤").Type;
            //base.item.createTile = base.mod.TileType("高阴燃草");
        }
	}
}
