using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.Enums;

namespace MythMod.Tiles.Festivals
{
    public class Chinalamp4 : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[(int)base.Type] = true;
            Main.tileLavaDeath[(int)base.Type] = true;
            Main.tileNoAttach[(int)base.Type] = true;
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                16,
                16
            };
            TileObjectData.newTile.CoordinateWidth = 36;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorTop = new AnchorData((Terraria.Enums.AnchorType)1, 1, 1);
            TileObjectData.addTile((int)base.Type);
            this.dustType = 22;
            this.disableSmartCursor = true;
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("中国灯");
            base.AddMapEntry(new Color(122, 87, 73), modTranslation);
            modTranslation.AddTranslation(GameCulture.Chinese, "中国灯");
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 48, 48, mod.ItemType("Chinalamp4"), 1, false, 0, false, false);
        }
        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (Main.tile[i, j].frameX < 40)
            {
                Lighting.AddLight(new Vector2(i * 16, j * 16), new Vector3(1f, 0.8f, 0.5f));
            }
        }
        public override void HitWire(int i, int j)
        {
            int num = i - (int)(Main.tile[i, j].frameX / 18 % 3);
            int num2 = j - (int)(Main.tile[i, j].frameY / 18 % 3);
            for (int k = num; k < num + 3; k++)
            {
                for (int l = num2 - 1; l < num2 + 3; l++)
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
                Wiring.SkipWire(num, num2 + 2);
                Wiring.SkipWire(num + 1, num2);
                Wiring.SkipWire(num + 1, num2 + 1);
                Wiring.SkipWire(num + 1, num2 + 2);
                Wiring.SkipWire(num + 2, num2);
                Wiring.SkipWire(num + 2, num2 + 1);
                Wiring.SkipWire(num + 2, num2 + 2);
            }
        }
        /*public override void PlaceInWorld(int i, int j, Item item)
        {
            short num = (short)(Main.rand.Next(0, 4));
            Main.tile[i, j].frameX = (short)(num * 72);
            Main.tile[i, j + 1].frameX = (short)(num * 72);
            Main.tile[i, j + 2].frameX = (short)(num * 72);
            Main.tile[i, j + 3].frameX = (short)(num * 72);
            Main.tile[i, j + 4].frameX = (short)(num * 72);
        }*/
    }
}
