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
namespace MythMod.Items.Feathers
{
	public class FeatherLace : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("羽毛挂饰");
			// base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "羽毛挂饰");
            // Tooltip.SetDefault("增加3%闪避");
		}
		public override void SetDefaults()
		{
			base.Item.width = 40;
			base.Item.height = 38;
			base.Item.value = 1000;
            base.Item.rare = 0;
            base.Item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions++;
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.Fea = 2;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(1);
            recipe.AddIngredient(320, 3);
            recipe.requiredTile[0] = 13;
            recipe.Register();
        }
    }
}
