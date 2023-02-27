using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.玄武岩家具
{
	// Token: 0x02000CB8 RID: 3256
	public class 玄武岩门Closed : ModTile
	{
		// Token: 0x0600417C RID: 16764 RVA: 0x0032C0C4 File Offset: 0x0032A2C4
		public override void SetDefaults()
		{
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileBlockLight[(int)base.Type] = true;
			Main.tileSolid[(int)base.Type] = true;
			Main.tileNoAttach[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			Main.tileWaterDeath[(int)base.Type] = false;
			TileID.Sets.NotReallySolid[(int)base.Type] = true;
			TileID.Sets.DrawsWalls[(int)base.Type] = true;
			TileID.Sets.HasOutlines[(int)base.Type] = true;
			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(0, 0);
			TileObjectData.newTile.AnchorTop = new AnchorData((Terraria.Enums.AnchorType)1, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.AnchorBottom = new AnchorData((Terraria.Enums.AnchorType)1, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = new Point16(0, 1);
			TileObjectData.addAlternate(0);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = new Point16(0, 2);
			TileObjectData.addAlternate(0);
			TileObjectData.addTile((int)base.Type);
			base.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("玄武岩门");
			base.AddMapEntry(new Color(191, 142, 111), modTranslation);
			this.disableSmartCursor = true;
			this.adjTiles = new int[]
			{
				10
			};
			this.openDoorID = base.mod.TileType("玄武岩门Open");
			modTranslation.AddTranslation(GameCulture.Chinese, "玄武岩门");
		}

		// Token: 0x0600417D RID: 16765 RVA: 0x0032AD68 File Offset: 0x00328F68
		public override bool CreateDust(int i, int j, ref int type)
		{
			Dust.NewDust(new Vector2((float)i, (float)j) * 16f, 16, 16, 6, 0f, 0f, 1, Color.White, 1f);
			return false;
		}

		// Token: 0x0600417E RID: 16766 RVA: 0x000138D5 File Offset: 0x00011AD5
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}

		// Token: 0x0600417F RID: 16767 RVA: 0x00003A42 File Offset: 0x00001C42
		public override bool HasSmartInteract()
		{
			return true;
		}

		// Token: 0x06004180 RID: 16768 RVA: 0x0032C2BC File Offset: 0x0032A4BC
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 16, 48, base.mod.ItemType("BasaltDoor"), 1, false, 0, false, false);
		}

		// Token: 0x06004181 RID: 16769 RVA: 0x0032C2F0 File Offset: 0x0032A4F0
		public override void MouseOver(int i, int j)
		{
			Player localPlayer = Main.LocalPlayer;
			localPlayer.noThrow = 2;
			localPlayer.showItemIcon = true;
			localPlayer.showItemIcon2 = base.mod.ItemType("BasaltDoor");
		}
	}
}
