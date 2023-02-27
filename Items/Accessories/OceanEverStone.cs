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
	public class OceanEverStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("海恒石");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "海恒石");
            Tooltip.SetDefault("坚定如海,永恒不变");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "坚定如海,永恒不变\n增加10防御,并提升回血速度");
        }
        public override void SetDefaults()
        {
            base.Item.width = 38;
			base.Item.height = 34;
			base.Item.value = 20000;
			base.Item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statDefense += 10;
            player.lifeRegen += 10;
        }
	}
}
