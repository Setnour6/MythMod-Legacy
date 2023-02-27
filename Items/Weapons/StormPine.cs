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
			Item.staff[base.item.type] = true;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "冰凌雪松");
		}
		public override void SetDefaults()
		{
			base.item.damage = 275;
			base.item.magic = true;
			base.item.mana = 5;
			base.item.width = 56;
			base.item.height = 56;
			base.item.useTime = 3;
			base.item.useAnimation = 3;
			base.item.useStyle = 5;
			base.item.noMelee = true;
			base.item.knockBack = 2.4f;
			base.item.value = 50000;
			base.item.rare = 11;
			base.item.UseSound = SoundID.Item60;
			base.item.autoReuse = true;
            base.item.shoot = 336;
			base.item.shootSpeed = 11f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
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
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(1930, 5);
            modRecipe.AddIngredient(null, "SoulOfPine", 100);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
