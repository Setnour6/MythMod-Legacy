using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.Enums;

namespace MythMod.Tiles.Ocean
{
	public class 大金柳珊瑚 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileNoAttach[(int)base.Type] = true;
            this.minPick = 300;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.Height = 7;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
                16,
                16,
                16,
                16,
                16,
                18
			};
            TileObjectData.newTile.CoordinateWidth = 90;
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.AnchorTop = default(AnchorData);
            TileObjectData.addTile((int)base.Type);
			this.dustType = 64;
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            base.AddMapEntry(new Color(255, 153, 0), modTranslation);
            modTranslation.SetDefault("");
            this.mineResist = 3f;
			base.SetDefaults();
			modTranslation.AddTranslation(GameCulture.Chinese, "");
		}
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 32, base.mod.ItemType("LargeGoldGorgonian"));
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
        public override void PlaceInWorld(int i, int j, Item item)
        {
            short num = (short)(Main.rand.Next(0, 4));
            Main.tile[i, j].frameX = (short)(num * 90);
            Main.tile[i, j + 6].frameX = (short)(num * 90);
            Main.tile[i, j + 5].frameX = (short)(num * 90);
            Main.tile[i, j + 4].frameX = (short)(num * 90);
            Main.tile[i, j + 3].frameX = (short)(num * 90);
            Main.tile[i, j + 2].frameX = (short)(num * 90);
            Main.tile[i, j + 1].frameX = (short)(num * 90);
        }
    }
}
