using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.Festivals
{
	public class 红烛 : ModTile
	{
		public override void SetDefaults()
		{
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileNoAttach[(int)base.Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                16,
                16
            };
            TileObjectData.newTile.CoordinateWidth = 18;
            TileObjectData.addTile((int)base.Type);
			this.dustType = 115;
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("");
            base.AddMapEntry(new Color(196, 11, 21), modTranslation);
			this.mineResist = 3f;
			base.SetDefaults();
			modTranslation.AddTranslation(GameCulture.Chinese, "");
		}
        public override void NearbyEffects(int i, int j, bool closer)
		{
		}
        public override void RightClick(int i, int j)
        {
            for (int m = 0; m < 8; m++)
            {
                if (Main.tile[i, j + m - 4].type == this.Type)
                {
                    Main.tile[i, j + m - 4].frameX = (short)(18 - Main.tile[i, j].frameX);
                }
            }
            base.RightClick(i, j);
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            if(Main.tile[i,j].frameX != 0)
            {
                r = 0.4f;
                g = 0.1f;
                b = 0f;
            }
            else
            {
                r = 0f;
                g = 0f;
                b = 0f;
            }
            return;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 32, base.mod.ItemType("红烛"));
        }
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            ulong randSeed = Main.TileFrameSeed ^ (ulong)((long)j << 32 | (long)((ulong)i));
            Color color = new Color(100, 100, 100, 0);
            int frameX = Main.tile[i, j].frameX;
            int frameY = Main.tile[i, j].frameY;
            int width = 20;
            int offsetY = 0;
            int height = 20;
            if (WorldGen.SolidTile(i, j - 1))
            {
                offsetY = 2;
                if (WorldGen.SolidTile(i - 1, j + 1) || WorldGen.SolidTile(i + 1, j + 1))
                {
                    offsetY = 4;
                }
            }
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            for (int k = 0; k < 7; k++)
            {
                float x = (float)Utils.RandomInt(ref randSeed, -10, 11) * 0.15f;
                float y = (float)Utils.RandomInt(ref randSeed, -10, 1) * 0.35f;
                Main.spriteBatch.Draw(mod.GetTexture("Tiles/Festivals/红烛Flame"), new Vector2((float)(i * 16 - (int)Main.screenPosition.X) - (width - 16f) / 2f + x, (float)(j * 16 - (int)Main.screenPosition.Y + offsetY) + y) + zero, new Rectangle(frameX, frameY, width, height), color, 0f, default(Vector2), 1f, SpriteEffects.None, 0f);
            }
        }
    }
}
