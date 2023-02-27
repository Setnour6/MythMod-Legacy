using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons.FestivalWeapons
{
	// Token: 0x0200052F RID: 1327
    public class CCoinBomb : ModItem
	{
		// Token: 0x06001750 RID: 5968 RVA: 0x0009AF78 File Offset: 0x00099178
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("钻石手雷");
            base.Tooltip.SetDefault("");
		}

		// Token: 0x06001751 RID: 5969 RVA: 0x0009AFD0 File Offset: 0x000991D0
		public override void SetDefaults()
		{
            base.item.thrown = true;
            base.item.damage = 1330;
            base.item.crit = 15;
            base.item.width = 20;
            base.item.height = 38;
            base.item.useTime = 28;
            base.item.useAnimation = 28;
            base.item.useStyle = 5;
            base.item.noMelee = true;
            base.item.knockBack = 2f;
            base.item.autoReuse = true;
            base.item.value = Item.sellPrice(0, 99, 99, 99);
            base.item.shoot = base.mod.ProjectileType("DiamondBomb");
            base.item.noUseGraphic = true;
            base.item.rare = 9;
            base.item.UseSound = SoundID.Item5;
            base.item.shootSpeed = 20f;
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
		public override void AddRecipes()
        {
        }
	}
}
