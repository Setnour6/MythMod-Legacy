using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace MythMod.Tiles.电梯
{
	// Token: 0x02000C76 RID: 3190
	public class 花岗岩电梯楼层显示标 : ModTile
	{
		// Token: 0x06004027 RID: 16423 RVA: 0x00322CBC File Offset: 0x00320EBC
        public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[(int)base.Type] = true;
			Main.tileLavaDeath[(int)base.Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16
            };
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 36;
			TileObjectData.addTile((int)base.Type);
			this.DustType = 7;
			this.disableSmartCursor/* tModPorter Note: Removed. Use TileID.Sets.DisableSmartCursor instead */ = true;
			ModTranslation modTranslation = base.CreateMapEntryName(null);
			modTranslation.SetDefault("花岗岩电梯楼层显示标");
			base.AddMapEntry(new Color(60, 60, 60), modTranslation);
			modTranslation.AddTranslation(GameCulture.Chinese, "花岗岩电梯楼层显示标");
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
            if (mplayer.floor < 10)
            {
                Main.spriteBatch.Draw(Mod.GetTexture("Tiles/电梯楼层显示标Glow" + mplayer.floor.ToString()), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), new Color(155, 155, 155, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
            if (mplayer.floor >= 10 && mplayer.floor < 100)
            {
                Main.spriteBatch.Draw(Mod.GetTexture(("Tiles/电梯楼层显示标Glow" + ((mplayer.floor - mplayer.floor % 10) / 10).ToString())), new Vector2(i * 16 - (int)Main.screenPosition.X - 6, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), new Color(155, 155, 155, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                Main.spriteBatch.Draw(Mod.GetTexture(("Tiles/电梯楼层显示标Glow" + (mplayer.floor % 10).ToString())), new Vector2(i * 16 - (int)Main.screenPosition.X + 6, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), new Color(155, 155, 155, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
            if (mplayer.floor >= 100)
            {
                Main.spriteBatch.Draw(Mod.GetTexture(("Tiles/电梯楼层显示标Glow" + ((mplayer.floor - mplayer.floor % 100) / 100).ToString())), new Vector2(i * 16 - (int)Main.screenPosition.X - 10, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), new Color(155, 155, 155, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                Main.spriteBatch.Draw(Mod.GetTexture(("Tiles/电梯楼层显示标Glow" + (mplayer.floor % 100 - (mplayer.floor % 100) % 10).ToString())), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), new Color(155, 155, 155, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                Main.spriteBatch.Draw(Mod.GetTexture(("Tiles/电梯楼层显示标Glow" + (mplayer.floor % 10).ToString())), new Vector2(i * 16 - (int)Main.screenPosition.X + 10, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height), new Color(155, 155, 155, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
        }
        // Token: 0x06004028 RID: 16424 RVA: 0x00322D58 File Offset: 0x00320F58
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
		    Item.NewItem(i * 16, j * 16, 16, 32, Mod.Find<ModItem>("GraniteLiftLabel").Type, 1, false, 0, false, false);
		}
    }
}
