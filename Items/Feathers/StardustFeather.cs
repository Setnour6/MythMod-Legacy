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
	public class StardustFeather : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("星尘羽");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "星尘羽");
            Tooltip.SetDefault("增加2速度,3秒飞行时间,100魔法,5个召唤栏位,12%闪避");
		}
		public override void SetDefaults()
		{
			base.item.width = 22;
			base.item.height = 46;
			base.item.value = 1;
            base.item.rare = 10;
            item.maxStack = 99;
        }
    }
}
