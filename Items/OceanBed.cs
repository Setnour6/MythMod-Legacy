using System;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
	// Token: 0x02000671 RID: 1649
    public class OceanBed : ModItem
	{
		// Token: 0x06001CA4 RID: 7332 RVA: 0x00009B49 File Offset: 0x00007D49
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("海洋床");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "海洋床");
		}

		// Token: 0x06001CA5 RID: 7333 RVA: 0x000B5C5C File Offset: 0x000B3E5C
		public override void SetDefaults()
		{
			base.item.width = 28;
			base.item.height = 14;
			base.item.maxStack = 99;
			base.item.useTurn = true;
			base.item.autoReuse = true;
			base.item.useAnimation = 15;
			base.item.useTime = 10;
			base.item.useStyle = 1;
			base.item.consumable = true;
			base.item.value = 0;
            base.item.createTile = base.mod.TileType("海洋床");
		}

		// Token: 0x06001CA6 RID: 7334 RVA: 0x000B5D04 File Offset: 0x000B3F04
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(null, "OceanBlueBar", 15);
			modRecipe.AddIngredient(225, 5);
			modRecipe.AddTile(18);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
