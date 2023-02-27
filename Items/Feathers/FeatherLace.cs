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
			base.DisplayName.SetDefault("羽毛挂饰");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "羽毛挂饰");
            Tooltip.SetDefault("增加3%闪避");
		}
		public override void SetDefaults()
		{
			base.item.width = 40;
			base.item.height = 38;
			base.item.value = 1000;
            base.item.rare = 0;
            base.item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions++;
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.Fea = 2;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(320, 3);
            recipe.requiredTile[0] = 13;
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
