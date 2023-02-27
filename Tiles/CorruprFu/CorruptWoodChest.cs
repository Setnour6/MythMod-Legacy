using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.CorruprFu
{
	public class CorruptWoodChest : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSpelunker[(int)base.Type] = true;
			Main.tileContainer[(int)base.Type] = true;
			Main.tileShine2[(int)base.Type] = true;
			Main.tileShine[(int)base.Type] = 1200;
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileNoAttach[(int)base.Type] = true;
			Main.tileOreFinderPriority[(int)base.Type] = 500;
			TileID.Sets.HasOutlines[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
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
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("缠藻箱");
			base.AddMapEntry(new Color(191, 142, 111), modTranslation, new Func<string, int, int, string>(this.MapChestName));
			this.disableSmartCursor/* tModPorter Note: Removed. Use TileID.Sets.DisableSmartCursor instead */ = true;
			this.AdjTiles = new int[]
			{
				21
			};
			this.chest/* tModPorter Note: Removed. Use ContainerName.SetDefault() and TileID.Sets.BasicChest instead */ = "缠藻箱";
			this.ChestDrop = base.Mod.Find<ModItem>("CorruptWoodChest").Type;
			modTranslation.AddTranslation(GameCulture.Chinese, "缠藻箱");
		}
		public override bool CreateDust(int i, int j, ref int type)
		{
			Dust.NewDust(new Vector2((float)i, (float)j) * 16f, 16, 16, 1, 0f, 0f, 1, new Color(100, 130, 150), 1f);
			return false;
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
		public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
		{
			return true;
		}
		public string MapChestName(string name, int i, int j)
		{
			int num = i;
			int num2 = j;
			Tile tile = Main.tile[i, j];
			if (tile.TileFrameX % 36 != 0)
			{
				num--;
			}
			if (tile.TileFrameY != 0)
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
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 32, this.ChestDrop, 1, false, 0, false, false);
			Chest.DestroyChest(i, j);
		}
		public override void RightClick(int i, int j)
		{
			Player localPlayer = Main.LocalPlayer;
			Tile tile = Main.tile[i, j];
			Main.mouseRightRelease = false;
			int num = i;
			int num2 = j;
			if (tile.TileFrameX % 36 != 0)
			{
				num--;
			}
			if (tile.TileFrameY != 0)
			{
				num2--;
			}
			if (localPlayer.sign >= 0)
			{
				SoundEngine.PlaySound(SoundID.MenuClose);
				localPlayer.sign = -1;
				Main.editSign = false;
				Main.npcChatText = "";
			}
			if (Main.editChest)
			{
				SoundEngine.PlaySound(SoundID.MenuTick);
				Main.editChest = false;
				Main.npcChatText = "";
			}
			if (localPlayer.editedChestName)
			{
				NetMessage.SendData(33, -1, -1, NetworkText.FromLiteral(Main.chest[localPlayer.chest].name), localPlayer.chest, 1f, 0f, 0f, 0, 0, 0);
				localPlayer.editedChestName = false;
			}
			if (Main.netMode != 1)
			{
				int num3 = Chest.FindChest(num, num2);
				if (num3 >= 0)
				{
					Main.stackSplit = 600;
					if (num3 == localPlayer.chest)
					{
						localPlayer.chest = -1;
						SoundEngine.PlaySound(SoundID.MenuClose);
					}
					else
					{
						localPlayer.chest = num3;
						Main.playerInventory = true;
						Main.recBigList = false;
						localPlayer.chestX = num;
						localPlayer.chestY = num2;
						SoundEngine.PlaySound((localPlayer.chest < 0) ? 10 : 12, -1, -1, 1, 1f, 0f);
					}
					Recipe.FindRecipes();
				}
				return;
			}
			if (num == localPlayer.chestX && num2 == localPlayer.chestY && localPlayer.chest >= 0)
			{
				localPlayer.chest = -1;
				Recipe.FindRecipes();
				SoundEngine.PlaySound(SoundID.MenuClose);
				return;
			}
			NetMessage.SendData(31, -1, -1, null, num, (float)num2, 0f, 0f, 0, 0, 0);
			Main.stackSplit = 600;
		}
		public override void MouseOver(int i, int j)
		{
			Player localPlayer = Main.LocalPlayer;
			Tile tile = Main.tile[i, j];
			int num = i;
			int num2 = j;
			if (tile.TileFrameX % 36 != 0)
			{
				num--;
			}
			if (tile.TileFrameY != 0)
			{
				num2--;
			}
			int num3 = Chest.FindChest(num, num2);
			localPlayer.cursorItemIconID = -1;
			if (num3 < 0)
			{
				localPlayer.cursorItemIconText = Language.GetTextValue("LegacyChestType.0");
			}
			else
			{
				localPlayer.cursorItemIconText = ((Main.chest[num3].name.Length > 0) ? Main.chest[num3].name : "缠藻箱");
				if (localPlayer.cursorItemIconText == "缠藻箱")
				{
					localPlayer.cursorItemIconID = base.Mod.Find<ModItem>("CorruptWoodChest").Type;
					localPlayer.cursorItemIconText = "";
				}
			}
			localPlayer.noThrow = 2;
			localPlayer.cursorItemIconEnabled = true;
		}
		public override void MouseOverFar(int i, int j)
		{
			this.MouseOver(i, j);
			Player localPlayer = Main.LocalPlayer;
			if (localPlayer.cursorItemIconText == "")
			{
				localPlayer.cursorItemIconEnabled = false;
				localPlayer.cursorItemIconID = 0;
			}
		}
	}
}
