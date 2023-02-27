using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Tiles.Volcano
{
	public class 高阴燃草 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileCut[(int)base.Type] = true;
			Main.tileSolid[(int)base.Type] = false;
			Main.tileNoAttach[(int)base.Type] = true;
			Main.tileNoFail[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			Main.tileWaterDeath[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
            this.dustType = 191;
            this.soundStyle = 1;
			this.soundType = 6;
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            base.AddMapEntry(new Color(127, 111, 144), modTranslation);
			base.SetDefaults();
		}
        public override void PlaceInWorld(int i, int j, Item item)
        {
            short num = (short)(Main.rand.Next(0, 23));
            Main.tile[i, j].frameX = (short)(num * 18);
        }
    }
}
