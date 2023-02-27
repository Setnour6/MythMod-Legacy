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
	public class RedBirdFeather : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("红雀毛");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "红雀毛");
            Tooltip.SetDefault("增加0.1速度,⅓秒飞行时间,10生命");
		}
		public override void SetDefaults()
		{
			base.item.width = 14;
			base.item.height = 30;
			base.item.value = 1;
            base.item.rare = 0;
            item.maxStack = 99;
        }
    }
}
