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
            // base.DisplayName.SetDefault("丛林弹弓");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.damage = 18;
			base.Item.crit = 8;
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
			base.Item.rare = 2;
			base.Item.UseSound = SoundID.Item5;
            Item.shoot = Mod.Find<ModProjectile>("GlowSporeBead").Type;
			base.Item.shootSpeed = 10f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2?(Vector2.Zero);
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(210, 8);
            recipe.AddIngredient(209, 6);
            recipe.AddIngredient(331, 6);
            recipe.requiredTile[0] = 16;
            recipe.Register();
        }
    }
}
