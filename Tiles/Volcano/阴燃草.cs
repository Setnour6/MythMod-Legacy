using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Tiles.Volcano
{
	public class 阴燃草 : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileCut[(int)base.Type] = true;
			Main.tileSolid[(int)base.Type] = false;
			Main.tileNoAttach[(int)base.Type] = true;
			Main.tileNoFail[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			Main.tileWaterDeath[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
			this.DustType = 191;
			this.soundStyle/* tModPorter Note: Removed. Integrate into HitSound */ = 1;
			this.HitSound = 6;
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            base.AddMapEntry(new Color(127, 111, 144), modTranslation);
			base.SetStaticDefaults();
		}
		public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
		{
			offsetY = 2;
		}
        public override void PlaceInWorld(int i, int j, Item item)
        {
            short num = (short)(Main.rand.Next(0, 23));
            Main.tile[i, j].TileFrameX = (short)(num * 18);
        }
    }
}
