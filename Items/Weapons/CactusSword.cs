using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class CactusSword : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("仙人掌弹弓");
            base.Tooltip.SetDefault("遍地皆是石子，弹药这种东西怎么会缺呢");
		}
		public override void SetDefaults()
		{
			base.Item.damage = 9;
			base.Item.crit = 7;
			base.Item.DamageType = DamageClass.Ranged;
			base.Item.width = 42;
			base.Item.height = 30;
			base.Item.useTime = 14;
			base.Item.useAnimation = 14;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 2f;
			base.Item.autoReuse = false;
			base.Item.value = Item.sellPrice(0, 0, 0, 50);
			base.Item.rare = 1;
			base.Item.UseSound = SoundID.Item5;
                 Item.shoot = 51;
			base.Item.shootSpeed = 8f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(Vector2.Zero);
		}
		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(276, 7);
            recipe.AddIngredient(ItemID.Cobweb, 14);
            recipe.requiredTile[0] = 18;
            recipe.Register();
        }
	}
}
