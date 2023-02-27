using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.Festivals
{
	public class 白菊 : ModTile
	{
		public override void SetDefaults()
		{
            Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileNoAttach[(int)base.Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                16,
                16
            };
            TileObjectData.newTile.CoordinateWidth = 36;
            TileObjectData.addTile((int)base.Type);
			this.dustType = 3;
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("");
            base.AddMapEntry(new Color(95, 175, 29), modTranslation);
			this.mineResist = 3f;
			base.SetDefaults();
			modTranslation.AddTranslation(GameCulture.Chinese, "");
		}
        public override void NearbyEffects(int i, int j, bool closer)
		{
		}
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 32, base.mod.ItemType("白菊"));
        }
        public override void PlaceInWorld(int i, int j, Item item)
        {
            short num = (short)(Main.rand.Next(0, 4));
            Main.tile[i, j].frameX = (short)(num * 36);
            Main.tile[i, j + 2].frameX = (short)(num * 36);
            Main.tile[i, j + 3].frameX = (short)(num * 36);
            Main.tile[i, j + 1].frameX = (short)(num * 36);
        }
    }
}
