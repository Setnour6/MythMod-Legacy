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

namespace MythMod.UI.YinYangLife
{
    public class YinYangLife : UIState
    {
        private int num = 7;
        private int num1 = 0;
        private bool living = true;
        public static bool Open = false;
        private YinYangMain yinYangMain = new YinYangMain();
        public override void OnInitialize()
        {
            yinYangMain = new YinYangMain();
            yinYangMain.Width.Set(76, 0);
            yinYangMain.Height.Set(74, 0);
            yinYangMain.Left.Set(5, 0);
            yinYangMain.Top.Set(Main.screenHeight - 74, 0);

            yinYangMain.OnLeftMouseDown += new UIElement.MouseEvent(DragStart);
            yinYangMain.OnLeftMouseUp += new UIElement.MouseEvent(DragEnd);

            Append(yinYangMain);
        }
        Vector2 offset;
        public bool dragging = false;
        private void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            offset = new Vector2(evt.MousePosition.X - yinYangMain.Left.Pixels, evt.MousePosition.Y - yinYangMain.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            yinYangMain.Left.Set(end.X - offset.X, 0f);
            yinYangMain.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }
        private int Lm = 0;
        public static int IMFlDmg = 0;
        protected override void DrawSelf(SpriteBatch spriteBatch)
		{
            Player player = Main.player[Main.myPlayer];
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
			Vector2 vector = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            if(mplayer.YangLife <= 0 && player.name != "万象元素")
            {
                mplayer.YangLife = 0;
                if(Lm == 0)
                {
                    Lm = player.statLifeMax;
                }
                player.statLifeMax2 = 20;
            }
            if (mplayer.YangLife > 0 && mplayer.YinLife > 0 && Lm != 0)
            {
                player.statLifeMax2 = Lm;
                Lm = 0;
            }
            if (mplayer.YinLife <= 0 && player.name != "万象元素")
            {
                mplayer.YinLife = 0;
                player.statLifeMax2 = 20;
            }
            if (dragging)
            {
                yinYangMain.Left.Set(Main.mouseX - offset.X, 0f);
                yinYangMain.Top.Set(Main.mouseY - offset.Y, 0f);
                Recalculate();
            }
            if (this.yinYangMain.ContainsPoint(vector) && !player.dead)
			{
				Main.LocalPlayer.mouseInterface = true;
				Main.instance.MouseText(string.Concat(new object[]
				{
					"阴寿命: ",
					mplayer.YinLife,
					"/",
					mplayer.YinLifeMax,
                    "\n阳寿命: ",
					mplayer.YangLife,
					"/",
					mplayer.YangLifeMax
				}), 0, 0, -1, -1, -1, -1);
			}
            if(!player.dead)
            {
                living = true;
            }
            else
            {
                if(living)
                {
                    mplayer.YangLife -= 1;
                    mplayer.YinLife -= 1;
                    living = false;
                }
            }
            if(IMFlDmg > 0)
            {
                IMFlDmg--;
                if(IMFlDmg != 1)
                {
                    player.noFallDmg = true;
                }
                else
                {
                    player.noFallDmg = false;
                }
            }
            else
            {
                IMFlDmg = 0;
            }
            if (this.yinYangMain.ContainsPoint(vector) && player.dead && mplayer.YinLife > 7 && mplayer.YangLife > 7 && NPC.CountNPCS(398) == 0)
			{
				Main.LocalPlayer.mouseInterface = true;
                if (!mplayer.YinYangRe)
                {
                    Main.instance.MouseText(string.Concat(new object[]
                {
                    "阴寿命: ",
                    mplayer.YinLife,
                    "/",
                    mplayer.YinLifeMax,
                    "\n阳寿命: ",
                    mplayer.YangLife,
                    "/",
                    mplayer.YangLifeMax,
                    "\n连点这里七次,或按鼠标着不放消耗阴阳寿命各7点立即原地复活"
                }), 0, 0, -1, -1, -1, -1);
                }
                else
                {
                    Main.instance.MouseText(string.Concat(new object[]
                {
                    "阴寿命: ",
                    mplayer.YinLife,
                    "/",
                    mplayer.YinLifeMax,
                    "\n阳寿命: ",
                    mplayer.YangLife,
                    "/",
                    mplayer.YangLifeMax,
                    "\n连点这里七次,或按鼠标着不放消耗阴阳寿命各5点立即原地复活"
                }), 0, 0, -1, -1, -1, -1);
                }
                if(Main.mouseLeft && num1 % 5 == 0 && num > 1)
                {
                    num -= 1;
                    string key = num.ToString();
		            Color messageColor = new Color(173, (int)((7 - num) / 7f * 255), 43);
                    Main.NewText(Language.GetTextValue("你还需要点击" + key + "次, 即可立即原地复活"), messageColor);
                }
                num1 += 1;
                if(Main.mouseLeft && num1 % 5 == 0 && num == 1)
                {
                    num -= 1;
                    string key = num.ToString();
		            Color messageColor = Color.Green;
                    Main.NewText(Language.GetTextValue("成功复活!"), messageColor);
                }
                if(num == 0)
                {
                    Vector2 vector1 = Main.screenPosition + new Vector2(Main.screenWidth / 2 - 16, Main.screenHeight / 2 - 24);
                    if(player.name != "万象元素")
                    {
                        if(!mplayer.YinYangRe)
                        {
                            mplayer.YinLife -= 7;
                            mplayer.YangLife -= 7;
                        }
                        else
                        {
                            mplayer.YinLife -= 5;
                            mplayer.YangLife -= 5;
                        }
                    }
                    if(player.statLifeMax2 <= 200)
                    {
                        player.statLife = 100;
                    }
                    else
                    {
                        player.statLife = player.statLifeMax2 / 2;
                    }
                    mplayer.num4 = 120;
                    player.immuneTime = 120;
                    IMFlDmg = 120;
                    player.noFallDmg = true;
                    player.Spawn();
                    player.respawnTimer = 0;
                    player.position = vector1;
                    num = 7;
                }
			}
            if (this.yinYangMain.ContainsPoint(vector) && player.dead && mplayer.YinLife > 10 && mplayer.YangLife > 10 && NPC.CountNPCS(398) > 0)
			{
				Main.LocalPlayer.mouseInterface = true;
				Main.instance.MouseText(string.Concat(new object[]
				{
					"阴寿命: ",
					mplayer.YinLife,
					"/",
					mplayer.YinLifeMax,
                    "\n阳寿命: ",
					mplayer.YangLife,
					"/",
					mplayer.YangLifeMax,
                    "\n月亮领主的法力使你无法复活"
				}), 0, 0, -1, -1, -1, -1);
            }
		}
    }
    public class YinYangMain : UIElement
    {
        private float wave = 0;
        private float wave2 = 0;
        private float wave3 = 0;
        private float wave4 = 0;
        private float wave2s = 0;
        private float wave4s = 0;
        private float wave4ss = 0;
        private float wave5 = 0;
        private float wave6 = 1;
        private int Lig = 0;
        public override void Draw(SpriteBatch spriteBatch)
        {
            Player player = Main.player[Main.myPlayer];
            CalculatedStyle innerDimensions = base.GetInnerDimensions();
            float shopx = innerDimensions.X;
            float shopy = innerDimensions.Y;
            Mod mod = ModLoader.GetMod("MythMod");
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            //DynamicSpriteFont font = mod.GetFont("方正喵呜体");
            wave += player.velocity.X / 100f;
            if(Lig > 0)
            {
                Lig -= 1;
            }
            else
            {
                Lig = 0;
            }
            Vector2 mouse = new Vector2(Main.mouseX, Main.mouseY);
            Vector2 UICenter = new Vector2(shopx + 38, shopx + 37) + Main.screenPosition;

            if (this.ContainsPoint(mouse))
            {
                Lig = 10;
            }
            if (Lig > 0)
            {
                spriteBatch.Draw(mod.GetTexture("UIImages/阴阳寿命框架"), new Vector2(shopx, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
            else
            {
                spriteBatch.Draw(mod.GetTexture("UIImages/阴阳寿命框架"), new Vector2(shopx, shopy), null, Microsoft.Xna.Framework.Color.White * 0.2f, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
            for(int yang = 0;yang < 48;yang++)
            {
                if(player.velocity.Length() > wave2)
                {
                    wave2 += player.velocity.Length() / 120f;
                    wave4 += player.velocity.X / 120f;
                    wave4ss = wave4;
                    wave5 = 0;
                    wave6 = 1;
                }
                else
                {
                    wave5 += 0.004f;
                    wave2 *= 0.999f;
                    wave6 *= 0.9995f;
                    wave4 = wave4ss * (float)Math.Cos(wave5) * wave6;
                }
                int ym = (int)(64 * ((1 + Math.Sin(yang / 6d + wave) * wave2 / 400f) + wave4 * 0.025f * (yang / 48f) - wave4 * 0.015d - mplayer.YangBar));
                ym = ym > 64 ? 64 : ym;
                if (Lig > 0)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/阳寿命2"), new Vector2(shopx + 4 + yang, shopy + 6 + ym - 64 + mplayer.YangBar * 64), new Microsoft.Xna.Framework.Rectangle(yang, ym, 1, (int)(64 - ym)), Microsoft.Xna.Framework.Color.White * 0.5f, 0f, new Vector2(0, -(int)(64 * (0.97f - mplayer.YangBar))), 1f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(mod.GetTexture("UIImages/阳寿命"), new Vector2(shopx + 4 + yang, shopy + 6 + ym - 64 + mplayer.YangBar * 64), new Microsoft.Xna.Framework.Rectangle(yang, ym, 1, (int)(64 - ym)), Color.White, 0f, new Vector2(0, -(int)(64 * (1 - mplayer.YangBar))), 1f, SpriteEffects.None, 0f);
                }
                else
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/阳寿命2"), new Vector2(shopx + 4 + yang, shopy + 6 + ym - 64 + mplayer.YangBar * 64), new Microsoft.Xna.Framework.Rectangle(yang, ym, 1, (int)(64 - ym)), Microsoft.Xna.Framework.Color.White * 0.2f, 0f, new Vector2(0, -(int)(64 * (0.97f - mplayer.YangBar))), 1f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(mod.GetTexture("UIImages/阳寿命"), new Vector2(shopx + 4 + yang, shopy + 6 + ym - 64 + mplayer.YangBar * 64), new Microsoft.Xna.Framework.Rectangle(yang, ym, 1, (int)(64 - ym)), Microsoft.Xna.Framework.Color.White * 0.05f, 0f, new Vector2(0, -(int)(64 * (1 - mplayer.YangBar))), 1f, SpriteEffects.None, 0f);
                }
            }
            for (int yin = 0; yin < 50; yin++)
            {
                int yn = (int)(66 * ((1 + Math.Sin(yin / 6d + wave + Math.PI * 0.75f) * wave2 / 400f) + wave4 * 0.025f * (yin / 50f) - wave4 * 0.015d - mplayer.YinBar));
                yn = yn > 66 ? 66 : yn;
                if (Lig > 0)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/阴寿命2"), new Vector2(shopx + 22 + yin, shopy + 4 + yn - 66 + mplayer.YinBar * 66), new Microsoft.Xna.Framework.Rectangle(yin - 2, yn, 1, (int)(66 - yn)), Microsoft.Xna.Framework.Color.White * 0.5f, 0f, new Vector2(0, -(int)(66 * (0.97f - mplayer.YinBar))), 1f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(mod.GetTexture("UIImages/阴寿命"), new Vector2(shopx + 22 + yin, shopy + 4 + yn - 66 + mplayer.YinBar * 66), new Microsoft.Xna.Framework.Rectangle(yin - 2, yn, 1, (int)(66 - yn)), Color.White, 0f, new Vector2(0, -(int)(66 * (1 - mplayer.YinBar))), 1f, SpriteEffects.None, 0f);
                }
                else
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/阴寿命2"), new Vector2(shopx + 22 + yin, shopy + 4 + yn - 66 + mplayer.YinBar * 66), new Microsoft.Xna.Framework.Rectangle(yin - 2, yn, 1, (int)(66 - yn)), Microsoft.Xna.Framework.Color.White * 0.2f, 0f, new Vector2(0, -(int)(66 * (0.97f - mplayer.YinBar))), 1f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(mod.GetTexture("UIImages/阴寿命"), new Vector2(shopx + 22 + yin, shopy + 4 + yn - 66 + mplayer.YinBar * 66), new Microsoft.Xna.Framework.Rectangle(yin - 2, yn, 1, (int)(66 - yn)), Microsoft.Xna.Framework.Color.White * 0.05f, 0f, new Vector2(0, -(int)(66 * (1 - mplayer.YinBar))), 1f, SpriteEffects.None, 0f);
                }
            }
            Vector2 vector = new Vector2(Main.mouseX, Main.mouseY);
            if (ContainsPoint(vector) && player.dead && mplayer.YinLife < 10)
            {
                Main.LocalPlayer.mouseInterface = true;
                Main.instance.MouseText(string.Concat(new object[]
                {
                    "阴寿命: ",
                    mplayer.YinLife,
                    "/",
                    mplayer.YinLifeMax,
                    "\n阳寿命: ",
                    mplayer.YangLife,
                    "/",
                    mplayer.YangLifeMax
                }), 0, 0, -1, -1, -1, -1);
            }
            if (ContainsPoint(vector) && player.dead && mplayer.YangLife < 10)
            {
                Main.LocalPlayer.mouseInterface = true;
                Main.instance.MouseText(string.Concat(new object[]
                {
                    "阴寿命: ",
                    mplayer.YinLife,
                    "/",
                    mplayer.YinLifeMax,
                    "\n阳寿命: ",
                    mplayer.YangLife,
                    "/",
                    mplayer.YangLifeMax
                }), 0, 0, -1, -1, -1, -1);
            }
            //spriteBatch.Draw(mod.GetTexture("UIImages/阴寿命2"), new Vector2(shopx + 22, shopy + 4), new Microsoft.Xna.Framework.Rectangle(0, (int)(66 * (1 - mplayer.YinBar)), 50, (int)(66 * mplayer.YinBar)), Color.White * 0.5f, 0f, new Vector2(0, -(int)(66 * (0.97f - mplayer.YinBar))), 1f, SpriteEffects.None, 0f);
            //spriteBatch.Draw(mod.GetTexture("UIImages/阴寿命"), new Vector2(shopx + 22, shopy + 4), new Microsoft.Xna.Framework.Rectangle(0, (int)(66 * (1 - mplayer.YinBar)), 50, (int)(66 * mplayer.YinBar)), Color.White, 0f, new Vector2(0, -(int)(66 * (1 - mplayer.YinBar))), 1f, SpriteEffects.None, 0f);
            //spriteBatch.Draw(mod.GetTexture("UIImages/阳寿命"), new Vector2(shopx + 4, shopy + 6), new Microsoft.Xna.Framework.Rectangle(0, (int)(64 * (1 - mplayer.YangBar)), 48, (int)(64 * mplayer.YangBar)), Color.White, 0f, new Vector2(0, -(int)(64 * (1 - mplayer.YangBar))), 1f, SpriteEffects.None, 0f);
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

            //Utils.DrawBorderStringFourWay(spriteBatch, Main.fontItemStack, Main.MouseWorld - Main.screenPosition - new Vector2(shopx, shopy) + "", Main.MouseWorld.X - Main.screenPosition.X, Main.MouseWorld.Y - Main.screenPosition.Y + 50, Microsoft.Xna.Framework.Color.White, Microsoft.Xna.Framework.Color.Black, new Vector2(0.3f), 1f);
            base.Draw(spriteBatch);
        }
    }
}