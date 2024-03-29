﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.玄武岩家具
{
    public class 玄武岩床 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style4x2);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				18
			};
			TileObjectData.addTile((int)base.Type);
			base.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("玄武岩床");
			base.AddMapEntry(new Color(80, 200, 200), modTranslation);
			this.dustType = 15;
			this.disableSmartCursor = true;
			this.adjTiles = new int[]
			{
				79
			};
			this.bed = true;
            modTranslation.AddTranslation(GameCulture.Chinese, "玄武岩床");
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 1;
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
            Item.NewItem(i * 16, j * 16, 64, 32, base.mod.ItemType("BasaltBed"), 1, false, 0, false, false);
		}
		public override void RightClick(int i, int j)
		{
			Player localPlayer = Main.LocalPlayer;
			Tile tile = Main.tile[i, j];
			int num = i - (int)(tile.frameX / 18);
			int num2 = j + 2;
			num += ((tile.frameX >= 72) ? 5 : 2);
			if (tile.frameY % 38 != 0)
			{
				num2--;
			}
			localPlayer.FindSpawn();
			if (localPlayer.SpawnX == num && localPlayer.SpawnY == num2)
			{
				localPlayer.RemoveSpawn();
                Main.NewText(Language.GetTextValue("Mods.MythMod.LCR.玄武岩床.0"), byte.MaxValue, 240, 20, false);
				return;
			}
			if (Player.CheckSpawn(num, num2))
			{
				localPlayer.ChangeSpawn(num, num2);
                Main.NewText(Language.GetTextValue("Mods.MythMod.LCR.玄武岩床.1"), byte.MaxValue, 240, 20, false);
			}
		}
		public override void MouseOver(int i, int j)
		{
			Player localPlayer = Main.LocalPlayer;
			localPlayer.noThrow = 2;
			localPlayer.showItemIcon = true;
            localPlayer.showItemIcon2 = base.mod.ItemType("BasaltBed");
		}
	}
}
