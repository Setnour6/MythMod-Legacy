using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.Festivals
{
	public class LittleLantern : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileLighted[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileNoAttach[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			Main.tileWaterDeath[(int)base.Type] = false;
			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 1;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
                16
			};
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 1;
			TileObjectData.newTile.Origin = new Point16(1, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.AnchorTop = new AnchorData((Terraria.Enums.AnchorType)1, 1, 1);
			TileObjectData.addTile((int)base.Type);
			base.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("LittleLantern");
			base.AddMapEntry(new Color(255, 0, 0), modTranslation);
			this.AdjTiles = new int[]
			{
				4
			};
			modTranslation.AddTranslation(GameCulture.Chinese, "小灯笼");
		}
		public override bool CreateDust(int i, int j, ref int type)
		{
			Dust.NewDust(new Vector2((float)i, (float)j) * 16f, 16, 16, 5, 0f, 0f, 1, new Color(100, 130, 150), 1f);
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
				r = 0.8f;
				g = 0.2f;
				b = 0f;
				return;
			}
			r = 0f;
			g = 0f;
			b = 0f;
		}

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            Item.NewItem(i * 16, j * 16, 48, 48, base.Mod.Find<ModItem>("LittleLantern").Type, 1, false, 0, false, false);
        }
        public override void HitWire(int i, int j)
		{
			int num = i - (int)(Main.tile[i, j].TileFrameX / 18 % 3);
			int num2 = j - (int)(Main.tile[i, j].TileFrameY / 18 % 3);
			for (int k = num; k < num + 3; k++)
			{
				for (int l = num2; l < num2 + 3; l++)
				{
					if (Main.tile[k, l] == null)
					{
						Main.tile[k, l] = new Tile();
					}
					if (Main.tile[k, l].HasTile && Main.tile[k, l].TileType == base.Type)
					{
						if (Main.tile[k, l].TileFrameX < 54)
						{
							Tile tile = Main.tile[k, l];
							tile.TileFrameX += 54;
						}
						else
						{
							Tile tile2 = Main.tile[k, l];
							tile2.TileFrameX -= 54;
						}
					}
				}
			}
			if (Wiring.running)
			{
				Wiring.SkipWire(num, num2);
				Wiring.SkipWire(num, num2 + 1);
				Wiring.SkipWire(num, num2 + 2);
				Wiring.SkipWire(num + 1, num2);
				Wiring.SkipWire(num + 1, num2 + 1);
				Wiring.SkipWire(num + 1, num2 + 2);
				Wiring.SkipWire(num + 2, num2);
				Wiring.SkipWire(num + 2, num2 + 1);
				Wiring.SkipWire(num + 2, num2 + 2);
			}
		}
	}
}
