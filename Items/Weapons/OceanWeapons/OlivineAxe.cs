﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Items.Weapons.OceanWeapons
{
    public class OlivineAxe : ModItem
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("橄榄石斧");
			// base.Tooltip.SetDefault("brush!");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "橄榄石斧");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "");
		}
		public override void SetDefaults()
		{
			base.Item.damage = 176;
			base.Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			base.Item.width = 66;
			base.Item.height = 62;
			base.Item.useTime = 18;
			base.Item.useAnimation = 18;
			base.Item.useTurn = true;
			base.Item.axe = 49;	
			base.Item.useStyle = 1;
			base.Item.knockBack = 9f;
			base.Item.value = 90000;
			base.Item.UseSound = SoundID.Item1;
			base.Item.autoReuse = true;
            base.Item.rare = 11;
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height / 4, Mod.Find<ModDust>("Olivine").Type, 0f, 0f, 0, default(Color), 1f);
			Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height / 2, Mod.Find<ModDust>("Olivine").Type, 0f, 0f, 0, default(Color), 1.8f);
			if (Main.rand.Next(3) == 0)
			{
				int num = Main.rand.Next(3);
				if (num == 0)
				{
					num = Mod.Find<ModDust>("Olivine").Type;
				}
				else if (num == 1)
				{
					num = Mod.Find<ModDust>("Olivine").Type;
				}
				else
				{
					num = Mod.Find<ModDust>("Olivine").Type;
				}
				Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, num, 0f, 0f, 0, default(Color), 1f);
			}
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(null, "Olivine", 7);
            recipe.AddIngredient(null, "GoldGorgonianBranch", 12);
            recipe.requiredTile[0] = 412;
            recipe.Register();
        }
    }
}
