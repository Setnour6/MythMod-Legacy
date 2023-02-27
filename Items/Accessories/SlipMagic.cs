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
	public class SlipMagic : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("滑脱护符");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "滑脱护符");
            Tooltip.SetDefault("增加8%闪避\n神话");//教程是物品介绍
		}
		public override void SetDefaults()
		{
			base.Item.width = 40;
			base.Item.height = 38;
			base.Item.value = 20000;
			base.Item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.Slip = 2;
        }
	}
}
