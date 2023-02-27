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
	public class GoldBirdFeather : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("金鸟毛");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "金鸟毛");
            Tooltip.SetDefault("装进羽毛槽增加0.15速度,⅔秒飞行时间,10生命,20法力,1%闪避");
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
