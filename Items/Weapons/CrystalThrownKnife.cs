using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class CrystalThrownKnife : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("晶体投刃");
            // base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
            base.Item.DamageType = DamageClass.Throwing;
            base.Item.damage = 220;
            base.Item.crit = 15;
            base.Item.width = 40;
            base.Item.height = 40;
            base.Item.useTime = 6;
            base.Item.useAnimation = 6;
            base.Item.useStyle = 5;
            base.Item.noMelee = true;
            base.Item.knockBack = 2f;
            base.Item.autoReuse = true;
            base.Item.value = Item.sellPrice(0, 10, 0, 0);
            base.Item.shoot = base.Mod.Find<ModProjectile>("CrystalThrownKnife").Type;
            base.Item.noUseGraphic = true;
            base.Item.rare = 11;
            base.Item.UseSound = SoundID.Item5;
            base.Item.shootSpeed = 35f;
        }
		public override void AddRecipes()
        {
        }
	}
}
