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
	public class MothEye : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("蛾眼吊坠");
			// base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "蛾眼吊坠");
            // Tooltip.SetDefault("增加一个召唤栏位");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "增加一个召唤栏位");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.width = 40;
			base.Item.height = 38;
			base.Item.value = 1000;
			base.Item.accessory = true;
            Item.rare = 3;
        }
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions++;
		}
	}
}
