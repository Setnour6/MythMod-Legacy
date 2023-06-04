using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.Plants
{
    // Token: 0x02000DCE RID: 3534
    public class 菠萝丛 : ModTile
    {
        // Token: 0x06004868 RID: 18536 RVA: 0x0034883C File Offset: 0x00346A3C
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
                18
            };
            TileObjectData.newTile.CoordinateWidth = 90;
            TileObjectData.addTile((int)base.Type);
            this.DustType = 39;
            this.HitSound = 6;
            LocalizedText modTranslation = base.CreateMapEntryName(null);
            // modTranslation.SetDefault("");
            base.AddMapEntry(new Color(100, 210, 80), modTranslation);
            this.MineResist = 3f;
            base.SetStaticDefaults();
            modTranslation.AddTranslation(GameCulture.Chinese, "");
        }
        private int xm = 0;
        // Token: 0x06004869 RID: 18537 RVA: 0x000138D5 File Offset: 0x00011AD5
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = (fail ? 1 : 3);
        }
        // Token: 0x0600486A RID: 18538 RVA: 0x003488D0 File Offset: 0x00346AD0
        public override void NearbyEffects(int i, int j, bool closer)
        {
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            if (frameX == 368)
            {
                Item.NewItem(i * 16, j * 16, 16, 32, base.Mod.Find<ModItem>("菠萝").Type);
            }
            Color messageColor = Color.Purple;
            //Main.NewText(Language.GetTextValue(frameX.ToString()), messageColor);
        }
        public override void PlaceInWorld(int i, int j, Item item)
        {
            short num = (short)(Main.rand.Next(0, 0));
            Main.tile[i, j].TileFrameX = (short)(num * 90);
        }
        public override void RandomUpdate(int i, int j)
        {
            if (Main.tile[i, j].TileFrameX < 400 && Main.rand.Next(5) == 2)
            {
                for (int y = j; y < j + 10; y++)
                {
                    if (Main.tile[i, y - 5].TileType == Mod.Find<ModTile>("菠萝丛").Type)
                    {
                        Main.tile[i, y - 5].TileFrameX += 90;
                    }
                }
                xm += 1;
            }
        }
    }
}
