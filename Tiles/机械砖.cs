using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Capture;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using System.Collections.Generic;
using System.IO;
using Terraria.ID;
using Terraria.ModLoader.IO;
using MythMod;
using MythMod.NPCs;
using System.Linq;
using Terraria.GameContent.Generation;
using Terraria.WorldBuilding;

namespace MythMod.Tiles
{
	// Token: 0x02000E8F RID: 3727
    public class 机械砖 : ModTile
	{
		private float num5 = 0;
		private int num6 = 0;
		private int num11 = 0;
		private int num12 = 0;
		// Token: 0x060045D6 RID: 17878 RVA: 0x0027A6F0 File Offset: 0x002788F0
		public override void SetStaticDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileMergeDirt[(int)base.Type] = true;
			Main.tileBlendAll[(int)base.Type] = true;
			Main.tileBlockLight[(int)base.Type] = true;
			Main.tileShine2[(int)base.Type] = true;
			Main.tileOreFinderPriority[(int)base.Type] = 0;
			this.MinPick = 120;
			this.DustType = -1;
			this.HitSound = 21;
			this.soundStyle/* tModPorter Note: Removed. Integrate into HitSound */ = 2;
			Main.tileSpelunker[(int)base.Type] = true;
			LocalizedText modTranslation = base.CreateMapEntryName(null);
            // modTranslation.SetDefault("机械砖");
			base.AddMapEntry(new Color(235, 20, 0), modTranslation);
            modTranslation.AddTranslation(GameCulture.Chinese, "机械砖");
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
			Texture2D texture = base.Mod.GetTexture("Tiles/机械砖_Glowmask");
			Vector2 position = new Vector2((float)(i * 16) - Main.screenPosition.X + (float)this.GetDrawOffset(), (float)(j * 16) - Main.screenPosition.Y + (float)this.GetDrawOffset());
			if (CaptureManager.Instance.IsCapturing)
			{
				position = new Vector2((float)(i * 16) - Main.screenPosition.X, (float)(j * 16) - Main.screenPosition.Y);
			}
			spriteBatch.Draw(texture, position, new Rectangle?(new Rectangle(num, num2, 18, 18)), new Color((int)(200 * Math.Sin(num5 / 700f * Math.PI) + 80 + num6), (int)(200 * Math.Sin(num5 / 700f * Math.PI) + 90 + num6), (int)(200 * Math.Sin(num5 / 700f * Math.PI) + 90 + num6), (int)(200 * Math.Sin(num5 / 700f * Math.PI) + 40 + num6)), 0f, new Vector2(0f, 0f), 1f, SpriteEffects.None, 0f);
		}
		// Token: 0x06004041 RID: 16449 RVA: 0x00324478 File Offset: 0x00322678
		public override void NearbyEffects(int i, int j, bool closer)
		{
			//string key = num5.ToString();
			//Color messageColor = Color.Orange;
			//Main.NewText(Language.GetTextValue(key), messageColor);
			if (Math.Abs(num5 % 1400 - 350) < 10)
			{
				Player player = Main.LocalPlayer;
				int num = j;
				if (Main.tile[i, num] != null&& Main.netMode != 1)
				{
					float num8 = (float)Main.mouseX + Main.screenPosition.X - (i * 16 + 16);
                    float num9 = (float)Main.mouseY + Main.screenPosition.Y - (num * 16 + 16);
                    float num10 = (float)Math.Sqrt((double)(num8 * num8 + num9 * num9));
					Vector2 vector = new Vector2(num8 / num10 * 9f, num9 / num10 * 9f).RotatedBy(Math.PI / 30f);
		        	int num7 = Projectile.NewProjectile(i * 16 + 16, num * 16 + 16, vector.X, vector.Y, 100, 30, 0f, Main.myPlayer, 0f, 0f);
					Main.projectile[num7].tileCollide = false;
				}
			}
			if (closer && !NPC.AnyNPCs(134))
			{
				WorldGen.KillTile(i, j, false, false, false);
				if (!Main.tile[i, j].HasTile && Main.netMode != 0)
				{
					NetMessage.SendData(17, -1, -1, null, 0, (float)i, (float)j, 0f, 0, 0, 0);
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
