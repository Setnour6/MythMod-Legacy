﻿using Terraria.ID;
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
			base.DisplayName.SetDefault("");
			base.Tooltip.SetDefault("");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "极夜封霜");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "");
		}
		public override void SetDefaults()
		{
			base.item.width = 64;
            base.item.height = 64;
			base.item.damage = 190;
			base.item.melee = true;
			base.item.noMelee = true;
			base.item.useTurn = true;
			base.item.noUseGraphic = true;
			base.item.useAnimation = 19;
			base.item.useStyle = 5;
			base.item.useTime = 19;
			base.item.knockBack = 7.5f;
			base.item.UseSound = SoundID.Item1;
			base.item.autoReuse = true;
			base.item.maxStack = 1;
			base.item.value = 50000;
			base.item.rare = 11;
            base.item.shoot = base.mod.ProjectileType("PolarNight");
			base.item.shootSpeed = 12f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position.X, position.Y, speedX * 1.5f, speedY * 1.5f, 343, damage, knockBack, player.whoAmI);
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(0));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("PolarNight"), damage, knockBack, player.whoAmI);
            for (int i = 0; i < 15; i++)
            {
                Vector2 v = new Vector2(0, 8).RotatedByRandom(Math.PI * 2);
                Projectile.NewProjectile(player.Center.X, player.Center.Y, v.X, v.Y, 344, (int)damage, 1, Main.myPlayer, 0f, 0f);
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(base.mod);
            modRecipe.AddIngredient(1947, 5);
            modRecipe.AddIngredient(null, "SoulOfFrozen", 100);
            modRecipe.requiredTile[0] = 412;
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}