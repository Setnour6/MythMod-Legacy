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
	public class GreenBlood : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("碧血戒");
			base.Tooltip.SetDefault("有10%的概率不会受到伤害,反而改为治愈你");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "碧血戒");
			base.Tooltip.AddTranslation(GameCulture.Chinese, "有10%的概率不会受到伤害,反而改为治愈你,在水中此概率升为20%");
		}
		public override void SetDefaults()
		{
			base.Item.width = 48;
			base.Item.height = 32;
			base.Item.value = 10000;
			base.Item.accessory = true;
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
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.GreenBlood = 5;
            if (player.wet)
            {
                //player.meleeDamage *= 1.17f;
                //player.magicDamage *= 1.17f;
                //player.rangedDamage *= 1.17f;
                //player.minionDamage *= 1.17f;
                //player.thrownDamage *= 1.17f;
            }
        }
	}
}
