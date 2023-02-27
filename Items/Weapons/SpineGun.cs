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
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "脊骨手枪");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "这才是真正的毛骨悚然");
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BoneLiquid", 8);
            recipe.AddIngredient(null, "BrokenTooth", 12);
            recipe.requiredTile[0] = 26;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override void SetDefaults()
		{
			base.item.damage = 22;
			base.item.width = 64;
			base.item.height = 40;
			base.item.useTime = 16;
			base.item.useAnimation = 16;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.ranged = true;
			base.item.knockBack = 1f;
			base.item.value = 3000;
			base.item.rare = 2;
			base.item.UseSound = SoundID.Item31;
			base.item.autoReuse = true;
            base.item.shoot = 14;
			base.item.shootSpeed = 10f;
            item.useAmmo = AmmoID.Bullet;
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
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
