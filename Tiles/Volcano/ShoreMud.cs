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
		public override void SetStaticDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileMergeDirt[(int)base.Type] = true;
			Main.tileBlendAll[(int)base.Type] = true;
			Main.tileBlockLight[(int)base.Type] = true;
			Main.tileShine2[(int)base.Type] = false;
			Main.tileOreFinderPriority[(int)base.Type] = 0;
			this.DustType = 6;
			this.MinPick = 0;
			this.HitSound = 21;
			this.soundStyle/* tModPorter Note: Removed. Integrate into HitSound */ = 2;
            this.ItemDrop/* tModPorter Note: Removed. Tiles and walls will drop the item which places them automatically. Use RegisterItemDrop to alter the automatic drop if necessary. */ = base.Mod.Find<ModItem>("ShoreMud").Type;
			Main.tileSpelunker[(int)base.Type] = true;
			LocalizedText modTranslation = base.CreateMapEntryName(null);
            // modTranslation.SetDefault("");
			base.AddMapEntry(new Color(127, 30, 49), modTranslation);
            modTranslation.AddTranslation(GameCulture.Chinese, "");
            SetModTree(new RedTree())/* tModPorter Note: Removed. Assign GrowsOnTileId to this tile type in ModTree.SetStaticDefaults instead */;
        }
        public override int SaplingGrowthType(ref int style)/* tModPorter Note: Removed. Use ModTree.SaplingGrowthType */
        {
            style = 0;
            return Mod.Find<ModTile>("RedTreeSapling").Type;
        }
        public override void RandomUpdate(int i, int j)
        {
            if(!Main.tile[i, j - 1].HasTile)
            {
                switch (Main.rand.Next(1, 4))
                {
                    case 1:
                        WorldGen.PlaceTile(i, j - 1, Mod.Find<ModTile>("RedTreeSapling").Type);
                        break;
                    case 2:
                        WorldGen.PlaceTile(i, j - 1, Mod.Find<ModTile>("GasRoot").Type);
                        short num = (short)(Main.rand.Next(0, 6) * 18);
                        Main.tile[i, j - 2].TileFrameX = num;
                        Main.tile[i, j - 1].TileFrameX = num;
                        break;
                    case 3:
                        WorldGen.PlaceTile(i, j - 2, Mod.Find<ModTile>("Shoregrass1").Type);
                        short num1 = (short)(Main.rand.Next(0, 6) * 36);
                        Main.tile[i, j - 2].TileFrameX = num1;
                        Main.tile[i, j - 1].TileFrameX = num1;
                        break;
                }
            }
            base.RandomUpdate(i, j);
        }
    }
}
