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
			base.DisplayName.SetDefault("Vortex Drill");
			base.DisplayName.AddTranslation(GameCulture.English, "漩涡钻头");
		}

		public override void SetDefaults()
		{
			base.item.damage = 95;
			base.item.melee = true;
			base.item.width = 20;
			base.item.height = 12;
			base.item.useTime = 3;
			base.item.useAnimation = 24;
			base.item.tileBoost = 1;
			base.item.channel = true;
			base.item.noUseGraphic = true;
			base.item.noMelee = true;
			base.item.pick = 240;
			base.item.useStyle = 5;
			base.item.knockBack = 3f;
			base.item.value = Item.sellPrice(0, 4, 16, 0);
			base.item.rare = 11;
			base.item.UseSound = SoundID.Item23;
			base.item.autoReuse = true;
			base.item.shoot = base.mod.ProjectileType("漩涡钻头Pro");
			base.item.shootSpeed = 40f;
		}

        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "OceanBlueBar", 30);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
