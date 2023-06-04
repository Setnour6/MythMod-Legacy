using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.Volcano
{
	public class RedTreeSapling : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 18 };
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.AnchorValidTiles = new int[]{ Mod.Find<ModTile>("ShoreMud").Type };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.DrawFlipHorizontal = true;
			TileObjectData.newTile.WaterPlacement = LiquidPlacement.Allowed;
			TileObjectData.newTile.LavaDeath = true;
			TileObjectData.newTile.RandomStyleRange = 3;
			TileObjectData.addTile(Type);
			sapling/* tModPorter Note: Removed. Use TileID.Sets.TreeSapling and TileID.Sets.CommonSapling instead */ = true;
			LocalizedText name = CreateMapEntryName();
			// name.SetDefault("Sapling");
			AddMapEntry(new Color(68, 65, 48), name);
			//dustType = mod.DustType("Sparkle");
			AdjTiles = new int[]{ TileID.Saplings };
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void RandomUpdate(int i, int j)
		{
			if (WorldGen.genRand.Next(20) == 0)
			{
				bool isPlayerNear = WorldGen.PlayerLOS(i, j);
				bool success = WorldGen.GrowTree(i, j);
				if (success && isPlayerNear)
				{
					WorldGen.TreeGrowFXCheck(i, j);
				}
			}
            if (WorldGen.genRand.Next(2) == 0)
            {
                bool isPlayerNear = WorldGen.PlayerLOS(i, j);
                bool success = WorldGen.GrowTree(i, j);
                if (success && isPlayerNear)
                {
                    WorldGen.PlaceTile(i + Main.rand.Next(-5,6),j,Mod.Find<ModTile>("GasRoot").Type);
                }
            }
        }

		public override void SetSpriteEffects(int i, int j, ref SpriteEffects effects)
		{
			if (i % 2 == 1)
			{
				effects = SpriteEffects.FlipHorizontally;
			}
		}
	}
}