using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.玄武岩家具
{
	public class 玄武岩灯 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileLighted[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			Main.tileWaterDeath[(int)base.Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1xX);
			TileObjectData.addTile((int)base.Type);
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("玄武岩灯");
            base.AddMapEntry(new Color(191, 142, 111), modTranslation);
            base.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
			this.disableSmartCursor = true;
			this.adjTiles = new int[]
			{
				4
			};
			modTranslation.AddTranslation(GameCulture.Chinese, "玄武岩灯");
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
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 16, 32, base.mod.ItemType("BasaltLamp"), 1, false, 0, false, false);
		}
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			if (Main.tile[i, j].frameX < 18)
			{
				r = 1f;
				g = 0.3f;
				b = 0f;
				return;
			}
			r = 0f;
			g = 0f;
			b = 0f;
		}
		public override void HitWire(int i, int j)
		{
			int num = i - (int)(Main.tile[i, j].frameX / 18 % 1);
			int num2 = j - (int)(Main.tile[i, j].frameY / 18 % 3);
			for (int k = num; k < num + 1; k++)
			{
				for (int l = num2; l < num2 + 3; l++)
				{
					if (Main.tile[k, l] == null)
					{
						Main.tile[k, l] = new Tile();
					}
					if (Main.tile[k, l].active() && Main.tile[k, l].type == base.Type)
					{
						if (Main.tile[k, l].frameX < 18)
						{
							Tile tile = Main.tile[k, l];
							tile.frameX += 18;
						}
						else
						{
							Tile tile2 = Main.tile[k, l];
							tile2.frameX -= 18;
						}
					}
				}
			}
			if (Wiring.running)
			{
				Wiring.SkipWire(num, num2);
				Wiring.SkipWire(num, num2 + 1);
				Wiring.SkipWire(num, num2 + 2);
			}
		}
	}
}
