using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.CorruprFu
{
	public class CorruptDoorOpen : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileSolid[(int)base.Type] = false;
			Main.tileLavaDeath[(int)base.Type] = true;
			Main.tileWaterDeath[(int)base.Type] = false;
			Main.tileNoSunLight[(int)base.Type] = true;
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Origin = new Point16(0, 0);
			TileObjectData.newTile.AnchorTop = new AnchorData((Terraria.Enums.AnchorType)1, 1, 0);
			TileObjectData.newTile.AnchorBottom = new AnchorData((Terraria.Enums.AnchorType)1, 1, 0);
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
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleMultiplier = 2;
			TileObjectData.newTile.StyleWrapLimit = 2;
			TileObjectData.newTile.Direction = (Terraria.Enums.TileObjectDirection)2;
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = new Point16(0, 1);
			TileObjectData.addAlternate(0);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = new Point16(0, 2);
			TileObjectData.addAlternate(0);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = new Point16(1, 0);
			TileObjectData.newAlternate.AnchorTop = new AnchorData((Terraria.Enums.AnchorType)1, 1, 1);
			TileObjectData.newAlternate.AnchorBottom = new AnchorData((Terraria.Enums.AnchorType)1, 1, 1);
			TileObjectData.newAlternate.Direction = (Terraria.Enums.TileObjectDirection)1;
			TileObjectData.addAlternate(1);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = new Point16(1, 1);
			TileObjectData.newAlternate.AnchorTop = new AnchorData((Terraria.Enums.AnchorType)1, 1, 1);
			TileObjectData.newAlternate.AnchorBottom = new AnchorData((Terraria.Enums.AnchorType)1, 1, 1);
			TileObjectData.newAlternate.Direction = (Terraria.Enums.TileObjectDirection)1;
			TileObjectData.addAlternate(1);
			TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
			TileObjectData.newAlternate.Origin = new Point16(1, 2);
			TileObjectData.newAlternate.AnchorTop = new AnchorData((Terraria.Enums.AnchorType)1, 1, 1);
			TileObjectData.newAlternate.AnchorBottom = new AnchorData((Terraria.Enums.AnchorType)1, 1, 1);
			TileObjectData.newAlternate.Direction = (Terraria.Enums.TileObjectDirection)1;
			TileObjectData.addAlternate(1);
			TileObjectData.addTile((int)base.Type);
			base.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
			TileID.Sets.HousingWalls[(int)base.Type] = true;
			TileID.Sets.HasOutlines[(int)base.Type] = true;
			LocalizedText modTranslation = base.CreateMapEntryName(null);
			// modTranslation.SetDefault("朽木门");
			base.AddMapEntry(new Color(191, 142, 111), modTranslation);
			this.disableSmartCursor/* tModPorter Note: Removed. Use TileID.Sets.DisableSmartCursor instead */ = true;
			this.AdjTiles = new int[]
			{
				11
			};
			this.CloseDoorID/* tModPorter Note: Removed. Use TileID.Sets.CloseDoorID instead */ = base.Mod.Find<ModTile>("CorruptDoorClosed").Type;
			modTranslation.AddTranslation(GameCulture.Chinese, "朽木门");
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
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 48, base.Mod.Find<ModItem>("CorruptWoodDoor").Type, 1, false, 0, false, false);
		}
		public override void MouseOver(int i, int j)
		{
			Player localPlayer = Main.LocalPlayer;
			localPlayer.noThrow = 2;
			localPlayer.cursorItemIconEnabled = true;
			localPlayer.cursorItemIconID = base.Mod.Find<ModItem>("CorruptWoodDoor").Type;
		}
	}
}
