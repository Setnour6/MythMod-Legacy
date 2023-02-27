using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class BlueGemSlingshot : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("蓝宝石弹弓");
            base.Tooltip.SetDefault("遍地皆是石子，弹药这种东西怎么会缺呢");
		}
		public override void SetDefaults()
		{
			base.item.damage = 13;
			base.item.crit = 6;
			base.item.ranged = true;
			base.item.width = 38;
			base.item.height = 36;
			base.item.useTime = 25;
			base.item.useAnimation = 14;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 2f;
			base.item.autoReuse = false;
			base.item.value = Item.sellPrice(0, 0, 10, 0);
			base.item.rare = 3;
			base.item.UseSound = SoundID.Item5;
                 item.shoot = base.mod.ProjectileType("BlueGemBead");
			base.item.shootSpeed = 10f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(Vector2.Zero);
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(177, 8);
            recipe.AddIngredient(21, 6);
            recipe.SetResult(this, 1);
            recipe.requiredTile[0] = 16;
            recipe.AddRecipe();
        }
	}
}
