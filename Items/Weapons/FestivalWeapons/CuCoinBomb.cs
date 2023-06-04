﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons.FestivalWeapons
{
	// Token: 0x0200052F RID: 1327
    public class CuCoinBomb : ModItem
	{
		// Token: 0x06001750 RID: 5968 RVA: 0x0009AF78 File Offset: 0x00099178
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("铜钱手雷");
            // base.Tooltip.SetDefault("");
		}

		// Token: 0x06001751 RID: 5969 RVA: 0x0009AFD0 File Offset: 0x000991D0
		public override void SetDefaults()
		{
            base.Item.damage = 30;
            base.Item.crit = 6;
            base.Item.DamageType = DamageClass.Throwing;
            base.Item.width = 20;
            base.Item.height = 38;
            base.Item.useTime = 60;
            base.Item.useAnimation = 60;
            base.Item.useStyle = 5;
            base.Item.noMelee = true;
            base.Item.knockBack = 2f;
            base.Item.autoReuse = true;
            base.Item.value = Item.sellPrice(0, 0, 0, 99);
            base.Item.shoot = base.Mod.Find<ModProjectile>("CuBumb").Type;
            base.Item.noUseGraphic = true;
            base.Item.rare = 2;
            base.Item.UseSound = SoundID.Item5;
            base.Item.shootSpeed = 7f;
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
		public override void AddRecipes()
        {
        }
	}
}
