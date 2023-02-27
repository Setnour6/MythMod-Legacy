using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.Enums;

namespace MythMod.Tiles.Ocean
{
	// Token: 0x02000DD9 RID: 3545
	public class 巨大鹿角珊瑚 : ModTile
	{
		// Token: 0x0600489C RID: 18588 RVA: 0x003496D4 File Offset: 0x003478D4
		public override void SetDefaults()
		{
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileNoAttach[(int)base.Type] = true;
            this.minPick = 300;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
                16,
                22
			};
            TileObjectData.newTile.CoordinateWidth = 90;
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.AnchorTop = default(AnchorData);
            TileObjectData.addTile((int)base.Type);
			this.dustType = 51;
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            base.AddMapEntry(new Color(126, 97, 101), modTranslation);
            modTranslation.SetDefault("");
            this.mineResist = 3f;
			base.SetDefaults();
			modTranslation.AddTranslation(GameCulture.Chinese, "");
		}
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 32, base.mod.ItemType("HugeAcropora"));
        }
        // Token: 0x0600489D RID: 18589 RVA: 0x000138D5 File Offset: 0x00011AD5
        public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
	}
}
