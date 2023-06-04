using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection;
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
using System.Text;
using System.Net;
using Terraria.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Diagnostics;
using Terraria.Utilities;
using Microsoft.VisualBasic;
using ReLogic.OS;


namespace MythMod.UI.Stones
{
    public class Stones : UIState
    {
        private int num = 7;
        private int num1 = 0;
        private bool living = true;
        public static bool Open = false;
        private StonesMain StonesMain = new StonesMain();
        public override void OnInitialize()
        {
            StonesMain = new StonesMain();
            StonesMain.Width.Set(392, 0);
            StonesMain.Height.Set(288, 0);
            StonesMain.Left.Set(Main.screenWidth * 0.5f, 0);
            StonesMain.Top.Set(Main.screenHeight * 0.5f, 0);

            StonesMain.OnLeftMouseDown += new UIElement.MouseEvent(DragStart);
            StonesMain.OnLeftMouseUp += new UIElement.MouseEvent(DragEnd);

            Append(StonesMain);
        }
        Vector2 offset;
        public bool dragging = false;
        private void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            offset = new Vector2(evt.MousePosition.X - StonesMain.Left.Pixels, evt.MousePosition.Y - StonesMain.Top.Pixels);
            if(Main.mouseX - StonesMain.Left.Pixels < 26 || (Main.mouseY - StonesMain.Top.Pixels < 50 && Main.mouseY - StonesMain.Top.Pixels > 24) || (Main.mouseY - StonesMain.Top.Pixels < 282 && Main.mouseY - StonesMain.Top.Pixels > 236) || (Main.mouseX - StonesMain.Left.Pixels < 392 && Main.mouseX - StonesMain.Left.Pixels > 212))
            {
                dragging = true;
            }
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            if (dragging)
            {
                StonesMain.Left.Set(end.X - offset.X, 0f);
                StonesMain.Top.Set(end.Y - offset.Y, 0f);
            }

            dragging = false;

            Recalculate();
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
            if (dragging)
            {
                StonesMain.Left.Set(Main.mouseX - offset.X, 0f);
                StonesMain.Top.Set(Main.mouseY - offset.Y, 0f);
                Recalculate();
            }
            if (Math.Abs(vector.X - offset.X - 92) <= 30 && Math.Abs(vector.Y - offset.Y - 43) <= 30)
            {
                mplayer.Sto = true;
            }
            else
            {
                mplayer.Sto = false;
            }
        }
    }
    public class StonesMain : UIElement
    {
        private bool HLBZ = false;
        private float num = 0;
        private Vector2 Empty = new Vector2(2, 2);
        private Vector2 Empty2 = new Vector2(2, 2);
        private Vector2 Middle = new Vector2(1, 1);
        private Vector2 Middle2 = new Vector2(1, 1);
        private Vector2 XW = new Vector2(0, 0);
        private Vector2 ZY = new Vector2(1, 0);
        private Vector2 BK = new Vector2(2, 0);
        private Vector2 DLY = new Vector2(0, 1);
        private Vector2 HS = new Vector2(0, 2);
        private Vector2 MGY = new Vector2(1, 1);
        private Vector2 SY = new Vector2(1, 2);
        private Vector2 SM = new Vector2(2, 1);
        private Vector2 XW2 = new Vector2(0, 0);
        private Vector2 ZY2 = new Vector2(1, 0);
        private Vector2 BK2 = new Vector2(2, 0);
        private Vector2 DLY2 = new Vector2(0, 1);
        private Vector2 HS2 = new Vector2(0, 2);
        private Vector2 MGY2 = new Vector2(1, 1);
        private Vector2 SY2 = new Vector2(1, 2);
        private Vector2 SM2 = new Vector2(2, 1);
        private int XWmove = 0;
        private int ZYmove = 0;
        private int BKmove = 0;
        private int DLYmove = 0;
        private int HSmove = 0;
        private int MGYmove = 0;
        private int SYmove = 0;
        private int SMmove = 0;
        private bool Movie = false;
        private int Movietime = 0;
        private int wo = 0;
        public override void Draw(SpriteBatch spriteBatch)
        {
            num++;
            Vector2 vector = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            Player player = Main.player[Main.myPlayer];
            CalculatedStyle innerDimensions = base.GetInnerDimensions();
            float shopx = innerDimensions.X;
            float shopy = innerDimensions.Y;
            Mod mod = ModLoader.GetMod("MythMod");
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            //DynamicSpriteFont font = mod.GetFont("方正喵呜体");
            spriteBatch.Draw(mod.GetTexture("UIImages/石板底框内部"), new Vector2(shopx, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            if (HLBZ)
            {
                //spriteBatch.Draw(mod.GetTexture("UIImages/海蓝宝珠"), new Vector2(shopx + 364 - 14, shopy + 29 - 14), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(mod.GetTexture("UIImages/光球"), new Vector2(shopx + 364 - 10, shopy + 29 - 10) + new Vector2(0, 18).RotatedBy(num / 60f), null, new Color(255, 255, 255, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
            if(Movie)
            {
                for (int a = 0; a < Movietime; a++)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/光球"), new Vector2(shopx + 364 - 10, shopy + 29 - 10) + new Vector2(0, 18).RotatedBy((num + a * 4) / 60f), null, new Color(255, 255, 255, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
            }
            spriteBatch.Draw(mod.GetTexture("UIImages/石板底框"), new Vector2(shopx, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(mod.GetTexture("UIImages/贝壳符文"), new Vector2(shopx + 26 + BK.X * 63, shopy + 50 + BK.Y * 63), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(mod.GetTexture("UIImages/灯笼鱼符文"), new Vector2(shopx + 26 + DLY.X * 63, shopy + 50 + DLY.Y * 63), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(mod.GetTexture("UIImages/海蛇符文"), new Vector2(shopx + 26 + HS.X * 63, shopy + 50 + HS.Y * 63), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(mod.GetTexture("UIImages/魔鬼鱼符文"), new Vector2(shopx + 26 + MGY.X * 63, shopy + 50 + MGY.Y * 63), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(mod.GetTexture("UIImages/鲨鱼符文"), new Vector2(shopx + 26 + SY.X * 63, shopy + 50 + SY.Y * 63), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(mod.GetTexture("UIImages/水母符文"), new Vector2(shopx + 26 + SM.X * 63, shopy + 50 + SM.Y * 63), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(mod.GetTexture("UIImages/章鱼符文"), new Vector2(shopx + 26 + ZY.X * 63, shopy + 50 + ZY.Y * 63), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(mod.GetTexture("UIImages/漩涡符文"), new Vector2(shopx + 26 + XW.X * 63, shopy + 50 + XW.Y * 63), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            //spriteBatch.Draw(mod.GetTexture("UIImages/阳寿命"), Main.MouseWorld - Main.screenPosition, null, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 0f);
            /*//从外部文件加载字体文件  
            PrivateFontCollection font = new PrivateFontCollection();
            font.AddFontFile(Environment.CurrentDirectory + @"\BITSUMISHI.TTF");
            //检测字体类型是否可用
            var r = font.Families[0].IsStyleAvailable(FontStyle.Regular);
            var b = font.Families[0].IsStyleAvailable(FontStyle.Bold);
            //定义成新的字体对象
            FontFamily myFontFamily = new FontFamily(font.Families[0].Name, font);
            Font myFont = new Font(myFontFamily, 22, FontStyle.Bold);*/
            if (Math.Abs(vector.X - shopx - 364) <= 15 && Math.Abs(vector.Y - shopy - 29) <= 15 && !HLBZ)
            {
                spriteBatch.Draw(mod.GetTexture("Items/Gems/MysteriesPearl"), new Vector2(Main.mouseX + 18, Main.mouseY + 18), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);

                if (Main.mouseRight && !HLBZ && NPC.CountNPCS(mod.Find<ModNPC>("OceanCrystal").Type) < 1)
                {
                    for (int num66 = 0; num66 < 58; num66++)
                    {
                        if (player.inventory[num66].type == mod.Find<ModItem>("MysteriesPearl").Type && player.inventory[num66].stack > 0)
                        {
                            player.inventory[num66].stack--;
                            HLBZ = true;
                        }
                    }
                }
            }
            if (HLBZ)
            {
                spriteBatch.Draw(mod.GetTexture("UIImages/海蓝宝珠"), new Vector2(shopx + 364 - 14, shopy + 29 - 14), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                //spriteBatch.Draw(mod.GetTexture("UIImages/光球"), new Vector2(shopx + 364 - 10, shopy + 29 - 10) + new Vector2(0, 18).RotatedBy(num / 60f), null, new Color(255,255,255,0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
            if(XWmove > 0)
            {
                XW += (Empty2 - Middle2) * 0.1f;
                XWmove -= 1;
            }
            if(XWmove == 0)
            {
                XW = XW2;
            }
            if (Math.Abs(vector.X - shopx - 26 - 34 - XW.X * 63) <= 30 && Math.Abs(vector.Y - shopy - 50 - 34 - XW.Y * 63) <= 30)
            {
                spriteBatch.Draw(mod.GetTexture("UIImages/奇怪的石块"), new Vector2(Main.mouseX, Main.mouseY + 28), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                if (Main.mouseLeft)
                {
                    if(new Vector2(XW.X + 1, XW.Y) == Empty || new Vector2(XW.X, XW.Y + 1) == Empty || new Vector2(XW.X - 1, XW.Y) == Empty || new Vector2(XW.X, XW.Y - 1) == Empty)
                    {
                        Middle = XW;
                        Middle2 = XW;
                        XWmove = 10;
                        XW2 = Empty;
                        Empty2 = Empty;
                        Empty = Middle; 
                    }  
                }
            }
            if (ZYmove > 0)
            {
                ZY += (Empty2 - Middle2) * 0.1f;
                ZYmove -= 1;
            }
            if (ZYmove == 0)
            {
                ZY = ZY2;
            }
            if (Math.Abs(vector.X - shopx - 26 - 34 - ZY.X * 63) <= 30 && Math.Abs(vector.Y - shopy - 50 - 34 - ZY.Y * 63) <= 30)
            {
                spriteBatch.Draw(mod.GetTexture("UIImages/奇怪的石块"), new Vector2(Main.mouseX, Main.mouseY + 28), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                if (Main.mouseLeft)
                {
                    if (new Vector2(ZY.X + 1, ZY.Y) == Empty || new Vector2(ZY.X, ZY.Y + 1) == Empty || new Vector2(ZY.X - 1, ZY.Y) == Empty || new Vector2(ZY.X, ZY.Y - 1) == Empty)
                    {
                        Middle = ZY;
                        Middle2 = ZY;
                        ZYmove = 10;
                        ZY2 = Empty;
                        Empty2 = Empty;
                        Empty = Middle;
                    }
                }
            }
            if (BKmove > 0)
            {
                BK += (Empty2 - Middle2) * 0.1f;
                BKmove -= 1;
            }
            if (BKmove == 0)
            {
                BK = BK2;
            }
            if (Math.Abs(vector.X - shopx - 26 - 34 - BK.X * 63) <= 30 && Math.Abs(vector.Y - shopy - 50 - 34 - BK.Y * 63) <= 30)
            {
                spriteBatch.Draw(mod.GetTexture("UIImages/奇怪的石块"), new Vector2(Main.mouseX, Main.mouseY + 28), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                if (Main.mouseLeft)
                {
                    if (new Vector2(BK.X + 1, BK.Y) == Empty || new Vector2(BK.X, BK.Y + 1) == Empty || new Vector2(BK.X - 1, BK.Y) == Empty || new Vector2(BK.X, BK.Y - 1) == Empty)
                    {
                        Middle = BK;
                        Middle2 = BK;
                        BKmove = 10;
                        BK2 = Empty;
                        Empty2 = Empty;
                        Empty = Middle;
                    }
                }
            }
            if (MGYmove > 0)
            {
                MGY += (Empty2 - Middle2) * 0.1f;
                MGYmove -= 1;
            }
            if (MGYmove == 0)
            {
                MGY = MGY2;
            }
            if (Math.Abs(vector.X - shopx - 26 - 34 - MGY.X * 63) <= 30 && Math.Abs(vector.Y - shopy - 50 - 34 - MGY.Y * 63) <= 30)
            {
                spriteBatch.Draw(mod.GetTexture("UIImages/奇怪的石块"), new Vector2(Main.mouseX, Main.mouseY + 28), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                if (Main.mouseLeft)
                {
                    if (new Vector2(MGY.X + 1, MGY.Y) == Empty || new Vector2(MGY.X, MGY.Y + 1) == Empty || new Vector2(MGY.X - 1, MGY.Y) == Empty || new Vector2(MGY.X, MGY.Y - 1) == Empty)
                    {
                        Middle = MGY;
                        Middle2 = MGY;
                        MGYmove = 10;
                        MGY2 = Empty;
                        Empty2 = Empty;
                        Empty = Middle;
                    }
                }
            }
            if (SMmove > 0)
            {
                SM += (Empty2 - Middle2) * 0.1f;
                SMmove -= 1;
            }
            if (SMmove == 0)
            {
                SM = SM2;
            }
            if (Math.Abs(vector.X - shopx - 26 - 34 - SM.X * 63) <= 30 && Math.Abs(vector.Y - shopy - 50 - 34 - SM.Y * 63) <= 30)
            {
                spriteBatch.Draw(mod.GetTexture("UIImages/奇怪的石块"), new Vector2(Main.mouseX, Main.mouseY + 28), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                if (Main.mouseLeft)
                {
                    if (new Vector2(SM.X + 1, SM.Y) == Empty || new Vector2(SM.X, SM.Y + 1) == Empty || new Vector2(SM.X - 1, SM.Y) == Empty || new Vector2(SM.X, SM.Y - 1) == Empty)
                    {
                        Middle = SM;
                        Middle2 = SM;
                        SMmove = 10;
                        SM2 = Empty;
                        Empty2 = Empty;
                        Empty = Middle;
                    }
                }
            }
            if (DLYmove > 0)
            {
                DLY += (Empty2 - Middle2) * 0.1f;
                DLYmove -= 1;
            }
            if (DLYmove == 0)
            {
                DLY = DLY2;
            }
            if (Math.Abs(vector.X - shopx - 26 - 34 - DLY.X * 63) <= 30 && Math.Abs(vector.Y - shopy - 50 - 34 - DLY.Y * 63) <= 30)
            {
                spriteBatch.Draw(mod.GetTexture("UIImages/奇怪的石块"), new Vector2(Main.mouseX, Main.mouseY + 28), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                if (Main.mouseLeft)
                {
                    if (new Vector2(DLY.X + 1, DLY.Y) == Empty || new Vector2(DLY.X, DLY.Y + 1) == Empty || new Vector2(DLY.X - 1, DLY.Y) == Empty || new Vector2(DLY.X, DLY.Y - 1) == Empty)
                    {
                        Middle = DLY;
                        Middle2 = DLY;
                        DLYmove = 10;
                        DLY2 = Empty;
                        Empty2 = Empty;
                        Empty = Middle;
                    }
                }
            }
            if (SYmove > 0)
            {
                SY += (Empty2 - Middle2) * 0.1f;
                SYmove -= 1;
            }
            if (SYmove == 0)
            {
                SY = SY2;
            }
            if (Math.Abs(vector.X - shopx - 26 - 34 - SY.X * 63) <= 30 && Math.Abs(vector.Y - shopy - 50 - 34 - SY.Y * 63) <= 30)
            {
                spriteBatch.Draw(mod.GetTexture("UIImages/奇怪的石块"), new Vector2(Main.mouseX, Main.mouseY + 28), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                if (Main.mouseLeft)
                {
                    if (new Vector2(SY.X + 1, SY.Y) == Empty || new Vector2(SY.X, SY.Y + 1) == Empty || new Vector2(SY.X - 1, SY.Y) == Empty || new Vector2(SY.X, SY.Y - 1) == Empty)
                    {
                        Middle = SY;
                        Middle2 = SY;
                        SYmove = 10;
                        SY2 = Empty;
                        Empty2 = Empty;
                        Empty = Middle;
                    }
                }
            }
            if (HSmove > 0)
            {
                HS += (Empty2 - Middle2) * 0.1f;
                HSmove -= 1;
            }
            if (HSmove == 0)
            {
                HS = HS2;
            }
            if (Math.Abs(vector.X - shopx - 26 - 34 - HS.X * 63) <= 30 && Math.Abs(vector.Y - shopy - 50 - 34 - HS.Y * 63) <= 30)
            {
                spriteBatch.Draw(mod.GetTexture("UIImages/奇怪的石块"), new Vector2(Main.mouseX, Main.mouseY + 28), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                if (Main.mouseLeft)
                {
                    if (new Vector2(HS.X + 1, HS.Y) == Empty || new Vector2(HS.X, HS.Y + 1) == Empty || new Vector2(HS.X - 1, HS.Y) == Empty || new Vector2(HS.X, HS.Y - 1) == Empty)
                    {
                        Middle = HS;
                        Middle2 = HS;
                        HSmove = 10;
                        HS2 = Empty;
                        Empty2 = Empty;
                        Empty = Middle;
                    }
                }
            }
            if(HLBZ && BK == new Vector2(0,0) && BK == new Vector2(0, 0) && MGY == new Vector2(1, 0) && ZY == new Vector2(2, 0) && DLY == new Vector2(0, 1) && HS == new Vector2(0, 2) && SY == new Vector2(1, 2) && SM == new Vector2(2, 1) && XW == new Vector2(2, 2))
            {
                Movie = true;
            }
            if (HLBZ && MythWorld.downedHYFY && BK == new Vector2(0, 1) && MGY == new Vector2(1, 0) && ZY == new Vector2(0, 2) && DLY == new Vector2(2, 2) && HS == new Vector2(2, 1) && SY == new Vector2(2, 0) && SM == new Vector2(0, 0) && XW == new Vector2(1, 1))
            {
                if (Main.worldName != mplayer.worldnm)
                {
                    Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, mod.Find<ModItem>("OceanWorld").Type, 1, false, 0, false, false);
                    Dictionary<string, string> worlddefaults = new Dictionary<string, string>();
                    Main.menuMode = 10;

                    int nums = 200;
                    FieldInfo field = typeof(WorldFileData).GetField("WorldSizeY", BindingFlags.Instance | BindingFlags.Public);
                    field.SetValue(Main.ActiveWorldFileData, nums);
                    FieldInfo field2 = typeof(WorldGen).GetField("lastMaxTilesY", BindingFlags.Static | BindingFlags.NonPublic);
                    field2.SetValue(null, nums);
                    MethodInfo method = typeof(Main).GetMethod("InitMap", BindingFlags.Instance | BindingFlags.NonPublic);
                    method.Invoke(Main.instance, null);

                    Player.SavePlayer(Main.ActivePlayerFileData, false);
                    WorldGen.SaveAndQuit();
                    if (!File.Exists("Ocean/" + Main.worldName + "Ocean" + "wld.bak"))
                    {
                        mplayer.create = true;
                    }
                    else
                    {
                        mplayer.create = false;
                    }
                    if (MythWorld.downedHYFY && mplayer.worldnm != Main.worldName)
                    {
                        mplayer.worldnm = Main.worldName;
                    }
                    //if (!File.Exists("Ocean/" + Main.worldName + "Ocean" + ".wld"))
                    //{
                    Main.ActiveWorldFileData = new WorldFileData("Ocean/" + Main.worldName + "Ocean" + ".wld", false);
                    //}
                    //else
                    //{
                    //WorldFileData.FromInvalidWorld("Ocean/" + Main.worldName + "Ocean" + ".wld", false);
                    //}
                    WorldGen.playWorld();
                    player.position = new Vector2(20, Main.maxTilesY / 10f + 60) * 16f;
                    MythWorld.WorldType = 1;
                    HLBZ = false;
                    Stones.Open = false;
                }
            }
            if (HLBZ && player.name == ("万象元素") && Stones.Open && MythWorld.downedHYFY)
            {
                if (Main.worldName != mplayer.worldnm)
                {
                    Dictionary<string, string> worlddefaults = new Dictionary<string, string>();
                    Main.menuMode = 10;

                    int nums = 200;
                    FieldInfo field = typeof(WorldFileData).GetField("WorldSizeY", BindingFlags.Instance | BindingFlags.Public);
                    field.SetValue(Main.ActiveWorldFileData, nums);
                    FieldInfo field2 = typeof(WorldGen).GetField("lastMaxTilesY", BindingFlags.Static | BindingFlags.NonPublic);
                    field2.SetValue(null, nums);
                    MethodInfo method = typeof(Main).GetMethod("InitMap", BindingFlags.Instance | BindingFlags.NonPublic);
                    method.Invoke(Main.instance, null);

                    Player.SavePlayer(Main.ActivePlayerFileData, false);
                    WorldGen.SaveAndQuit();
                    if (!File.Exists("Ocean/" + Main.worldName + "Ocean" + "wld.bak"))
                    {
                        mplayer.create = true;
                    }
                    else
                    {
                        mplayer.create = false;
                    }
                    if(Main.expertMode)
                    {
                        mplayer.wExpert = true;
                    }
                    if (MythWorld.Myth)
                    {
                        mplayer.wMyth = true;
                    }
                    if (MythWorld.downedHYFY && mplayer.worldnm != Main.worldName)
                    {
                        mplayer.worldnm = Main.worldName;
                    }
                    //if (!File.Exists("Ocean/" + Main.worldName + "Ocean" + ".wld"))
                    //{
                    Main.ActiveWorldFileData = new WorldFileData("Ocean/" + Main.worldName + "Ocean" + ".wld", false);
                    //}
                    //else
                    //{
                    //WorldFileData.FromInvalidWorld("Ocean/" + Main.worldName + "Ocean" + ".wld", false);
                    //}
                    WorldGen.playWorld();
                    player.position = new Vector2(20, Main.maxTilesY / 10f + 60) * 16f;
                    MythWorld.WorldType = 1;
                    HLBZ = false;
                    Stones.Open = false;
                }
            }
            if (Movie)
            {
                Movietime += 1;
                mplayer.movieTime = Movietime;

                spriteBatch.Draw(mod.GetTexture("UIImages/石板底框光效"), new Vector2(shopx, shopy), null, new Color(Movietime / 120f, Movietime / 120f, Movietime / 120f, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(mod.GetTexture("UIImages/贝壳符文light"), new Vector2(shopx + 26 + BK.X * 63, shopy + 50 + BK.Y * 63), null, new Color(Movietime / 120f, Movietime / 120f, Movietime / 120f, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(mod.GetTexture("UIImages/灯笼鱼符文light"), new Vector2(shopx + 26 + DLY.X * 63, shopy + 50 + DLY.Y * 63), null, new Color(Movietime / 120f, Movietime / 120f, Movietime / 120f, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(mod.GetTexture("UIImages/海蛇符文light"), new Vector2(shopx + 26 + HS.X * 63, shopy + 50 + HS.Y * 63), null, new Color(Movietime / 120f, Movietime / 120f, Movietime / 120f, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(mod.GetTexture("UIImages/魔鬼鱼符文light"), new Vector2(shopx + 26 + MGY.X * 63, shopy + 50 + MGY.Y * 63), null, new Color(Movietime / 120f, Movietime / 120f, Movietime / 120f, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(mod.GetTexture("UIImages/鲨鱼符文light"), new Vector2(shopx + 26 + SY.X * 63, shopy + 50 + SY.Y * 63), null, new Color(Movietime / 120f, Movietime / 120f, Movietime / 120f, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(mod.GetTexture("UIImages/水母符文light"), new Vector2(shopx + 26 + SM.X * 63, shopy + 50 + SM.Y * 63), null, new Color(Movietime / 120f, Movietime / 120f, Movietime / 120f, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(mod.GetTexture("UIImages/章鱼符文light"), new Vector2(shopx + 26 + ZY.X * 63, shopy + 50 + ZY.Y * 63), null, new Color(Movietime / 120f, Movietime / 120f, Movietime / 120f, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(mod.GetTexture("UIImages/漩涡符文light"), new Vector2(shopx + 26 + XW.X * 63, shopy + 50 + XW.Y * 63), null, new Color(Movietime / 120f, Movietime / 120f, Movietime / 120f, 0), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                if (Movietime >= 120)
                {
                    HLBZ = false;
                    Stones.Open = false;
                    NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - 200, mod.Find<ModNPC>("OceanCrystal").Type, 0, 0, 0, 0, 255);
                    Movie = false;
                    mplayer.movieTime = 0;
                    Movietime = 0;
                }
            }
            //Utils.DrawBorderStringFourWay(spriteBatch, Main.fontItemStack, Main.MouseWorld - Main.screenPosition - new Vector2(shopx, shopy) + "", Main.MouseWorld.X - Main.screenPosition.X, Main.MouseWorld.Y - Main.screenPosition.Y + 50, Microsoft.Xna.Framework.Color.White, Microsoft.Xna.Framework.Color.Black, new Vector2(0.3f), 1f);
            base.Draw(spriteBatch);
        }
    }
}