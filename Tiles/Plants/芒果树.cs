using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace MythMod.Tiles.Plants
{
    public class 芒果树 : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[(int)base.Type] = true;
            Main.tileNoAttach[(int)base.Type] = true;
            Main.tileAxe[(int)base.Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.Height = 22;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                16,
                16,
                16,
                16,
                16,
                16,
                16,
                16,
                16,
                16,
                16,
                16,
                16,
                16,
                16,
                16,
                16,
                16,
                16,
                20
            };
            TileObjectData.newTile.CoordinateWidth = 256;
            TileObjectData.newTile.Origin = new Point16(0, 17);
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.addTile((int)base.Type);
            this.DustType = 39;
            this.HitSound = 6;
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("");
            base.AddMapEntry(new Color(100, 210, 80), modTranslation);
            this.MineResist = 3f;
            base.SetStaticDefaults();
            modTranslation.AddTranslation(GameCulture.Chinese, "");
        }
        private int xm = 0;
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = (fail ? 1 : 3);
        }
        public override void NearbyEffects(int i, int j, bool closer)
        {
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            if (frameX == 774)
            {
                Item.NewItem(i * 16, j * 16, 16, 32, base.Mod.Find<ModItem>("芒果").Type, 15);
                Item.NewItem(i * 16, j * 16, 16, 32, base.Mod.Find<ModItem>("芒果").Type, 15);
                Item.NewItem(i * 16, j * 16, 16, 32, base.Mod.Find<ModItem>("芒果").Type, 15);
                Item.NewItem(i * 16, j * 16, 16, 32, base.Mod.Find<ModItem>("芒果").Type, Main.rand.Next(3, 15));
                Item.NewItem(i * 16, j * 16, 16, 32, 9, 15);
            }
            Color messageColor = Color.Purple;
        }
        public override void PlaceInWorld(int i, int j, Item item)
        {
            short num = (short)(Main.rand.Next(0, 0));
            Main.tile[i, j].TileFrameX = 0;
        }
        public override void RandomUpdate(int i, int j)
        {
            if (Main.tile[i, j].TileFrameX < 774 && Main.rand.Next(100) == 1)
            {
                for (int y = j; y < j + 44; y++)
                {
                    if (Main.tile[i, y - 22].TileType == Mod.Find<ModTile>("芒果树").Type)
                    {
                        Main.tile[i, y - 22].TileFrameX += 256;
                    }
                }
                xm += 1;
            }
        }
    }
}
