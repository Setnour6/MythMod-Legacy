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
            item.maxStack = 999;
            item.consumable = true;
            item.width = 24;
            item.height = 24;
            item.rare = 9;
            item.expert = true;
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
                    type = mod.ItemType("DarkStaff");
                    break;
                case 2:
                    type = mod.ItemType("EvilBomb");
                    break;
                case 3:
                    type = mod.ItemType("EvilRing");
                    break;
                case 4:
                    type = mod.ItemType("EvilSlingshot");
                    break;
                case 5:
                    type = mod.ItemType("EvilSword");
                    break;
                case 6:
                    type = mod.ItemType("ShadowYoyo");
                    break;
                case 7:
                    type = mod.ItemType("EvilShadowBlade");
                    break;
                case 8:
                    type = mod.ItemType("GeometryEvil");
                    break;
            }
            player.QuickSpawnItem(type, 1);
        }
	}
}
