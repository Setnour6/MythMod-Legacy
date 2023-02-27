using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Shaders;


namespace MythMod.Items.Accessories
{
	public class WaterStoneHairPin : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("XXX");
			base.Tooltip.SetDefault("XXX");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "水源石头饰");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "水下伤害提升17%");
		}
		public override void SetDefaults()
		{
			base.item.width = 48;
			base.item.height = 32;
			base.item.value = 10000;
			base.item.accessory = true;
            //Player player = Main.player[Main.myPlayer];
            //if (player.name != "万象元素")
            //{
                //base.item.maxStack = 0;
            //}
            //else
            //{
                //base.item.maxStack = 1;
            //}
        }
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            if(player.wet)
            {
                player.meleeDamage *= 1.17f;
                player.magicDamage *= 1.17f;
                player.rangedDamage *= 1.17f;
                player.minionDamage *= 1.17f;
                player.thrownDamage *= 1.17f;
            }
        }
	}
}
