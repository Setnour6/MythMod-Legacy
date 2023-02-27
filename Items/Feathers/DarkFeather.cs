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
	public class DarkFeather : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("暗夜幽羽");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "暗夜幽羽");
            Tooltip.SetDefault("增加0.16速度,½秒飞行时间,3%暴击,2%闪避");
		}
		public override void SetDefaults()
		{
			base.item.width = 14;
			base.item.height = 34;
			base.item.value = 1;
            base.item.rare = 1;
            item.maxStack = 99;
        }
    }
}
