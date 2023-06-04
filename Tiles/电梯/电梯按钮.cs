using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.电梯
{
	public class 电梯按钮 : ModTile
	{
        private bool LiftU = false;
        private bool LiftD = false;
        public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16
            };
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.addTile((int)base.Type);
			this.DustType = 7;
			this.disableSmartCursor/* tModPorter Note: Removed. Use TileID.Sets.DisableSmartCursor instead */ = true;
			LocalizedText modTranslation = base.CreateMapEntryName(null);
			// modTranslation.SetDefault("电梯按钮");
			base.AddMapEntry(new Color(60, 60, 60), modTranslation);
			modTranslation.AddTranslation(GameCulture.Chinese, "电梯按钮");
		}
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            Player player = Main.LocalPlayer;
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Vector2 v = player.Center - new Vector2(i * 16, j * 16);
            float m = v.Length();
            if (Main.drawToScreen)
            {
                zero = Vector2.Zero;
            }
            int height = 16;
            if (LiftU && m < 120)
            {
                Main.spriteBatch.Draw(Mod.GetTexture("Tiles/LiftU"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), new Color(155, 155, 155, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
            if (LiftD && m < 120)
            {
                Main.spriteBatch.Draw(Mod.GetTexture("Tiles/LiftD"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), new Color(155, 155, 155, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
            if (mplayer.LiftD == false)
            {
                LiftD = false;
            }
            if (mplayer.LiftU == false)
            {
                LiftU = false;
            }
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
		    Item.NewItem(i * 16, j * 16, 16, 32, Mod.Find<ModItem>("LiftButton").Type, 1, false, 0, false, false);
		}
        public override void RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.Zonefloor = 0;
            mplayer.firstClick = true;
            mplayer.liftPos = new Vector2(i * 16, j * 16);
            if (Main.tile[i, j].TileFrameY > 8)
            {
                if(!LiftD)
                {
                    LiftD = true;
                    mplayer.LiftD = true;
                }
                else
                {
                    LiftD = false;
                    mplayer.LiftD = false;
                }
            }
            else
            {
                if (!LiftU)
                {
                    LiftU = true;
                    mplayer.LiftU = true;
                }
                else
                {
                    LiftU = false;
                    mplayer.LiftU = false;
                }
            }
        }
    }
}
