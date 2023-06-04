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
            // base.DisplayName.SetDefault("蓝宝石弹弓");
            // base.Tooltip.SetDefault("遍地皆是石子，弹药这种东西怎么会缺呢");
		}
		public override void SetDefaults()
		{
			base.Item.damage = 13;
			base.Item.crit = 6;
			base.Item.DamageType = DamageClass.Ranged;
			base.Item.width = 38;
			base.Item.height = 36;
			base.Item.useTime = 25;
			base.Item.useAnimation = 14;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 2f;
			base.Item.autoReuse = false;
			base.Item.value = Item.sellPrice(0, 0, 10, 0);
			base.Item.rare = 3;
			base.Item.UseSound = SoundID.Item5;
                 Item.shoot = base.Mod.Find<ModProjectile>("BlueGemBead").Type;
			base.Item.shootSpeed = 10f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(Vector2.Zero);
		}
		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(177, 8);
            recipe.AddIngredient(21, 6);
            recipe.requiredTile[0] = 16;
            recipe.Register();
        }
	}
}
