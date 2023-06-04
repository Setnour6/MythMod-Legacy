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
            // base.DisplayName.SetDefault("蜂蜜投瓶");
            // base.Tooltip.SetDefault("");
		}
		public override void SetDefaults()
		{
            base.Item.damage = 37;
            base.Item.DamageType = DamageClass.Throwing;
            base.Item.crit = 6;
            base.Item.width = 20;
            base.Item.height = 38;
            base.Item.useTime = 16;
            base.Item.useAnimation = 16;
            base.Item.useStyle = 5;
            base.Item.noMelee = true;
            base.Item.knockBack = 2f;
            base.Item.autoReuse = true;
            base.Item.value = 5000;
            base.Item.shoot = base.Mod.Find<ModProjectile>("HoneyBottle").Type;
            base.Item.noUseGraphic = true;
            base.Item.rare = 4;
            base.Item.UseSound = SoundID.Item5;
            base.Item.shootSpeed = 11f;
        }
		public override void AddRecipes()
        {
        }
	}
}
