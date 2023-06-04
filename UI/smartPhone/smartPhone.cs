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


namespace MythMod.UI.smartPhone
{
    public class smartPhone : UIState
    {
        private int num = 7;
        private int num1 = 0;
        private bool living = true;
        public static bool Open = false;
        private smartPhoneMain smartPhoneMain = new smartPhoneMain();
        public override void OnInitialize()
        {
            smartPhoneMain = new smartPhoneMain();
            smartPhoneMain.Width.Set(268, 0);
            smartPhoneMain.Height.Set(340, 0);
            smartPhoneMain.Left.Set(Main.screenWidth * 0.5f - 134, 0);
            smartPhoneMain.Top.Set(Main.screenHeight * 0.5f - 220, 0);
            smartPhoneMain.OnLeftMouseDown += new UIElement.MouseEvent(DragStart);
            smartPhoneMain.OnLeftMouseUp += new UIElement.MouseEvent(DragEnd);

            Append(smartPhoneMain);
        }
        Vector2 offset;
        public bool dragging = false;
        private void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            offset = new Vector2(evt.MousePosition.X - smartPhoneMain.Left.Pixels, evt.MousePosition.Y - smartPhoneMain.Top.Pixels);
            if (Main.mouseX - smartPhoneMain.Left.Pixels < 8 || (Main.mouseY - smartPhoneMain.Top.Pixels < 50 && Main.mouseY - smartPhoneMain.Top.Pixels > 0) || (Main.mouseY - smartPhoneMain.Top.Pixels < 476 && Main.mouseY - smartPhoneMain.Top.Pixels > 446) || (Main.mouseX - smartPhoneMain.Left.Pixels < 286 && Main.mouseX - smartPhoneMain.Left.Pixels > 276))
            {
                dragging = true;
            }
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            if (dragging)
            {
                smartPhoneMain.Left.Set(end.X - offset.X, 0f);
                smartPhoneMain.Top.Set(end.Y - offset.Y, 0f);
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
                smartPhoneMain.Left.Set(Main.mouseX - offset.X, 0f);
                smartPhoneMain.Top.Set(Main.mouseY - offset.Y, 0f);
                Recalculate();
            }
        }
    }
    public class smartPhoneMain : UIElement
    {
        private int m = 0;
        private float Y = 0;
        private float HK = 0;
        private float OldHK = 0;
        public static int Book = 0;
        private int BookPage = 1;
        private int Nian = 0;
        private bool NIAN = false;
        private bool On = true;
        private bool drag = false;
        private int[,] Shop = new int[4, 4];
        private int[,] ShopStack = new int[4, 4];
        private bool[,] checkOn = new bool[4, 4];
        private bool[,] SoldOut = new bool[4, 4];
        private bool Onload = true;
        private bool AddC = false;
        private int AddCco = 0;
        private int Checkco = 0;
        private int NoEnoughMoney = 0;
        private int Refco = 0;
        private bool signalWeak = false;
        private Vector2 sp = new Vector2(-1, -1);
        private int SigS = 4;
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 vector = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            Player player = Main.player[Main.myPlayer];
            CalculatedStyle innerDimensions = base.GetInnerDimensions();
            float shopx = innerDimensions.X;
            float shopy = innerDimensions.Y;
            Mod mod = ModLoader.GetMod("MythMod");
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Vector2 worldPos = Main.screenPosition + new Vector2(shopx, shopy) + new Vector2(203, 114);
            Vector2 texPos = worldPos  - Main.screenPosition;
            Vector2 worldPos2 = Main.screenPosition + new Vector2(shopx, shopy) + new Vector2(112, 421);
            Vector2 texPos2 = worldPos2 - Main.screenPosition;
            Vector2 worldPos3 = Main.screenPosition + new Vector2(shopx, shopy) + new Vector2(60, 185);
            Vector2 texPos3 = worldPos3 - Main.screenPosition;
            Vector2 worldPos4 = Main.screenPosition + new Vector2(shopx, shopy) + new Vector2(20, 39);
            Vector2 texPos4 = worldPos4 - Main.screenPosition;
            if (Book == 0)
            {
                int[] shopList =
                { 38, 40, 41, 31, 28, 188, 189, 110, 274, 265, 288, 289, 290, 291, 292, 293, 294, 295, 296, 297, 298, 299, 300, 301, 302, 303, 304, 305, 509, 510 , mod.Find<ModItem>("Rice").Type,  mod.Find<ModItem>("LazarBattery").Type, mod.Find<ModItem>("TNTBoom").Type, mod.Find<ModItem>("MysteriesBroken").Type,  mod.Find<ModItem>("ShellBell").Type, mod.Find<ModItem>("Shell10").Type, mod.Find<ModItem>("Shell7").Type, mod.Find<ModItem>("MesslessPotion").Type, mod.Find<ModItem>("AngerPotion").Type, mod.Find<ModItem>("Thunderwater").Type, mod.Find<ModItem>("LittleYangLifePotion").Type, mod.Find<ModItem>("LittleYinLifePotion").Type, mod.Find<ModItem>("YangLifePotion").Type, mod.Find<ModItem>("YinLifePotion").Type, mod.Find<ModItem>("RainPotion").Type, mod.Find<ModItem>("LoveArrow").Type
            , mod.Find<ModItem>("Passionfruit").Type, mod.Find<ModItem>("Strawberry").Type, mod.Find<ModItem>("Guava").Type, mod.Find<ModItem>("Cantaloupe").Type, mod.Find<ModItem>("litchi").Type, mod.Find<ModItem>("WaxApple").Type, mod.Find<ModItem>("Durian").Type, mod.Find<ModItem>("Kiwi").Type, mod.Find<ModItem>("Avocado").Type, mod.Find<ModItem>("Mangosteen").Type, mod.Find<ModItem>("Pomegranate").Type, mod.Find<ModItem>("Watermenlon").Type, mod.Find<ModItem>("PirateFlag").Type, mod.Find<ModItem>("HugeBlueStarfish").Type, mod.Find<ModItem>("HugeOrangeStarfish").Type, mod.Find<ModItem>("RedLantern").Type, mod.Find<ModItem>("KongmingLamp").Type, mod.Find<ModItem>("Mooncake").Type, mod.Find<ModItem>("Geoduck").Type, mod.Find<ModItem>("Zongzi").Type, mod.Find<ModItem>("BloodLamp").Type, mod.Find<ModItem>("Mussel").Type, mod.Find<ModItem>("Pepper").Type, mod.Find<ModItem>("FIshegg").Type, mod.Find<ModItem>("JuiceMachine").Type, mod.Find<ModItem>("SeaUrchin").Type, mod.Find<ModItem>("YellowChrysanthemum").Type, mod.Find<ModItem>("WhiteChrysanthemum").Type, mod.Find<ModItem>("Smoke").Type, mod.Find<ModItem>("Redcandle").Type
            , mod.Find<ModItem>("Egg").Type, mod.Find<ModItem>("RedWine").Type, mod.Find<ModItem>("Pan").Type, mod.Find<ModItem>("Oyster").Type, mod.Find<ModItem>("GlowingShrimp").Type, mod.Find<ModItem>("Squid").Type, mod.Find<ModItem>("Saury").Type, mod.Find<ModItem>("Flashlight").Type, mod.Find<ModItem>("Flashlight2").Type, 341, 348, 351, 358, 352, 363, 3202, 526, 527, 528, 511, 512, 513, 538, 583, 584, 585, 669, 1244, 2769, 2290, 2291, 2292, 2289, 2373, 2375, 2354, 1288, 1289, 1282, 1283, 1284, 1285, 1286, 1287, 2297, 2298, 2299, 2300, 2301, 1873, 1918, 3730, 3731, 3732, 3733, 3734, 3735, 3736, 3737, 3738, 3739, 3740, 3741, 3742, 3743, 3744, 3745, 3746, 3747, 3748, 3749, mod.Find<ModItem>("Coke").Type, mod.Find<ModItem>("Sprite").Type, mod.Find<ModItem>("PixelLover").Type, mod.Find<ModItem>("LavaDrink").Type, mod.Find<ModItem>("LightPipe").Type};
                int[] shopListRare =
            {mod.Find<ModItem>("BayBerryBubbleDrink").Type, mod.Find<ModItem>("GreenHatDrink").Type,mod.Find<ModItem>("WithOutBerryDrink").Type, mod.Find<ModItem>("YoghurtCaribbeanDrink").Type, mod.Find<ModItem>("LonelyJellyDrink").Type, mod.Find<ModItem>("MageliteDrink").Type, mod.Find<ModItem>("MagicalPlanitDrink").Type, mod.Find<ModItem>("OceanCatchDrink").Type, mod.Find<ModItem>("PurpleFreezeDrink").Type, mod.Find<ModItem>("SouthAmMitNightDrink").Type, mod.Find<ModItem>("TrafficLightDrink").Type, mod.Find<ModItem>("U8GrapefruitDrink").Type, mod.Find<ModItem>("TequilaSunriseDrink").Type, mod.Find<ModItem>("SunsetGlowDrink").Type, mod.Find<ModItem>("PurpleFreezeDrink").Type, mod.Find<ModItem>("SummerStarrySkyDrink").Type, mod.Find<ModItem>("StrawberryMojituoDrink").Type, mod.Find<ModItem>("SingaporeSlingDrink").Type, mod.Find<ModItem>("SglyBeerDrink").Type, mod.Find<ModItem>("SexOnTheBeachDrink").Type, mod.Find<ModItem>("SeaFlowerDrink").Type, mod.Find<ModItem>("ScrewdriverDrink").Type, mod.Find<ModItem>("PurpleCrystalDrink").Type, mod.Find<ModItem>("PinkLadyDrink").Type, mod.Find<ModItem>("PinaColadaDrink").Type, mod.Find<ModItem>("OrangeDrink").Type, mod.Find<ModItem>("NorthLandSpringDrink").Type, mod.Find<ModItem>("MoonTonightDrink").Type, mod.Find<ModItem>("MexicanDrink").Type, mod.Find<ModItem>("LotusNightDrink").Type, mod.Find<ModItem>("LavenderDrink").Type, mod.Find<ModItem>("JinglingMojituoDrink").Type, mod.Find<ModItem>("JinglingFeishiDrink").Type, mod.Find<ModItem>("GoldFeishiDrink").Type, mod.Find<ModItem>("FirstLoveDrink").Type, mod.Find<ModItem>("DryMartini").Type, mod.Find<ModItem>("DaturaImpression").Type, mod.Find<ModItem>("CubaLibreDrink").Type, mod.Find<ModItem>("PurpleFreezeDrink").Type, mod.Find<ModItem>("BurningHellDrink").Type, mod.Find<ModItem>("BoluolitaDrink").Type, mod.Find<ModItem>("BlueHawaiiDrink").Type, mod.Find<ModItem>("BloodyMarieDrink").Type, mod.Find<ModItem>("B25Drink").Type};
                if ((int)(Main.time / 8f) % 1024 <= 738)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/JungleBackground"), new Vector2(shopx, shopy), new Rectangle((int)(Main.time / 8f) % 1024, 0, 286, 476), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
                else
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/JungleBackground"), new Vector2(shopx, shopy), new Rectangle((int)(Main.time / 8f) % 1024, 0, 1024 - (int)(Main.time / 8f) % 1024, 476), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(mod.GetTexture("UIImages/JungleBackground"), new Vector2(shopx + (1024 - (int)(Main.time / 8f) % 1024), shopy), new Rectangle(0, 0, 286 - (1024 - (int)(Main.time / 8f) % 1024), 476), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
                spriteBatch.Draw(mod.GetTexture("UIImages/电子商城界面"), new Vector2(shopx, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                if (sp.X >= 0 && sp.Y >= 0)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/电子商城选中"), new Vector2(shopx + 60 * sp.X, shopy + 63 * sp.Y), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        if (checkOn[x, y] && !SoldOut[x, y])
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电子商城原版选中"), new Vector2(shopx + 60 * x, shopy + 63 * y), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        }
                        if (SoldOut[x, y])
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/电子商城卖完"), new Vector2(shopx + 60 * x, shopy + 63 * y), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        }
                    }
                }
                if (AddC)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/电子商城界面2"), new Vector2(shopx, shopy), null, new Color((AddCco) / 15f, (AddCco) / 15f, (AddCco) / 15f, (AddCco) / 15f), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(mod.GetTexture("UIImages/电子商城充值界面"), new Vector2(shopx, shopy), null, new Color((15 - AddCco) / 15f, (15 - AddCco) / 15f, (15 - AddCco) / 15f, (15 - AddCco) / 15f), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    if ((new Vector2(Main.mouseX, Main.mouseY) - new Vector2(shopx + 122, shopy + 75)).Length() <= 11 && !signalWeak)
                    {
                        spriteBatch.Draw(mod.GetTexture("UIImages/按下Cu"), new Vector2(shopx, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "按下充值1铜", Main.mouseX + 20, Main.mouseY + 20, Color.White, Color.Black, Vector2.Zero);
                        if (Main.mouseLeft && AddCco == 0)
                        {
                            for (int num66 = 0; num66 < 58; num66++)
                            {
                                if (player.inventory[num66].type == 71 && player.inventory[num66].stack > 0)
                                {
                                    player.inventory[num66].stack--;
                                    mplayer.Elecoin += 1;
                                    break;
                                }
                            }
                        }
                    }
                    if ((new Vector2(Main.mouseX, Main.mouseY) - new Vector2(shopx + 162, shopy + 75)).Length() <= 11 && !signalWeak)
                    {
                        spriteBatch.Draw(mod.GetTexture("UIImages/按下Ag"), new Vector2(shopx, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "按下充值1银", Main.mouseX - 40, Main.mouseY + 20, Color.White, Color.Black, Vector2.Zero);
                        if (Main.mouseLeft && AddCco == 0)
                        {
                            AddCco = 1;
                            for (int num66 = 0; num66 < 58; num66++)
                            {
                                if (player.inventory[num66].type == 72 && player.inventory[num66].stack > 0)
                                {
                                    player.inventory[num66].stack--;
                                    mplayer.Elecoin += 100;
                                }
                            }
                        }
                    }
                    if ((new Vector2(Main.mouseX, Main.mouseY) - new Vector2(shopx + 122, shopy + 114)).Length() <= 11 && !signalWeak)
                    {
                        spriteBatch.Draw(mod.GetTexture("UIImages/按下Au"), new Vector2(shopx, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "按下充值1金", Main.mouseX + 20, Main.mouseY + 20, Color.White, Color.Black, Vector2.Zero);
                        if (Main.mouseLeft && AddCco == 0)
                        {
                            AddCco = 5;
                            for (int num66 = 0; num66 < 58; num66++)
                            {
                                if (player.inventory[num66].type == 73 && player.inventory[num66].stack > 0)
                                {
                                    player.inventory[num66].stack--;
                                    mplayer.Elecoin += 10000;
                                }
                            }
                        }
                    }
                    if ((new Vector2(Main.mouseX, Main.mouseY) - new Vector2(shopx + 162, shopy + 114)).Length() <= 11 && !signalWeak)
                    {
                        spriteBatch.Draw(mod.GetTexture("UIImages/按下Pt"), new Vector2(shopx, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "按下充值1铂金", Main.mouseX - 50, Main.mouseY + 20, Color.White, Color.Black, Vector2.Zero);
                        if (Main.mouseLeft && AddCco == 0)
                        {
                            AddCco = 10;
                            for (int num66 = 0; num66 < 58; num66++)
                            {
                                if (player.inventory[num66].type == 74 && player.inventory[num66].stack > 0)
                                {
                                    player.inventory[num66].stack--;
                                    mplayer.Elecoin += 1000000;
                                }
                            }
                        }
                    }
                }
                else
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/电子商城界面2"), new Vector2(shopx, shopy), null, new Color((15 - AddCco) / 15f, (15 - AddCco) / 15f, (15 - AddCco) / 15f, (15 - AddCco) / 15f), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(mod.GetTexture("UIImages/电子商城充值界面"), new Vector2(shopx, shopy), null, new Color((AddCco) / 15f, (AddCco) / 15f, (AddCco) / 15f, (AddCco) / 15f), 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
                if (Main.time % 21600 == 30 && !signalWeak)
                {
                    for (int x = 0; x < 4; x++)
                    {
                        for (int y = 0; y < 4; y++)
                        {
                            if (Main.rand.Next(100) > 10)
                            {
                                Shop[x, y] = shopList[Main.rand.Next(20000) % (shopList.Length)];
                            }
                            else
                            {
                                Shop[x, y] = shopListRare[Main.rand.Next(20000) % (shopListRare.Length)];
                            }
                            var item = new Item();
                            item.SetDefaults(Shop[x, y]);
                            var sta = item.maxStack;
                            var value = item.value;
                            SoldOut[x, y] = false;
                            if (sta != 1 && value < 50000)
                            {
                                ShopStack[x, y] = Main.rand.Next(1, 15);
                            }
                            else
                            {
                                ShopStack[x, y] = 1;
                            }
                        }
                    }
                }
                if (Onload)
                {
                    for (int x = 0; x < 4; x++)
                    {
                        for (int y = 0; y < 4; y++)
                        {
                            if(Main.rand.Next(100) > 10)
                            {
                                Shop[x, y] = shopList[Main.rand.Next(20000) % (shopList.Length)];
                            }
                            else
                            {
                                Shop[x, y] = shopListRare[Main.rand.Next(20000) % (shopListRare.Length)];
                            }
                            var item = new Item();
                            item.SetDefaults(Shop[x, y]);
                            var sta = item.maxStack;
                            var value = item.value;
                            SoldOut[x, y] = false;
                            if (sta != 1 && value < 50000)
                            {
                                ShopStack[x, y] = Main.rand.Next(1, 15);
                            }
                            else
                            {
                                ShopStack[x, y] = 1;
                            }
                        }
                    }
                    Onload = false;
                }
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        if (!SoldOut[x, y])
                        {
                            Texture2D shop = TextureAssets.Item[Shop[x, y]].Value;
                            if (shop.Width >= shop.Height)
                            {
                                spriteBatch.Draw(shop, new Vector2(shopx + 32 + 60 * x, shopy + 161 + 63 * y + (shop.Width - shop.Height) / 2f), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1 / (float)(Math.Sqrt(shop.Width * shop.Width + shop.Width * shop.Width) / 45f), SpriteEffects.None, 0f);
                            }
                            else
                            {
                                spriteBatch.Draw(shop, new Vector2(shopx + 32 + 60 * x - (shop.Width - shop.Height) / 2f, shopy + 161 + 63 * y), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1 / (float)(Math.Sqrt(shop.Height * shop.Height + shop.Height * shop.Height) / 45f), SpriteEffects.None, 0f);
                            }
                        }
                    }
                }
                Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, mplayer.Elecoin.ToString(), texPos.X, texPos.Y + 1, Color.White, Color.Black, Vector2.Zero);
                if (NoEnoughMoney == 0)
                {
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, mplayer.TotalCoin.ToString(), texPos2.X, texPos2.Y, Color.White, Color.Black, Vector2.Zero);
                }
                else
                {
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "余额不足!", texPos2.X, texPos2.Y, Color.Red, Color.Black, Vector2.Zero);
                }
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        if (ShopStack[x, y] != 1 && !SoldOut[x, y])
                        {
                            Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, ShopStack[x, y].ToString(), texPos3.X + 60 * x, texPos3.Y + 63 * y, Color.White, Color.Black, Vector2.Zero);
                        }
                        if (Math.Abs(Main.mouseX - (shopx + 48 + 60 * x)) < 25 && Math.Abs(Main.mouseY - (shopy + 177 + 63 * y)) < 25 && !SoldOut[x, y] && !signalWeak)
                        {
                            var item = new Item();
                            item.SetDefaults(Shop[x, y]);
                            var value = item.value;
                            if (x >= 2)
                            {
                                if (x == 2)
                                {
                                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, Lang.GetItemName(Shop[x, y]).ToString(), Main.mouseX - 20, Main.mouseY + 20, Color.White, Color.Black, Vector2.Zero);
                                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "售价:" + value * ShopStack[x, y] * 3, Main.mouseX - 20, Main.mouseY + 40, Color.White, Color.Black, Vector2.Zero);
                                }
                                if (x == 3)
                                {
                                    if ((Main.mouseX - (shopx + 48 + 60 * x)) <= 0)
                                    {
                                        Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, Lang.GetItemName(Shop[x, y]).ToString(), Main.mouseX - 60, Main.mouseY + 20, Color.White, Color.Black, Vector2.Zero);
                                        Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "售价:" + value * ShopStack[x, y] * 3, Main.mouseX - 60, Main.mouseY + 40, Color.White, Color.Black, Vector2.Zero);
                                    }
                                    else
                                    {
                                        Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, Lang.GetItemName(Shop[x, y]).ToString(), shopx + 48 + 60 * x - 60, Main.mouseY + 20, Color.White, Color.Black, Vector2.Zero);
                                        Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "售价:" + value * ShopStack[x, y] * 3, shopx + 48 + 60 * x - 60, Main.mouseY + 40, Color.White, Color.Black, Vector2.Zero);
                                    }
                                }
                            }
                            else
                            {
                                Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, Lang.GetItemName(Shop[x, y]).ToString(), Main.mouseX + 20, Main.mouseY + 20, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "售价:" + value * ShopStack[x, y] * 3, Main.mouseX + 20, Main.mouseY + 40, Color.White, Color.Black, Vector2.Zero);
                            }
                            sp = new Vector2(x, y);
                            if (Checkco == 0 && Main.mouseLeft && !checkOn[x, y])
                            {
                                Checkco += 15;
                                checkOn[x, y] = true;
                                mplayer.TotalCoin += value * ShopStack[x, y] * 3;
                            }
                            if (Checkco == 0 && Main.mouseLeft && checkOn[x, y])
                            {
                                Checkco += 15;
                                checkOn[x, y] = false;
                                mplayer.TotalCoin -= value * ShopStack[x, y] * 3;
                            }
                        }
                    }
                }
                if ((new Vector2(Main.mouseX, Main.mouseY) - new Vector2(shopx + 253, shopy + 98)).Length() <= 11 && !signalWeak)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/电子商城刷新"), new Vector2(shopx, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "刷新\n消耗50000", shopx + 190, Main.mouseY - 5, Color.White, Color.Black, Vector2.Zero);
                    if (Main.mouseLeft && Refco == 0 && mplayer.Elecoin >= 50000)
                    {
                        Refco = 60;
                        mplayer.Elecoin -= 50000;
                        mplayer.TotalCoin = 0;
                        for (int x = 0; x < 4; x++)
                        {
                            for (int y = 0; y < 4; y++)
                            {
                                if (Main.rand.Next(100) > 10)
                                {
                                    Shop[x, y] = shopList[Main.rand.Next(20000) % (shopList.Length)];
                                }
                                else
                                {
                                    Shop[x, y] = shopListRare[Main.rand.Next(20000) % (shopListRare.Length)];
                                }
                                var item = new Item();
                                item.SetDefaults(Shop[x, y]);
                                var sta = item.maxStack;
                                var value = item.value;
                                SoldOut[x, y] = false;
                                if (sta != 1 && value < 50000)
                                {
                                    ShopStack[x, y] = Main.rand.Next(1, 15);
                                }
                                else
                                {
                                    ShopStack[x, y] = 1;
                                }
                                checkOn[x, y] = false;
                            }
                        }
                    }
                }
                if (Math.Abs(Main.mouseX - (shopx + 255)) < 18 && Math.Abs(Main.mouseY - (shopy + 71)) < 15 && !signalWeak)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/神话异空间群聊二维码"), new Vector2(Main.mouseX - 160, Main.mouseY + 20), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(mod.GetTexture("UIImages/二维码"), new Vector2(shopx, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
                if (Math.Abs(Main.mouseX - (shopx + 218)) < 25 && Math.Abs(Main.mouseY - (shopy + 68)) < 10 && !signalWeak)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/充值"), new Vector2(shopx, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    if (Main.mouseLeft && AddCco == 0 && !AddC)
                    {
                        AddCco += 15;
                        AddC = true;
                    }
                    if (Main.mouseLeft && AddCco == 0 && AddC)
                    {
                        AddCco += 15;
                        AddC = false;
                    }
                }
                if (Math.Abs(Main.mouseX - (shopx + 255)) < 18 && Math.Abs(Main.mouseY - (shopy + 430)) < 15 && !signalWeak)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/退出"), new Vector2(shopx, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    if (Main.mouseX - (shopx + 255) > 0)
                    {
                        Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "退出", shopx + 220, Main.mouseY - 5, Color.White, Color.Black, Vector2.Zero);
                    }
                    if (Main.mouseLeft)
                    {
                        smartPhone.Open = false;
                    }
                }
                if (Math.Abs(Main.mouseX - (shopx + 220)) < 18 && Math.Abs(Main.mouseY - (shopy + 430)) < 15 && !signalWeak)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/购买"), new Vector2(shopx, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    if (Main.mouseX - (shopx + 220) > 0)
                    {
                        Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "购买", shopx + 240, Main.mouseY - 5, Color.White, Color.Black, Vector2.Zero);
                    }
                    if (Main.mouseLeft)
                    {
                        if (mplayer.Elecoin >= mplayer.TotalCoin)
                        {
                            for (int x = 0; x < 4; x++)
                            {
                                for (int y = 0; y < 4; y++)
                                {
                                    if (checkOn[x, y])
                                    {
                                        player.QuickSpawnItem(Shop[x, y], ShopStack[x, y]);
                                        checkOn[x, y] = false;
                                        SoldOut[x, y] = true;
                                    }
                                }
                            }
                            mplayer.Elecoin -= mplayer.TotalCoin;
                            mplayer.TotalCoin = 0;
                        }
                        else
                        {
                            NoEnoughMoney = 30;
                            mplayer.TotalCoin = 0;
                            for (int x = 0; x < 4; x++)
                            {
                                for (int y = 0; y < 4; y++)
                                {
                                    if (checkOn[x, y])
                                    {
                                        checkOn[x, y] = false;
                                    }
                                }
                            }
                        }
                    }
                }
                spriteBatch.Draw(mod.GetTexture("UIImages/手机底框"), new Vector2(shopx, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                if (Main.dayTime)
                {
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, ((int)(Main.time - 12600 + 79200 - 10800) / 3600 % 12 + 1).ToString() + ":" + ((int)(Main.time - 12600 + 79200 - 10800) / 60 % 60).ToString() + " 白天", texPos4.X, texPos4.Y - 8, Color.White, Color.Black, Vector2.Zero);
                }
                else
                {
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, ((int)(Main.time - 12600 + 79200) / 3600 % 12 + 1).ToString() + ":" + ((int)(Main.time - 12600 + 79200) / 60 % 60).ToString() + " 夜间", texPos4.X, texPos4.Y - 8, Color.White, Color.Black, Vector2.Zero);
                }
                if (Main.time % 60 == 0)
                {
                    if (mplayer.SignalStrength > 0.4f)
                    {
                        SigS = 4;
                        signalWeak = false;
                    }
                    else if (mplayer.SignalStrength > 0.25f)
                    {
                        SigS = 3;
                        signalWeak = false;
                    }
                    else if (mplayer.SignalStrength > 0.15f)
                    {
                        SigS = 2;
                        signalWeak = false;
                    }
                    else if (mplayer.SignalStrength > 0.06f)
                    {
                        SigS = 1;
                        signalWeak = false;
                    }
                    else
                    {
                        SigS = 0;
                        signalWeak = true;
                    }
                }
                spriteBatch.Draw(mod.GetTexture("UIImages/信号" + SigS.ToString()), new Vector2(shopx + 20, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                if (Main.raining)
                {
                    if (Main.maxRain <= 2)
                    {
                        spriteBatch.Draw(mod.GetTexture("UIImages/天气6"), new Vector2(shopx + 20, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    }
                    else
                    {
                        spriteBatch.Draw(mod.GetTexture("UIImages/天气7"), new Vector2(shopx + 20, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    }
                }
                if (!Main.raining)
                {
                    if (Main.numClouds > 20)
                    {
                        if (Main.dayTime)
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/天气4"), new Vector2(shopx + 20, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        }
                        if (!Main.dayTime)
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/天气3"), new Vector2(shopx + 20, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        }
                    }
                    else
                    {
                        if (Main.dayTime)
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/天气1"), new Vector2(shopx + 20, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        }
                        if (!Main.dayTime)
                        {
                            spriteBatch.Draw(mod.GetTexture("UIImages/天气2"), new Vector2(shopx + 20, shopy), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        }
                    }
                }
                if (AddCco > 0)
                {
                    AddCco -= 1;
                }
                else
                {
                    AddCco = 0;
                }
                if (Checkco > 0)
                {
                    Checkco -= 1;
                }
                else
                {
                    Checkco = 0;
                }
                if (NoEnoughMoney > 0)
                {
                    NoEnoughMoney -= 1;
                }
                else
                {
                    NoEnoughMoney = 0;
                }
                if (Refco > 0)
                {
                    Refco -= 1;
                }
                else
                {
                    Refco = 0;
                }
            }
            if(Book == 1)
            {
                spriteBatch.Draw(mod.GetTexture("UIImages/美食宝典1"), new Vector2(shopx - 60, shopy - 30), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(mod.GetTexture("UIImages/美食宝典Exp"), new Vector2(shopx - 60, shopy - 30), new Rectangle(0, 0, 116 + (int)(210 * (float)(mplayer.FoodExp - mplayer.FoodLecelUpNeed[mplayer.FoodLevel - 1]) / (float)(mplayer.FoodLecelUpNeed[mplayer.FoodLevel] - mplayer.FoodLecelUpNeed[mplayer.FoodLevel - 1] + 0.0001f)), 550), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                String A = "-" + BookPage + "-";
                String B = "";
                if (BookPage == 1)
                {
                    B = "饭";
                    Difficulty = 1;
                }
                if (BookPage == 2)
                {
                    B = "西瓜拼盘";
                    Difficulty = 1;
                }
                if (BookPage == 3)
                {
                    B = "煎蛋";
                    Difficulty = 2;
                }
                if (BookPage == 4)
                {
                    B = "汤圆";
                    Difficulty = 1;
                }
                if (BookPage == 5)
                {
                    B = "泰式炒面";
                    FoodType = 2267;
                    Difficulty = 2;
                }
                if (BookPage == 6)
                {
                    B = "越南河粉";
                    FoodType = 2268;
                    Difficulty = 2;
                }
                if (BookPage == 7)
                {
                    B = "蜂蜜饼干";
                    FoodType = 1919;
                    Difficulty = 2;
                }
                if (BookPage == 8)
                {
                    B = "蛋酒";
                    FoodType = 1912;
                    Difficulty = 3;
                }
                if (BookPage == 9)
                {
                    B = "圣诞布丁";
                    FoodType = 1911;
                    Difficulty = 3;
                }
                if (BookPage == 10)
                {
                    B = "熟鱼";
                    FoodType = 2425;
                    Difficulty = 2;
                }
                if (BookPage == 11)
                {
                    B = "熟虾";
                    FoodType = 2426;
                    Difficulty = 2;
                }
                if (BookPage == 12)
                {
                    B = "熟棉花糖";
                    FoodType = 969;
                    Difficulty = 1;
                }
                if (BookPage == 13)
                {
                    B = "鱼菇汤";
                    FoodType = 357;
                    Difficulty = 2;
                }
                if (BookPage == 14)
                {
                    B = "南瓜饼";
                    FoodType = 1787;
                    Difficulty = 3;
                }
                if (BookPage == 15)
                {
                    B = "麦芽酒";
                    FoodType = 353;
                    Difficulty = 3;
                }
                if (BookPage == 16)
                {
                    B = "蛆虫汤";
                    FoodType = 3195;
                    Difficulty = 3;
                }
                if (BookPage == 17)
                {
                    B = "清酒";
                    FoodType = 2266;
                    Difficulty = 3;
                }
                if (BookPage == 18)
                {
                    B = "蛋炒饭";
                    FoodType = mod.Find<ModItem>(B).Type;
                    Difficulty = 2;
                }
                if (BookPage == 19)
                {
                    B = "蛋挞";
                    FoodType = mod.Find<ModItem>(B).Type;
                    Difficulty = 3;
                }
                if (BookPage == 20)
                {
                    B = "烤榴莲";
                    FoodType = mod.Find<ModItem>(B).Type;
                    Difficulty = 2;
                }
                if (BookPage == 21)
                {
                    B = "姜饼";
                    FoodType = mod.Find<ModItem>(B).Type;
                    Difficulty = 2;
                }
                Texture2D fd = TextureAssets.Item[FoodKind[Book, BookPage]].Value;
                if (!mplayer.BanFood[Book,BookPage])
                {
                    fd = mod.GetTexture("UIImages/美食宝典未知");
                }
                if (fd.Width >= fd.Height)
                {
                    spriteBatch.Draw(fd, new Vector2(shopx - 60 + 78, shopy - 30 + 56 + (fd.Width - fd.Height) / 2f), null, Color.White, 0f, Vector2.Zero, 1 / (float)(Math.Sqrt(fd.Width * fd.Width + fd.Width * fd.Width) / 73.5f), SpriteEffects.None, 0f);
                }
                else
                {
                    spriteBatch.Draw(fd, new Vector2(shopx - 60 + 78 - (fd.Width - fd.Height) / 2f, shopy - 30 + 56), null, Color.White, 0f, Vector2.Zero, 1 / (float)(Math.Sqrt(fd.Height * fd.Height + fd.Height * fd.Height) / 73.5f), SpriteEffects.None, 0f);
                }
                Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, A, shopx + 140 - A.Length * 4, shopy + 454, new Color(73, 52, 22), new Color(0, 0, 0, 0), Vector2.Zero);
                Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "名称:" + B, shopx + 140, shopy + 54, new Color(73, 52, 22), new Color(0, 0, 0, 0), Vector2.Zero);
                Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "制作难度:" + Difficulty, shopx + 140, shopy + 81, new Color(73, 52, 22), new Color(0, 0, 0, 0), Vector2.Zero);
                Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "您的等级:" + mplayer.FoodLevel, shopx + 30, shopy + 108, new Color(73, 52, 22), new Color(0, 0, 0, 0), Vector2.Zero);
                Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "升级所需经验" + (mplayer.FoodLecelUpNeed[mplayer.FoodLevel] -  mplayer.FoodExp), shopx + 30, shopy + 162, new Color(73, 52, 22), new Color(0, 0, 0, 0), Vector2.Zero);
                if ((new Vector2(Main.mouseX, Main.mouseY) - new Vector2(shopx - 58, shopy + 220)).Length() < 23)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/美食宝典翻页减少"), new Vector2(shopx - 80, shopy + 195), null, Microsoft.Xna.Framework.Color.SaddleBrown, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    if(Main.mouseLeft && pagCo < 0 && BookPage > 1)
                    {
                        pagCo = 15;
                        BookPage -= 1;
                    }
                }
                else
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/美食宝典翻页减少"), new Vector2(shopx - 80, shopy + 195), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
                if ((new Vector2(Main.mouseX, Main.mouseY) - new Vector2(shopx + 342, shopy + 220)).Length() < 23)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/美食宝典翻页增加"), new Vector2(shopx + 320, shopy + 195), null, Microsoft.Xna.Framework.Color.SaddleBrown, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    if (Main.mouseLeft && pagCo < 0 && BookPage < 21)
                    {
                        pagCo = 15;
                        BookPage += 1;
                    }
                }
                else
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/美食宝典翻页增加"), new Vector2(shopx + 320, shopy + 195), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
                pagCo -= 1;
            }
            if (Book == 2)
            {
                spriteBatch.Draw(mod.GetTexture("UIImages/美食宝典2"), new Vector2(shopx - 60, shopy - 30), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                spriteBatch.Draw(mod.GetTexture("UIImages/美食宝典Exp"), new Vector2(shopx - 60, shopy - 30), new Rectangle(0, 0, 116 + (int)(210 * (float)(mplayer.FoodExp - mplayer.FoodLecelUpNeed[mplayer.FoodLevel - 1]) / (float)(mplayer.FoodLecelUpNeed[mplayer.FoodLevel] - mplayer.FoodLecelUpNeed[mplayer.FoodLevel - 1] + 0.0001f)), 550), Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                String A = "-" + BookPage + "-";
                String B = "";
                if (BookPage == 1)
                {
                    B = "生鱼片";
                    Difficulty = 1;
                }
                if (BookPage == 2)
                {
                    B = "灵魂蛋糕";
                    Difficulty = 0;
                }
                if (BookPage == 3)
                {
                    B = "焦糖苹果";
                    Difficulty = 0;
                }
                if (BookPage == 4)
                {
                    B = "糖棒";
                    Difficulty = 0;
                }
                if (BookPage == 5)
                {
                    B = "蜜糖李";
                    Difficulty = 0;
                }
                if (BookPage == 6)
                {
                    B = "西瓜汁";
                    Difficulty = 2;
                }
                if (BookPage == 7)
                {
                    B = "哈密瓜汁";
                    Difficulty = 2;
                }
                if (BookPage == 8)
                {
                    B = "小西瓜果冻";
                    Difficulty = 3;
                }
                if (BookPage == 9)
                {
                    B = "小哈密瓜果冻";
                    Difficulty = 3;
                }
                if (BookPage == 10)
                {
                    B = "椰子汁";
                    Difficulty = 2;
                }
                if (BookPage == 11)
                {
                    B = "小椰子果冻";
                    Difficulty = 2;
                }
                Texture2D fd = TextureAssets.Item[FoodKind[Book, BookPage]].Value;
                if (!mplayer.BanFood[Book, BookPage])
                {
                    fd = mod.GetTexture("UIImages/美食宝典未知");
                }
                if (fd.Width >= fd.Height)
                {
                    spriteBatch.Draw(fd, new Vector2(shopx - 60 + 78, shopy - 30 + 56 + (fd.Width - fd.Height) / 2f), null, Color.White, 0f, Vector2.Zero, 1 / (float)(Math.Sqrt(fd.Width * fd.Width + fd.Width * fd.Width) / 73.5f), SpriteEffects.None, 0f);
                }
                else
                {
                    spriteBatch.Draw(fd, new Vector2(shopx - 60 + 78 - (fd.Width - fd.Height) / 2f, shopy - 30 + 56), null, Color.White, 0f, Vector2.Zero, 1 / (float)(Math.Sqrt(fd.Height * fd.Height + fd.Height * fd.Height) / 73.5f), SpriteEffects.None, 0f);
                }
                Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, A, shopx + 140 - A.Length * 4, shopy + 454, new Color(73, 52, 22), new Color(0, 0, 0, 0), Vector2.Zero);
                Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "名称:" + B, shopx + 140, shopy + 54, new Color(73, 52, 22), new Color(0, 0, 0, 0), Vector2.Zero);
                Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "制作难度:" + Difficulty, shopx + 140, shopy + 81, new Color(73, 52, 22), new Color(0, 0, 0, 0), Vector2.Zero);
                Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "您的等级:" + mplayer.FoodLevel, shopx + 30, shopy + 108, new Color(73, 52, 22), new Color(0, 0, 0, 0), Vector2.Zero);
                Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "升级所需经验" + (mplayer.FoodLecelUpNeed[mplayer.FoodLevel] - mplayer.FoodExp), shopx + 30, shopy + 162, new Color(73, 52, 22), new Color(0, 0, 0, 0), Vector2.Zero);
                if ((new Vector2(Main.mouseX, Main.mouseY) - new Vector2(shopx - 58, shopy + 220)).Length() < 23)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/美食宝典翻页减少"), new Vector2(shopx - 80, shopy + 195), null, Microsoft.Xna.Framework.Color.SaddleBrown, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    if (Main.mouseLeft && pagCo < 0 && BookPage > 1)
                    {
                        pagCo = 15;
                        BookPage -= 1;
                    }
                }
                else
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/美食宝典翻页减少"), new Vector2(shopx - 80, shopy + 195), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
                if ((new Vector2(Main.mouseX, Main.mouseY) - new Vector2(shopx + 342, shopy + 220)).Length() < 23)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/美食宝典翻页增加"), new Vector2(shopx + 320, shopy + 195), null, Microsoft.Xna.Framework.Color.SaddleBrown, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    if (Main.mouseLeft && pagCo < 0 && BookPage < 11)
                    {
                        pagCo = 15;
                        BookPage += 1;
                    }
                }
                else
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/美食宝典翻页增加"), new Vector2(shopx + 320, shopy + 195), null, Microsoft.Xna.Framework.Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                }
                pagCo -= 1;
            }
            FoodKind[1, 1] = mod.Find<ModItem>("CookedRice").Type;
            FoodKind[1, 2] = mod.Find<ModItem>("西瓜拼盘").Type;
            FoodKind[1, 3] = mod.Find<ModItem>("FriedEgg").Type;
            FoodKind[1, 4] = mod.Find<ModItem>("Tangyuan").Type;
            FoodKind[1, 5] = 2267;
            FoodKind[1, 6] = 2268;
            FoodKind[1, 7] = 1919;
            FoodKind[1, 8] = 1912;
            FoodKind[1, 9] = 1911;
            FoodKind[1, 10] = 2425;
            FoodKind[1, 11] = 2426;
            FoodKind[1, 12] = 969;
            FoodKind[1, 13] = 357;
            FoodKind[1, 14] = 1787;
            FoodKind[1, 15] = 353;
            FoodKind[1, 16] = 3195;
            FoodKind[1, 17] = 2266;
            FoodKind[1, 18] = mod.Find<ModItem>("EggFriedRice").Type;
            FoodKind[1, 19] = mod.Find<ModItem>("EggTart").Type;
            FoodKind[1, 20] = mod.Find<ModItem>("BakeDurian").Type;
            FoodKind[1, 21] = 1920;
            FoodKind[2, 1] = 2427;
            FoodKind[2, 2] = 1735;
            FoodKind[2, 3] = 1734;
            FoodKind[2, 4] = 1867;
            FoodKind[2, 5] = 1868;
            FoodKind[2, 6] = mod.Find<ModItem>("西瓜汁").Type;
            FoodKind[2, 7] = mod.Find<ModItem>("CantaloupeJuice").Type;
            FoodKind[2, 8] = mod.Find<ModItem>("小西瓜果冻").Type;
            FoodKind[2, 9] = mod.Find<ModItem>("小哈密瓜果冻").Type;
            FoodKind[2, 10] = mod.Find<ModItem>("椰子汁").Type;
            FoodKind[2, 11] = mod.Find<ModItem>("小椰子果冻").Type;
            base.Draw(spriteBatch);
        }
        public static int[,] FoodKind = new int[16, 30];
        private int pagCo = 0;
        private int pagCoCou = 0;
        private int FoodType = 0;
        private int Difficulty = 0;
    }
}