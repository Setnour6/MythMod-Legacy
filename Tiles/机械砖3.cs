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
    public class 机械砖3 : ModTile
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
			this.ItemDrop = base.Mod.Find<ModItem>("MachineBrick2").Type;
			this.DustType = 6;
			this.HitSound = 21;
			this.soundStyle/* tModPorter Note: Removed. Integrate into HitSound */ = 2;
			Main.tileSpelunker[(int)base.Type] = true;
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("机械砖3");
			base.AddMapEntry(new Color(235, 20, 0), modTranslation);
            modTranslation.AddTranslation(GameCulture.Chinese, "机械砖");
		}
		// Token: 0x06004019 RID: 16409 RVA: 0x003229C4 File Offset: 0x00320BC4
		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
            Player player = Main.LocalPlayer;
            num5 += 0.04F;
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
			Texture2D texture = base.Mod.GetTexture("Tiles/机械砖3_Glowmask");
			Vector2 position = new Vector2((float)(i * 16) - Main.screenPosition.X + (float)this.GetDrawOffset(), (float)(j * 16) - Main.screenPosition.Y + (float)this.GetDrawOffset());
			if (CaptureManager.Instance.IsCapturing)
			{
				position = new Vector2((float)(i * 16) - Main.screenPosition.X, (float)(j * 16) - Main.screenPosition.Y);
			}
            float XMax = (float)Math.Abs(player.Center.X - Main.screenPosition.X - position.X);
            float Leng = 10;
            if (player.Center.X - Main.screenPosition.X - position.X > 0)
            {
                for (int dX = 0; dX < XMax; dX += 16)
                {
                    spriteBatch.Draw(texture, position + new Vector2(dX, 0), new Rectangle?(new Rectangle(num, num2, 18, 18)), default(Color), 0, new Vector2(0f, 0f), 1f, SpriteEffects.None, 0f);
                }
            }
            else
            {
                for (int dX = 0; dX > -XMax; dX -= 16)
                {
                    spriteBatch.Draw(texture, position + new Vector2(dX,0), new Rectangle?(new Rectangle(num, num2, 18, 18)), default(Color), 0, new Vector2(0f, 0f), 1f, SpriteEffects.None, 0f);
                }
            }
            spriteBatch.Draw(texture, position, new Rectangle?(new Rectangle(num, num2, 18, 18)), new Color((int)(200 * Math.Sin(num5 / 700f * Math.PI) + 80 + num6), (int)(200 * Math.Sin(num5 / 700f * Math.PI) + 90 + num6), (int)(200 * Math.Sin(num5 / 700f * Math.PI) + 90 + num6), (int)(200 * Math.Sin(num5 / 700f * Math.PI) + 40 + num6)), 0f, new Vector2(0f, 0f), 1f, SpriteEffects.None, 0f);
		}
		// Token: 0x06004041 RID: 16449 RVA: 0x00324478 File Offset: 0x00322678
		public override void NearbyEffects(int i, int j, bool closer)
		{
			//string key = num5.ToString();
			//Color messageColor = Color.Orange;
			//Main.NewText(Language.GetTextValue(key), messageColor);
			if (Main.rand.Next(1000) == 10)
			{
				Player player = Main.LocalPlayer;
				int num = j;
				if (Main.tile[i, num] != null&& Main.netMode != 1)
				{
				    for (int k = 0; k < 2; k++)
		        	{
				    	int num7 = Projectile.NewProjectile(i * 16 + 16, num * 16 + 16, 0, 0, 20, 60, 0f, Main.myPlayer, 0f, 0f);
				        Main.projectile[num7].tileCollide = false;
                        if (Main.npc[k].CanBeChasedBy(Main.projectile[num7], false))
                        {
							float num8 = Main.npc[k].Center.X - (i * 16 + 16);
                            float num9 = Main.npc[k].Center.Y - (num * 16 + 16);
                            float num10 = (float)Math.Sqrt((double)(num8 * num8 + num9 * num9));
							Vector2 vector = new Vector2(num8 / num10 * 15f, num9 / num10 * 15f);
							Main.projectile[num7].velocity = vector;
							Main.projectile[num7].tileCollide = false;
                        }
						else
						{
							Main.projectile[num7].timeLeft = 0;
							Main.projectile[num7].tileCollide = false;
						}
					}
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
