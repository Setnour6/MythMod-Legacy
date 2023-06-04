﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.Foods
{
	public class 炭烧生蚝 : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileLighted[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			Main.tileWaterDeath[(int)base.Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16
			};
            TileObjectData.newTile.CoordinateWidth = 32;
            TileObjectData.addTile((int)base.Type);
			LocalizedText modTranslation = base.CreateMapEntryName(null);
			// modTranslation.SetDefault("炭烧生蚝");
            base.AddMapEntry(new Color(242, 141, 0), modTranslation);
            base.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
			this.disableSmartCursor/* tModPorter Note: Removed. Use TileID.Sets.DisableSmartCursor instead */ = true;
			this.AdjTiles = new int[]
			{
				4
			};
			this.ItemDrop/* tModPorter Note: Removed. Tiles and walls will drop the item which places them automatically. Use RegisterItemDrop to alter the automatic drop if necessary. */ = base.Mod.Find<ModItem>("炭烧生蚝").Type;
			modTranslation.AddTranslation(GameCulture.Chinese, "炭烧生蚝");
		}
        public override void NearbyEffects(int i, int j, bool closer)
        {
            Player player = Main.player[Main.myPlayer];
            player.AddBuff(Mod.Find<ModBuff>("海的味道I").Type, 20);
            player.AddBuff(Mod.Find<ModBuff>("热乎乎的美味I").Type, 20);
        }
        public override bool CreateDust(int i, int j, ref int type)
		{
			Dust.NewDust(new Vector2((float)i, (float)j) * 16f, 16, 16, 93, 0f, 0f, 1, new Color(100, 130, 150), 1f);
			return false;
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
        public override void PlaceInWorld(int i, int j, Item item)
        {
            short num = (short)(Main.rand.Next(0, 4));
            Main.tile[i, j].TileFrameX = (short)(num * 32);
        }
    }
}
