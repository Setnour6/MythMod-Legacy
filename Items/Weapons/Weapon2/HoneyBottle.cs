using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons.Weapon2
{
    public class HoneyBottle : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("蜂蜜投瓶");
            base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
            base.item.damage = 37;
            base.item.thrown = true;
            base.item.crit = 6;
            base.item.width = 20;
            base.item.height = 38;
            base.item.useTime = 16;
            base.item.useAnimation = 16;
            base.item.useStyle = 5;
            base.item.noMelee = true;
            base.item.knockBack = 2f;
            base.item.autoReuse = true;
            base.item.value = 5000;
            base.item.shoot = base.mod.ProjectileType("HoneyBottle");
            base.item.noUseGraphic = true;
            base.item.rare = 4;
            base.item.UseSound = SoundID.Item5;
            base.item.shootSpeed = 11f;
        }
		public override void AddRecipes()
        {
        }
	}
}
