﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MythMod.UI.Stones;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.Enums;

namespace MythMod.Tiles.电梯
{
    public class 电梯门 : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[(int)base.Type] = true;
            Main.tileNoAttach[(int)base.Type] = true;
            this.minPick = 260;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
                16,
                16
            };
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.AnchorTop = default(AnchorData);
            TileObjectData.addTile((int)base.Type);
            this.dustType = 224;
            ModTranslation modTranslation = base.CreateMapEntryName(null);
            modTranslation.SetDefault("");
            base.AddMapEntry(new Color(60, 60, 60), modTranslation);
            this.mineResist = 3f;
            base.SetDefaults();
            modTranslation.AddTranslation(GameCulture.Chinese, "");
        }
        private int num = 0;
        private int num3 = 0;
        private bool instant = true;
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = (fail ? 1 : 3);
        }
        public override void NearbyEffects(int i, int j, bool closer)
        {
            Player player = Main.LocalPlayer;
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Vector2 v = player.Center - new Vector2(i * 16, j * 16);
            float m = v.Length();
            if (mplayer.OpenLift && m < 120)
            {
                if(instant && mplayer.LiftOpenDegree == 1)
                {
                    for(int a = i;a < i + 3; a++)
                    {
                        for (int b = j; b < j + 4; b++)
                        {
                            Main.tile[a, b].frameY += 72;
                        }
                    }
                    instant = false;
                }
                if (!instant && mplayer.LiftOpenDegree == 2)
                {
                    for (int a = i; a < i + 3; a++)
                    {
                        for (int b = j; b < j + 4; b++)
                        {
                            Main.tile[a, b].frameY += 72;
                        }
                    }
                    instant = true;
                }
                if (instant && mplayer.LiftOpenDegree == 3)
                {
                    for (int a = i; a < i + 3; a++)
                    {
                        for (int b = j; b < j + 4; b++)
                        {
                            Main.tile[a, b].frameY += 72;
                        }
                    }
                    instant = false;
                }
                if (!instant && mplayer.LiftOpenDegree == 4)
                {
                    for (int a = i; a < i + 3; a++)
                    {
                        for (int b = j; b < j + 4; b++)
                        {
                            Main.tile[a, b].frameY += 72;
                        }
                    }
                    instant = true;
                }
                if (instant && mplayer.LiftOpenDegree == 5)
                {
                    for (int a = i; a < i + 3; a++)
                    {
                        for (int b = j; b < j + 4; b++)
                        {
                            Main.tile[a, b].frameY += 72;
                        }
                    }
                    instant = false;
                }
                if (!instant && mplayer.LiftOpenDegree == 6)
                {
                    for(int a = i; a < i + 3; a++)
                    {
                        for (int b = j; b < j + 4; b++)
                        {
                            Main.tile[a, b].frameY += 72;
                        }
                    }
                    instant = true;
                }
                num = (int)Main.time;
            }
            if (mplayer.CloseLift && m < 120)
            {
                if (!instant && mplayer.LiftOpenDegree == 0)
                {
                    for (int a = i; a < i + 3; a++)
                    {
                        for (int b = j; b < j + 4; b++)
                        {
                            Main.tile[a, b].frameY -= 72;
                        }
                    }
                    instant = true;
                }
                if (instant && mplayer.LiftOpenDegree == 1)
                {
                    for (int a = i; a < i + 3; a++)
                    {
                        for (int b = j; b < j + 4; b++)
                        {
                            Main.tile[a, b].frameY -= 72;
                        }
                    }
                    instant = false;
                }
                if (!instant && mplayer.LiftOpenDegree == 2)
                {
                    for (int a = i; a < i + 3; a++)
                    {
                        for (int b = j; b < j + 4; b++)
                        {
                            Main.tile[a, b].frameY -= 72;
                        }
                    }
                    instant = true;
                }
                if (instant && mplayer.LiftOpenDegree == 3)
                {
                    for (int a = i; a < i + 3; a++)
                    {
                        for (int b = j; b < j + 4; b++)
                        {
                            Main.tile[a, b].frameY -= 72;
                        }
                    }
                    instant = false;
                }
                if (!instant && mplayer.LiftOpenDegree == 4)
                {
                    for (int a = i; a < i + 3; a++)
                    {
                        for (int b = j; b < j + 4; b++)
                        {
                            Main.tile[a, b].frameY -= 72;
                        }
                    }
                    instant = true;
                }
                if (instant && mplayer.LiftOpenDegree == 5)
                {
                    for (int a = i; a < i + 3; a++)
                    {
                        for (int b = j; b < j + 4; b++)
                        {
                            Main.tile[a, b].frameY -= 72;
                        }
                    }
                    instant = false;
                }
                Lighting.AddLight(new Vector2(i * 16, j * 16), new Vector3(255,131, 0) / 240f * mplayer.LiftOpenDegree);
            }
            if(!mplayer.OpenLift && !mplayer.CloseLift)
            {
                //Main.tile[i, j].frameY = (short)(num3);
            }
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int num = 0;
            switch (frameX / 54)
            {
                case 0:
                    num = base.mod.ItemType("LiftDoor");
                    break;
                case 1:
                    num = base.mod.ItemType("WoodLiftDoor");
                    break;
                case 2:
                    num = base.mod.ItemType("RedWoodLiftDoor");
                    break;
            }
            if (num > 0)
            {
                Item.NewItem(i * 16, j * 16, 48, 48, num, 1, false, 0, false, false);
            }
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
            Main.spriteBatch.Draw(mod.GetTexture("Tiles/电梯门Glow"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, height), new Color(55, 55, 55, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
        public override void RightClick(int i, int j)//右击
        {
            Player player = Main.LocalPlayer;
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
        }
    }
}
