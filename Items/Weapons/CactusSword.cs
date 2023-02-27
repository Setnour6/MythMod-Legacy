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
			base.item.damage = 9;
			base.item.crit = 7;
			base.item.ranged = true;
			base.item.width = 42;
			base.item.height = 30;
			base.item.useTime = 14;
			base.item.useAnimation = 14;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 2f;
			base.item.autoReuse = false;
			base.item.value = Item.sellPrice(0, 0, 0, 50);
			base.item.rare = 1;
			base.item.UseSound = SoundID.Item5;
                 item.shoot = 51;
			base.item.shootSpeed = 8f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(Vector2.Zero);
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(276, 7);
            recipe.AddIngredient(ItemID.Cobweb, 14);
            recipe.SetResult(this, 1);
            recipe.requiredTile[0] = 18;
            recipe.AddRecipe();
        }
	}
}
