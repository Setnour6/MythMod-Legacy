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
namespace MythMod.Items.TreasureBag
{
    public class EvilBotleTreasureBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
            DisplayName.AddTranslation(GameCulture.Chinese, "宝藏袋");
			Tooltip.AddTranslation(GameCulture.Chinese, "右键点击打开");
		}
        //public override int BossBagNPC => mod.NPCType("EvilBotle");
        public override void SetDefaults()
		{
            Item.maxStack = 999;
            Item.consumable = true;
            Item.width = 24;
            Item.height = 24;
            Item.rare = 9;
            Item.expert = true;
            //this.BossBagNPC = mod.NPCType("EvilBotle");
        }
		public override bool CanRightClick()
		{
			return true;
		}
        public override void RightClick(Player player)
        {
            int type = 0;
            switch (Main.rand.Next(1, 9))
            {
                case 1:
                    type = Mod.Find<ModItem>("DarkStaff").Type;
                    break;
                case 2:
                    type = Mod.Find<ModItem>("EvilBomb").Type;
                    break;
                case 3:
                    type = Mod.Find<ModItem>("EvilRing").Type;
                    break;
                case 4:
                    type = Mod.Find<ModItem>("EvilSlingshot").Type;
                    break;
                case 5:
                    type = Mod.Find<ModItem>("EvilSword").Type;
                    break;
                case 6:
                    type = Mod.Find<ModItem>("ShadowYoyo").Type;
                    break;
                case 7:
                    type = Mod.Find<ModItem>("EvilShadowBlade").Type;
                    break;
                case 8:
                    type = Mod.Find<ModItem>("GeometryEvil").Type;
                    break;
            }
            player.QuickSpawnItem(type, 1);
        }
	}
}
