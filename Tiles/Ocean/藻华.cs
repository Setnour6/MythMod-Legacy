using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Tiles.Ocean
{
	public class 藻华 : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileCut[(int)base.Type] = true;
			Main.tileBlockLight[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			Main.tileNoFail[(int)base.Type] = true;
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("藻华");
			base.AddMapEntry(new Color(0, 50, 0), modTranslation);
			this.HitSound = 6;
			this.DustType = 2;
			modTranslation.AddTranslation(GameCulture.Chinese, "藻华");
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}

		public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
		{
			if (WorldGen.genRand.Next(2) == 0 && Main.player[(int)Player.FindClosest(new Vector2((float)(i * 16), (float)(j * 16)), 16, 16)].cordage)
			{
				Item.NewItem(new Vector2((float)(i * 16) + 8f, (float)(j * 16) + 8f), 2996, 1, false, 0, false, false);
			}
			if (Main.tile[i, j + 1] != null && Main.tile[i, j + 1].HasTile && (int)Main.tile[i, j + 1].TileType == base.Mod.Find<ModTile>("藻华").Type)
			{
				WorldGen.KillTile(i, j + 1, false, false, false);
				if (!Main.tile[i, j + 1].HasTile && Main.netMode != 0)
				{
					NetMessage.SendData(17, -1, -1, null, 0, (float)i, (float)j + 1f, 0f, 0, 0, 0);
				}
			}
		}

		public override void RandomUpdate(int i, int j)
		{
			if (Main.tile[i, j + 1] != null && !Main.tile[i, j + 1].HasTile && Main.tile[i, j + 1].TileType != (ushort)base.Mod.Find<ModTile>("藻华").Type && Main.tile[i, j + 1].LiquidAmount >= 128 && !(Main.tile[i, j + 1].LiquidType == LiquidID.Lava))
			{
				bool flag = false;
				int k = j;
				while (k > j - 10)
				{
					if (Main.tile[i, k].BottomSlope)
					{
						flag = false;
						break;
					}
					if (Main.tile[i, k].HasTile && !Main.tile[i, k].BottomSlope)
					{
						flag = true;
						break;
					}
					j--;
				}
				if (flag)
				{
					int num = j + 1;
					Main.tile[i, num].TileType = (ushort)base.Mod.Find<ModTile>("藻华").Type;
					Main.tile[i, num].TileFrameX = (short)(WorldGen.genRand.Next(8) * 18);
					Main.tile[i, num].TileFrameY = 72;
					Main.tile[i, num - 1].TileFrameX = (short)(WorldGen.genRand.Next(12) * 18);
					Main.tile[i, num - 1].TileFrameY = (short)(WorldGen.genRand.Next(4) * 18);
					Main.tile[i, num].HasTile = true;
					WorldGen.SquareTileFrame(i, num, true);
					WorldGen.SquareTileFrame(i, num - 1, true);
					if (Main.netMode == 2)
					{
						NetMessage.SendTileSquare(-1, i, num, 3, 0);
						NetMessage.SendTileSquare(-1, i, num - 1, 3, 0);
					}
				}
			}
		}
	}
}
