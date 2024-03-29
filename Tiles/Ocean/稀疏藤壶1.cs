﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.Ocean
{
	public class 稀疏藤壶1 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                36,
            };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.CoordinateWidth = 36;
            TileObjectData.addTile((int)base.Type);
			this.dustType = 7;
            this.drop = mod.ItemType("Barnacle");
            this.disableSmartCursor = true;
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("藤壶");
			base.AddMapEntry(new Color(178, 178 ,138), modTranslation);
			modTranslation.AddTranslation(GameCulture.Chinese, "藤壶");
		}
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("Barnacle"), 1, false, 0, false, false);
		}
        public override void PlaceInWorld(int i, int j, Item item)
        {
            int num = Main.rand.Next(0, 18) * 2;
            int num2 = Main.rand.Next(0, 18) * 2;
            Main.tile[i, j].frameX = (short)num;
            Main.tile[i, j].frameY = (short)num2;
        }
    }
}
