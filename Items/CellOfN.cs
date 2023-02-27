using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
	// Token: 0x02000719 RID: 1817
    public class CellOfN : ModItem
	{
		// Token: 0x06001FC4 RID: 8132 RVA: 0x000C4C50 File Offset: 0x000C2E50
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("123");
			base.Tooltip.SetDefault("'456'");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "神经细胞");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "神经细胞");
		}

		// Token: 0x06001FC5 RID: 8133 RVA: 0x000C4CA8 File Offset: 0x000C2EA8
		public override void SetDefaults()
		{
			base.item.width = 28;
			base.item.height = 24;
			base.item.maxStack = 999;
			base.item.value = Item.sellPrice(0, 2, 50, 0);
			base.item.rare = 6;
		}
    }
}


