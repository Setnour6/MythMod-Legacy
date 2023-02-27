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
	public class SolarFeather : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("日耀羽");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "日耀羽");
            Tooltip.SetDefault("增加2速度,3秒飞行时间,100生命,11‰概率引燃敌人,12%闪避,15防御");
		}
		public override void SetDefaults()
		{
			base.Item.width = 22;
			base.Item.height = 42;
			base.Item.value = 1;
            base.Item.rare = 10;
            Item.maxStack = 99;
        }
    }
}
