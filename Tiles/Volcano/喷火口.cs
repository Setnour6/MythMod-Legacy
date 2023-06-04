using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Capture;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.Volcano
{
	// Token: 0x02000DCE RID: 3534
	public class 喷火口 : ModTile
	{
		// Token: 0x06004868 RID: 18536 RVA: 0x0034883C File Offset: 0x00346A3C
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileNoAttach[(int)base.Type] = true;
            this.MinPick = 264;
            Main.tileLavaDeath[(int)base.Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                28
            };
            TileObjectData.newTile.CoordinateWidth = 80;
            TileObjectData.addTile((int)base.Type);
			this.DustType = 6;
            LocalizedText modTranslation = base.CreateMapEntryName(null);
            // modTranslation.SetDefault("");
            base.AddMapEntry(new Color(3, 3, 3), modTranslation);
			this.MineResist = 3f;
			base.SetStaticDefaults();
			modTranslation.AddTranslation(GameCulture.Chinese, "");
		}
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = (fail ? 1 : 3);
		}
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
        public override void NearbyEffects(int i, int j, bool closer)
		{
            if(!Main.gamePaused)
            {
                if (Main.rand.Next(400) == 1)
                {
                    Projectile.NewProjectile(i * 16f + 8f, j * 16f - 16f, 0, 0, Mod.Find<ModProjectile>("FireSmoke2").Type, 120, 2f, Main.myPlayer, 0f, 0f);
                }
            }
		}
        private int GetDrawOffset()
        {
            int num;
            if ((float)Main.screenWidth < 1664f)
            {
                num = 193;
            }
            else
            {
                num = (int)(-0.5f * (float)Main.screenWidth + 1025f);
            }
            return num - 1;
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
            float l = 0;
            for (int x = i - 4; x < i + 4; x++)
            {
                for (int y = j - 4; y < j + 4; y++)
                {
                    if ((Main.tile[x, y].LiquidType == LiquidID.Lava) && new Vector2(i - x, j - y).Length() <= 4)
                    {
                        l += 0.99f;
                    }
                }
            }
            Main.spriteBatch.Draw(Mod.GetTexture("Tiles/喷火口Glow"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), new Color(l / 24f, l / 24f, l / 24f, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            for (int z = Main.rand.Next(46, 48); z < 50; z++)
            {
                Item.NewItem(i * 16, j * 16, 16, 32, base.Mod.Find<ModItem>("Basalt").Type);
            }
        }
        public override void PlaceInWorld(int i, int j, Item item)
        {
            short num = (short)(Main.rand.Next(0, 8));
            Main.tile[i, j].TileFrameX = (short)(num * 80);
            Main.tile[i, j + 2].TileFrameX = (short)(num * 80);
            Main.tile[i, j + 1].TileFrameX = (short)(num * 80);
        }
    }
}
