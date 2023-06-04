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
	public class StarlightFeather : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("荧星之羽");
			// base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "荧星之羽");
            // Tooltip.SetDefault("增加0.4速度,0.9秒飞行时间,4法力回复,40魔法,2%闪避");
		}
		public override void SetDefaults()
		{
			base.Item.width = 32;
			base.Item.height = 36;
			base.Item.value = 1;
            base.Item.rare = 4;
            Item.maxStack = 99;
        }
    }
}
