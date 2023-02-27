using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.Festivals
{
	public class LargeLantern2 : ModTile
	{
		public override void SetStaticDefaults()
		{
            Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileNoAttach[(int)base.Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.Height = 5;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                16,
                16,
                16
            };
            TileObjectData.newTile.CoordinateWidth = 54;
            TileObjectData.addTile((int)base.Type);
			this.DustType = 3;
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("");
            base.AddMapEntry(new Color(122, 87, 73), modTranslation);
            this.MineResist = 3f;
			base.SetStaticDefaults();
			modTranslation.AddTranslation(GameCulture.Chinese, "灯笼");
		}
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 32, base.Mod.Find<ModItem>("LargeLantern2").Type);
        }
        public override void HitWire(int i, int j)
        {
            int num = i - (int)(Main.tile[i, j].TileFrameX / 18 % 3);
            int num2 = j - (int)(Main.tile[i, j].TileFrameY / 18 % 3);
            for (int k = num; k < num + 3; k++)
            {
                for (int l = num2; l < num2 + 6; l++)
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
                Wiring.SkipWire(num, num2 + 3);
                Wiring.SkipWire(num, num2 + 4);
                Wiring.SkipWire(num, num2 + 5);
                Wiring.SkipWire(num + 1, num2);
                Wiring.SkipWire(num + 1, num2 + 1);
                Wiring.SkipWire(num + 1, num2 + 2);
                Wiring.SkipWire(num + 1, num2 + 3);
                Wiring.SkipWire(num + 1, num2 + 4);
                Wiring.SkipWire(num + 1, num2 + 5);
            }
        }
        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (Main.tile[i, j].TileFrameX < 40 && Main.tile[i, j].TileFrameY < 48 && Main.tile[i, j].TileFrameY != 0)
            {
                Lighting.AddLight(new Vector2(i * 16, j * 16), new Vector3(0.8f, 0.2f, 0f));
            }
        }
        /*public override void PlaceInWorld(int i, int j, Item item)
        {
            short num = (short)(Main.rand.Next(0, 4));
            Main.tile[i, j].frameX = (short)(num * 36);
            Main.tile[i, j + 2].frameX = (short)(num * 36);
            Main.tile[i, j + 3].frameX = (short)(num * 36);
            Main.tile[i, j + 1].frameX = (short)(num * 36);
        }*/
    }
}
