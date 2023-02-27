using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.Foods
{
	public class 爆炒锅 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileLighted[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			Main.tileWaterDeath[(int)base.Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16
			};
            TileObjectData.newTile.CoordinateWidth = 64;
            TileObjectData.addTile((int)base.Type);
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("爆炒锅");
			base.AddMapEntry(new Color(0, 17, 6), modTranslation);
			base.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
			this.disableSmartCursor = true;
			this.adjTiles = new int[]
			{
				4
			};
			modTranslation.AddTranslation(GameCulture.Chinese, "爆炒锅");
		}
		public override bool CreateDust(int i, int j, ref int type)
		{
			Dust.NewDust(new Vector2((float)i, (float)j) * 16f, 16, 16, 53, 0f, 0f, 1, default(Color), 1f);
			return false;
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
        public override void PlaceInWorld(int i, int j, Item item)
        {
            short num = (short)(Main.rand.Next(0, 2));
            Main.tile[i, j].frameX = (short)(num * 64);
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 32, mod.ItemType("爆炒锅"));
        }
    }
}
