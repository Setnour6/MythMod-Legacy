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
	public class RainbowFeather : ModItem
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("彩虹之羽");
			// base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "彩虹之羽");
            // Tooltip.SetDefault("增加0.7速度,0.8秒飞行时间,10生命,10法力,1生命回复, 1法力回复,1%暴击,1%闪避,2防御,1%伤害");
		}
		public override void SetDefaults()
		{
			base.Item.width = 30;
			base.Item.height = 32;
			base.Item.value = 1;
            base.Item.rare = 2;
            Item.maxStack = 99;
        }
    }
}
