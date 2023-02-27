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
	public class VoidFeather : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("虚空幻羽");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "虚空幻羽");
            Tooltip.SetDefault("增加1.1速度,2.4秒飞行时间,10%闪避");
		}
		public override void SetDefaults()
		{
			base.Item.width = 18;
			base.Item.height = 44;
			base.Item.value = 1;
            base.Item.rare = 8;
            Item.maxStack = 99;
        }
    }
}
