using System;
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
            base.DisplayName.SetDefault("铜钱手雷");
            base.Tooltip.SetDefault("");
		}

		// Token: 0x06001751 RID: 5969 RVA: 0x0009AFD0 File Offset: 0x000991D0
		public override void SetDefaults()
		{
            base.item.damage = 30;
            base.item.crit = 6;
            base.item.thrown = true;
            base.item.width = 20;
            base.item.height = 38;
            base.item.useTime = 60;
            base.item.useAnimation = 60;
            base.item.useStyle = 5;
            base.item.noMelee = true;
            base.item.knockBack = 2f;
            base.item.autoReuse = true;
            base.item.value = Item.sellPrice(0, 0, 0, 99);
            base.item.shoot = base.mod.ProjectileType("CuBumb");
            base.item.noUseGraphic = true;
            base.item.rare = 2;
            base.item.UseSound = SoundID.Item5;
            base.item.shootSpeed = 7f;
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
		public override void AddRecipes()
        {
        }
	}
}
