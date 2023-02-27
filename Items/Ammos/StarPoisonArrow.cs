using System;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Ammos
{
    public class StarPoisonArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Arctic Arrow");
			base.Tooltip.SetDefault("Freezes enemies for a short time");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "星渊毒素箭");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "施加夺命剧毒");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.damage = 47;
            base.item.crit = 4;
            base.item.ranged = true;
			base.item.width = 22;
			base.item.height = 36;
			base.item.maxStack = 999;
			base.item.consumable = true;
			base.item.knockBack = 1.5f;
			base.item.value = 100;
			base.item.rare = 3;
            base.item.shoot = base.mod.ProjectileType("StarPoisonArrow");
			base.item.shootSpeed = 13f;
			base.item.ammo = 40;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(40, 20);
            recipe.AddIngredient(null, "StarAbyssCell", 1);
            recipe.SetResult(this, 20);
            recipe.requiredTile[0] = 134;
            recipe.AddRecipe();
        }
    }
}
