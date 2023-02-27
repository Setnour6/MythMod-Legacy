﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles
{
    public class ML宝藏箱2 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSpelunker[(int)base.Type] = true;
			Main.tileContainer[(int)base.Type] = true;
			Main.tileShine2[(int)base.Type] = true;
			Main.tileShine[(int)base.Type] = 1200;
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileNoAttach[(int)base.Type] = true;
			Main.tileValue[(int)base.Type] = 575;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.newTile.HookCheck = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.FindEmptyChest), -1, 0, true);
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.AfterPlacement_Hook), -1, 0, false);
			TileObjectData.newTile.AnchorInvalidTiles = new int[]
			{
				127
			};
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile((int)base.Type);
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("月亮领主宝藏箱 ");
			base.AddMapEntry(new Color(0, 0, 225), modTranslation, new Func<string, int, int, string>(this.MapChestName));
			this.dustType = 155;
			this.disableSmartCursor = true;
			this.adjTiles = new int[]
			{
				21
			};
            this.chest = "月亮领主宝藏箱";
            this.chestDrop = base.mod.ItemType("MLChest2");
            modTranslation.AddTranslation(GameCulture.Chinese, "月亮领主宝藏箱 ");
		}
		public string MapChestName(string name, int i, int j)
		{
			int num = i;
			int num2 = j;
			Tile tile = Main.tile[i, j];
			if (tile.frameX % 36 != 0)
			{
				num--;
			}
			if (tile.frameY != 0)
			{
				num2--;
			}
			int num3 = Chest.FindChest(num, num2);
			if (Main.chest[num3].name == "")
			{
				return name;
			}
			return name + ": " + Main.chest[num3].name;
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 1;
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 32, this.chestDrop, 1, false, 0, false, false);
			Chest.DestroyChest(i, j);
		}
		public override void RightClick(int i, int j)
		{
            Player player = Main.player[Main.myPlayer];
            Tile tile = Main.tile[i, j];
            Main.mouseRightRelease = false;
            int num = i;
            int num2 = j;
            if (tile.frameX % 36 != 0)
            {
                num--;
            }
            if (tile.frameY != 0)
            {
                num2--;
            }
            if (player.sign >= 0)
            {
                Main.PlaySound(11, -1, -1, 1, 1f, 0f);
                player.sign = -1;
                Main.editSign = false;
                Main.npcChatText = "";
            }
            if (Main.editChest)
            {
                Main.PlaySound(12, -1, -1, 1, 1f, 0f);
                Main.editChest = false;
                Main.npcChatText = "";
            }
            if (player.editedChestName)
            {
                NetMessage.SendData(33, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f, 0f, 0f, 0, 0, 0);
                player.editedChestName = false;
            }
            if (Main.netMode != 1)
            {
                int num3 = Chest.FindChest(num, num2);
                if (num3 >= 0)
                {
                    Main.stackSplit = 600;
                    if (num3 == player.chest)
                    {
                        player.chest = -1;
                        Main.PlaySound(11, -1, -1, 1, 1f, 0f);
                    }
                    else
                    {
                        player.chest = num3;
                        Main.playerInventory = true;
                        Main.recBigList = false;
                        player.chestX = num;
                        player.chestY = num2;
                        Main.PlaySound((player.chest < 0) ? 10 : 12, -1, -1, 1, 1f, 0f);
                    }
                    Recipe.FindRecipes();
                }
                return;
            }
            if (num == player.chestX && num2 == player.chestY && player.chest >= 0)
            {
                player.chest = -1;
                Recipe.FindRecipes();
                Main.PlaySound(11, -1, -1, 1, 1f, 0f);
                return;
            }
            NetMessage.SendData(31, -1, -1, null, num, (float)num2, 0f, 0f, 0, 0, 0);
            Main.stackSplit = 600;
        }
		public override void MouseOver(int i, int j)
		{
			Player player = Main.player[Main.myPlayer];
			Tile tile = Main.tile[i, j];
			int num = i;
			int num2 = j;
			if (tile.frameX % 36 != 0)
			{
				num--;
			}
			if (tile.frameY != 0)
			{
				num2--;
			}
			int num3 = Chest.FindChest(num, num2);
			player.showItemIcon2 = -1;
			if (num3 < 0)
			{
				player.showItemIconText = Lang.chestType[0].Value;//213456
			}
			else
			{
                player.showItemIconText = ((Main.chest[num3].name.Length > 0) ? Main.chest[num3].name : "月亮领主宝藏箱 ");
                if (player.showItemIconText == "月亮领主宝藏箱")
				{
                    player.showItemIcon2 = base.mod.ItemType("MLChest");
					player.showItemIconText = "";
				}
			}
			player.noThrow = 2;
			player.showItemIcon = true;
		}
		public override void MouseOverFar(int i, int j)
		{
			this.MouseOver(i, j);
			Player player = Main.player[Main.myPlayer];
			if (player.showItemIconText == "")
			{
				player.showItemIcon = false;
				player.showItemIcon2 = 0;
			}
		}
	}
}
