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

namespace MythMod.Items.Weapons
{
    public class NightOfPole : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("");
			// base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "极夜封霜");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "");
		}
		public override void SetDefaults()
		{
			base.Item.width = 64;
            base.Item.height = 64;
			base.Item.damage = 190;
			base.Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			base.Item.noMelee = true;
			base.Item.useTurn = true;
			base.Item.noUseGraphic = true;
			base.Item.useAnimation = 19;
			base.Item.useStyle = 5;
			base.Item.useTime = 19;
			base.Item.knockBack = 7.5f;
			base.Item.UseSound = SoundID.Item1;
			base.Item.autoReuse = true;
			base.Item.maxStack = 1;
			base.Item.value = 50000;
			base.Item.rare = 11;
            base.Item.shoot = base.Mod.Find<ModProjectile>("PolarNight").Type;
			base.Item.shootSpeed = 12f;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX * 1.5f, speedY * 1.5f, 343, damage, knockBack, player.whoAmI);
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, Mod.Find<ModProjectile>("PolarNight").Type, damage, knockBack, player.whoAmI);
            for (int i = 0; i < 15; i++)
            {
                Vector2 v = new Vector2(0, 8).RotatedByRandom(Math.PI * 2);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, v.X, v.Y, 344, (int)damage, 1, Main.myPlayer, 0f, 0f);
            }
            return false;
        }
        public override void AddRecipes()
        {
            Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
            modRecipe.AddIngredient(1947, 5);
            modRecipe.AddIngredient(null, "SoulOfFrozen", 100);
            modRecipe.requiredTile[0] = 412;
            modRecipe.Register();
        }
    }
}
