using System;
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
			base.item.damage = 13;
            base.item.crit = 4;
            base.item.ranged = true;
			base.item.width = 22;
			base.item.height = 36;
			base.item.maxStack = 999;
			base.item.consumable = true;
			base.item.knockBack = 1.5f;
			base.item.value = 400;
			base.item.rare = 3;
            base.item.shoot = base.mod.ProjectileType("HeartArrow");
			base.item.shootSpeed = 13f;
			base.item.ammo = 40;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(40, 100);
            recipe.AddIngredient(2352, 1);
            recipe.SetResult(this, 100);
            recipe.requiredTile[0] = 125;
            recipe.AddRecipe();
        }
    }
}
