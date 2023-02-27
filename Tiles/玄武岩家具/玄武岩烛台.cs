using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.玄武岩家具
{
	// Token: 0x02000CB2 RID: 3250
	public class 玄武岩烛台 : ModTile
	{
		// Token: 0x06004151 RID: 16721 RVA: 0x0032B0F4 File Offset: 0x003292F4
		public override void SetDefaults()
		{
			Main.tileLighted[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			Main.tileWaterDeath[(int)base.Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile((int)base.Type);
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("玄武岩烛台");
			base.AddMapEntry(new Color(191, 142, 111), modTranslation);
			base.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
			this.disableSmartCursor = true;
			this.adjTiles = new int[]
			{
				4
			};
			modTranslation.AddTranslation(GameCulture.Chinese, "玄武岩烛台");
		}

		// Token: 0x06004152 RID: 16722 RVA: 0x0032AD68 File Offset: 0x00328F68
		public override bool CreateDust(int i, int j, ref int type)
		{
			Dust.NewDust(new Vector2((float)i, (float)j) * 16f, 16, 16, 1, 0f, 0f, 1, new Color(100, 130, 150), 1f);
			return false;
		}

		// Token: 0x06004153 RID: 16723 RVA: 0x000138D5 File Offset: 0x00011AD5
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}

		// Token: 0x06004154 RID: 16724 RVA: 0x0032B1B0 File Offset: 0x003293B0
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			if (Main.tile[i, j].frameX < 18)
			{
				r = 1f;
				g = 0.1647058823529412f;
				b = 0.0f;
				return;
			}
			r = 0f;
			g = 0f;
			b = 0f;
		}

		// Token: 0x06004155 RID: 16725 RVA: 0x0032B204 File Offset: 0x00329404
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 16, 16, base.mod.ItemType("BasaltCandlestick"), 1, false, 0, false, false);
		}

		// Token: 0x06004156 RID: 16726 RVA: 0x0032B238 File Offset: 0x00329438
		public override void HitWire(int i, int j)
		{
			int num = i - (int)(Main.tile[i, j].frameX / 18 % 2);
			int num2 = j - (int)(Main.tile[i, j].frameY / 18 % 2);
			for (int k = num; k < num + 2; k++)
			{
				for (int l = num2; l < num2 + 2; l++)
				{
					if (Main.tile[k, l] == null)
					{
						Main.tile[k, l] = new Tile();
					}
					if (Main.tile[k, l].active() && Main.tile[k, l].type == base.Type)
					{
						if (Main.tile[k, l].frameX < 36)
						{
							Tile tile = Main.tile[k, l];
							tile.frameX += 36;
						}
						else
						{
							Tile tile2 = Main.tile[k, l];
							tile2.frameX -= 36;
						}
					}
				}
			}
			if (Wiring.running)
			{
				Wiring.SkipWire(num, num2);
				Wiring.SkipWire(num, num2 + 1);
				Wiring.SkipWire(num + 1, num2);
				Wiring.SkipWire(num + 1, num2 + 1);
			}
		}
	}
}
