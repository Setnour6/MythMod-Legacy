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
using Terraria.GameContent.Achievements;

namespace MythMod.Items.Weapons
{
    public class StormPine : ModItem
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("冰凌雪松");
			Item.staff[base.Item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "冰凌雪松");
		}
		public override void SetDefaults()
		{
			base.Item.damage = 275;
			base.Item.DamageType = DamageClass.Magic;
			base.Item.mana = 5;
			base.Item.width = 56;
			base.Item.height = 56;
			base.Item.useTime = 3;
			base.Item.useAnimation = 3;
			base.Item.useStyle = 5;
			base.Item.noMelee = true;
			base.Item.knockBack = 2.4f;
			base.Item.value = 50000;
			base.Item.rare = 11;
			base.Item.UseSound = SoundID.Item60;
			base.Item.autoReuse = true;
            base.Item.shoot = 336;
			base.Item.shootSpeed = 11f;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 v = new Vector2(speedX, speedY).RotatedBy(Main.rand.Next(-100, 100) / 1000f * Math.PI) * Main.rand.Next(800, 1200) / 1000f;
            Projectile.NewProjectile(position.X + speedX, position.Y + speedY, v.X, v.Y, 336, damage, knockBack, player.whoAmI, 1f);
            v = new Vector2(speedX, speedY).RotatedBy(Main.rand.Next(-100, 100) / 1000f * Math.PI) * Main.rand.Next(800, 1200) / 1000f;
            Projectile.NewProjectile(position.X + speedX, position.Y + speedY, v.X, v.Y, 336, damage, knockBack, player.whoAmI, 1f);
            v = new Vector2(speedX, speedY).RotatedBy(Main.rand.Next(-100, 100) / 1000f * Math.PI) * Main.rand.Next(800, 1200) / 1000f;
            Projectile.NewProjectile(position.X + speedX, position.Y + speedY, v.X, v.Y, 336, damage, knockBack, player.whoAmI, 1f);
            v = new Vector2(speedX, speedY).RotatedBy(Main.rand.Next(-100, 100) / 1000f * Math.PI) * Main.rand.Next(800, 1200) / 1000f;
            Projectile.NewProjectile(position.X + speedX, position.Y + speedY, v.X, v.Y, 336, damage, knockBack, player.whoAmI, 1f);
            v = new Vector2(speedX / 1.8f, speedY / 1.8f).RotatedBy(Main.rand.Next(-100, 100) / 10000f * Math.PI) * Main.rand.Next(800, 1200) / 1000f;
            Projectile.NewProjectile((float)position.X + speedX, position.Y + speedY, v.X, v.Y, 337, (int)damage, (float)knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(1930, 5);
            modRecipe.AddIngredient(null, "SoulOfPine", 100);
            modRecipe.requiredTile[0] = 412;
            modRecipe.Register();
        }
    }
}
