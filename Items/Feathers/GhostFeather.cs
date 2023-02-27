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
	public class GhostFeather : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("幽冥羽");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "幽冥羽");
            Tooltip.SetDefault("增加1速度,1.8秒飞行时间,7%暴击,5%闪避");
		}
		public override void SetDefaults()
		{
			base.item.width = 28;
			base.item.height = 36;
			base.item.value = 1;
            base.item.rare = 7;
            item.maxStack = 99;
        }
    }
}
