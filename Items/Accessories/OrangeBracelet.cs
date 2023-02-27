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
namespace MythMod.Items.Accessories
{
	public class OrangeBracelet : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("沁桔手环");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "沁桔手环");
            Tooltip.SetDefault("增加生命回复速度,免疫绝大多数负面Buff");
            Tooltip.AddTranslation(GameCulture.Chinese, "增加生命回复速度,免疫绝大多数负面Buff");
		}
		public override void SetDefaults()
		{
			base.Item.width = 32;
			base.Item.height = 20;
			base.Item.value = 80000;
			base.Item.accessory = true;
            base.Item.rare = 7;
        }
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.lifeRegen += 17;
            for(int p = 0;p < Main.maxBuffTypes;p++)
            {
                if(Main.debuff[p])
                {
                    player.buffImmune[p] = true;
                }
            }
        }
    }
}
