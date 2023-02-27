using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles
{
	// Token: 0x02000EAA RID: 3754
    public class BOC宝藏箱2 : ModTile
	{
		// Token: 0x06004652 RID: 18002 RVA: 0x0027C814 File Offset: 0x0027AA14
		public override void SetStaticDefaults()
		{
			Main.tileSpelunker[(int)base.Type] = true;
			Main.tileContainer[(int)base.Type] = true;
			Main.tileShine2[(int)base.Type] = true;
			Main.tileShine[(int)base.Type] = 1200;
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileNoAttach[(int)base.Type] = true;
			Main.tileOreFinderPriority[(int)base.Type] = 575;
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
			TileObjectData.addTile((int)base.Type);
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("克苏鲁之脑宝藏箱 ");
			base.AddMapEntry(new Color(247, 145, 156), modTranslation, new Func<string, int, int, string>(this.MapChestName));
			this.DustType = 155;
			this.disableSmartCursor/* tModPorter Note: Removed. Use TileID.Sets.DisableSmartCursor instead */ = true;
			this.AdjTiles = new int[]
			{
				21
			};
            this.chest/* tModPorter Note: Removed. Use ContainerName.SetDefault() and TileID.Sets.BasicChest instead */ = "克苏鲁之脑宝藏箱";
            this.ChestDrop = base.Mod.Find<ModItem>("BOCChest2").Type;
            modTranslation.AddTranslation(GameCulture.Chinese, "克苏鲁之脑宝藏箱 ");
		}

		// Token: 0x06004653 RID: 18003 RVA: 0x0027286C File Offset: 0x00270A6C
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

		// Token: 0x06004654 RID: 18004 RVA: 0x00012DBC File Offset: 0x00010FBC
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 1;
		}

		// Token: 0x06004655 RID: 18005 RVA: 0x002728E0 File Offset: 0x00270AE0
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 32, this.ChestDrop, 1, false, 0, false, false);
			Chest.DestroyChest(i, j);
		}

		// Token: 0x06004656 RID: 18006 RVA: 0x00272914 File Offset: 0x00270B14
		public override void RightClick(int i, int j)
		{
			Player player = Main.player[Main.myPlayer];
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
			if (player.sign >= 0)
			{
				SoundEngine.PlaySound(SoundID.MenuClose);
				player.sign = -1;
				Main.editSign = false;
				Main.npcChatText = "";
			}
			if (Main.editChest)
			{
				SoundEngine.PlaySound(SoundID.MenuTick);
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
						SoundEngine.PlaySound(SoundID.MenuClose);
					}
					else
					{
						player.chest = num3;
						Main.playerInventory = true;
						Main.recBigList = false;
						player.chestX = num;
						player.chestY = num2;
						SoundEngine.PlaySound((player.chest < 0) ? 10 : 12, -1, -1, 1, 1f, 0f);
					}
					Recipe.FindRecipes();
				}
				return;
			}
			if (num == player.chestX && num2 == player.chestY && player.chest >= 0)
			{
				player.chest = -1;
				Recipe.FindRecipes();
				SoundEngine.PlaySound(SoundID.MenuClose);
				return;
			}
			NetMessage.SendData(31, -1, -1, null, num, (float)num2, 0f, 0f, 0, 0, 0);
			Main.stackSplit = 600;
		}

		// Token: 0x06004657 RID: 18007 RVA: 0x0027C9E0 File Offset: 0x0027ABE0
		public override void MouseOver(int i, int j)
		{
			Player player = Main.player[Main.myPlayer];
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
			player.cursorItemIconID = -1;
			if (num3 < 0)
			{
				player.cursorItemIconText = Lang.chestType[0].Value;//123465
			}
			else
			{
                player.cursorItemIconText = ((Main.chest[num3].name.Length > 0) ? Main.chest[num3].name : "克苏鲁之脑宝藏箱 ");
                if (player.cursorItemIconText == "克苏鲁之脑宝藏箱")
				{
                    player.cursorItemIconID = base.Mod.Find<ModItem>("BOCChest").Type;
					player.cursorItemIconText = "";
				}
			}
			player.noThrow = 2;
			player.cursorItemIconEnabled = true;
		}

		// Token: 0x06004658 RID: 18008 RVA: 0x00272BDC File Offset: 0x00270DDC
		public override void MouseOverFar(int i, int j)
		{
			this.MouseOver(i, j);
			Player player = Main.player[Main.myPlayer];
			if (player.cursorItemIconText == "")
			{
				player.cursorItemIconEnabled = false;
				player.cursorItemIconID = 0;
			}
		}
	}
}
