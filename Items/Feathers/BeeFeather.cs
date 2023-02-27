﻿using Terraria.ID;
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
	public class BeeFeather : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("蜂之翎");
			base.Tooltip.SetDefault("");
			base.DisplayName.AddTranslation(GameCulture.Chinese, "蜂之翎");
            Tooltip.SetDefault("如果装进饰品栏:增加6%闪避,增加1个召唤栏位\n如果装进羽毛槽:增加3%闪避,1个召唤栏位,0.24速度,⅔秒飞行时间\n神话");//教程是物品介绍
		}
		public override void SetDefaults()
		{
			base.item.width = 40;
			base.item.height = 38;
			base.item.value = 20000;
			base.item.accessory = true;
            item.rare = 2;

        }
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.maxMinions++;
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.BeeFeather = 2;
        }
	}
}