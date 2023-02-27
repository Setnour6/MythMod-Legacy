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
	public class LazarKnife : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("激光手里剑");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.useStyle = 1;
			item.shootSpeed = 27f;
			item.shoot = mod.ProjectileType("LaserKnife");
			item.width = 54;
			item.height = 60;
			item.maxStack = 999;
			item.consumable = true;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 10;
			item.useTime = 10;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.rare = 6;
            item.damage = 90;
            item.autoReuse = true;
        }
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(null, "LazarBattery", 1);
            modRecipe.AddIngredient(42, 100);
            modRecipe.requiredTile[0] = 134;
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
