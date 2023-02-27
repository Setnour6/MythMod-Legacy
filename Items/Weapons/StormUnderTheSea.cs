using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
using Terraria.Graphics.Shaders;
namespace MythMod.Items.Weapons
{
	public class StormUnderTheSea : ModItem
	{
		// TODO, count as explosive for demolitionist spawn

		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("渊海风暴");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            item.glowMask = GetGlowMask;
            item.useStyle = 1;
			item.shootSpeed = 27f;
			item.shoot = mod.ProjectileType("StormUnderTheSea");
			item.width = 54;
			item.height = 60;
			item.maxStack = 7;
			item.consumable = true;
			item.UseSound = SoundID.Item1;
			item.useAnimation = 10;
			item.useTime = 10;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.rare = 10;
            item.damage = 462;
            item.autoReuse = true;
        }
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(null, "DarkSeaBar", 7);
            modRecipe.requiredTile[0] = 412;
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
