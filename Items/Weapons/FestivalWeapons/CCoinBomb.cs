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
            // base.DisplayName.SetDefault("钻石手雷");
            // base.Tooltip.SetDefault("");
		}

		// Token: 0x06001751 RID: 5969 RVA: 0x0009AFD0 File Offset: 0x000991D0
		public override void SetDefaults()
		{
            base.Item.DamageType = DamageClass.Throwing;
            base.Item.damage = 1330;
            base.Item.crit = 15;
            base.Item.width = 20;
            base.Item.height = 38;
            base.Item.useTime = 28;
            base.Item.useAnimation = 28;
            base.Item.useStyle = 5;
            base.Item.noMelee = true;
            base.Item.knockBack = 2f;
            base.Item.autoReuse = true;
            base.Item.value = Item.sellPrice(0, 99, 99, 99);
            base.Item.shoot = base.Mod.Find<ModProjectile>("DiamondBomb").Type;
            base.Item.noUseGraphic = true;
            base.Item.rare = 9;
            base.Item.UseSound = SoundID.Item5;
            base.Item.shootSpeed = 20f;
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
		public override void AddRecipes()
        {
        }
	}
}
