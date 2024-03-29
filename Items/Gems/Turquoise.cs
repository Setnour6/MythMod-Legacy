﻿using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Gems
{
	// Token: 0x020005BF RID: 1471
    public class Turquoise : ModItem
	{
		// Token: 0x060019E8 RID: 6632 RVA: 0x00008E84 File Offset: 0x00007084
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("绿松石");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "绿松石");
		}

		// Token: 0x060019E9 RID: 6633 RVA: 0x000A8668 File Offset: 0x000A6868
		public override void SetDefaults()
		{
			base.item.width = 20;
			base.item.height = 20;
			base.item.maxStack = 999;
			base.item.value = Item.sellPrice(0, 0, 30, 0);
			base.item.rare = 0;
		}
	}
}
