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
	public class BirdFeather : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("鸟毛");
			// base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "鸟毛");
            // Tooltip.SetDefault("增加0.1速度,⅓秒飞行时间");
		}
		public override void SetDefaults()
		{
			base.Item.width = 14;
			base.Item.height = 30;
			base.Item.value = 1;
            base.Item.rare = 0;
            Item.maxStack = 99;
        }
    }
}
