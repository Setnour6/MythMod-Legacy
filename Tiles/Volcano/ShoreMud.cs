using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Capture;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Tiles.Volcano
{
    public class ShoreMud : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileMergeDirt[(int)base.Type] = true;
			Main.tileBlendAll[(int)base.Type] = true;
			Main.tileBlockLight[(int)base.Type] = true;
			Main.tileShine2[(int)base.Type] = false;
			Main.tileValue[(int)base.Type] = 0;
			this.dustType = 6;
			this.minPick = 0;
			this.soundType = 21;
			this.soundStyle = 2;
            this.drop = base.mod.ItemType("ShoreMud");
			Main.tileSpelunker[(int)base.Type] = true;
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("");
			base.AddMapEntry(new Color(127, 30, 49), modTranslation);
            modTranslation.AddTranslation(GameCulture.Chinese, "");
            SetModTree(new RedTree());
        }
        public override int SaplingGrowthType(ref int style)
        {
            style = 0;
            return mod.TileType("RedTreeSapling");
        }
        public override void RandomUpdate(int i, int j)
        {
            if(!Main.tile[i, j - 1].active())
            {
                switch (Main.rand.Next(1, 4))
                {
                    case 1:
                        WorldGen.PlaceTile(i, j - 1, mod.TileType("RedTreeSapling"));
                        break;
                    case 2:
                        WorldGen.PlaceTile(i, j - 1, mod.TileType("GasRoot"));
                        short num = (short)(Main.rand.Next(0, 6) * 18);
                        Main.tile[i, j - 2].frameX = num;
                        Main.tile[i, j - 1].frameX = num;
                        break;
                    case 3:
                        WorldGen.PlaceTile(i, j - 2, mod.TileType("Shoregrass1"));
                        short num1 = (short)(Main.rand.Next(0, 6) * 36);
                        Main.tile[i, j - 2].frameX = num1;
                        Main.tile[i, j - 1].frameX = num1;
                        break;
                }
            }
            base.RandomUpdate(i, j);
        }
    }
}
