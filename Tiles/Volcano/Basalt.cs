﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Capture;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Tiles.Volcano
{
	// Token: 0x02000E8F RID: 3727
    public class Basalt : ModTile
	{
		// Token: 0x060045D6 RID: 17878 RVA: 0x0027A6F0 File Offset: 0x002788F0
		public override void SetStaticDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileMergeDirt[(int)base.Type] = true;
			Main.tileBlendAll[(int)base.Type] = true;
			Main.tileBlockLight[(int)base.Type] = true;
			Main.tileShine2[(int)base.Type] = false;
			Main.tileOreFinderPriority[(int)base.Type] = 0;
			this.DustType = 6;
			this.MinPick = 270;
			this.HitSound = 21;
			this.soundStyle/* tModPorter Note: Removed. Integrate into HitSound */ = 2;
            this.ItemDrop = base.Mod.Find<ModItem>("Basalt").Type;
			Main.tileSpelunker[(int)base.Type] = true;
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("Basalt");
			base.AddMapEntry(new Color(28, 28, 28), modTranslation);
            modTranslation.AddTranslation(GameCulture.Chinese, "玄武岩礁石");
		}
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if (!Lighting.NotRetro)
            {
                return;
            }
            int num = (int)Main.tile[i, j].TileFrameX;
            int num2 = (int)Main.tile[i, j].TileFrameY;
            int num3 = i % 1;
            int num4 = j % 1;
            num3 *= 288;
            num4 *= 270;
            num += num3;
            num2 += num4;
            Texture2D texture = base.Mod.GetTexture("Tiles/玄武岩礁石Glow");
            Vector2 position = new Vector2((float)(i * 16) - Main.screenPosition.X + (float)this.GetDrawOffset(), (float)(j * 16) - Main.screenPosition.Y + (float)this.GetDrawOffset());
            if (CaptureManager.Instance.IsCapturing)
            {
                position = new Vector2((float)(i * 16) - Main.screenPosition.X, (float)(j * 16) - Main.screenPosition.Y);
            }
            float l = 0;
            for(int x = i - 4;x < i + 4; x++)
            {
                for (int y = j - 4; y < j + 4; y++)
                {
                    if((Main.tile[x,y].LiquidType == LiquidID.Lava) && new Vector2(i - x, j - y).Length() <= 4)
                    {
                        l += 0.99f;
                    }
                }
            }
            spriteBatch.Draw(texture, position, new Rectangle?(new Rectangle(num, num2, 18, 18)), new Color(l / 24f, l / 24f, l / 24f, 0), 0f, new Vector2(0f, 0f), 1f, SpriteEffects.None, 0f);
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
    }
}
