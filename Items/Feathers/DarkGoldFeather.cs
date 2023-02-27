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
	public class DarkGoldFeather : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("暗金羽");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "暗金羽");
            Tooltip.SetDefault("增加1.3速度,3秒飞行时间,4%暴击,4%闪避,1%吸血率");
		}
		public override void SetDefaults()
		{
			base.item.width = 26;
			base.item.height = 26;
			base.item.value = 1;
            base.item.rare = 7;
            item.maxStack = 99;
        }
    }
}
