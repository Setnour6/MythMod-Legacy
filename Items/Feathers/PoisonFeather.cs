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
	public class PoisonFeather : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("毒羽");
			// base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "毒羽");
            // Tooltip.SetDefault("增加0.5速度,0.5秒飞行时间,30生命,2%闪避,攻击2%附带中毒效果");
		}
		public override void SetDefaults()
		{
			base.Item.width = 26;
			base.Item.height = 32;
			base.Item.value = 1;
            base.Item.rare = 5;
            Item.maxStack = 99;
        }
    }
}
