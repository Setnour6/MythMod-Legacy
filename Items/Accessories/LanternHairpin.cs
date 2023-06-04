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
	public class LanternHairpin : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("红灯笼发钗");
			// base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "红灯笼发钗");
            // Tooltip.SetDefault("增加4个召唤栏位");
            Tooltip.AddTranslation(GameCulture.Chinese, "增加4个召唤栏位");
            GetGlowMask = MythMod.SetStaticDefaultsGlowMask(this);
        }
        public static short GetGlowMask = 0;
        public override void SetDefaults()
        {
            Item.glowMask = GetGlowMask;
            base.Item.width = 40;
			base.Item.height = 38;
			base.Item.value = 20000;
			base.Item.accessory = true;
            base.Item.rare = 7;
        }
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions += 4;
		}
    }
}
