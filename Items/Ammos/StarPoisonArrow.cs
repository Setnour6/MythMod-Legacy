using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Ammos
{
    public class StarPoisonArrow : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("Arctic Arrow");
			// base.Tooltip.SetDefault("Freezes enemies for a short time");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "星渊毒素箭");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "施加夺命剧毒");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.damage = 47;
            base.Item.crit = 4;
            base.Item.DamageType = DamageClass.Ranged;
			base.Item.width = 22;
			base.Item.height = 36;
			base.Item.maxStack = 999;
			base.Item.consumable = true;
			base.Item.knockBack = 1.5f;
			base.Item.value = 100;
			base.Item.rare = 3;
            base.Item.shoot = base.Mod.Find<ModProjectile>("StarPoisonArrow").Type;
			base.Item.shootSpeed = 13f;
			base.Item.ammo = 40;
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(20);
            recipe.AddIngredient(40, 20);
            recipe.AddIngredient(null, "StarAbyssCell", 1);
            recipe.requiredTile[0] = 134;
            recipe.Register();
        }
    }
}
