using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
	// Token: 0x0200015B RID: 347
    public class Mussel : ModItem
	{
		// Token: 0x060005E3 RID: 1507 RVA: 0x00041728 File Offset: 0x0003F928
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("青口螺");
            // base.Tooltip.SetDefault("");
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x00041780 File Offset: 0x0003F980
		public override void SetDefaults()
		{
			base.Item.width = 34;
            base.Item.height = 30;
            base.Item.rare = 0;
			base.Item.useAnimation = 30;
			base.Item.useTime = 20;
			base.Item.useStyle = 2;
			base.Item.UseSound = SoundID.Item8;
			base.Item.consumable = true;
            base.Item.maxStack = 200;
            Item.value = 2000;
        }

		// Token: 0x060005E5 RID: 1509 RVA: 0x000043CB File Offset: 0x000025CB
		// Token: 0x060005E6 RID: 1510 RVA: 0x000417F8 File Offset: 0x0003F9F8
        public override void AddRecipes()
        {
        }
	}
}
