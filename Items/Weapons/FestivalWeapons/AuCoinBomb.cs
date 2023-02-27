using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons.FestivalWeapons
{
	// Token: 0x0200052F RID: 1327
    public class AuCoinBomb : ModItem
	{
		// Token: 0x06001750 RID: 5968 RVA: 0x0009AF78 File Offset: 0x00099178
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("金钱手雷");
            base.Tooltip.SetDefault("");
		}

		// Token: 0x06001751 RID: 5969 RVA: 0x0009AFD0 File Offset: 0x000991D0
		public override void SetDefaults()
		{
            base.item.damage = 250;
            base.item.thrown = true;
            base.item.crit = 15;
            base.item.width = 20;
            base.item.height = 38;
            base.item.useTime = 42;
            base.item.useAnimation = 42;
            base.item.useStyle = 5;
            base.item.noMelee = true;
            base.item.knockBack = 2f;
            base.item.autoReuse = true;
            base.item.value = Item.sellPrice(0, 9, 99, 99);
            base.item.shoot = base.mod.ProjectileType("AuBomb");
            base.item.noUseGraphic = true;
            base.item.rare = 6;
            base.item.UseSound = SoundID.Item5;
            base.item.shootSpeed = 12f;
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
		public override void AddRecipes()
        {
        }
	}
}
