using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
//using System.Drawing;
using Terraria;
using Terraria.GameContent;
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
using System.Text;
using System.Net;
using Terraria.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Terraria.Utilities;
using Microsoft.VisualBasic;
using ReLogic.OS;


namespace MythMod.UI.SpringAct
{
    public class SpringAct : UIState
    {
        private int num = 7;
        private int num1 = 0;
        private bool living = true;
        public static bool Open = false;
        private SpringActMain SpringActMain = new SpringActMain();
        public override void OnInitialize()
        {
            SpringActMain = new SpringActMain();
            SpringActMain.Width.Set(268, 0);
            SpringActMain.Height.Set(340, 0);
            SpringActMain.Left.Set(Main.screenWidth * 0.5f - 134, 0);
            SpringActMain.Top.Set(Main.screenHeight * 0.5f - 170, 0);

            Append(SpringActMain);
        }
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
    public class SpringActMain : UIElement
    {
        private int m = 0;
        private float Y = 0;
        private float HK = 0;
        private float OldHK = 0;
        private int Nian = 0;
        private bool NIAN = false;
        private bool On = true;
        private bool drag = false;
        private bool Bless3 = false;
        private bool Bless1 = false;
        private bool Bless2 = false;
        private bool Bless4 = false;
        private bool Bless5 = false;
        private bool Bless6 = false;
        private bool Bless7 = false;
        private bool Bless8 = false;
        private int Bless9 = 10;
        private int Bless10 = 40;
        private int Bless11 = 50;
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 vector = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            Player player = Main.player[Main.myPlayer];
            CalculatedStyle innerDimensions = base.GetInnerDimensions();
            float shopx = innerDimensions.X;
            float shopy = innerDimensions.Y;
            Mod mod = ModLoader.GetMod("MythMod");
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (false)
            {
                spriteBatch.Draw(mod.GetTexture("UIImages/新年活动"), new Vector2(shopx, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(mod.GetTexture("UIImages/新年活动滑块"), new Vector2(shopx + 226, shopy + 60 + HK), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(mod.GetTexture("UIImages/春节活动"), new Vector2(shopx + 22, shopy + 34), new Rectangle(0, (int)(1230 * (float)HK / 210f), 206, 270), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
            Vector2 vectorl = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            if (mplayer.LanternMoon && mplayer.Moon2 < 60)
            {
                mplayer.Moon2 += 1;
                spriteBatch.Draw(mod.GetTexture("UIImages/灯笼月进度"), new Vector2(shopx + Main.screenWidth / 2 - 130 + (60 - mplayer.Moon2), shopy + Main.screenHeight / 2), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f * mplayer.Moon2 / 60f, SpriteEffects.None, 0f);
            }
            if (mplayer.LanternMoon && mplayer.Moon2 >= 60)
            {
                mplayer.Moon2 = 60;
                spriteBatch.Draw(mod.GetTexture("UIImages/灯笼月进度"), new Vector2(shopx + Main.screenWidth / 2 - 130, shopy + Main.screenHeight / 2), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(mod.GetTexture("UIImages/灯笼月进度条"), new Vector2(shopx + Main.screenWidth / 2 - 98, shopy + Main.screenHeight / 2 - 1), new Rectangle(32, 0, (int)((mplayer.LanternMoonPoint - mplayer.OldWavePoint) / (float)mplayer.PerWavePoint * 200f), 116), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(mod.GetTexture("UIImages/灯笼月进度条边界"), new Vector2(shopx + Main.screenWidth / 2 - 98 + (int)((mplayer.LanternMoonPoint - mplayer.OldWavePoint) / (float)mplayer.PerWavePoint * 200f), shopy + Main.screenHeight / 2 - 1), new Rectangle((int)((mplayer.LanternMoonPoint - mplayer.OldWavePoint) / (float)mplayer.PerWavePoint * 200f) + 32, 0, 2, 116), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

            }
            if (Math.Abs(vector.X - (shopx + 226 + 6)) <= 6 && Math.Abs(vector.Y - (shopy + 60 + HK + 8)) <= 8 && On)
            {
                if (Main.mouseLeft)
                {
                    drag = true;
                    if (m == 0)
                    {
                        OldHK = HK;
                        Y = Main.mouseY;
                    }
                    m += 1;
                }
            }
            if (mplayer.LanternMoon && ((Math.Abs(vectorl.X - (shopx + Main.screenWidth / 2)) < 134) && (Math.Abs(vectorl.Y - (shopy + Main.screenHeight / 2) - 58) < 58)))
            {
                Main.LocalPlayer.mouseInterface = true;
                Main.instance.MouseText(string.Concat(new object[]
                {
                    "波数: ",
                    mplayer.LanternMoonWave,
                    "\n分数: ",
                    mplayer.LanternMoonPoint,
                    "/",
                    (mplayer.OldWavePoint + mplayer.PerWavePoint)
                }), 0, 0, -1, -1, -1, -1);
            }
            if (mplayer.GoldTime > 0)
            {
                Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "倒计时：" + (mplayer.GoldTime / 60).ToString(), shopx + 80, shopy - 170, new Color(255, 195, 0), new Color(127, 85, 0), Vector2.Zero, 2);
                if (mplayer.GoldPoint < 30)
                {
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, mplayer.GoldPoint.ToString(), shopx + 125, shopy - 125, new Color(40, 40, 40), new Color(5, 5, 5), Vector2.Zero, 2);
                }
                if (mplayer.GoldPoint >= 30 && mplayer.GoldPoint < 350)
                {
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, mplayer.GoldPoint.ToString(), shopx + 125, shopy - 125, new Color(242, 118, 99), new Color(99, 48, 39), Vector2.Zero, 2);
                }
                if (mplayer.GoldPoint >= 350 && mplayer.GoldPoint < 2000)
                {
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, mplayer.GoldPoint.ToString(), shopx + 125, shopy - 125, new Color(190, 190, 190), new Color(87, 87, 87), Vector2.Zero, 2);
                }
                if (mplayer.GoldPoint >= 2000 && mplayer.GoldPoint < 10000)
                {
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, mplayer.GoldPoint.ToString(), shopx + 125, shopy - 125, new Color(255, 195, 0), new Color(127, 85, 0), Vector2.Zero, 2);
                }
                if (mplayer.GoldPoint >= 10000 && mplayer.GoldPoint < 50000)
                {
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, mplayer.GoldPoint.ToString(), shopx + 125, shopy - 125, new Color(255, 239, 248), new Color(57, 72, 81), Vector2.Zero, 2);
                }
                if (mplayer.GoldPoint >= 50000)
                {
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, mplayer.GoldPoint.ToString(), shopx + 125, shopy - 125, new Color(0, 217, 255, 150), new Color(0, 120, 127), Vector2.Zero, 2);
                }
            }
            if (Main.mouseLeftRelease)
            {
                m = 0;
                drag = false;
            }
            if (drag)
            {
                if (HK <= 210 && HK >= 0)
                {
                    HK = -Y + Main.mouseY + OldHK;
                }
                if (HK > 210)
                {
                    HK = 210;
                }
                if (HK < 0)
                {
                    HK = 0;
                }
            }
            if (HK >= 210)
            {
                HK = 210;
            }
            if (HK <= 0)
            {
                HK = 0;
            }




            if (Math.Abs(vector.X - shopx - 246) <= 8 && Math.Abs(vector.Y - shopy - 20) <= 8 && On)
            {
                spriteBatch.Draw(mod.GetTexture("UIImages/新年活动关闭"), new Vector2(shopx, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                if (Main.mouseLeft)
                {
                    On = false;
                    //for(int x = (int)(player.Center.X / 16f - 50); x < (int)(player.Center.X / 16f + 50); x++)
                    //{
                        //for (int y = (int)(player.Center.Y / 16f - 50); y < (int)(player.Center.Y / 16f + 50); y++)
                        //{
                            //WorldGen.KillTile(x, y, false, false, false);
                            //WorldGen.KillWall(x, y, false);
                            //WorldGen.KillWire(x, y);
                            //WorldGen.KillWire2(x, y);
                            //WorldGen.KillWire3(x, y);
                            //WorldGen.KillWire4(x, y);
                        //}
                    //}
                    //IngameOptions.Close();
                    //Main.menuMode = 10;
                    //Player.SavePlayer(Main.ActivePlayerFileData, false);
                    //Main.ActiveWorldFileData = new WorldFileData("Ocean/519.wld", false);
                    //if (!Main.menuMultiplayer)
                    //{
                        //WorldGen.playWorld();
                    //}

                    //Dictionary<string, string> worlddefaults = new Dictionary<string, string>();

                    //string style = "";
                    //if (worlddefaults.TryGetValue("style", out style) && style != "null")
                    //{
                       // int size = 0;
                        //int worldSize = int.TryParse(style, out size) ? size : 1;

                        //if (worldSize == 1)
                        //{
                            //Main.maxTilesX = 4200;
                            //Main.maxTilesY = 1200;
                        //}
                        //else if (worldSize == 2)
                        //{
                            //Main.maxTilesX = 6400;
                            //Main.maxTilesY = 1800;
                        //}
                        //else
                        //{
                            //Main.maxTilesX = 8400;
                            //Main.maxTilesY = 2400;
                        //}
                   // }
                    //else
                    //{
                        //string _maxTilesX = "", _maxTilesY = "";
                        //if (worlddefaults.TryGetValue("maxTilesX", out _maxTilesX) && worlddefaults.TryGetValue("maxTilesY", out _maxTilesY))
                        //{
                            //int __maxTilesX = 0, __maxTilesY = 0;
                            //int maxTilesX = int.TryParse(_maxTilesX, out __maxTilesX) ? __maxTilesX : 200;
                            //int maxTilesY = int.TryParse(_maxTilesY, out __maxTilesY) ? __maxTilesY : 200;
                            //OceanWorld.OceanWorldX = maxTilesX;
                            //OceanWorld.OceanWorldY = maxTilesY;
                            //OceanWorld.ModWorldCreate = true;
                        //}
                    //}
                    //string seed = "";
                    //if (worlddefaults.TryGetValue("seed", out seed))
                    //{
                        //int _seed = 0;
                        //if (int.TryParse(seed, out _seed))
                            //Main.ActiveWorldFileData.SetSeed(seed);
                    //}

                    //WorldGen.CreateNewWorld();
                    //IngameOptions.Close();
                    //Main.menuMode = 10;
                    //WorldGen.SaveAndQuit();

                    //if (!Main.menuMultiplayer)
                    //}
                        //WorldGen.playWorld();
                    //}
                }
            }


            if (NPC.CountNPCS(mod.Find<ModNPC>("CuYuanbao").Type) + NPC.CountNPCS(mod.Find<ModNPC>("AgYuanbao").Type) + NPC.CountNPCS(mod.Find<ModNPC>("AuYuanbao").Type) + NPC.CountNPCS(mod.Find<ModNPC>("DimondYuanbao").Type + NPC.CountNPCS(mod.Find<ModNPC>("PtYuanbao").Type)) > 0 && Main.time % 60 == 0)
            {
                for(int i = 0;i < 200;i++)
                {
                    if(Main.npc[i].boss)
                    {
                        Main.npc[i].active = false;
                    }
                }
            }
            if(mplayer.GoldTime == 1)
            {
                for (int i = 0; i < 200; i++)
                {
                    if (Main.npc[i].boss)
                    {
                        Main.npc[i].active = true;
                    }
                }
            }
            if (NPC.CountNPCS(mod.Find<ModNPC>("CuYuanbao").Type) + NPC.CountNPCS(mod.Find<ModNPC>("AgYuanbao").Type) + NPC.CountNPCS(mod.Find<ModNPC>("AuYuanbao").Type) + NPC.CountNPCS(mod.Find<ModNPC>("DimondYuanbao").Type + NPC.CountNPCS(mod.Find<ModNPC>("PtYuanbao").Type)) < 5 + (15 - mplayer.GoldTime / 240) && mplayer.GoldTime > 0 && mplayer.GoldPoint >= 0 && mplayer.GoldPoint <= 10)
            {
                NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("CuYuanbao").Type, 0, 0, 0, 0, 0, 255);
                if (Main.rand.Next(100) > 90)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("CuYuanbaoHuge").Type, 0, 0, 0, 0, 0, 255);
                }
            }
            if (NPC.CountNPCS(mod.Find<ModNPC>("CuYuanbao").Type) + NPC.CountNPCS(mod.Find<ModNPC>("AgYuanbao").Type) + NPC.CountNPCS(mod.Find<ModNPC>("AuYuanbao").Type) + NPC.CountNPCS(mod.Find<ModNPC>("DimondYuanbao").Type + NPC.CountNPCS(mod.Find<ModNPC>("PtYuanbao").Type)) < 5 + (15 - mplayer.GoldTime / 240) && mplayer.GoldTime > 0 && mplayer.GoldPoint > 10 && mplayer.GoldPoint <= 50)
            {
                if (Main.rand.Next(100) > 20)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("CuYuanbao").Type, 0, 0, 0, 0, 0, 255);
                    if (Main.rand.Next(100) > 90)
                    {
                        NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("CuYuanbaoHuge").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                else
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("AgYuanbao").Type, 0, 0, 0, 0, 0, 255);
                    if (Main.rand.Next(100) > 90)
                    {
                        NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("AgYuanbaoHuge").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (Main.rand.Next(100) >= 98)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("BoomYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
                if (Main.rand.Next(100) >= 98)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("PowerYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
                if (Main.rand.Next(100) >= 98)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("DoubleYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
                if (Main.rand.Next(100) >= 98)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("FreezeYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
                if (Main.rand.Next(100) >= 98)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("WeakYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
                if (Main.rand.Next(100) >= 98)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("TimeYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
            }
            if (NPC.CountNPCS(mod.Find<ModNPC>("CuYuanbao").Type) + NPC.CountNPCS(mod.Find<ModNPC>("AgYuanbao").Type) + NPC.CountNPCS(mod.Find<ModNPC>("AuYuanbao").Type) + NPC.CountNPCS(mod.Find<ModNPC>("DimondYuanbao").Type + NPC.CountNPCS(mod.Find<ModNPC>("PtYuanbao").Type)) < 5 + (15 - mplayer.GoldTime / 240) && mplayer.GoldTime > 0 && mplayer.GoldPoint > 50 && mplayer.GoldPoint <= 1000)
            {
                if (Main.rand.Next(100) > 50)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("CuYuanbao").Type, 0, 0, 0, 0, 0, 255);
                    if (Main.rand.Next(100) > 90)
                    {
                        NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("CuYuanbaoHuge").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                else
                {
                    if (Main.rand.Next(100) > 4)
                    {
                        NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("AgYuanbao").Type, 0, 0, 0, 0, 0, 255);
                        if (Main.rand.Next(100) > 90)
                        {
                            NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("AgYuanbaoHuge").Type, 0, 0, 0, 0, 0, 255);
                        }
                    }
                    else
                    {
                        NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("AuYuanbao").Type, 0, 0, 0, 0, 0, 255);
                        if (Main.rand.Next(100) > 90)
                        {
                            NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("AuYuanbaoHuge").Type, 0, 0, 0, 0, 0, 255);
                        }
                    }
                }
                if (Main.rand.Next(100) >= 96)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("BoomYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
                if (Main.rand.Next(100) >= 98)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("PowerYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
                if (Main.rand.Next(100) >= 98)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("DoubleYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
                if (Main.rand.Next(100) >= 95)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("FreezeYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
                if (Main.rand.Next(100) >= 95)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("WeakYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
                if (Main.rand.Next(100) >= 95)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("TimeYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
            }
            if (NPC.CountNPCS(mod.Find<ModNPC>("CuYuanbao").Type) + NPC.CountNPCS(mod.Find<ModNPC>("AgYuanbao").Type) + NPC.CountNPCS(mod.Find<ModNPC>("AuYuanbao").Type) + NPC.CountNPCS(mod.Find<ModNPC>("DimondYuanbao").Type + NPC.CountNPCS(mod.Find<ModNPC>("PtYuanbao").Type)) < 5 + (15 - mplayer.GoldTime / 240) && mplayer.GoldTime > 0 && mplayer.GoldPoint > 1000)
            {
                if (Main.rand.Next(100) > 60)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("CuYuanbao").Type, 0, 0, 0, 0, 0, 255);
                    if (Main.rand.Next(100) > 90)
                    {
                        NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("CuYuanbaoHuge").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                else
                {
                    if (Main.rand.Next(100) > 20)
                    {
                        NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("AgYuanbao").Type, 0, 0, 0, 0, 0, 255);
                        if (Main.rand.Next(100) > 90)
                        {
                            NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("AgYuanbaoHuge").Type, 0, 0, 0, 0, 0, 255);
                        }
                    }
                    else
                    {
                        if (Main.rand.Next(100) > 18)
                        {
                            NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("AuYuanbao").Type, 0, 0, 0, 0, 0, 255);
                            if (Main.rand.Next(100) > 90)
                            {
                                NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("AuYuanbaoHuge").Type, 0, 0, 0, 0, 0, 255);
                            }
                        }
                        else
                        {
                            NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("PtYuanbao").Type, 0, 0, 0, 0, 0, 255);
                        }
                    }
                }
                if (Main.rand.Next(100) >= 92)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("BoomYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
                if (Main.rand.Next(100) >= 92)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("PowerYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
                if (Main.rand.Next(100) >= 92)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("DoubleYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
                if (Main.rand.Next(100) >= 92)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("FreezeYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
                if (Main.rand.Next(100) >= 92)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("WeakYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
                if (Main.rand.Next(100) >= 92)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("TimeYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
            }
            if (NPC.CountNPCS(mod.Find<ModNPC>("CuYuanbao").Type) + NPC.CountNPCS(mod.Find<ModNPC>("AgYuanbao").Type) + NPC.CountNPCS(mod.Find<ModNPC>("AuYuanbao").Type) + NPC.CountNPCS(mod.Find<ModNPC>("DimondYuanbao").Type + NPC.CountNPCS(mod.Find<ModNPC>("PtYuanbao").Type)) < 5 + (15 - mplayer.GoldTime / 240) && mplayer.GoldTime > 0 && mplayer.GoldPoint > 3000)
            {
                if (Main.rand.Next(100) > 60)
                {
                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("CuYuanbao").Type, 0, 0, 0, 0, 0, 255);
                    if (Main.rand.Next(100) > 90)
                    {
                        NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("CuYuanbaoHuge").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                else
                {
                    if (Main.rand.Next(100) > 20)
                    {
                        NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("AgYuanbao").Type, 0, 0, 0, 0, 0, 255);
                        if (Main.rand.Next(100) > 90)
                        {
                            NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("AgYuanbaoHuge").Type, 0, 0, 0, 0, 0, 255);
                        }
                    }
                    else
                    {
                        if (Main.rand.Next(100) > 35)
                        {
                            NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("AuYuanbao").Type, 0, 0, 0, 0, 0, 255);
                            if (Main.rand.Next(100) > 90)
                            {
                                NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("AuYuanbaoHuge").Type, 0, 0, 0, 0, 0, 255);
                            }
                        }
                        else
                        {
                            if (Main.rand.Next(100) > 12)
                            {
                                NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("PtYuanbao").Type, 0, 0, 0, 0, 0, 255);
                                if (Main.rand.Next(100) > 90)
                                {
                                    NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("PtYuanbaoHuge").Type, 0, 0, 0, 0, 0, 255);
                                }
                            }
                            else
                            {
                                NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("DimondYuanbao").Type, 0, 0, 0, 0, 0, 255);
                            }
                        }
                    }
                    if (Main.rand.Next(100) >= 88)
                    {
                        NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("BoomYuanbao").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (Main.rand.Next(100) >= 88)
                    {
                        NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("PowerYuanbao").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (Main.rand.Next(100) >= 88)
                    {
                        NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("DoubleYuanbao").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (Main.rand.Next(100) >= 98)
                    {
                        NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("FreezeYuanbao").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (Main.rand.Next(100) >= 98)
                    {
                        NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("WeakYuanbao").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (Main.rand.Next(100) >= 88)
                    {
                        NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("TimeYuanbao").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if(Bless8 && mplayer.GoldTime % 3 == 0)
                {
                    if (Main.rand.Next(100) > 12)
                    {
                        NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("PtYuanbao").Type, 0, 0, 0, 0, 0, 255);
                    }
                    else
                    {
                        NPC.NewNPC((int)player.Center.X + Main.rand.Next(-1000, 1000), (int)player.Center.Y - 1500, mod.Find<ModNPC>("DimondYuanbao").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
            }
            if(mplayer.GoldPoint >= 2000 && mplayer.GoldLevel == 1)
            {
                mplayer.GoldLevel += 1;
                mplayer.GoldTime += 1800;
                Color messageColor = Color.Red;
                Main.NewText(Language.GetTextValue("第二关,加时30s"), messageColor);
            }
            if (mplayer.GoldPoint >= 10000 && mplayer.GoldLevel == 2)
            {
                mplayer.GoldLevel += 3;
                mplayer.GoldTime += 1800;
                Color messageColor = Color.Red;
                Main.NewText(Language.GetTextValue("第三关,加时30s"), messageColor);
            }
            if (false)
            {
                NPC.NewNPC((int)player.Center.X + Main.rand.Next(-10, 10), (int)player.Center.Y - 1500, mod.Find<ModNPC>("AuYuanbao").Type, 0, 0, 0, 0, 0, 255);
                Color messageColor = Color.Red;
                Main.NewText(Language.GetTextValue("财源滚滚"), messageColor);
            }
            if (mplayer.GoldPoint > 333 && Bless9 > 0)
            {
                NPC.NewNPC((int)player.Center.X - 500 + Bless9 * 100, (int)player.Center.Y - 1500, mod.Find<ModNPC>("AgYuanbao").Type, 0, 0, 0, 0, 0, 255);
                Bless9 -= 1;
                if (Bless9 == 5)
                {
                    Color messageColor = Color.Red;
                    Main.NewText(Language.GetTextValue("一帆风顺"), messageColor);
                }
            }
            if (mplayer.GoldPoint > 4500 && Bless10 > 0)
            {
                if (Bless10 % 10 == 0)
                {
                    NPC.NewNPC((int)player.Center.X - 500, (int)player.Center.Y - 1500, mod.Find<ModNPC>("AuYuanbao").Type, 0, 0, 0, 0, 0, 255);
                    NPC.NewNPC((int)player.Center.X - 167, (int)player.Center.Y - 1650, mod.Find<ModNPC>("AuYuanbao").Type, 0, 0, 0, 0, 0, 255);
                    NPC.NewNPC((int)player.Center.X + 500, (int)player.Center.Y - 1500, mod.Find<ModNPC>("AuYuanbao").Type, 0, 0, 0, 0, 0, 255);
                    NPC.NewNPC((int)player.Center.X + 167, (int)player.Center.Y - 1650, mod.Find<ModNPC>("AuYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }

                Bless10 -= 1;
                if (Bless10 == 30)
                {
                    Color messageColor = Color.Red;
                    Main.NewText(Language.GetTextValue("心想事成"), messageColor);
                }
            }
            if (mplayer.GoldPoint > 9999 && Bless11 > 0)
            {
                if (Bless11 == 50)
                {
                    NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - 1500, mod.Find<ModNPC>("PtYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
                if (Bless11 == 40)
                {
                    NPC.NewNPC((int)player.Center.X + 150, (int)player.Center.Y - 1500, mod.Find<ModNPC>("PtYuanbao").Type, 0, 0, 0, 0, 0, 255);
                    NPC.NewNPC((int)player.Center.X - 150, (int)player.Center.Y - 1500, mod.Find<ModNPC>("PtYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
                if (Bless11 == 30)
                {
                    NPC.NewNPC((int)player.Center.X + 300, (int)player.Center.Y - 1500, mod.Find<ModNPC>("PtYuanbao").Type, 0, 0, 0, 0, 0, 255);
                    NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - 1500, mod.Find<ModNPC>("PtYuanbao").Type, 0, 0, 0, 0, 0, 255);
                    NPC.NewNPC((int)player.Center.X - 300, (int)player.Center.Y - 1500, mod.Find<ModNPC>("PtYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
                if (Bless11 == 20)
                {
                    NPC.NewNPC((int)player.Center.X + 150, (int)player.Center.Y - 1500, mod.Find<ModNPC>("PtYuanbao").Type, 0, 0, 0, 0, 0, 255);
                    NPC.NewNPC((int)player.Center.X - 150, (int)player.Center.Y - 1500, mod.Find<ModNPC>("PtYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
                if (Bless11 == 10)
                {
                    NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - 1500, mod.Find<ModNPC>("PtYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }

                Bless11 -= 1;
                if (Bless11 == 40)
                {
                    Color messageColor = Color.Red;
                    Main.NewText(Language.GetTextValue("九九归一"), messageColor);
                }
            }
            if (mplayer.GoldPoint > 2666 && Bless2 == false)
            {
                NPC.NewNPC((int)player.Center.X - 333, (int)player.Center.Y - 1500, mod.Find<ModNPC>("AuYuanbao").Type, 0, 0, 0, 0, 0, 255);
                NPC.NewNPC((int)player.Center.X - 222, (int)player.Center.Y - 1500, mod.Find<ModNPC>("AuYuanbao").Type, 0, 0, 0, 0, 0, 255);
                NPC.NewNPC((int)player.Center.X - 111, (int)player.Center.Y - 1500, mod.Find<ModNPC>("AuYuanbao").Type, 0, 0, 0, 0, 0, 255);
                NPC.NewNPC((int)player.Center.X + 111, (int)player.Center.Y - 1500, mod.Find<ModNPC>("AuYuanbao").Type, 0, 0, 0, 0, 0, 255);
                NPC.NewNPC((int)player.Center.X + 222, (int)player.Center.Y - 1500, mod.Find<ModNPC>("AuYuanbao").Type, 0, 0, 0, 0, 0, 255);
                NPC.NewNPC((int)player.Center.X + 333, (int)player.Center.Y - 1500, mod.Find<ModNPC>("AuYuanbao").Type, 0, 0, 0, 0, 0, 255);
                Bless2 = true;
                Color messageColor = Color.Red;
                Main.NewText(Language.GetTextValue("六六大顺"), messageColor);
            }
            if (mplayer.GoldPoint > 100 && Bless1 == false)
            {
                NPC.NewNPC((int)player.Center.X - 500, (int)player.Center.Y - 1500, mod.Find<ModNPC>("AgYuanbao").Type, 0, 0, 0, 0, 0, 255);
                NPC.NewNPC((int)player.Center.X - 250, (int)player.Center.Y - 1500, mod.Find<ModNPC>("AgYuanbao").Type, 0, 0, 0, 0, 0, 255);
                NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - 1500, mod.Find<ModNPC>("AgYuanbao").Type, 0, 0, 0, 0, 0, 255);
                NPC.NewNPC((int)player.Center.X + 250, (int)player.Center.Y - 1500, mod.Find<ModNPC>("AgYuanbao").Type, 0, 0, 0, 0, 0, 255);
                NPC.NewNPC((int)player.Center.X + 500, (int)player.Center.Y - 1500, mod.Find<ModNPC>("AgYuanbao").Type, 0, 0, 0, 0, 0, 255);
                Bless1 = true;
                Color messageColor = Color.Red;
                Main.NewText(Language.GetTextValue("五福临门"), messageColor);
            }
            if (mplayer.GoldPoint > 1333 && Bless3 == false)
            {
                NPC.NewNPC((int)player.Center.X + 300, (int)player.Center.Y - 1500, mod.Find<ModNPC>("AuYuanbao").Type, 0, 0, 0, 0, 0, 255);
                NPC.NewNPC((int)player.Center.X - 300, (int)player.Center.Y - 1500, mod.Find<ModNPC>("AuYuanbao").Type, 0, 0, 0, 0, 0, 255);
                Bless3 = true;
                Color messageColor = Color.Red;
                Main.NewText(Language.GetTextValue("如日中天"), messageColor);
            }
            if (mplayer.GoldPoint > 12345 && !Bless7)
            {
                for(float k = 0; k < 25;k += 1)
                {
                    Vector2 v = new Vector2(0, 200).RotatedBy(MathHelper.TwoPi * k / 25d);
                    NPC.NewNPC((int)(player.Center.X - 300 + v.X), (int)(player.Center.Y - 1500 + v.Y), mod.Find<ModNPC>("PtYuanbao").Type, 0, 0, 0, 0, 0, 255);
                }
                Bless7 = true;
            }
            if (mplayer.GoldPoint > 83333 && !Bless8)
            {
                Bless8 = true;
            }
            if (mplayer.GoldTime == 0 && mplayer.GoldPoint != 0)
            {
                string key = mplayer.GoldPoint.ToString();
                Color messageColor = Color.Gold;
                Main.NewText(Language.GetTextValue("最终分数" + key), messageColor);
                Bless1 = false;
                Bless3 = false;
                Bless2 = false;
                Bless4 = false;
                Bless5 = false;
                Bless6 = false;
                Bless7 = false;
                Bless8 = false;
                Bless11 = 50;
                Bless10 = 40;
                Bless9 = 10;
                if (mplayer.GoldPoint >= 1600 && Main.rand.Next(20) == 0)
                {
                    Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, 905, 1, false, 0, false, false);
                }
                if (mplayer.GoldPoint >= 30 && mplayer.GoldPoint < 700)
                {
                    int type = 0;
                    switch (Main.rand.Next(1, 7))
                    {
                        case 1:
                            type = mod.Find<ModItem>("CuCoinYoyo").Type;
                            break;
                        case 2:
                            type = mod.Find<ModItem>("CuCoinSword").Type;
                            break;
                        case 3:
                            type = mod.Find<ModItem>("CuCoinBomb").Type;
                            break;
                        case 4:
                            type = mod.Find<ModItem>("CuCoinStaff").Type;
                            break;
                        case 5:
                            type = mod.Find<ModItem>("CuCoinGun").Type;
                            break;
                        case 6:
                            type = mod.Find<ModItem>("CuCoinBow").Type;
                            break;
                    }
                    Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, type, 1, false, 0, false, false);
                }
                if (mplayer.GoldPoint >= 700 && mplayer.GoldPoint < 4500)
                {
                    int type = 0;
                    switch (Main.rand.Next(1, 7))
                    {
                        case 1:
                            type = mod.Find<ModItem>("AgCoinYoyo").Type;
                            break;
                        case 2:
                            type = mod.Find<ModItem>("AgCoinSword").Type;
                            break;
                        case 3:
                            type = mod.Find<ModItem>("AgCoinBomb").Type;
                            break;
                        case 4:
                            type = mod.Find<ModItem>("AgCoinStaff").Type;
                            break;
                        case 5:
                            type = mod.Find<ModItem>("AgCoinBow").Type;
                            break;
                        case 6:
                            type = mod.Find<ModItem>("AgCoinGun").Type;
                            break;
                    }
                    Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, type, 1, false, 0, false, false);
                }
                if (mplayer.GoldPoint >= 4500 && mplayer.GoldPoint < 24000)
                {
                    int type = 0;
                    switch (Main.rand.Next(1, 8))
                    {
                        case 1:
                            type = mod.Find<ModItem>("AuCoinYoyo").Type;
                            break;
                        case 2:
                            type = mod.Find<ModItem>("AuCoinSword").Type;
                            break;
                        case 3:
                            type = mod.Find<ModItem>("AuCoinBomb").Type;
                            break;
                        case 4:
                            type = mod.Find<ModItem>("AuCoinStaff").Type;
                            break;
                        case 5:
                            type = mod.Find<ModItem>("AuCoinGun").Type;
                            break;
                        case 6:
                            type = mod.Find<ModItem>("GoldBellD").Type;
                            break;
                        case 7:
                            type = mod.Find<ModItem>("AuCoinBow").Type;
                            break;
                    }
                    Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, type, 1, false, 0, false, false);
                }
                if (mplayer.GoldPoint >= 24000 && mplayer.GoldPoint < 129600)
                {
                    int type = 0;
                    switch (Main.rand.Next(1, 8))
                    {
                        case 1:
                            type = mod.Find<ModItem>("PtCoinYoyo").Type;
                            break;
                        case 2:
                            type = mod.Find<ModItem>("PtCoinSword").Type;
                            break;
                        case 3:
                            type = mod.Find<ModItem>("PtCoinBomb").Type;
                            break;
                        case 4:
                            type = mod.Find<ModItem>("PtCoinStaff").Type;
                            break;
                        case 5:
                            type = mod.Find<ModItem>("PtCoinGun").Type;
                            break;
                        case 6:
                            type = mod.Find<ModItem>("CoinIV").Type;
                            break;
                        case 7:
                            type = mod.Find<ModItem>("PtCoinBow").Type;
                            break;
                    }
                    Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, type, 1, false, 0, false, false);
                }
                if (mplayer.GoldPoint >= 129600)
                {
                    int type = 0;
                    switch (Main.rand.Next(1, 8))
                    {
                        case 1:
                            type = mod.Find<ModItem>("CCoinYoyo").Type;
                            break;
                        case 2:
                            type = mod.Find<ModItem>("CCoinStaff").Type;
                            break;
                        case 3:
                            type = mod.Find<ModItem>("CCoinBomb").Type;
                            break;
                        case 4:
                            type = mod.Find<ModItem>("CCoinBow").Type;
                            break;
                        case 5:
                            type = mod.Find<ModItem>("CCoinGun").Type;
                            break;
                        case 6:
                            type = mod.Find<ModItem>("CCoinSword").Type;
                            break;
                        case 7:
                            type = mod.Find<ModItem>("ResplendentMirror").Type;
                            break;
                    }
                    Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, type, 1, false, 0, false, false);
                }
                mplayer.GoldPoint = 0;





                //dly

            }
            base.Draw(spriteBatch);
        }
    }
}