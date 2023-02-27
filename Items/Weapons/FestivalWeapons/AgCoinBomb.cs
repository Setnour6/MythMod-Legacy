using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons.FestivalWeapons
{
    public class AgCoinBomb : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("银钱手雷");
            base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
            base.item.damage = 52;
            base.item.thrown = true;
            base.item.crit = 6;
            base.item.width = 20;
            base.item.height = 38;
            base.item.useTime = 48;
            base.item.useAnimation = 48;
            base.item.useStyle = 5;
            base.item.noMelee = true;
            base.item.knockBack = 2f;
            base.item.autoReuse = true;
            base.item.value = Item.sellPrice(0, 0, 99, 99);
            base.item.shoot = base.mod.ProjectileType("AgBomb");
            base.item.noUseGraphic = true;
            base.item.rare = 4;
            base.item.UseSound = SoundID.Item5;
            base.item.shootSpeed = 9f;
        }
        // Token: 0x0600462B RID: 17963 RVA: 0x0027BBA8 File Offset: 0x00279DA8
		public override void AddRecipes()
        {
        }
	}
}
