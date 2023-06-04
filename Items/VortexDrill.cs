using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items
{
	public class VortexDrill : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("Vortex Drill");
			base.DisplayName.AddTranslation(GameCulture.English, "漩涡钻头");
		}

		public override void SetDefaults()
		{
			base.Item.damage = 95;
			base.Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			base.Item.width = 20;
			base.Item.height = 12;
			base.Item.useTime = 3;
			base.Item.useAnimation = 24;
			base.Item.tileBoost = 1;
			base.Item.channel = true;
			base.Item.noUseGraphic = true;
			base.Item.noMelee = true;
			base.Item.pick = 240;
			base.Item.useStyle = 5;
			base.Item.knockBack = 3f;
			base.Item.value = Item.sellPrice(0, 4, 16, 0);
			base.Item.rare = 11;
			base.Item.UseSound = SoundID.Item23;
			base.Item.autoReuse = true;
			base.Item.shoot = base.Mod.Find<ModProjectile>("漩涡钻头Pro").Type;
			base.Item.shootSpeed = 40f;
		}

        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(null, "OceanBlueBar", 30);
            modRecipe.requiredTile[0] = 412;
            modRecipe.Register();
        }
    }
}
