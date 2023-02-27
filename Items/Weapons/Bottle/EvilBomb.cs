using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons.Bottle
{
    public class EvilBomb : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("魔焰法瓶");
            base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
            base.item.damage = 22;
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
            base.item.value = Item.sellPrice(0, 0, 1, 0);
            base.item.shoot = base.mod.ProjectileType("EvilBomb");
            base.item.noUseGraphic = true;
            base.item.rare = 3;
            base.item.UseSound = SoundID.Item5;
            base.item.shootSpeed = 7f;
        }
		public override void AddRecipes()
        {
        }
	}
}
