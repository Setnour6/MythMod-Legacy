﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.玄武岩家具
{
	public class 玄武岩梳妆台 : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolidTop[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileNoAttach[(int)base.Type] = true;
			Main.tileTable[(int)base.Type] = true;
			Main.tileContainer[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			Main.tileWaterDeath[(int)base.Type] = false;
			TileID.Sets.HasOutlines[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.Origin = new Point16(1, 1);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16
			};
			TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.FindEmptyChest), -1, 0, true);
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(new Func<int, int, int, int, int, int>(Chest.AfterPlacement_Hook), -1, 0, false);
			TileObjectData.newTile.AnchorInvalidTiles = new int[]
			{
				127
			};
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.AnchorBottom = new AnchorData((Terraria.Enums.AnchorType)11, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile((int)base.Type);
			base.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("玄武岩梳妆台");
			base.AddMapEntry(new Color(191, 142, 111), modTranslation);
			this.disableSmartCursor/* tModPorter Note: Removed. Use TileID.Sets.DisableSmartCursor instead */ = true;
			this.AdjTiles = new int[]
			{
				88
			};
			this.dresser/* tModPorter Note: Removed. Use ContainerName.SetDefault() and TileID.Sets.BasicDresser instead */ = "玄武岩梳妆台";
			this.DresserDrop = base.Mod.Find<ModItem>("BasaltDressingtable").Type;
			modTranslation.AddTranslation(GameCulture.Chinese, "玄武岩梳妆台");
		}
		public override bool CreateDust(int i, int j, ref int type)
		{
			Dust.NewDust(new Vector2((float)i, (float)j) * 16f, 16, 16, 1, 0f, 0f, 1, new Color(100, 130, 150), 1f);
			return false;
		}
		public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
		{
			return true;
		}
		public override void RightClick(int i, int j)
		{
			Player localPlayer = Main.LocalPlayer;
			if (Main.tile[Player.tileTargetX, Player.tileTargetY].TileFrameY == 0)
			{
				Main.CancelClothesWindow(true);
				Main.mouseRightRelease = false;
				int num = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].TileFrameX / 18);
				num %= 3;
				num = Player.tileTargetX - num;
				int num2 = Player.tileTargetY - (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].TileFrameY / 18);
				if (localPlayer.sign > -1)
				{
					SoundEngine.PlaySound(SoundID.MenuClose);
					localPlayer.sign = -1;
					Main.editSign = false;
					Main.npcChatText = string.Empty;
				}
				if (Main.editChest)
				{
					SoundEngine.PlaySound(SoundID.MenuTick);
					Main.editChest = false;
					Main.npcChatText = string.Empty;
				}
				if (localPlayer.editedChestName)
				{
					NetMessage.SendData(33, -1, -1, NetworkText.FromLiteral(Main.chest[localPlayer.chest].name), localPlayer.chest, 1f, 0f, 0f, 0, 0, 0);
					localPlayer.editedChestName = false;
				}
				if (Main.netMode == 1)
				{
					if (num == localPlayer.chestX && num2 == localPlayer.chestY && localPlayer.chest != -1)
					{
						localPlayer.chest = -1;
						Recipe.FindRecipes();
						SoundEngine.PlaySound(SoundID.MenuClose);
						return;
					}
					NetMessage.SendData(31, -1, -1, null, num, (float)num2, 0f, 0f, 0, 0, 0);
					Main.stackSplit = 600;
					return;
				}
				else
				{
					localPlayer.flyingPigChest = -1;
					int num3 = Chest.FindChest(num, num2);
					if (num3 != -1)
					{
						Main.stackSplit = 600;
						if (num3 == localPlayer.chest)
						{
							localPlayer.chest = -1;
							Recipe.FindRecipes();
							SoundEngine.PlaySound(SoundID.MenuClose);
						}
						else if (num3 != localPlayer.chest && localPlayer.chest == -1)
						{
							localPlayer.chest = num3;
							Main.playerInventory = true;
							Main.recBigList = false;
							SoundEngine.PlaySound(SoundID.MenuOpen);
							localPlayer.chestX = num;
							localPlayer.chestY = num2;
						}
						else
						{
							localPlayer.chest = num3;
							Main.playerInventory = true;
							Main.recBigList = false;
							SoundEngine.PlaySound(SoundID.MenuTick);
							localPlayer.chestX = num;
							localPlayer.chestY = num2;
						}
						Recipe.FindRecipes();
						return;
					}
				}
			}
			else
			{
				Main.playerInventory = false;
				localPlayer.chest = -1;
				Recipe.FindRecipes();
				Main.interactedDresserTopLeftX = Player.tileTargetX;
				Main.interactedDresserTopLeftY = Player.tileTargetY;
				Main.OpenClothesWindow();
			}
		}
		public override void MouseOverFar(int i, int j)
		{
			Player localPlayer = Main.LocalPlayer;
			Tile tile = Main.tile[Player.tileTargetX, Player.tileTargetY];
			int num = Player.tileTargetX;
			int num2 = Player.tileTargetY;
			num -= (int)(tile.TileFrameX % 54 / 18);
			if (tile.TileFrameY % 36 != 0)
			{
				num2--;
			}
			int num3 = Chest.FindChest(num, num2);
			localPlayer.cursorItemIconID = -1;
			if (num3 < 0)
			{
				localPlayer.cursorItemIconText = Language.GetTextValue("LegacyDresserType.0");
			}
			else
			{
				if (Main.chest[num3].name != "")
				{
					localPlayer.cursorItemIconText = Main.chest[num3].name;
				}
				else
				{
					localPlayer.cursorItemIconText = this.chest/* tModPorter Note: Removed. Use ContainerName.SetDefault() and TileID.Sets.BasicChest instead */;
				}
				if (localPlayer.cursorItemIconText == this.chest/* tModPorter Note: Removed. Use ContainerName.SetDefault() and TileID.Sets.BasicChest instead */)
				{
					localPlayer.cursorItemIconID = base.Mod.Find<ModItem>("BasaltDressingtable").Type;
					localPlayer.cursorItemIconText = "";
				}
			}
			localPlayer.noThrow = 2;
			localPlayer.cursorItemIconEnabled = true;
			if (localPlayer.cursorItemIconText == "")
			{
				localPlayer.cursorItemIconEnabled = false;
				localPlayer.cursorItemIconID = 0;
			}
		}
		public override void MouseOver(int i, int j)
		{
			Player localPlayer = Main.LocalPlayer;
			Tile tile = Main.tile[Player.tileTargetX, Player.tileTargetY];
			int num = Player.tileTargetX;
			int num2 = Player.tileTargetY;
			num -= (int)(tile.TileFrameX % 54 / 18);
			if (tile.TileFrameY % 36 != 0)
			{
				num2--;
			}
			int num3 = Chest.FindChest(num, num2);
			localPlayer.cursorItemIconID = -1;
			if (num3 < 0)
			{
				localPlayer.cursorItemIconText = Language.GetTextValue("LegacyDresserType.0");
			}
			else
			{
				if (Main.chest[num3].name != "")
				{
					localPlayer.cursorItemIconText = Main.chest[num3].name;
				}
				else
				{
					localPlayer.cursorItemIconText = this.chest/* tModPorter Note: Removed. Use ContainerName.SetDefault() and TileID.Sets.BasicChest instead */;
				}
				if (localPlayer.cursorItemIconText == this.chest/* tModPorter Note: Removed. Use ContainerName.SetDefault() and TileID.Sets.BasicChest instead */)
				{
					localPlayer.cursorItemIconID = base.Mod.Find<ModItem>("BasaltDressingtable").Type;
					localPlayer.cursorItemIconText = "";
				}
			}
			localPlayer.noThrow = 2;
			localPlayer.cursorItemIconEnabled = true;
			if (Main.tile[Player.tileTargetX, Player.tileTargetY].TileFrameY > 0)
			{
				localPlayer.cursorItemIconID = 269;
			}
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 48, 32, this.DresserDrop, 1, false, 0, false, false);
			Chest.DestroyChest(i, j);
		}
	}
}
