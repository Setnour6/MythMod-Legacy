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
namespace MythMod.Items.Feathers
{
	public class CorruptFeather : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("腐化魔羽");
			// base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "腐化魔羽");
            // Tooltip.SetDefault("增加0.34速度,⅘秒飞行时间,3%闪避,2%暴击,4防御\n在腐化之地效果翻倍");
		}
		public override void SetDefaults()
		{
			base.Item.width = 34;
			base.Item.height = 40;
			base.Item.value = 1;
            base.Item.rare = 2;
            Item.maxStack = 99;
        }
    }
}
