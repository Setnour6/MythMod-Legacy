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
	public class DukeTooth : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("公爵之牙");
			// base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "公爵之牙");
            // Tooltip.SetDefault("增加12%暴击和闪避");
            base.Tooltip.AddTranslation(GameCulture.Chinese, "增加12%暴击和闪避");
        }
        public override void SetDefaults()
        {
            base.Item.width = 38;
			base.Item.height = 48;
			base.Item.value = 20000;
			base.Item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.GetCritChance(DamageClass.Ranged) += 12;
            player.GetCritChance(DamageClass.Generic) += 12;
            player.GetCritChance(DamageClass.Magic) += 12;
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.Duke = 2;
        }
	}
}
