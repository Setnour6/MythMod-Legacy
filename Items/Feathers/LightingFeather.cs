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
	public class LightingFeather : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("雷霆羽");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "雷霆羽");
            Tooltip.SetDefault("增加0.84速度,1.3秒飞行时间,6‰触发雷电,3闪避");
		}
		public override void SetDefaults()
		{
			base.Item.width = 42;
			base.Item.height = 34;
			base.Item.value = 1;
            base.Item.rare = 6;
            Item.maxStack = 99;
        }
    }
}
