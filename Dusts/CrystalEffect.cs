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
using System.Linq;
using System.Text;
using TemplateMod2.Utils;

namespace MythMod.Dusts
{
    public class CrystalEffect : UIState
    {
        private bool living = true;
        public static bool Open = true;
        Vector2 offset;
        private CrystalEffectMain CrystalEffectMain = new CrystalEffectMain();
        public override void OnInitialize()
        {
            CrystalEffectMain = new CrystalEffectMain();
            CrystalEffectMain.Width.Set(422, 0);
            CrystalEffectMain.Height.Set(424, 0);
            CrystalEffectMain.Left.Set(Main.screenWidth * 0.5f - 315, 0);
            CrystalEffectMain.Top.Set(Main.screenHeight * 0.5f - 318, 0);

            Append(CrystalEffectMain);
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
    public class CrystalEffectMain : UIElement
    {
        bool FeaSystem = false;
        float FeaOnDelay = 0;
        float FeaOffDelay = 0;
        public static int[] fea = new int[40];
        public static int Fragment = 0;
        public int Frep = 0;
        public int Expp = 0;
        public static int cooling = 0;
        public bool Uns = true;
        public bool[] CanFea = new bool[40];
        public Vector2[] vfea = new Vector2[40];
        public static int MaxFea = 3;
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector2 vector = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            Player player = Main.player[Main.myPlayer];
            CalculatedStyle innerDimensions = base.GetInnerDimensions();
            float shopx = innerDimensions.X;
            float shopy = innerDimensions.Y;
            Mod mod = ModLoader.GetMod("MythMod");
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            
            /*羽毛福利*/
            if (Main.hardMode)
            {
                MaxFea = 8;
            }
            else
            {
                MaxFea = 3;
            }
            if (Fragment > 0)
            {
                Fragment -= 1;
            }
            else
            {
                Fragment = 0;
            }
            if (Fragment > 0)
            {
                spriteBatch.Draw(mod.GetTexture("Items/Weapons/Bottle/EvilFragment"), new Vector2(Main.mouseX + 20, Main.mouseY + 20), null, new Color(255, 255, 255, 255), 0f, Utils.Size(mod.GetTexture("Items/Weapons/Bottle/EvilFragment")) / 2f, 1f, SpriteEffects.None, 0f);
            }
            //Boss列表

            IList<int> ContainFea = new List<int>();
            ContainFea.Add(320);
            ContainFea.Add(1516);
            ContainFea.Add(1517);
            ContainFea.Add(1518);
            ContainFea.Add(1519);
            ContainFea.Add(mod.Find<ModItem>("BirdFeather").Type);
            ContainFea.Add(mod.Find<ModItem>("BlueBirdFeather").Type);
            ContainFea.Add(mod.Find<ModItem>("GoldBirdFeather").Type);
            ContainFea.Add(mod.Find<ModItem>("RedBirdFeather").Type);
            ContainFea.Add(mod.Find<ModItem>("BeeFeather").Type);
            ContainFea.Add(mod.Find<ModItem>("SnowFeather").Type);
            ContainFea.Add(mod.Find<ModItem>("VoidFeather").Type);
            ContainFea.Add(mod.Find<ModItem>("TwilightFeather").Type);
            ContainFea.Add(mod.Find<ModItem>("SolarFeather").Type);
            ContainFea.Add(mod.Find<ModItem>("StardustFeather").Type);
            ContainFea.Add(mod.Find<ModItem>("LightingFeather").Type);
            ContainFea.Add(mod.Find<ModItem>("LeaveFeather").Type);
            ContainFea.Add(mod.Find<ModItem>("GoldFeather").Type);
            ContainFea.Add(mod.Find<ModItem>("GhostFeather").Type);
            ContainFea.Add(mod.Find<ModItem>("CrimsonFeather").Type);
            ContainFea.Add(mod.Find<ModItem>("CorruptFeather").Type);
            ContainFea.Add(mod.Find<ModItem>("DarkFeather").Type);
            ContainFea.Add(mod.Find<ModItem>("DarkGoldFeather").Type);
            ContainFea.Add(mod.Find<ModItem>("RainbowFeather").Type);
            ContainFea.Add(mod.Find<ModItem>("PoisonFeather").Type);
            ContainFea.Add(mod.Find<ModItem>("RedSnowFeather").Type);
            ContainFea.Add(mod.Find<ModItem>("StarlightFeather").Type);
            if (Main.playerInventory)
            {
                Vector2 vMou = new Vector2(Main.mouseX, Main.mouseY);
                Vector2 FesPos = new Vector2(136, Main.screenHeight - 30);
                if (FeaOnDelay > 0)
                {
                    FeaOnDelay -= 1;
                }
                else
                {
                    FeaOnDelay = 0;
                }
                if (FeaOffDelay > 0)
                {
                    FeaOffDelay -= 1;
                }
                else
                {
                    FeaOffDelay = 0;
                }
                if ((vMou - (FesPos + new Vector2(48, 0))).Length() <= 25)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/MISSHighlight"), FesPos + new Vector2(48, 0), null, new Color(255, 255, 255, 255), 0f, Utils.Size(mod.GetTexture("UIImages/MISS")) / 2f, 1f, SpriteEffects.None, 0f);
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "闪避" + mplayer.Misspossibility.ToString() + "%", Main.mouseX + 20, Main.mouseY, new Color(255, 255, 255), new Color(0, 0, 0), Vector2.Zero, 1);
                }
                else
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/MISS"), FesPos + new Vector2(48, 0), null, new Color(140, 140, 140, 0), 0f, Utils.Size(mod.GetTexture("UIImages/MISS")) / 2f, 1f, SpriteEffects.None, 0f);
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, mplayer.Misspossibility.ToString(), FesPos.X + 48 - mplayer.Misspossibility.ToString().Length * 4, FesPos.Y - 12, new Color(255, 255, 255), new Color(0, 0, 0), Vector2.Zero, 1);
                }
                if ((vMou - (FesPos + new Vector2(76, -12))).Length() <= 6)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/ExpolorateHighlight"), FesPos + new Vector2(76, -12), null, new Color(255, 255, 0, 150), 0f, Utils.Size(mod.GetTexture("UIImages/ExpolorateHighlight")) / 2f, 1f, SpriteEffects.None, 0f);
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "引爆率" + mplayer.ExpolodePoint.ToString() + "‱", Main.mouseX + 20, Main.mouseY, new Color(255, 255, 255), new Color(255, 145, 0), Vector2.Zero, 1);
                }
                else
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/Expolorate"), FesPos + new Vector2(76, -12), null, new Color(255, 140, 0, 0), 0f, Utils.Size(mod.GetTexture("UIImages/Expolorate")) / 2f, 1f, SpriteEffects.None, 0f);
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, mplayer.ExpolodePoint.ToString(), FesPos.X + 79 - mplayer.ExpolodePoint.ToString().Length, FesPos.Y - 14, new Color(255, 145, 255), new Color(0, 0, 0), Vector2.Zero, 0.5f);
                }
                if ((vMou - (FesPos + new Vector2(76, 12))).Length() <= 6)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/FreezrateHighlight"), FesPos + new Vector2(76, 12), null, new Color(255, 255, 255, 255), 0f, Utils.Size(mod.GetTexture("UIImages/FreezrateHighlight")) / 2f, 1f, SpriteEffects.None, 0f);
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "冰封率" + mplayer.FreezingPoint.ToString() + "‱", Main.mouseX + 20, Main.mouseY, new Color(255, 255, 255), new Color(0, 120, 200), Vector2.Zero, 1);
                }
                else
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/Freezrate"), FesPos + new Vector2(76, 12), null, new Color(71, 71, 255, 0), 0f, Utils.Size(mod.GetTexture("UIImages/Freezrate")) / 2f, 1f, SpriteEffects.None, 0f);
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, mplayer.FreezingPoint.ToString(), FesPos.X + 79 - mplayer.FreezingPoint.ToString().Length, FesPos.Y + 11, new Color(255, 255, 255), new Color(0, 120, 200), Vector2.Zero, 0.5f);
                }
                if ((vMou - (FesPos + new Vector2(100, 12))).Length() <= 6)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/LigrateHighlight"), FesPos + new Vector2(100, 12), null, new Color(255, 255, 255, 255), 0f, Utils.Size(mod.GetTexture("UIImages/LigrateHighlight")) / 2f, 1f, SpriteEffects.None, 0f);
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "雷电率" + mplayer.LightingPoint.ToString() + "‱", Main.mouseX + 20, Main.mouseY, new Color(255, 255, 255), new Color(0, 200, 255), Vector2.Zero, 1);
                }
                else
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/Ligrate"), FesPos + new Vector2(100, 12), null, new Color(71, 71, 255, 0), 0f, Utils.Size(mod.GetTexture("UIImages/Ligrate")) / 2f, 1f, SpriteEffects.None, 0f);
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, mplayer.LightingPoint.ToString(), FesPos.X + 108 - mplayer.LightingPoint.ToString().Length, FesPos.Y + 11, new Color(255, 255, 255), new Color(0, 200, 255), Vector2.Zero, 0.5f);
                }
                if ((vMou - (FesPos + new Vector2(100, -12))).Length() <= 6)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/BloodrateHighlight"), FesPos + new Vector2(100, -12), null, new Color(255, 255, 255, 255), 0f, Utils.Size(mod.GetTexture("UIImages/BloodrateHighlight")) / 2f, 1f, SpriteEffects.None, 0f);
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "吸血率" + mplayer.BloodPoint.ToString() + "‱", Main.mouseX + 20, Main.mouseY, new Color(255, 255, 255), new Color(255, 0, 0), Vector2.Zero, 1);
                }
                else
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/Bloodrate"), FesPos + new Vector2(100, -12), null, new Color(71, 71, 255, 0), 0f, Utils.Size(mod.GetTexture("UIImages/Bloodrate")) / 2f, 1f, SpriteEffects.None, 0f);
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, mplayer.BloodPoint.ToString(), FesPos.X + 108 - mplayer.BloodPoint.ToString().Length, FesPos.Y - 14, new Color(255, 255, 255), new Color(255, 0, 0), Vector2.Zero, 0.5f);
                }
                if ((vMou - (FesPos + new Vector2(129, -12))).Length() <= 6)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/PoisrateHighlight"), FesPos + new Vector2(129, -12), null, new Color(255, 255, 255, 255), 0f, Utils.Size(mod.GetTexture("UIImages/PoisrateHighlight")) / 2f, 1f, SpriteEffects.None, 0f);
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "放毒率" + mplayer.PoisonPoint.ToString() + "‱", Main.mouseX + 20, Main.mouseY, new Color(255, 255, 255), new Color(71, 109, 11), Vector2.Zero, 1);
                }
                else
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/Poisrate"), FesPos + new Vector2(129, -12), null, new Color(71, 71, 255, 0), 0f, Utils.Size(mod.GetTexture("UIImages/Poisrate")) / 2f, 1f, SpriteEffects.None, 0f);
                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, mplayer.PoisonPoint.ToString(), FesPos.X + 137 - mplayer.PoisonPoint.ToString().Length, FesPos.Y - 14, new Color(255, 255, 255), new Color(71, 109, 11), Vector2.Zero, 0.5f);
                }
                /*Utils.DrawBorderStringFourWay(Main.spriteBatch, Main.fontMouseText, Main.mouseItem.type.ToString(), Main.mouseX, Main.mouseY + 36, new Color(255, 255, 255), new Color(0, 0, 0), Vector2.Zero, 1);*/
                if (!FeaSystem)
                {
                    Vector2 v = new Vector2(0, -60);
                    Vector2 v2 = new Vector2(0, 60);
                    if (FeaOffDelay != 0)
                    {
                        for (int u = 0; u < 3; u++)
                        {
                            if(MaxFea > u)
                            {
                                CanFea[u] = true;
                                vfea[u] = new Vector2(Main.screenWidth / 2, Main.screenHeight / 2) + v.RotatedBy(Math.PI * (double)u / 1.5) * (FeaOffDelay) / 60f;
                                spriteBatch.Draw(mod.GetTexture("UIImages/Feather" + (u + 1).ToString()), new Vector2(Main.screenWidth / 2, Main.screenHeight / 2) + v.RotatedBy(Math.PI * (double)u / 1.5) * (FeaOffDelay) / 60f, null, new Color(255, 255, 255, 255), 0f, Utils.Size(mod.GetTexture("UIImages/Feather1")) / 2f, 1f, SpriteEffects.None, 0f);
                                if (fea[u] != 0)
                                {
                                    float scal = 1f;
                                    if(TextureAssets.Item[fea[u]].Value.Width + TextureAssets.Item[fea[u]].Value.Height > 60)
                                    {
                                        scal = 60f / (float)(TextureAssets.Item[fea[u]].Value.Width + TextureAssets.Item[fea[u]].Value.Height);
                                    }
                                    spriteBatch.Draw(TextureAssets.Item[fea[u]].Value, vfea[u], null, new Color(255, 255, 255, 255), 0f, Utils.Size(TextureAssets.Item[fea[u]].Value) / 2f, scal, SpriteEffects.None, 0f);
                                }
                            }
                        }
                        for (int u = 3; u < 8; u++)
                        {
                            if (MaxFea > u)
                            {
                                CanFea[u] = true;
                                vfea[u] = new Vector2(Main.screenWidth / 2, Main.screenHeight / 2) + v.RotatedBy(Math.PI * ((double)(u - 3) / 2.5 + 0.5)) * (FeaOffDelay) / 60f * 1.8f;
                                spriteBatch.Draw(mod.GetTexture("UIImages/Feather" + (u + 1).ToString()), new Vector2(Main.screenWidth / 2, Main.screenHeight / 2) + v.RotatedBy(Math.PI * ((double)(u - 3) / 2.5 + 0.5)) * (FeaOffDelay) / 60f * 1.8f, null, new Color(255, 255, 255, 255), 0f, Utils.Size(mod.GetTexture("UIImages/Feather2")) / 2f, 1f, SpriteEffects.None, 0f);
                                if (fea[u] != 0)
                                {
                                    float scal = 1f;
                                    if (TextureAssets.Item[fea[u]].Value.Width + TextureAssets.Item[fea[u]].Value.Height > 60)
                                    {
                                        scal = 60f / (float)(TextureAssets.Item[fea[u]].Value.Width + TextureAssets.Item[fea[u]].Value.Height);
                                    }
                                    spriteBatch.Draw(TextureAssets.Item[fea[u]].Value, vfea[u], null, new Color(255, 255, 255, 255), 0f, Utils.Size(TextureAssets.Item[fea[u]].Value) / 2f, scal, SpriteEffects.None, 0f);
                                }
                            }
                        }
                    }
                    if ((vMou - FesPos).Length() > 32)
                    {
                        spriteBatch.Draw(mod.GetTexture("UIImages/WING"), FesPos, null, new Color(140, 140, 140, 0), 0f, Utils.Size(mod.GetTexture("UIImages/WING")) / 2f, 1f, SpriteEffects.None, 0f);
                    }
                    else
                    {
                        spriteBatch.Draw(mod.GetTexture("UIImages/WINGHighLight"), FesPos, null, new Color(255, 255, 255, 255), 0f, Utils.Size(mod.GetTexture("UIImages/WINGHighLight")) / 2f, 1f, SpriteEffects.None, 0f);
                        Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "打开羽毛界面", Main.mouseX + 20, Main.mouseY, new Color(255, 255, 255), new Color(0, 0, 0), Vector2.Zero, 1);
                        if (FeaOffDelay == 0 && Main.mouseLeft)
                        {
                            FeaSystem = true;
                            FeaOnDelay = 60;
                        }
                    }
                }
                else
                {
                    Vector2 v = new Vector2(0, -60);
                    for (int u = 0; u < 3; u++)
                    {
                        if (MaxFea > u)
                        {
                            CanFea[u] = true;
                            vfea[u] = new Vector2(Main.screenWidth / 2, Main.screenHeight / 2) + v.RotatedBy(Math.PI * (double)u / 1.5) * (60 - FeaOnDelay) / 60f;
                            spriteBatch.Draw(mod.GetTexture("UIImages/Feather" + (u + 1).ToString()), new Vector2(Main.screenWidth / 2, Main.screenHeight / 2) + v.RotatedBy(Math.PI * (double)u / 1.5) * (60 - FeaOnDelay) / 60f, null, new Color(255, 255, 255, 255), 0f, Utils.Size(mod.GetTexture("UIImages/Feather1")) / 2f, 1f, SpriteEffects.None, 0f);
                            if (fea[u] != 0)
                            {
                                float scal = 1f;
                                if (TextureAssets.Item[fea[u]].Value.Width + TextureAssets.Item[fea[u]].Value.Height > 60)
                                {
                                    scal = 60f / (float)(TextureAssets.Item[fea[u]].Value.Width + TextureAssets.Item[fea[u]].Value.Height);
                                }
                                spriteBatch.Draw(TextureAssets.Item[fea[u]].Value, vfea[u], null, new Color(255, 255, 255, 255), 0f, Utils.Size(TextureAssets.Item[fea[u]].Value) / 2f, scal, SpriteEffects.None, 0f);
                            }
                        }
                    }
                    for (int u = 3; u < 8; u++)
                    {
                        if (MaxFea > u)
                        {
                            CanFea[u] = true;
                            vfea[u] = new Vector2(Main.screenWidth / 2, Main.screenHeight / 2) + v.RotatedBy(Math.PI * ((double)(u - 3) / 2.5 + 0.5)) * (60 - FeaOnDelay) / 60f * 1.8f;
                            spriteBatch.Draw(mod.GetTexture("UIImages/Feather" + (u + 1).ToString()), new Vector2(Main.screenWidth / 2, Main.screenHeight / 2) + v.RotatedBy(Math.PI * ((double)(u - 3) / 2.5 + 0.5)) * (60 - FeaOnDelay) / 60f * 1.8f, null, new Color(255, 255, 255, 255), 0f, Utils.Size(mod.GetTexture("UIImages/Feather2")) / 2f, 1f, SpriteEffects.None, 0f);
                            if (fea[u] != 0)
                            {
                                float scal = 1f;
                                if (TextureAssets.Item[fea[u]].Value.Width + TextureAssets.Item[fea[u]].Value.Height > 60)
                                {
                                    scal = 60f / (float)(TextureAssets.Item[fea[u]].Value.Width + TextureAssets.Item[fea[u]].Value.Height);
                                }
                                spriteBatch.Draw(TextureAssets.Item[fea[u]].Value, vfea[u], null, new Color(255, 255, 255, 255), 0f, Utils.Size(TextureAssets.Item[fea[u]].Value) / 2f, scal, SpriteEffects.None, 0f);
                            }
                        }
                    }
                    /*Main.HoverItem.type*/
                    if ((vMou - FesPos).Length() > 32)
                    {
                        spriteBatch.Draw(mod.GetTexture("UIImages/WINGHighLight"), FesPos, null, new Color(255, 255, 255, 255), 0f, Utils.Size(mod.GetTexture("UIImages/WINGHighLight")) / 2f, 1f, SpriteEffects.None, 0f);
                    }
                    else
                    {
                        spriteBatch.Draw(mod.GetTexture("UIImages/WING"), FesPos, null, new Color(140, 140, 140, 0), 0f, Utils.Size(mod.GetTexture("UIImages/WING")) / 2f, 1f, SpriteEffects.None, 0f);
                        Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "关闭羽毛界面", Main.mouseX + 20, Main.mouseY, new Color(255, 255, 255), new Color(0, 0, 0), Vector2.Zero, 1);
                        if (FeaOnDelay == 0 && Main.mouseLeft)
                        {
                            FeaSystem = false;
                            FeaOffDelay = 60;
                        }
                    }
                }
                if (cooling > 0)
                {
                    cooling -= 1;
                }
                else
                {
                    cooling = 0;
                    Uns = true;
                }
                if(Main.mouseItem.stack == 0)
                {
                    Main.mouseItem.type = 0;
                }
                for (int i = 0,fp = 0,ep = 0,lp = 0, bp = 0, pp = 0; i < 40; i++)
                {
                    if (fea[i] == 1519)
                    {
                        fp += 20;
                    }
                    if (fea[i] == mod.Find<ModItem>("SnowFeather").Type)
                    {
                        fp += 7;
                    }
                    if (fea[i] == mod.Find<ModItem>("RedSnowFeather").Type)
                    {
                        fp += 15;
                    }
                    if (fea[i] == mod.Find<ModItem>("PoisonFeather").Type)
                    {
                        pp += 200;
                    }
                    if (fea[i] == mod.Find<ModItem>("DarkGoldFeather").Type)
                    {
                        bp += 100;
                    }
                    if (fea[i] == mod.Find<ModItem>("LightingFeather").Type)
                    {
                        lp += 60;
                    }
                    if (fea[i] == 1518)
                    {
                        ep += 40;
                    }
                    if (fea[i] == mod.Find<ModItem>("SolarFeather").Type)
                    {
                        ep += 110;
                    }
                    if (i == 39)
                    {
                        /*string key = ep.ToString();
                        Color messageColor = Color.Purple;
                        Main.NewText(Language.GetTextValue(key), messageColor);*/
                        mplayer.FreezingPoint = fp;
                        mplayer.ExpolodePoint = ep;
                        mplayer.LightingPoint = lp;
                        mplayer.PoisonPoint = pp;
                        mplayer.BloodPoint = bp;
                    }
                    if ((vMou - vfea[i]).Length() < 18)
                    {
                        if (CanFea[i])
                        {
                            if (fea[i] == 0)//放置
                            {
                                if(cooling == 0)
                                {
                                    if(Main.mouseItem.stack == 1 && Uns && Main.mouseItem.rare <= i)
                                    {
                                        Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "可嵌入羽毛", Main.mouseX, Main.mouseY + 36, new Color(255, 255, 255), new Color(0, 0, 0), Vector2.Zero, 1);
                                        if (Main.mouseLeft)
                                        {
                                            if(ContainFea.Contains(Main.mouseItem.type))
                                            {
                                                fea[i] = Main.mouseItem.type;
                                                Main.mouseItem.type = 0;
                                                Main.mouseItem.stack--;
                                                cooling = 10;
                                            }
                                        }
                                    }
                                    String T = "";
                                    if (Main.mouseItem.stack > 1)
                                    {
                                        T += "\n请将羽毛的堆叠数量改为1";
                                    }
                                    if (Main.mouseItem.rare > i && ContainFea.Contains(Main.mouseItem.type))
                                    {
                                        T += "\n该羽毛槽无法承载这么高品质的羽毛";
                                    }
                                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, T, Main.mouseX, Main.mouseY + 32, new Color(255, 0, 0), new Color(0, 0, 0), Vector2.Zero, 1);
                                }
                            }
                            else
                            {
                                if(FeaSystem)
                                {
                                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, Lang.GetItemName(fea[i]).ToString(), Main.mouseX, Main.mouseY + 36, new Color(255, 255, 255), new Color(0, 0, 0), Vector2.Zero, 1);
                                }

                                if (Main.mouseLeft && cooling == 0)//交换
                                {
                                    if (Main.mouseItem.stack == 1 && Uns && Main.mouseItem.rare <= i)
                                    {
                                        if (ContainFea.Contains(Main.mouseItem.type))
                                        {
                                            cooling = 10;
                                            int T = 0;
                                            T = fea[i];
                                            fea[i] = Main.mouseItem.type;
                                            Main.mouseItem.SetDefaults(T);
                                        }
                                    }                                                                       
                                }
                                if (Main.mouseLeft && cooling == 0)
                                {
                                    String T = "";
                                    if (Main.mouseItem.stack > 1)
                                    {
                                        T += "\n请将羽毛的堆叠数量改为1";
                                    }
                                    if (Main.mouseItem.rare > i && ContainFea.Contains(Main.mouseItem.type))
                                    {
                                        T += "\n该羽毛槽无法承载这么高品质的羽毛";
                                    }
                                    Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, T, Main.mouseX, Main.mouseY + 32, new Color(255, 0, 0), new Color(0, 0, 0), Vector2.Zero, 1);
                                }
                                if (Main.mouseLeft && cooling == 0 && Main.mouseItem.stack <= 0)//卸下
                                {
                                    Uns = false;
                                }
                                if(!Uns && Main.mouseLeftRelease)
                                {
                                    cooling = 10;
                                    Main.mouseItem.SetDefaults(fea[i]);
                                    fea[i] = 0;
                                }
                            }
                        }
                        else
                        {
                            Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "尚未解锁", Main.mouseX, Main.mouseY + 36, new Color(255, 255, 255), new Color(0, 0, 0), Vector2.Zero, 1);
                        }
                    }
                    mplayer.Feathers[i] = fea[i];
                }
            }
            /*波江*/
            if (player.HeldItem.type == mod.Find<ModItem>("Wave").Type)
            {
                /*List<CustomVertexInfo> bars = new List<CustomVertexInfo>();

                // 把所有的点都生成出来，按照顺序
                for (int i = 1; i < projectile.oldPos.Length; ++i)
                {
                    if (projectile.oldPos[i] == Vector2.Zero) break;
                    //spriteBatch.Draw(Main.magicPixel, projectile.oldPos[i] - Main.screenPosition,
                    //    new Rectangle(0, 0, 1, 1), Color.White, 0f, new Vector2(0.5f, 0.5f), 5f, SpriteEffects.None, 0f);

                    int width = 30;
                    var normalDir = projectile.oldPos[i - 1] - projectile.oldPos[i];
                    normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));

                    var factor = i / (float)projectile.oldPos.Length;
                    var color = Color.Lerp(Color.White, Color.Blue, factor);
                    var w = MathHelper.Lerp(1f, 0.05f, factor);

                    bars.Add(new CustomVertexInfo(projectile.oldPos[i] + normalDir * width + new Vector2(13, 13) - projectile.velocity * 1.5f, color, new Vector3((float)Math.Sqrt(factor), 1, w)));
                    bars.Add(new CustomVertexInfo(projectile.oldPos[i] + normalDir * -width + new Vector2(13, 13) - projectile.velocity * 1.5f, color, new Vector3((float)Math.Sqrt(factor), 0, w)));
                }

                List<CustomVertexInfo> triangleList = new List<CustomVertexInfo>();

                if (bars.Count > 2)
                {

                    // 按照顺序连接三角形
                    triangleList.Add(bars[0]);
                    var vertex = new CustomVertexInfo((bars[0].Position + bars[1].Position) * 0.5f + Vector2.Normalize(projectile.velocity) * 30, Color.White, new Vector3(0, 0.5f, 1));
                    triangleList.Add(bars[1]);
                    triangleList.Add(vertex);
                    for (int i = 0; i < bars.Count - 2; i += 2)
                    {
                        triangleList.Add(bars[i]);
                        triangleList.Add(bars[i + 2]);
                        triangleList.Add(bars[i + 1]);

                        triangleList.Add(bars[i + 1]);
                        triangleList.Add(bars[i + 2]);
                        triangleList.Add(bars[i + 3]);
                    }


                    spriteBatch.End();
                    spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, SamplerState.PointWrap, DepthStencilState.Default, RasterizerState.CullNone);
                    RasterizerState originalState = Main.graphics.GraphicsDevice.RasterizerState;
                    // 干掉注释掉就可以只显示三角形栅格
                    //RasterizerState rasterizerState = new RasterizerState();
                    //rasterizerState.CullMode = CullMode.None;
                    //rasterizerState.FillMode = FillMode.WireFrame;
                    //Main.graphics.GraphicsDevice.RasterizerState = rasterizerState;

                    var projection = Matrix.CreateOrthographicOffCenter(0, Main.screenWidth, Main.screenHeight, 0, 0, 1);
                    var model = Matrix.CreateTranslation(new Vector3(-Main.screenPosition.X, -Main.screenPosition.Y, 0));

                    // 把变换和所需信息丢给shader
                    MythMod.DefaultEffectB2.Parameters["uTransform"].SetValue(model * projection);
                    MythMod.DefaultEffectB2.Parameters["uTime"].SetValue(-(float)Main.time * 0.03f);
                    Main.graphics.GraphicsDevice.Textures[0] = MythMod.MainColorBlue;
                    Main.graphics.GraphicsDevice.Textures[1] = MythMod.MainShape;
                    Main.graphics.GraphicsDevice.Textures[2] = MythMod.MaskColor;
                    Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
                    Main.graphics.GraphicsDevice.SamplerStates[1] = SamplerState.PointWrap;
                    Main.graphics.GraphicsDevice.SamplerStates[2] = SamplerState.PointWrap;
                    //Main.graphics.GraphicsDevice.Textures[0] = Main.magicPixel;
                    //Main.graphics.GraphicsDevice.Textures[1] = Main.magicPixel;
                    //Main.graphics.GraphicsDevice.Textures[2] = Main.magicPixel;

                    MythMod.DefaultEffectB2.CurrentTechnique.Passes[0].Apply();


                    Main.graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, triangleList.ToArray(), 0, triangleList.Count / 3);

                    Main.graphics.GraphicsDevice.RasterizerState = originalState;
                    spriteBatch.End();
                    spriteBatch.Begin();
                }*/
            }
            if (NPC.CountNPCS(mod.Find<ModNPC>("CrystalSwordEX").Type) >= 1)
            {
                for(int l = 0; l < 200; l++)
                {
                    if(Main.npc[l].type == mod.Find<ModNPC>("CrystalSwordEX").Type)
                    {
                        Utils.DrawBorderStringFourWay(Main.spriteBatch, FontAssets.MouseText.Value, "累计伤害:" + (mplayer.KillCrystal).ToString(), Main.npc[l].Center.X - Main.screenPosition.X - 127f, Main.npc[l].Center.Y - Main.screenPosition.Y - 110f, new Color(0, 150, 255), new Color(255, 255, 255), Vector2.Zero, 2);
                    }
                }
            }
            if (!player.HasBuff(mod.Find<ModBuff>("愚昧诅咒").Type))
            {
                if (mplayer.ArrowMHold > 0)
                {
                    for (int z = 0; z < 7; z++)
                    {
                        Vector2 v = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
                        Vector2 v2 = (v - player.Center) / ((v - player.Center).Length() + 0.00001f) * 30f;
                        Vector2 v3 = v2.RotatedBy(Math.Sin(z / 5.5f * Math.PI + Main.time / 15d) / 2.2f);
                        for (float i = (float)(Main.time / 15d + z / 6d) % 1; i < 25; i++)
                        {
                            spriteBatch.Draw(mod.GetTexture("Projectiles/散裂之星2"), player.Center + v3 * (i + 1) - Main.screenPosition + new Vector2(0, i * i / 6f), null, new Color(255, 255, 255, 0), 0f, Utils.Size(mod.GetTexture("Projectiles/散裂之星2")) / 2f, (25 - i) / 50f, SpriteEffects.None, 0f);
                        }
                    }
                }
                if (mplayer.BstarMHold > 0)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/Bluelight"), new Vector2(Main.mouseX, Main.mouseY + 265), null, new Color(0.5f + 0.5f * (float)Math.Sin(Main.time / 5f), 0.5f + 0.5f * (float)Math.Sin(Main.time / 5f), 0.5f + 0.5f * (float)Math.Sin(Main.time / 5f), 0), 0, new Vector2(200, 275), 1, SpriteEffects.None, 0f);
                }
                if (mplayer.FlowMHold > 0)
                {
                    for (int k = 0; k < 80; k++)
                    {
                        Vector2 v = new Vector2(0, 1);
                        Vector2 v3 = (v - new Vector2(Main.mouseX, Main.mouseY)) / ((v - new Vector2(Main.mouseX, Main.mouseY)).Length() + 0.00001f) * 10f;
                        Vector2 v2 = v3.RotatedBy(Math.PI * k / 40d);
                        for (float i = (float)(Main.time / 15d) % 1; i < 10; i++)
                        {
                            spriteBatch.Draw(mod.GetTexture("Projectiles/projectile4/GarnetStaff2"), new Vector2(Main.mouseX, Main.mouseY) + v2 * (i + 2), null, new Color(0.6f, 0.6f, 0.6f, 0), 0f, Utils.Size(mod.GetTexture("Projectiles/projectile4/GarnetStaff2")) / 2f, (10 - i) / 36f, SpriteEffects.None, 0f);
                        }
                    }
                }
                if (mplayer.BloodMHold > 0)
                {
                    for (int z = 0; z < 7; z++)
                    {
                        Vector2 v = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
                        Vector2 v2 = (v - player.Center) / ((v - player.Center).Length() + 0.00001f) * 30f;
                        Vector2 v3 = v2.RotatedBy(Math.Sin(z / 5.5f * Math.PI + Main.time / 15d) / 2.2f);
                        for (float i = (float)(Main.time / 15d + z / 6d) % 1; i < 25; i++)
                        {
                            spriteBatch.Draw(mod.GetTexture("Projectiles/FireworkGoldShine2"), player.Center + v3 * (i + 1) - Main.screenPosition + new Vector2(0, i * i / 8f), null, new Color(255, 255, 255, 0), 0f, Utils.Size(mod.GetTexture("Projectiles/FireworkGoldShine2")) / 2f, (25 - i) / 50f, SpriteEffects.None, 0f);
                        }
                    }
                }
                if (mplayer.ProjMHold > 0)
                {
                    for (int z = 0; z < 7; z++)
                    {
                        Vector2 v = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
                        Vector2 v2 = (v - player.Center) / ((v - player.Center).Length() + 0.00001f) * 30f;
                        Vector2 v3 = v2.RotatedBy(Math.Sin(z / 5.5f * Math.PI + Main.time / 15d) / 2.2f);
                        for (float i = (float)(Main.time / 15d + z / 6d) % 1; i < 25; i++)
                        {
                            spriteBatch.Draw(mod.GetTexture("Projectiles/紫点海葵粒子"), player.Center + v3 * (i + 1) - Main.screenPosition + new Vector2(0, i * i / 8f), null, new Color(255, 255, 255, 0), 0f, Utils.Size(mod.GetTexture("Projectiles/紫点海葵粒子")) / 2f, (25 - i) / 50f, SpriteEffects.None, 0f);
                        }
                    }
                }
                if (mplayer.LazaMHold > 0)
                {
                    spriteBatch.Draw(mod.GetTexture("Dusts/Purple"), player.Center - Main.screenPosition - new Vector2(Main.screenWidth / 2f, Main.screenHeight / 2f), new Rectangle(0, 0, Main.screenWidth + 50, Main.screenHeight + 50), new Color(0.5f + 0.5f * (float)Math.Sin(Main.time / 5f), 0.5f + 0.5f * (float)Math.Sin(Main.time / 5f), 0.5f + 0.5f * (float)Math.Sin(Main.time / 5f), 0), 0f, Utils.Size(mod.GetTexture("Dusts/Purple")) / 2f, 1f, SpriteEffects.None, 0f);
                }
                if (mplayer.CoinMHold > 0)
                {
                    spriteBatch.Draw(mod.GetTexture("Dusts/Coin"), player.Center - Main.screenPosition - new Vector2(Main.screenWidth / 2f, Main.screenHeight / 2f), new Rectangle(0, 0, Main.screenWidth + 50, Main.screenHeight + 50), new Color(0.5f + 0.5f * (float)Math.Sin(Main.time / 5f), 0.5f + 0.5f * (float)Math.Sin(Main.time / 5f), 0.5f + 0.5f * (float)Math.Sin(Main.time / 5f), 0), 0f, Utils.Size(mod.GetTexture("Dusts/Coin")) / 2f, 1f, SpriteEffects.None, 0f);
                }
                if (mplayer.CurseMHold > 0)
                {
                    Vector2 v = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
                    Vector2 v2 = (v - player.Center) / ((v - player.Center).Length() + 0.00001f) * 30f;
                    for (float i = (float)(Main.time / 15d) % 1; i < 25; i++)
                    {
                        spriteBatch.Draw(mod.GetTexture("Projectiles/FireworkGreen"), player.Center + v2 * (i + 2) - Main.screenPosition, null, new Color(255, 255, 255, 0), 0f, Utils.Size(mod.GetTexture("Projectiles/FireworkGreen")) / 2f, (25 - i) / 25f, SpriteEffects.None, 0f);
                    }
                }
                if (mplayer.WitcMHold > 0)
                {
                    Vector2 v = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
                    Vector2 v2 = (v - player.Center) / ((v - player.Center).Length() + 0.00001f) * 30f;
                    for (float i = (float)(Main.time / 15d) % 1; i < 25; i++)
                    {
                        spriteBatch.Draw(mod.GetTexture("Projectiles/FireworkSilver2"), player.Center + v2 * (i + 2) - Main.screenPosition, null, new Color(255, 255, 255, 0), 0f, Utils.Size(mod.GetTexture("Projectiles/FireworkSilver2")) / 2f, (25 - i) / 25f, SpriteEffects.None, 0f);
                    }
                }
                if (mplayer.ElectricMHold > 0)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/ElectricRing"), new Vector2(Main.mouseX, Main.mouseY), new Rectangle(0, 102 * (int)(((Main.time + 28) / 4d) % 4), 102, 102), new Color(255, 255, 255, 0), (float)(Main.time / 32d), new Vector2(51, 51), (float)(Math.Sin(Main.time / 15d) / 15 + 1), SpriteEffects.None, 0f);
                    spriteBatch.Draw(mod.GetTexture("UIImages/ElectricRing"), new Vector2(Main.mouseX, Main.mouseY), new Rectangle(0, 102 * (int)((Main.time / 4d) % 4), 102, 102), new Color(255, 255, 255, 0), (float)(-Main.time / 32d), new Vector2(51, 51), (float)(-Math.Sin(Main.time / 15d) / 15 + 1) / 1.2f, SpriteEffects.None, 0f);
                }
                if (mplayer.ShadMHold > 0)
                {
                    for(int k = 0; k < 6; k++)
                    {
                        Vector2 v = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
                        Vector2 v3 = (v - player.Center) / ((v - player.Center).Length() + 0.00001f) * 30f;
                        Vector2 v2 = v3.RotatedBy(Math.Sin(Main.time / 15d + k) * 0.5f);
                        for (float i = (float)(Main.time / 15d) % 1; i < 25; i++)
                        {
                            spriteBatch.Draw(mod.GetTexture("Projectiles/FireworkPurple"), player.Center + v2 * (i + 2) - Main.screenPosition, null, new Color(255, 255, 255, 0), 0f, Utils.Size(mod.GetTexture("Projectiles/FireworkPurple")) / 2f, (25 - i) / 16f, SpriteEffects.None, 0f);
                        }
                    }
                }
                if (mplayer.MeteorMHold > 0)
                {
                    spriteBatch.Draw(mod.GetTexture("UIImages/FlameRing"), new Vector2(Main.mouseX, Main.mouseY), null, new Color(255, 255, 255, 0), (float)(-Main.time / 32d), new Vector2(200, 200), 1, SpriteEffects.None, 0f);
                }
                if (mplayer.IceMHold > 0)
                {
                    Vector2 v = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
                    Vector2 v2 = (v - player.Center) / ((v - player.Center).Length() + 0.00001f) * 30f;
                    for (float i = (float)(Main.time / 15d) % 1; i < 25; i++)
                    {
                        spriteBatch.Draw(mod.GetTexture("Projectiles/霜雪破散裂"), player.Center + v2 * (i + 2) - Main.screenPosition, null, new Color(255, 255, 255, 0), 0f, Utils.Size(mod.GetTexture("Projectiles/霜雪破散裂")) / 2f, (25 - i) / 25f, SpriteEffects.None, 0f);
                    }
                }
                if (mplayer.FireMHold > 0)
                {
                    Vector2 v = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
                    Vector2 v2 = (v - player.Center) / ((v - player.Center).Length() + 0.00001f) * 30f;
                    for (float i = (float)(Main.time / 15d) % 1; i < 25; i++)
                    {
                        spriteBatch.Draw(mod.GetTexture("Projectiles/海葵粒子"), player.Center + v2 * (i + 2) - Main.screenPosition, null, new Color(255, 255, 255, 0), 0f, Utils.Size(mod.GetTexture("Projectiles/海葵粒子")) / 2f, (25 - i) / 25f, SpriteEffects.None, 0f);
                    }
                }
                if (mplayer.FreLoopMHold > 0)
                {
                    for(int k = 0; k < 320; k++)
                    {
                        Vector2 v = new Vector2(0, 1);
                        Vector2 v3 = (v - player.Center) / ((v - player.Center).Length() + 0.00001f) * 30f;
                        Vector2 v2 = v3.RotatedBy(Math.PI * k / 160d);
                        for (float i = (float)(Main.time / 15d) % 1; i < 10; i++)
                        {
                            spriteBatch.Draw(mod.GetTexture("Projectiles/projectile3/GoldPosiDust"), player.Center + v2 * (i + 2) - Main.screenPosition, null, new Color(0.6f, 0.6f, 0.6f, 0), 0f, Utils.Size(mod.GetTexture("Projectiles/projectile3/GoldPosiDust")) / 2f, (10 - i) / 36f, SpriteEffects.None, 0f);
                        }
                    }
                }
            }
            for (int i = 0;i < 6000;i++)
            {
                if(Main.dust[i].type == mod.Find<ModDust>("PurpleFlame").Type && Main.dust[i].scale > 0.3f)
                {
                    for (int l = 0; l < Main.dust[i].scale * 20f; l++)
                    {
                        float Dx = Main.rand.NextFloat(-9f, 9f);
                        spriteBatch.Draw(mod.GetTexture("UIImages/fireEffect"), new Vector2(Main.dust[i].position.X + Dx * Main.dust[i].scale, Main.dust[i].position.Y + Main.rand.NextFloat(-2f, 2f) * Main.dust[i].scale) - Main.screenPosition, null, new Color(0.18f,0.12f,0.2f,0), 0f, Utils.Size(mod.GetTexture("UIImages/fireEffect")) / 2f, Main.dust[i].scale * 0.01f * (5 - Math.Abs(Dx)) / 6f, SpriteEffects.None, 0f);
                    }
                }
                if (Main.dust[i].type == mod.Find<ModDust>("Crystal").Type && Main.dust[i].scale > 0.3f)
                {
                    for (int l = 0; l < Main.dust[i].scale * 20f; l++)
                    {
                        spriteBatch.Draw(mod.GetTexture("Dusts/CrystalEffect"), new Vector2(Main.dust[i].position.X + (float)l * Main.dust[i].scale, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i)) / 2f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 4d / 3d)) / 2f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 1d / 3d)) / 2f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/CrystalEffect")) / 2f, Main.dust[i].scale, SpriteEffects.None, 0f);
                        spriteBatch.Draw(mod.GetTexture("Dusts/CrystalEffect"), new Vector2(Main.dust[i].position.X - (float)l * Main.dust[i].scale, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i)) / 2f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 4d / 3d)) / 2f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 1d / 3d)) / 2f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/CrystalEffect")) / 2f, Main.dust[i].scale, SpriteEffects.None, 0f);
                        spriteBatch.Draw(mod.GetTexture("Dusts/CrystalEffect"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y + (float)l * Main.dust[i].scale) - Main.screenPosition, null, new Color(Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i)) / 2f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 4d / 3d)) / 2f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 1d / 3d)) / 2f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/CrystalEffect")) / 2f, Main.dust[i].scale, SpriteEffects.None, 0f);
                        spriteBatch.Draw(mod.GetTexture("Dusts/CrystalEffect"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y - (float)l * Main.dust[i].scale) - Main.screenPosition, null, new Color(Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i)) / 2f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 4d / 3d)) / 2f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 1d / 3d)) / 2f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/CrystalEffect")) / 2f, Main.dust[i].scale, SpriteEffects.None, 0f);
                    }
                }
                if (Main.dust[i].type == mod.Find<ModDust>("CrystalBlue").Type && Main.dust[i].scale > 0.3f)
                {
                    for (int l = 0; l < Main.dust[i].scale * 20f; l++)
                    {
                        spriteBatch.Draw(mod.GetTexture("Dusts/CrystalEffect"), new Vector2(Main.dust[i].position.X + (float)l * Main.dust[i].scale, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i)) / 20f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 4d / 3d)) / 6f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 1d / 3d)) / 0.7f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/CrystalEffect")) / 1f, Main.dust[i].scale, SpriteEffects.None, 0f);
                        spriteBatch.Draw(mod.GetTexture("Dusts/CrystalEffect"), new Vector2(Main.dust[i].position.X - (float)l * Main.dust[i].scale, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i)) / 20f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 4d / 3d)) / 6f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 1d / 3d)) / 0.7f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/CrystalEffect")) / 1f, Main.dust[i].scale, SpriteEffects.None, 0f);
                        spriteBatch.Draw(mod.GetTexture("Dusts/CrystalEffect"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y + (float)l * Main.dust[i].scale) - Main.screenPosition, null, new Color(Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i)) / 20f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 4d / 3d)) / 6f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 1d / 3d)) / 0.7f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/CrystalEffect")) / 1f, Main.dust[i].scale, SpriteEffects.None, 0f);
                        spriteBatch.Draw(mod.GetTexture("Dusts/CrystalEffect"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y - (float)l * Main.dust[i].scale) - Main.screenPosition, null, new Color(Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i)) / 20f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 4d / 3d)) / 6f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 1d / 3d)) / 0.7f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/CrystalEffect")) / 1f, Main.dust[i].scale, SpriteEffects.None, 0f);
                    }
                }
                if (Main.dust[i].type == mod.Find<ModDust>("CrystalCrism").Type && Main.dust[i].scale > 0.3f)
                {
                    for (int l = 0; l < Main.dust[i].scale * 20f; l++)
                    {
                        spriteBatch.Draw(mod.GetTexture("Dusts/CrystalEffect"), new Vector2(Main.dust[i].position.X + (float)l * Main.dust[i].scale, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i)) / 0.7f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 4d / 3d)) / 5f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 1d / 3d)) / 20f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/CrystalEffect")) / 2f, Main.dust[i].scale, SpriteEffects.None, 0f);
                        spriteBatch.Draw(mod.GetTexture("Dusts/CrystalEffect"), new Vector2(Main.dust[i].position.X - (float)l * Main.dust[i].scale, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i)) / 0.7f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 4d / 3d)) / 5f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 1d / 3d)) / 20f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/CrystalEffect")) / 2f, Main.dust[i].scale, SpriteEffects.None, 0f);
                        spriteBatch.Draw(mod.GetTexture("Dusts/CrystalEffect"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y + (float)l * Main.dust[i].scale) - Main.screenPosition, null, new Color(Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i)) / 0.7f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 4d / 3d)) / 5f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 1d / 3d)) / 20f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/CrystalEffect")) / 2f, Main.dust[i].scale, SpriteEffects.None, 0f);
                        spriteBatch.Draw(mod.GetTexture("Dusts/CrystalEffect"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y - (float)l * Main.dust[i].scale) - Main.screenPosition, null, new Color(Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i)) / 0.7f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 4d / 3d)) / 5f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 1d / 3d)) / 20f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/CrystalEffect")) / 2f, Main.dust[i].scale, SpriteEffects.None, 0f);
                    }
                }
                if (Main.dust[i].type == mod.Find<ModDust>("Crystal2").Type && Main.dust[i].scale > 0.3f)
                {
                    for (int l = 0; l < Main.dust[i].scale * 20f; l++)
                    {
                        spriteBatch.Draw(mod.GetTexture("Dusts/CrystalEffect"), new Vector2(Main.dust[i].position.X + (float)l * Main.dust[i].scale, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i)) / 50f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 4d / 3d)) / 20f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 1d / 3d)) / 2f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/CrystalEffect")) / 2f, Main.dust[i].scale, SpriteEffects.None, 0f);
                        spriteBatch.Draw(mod.GetTexture("Dusts/CrystalEffect"), new Vector2(Main.dust[i].position.X - (float)l * Main.dust[i].scale, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i)) / 50f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 4d / 3d)) / 20f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 1d / 3d)) / 2f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/CrystalEffect")) / 2f, Main.dust[i].scale, SpriteEffects.None, 0f);
                        spriteBatch.Draw(mod.GetTexture("Dusts/CrystalEffect"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y + (float)l * Main.dust[i].scale) - Main.screenPosition, null, new Color(Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i)) / 50f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 4d / 3d)) / 20f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 1d / 3d)) / 2f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/CrystalEffect")) / 2f, Main.dust[i].scale, SpriteEffects.None, 0f);
                        spriteBatch.Draw(mod.GetTexture("Dusts/CrystalEffect"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y - (float)l * Main.dust[i].scale) - Main.screenPosition, null, new Color(Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i)) / 50f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 4d / 3d)) / 20f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 1d / 3d)) / 2f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/CrystalEffect")) / 2f, Main.dust[i].scale, SpriteEffects.None, 0f);
                    }
                }
                if (Main.dust[i].type == mod.Find<ModDust>("Star").Type && Main.dust[i].scale > 0.3f)
                {
                    int R0 = (int)(73 + (Math.Sin(Main.dust[i].scale * 12) + 1) * 70.5);
                    int G0 = (int)(170 - (Math.Sin(Main.dust[i].scale * 12) + 1) * 52);
                    for (int l = 0; l < Main.dust[i].scale * 8f; l++)
                    {
                        spriteBatch.Draw(mod.GetTexture("Dusts/CrystalEffect"), new Vector2(Main.dust[i].position.X + (float)l * Main.dust[i].scale, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i) / 4f) * R0 / 600f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 4d / 3d) / 4f) * G0 / 600f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 1d / 3d) / 4f) * 255f / 600f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/CrystalEffect")) / 2f, Main.dust[i].scale, SpriteEffects.None, 0f);
                        spriteBatch.Draw(mod.GetTexture("Dusts/CrystalEffect"), new Vector2(Main.dust[i].position.X - (float)l * Main.dust[i].scale, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i) / 4f) * R0 / 600f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 4d / 3d) / 4f) * G0 / 600f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 1d / 3d) / 4f) * 255f / 600f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/CrystalEffect")) / 2f, Main.dust[i].scale, SpriteEffects.None, 0f);
                        spriteBatch.Draw(mod.GetTexture("Dusts/CrystalEffect"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y + (float)l * Main.dust[i].scale) - Main.screenPosition, null, new Color(Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i) / 4f) * R0 / 600f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 4d / 3d) / 4f) * G0 / 600f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 1d / 3d) / 4f) * 255f / 600f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/CrystalEffect")) / 2f, Main.dust[i].scale, SpriteEffects.None, 0f);
                        spriteBatch.Draw(mod.GetTexture("Dusts/CrystalEffect"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y - (float)l * Main.dust[i].scale) - Main.screenPosition, null, new Color(Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i) / 4f) * R0 / 600f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 4d / 3d) / 4f) * G0 / 600f, Main.dust[i].scale / (float)l * (float)(1 + Math.Sin((float)l / 3d + i + Math.PI * 1d / 3d) / 4f) * 255f / 600f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/CrystalEffect")) / 2f, Main.dust[i].scale, SpriteEffects.None, 0f);
                    }
                }
                if (Main.dust[i].type == mod.Find<ModDust>("Purplefire").Type && Main.dust[i].scale > 0.15f)
                {
                    float St = Main.dust[i].scale / 6f;
                    if(St > 0.3f)
                    {
                        St = 0.3f;
                    }
                    spriteBatch.Draw(mod.GetTexture("Dusts/Purplelight"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(St,St,St, 0), 0f, new Vector2(56, 56), Main.dust[i].scale * 0.15f, SpriteEffects.None, 0f);
                }
                if (Main.dust[i].type == mod.Find<ModDust>("Redfire").Type && Main.dust[i].scale > 0.15f)
                {
                    float St = Main.dust[i].scale / 6f;
                    if (St > 0.3f)
                    {
                        St = 0.3f;
                    }
                    spriteBatch.Draw(mod.GetTexture("Dusts/Redlight"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(St, St, St, 0), 0f, new Vector2(56, 56), Main.dust[i].scale * 0.15f, SpriteEffects.None, 0f);
                }
                if (Main.dust[i].type == mod.Find<ModDust>("Greenfire").Type && Main.dust[i].scale > 0.15f)
                {
                    float St = Main.dust[i].scale / 6f;
                    if (St > 0.3f)
                    {
                        St = 0.3f;
                    }
                    spriteBatch.Draw(mod.GetTexture("Dusts/Greenlight"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(St, St, St, 0), 0f, new Vector2(56, 56), Main.dust[i].scale * 0.15f, SpriteEffects.None, 0f);
                }
                if (Main.dust[i].type == mod.Find<ModDust>("BlueEffect").Type && Main.dust[i].scale > 0.15f)
                {
                    spriteBatch.Draw(mod.GetTexture("Dusts/Bluelight"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(Main.dust[i].scale / 2f - 0.075f, Main.dust[i].scale / 2f - 0.075f, Main.dust[i].scale / 2f - 0.075f, 0), 0f, new Vector2(56, 56), (1.2f - Main.dust[i].scale) * 2f, SpriteEffects.None, 0f);
                }
                if (Main.dust[i].type == mod.Find<ModDust>("GreenEffect").Type && Main.dust[i].scale > 0.15f)
                {
                    spriteBatch.Draw(mod.GetTexture("Dusts/Greenlight"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(Main.dust[i].scale / 2f - 0.075f, Main.dust[i].scale / 2f - 0.075f, Main.dust[i].scale / 2f - 0.075f, 0), 0f, new Vector2(56, 56), (1.2f - Main.dust[i].scale) * 2f, SpriteEffects.None, 0f);
                }
                if (Main.dust[i].type == mod.Find<ModDust>("GarnetEffect").Type && Main.dust[i].scale > 0.15f)
                {
                    spriteBatch.Draw(mod.GetTexture("Dusts/Garnetlight"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(Main.dust[i].scale / 2f - 0.075f, Main.dust[i].scale / 2f - 0.075f, Main.dust[i].scale / 2f - 0.075f, 0), 0f, new Vector2(56, 56), (1.2f - Main.dust[i].scale) * 2f, SpriteEffects.None, 0f);
                }
                if (Main.dust[i].type == mod.Find<ModDust>("PurpleEffect").Type && Main.dust[i].scale > 0.15f)
                {
                    spriteBatch.Draw(mod.GetTexture("Dusts/Purplelight"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(Main.dust[i].scale / 2f - 0.075f, Main.dust[i].scale / 2f - 0.075f, Main.dust[i].scale / 2f - 0.075f, 0), 0f, new Vector2(56, 56), (1.2f - Main.dust[i].scale) * 2f, SpriteEffects.None, 0f);
                }
                if (Main.dust[i].type == mod.Find<ModDust>("RedEffect").Type && Main.dust[i].scale > 0.15f)
                {
                    spriteBatch.Draw(mod.GetTexture("Dusts/Redlight"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(Main.dust[i].scale / 2f - 0.075f, Main.dust[i].scale / 2f - 0.075f, Main.dust[i].scale / 2f - 0.075f, 0), 0f, new Vector2(56, 56), (1.2f - Main.dust[i].scale) * 2f, SpriteEffects.None, 0f);
                }
                if (Main.dust[i].type == mod.Find<ModDust>("WhiteEffect").Type && Main.dust[i].scale > 0.15f && i % 3 == 0)
                {
                    spriteBatch.Draw(mod.GetTexture("Dusts/Silverlight"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(Main.dust[i].scale / 1.5f - 0.1f, 0, 0, 0), 0f, new Vector2(56, 56), (1.2f - Main.dust[i].scale) * 2f, SpriteEffects.None, 0f);
                }
                if (Main.dust[i].type == mod.Find<ModDust>("WhiteEffect").Type && Main.dust[i].scale > 0.15f && i % 3 == 1)
                {
                    spriteBatch.Draw(mod.GetTexture("Dusts/Silverlight"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(0, Main.dust[i].scale / 1.5f - 0.1f, 0, 0), 0f, new Vector2(56, 56), (1.2f - Main.dust[i].scale) * 2f, SpriteEffects.None, 0f);
                }
                if (Main.dust[i].type == mod.Find<ModDust>("WhiteEffect").Type && Main.dust[i].scale > 0.15f && i % 3 == 2)
                {
                    spriteBatch.Draw(mod.GetTexture("Dusts/Silverlight"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(0, 0, Main.dust[i].scale / 1.5f - 0.1f, 0), 0f, new Vector2(56, 56), (1.2f - Main.dust[i].scale) * 2f, SpriteEffects.None, 0f);
                }
                if (Main.dust[i].type == mod.Find<ModDust>("Wave").Type && Main.dust[i].scale > 0.3f && Main.dust[i].active)
                {
                    Vector2 v = Main.dust[i].velocity;
                    for (int l = 0; l < Main.dust[i].velocity.Length() * 400; l += 120)
                    {
                        if (l > Main.dust[i].velocity.Length() * 250)
                        {
                            //spriteBatch.Draw(mod.GetTexture("Dusts/WaveEffect"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition - v.RotatedBy(l / 5000f * Math.Sin(l * Main.time / 50000f)) * (float)l / 100f, null, new Color(0.02f, 0.02f, 0.04f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/WaveEffect")) / 2f, Main.dust[i].scale, SpriteEffects.None, 0f);
                            //spriteBatch.Draw(mod.GetTexture("Dusts/WaveEffect"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition - v.RotatedBy(-(l / 5000f * Math.Sin(l * Main.time / 50000f))) * (float)l / 100f, null, new Color(0.02f, 0.02f, 0.04f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/WaveEffect")) / 2f, Main.dust[i].scale, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Dusts/WaveEffect"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition - v.RotatedBy(Math.PI * 0.5 - l / 5000f) * (float)l / 100f, null, new Color(0.009f, 0.009f, 0.018f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/WaveEffect")) / 2f, Main.dust[i].scale, SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Dusts/WaveEffect"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition + v.RotatedBy(Math.PI * 0.5 + l / 5000f) * (float)l / 100f, null, new Color(0.009f, 0.009f, 0.018f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/WaveEffect")) / 2f, Main.dust[i].scale, SpriteEffects.None, 0f);
                        }
                        else
                        {
                            //spriteBatch.Draw(mod.GetTexture("Dusts/WaveEffect"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition - v.RotatedBy(l / 5000f * Math.Sin(l * Main.time / 50000f)) * (float)l / 100f, null, new Color(0.02f * (Main.dust[i].velocity.Length() * 40f - l) / (Main.dust[i].velocity.Length() * 15f), 0.02f * (Main.dust[i].velocity.Length() * 400f - l) / (Main.dust[i].velocity.Length() * 150f), 0.04f * (Main.dust[i].velocity.Length() * 400f - l) / (Main.dust[i].velocity.Length() * 150f), 0), 0f, Utils.Size(mod.GetTexture("Dusts/WaveEffect")) / 2f, Main.dust[i].scale * (Main.dust[i].velocity.Length() * 400f - l) / (Main.dust[i].velocity.Length() * 150f), SpriteEffects.None, 0f);
                            //spriteBatch.Draw(mod.GetTexture("Dusts/WaveEffect"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition - v.RotatedBy(-(l / 5000f * Math.Sin(l * Main.time / 50000f))) * (float)l / 100f, null, new Color(0.02f * (Main.dust[i].velocity.Length() * 40f - l) / (Main.dust[i].velocity.Length() * 15f), 0.02f * (Main.dust[i].velocity.Length() * 400f - l) / (Main.dust[i].velocity.Length() * 150f), 0.04f * (Main.dust[i].velocity.Length() * 400f - l) / (Main.dust[i].velocity.Length() * 150f), 0), 0f, Utils.Size(mod.GetTexture("Dusts/WaveEffect")) / 2f, Main.dust[i].scale * (Main.dust[i].velocity.Length() * 400f - l) / (Main.dust[i].velocity.Length() * 150f), SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Dusts/WaveEffect"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition - v.RotatedBy(Math.PI * 0.5 - l / 5000f) * (float)l / 100f, null, new Color(0.009f * (Main.dust[i].velocity.Length() * 400f - l) / (Main.dust[i].velocity.Length() * 150f), 0.009f * (Main.dust[i].velocity.Length() * 400f - l) / (Main.dust[i].velocity.Length() * 150f), 0.018f * (Main.dust[i].velocity.Length() * 400f - l) / (Main.dust[i].velocity.Length() * 150f), 0), 0f, Utils.Size(mod.GetTexture("Dusts/WaveEffect")) / 2f, Main.dust[i].scale * (Main.dust[i].velocity.Length() * 400f - l) / (Main.dust[i].velocity.Length() * 150f), SpriteEffects.None, 0f);
                            spriteBatch.Draw(mod.GetTexture("Dusts/WaveEffect"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition + v.RotatedBy(Math.PI * 0.5 + l / 5000f) * (float)l / 100f, null, new Color(0.009f * (Main.dust[i].velocity.Length() * 400f - l) / (Main.dust[i].velocity.Length() * 150f), 0.009f * (Main.dust[i].velocity.Length() * 400f - l) / (Main.dust[i].velocity.Length() * 150f), 0.018f * (Main.dust[i].velocity.Length() * 400f - l) / (Main.dust[i].velocity.Length() * 150f), 0), 0f, Utils.Size(mod.GetTexture("Dusts/WaveEffect")) / 2f, Main.dust[i].scale * (Main.dust[i].velocity.Length() * 400f - l) / (Main.dust[i].velocity.Length() * 150f), SpriteEffects.None, 0f);
                        }
                    }
                }
                if (Main.dust[i].type == mod.Find<ModDust>("Wind").Type && Main.dust[i].scale > 0.3f && Main.dust[i].active)
                {
                    Vector2 v = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
                    float d = (Main.dust[i].position - v).Length();
                    if (d < 260)
                    {
                        if (d > 50)
                        {
                            if (i % 2 == 1)
                            {
                                spriteBatch.Draw(mod.GetTexture("Dusts/WindEffect"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(1 * (255 - Main.dust[i].alpha) / 510f * Main.dust[i].scale, 1 * (255 - Main.dust[i].alpha) / 510f * Main.dust[i].scale, 1 * (255 - Main.dust[i].alpha) / 510f * Main.dust[i].scale, 0), 0f, Utils.Size(mod.GetTexture("Dusts/WindEffect")) / 2f, Main.dust[i].scale / d * 80f, SpriteEffects.None, 0f);
                            }
                            else
                            {
                                spriteBatch.Draw(mod.GetTexture("Dusts/WindEffect"), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(1 * (255 - Main.dust[i].alpha) / 255f * Main.dust[i].scale, 1 * (255 - Main.dust[i].alpha) / 255f * Main.dust[i].scale, 1 * (255 - Main.dust[i].alpha) / 255f * Main.dust[i].scale, 0), 0f, Utils.Size(mod.GetTexture("Dusts/WindEffect")) / 2f, Main.dust[i].scale / d * 80f, SpriteEffects.None, 0f);
                            }
                        }
                    }
                }
                if (Main.dust[i].type == mod.Find<ModDust>("Pixel").Type && Main.dust[i].scale > 0.3f && Main.dust[i].active)
                {
                    spriteBatch.Draw(mod.GetTexture("Dusts/PixelEffect" + (i % 4 + 1).ToString()), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(1f, 1f, 1f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/PixelEffect" + (i % 4 + 1).ToString())) / 2f, Main.dust[i].scale / 5f, SpriteEffects.None, 0f);
                }
                if (Main.dust[i].type == mod.Find<ModDust>("Pixel2").Type && Main.dust[i].scale > 0.3f && Main.dust[i].active)
                {
                    spriteBatch.Draw(mod.GetTexture("Dusts/PixelEffect" + (i % 4 + 1).ToString()), new Vector2(Main.dust[i].position.X, Main.dust[i].position.Y) - Main.screenPosition, null, new Color(0.4f, 0.4f, 0.4f, 0), 0f, Utils.Size(mod.GetTexture("Dusts/PixelEffect" + (i % 4 + 1).ToString())) / 2f, Main.dust[i].scale / 5f, SpriteEffects.None, 0f);
                }
            }
            base.Draw(spriteBatch);
        }
    }
}
