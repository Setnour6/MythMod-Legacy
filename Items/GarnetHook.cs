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
            // base.DisplayName.SetDefault("石榴石钩爪");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "石榴石钩爪");
		}
		public override void SetDefaults()
		{
			base.Item.width = 40;
			base.Item.height = 40;
			base.Item.value = Item.sellPrice(0, 4, 0, 0);
			base.Item.rare = 1;
			base.Item.noUseGraphic = true;
			base.Item.useStyle = 5;
			base.Item.shootSpeed = 15f;
            base.Item.shoot = base.Mod.Find<ModProjectile>("石榴石钩爪Pro").Type;
			base.Item.UseSound = SoundID.Item1;
			base.Item.useAnimation = 20;
			base.Item.useTime = 20;
			base.Item.noMelee = false;
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(null, "Garnet", 15);
            recipe.requiredTile[0] = 16;
            recipe.Register();
        }
	}
}
