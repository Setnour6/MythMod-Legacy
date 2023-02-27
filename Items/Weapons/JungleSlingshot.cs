using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons
{
    public class JungleSlingshot : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("丛林弹弓");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            base.item.damage = 18;
			base.item.crit = 8;
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
			base.item.rare = 2;
			base.item.UseSound = SoundID.Item5;
            item.shoot = mod.ProjectileType("GlowSporeBead");
			base.item.shootSpeed = 10f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(Vector2.Zero);
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(210, 8);
            recipe.AddIngredient(209, 6);
            recipe.AddIngredient(331, 6);
            recipe.SetResult(this, 1);
            recipe.requiredTile[0] = 16;
            recipe.AddRecipe();
        }
    }
}
