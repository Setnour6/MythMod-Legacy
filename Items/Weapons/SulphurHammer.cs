using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
	public class SulphurHammer : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("硫磺战锤");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "硫磺战锤");
		}
		public override void SetDefaults()
		{
			base.Item.width = 46;
			base.Item.damage = 330;
			base.Item.noMelee = true;
			base.Item.noUseGraphic = true;
			base.Item.useAnimation = 20;
            base.Item.autoReuse = true;
            base.Item.useStyle = 1;
			base.Item.useTime = 20;
			base.Item.knockBack = 7.5f;
			base.Item.UseSound = SoundID.Item1;
			base.Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			base.Item.height = 38;
			base.Item.value = Item.buyPrice(0, 3, 0, 0);
			base.Item.rare = 11;
			base.Item.shoot = base.Mod.Find<ModProjectile>("SulfurHammer").Type;
			base.Item.shootSpeed = 18.5f;
		}
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(null, "Basalt", 12);
            modRecipe.AddIngredient(null, "Sulfur", 72);
            modRecipe.requiredTile[0] = 412;
            modRecipe.Register();
        }
    }
}
