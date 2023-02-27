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
	public class TwilightFeather : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("暮光羽");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "暮光羽");
            Tooltip.SetDefault("增加0.4速度,0.9秒飞行时间,3生命回复,3法力回复,30生命,1%闪避");
		}
		public override void SetDefaults()
		{
			base.item.width = 22;
			base.item.height = 40;
			base.item.value = 1;
            base.item.rare = 4;
            item.maxStack = 99;
        }
    }
}
