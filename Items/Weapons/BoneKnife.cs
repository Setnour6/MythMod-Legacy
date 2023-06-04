using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class BoneKnife : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("骨片飞刀");
            // base.Tooltip.SetDefault("");
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(null, "BoneLiquid", 5);
            recipe.AddIngredient(null, "BrokenTooth", 15);
            recipe.requiredTile[0] = 26;
            recipe.Register();
        }
        public override void SetDefaults()
		{
            base.Item.damage = 27;
            base.Item.crit = 6;
            base.Item.width = 18;
            base.Item.height = 52;
            base.Item.useTime = 28;
            base.Item.useAnimation = 28;
            base.Item.useStyle = 5;
            base.Item.noMelee = true;
            base.Item.knockBack = 2f;
            base.Item.autoReuse = true;
            base.Item.value = Item.sellPrice(0, 0, 10, 0);
            base.Item.shoot = base.Mod.Find<ModProjectile>("骨片飞刀").Type;
            base.Item.noUseGraphic = true;
            base.Item.rare = 2;
            base.Item.UseSound = SoundID.Item5;
            base.Item.shootSpeed = 7f;
        }
	}
}
