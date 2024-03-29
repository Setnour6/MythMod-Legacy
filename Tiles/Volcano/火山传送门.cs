﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.Volcano
{
	public class 火山传送门 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Height = 8;
            TileObjectData.newTile.Width = 8;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                16,
                16,
                16,
                16,
                16,
                16
            };
            this.minPick = 500;
            TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.addTile((int)base.Type);
			this.dustType = 7;
			this.disableSmartCursor = true;
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("火山传送门");
			base.AddMapEntry(new Color(0, 0, 0), modTranslation);
			modTranslation.AddTranslation(GameCulture.Chinese, "火山传送门");
		}
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("火山传送门"), 1, false, 0, false, false);
		}
	}
}
