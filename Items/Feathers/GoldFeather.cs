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
	public class GoldFeather : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("灿金之羽");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "灿金之羽");
            Tooltip.SetDefault("增加0.27速度,0.8秒飞行时间,3%闪避,30法力,30生命");
		}
		public override void SetDefaults()
		{
			base.Item.width = 28;
			base.Item.height = 36;
			base.Item.value = 1;
            base.Item.rare = 3;
            Item.maxStack = 99;
        }
    }
}
