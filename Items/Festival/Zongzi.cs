using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Festival
{
	// Token: 0x0200015B RID: 347
    public class Zongzi : ModItem
	{
		// Token: 0x060005E3 RID: 1507 RVA: 0x00041728 File Offset: 0x0003F928
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("粽子");
            base.Tooltip.SetDefault("");
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x00041780 File Offset: 0x0003F980
		public override void SetDefaults()
		{
			base.item.width = 34;
			base.item.height = 32;
			base.item.useAnimation = 20;
			base.item.useTime = 20;
            base.item.maxStack = 999;
            base.item.rare = 8;
            base.item.value = Item.sellPrice(0, 0, 10, 0);
		}
	}
}
