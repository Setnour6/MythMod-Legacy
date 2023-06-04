using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;

namespace MythMod.Items.Weapons
{
    public class SpineGun : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("");
			// base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "脊骨手枪");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "这才是真正的毛骨悚然");
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(null, "BoneLiquid", 8);
            recipe.AddIngredient(null, "BrokenTooth", 12);
            recipe.requiredTile[0] = 26;
            recipe.Register();
        }
        public override void SetDefaults()
		{
			base.Item.damage = 22;
			base.Item.width = 64;
			base.Item.height = 40;
			base.Item.useTime = 16;
			base.Item.useAnimation = 16;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.DamageType = DamageClass.Ranged;
			base.Item.knockBack = 1f;
			base.Item.value = 3000;
			base.Item.rare = 2;
			base.Item.UseSound = SoundID.Item31;
			base.Item.autoReuse = true;
            base.Item.shoot = 14;
			base.Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Bullet;
        }
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float num = speedX + (float)Main.rand.Next(-10, 11) * 0.05f;
			float num2 = speedY + (float)Main.rand.Next(-10, 11) * 0.05f;
			Projectile.NewProjectile(position.X, position.Y - 2, speedX, speedY, type, (int)((double)damage), knockBack, player.whoAmI, 0f, 0);
			return false;
		}
		public override Vector2? HoldoutOffset()
        {
            return new Vector2(-18.0f, 0.0f);
        }
	}
}
