using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles
{
    public class 光之花 : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[(int)base.Type] = true;
            Main.tileNoAttach[(int)base.Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                20
            };
            TileObjectData.newTile.CoordinateWidth = 36;
            TileObjectData.addTile((int)base.Type);
            this.dustType = 39;
            this.soundType = 6;
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("");
            base.AddMapEntry(new Color(242, 181, 0), modTranslation);
            this.mineResist = 3f;
            base.SetDefaults();
            modTranslation.AddTranslation(GameCulture.Chinese, "光之花");
        }
        private int xm = 0;
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = (fail ? 1 : 3);
        }
        public override void NearbyEffects(int i, int j, bool closer)
        {
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 242 / 255f;
            g = 181 / 255f;
            b = 0f;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 32, base.mod.ItemType("FlowerOfLight"));
        }
    }
}
