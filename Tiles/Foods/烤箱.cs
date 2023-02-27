using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.Foods
{
	public class 烤箱 : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileLighted[(int)base.Type] = true;
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			Main.tileWaterDeath[(int)base.Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.addTile((int)base.Type);
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("烤箱");
			base.AddMapEntry(new Color(191, 142, 111), modTranslation);
			base.AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
			this.disableSmartCursor = true;
			this.adjTiles = new int[]
			{
				4
			};
			modTranslation.AddTranslation(GameCulture.Chinese, "烤箱");
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
			if (Main.tile[i, j].frameX >= 36)
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
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            int height = 16;
            Main.spriteBatch.Draw(mod.GetTexture("Tiles/Foods/烤箱Glow"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, height), new Color(255, 255, 255, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 16, 16, base.mod.ItemType("烤箱"), 1, false, 0, false, false);
		}
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
