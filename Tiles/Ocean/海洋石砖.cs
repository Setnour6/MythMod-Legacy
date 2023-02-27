using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Tiles.Ocean
{
	// Token: 0x02000E8F RID: 3727
    public class 海洋石砖 : ModTile
	{
		// Token: 0x060045D6 RID: 17878 RVA: 0x0027A6F0 File Offset: 0x002788F0
		public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileMergeDirt[(int)base.Type] = true;
			Main.tileBlendAll[(int)base.Type] = true;
			Main.tileBlockLight[(int)base.Type] = true;
			Main.tileShine2[(int)base.Type] = true;
			Main.tileValue[(int)base.Type] = 415;
			this.dustType = 224;
			this.minPick = 235;
			this.soundType = 21;
            this.drop = base.mod.ItemType("OceanStoneBlock");

            this.soundStyle = 2;
			Main.tileSpelunker[(int)base.Type] = true;
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("海洋石砖");
			base.AddMapEntry(new Color(6, 61, 54), modTranslation);
            modTranslation.AddTranslation(GameCulture.Chinese, "海洋石砖");
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
            Main.spriteBatch.Draw(mod.GetTexture("Tiles/Ocean/海洋石砖Glow"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, height), Color.White * (float)(Math.Sin(Main.time * 0.002f) * 0.003 + 0.005), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
