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
namespace MythMod.Items.Accessories
{
	public class OceanBubble : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("气泡项链");
			// base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "气泡项链");
            // Tooltip.SetDefault("");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "提供水下呼吸");
        }
        public override void SetDefaults()
        {
            base.Item.width = 44;
			base.Item.height = 30;
			base.Item.value = 20000;
			base.Item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.breath = player.breathMax;
        }
	}
}
