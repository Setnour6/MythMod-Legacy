using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
    public class GarnetHook : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("石榴石钩爪");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "石榴石钩爪");
		}
		public override void SetDefaults()
		{
			base.item.width = 40;
			base.item.height = 40;
			base.item.value = Item.sellPrice(0, 4, 0, 0);
			base.item.rare = 1;
			base.item.noUseGraphic = true;
			base.item.useStyle = 5;
			base.item.shootSpeed = 15f;
            base.item.shoot = base.mod.ProjectileType("石榴石钩爪Pro");
			base.item.UseSound = SoundID.Item1;
			base.item.useAnimation = 20;
			base.item.useTime = 20;
			base.item.noMelee = false;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Garnet", 15);
            recipe.requiredTile[0] = 16;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
