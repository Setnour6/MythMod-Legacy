using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.玄武岩家具
{
	public class 玄武岩蜡烛 : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileLighted[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			Main.tileWaterDeath[(int)base.Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.StyleOnTable1x1);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				20
			};
			TileObjectData.addTile((int)base.Type);
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("玄武岩蜡烛");
			base.AddMapEntry(new Color(191, 142, 111), modTranslation);
			base.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
			this.disableSmartCursor/* tModPorter Note: Removed. Use TileID.Sets.DisableSmartCursor instead */ = true;
			this.AdjTiles = new int[]
			{
				4
			};
			this.ItemDrop = base.Mod.Find<ModItem>("BasaltCandle").Type;
			modTranslation.AddTranslation(GameCulture.Chinese, "玄武岩蜡烛");
		}
		public override bool CreateDust(int i, int j, ref int type)
		{
			Dust.NewDust(new Vector2((float)i, (float)j) * 16f, 16, 16, 1, 0f, 0f, 1, new Color(100, 130, 150), 1f);
			return false;
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			if (Main.tile[i, j].TileFrameX < 18)
			{
				r = 1f;
				g = 0.16f;
				b = 0f;
				return;
			}
			r = 0f;
			g = 0f;
			b = 0f;
		}
		public override void HitWire(int i, int j)
		{
			int num = i - (int)(Main.tile[i, j].TileFrameX / 18 % 1);
			int num2 = j - (int)(Main.tile[i, j].TileFrameY / 18 % 1);
			for (int k = num; k < num + 1; k++)
			{
				for (int l = num2; l < num2 + 1; l++)
				{
					if (Main.tile[k, l] == null)
					{
						Main.tile[k, l] = new Tile();
					}
					if (Main.tile[k, l].HasTile && Main.tile[k, l].TileType == base.Type)
					{
						if (Main.tile[k, l].TileFrameX < 18)
						{
							Tile tile = Main.tile[k, l];
							tile.TileFrameX += 18;
						}
						else
						{
							Tile tile2 = Main.tile[k, l];
							tile2.TileFrameX -= 18;
						}
					}
				}
			}
			if (Wiring.running)
			{
				Wiring.SkipWire(num, num2);
			}
		}
	}
}
