﻿using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MythMod.Items.Foods
{
	// Token: 0x0200015B RID: 347
    public class SeaUrchin : ModItem
	{
		// Token: 0x060005E3 RID: 1507 RVA: 0x00041728 File Offset: 0x0003F928
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("海胆刺身");
            // base.Tooltip.SetDefault("看样子……有点重口");
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x00041780 File Offset: 0x0003F980
		public override void SetDefaults()
		{
			base.Item.width = 40;
            base.Item.height = 30;
            base.Item.rare = 5;
			base.Item.useAnimation = 20;
			base.Item.useTime = 20;
			base.Item.useStyle = 2;
			base.Item.UseSound = SoundID.Item8;
			base.Item.consumable = true;
            base.Item.maxStack = 200;
            Item.value = 50000;

        }

		// Token: 0x060005E5 RID: 1509 RVA: 0x000043CB File Offset: 0x000025CB
		// Token: 0x060005E6 RID: 1510 RVA: 0x000417F8 File Offset: 0x0003F9F8
        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            if (player.itemAnimation > 0 && player.itemTime == 0)
            {
                player.itemTime = base.Item.useTime;
                modPlayer.YinLife += 2;
                player.statLife += 50;
            }
            return true;
        }
        public override void AddRecipes()
        {
        }
	}
}
