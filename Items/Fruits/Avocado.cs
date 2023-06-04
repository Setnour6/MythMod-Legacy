using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Fruits
{
	// Token: 0x0200015B RID: 347
    public class Avocado : ModItem
	{
		// Token: 0x060005E3 RID: 1507 RVA: 0x00041728 File Offset: 0x0003F928
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("牛油果");
            // base.Tooltip.SetDefault("");
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x00041780 File Offset: 0x0003F980
		public override void SetDefaults()
		{
			base.Item.width = 32;
			base.Item.height = 32;
			base.Item.rare = 2;
			base.Item.useAnimation = 20;
			base.Item.useTime = 20;
			base.Item.useStyle = 2;
			base.Item.UseSound = SoundID.Item8;
			base.Item.consumable = true;
            base.Item.maxStack = 200;
            Item.rare = 0;
            Item.value = 1000;
        }
	}
}
