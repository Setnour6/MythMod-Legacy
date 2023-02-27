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
            base.DisplayName.SetDefault("骨片飞刀");
            base.Tooltip.SetDefault("");
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BoneLiquid", 5);
            recipe.AddIngredient(null, "BrokenTooth", 15);
            recipe.requiredTile[0] = 26;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override void SetDefaults()
		{
            base.item.damage = 27;
            base.item.crit = 6;
            base.item.width = 18;
            base.item.height = 52;
            base.item.useTime = 28;
            base.item.useAnimation = 28;
            base.item.useStyle = 5;
            base.item.noMelee = true;
            base.item.knockBack = 2f;
            base.item.autoReuse = true;
            base.item.value = Item.sellPrice(0, 0, 10, 0);
            base.item.shoot = base.mod.ProjectileType("骨片飞刀");
            base.item.noUseGraphic = true;
            base.item.rare = 2;
            base.item.UseSound = SoundID.Item5;
            base.item.shootSpeed = 7f;
        }
	}
}
