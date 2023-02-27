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
			base.DisplayName.SetDefault("硫磺战锤");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "硫磺战锤");
		}
		public override void SetDefaults()
		{
			base.item.width = 46;
			base.item.damage = 330;
			base.item.noMelee = true;
			base.item.noUseGraphic = true;
			base.item.useAnimation = 20;
            base.item.autoReuse = true;
            base.item.useStyle = 1;
			base.item.useTime = 20;
			base.item.knockBack = 7.5f;
			base.item.UseSound = SoundID.Item1;
			base.item.melee = true;
			base.item.height = 38;
			base.item.value = Item.buyPrice(0, 3, 0, 0);
			base.item.rare = 11;
			base.item.shoot = base.mod.ProjectileType("SulfurHammer");
			base.item.shootSpeed = 18.5f;
		}
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(null, "Basalt", 12);
            modRecipe.AddIngredient(null, "Sulfur", 72);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
