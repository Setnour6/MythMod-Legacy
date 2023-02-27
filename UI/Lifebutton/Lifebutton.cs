using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
//using System.Drawing;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.ID;
using System;
using Terraria.DataStructures;
using Terraria.Localization;
using System.Collections.Generic;
using System.IO;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.UI.Elements;
using Terraria.GameContent.Liquid;
using Terraria.Graphics;

namespace MythMod.UI.Lifebutton
{
    public class Lifebutton : UIState
    {
        public static bool Down2 = false;
        public static bool Up2 = false;
        private bool living = true;
        public static bool Open = false;
        private LifebuttonMain LifebuttonMain = new LifebuttonMain();
        public override void OnInitialize()
        {
            LifebuttonMain = new LifebuttonMain();
            LifebuttonMain.Width.Set(422, 0);
            LifebuttonMain.Height.Set(424, 0);
            LifebuttonMain.Left.Set(Main.screenWidth * 0.5f + 40, 0);
            LifebuttonMain.Top.Set(Main.screenHeight * 0.5f, 0);

            Append(LifebuttonMain);
        }
        Vector2 offset;
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Player player = Main.player[Main.myPlayer];
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Vector2 vector = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            CalculatedStyle innerDimensions = base.GetInnerDimensions();
            float shopx2 = innerDimensions.X;
            float shopy2 = innerDimensions.Y;
            float shopx = innerDimensions.X;
            float shopy = innerDimensions.Y;
        }
    }
    public class LifebuttonMain : UIElement
    {
        private bool Down = false;
        private bool Up = false;
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 vector = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Player player = Main.player[Main.myPlayer];
            CalculatedStyle innerDimensions = base.GetInnerDimensions();
            float shopx = innerDimensions.X;
            float shopy = innerDimensions.Y;
            Mod mod = ModLoader.GetMod("MythMod");
            if(Lifebutton.Down2)
            {
                Down = true;
            }
            if (Lifebutton.Up2)
            {
                Up = true;
            }
            if (Down)
            {
                for (int a = 0; a < mplayer.floor; a++)
                {
                    if (a < 9)
                    {
                        if (Math.Abs(vector.X - shopx - 5) <= 9 && Math.Abs(vector.Y - (shopy + 18 * a - (mplayer.floor * 9 / 2) + 5)) <= 8)
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电梯按钮"), new Vector2(shopx, shopy + 18 * a - (mplayer.floor * 9 / 2)), null, Microsoft.Xna.Framework.Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + (a + 1).ToString()), new Vector2(shopx - 16, shopy + 18 * a - (mplayer.floor * 9 / 2) + 2), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            if (Main.mouseRight)
                            {
                                mplayer.aimFloor = a + 1;
                                mplayer.TransD = true;
                                Down = false;
                                Lifebutton.Open = false;
                            }
                        }
                        else
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电梯按钮"), new Vector2(shopx, shopy + 18 * a - (mplayer.floor * 9 / 2)), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + (a + 1).ToString()), new Vector2(shopx - 16, shopy + 18 * a - (mplayer.floor * 9 / 2) + 2), null, Microsoft.Xna.Framework.Color.DarkOrange * 0.75f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        }
                    }
                    if (a >= 9 && a < 18)
                    {
                        if (Math.Abs(vector.X - shopx - 23) <= 9 && Math.Abs(vector.Y - (shopy + 18 * (a + 1) - (mplayer.floor * 9 / 2) - 180)) <= 8)
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电梯按钮"), new Vector2(shopx + 18, shopy + 18 * (a + 1) - (mplayer.floor * 9 / 2) - 180), null, Microsoft.Xna.Framework.Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + (((a + 1) - (a + 1) % 10) / 10).ToString()), new Vector2(shopx - 3, shopy + 18 * (a + 1) - (mplayer.floor * 9 / 2) + 2 - 180), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + ((a + 1) % 10).ToString()), new Vector2(shopx + 5, shopy + 18 * (a + 1) - (mplayer.floor * 9 / 2) + 2 - 180), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            if (Main.mouseRight)
                            {
                                mplayer.aimFloor = a + 1;
                                mplayer.TransD = true;
                                Down = false;
                                Lifebutton.Open = false;
                            }
                        }
                        else
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电梯按钮"), new Vector2(shopx + 18, shopy + 18 * (a + 1) - (mplayer.floor * 9 / 2) - 180), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + (((a + 1) - (a + 1) % 10) / 10).ToString()), new Vector2(shopx - 3, shopy + 18 * (a + 1) - (mplayer.floor * 9 / 2) + 2 - 180), null, Microsoft.Xna.Framework.Color.DarkOrange * 0.75f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + ((a + 1) % 10).ToString()), new Vector2(shopx + 5, shopy + 18 * (a + 1) - (mplayer.floor * 9 / 2) + 2 - 180), null, Microsoft.Xna.Framework.Color.DarkOrange * 0.75f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        }
                    }
                    if (a >= 18 && a < 27)
                    {
                        if (Math.Abs(vector.X - shopx - 41) <= 9 && Math.Abs(vector.Y - (shopy + 18 * (a + 2) - (mplayer.floor * 9 / 2) - 360)) <= 8)
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电梯按钮"), new Vector2(shopx + 36, shopy + 18 * (a + 2) - (mplayer.floor * 9 / 2) - 360), null, Microsoft.Xna.Framework.Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + (((a + 1) - (a + 1) % 10) / 10).ToString()), new Vector2(shopx + 15, shopy + 18 * (a + 2) - (mplayer.floor * 9 / 2) + 2 - 360), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + ((a + 1) % 10).ToString()), new Vector2(shopx + 23, shopy + 18 * (a + 2) - (mplayer.floor * 9 / 2) + 2 - 360), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            if (Main.mouseRight)
                            {
                                mplayer.aimFloor = a + 1;
                                mplayer.TransD = true;
                                Down = false;
                                Lifebutton.Open = false;
                            }
                        }
                        else
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电梯按钮"), new Vector2(shopx + 36, shopy + 18 * (a + 2) - (mplayer.floor * 9 / 2) - 360), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + (((a + 1) - (a + 1) % 10) / 10).ToString()), new Vector2(shopx + 15, shopy + 18 * (a + 2) - (mplayer.floor * 9 / 2) + 2 - 360), null, Microsoft.Xna.Framework.Color.DarkOrange * 0.75f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + ((a + 1) % 10).ToString()), new Vector2(shopx + 23, shopy + 18 * (a + 2) - (mplayer.floor * 9 / 2) + 2 - 360), null, Microsoft.Xna.Framework.Color.DarkOrange * 0.75f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        }
                    }
                    if (a >= 27 && a < 36)
                    {
                        if (Math.Abs(vector.X - shopx - 59) <= 9 && Math.Abs(vector.Y - (shopy + 18 * (a + 3) - (mplayer.floor * 9 / 2) - 540)) <= 8)
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电梯按钮"), new Vector2(shopx + 54, shopy + 18 * (a + 3) - (mplayer.floor * 9 / 2) - 540), null, Microsoft.Xna.Framework.Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + (((a + 1) - (a + 1) % 10) / 10).ToString()), new Vector2(shopx + 33, shopy + 18 * (a + 3) - (mplayer.floor * 9 / 2) + 2 - 540), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + ((a + 1) % 10).ToString()), new Vector2(shopx + 41, shopy + 18 * (a + 3) - (mplayer.floor * 9 / 2) + 2 - 540), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            if (Main.mouseRight)
                            {
                                mplayer.aimFloor = a + 1;
                                mplayer.TransD = true;
                                Down = false;
                                Lifebutton.Open = false;
                            }
                        }
                        else
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电梯按钮"), new Vector2(shopx + 54, shopy + 18 * (a + 3) - (mplayer.floor * 9 / 2) - 540), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + (((a + 1) - (a + 1) % 10) / 10).ToString()), new Vector2(shopx + 33, shopy + 18 * (a + 3) - (mplayer.floor * 9 / 2) + 2 - 540), null, Microsoft.Xna.Framework.Color.DarkOrange * 0.75f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + ((a + 1) % 10).ToString()), new Vector2(shopx + 41, shopy + 18 * (a + 3) - (mplayer.floor * 9 / 2) + 2 - 540), null, Microsoft.Xna.Framework.Color.DarkOrange * 0.75f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        }
                    }
                    if (a >= 36 && a < 45)
                    {
                        if (Math.Abs(vector.X - shopx - 77) <= 9 && Math.Abs(vector.Y - (shopy + 18 * (a + 4) - (mplayer.floor * 9 / 2) - 720)) <= 8)
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电梯按钮"), new Vector2(shopx + 72, shopy + 18 * (a + 4) - (mplayer.floor * 9 / 2) - 720), null, Microsoft.Xna.Framework.Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + (((a + 1) - (a + 1) % 10) / 10).ToString()), new Vector2(shopx + 51, shopy + 18 * (a + 4) - (mplayer.floor * 9 / 2) + 2 - 720), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + ((a + 1) % 10).ToString()), new Vector2(shopx + 59, shopy + 18 * (a + 4) - (mplayer.floor * 9 / 2) + 2 - 720), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            if (Main.mouseRight)
                            {
                                mplayer.aimFloor = a + 1;
                                mplayer.TransD = true;
                                Down = false;
                                Lifebutton.Open = false;
                            }
                        }
                        else
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电梯按钮"), new Vector2(shopx + 72, shopy + 18 * (a + 4) - (mplayer.floor * 9 / 2) - 720), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + (((a + 1) - (a + 1) % 10) / 10).ToString()), new Vector2(shopx + 51, shopy + 18 * (a + 4) - (mplayer.floor * 9 / 2) + 2 - 720), null, Microsoft.Xna.Framework.Color.DarkOrange * 0.75f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + ((a + 1) % 10).ToString()), new Vector2(shopx + 59, shopy + 18 * (a + 4) - (mplayer.floor * 9 / 2) + 2 - 720), null, Microsoft.Xna.Framework.Color.DarkOrange * 0.75f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        }
                    }
                }
            }
            if (Up)
            {
                for (int a = mplayer.Maxfloor - 1; a > mplayer.floor - 1; a--)
                {
                    if (a < 9)
                    {
                        if (Math.Abs(vector.X - shopx - 5) <= 9 && Math.Abs(vector.Y - (shopy + 18 * a - (mplayer.floor * 9 / 2) + 5)) <= 8)
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电梯按钮"), new Vector2(shopx, shopy + 18 * a - (mplayer.floor * 9 / 2)), null, Microsoft.Xna.Framework.Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + (a + 1).ToString()), new Vector2(shopx - 16, shopy + 18 * a - (mplayer.floor * 9 / 2) + 2), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            if (Main.mouseRight)
                            {
                                mplayer.aimFloor = a + 1;
                                mplayer.TransU = true;
                                Up = false;
                                Lifebutton.Open = false;
                            }
                        }
                        else
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电梯按钮"), new Vector2(shopx, shopy + 18 * a - (mplayer.floor * 9 / 2)), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + (a + 1).ToString()), new Vector2(shopx - 16, shopy + 18 * a - (mplayer.floor * 9 / 2) + 2), null, Microsoft.Xna.Framework.Color.DarkOrange * 0.75f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        }
                    }
                    if (a >= 9 && a < 18)
                    {
                        if (Math.Abs(vector.X - shopx - 23) <= 9 && Math.Abs(vector.Y - (shopy + 18 * (a + 1) - (mplayer.floor * 9 / 2) - 180)) <= 8)
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电梯按钮"), new Vector2(shopx + 18, shopy + 18 * (a + 1) - (mplayer.floor * 9 / 2) - 180), null, Microsoft.Xna.Framework.Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + (((a + 1) - (a + 1) % 10) / 10).ToString()), new Vector2(shopx - 3, shopy + 18 * (a + 1) - (mplayer.floor * 9 / 2) + 2 - 180), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + ((a + 1) % 10).ToString()), new Vector2(shopx + 5, shopy + 18 * (a + 1) - (mplayer.floor * 9 / 2) + 2 - 180), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            if (Main.mouseRight)
                            {
                                mplayer.aimFloor = a + 1;
                                mplayer.TransU = true;
                                Up = false;
                                Lifebutton.Open = false;
                            }
                        }
                        else
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电梯按钮"), new Vector2(shopx + 18, shopy + 18 * (a + 1) - (mplayer.floor * 9 / 2) - 180), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + (((a + 1) - (a + 1) % 10) / 10).ToString()), new Vector2(shopx - 3, shopy + 18 * (a + 1) - (mplayer.floor * 9 / 2) + 2 - 180), null, Microsoft.Xna.Framework.Color.DarkOrange * 0.75f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + ((a + 1) % 10).ToString()), new Vector2(shopx + 5, shopy + 18 * (a + 1) - (mplayer.floor * 9 / 2) + 2 - 180), null, Microsoft.Xna.Framework.Color.DarkOrange * 0.75f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        }
                    }
                    if (a >= 18 && a < 27)
                    {
                        if (Math.Abs(vector.X - shopx - 41) <= 9 && Math.Abs(vector.Y - (shopy + 18 * (a + 2) - (mplayer.floor * 9 / 2) - 360)) <= 8)
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电梯按钮"), new Vector2(shopx + 36, shopy + 18 * (a + 2) - (mplayer.floor * 9 / 2) - 360), null, Microsoft.Xna.Framework.Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + (((a + 1) - (a + 1) % 10) / 10).ToString()), new Vector2(shopx + 15, shopy + 18 * (a + 2) - (mplayer.floor * 9 / 2) + 2 - 360), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + ((a + 1) % 10).ToString()), new Vector2(shopx + 23, shopy + 18 * (a + 2) - (mplayer.floor * 9 / 2) + 2 - 360), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            if (Main.mouseRight)
                            {
                                mplayer.aimFloor = a + 1;
                                mplayer.TransU = true;
                                Up = false;
                                Lifebutton.Open = false;
                            }
                        }
                        else
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电梯按钮"), new Vector2(shopx + 36, shopy + 18 * (a + 2) - (mplayer.floor * 9 / 2) - 360), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + (((a + 1) - (a + 1) % 10) / 10).ToString()), new Vector2(shopx + 15, shopy + 18 * (a + 2) - (mplayer.floor * 9 / 2) + 2 - 360), null, Microsoft.Xna.Framework.Color.DarkOrange * 0.75f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + ((a + 1) % 10).ToString()), new Vector2(shopx + 23, shopy + 18 * (a + 2) - (mplayer.floor * 9 / 2) + 2 - 360), null, Microsoft.Xna.Framework.Color.DarkOrange * 0.75f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        }
                    }
                    if (a >= 27 && a < 36)
                    {
                        if (Math.Abs(vector.X - shopx - 59) <= 9 && Math.Abs(vector.Y - (shopy + 18 * (a + 3) - (mplayer.floor * 9 / 2) - 540)) <= 8)
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电梯按钮"), new Vector2(shopx + 54, shopy + 18 * (a + 3) - (mplayer.floor * 9 / 2) - 540), null, Microsoft.Xna.Framework.Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + (((a + 1) - (a + 1) % 10) / 10).ToString()), new Vector2(shopx + 33, shopy + 18 * (a + 3) - (mplayer.floor * 9 / 2) + 2 - 540), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + ((a + 1) % 10).ToString()), new Vector2(shopx + 41, shopy + 18 * (a + 3) - (mplayer.floor * 9 / 2) + 2 - 540), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            if (Main.mouseRight)
                            {
                                mplayer.aimFloor = a + 1;
                                mplayer.TransU = true;
                                Up = false;
                                Lifebutton.Open = false;
                            }
                        }
                        else
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电梯按钮"), new Vector2(shopx + 54, shopy + 18 * (a + 3) - (mplayer.floor * 9 / 2) - 540), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + (((a + 1) - (a + 1) % 10) / 10).ToString()), new Vector2(shopx + 33, shopy + 18 * (a + 3) - (mplayer.floor * 9 / 2) + 2 - 540), null, Microsoft.Xna.Framework.Color.DarkOrange * 0.75f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + ((a + 1) % 10).ToString()), new Vector2(shopx + 41, shopy + 18 * (a + 3) - (mplayer.floor * 9 / 2) + 2 - 540), null, Microsoft.Xna.Framework.Color.DarkOrange * 0.75f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        }
                    }
                    if (a >= 36 && a < 45)
                    {
                        if (Math.Abs(vector.X - shopx - 77) <= 9 && Math.Abs(vector.Y - (shopy + 18 * (a + 4) - (mplayer.floor * 9 / 2) - 720)) <= 8)
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电梯按钮"), new Vector2(shopx + 72, shopy + 18 * (a + 4) - (mplayer.floor * 9 / 2) - 720), null, Microsoft.Xna.Framework.Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + (((a + 1) - (a + 1) % 10) / 10).ToString()), new Vector2(shopx + 51, shopy + 18 * (a + 4) - (mplayer.floor * 9 / 2) + 2 - 720), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + ((a + 1) % 10).ToString()), new Vector2(shopx + 59, shopy + 18 * (a + 4) - (mplayer.floor * 9 / 2) + 2 - 720), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            if (Main.mouseRight)
                            {
                                mplayer.aimFloor = a + 1;
                                mplayer.TransU = true;
                                Up = false;
                                Lifebutton.Open = false;
                            }
                        }
                        else
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电梯按钮"), new Vector2(shopx + 72, shopy + 18 * (a + 4) - (mplayer.floor * 9 / 2) - 720), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + (((a + 1) - (a + 1) % 10) / 10).ToString()), new Vector2(shopx + 51, shopy + 18 * (a + 4) - (mplayer.floor * 9 / 2) + 2 - 720), null, Microsoft.Xna.Framework.Color.DarkOrange * 0.75f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Tiles/电梯楼层显示标Glow" + ((a + 1) % 10).ToString()), new Vector2(shopx + 59, shopy + 18 * (a + 4) - (mplayer.floor * 9 / 2) + 2 - 720), null, Microsoft.Xna.Framework.Color.DarkOrange * 0.75f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        }
                    }
                }
            }
            if((mplayer.liftPos - player.Center).Length() > 100)
            {
                Lifebutton.Open = false;
                mplayer.liftPos = new Vector2(0, 0);
                //mplayer.关电梯 = true;
            }
            base.Draw(spriteBatch);
        }
    }
}