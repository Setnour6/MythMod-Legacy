using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Ammos
{
    public class LoveArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Arctic Arrow");
			base.Tooltip.SetDefault("Freezes enemies for a short time");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "爱心箭");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "爱意……");
		}
		public override void SetDefaults()
		{
			base.Item.damage = 13;
            base.Item.crit = 4;
            base.Item.DamageType = DamageClass.Ranged;
			base.Item.width = 22;
			base.Item.height = 36;
			base.Item.maxStack = 999;
			base.Item.consumable = true;
			base.Item.knockBack = 1.5f;
			base.Item.value = 400;
			base.Item.rare = 3;
            base.Item.shoot = base.Mod.Find<ModProjectile>("HeartArrow").Type;
			base.Item.shootSpeed = 13f;
			base.Item.ammo = 40;
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(100);
            recipe.AddIngredient(40, 100);
            recipe.AddIngredient(2352, 1);
            recipe.requiredTile[0] = 125;
            recipe.Register();
        }
    }
}
