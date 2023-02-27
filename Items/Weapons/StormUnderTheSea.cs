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
            Item.glowMask = GetGlowMask;
            Item.useStyle = 1;
			Item.shootSpeed = 27f;
			Item.shoot = Mod.Find<ModProjectile>("StormUnderTheSea").Type;
			Item.width = 54;
			Item.height = 60;
			Item.maxStack = 7;
			Item.consumable = true;
			Item.UseSound = SoundID.Item1;
			Item.useAnimation = 10;
			Item.useTime = 10;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = 10;
            Item.damage = 462;
            Item.autoReuse = true;
        }
		public override void AddRecipes()
		{
			Recipe modRecipe = /* base */Recipe.Create(this.Type, 1);
			modRecipe.AddIngredient(null, "DarkSeaBar", 7);
            modRecipe.requiredTile[0] = 412;
			modRecipe.Register();
		}
	}
}
