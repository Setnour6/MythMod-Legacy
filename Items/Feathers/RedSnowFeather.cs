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
	public class RedSnowFeather : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("雪里红羽");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "雪里红羽");
            Tooltip.SetDefault("增加0.86速度,1秒飞行时间,40生命,15‱概率冰冻敌人,2%闪避,3生命回复");
		}
		public override void SetDefaults()
		{
			base.item.width = 30;
			base.item.height = 32;
			base.item.value = 1;
            base.item.rare = 6;
            item.maxStack = 99;
        }
    }
}
