using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
// Token: 0x02000719 RID: 1817
namespace MythMod.Items
{
	// Token: 0x02000719 RID: 1817
    public class MoonMossBar : ModItem
	{
		// Token: 0x06001FC4 RID: 8132 RVA: 0x000C4C50 File Offset: 0x000C2E50
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("123");
			base.Tooltip.SetDefault("'456'");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "月苔锭");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "'晶莹剔透，幻彩迷离'");
		}

		// Token: 0x06001FC5 RID: 8133 RVA: 0x000C4CA8 File Offset: 0x000C2EA8
		public override void SetDefaults()
		{
			base.Item.width = 20;
			base.Item.height = 20;
			base.Item.maxStack = 999;
			base.Item.value = Item.sellPrice(0, 3, 75, 0);
			base.Item.rare = 10;
			base.Item.autoReuse = true;
			base.Item.useAnimation = 15;
			base.Item.useTime = 10;
			base.Item.useStyle = 1;
			base.Item.consumable = true;
			base.Item.createTile = base.Mod.Find<ModTile>("Bars").Type;
			base.Item.placeStyle = 2;
		}
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
        public override void AddRecipes()
        {

        }	
    }
}


