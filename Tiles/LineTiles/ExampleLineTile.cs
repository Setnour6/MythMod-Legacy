﻿using System;
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
using Terraria.World.Generation;
using Terraria.GameContent.Generation;

namespace MythMod.Tiles.LineTiles
{
    public class ExampleLineTile : ModTile
	{
		private float num5 = 0;
		private int num6 = 0;
		private int num11 = 0;
		private int num12 = 0;
        public override void SetDefaults()
		{
			Main.tileSolid[(int)base.Type] = true;
			Main.tileMergeDirt[(int)base.Type] = true;
			Main.tileBlendAll[(int)base.Type] = true;
			Main.tileBlockLight[(int)base.Type] = true;
			Main.tileShine2[(int)base.Type] = true;
			Main.tileValue[(int)base.Type] = 0;
			this.minPick = 120;
			this.drop = base.mod.ItemType("MachineBrick2");
			this.dustType = 6;
			this.soundType = 21;
			this.soundStyle = 2;
			Main.tileSpelunker[(int)base.Type] = true;
			ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("ExampleLineTile");
			base.AddMapEntry(new Color(235, 20, 0), modTranslation);
            modTranslation.AddTranslation(GameCulture.Chinese, "ExampleLineTile");
		}
		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
            Player player = Main.LocalPlayer;
            Texture2D texture = base.mod.GetTexture("Tiles/LineTiles/ExampleLineTile_Line");
			Vector2 position = new Vector2((float)(i * 16) - Main.screenPosition.X, (float)(j * 16) - Main.screenPosition.Y);
			if (CaptureManager.Instance.IsCapturing)
			{
				position = new Vector2((float)(i * 16) - Main.screenPosition.X, (float)(j * 16) - Main.screenPosition.Y);
			}
            float XMax = (float)Math.Abs(player.Center.X - Main.screenPosition.X - position.X);
            float DeltaY = (player.Center.Y - Main.screenPosition.Y - position.Y) / 2f;
            float DeltaX = (player.Center.X - Main.screenPosition.X - position.X) / 2f;
            float Leng = 320;
            float M = (float)(Math.Sqrt(Leng * Leng - DeltaY * DeltaY) / Math.Abs(DeltaX));
            float dA = DeltaX / (float)Math.Sqrt(-10 + Math.Sqrt(120 * M - 20));
            string key = dA.ToString();
            Color messageColor = Color.Orange;
            Main.NewText(Language.GetTextValue(key), messageColor);
            if (player.Center.X - Main.screenPosition.X - position.X > 0)
            {
                for (int dX = 0; dX < XMax; dX += 4)
                {
                    Vector2 v = new Vector2(dX , dA * (float)(Math.Cosh(dX / dA)));
                    Color color = Lighting.GetColor((int)(v.X / 16f), (int)(v.Y / 16f));
                    color = Color.White;
                    spriteBatch.Draw(texture, position + v + new Vector2(192, -112), new Rectangle?(new Rectangle(0, 0, 16, 16)), color, (float)(Math.Atan(Math.Sinh(dX / dA))), new Vector2(0f, 0f), 1f, SpriteEffects.None, 0f);
                }
            }
            else
            {
                for (int dX = 0; dX > -XMax; dX -= 4)
                {
                    Vector2 v = new Vector2(dX, dA * (float)(Math.Cosh(dX / dA)));
                    Color color = Lighting.GetColor((int)(v.X / 16f), (int)(v.Y / 16f));
                    color = Color.White;
                    spriteBatch.Draw(texture, position + v + new Vector2(192, -112), new Rectangle?(new Rectangle(0, 0, 16, 16)), color, (float)(Math.Atan(Math.Sinh(dX / dA))), new Vector2(0f, 0f), 1f, SpriteEffects.None, 0f);
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
    }
}
