using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.Plants
{
    public class 百香果藤 : ModTile
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
                22
            };
            TileObjectData.newTile.CoordinateWidth = 48;
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
            if (frameX == 150)
            {
                Item.NewItem(i * 16, j * 16, 16, 32, base.Mod.Find<ModItem>("百香果").Type);
                Item.NewItem(i * 16, j * 16, 16, 32, base.Mod.Find<ModItem>("百香果").Type);
                Item.NewItem(i * 16, j * 16, 16, 32, base.Mod.Find<ModItem>("百香果").Type);
                Item.NewItem(i * 16, j * 16, 16, 32, base.Mod.Find<ModItem>("百香果").Type);
            }
            //Color messageColor = Color.Purple;
            //Main.NewText(Language.GetTextValue(frameX.ToString()), messageColor);
        }
        public override void PlaceInWorld(int i, int j, Item item)
        {
            short num = (short)(Main.rand.Next(0, 0));
            Main.tile[i, j].TileFrameX = (short)(num * 90);
        }
        public override void RandomUpdate(int i, int j)
        {
            if (Main.tile[i, j].TileFrameX < 192 && Main.rand.Next(3) == 2)
            {
                for (int y = j; y < j + 10; y++)
                {
                    if (Main.tile[i, y - 5].TileType == Mod.Find<ModTile>("百香果藤").Type)
                    {
                        Main.tile[i, y - 5].TileFrameX += 48;
                    }
                }
                xm += 1;
            }
        }
    }
}
