using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Capture;

namespace MythMod.Tiles.Volcano
{
	// Token: 0x02000E8F RID: 3727
    public class 熔岩石 : ModTile
	{
		private float num5 = 0;
		private int num6 = 0;
		// Token: 0x060045D6 RID: 17878 RVA: 0x0027A6F0 File Offset: 0x002788F0
		public override void SetStaticDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileMergeDirt[(int)base.Type] = true;
			Main.tileBlendAll[(int)base.Type] = true;
			Main.tileBlockLight[(int)base.Type] = true;
			Main.tileShine2[(int)base.Type] = true;
			Main.tileOreFinderPriority[(int)base.Type] = 0;
			this.MinPick = 300;
			this.DustType = 6;
			this.HitSound = 21;
			this.soundStyle/* tModPorter Note: Removed. Integrate into HitSound */ = 2;
            this.ItemDrop = base.Mod.Find<ModItem>("LavaStoneCore").Type;
			Main.tileSpelunker[(int)base.Type] = true;
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("熔岩石");
			base.AddMapEntry(new Color(235, 20, 0), modTranslation);
            modTranslation.AddTranslation(GameCulture.Chinese, "熔岩石");
		}
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
        // Token: 0x06004019 RID: 16409 RVA: 0x003229C4 File Offset: 0x00320BC4
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			num5 += 1;
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
			Texture2D texture = base.Mod.GetTexture("Tiles/熔岩石_Glowmask");
			Vector2 position = new Vector2((float)(i * 16) - Main.screenPosition.X + (float)this.GetDrawOffset(), (float)(j * 16) - Main.screenPosition.Y + (float)this.GetDrawOffset());
			if (CaptureManager.Instance.IsCapturing)
			{
				position = new Vector2((float)(i * 16) - Main.screenPosition.X, (float)(j * 16) - Main.screenPosition.Y);
			}
			spriteBatch.Draw(texture, position, new Rectangle?(new Rectangle(num, num2, 18, 18)), new Color((int)(60 * Math.Sin(num5 / 10000f) + 80 + num6), (int)(80 * Math.Sin(num5 / 10000f) + 90 + num6), (int)(80 * Math.Sin(num5 / 10000f) + 90 + num6), (int)(80 * Math.Sin(num5 / 10000f) + 90 + num6)), 0f, new Vector2(0f, 0f), 1f, SpriteEffects.None, 0f);
		}
		// Token: 0x06004041 RID: 16449 RVA: 0x00324478 File Offset: 0x00322678
		public override void NearbyEffects(int i, int j, bool closer)
		{
			if (closer && Main.rand.Next(1000) == 0)
			{
				int num = j + 1;
				if (Main.tile[i, num] != null&& Main.netMode != 1)
				{
		        	int num7 = Dust.NewDust(new Vector2(i * 16 + 16, num * 16 + 16), 16, 16, 6, 0f, 0f, 100, default(Color), 2f);
				}
			}
		}
		// Token: 0x0600401A RID: 16410 RVA: 0x003228F4 File Offset: 0x00320AF4
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
