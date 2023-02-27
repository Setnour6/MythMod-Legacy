using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons.FestivalWeapons
{
    public class BlueberryswKnife : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("蓝莓喜糖投刃");
            base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
            base.item.thrown = true;
            base.item.damage = 200;
            base.item.crit = 15;
            base.item.width = 40;
            base.item.height = 40;
            base.item.useTime = 18;
            base.item.useAnimation = 18;
            base.item.useStyle = 5;
            base.item.noMelee = true;
            base.item.knockBack = 2f;
            base.item.autoReuse = true;
            base.item.value = Item.sellPrice(0, 1, 0, 0);
            base.item.shoot = base.mod.ProjectileType("BlueberryswKnife");
            base.item.noUseGraphic = true;
            base.item.rare = 6;
            base.item.UseSound = SoundID.Item5;
            base.item.shootSpeed = 27f;
        }
		public override void AddRecipes()
        {
        }
	}
}
