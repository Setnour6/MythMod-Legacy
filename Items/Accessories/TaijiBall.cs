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
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;
namespace MythMod.Items.Accessories
{
	public class TaijiBall : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("太极球");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "太极球");
            Tooltip.SetDefault("阴阳寿命复活消耗的寿命变为各5点");
		}
		public override void SetDefaults()
		{
			base.item.width = 50;
			base.item.height = 100;
            base.item.rare = 6;
            base.item.value = 10000;
			base.item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.YinYangRe = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(527, 5);
            recipe.AddIngredient(528, 5);
            recipe.AddIngredient(520, 5);
            recipe.AddIngredient(521, 5);
            recipe.requiredTile[0] = 13;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}