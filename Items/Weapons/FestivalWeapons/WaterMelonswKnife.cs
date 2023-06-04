using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons.FestivalWeapons
{
    public class WaterMelonswKnife : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("西瓜喜糖投刃");
            // base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
            base.Item.DamageType = DamageClass.Throwing;
            base.Item.damage = 200;
            base.Item.crit = 15;
            base.Item.width = 40;
            base.Item.height = 40;
            base.Item.useTime = 18;
            base.Item.useAnimation = 18;
            base.Item.useStyle = 5;
            base.Item.noMelee = true;
            base.Item.knockBack = 2f;
            base.Item.autoReuse = true;
            base.Item.value = Item.sellPrice(0, 1, 0, 0);
            base.Item.shoot = base.Mod.Find<ModProjectile>("WatermelonswKnife").Type;
            base.Item.noUseGraphic = true;
            base.Item.rare = 6;
            base.Item.UseSound = SoundID.Item5;
            base.Item.shootSpeed = 27f;
        }
		public override void AddRecipes()
        {
        }
	}
}
