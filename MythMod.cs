using Terraria.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;
using Terraria.Graphics.Effects;
using Terraria.UI;
using Terraria;
using MythMod.Dusts;
using MythMod.Effects;
using MythMod.NPCs.LanternMoon;
using MythMod.UI.YinYangLife;
using MythMod.UI.Stones;
using MythMod.UI.smartPhone;
using MythMod.UI.Starfish;
using MythMod.Projectiles;
using On.Terraria;
using MythMod.UI.Lifebutton;
using MythMod.UI.SpringAct;
using MythMod.UI.OceanWorld;
using MythMod.NPCs.Yasitaya;
using MythMod.Backgrounds;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Linq;
using ReLogic.Graphics;
using On.Terraria.GameContent.UI.Elements;
using Terraria.GameContent.UI.Elements;
using System.Reflection;
using UICharacter = Terraria.GameContent.UI.Elements.UICharacter;
using Utils = Terraria.Utils;


namespace MythMod
{
    public class MythMod : Mod
    {
        internal YinYangLife YinYangLife;
        internal Stones Stones;
        internal SpringAct SpringAct;
        internal smartPhone smartPhone;
        internal Starfish Starfish;
        internal CrystalEffect CrystalEffect;
        internal OceanWorld OceanWorld;
        internal Lifebutton Lifebutton;
        private UserInterface LifebuttonUserInterface;
        private UserInterface smartPhoneUserInterface;
        private UserInterface SpringActUserInterface;
        private UserInterface YinYangLifeUserInterface;
        private UserInterface StonesUserInterface;
        private UserInterface StarfishUserInterface;
        private UserInterface CrystalEffectUserInterface;
        public static TrailManager TrailManager;
        public static Effect Wave;
        private UserInterface OceanWorldUserInterface;
        //public static DynamicSpriteFont Font;
        public static MythMod Instance { get; set; }
        public static Effect npcEffect;
        public static Effect npcEffect2;
        public MythMod()
        {
            Instance = this;
        }
        public static Effect DefaultEffect;
        public static Effect DefaultEffect2;
        public static Effect DefaultEffectB;
        public static Effect DefaultEffectB2;
        public static Effect DefaultEffectWave;
        public static Effect DefaultEffectDarkRedGold;
        public static Effect DefaultEffectDarkRedGold2;
        public static Effect DefaultEffectY;
        public static Effect DefaultEffectAll;
        public static Effect DefaultEffectG;
        public static Texture2D MainColorBlue;
        public static Texture2D MainColorBlueD;
        public static Texture2D MainColorGarnet;
        public static Texture2D MainColorGreen;
        public static Texture2D MainColorPurple;
        public static Texture2D MainColorColdPurple;
        public static Texture2D MainColorWhite;
        public static Texture2D MainColorRed;
        public static Texture2D MainColorDarkRedGold;
        public static Texture2D MainColorDarkRedGold2;
        public static Texture2D MainColorYellow;
        public static Texture2D MainColorGoldYellow;
        public static Texture2D MainShape;
        public static Texture2D MaskColor;
        public static Texture2D MaskColor2;
        public static Texture2D MaskColor3;
        public static Texture2D MaskColor4;
        public static Texture2D MaskColor5;
        public static Texture2D MaskColor7;
        public override void PostUpdateInput()/* tModPorter Note: Removed. Use ModSystem.PostUpdateInput */
        {
            if (!Filters.Scene["MythMod:ShockWave"].IsActive())
            {
                // 开启滤镜
                if (GiantSword.OpenEffw)
                {
                    Filters.Scene.Activate("MythMod:ShockWave");
                    GiantSword.OpenEffw = false;
                }
            }
            else
            {
                if (GiantSword.Range > 2)
                {
                    Filters.Scene.Deactivate("MythMod:ShockWave");
                }
                if (!Terraria.Main.gamePaused)
                {
                    GiantSword.Range += GiantSword.RangeAdd;
                    GiantSword.RangeAdd *= 0.99f;
                }
                Wave.Parameters["pos"].SetValue(new Vector2(WavePoint.WavCent.X / (float)Terraria.Main.screenWidth, WavePoint.WavCent.Y / (float)Terraria.Main.screenHeight));
                Wave.Parameters["uTime"].SetValue((float)Terraria.Main.time);
                Wave.Parameters["uWaveR"].SetValue(GiantSword.Range);
            }
        }
        public override void PostSetupContent()
        {
            //WeakReferenceSupport.Setup();
            Wave = GetEffect("Effects/ShockWave");
            DefaultEffect = GetEffect("Effects/Trail");
            DefaultEffect2 = GetEffect("Effects/Trail2");
            DefaultEffectB = GetEffect("Effects/TrailB");
            DefaultEffectY = GetEffect("Effects/TrailY");
            DefaultEffectB2 = GetEffect("Effects/TrailB2");
            DefaultEffectWave = GetEffect("Effects/Wave");
            DefaultEffectDarkRedGold = GetEffect("Effects/TrailDarkRedGold");
            DefaultEffectDarkRedGold2 = GetEffect("Effects/TrailDarkRedGold2");
            DefaultEffectAll = GetEffect("Effects/TrailAll");
            DefaultEffectG = GetEffect("Effects/TrailG");
            MainColorBlue = GetTexture("UIImages/heatmapBlue");
            MainColorBlueD = GetTexture("UIImages/heatmapBlueD");
            MainColorGarnet = GetTexture("UIImages/heatmapGarnet");
            MainColorGreen = GetTexture("UIImages/heatmapGreen");
            MainColorPurple = GetTexture("UIImages/heatmapPurple");
            MainColorColdPurple = GetTexture("UIImages/heatmapColdPurple");
            MainColorWhite = GetTexture("UIImages/heatmapWhite");
            MainColorRed = GetTexture("UIImages/heatmapRed");
            MainColorDarkRedGold = GetTexture("UIImages/heatmapDarkRedGold");
            MainColorDarkRedGold2 = GetTexture("UIImages/heatmapDarkRedGold2");
            MainColorYellow = GetTexture("UIImages/heatmapYellow");
            MainColorGoldYellow = GetTexture("UIImages/heatmapGoldYellow");
            MainShape = GetTexture("UIImages/Lightline");
            MaskColor = GetTexture("UIImages/FogTrace");
            MaskColor2 = GetTexture("UIImages/SharpTrace");
            MaskColor3 = GetTexture("UIImages/SharpTraceL");
            MaskColor4 = GetTexture("UIImages/SharpTraceGold");
            MaskColor5 = GetTexture("UIImages/SharpTraceGoldL");
            MaskColor7 = GetTexture("UIImages/Lightline2");
            Mod mod = ModLoader.GetMod("MythMod");
            Mod BMod = ModLoader.GetMod("BossChecklist");
            if (BMod != null)
            {
                BMod.Call("AddBoss",
                    5.99f,
                    new List<int> { mod.Find<ModNPC>("EvilBotle").Type },
                    this,
                    "封魔石瓶",
                    (Func<bool>)(() => MythWorld.downedBottle),
                    new List<int> { mod.Find<ModItem>("EvilFragment").Type },//召唤物
                    new List<int> { mod.Find<ModItem>("GeometryEvil").Type },//稀有掉落
                    new List<int> { mod.Find<ModItem>("DarkStaff").Type, mod.Find<ModItem>("EvilBomb").Type, mod.Find<ModItem>("EvilRing").Type, mod.Find<ModItem>("EvilShadowBlade").Type, mod.Find<ModItem>("EvilSlingshot").Type, mod.Find<ModItem>("EvilSword").Type, mod.Find<ModItem>("ShadowYoyo").Type },//常规掉落
                    this,//9
                    "在大理石教堂废墟的碎片堆中使用[i:" + mod.Find<ModItem>("EvilFragment").Type.ToString() + "]召唤",
                    mod.GetTexture("NPCs/EvilBotle/EvilBotle"),
                    this);
                //BMod.Call("AddBoss",/*时期*/4.2f,/*Boss*/new List<int> { mod.NPCType("BloodTusk") }, this,/*名字*/"鲜血獠牙",/*是否击杀*/(Func<bool>)(() => MythWorld.downedXXLY),/*召唤物*/new List<int> { mod.ItemType("CursedJawbone") },/*稀有掉落*/new List<int> { mod.ItemType("SwordXXLY"), mod.ItemType("BrokenBone") },/*常规掉落*/new List<int> { mod.ItemType("BoneLiquid"), mod.ItemType("BrokenTooth"), mod.ItemType("BoneKnife"), mod.ItemType("SpineGun"), mod.ItemType("TuskBow"), mod.ItemType("TuskStaff"), mod.ItemType("TuskLace") },/*召唤方法*/"在猩红之地使用[i:" + mod.ItemType("CursedJawbone").ToString() + "]召唤\n或在猩红之地自然生成", this,/*图像*/mod.GetTexture("NPCs/BloodTuskWhole"), this);
                BMod.Call("AddBoss",/*时期*/4.09f,/*Boss*/new List<int> { mod.Find<ModNPC>("BloodTusk").Type }, this,/*名字*/"鲜血獠牙",/*是否击杀*/(Func<bool>)(() => MythWorld.downedXXLY),/*召唤物*/new List<int> { mod.Find<ModItem>("CursedJawbone").Type },/*稀有掉落*/new List<int> { mod.Find<ModItem>("SwordXXLY").Type , mod.Find<ModItem>("BloodyTuskPlatfo").Type },/*常规掉落*/new List<int> { mod.Find<ModItem>("BoneLiquid").Type, mod.Find<ModItem>("BrokenBone").Type, mod.Find<ModItem>("BoneKnife").Type, mod.Find<ModItem>("BrokenTooth").Type, mod.Find<ModItem>("SpineGun").Type, mod.Find<ModItem>("TuskBow").Type, mod.Find<ModItem>("TuskStaff").Type, mod.Find<ModItem>("TuskLace").Type },/*召唤方法*/"在猩红之地使用[i:" + mod.Find<ModItem>("CursedJawbone").Type.ToString() + "]召唤\n或在猩红之地自然生成", this,/*图像*/mod.GetTexture("NPCs/BloodTusk"), this);
                BMod.Call("AddBoss",/*时期*/4.08f,/*Boss*/new List<int> { mod.Find<ModNPC>("CorruptMoth").Type }, this,/*名字*/"腐檀巨蛾",/*是否击杀*/(Func<bool>)(() => MythWorld.downedFTJE),/*召唤物*/new List<int> { mod.Find<ModItem>("EvilCocoon").Type },/*稀有掉落*/new List<int> { mod.Find<ModItem>("SwordFTJE").Type , mod.Find<ModItem>("CorruptMothPlatform").Type },/*常规掉落*/new List<int> { mod.Find<ModItem>("BrokenWingOfMoth").Type, mod.Find<ModItem>("EvilScaleDust").Type, mod.Find<ModItem>("EvilChrysalis").Type, mod.Find<ModItem>("DustOfCorrupt").Type, mod.Find<ModItem>("PhosphorescenceGun").Type, mod.Find<ModItem>("ScaleWingBlade").Type, mod.Find<ModItem>("ShadowWingBow").Type, mod.Find<ModItem>("MothEye").Type },/*召唤方法*/"在腐化之地使用[i:" + mod.Find<ModItem>("EvilCocoon").Type.ToString() + "]召唤\n或在腐化之地打破自然生成的魔茧", this,/*图像*/mod.GetTexture("NPCs/CorruptMothBoss"), this);

                BMod.Call("AddBoss",/*时期*/9.05f,/*Boss*/new List<int> { mod.Find<ModNPC>("LanternGhostKing").Type }, this,/*名字*/"灯笼鬼王",/*是否击杀*/(Func<bool>)(() => MythWorld.downedDLGW),/*召唤物*/new List<int> { mod.Find<ModItem>("BloodLamp").Type },/*稀有掉落*/new List<int> {mod.Find<ModItem>("LanternKingPlatform").Type },/*常规掉落*/new List<int> { mod.Find<ModItem>("IlluminatedNight").Type, mod.Find<ModItem>("LampFire").Type, mod.Find<ModItem>("LanternYoyo").Type, mod.Find<ModItem>("RedLanternGun").Type, mod.Find<ModItem>("Wick").Type, mod.Find<ModItem>("LanternHairpin").Type },/*召唤方法*/"灯笼月第15波出现", this,/*图像*/mod.GetTexture("NPCs/LanternMoon/LanternGhostKing"), this);
                BMod.Call("AddBoss",/*时期*/15f,/*Boss*/new List<int> { mod.Find<ModNPC>("AncientTangerineTreeEye").Type }, this,/*名字*/"千年桔树妖",/*是否击杀*/(Func<bool>)(() => MythWorld.downedQNGSY),/*召唤物*/new List<int> { mod.Find<ModItem>("BloodLamp").Type },/*稀有掉落*/new List<int> {mod.Find<ModItem>("OrangeMonstorPlatform").Type },/*常规掉落*/new List<int> { mod.Find<ModItem>("OrangeBlade").Type, mod.Find<ModItem>("OrangeBow").Type, mod.Find<ModItem>("OrangeFurlBlade").Type, mod.Find<ModItem>("OrangeFurlBlade").Type, mod.Find<ModItem>("OrangeStaff").Type, mod.Find<ModItem>("OrangeSummonStaff").Type, mod.Find<ModItem>("OrangeBracelet").Type },/*召唤方法*/"灯笼月第25波出现", this,/*图像*/mod.GetTexture("NPCs/LanternMoon/AncientTangerineTreeBoss"), this);

                  BMod.Call("AddBoss",/*时期*/16.6f,/*Boss*/new List<int> { mod.Find<ModNPC>("CrystalSword").Type }, this,/*名字*/"冰洲石剑",/*是否击杀*/(Func<bool>)(() => MythWorld.downedBZSJ),/*召唤物*/new List<int> { mod.Find<ModItem>("CrystalScabbard").Type },/*稀有掉落*/new List<int> { mod.Find<ModItem>("CrystalSwordPlatfo").Type },/*常规掉落*/new List<int> { mod.Find<ModItem>("CrystalBall").Type, mod.Find<ModItem>("CrystalBlade").Type, mod.Find<ModItem>("CrystalBow").Type, mod.Find<ModItem>("CrystalEagle").Type, mod.Find<ModItem>("CrystalRose").Type, mod.Find<ModItem>("CrystalSwordStaff").Type, mod.Find<ModItem>("CrystalThrownKnife").Type},/*召唤方法*/"在水晶岛使用[i:" + mod.Find<ModItem>("CrystalScabbard").Type.ToString() + "]召唤", this,/*图像*/mod.GetTexture("NPCs/CrystalSword/CrystalSword"), this);

                BMod.Call("AddBoss",/*时期*/8.88f,/*Boss*/new List<int> { mod.Find<ModNPC>("OceanCrystal").Type }, this,/*名字*/"湛海魔晶",/*是否击杀*/(Func<bool>)(() => MythWorld.downedHYFY),/*召唤物*/new List<int> { mod.Find<ModItem>("SealTableOfOcean").Type, mod.Find<ModItem>("MysteriesPearl").Type },/*稀有掉落*/new List<int> {},/*常规掉落*/new List<int> { mod.Find<ModItem>("MysteriesPearl").Type, mod.Find<ModItem>("Aquamarine").Type, mod.Find<ModItem>("OceanCrystalClub").Type},/*召唤方法*/"在海洋封印台上按要求完成拼图,并放置[i:" + mod.Find<ModItem>("MysteriesPearl").Type.ToString() + "]", this,/*图像*/mod.GetTexture("NPCs/OceanCrystal/OceanCrystal"), this);

                  BMod.Call("AddBoss",/*时期*/0.14f,/*Boss*/new List<int> { mod.Find<ModNPC>("DirtSprite").Type }, this,/*名字*/"潜地恶鬼",/*是否击杀*/(Func<bool>)(() => MythWorld.downedQDEG),/*召唤物*/new List<int> { mod.Find<ModItem>("DirtSkeleton").Type },/*稀有掉落*/new List<int> { mod.Find<ModItem>("DirtspritePlatfo").Type },/*常规掉落*/new List<int> { mod.Find<ModItem>("GrassGun").Type, mod.Find<ModItem>("MossRay").Type, mod.Find<ModItem>("MountainStaff").Type, mod.Find<ModItem>("MudBlade").Type, mod.Find<ModItem>("RootStaff").Type, mod.Find<ModItem>("VineSlingshot").Type},/*召唤方法*/"用[i:" + mod.Find<ModItem>("DirtSkeleton").Type.ToString() + "]召唤", this,/*图像*/mod.GetTexture("NPCs/DirtSprite"), this);

                  BMod.Call("AddBoss",/*时期*/14.4f,/*Boss*/new List<int> { mod.Find<ModNPC>("StarJellyfish").Type}, this,/*名字*/"星渊水母",/*是否击杀*/(Func<bool>)(() => MythWorld.downedXYSM),/*召唤物*/new List<int> { mod.Find<ModItem>("GlowingShrimpJam").Type },/*稀有掉落*/new List<int> { mod.Find<ModItem>("StarJellyFishPlatf").Type, mod.Find<ModItem>("SwordXYSM").Type },/*常规掉落*/new List<int> { mod.Find<ModItem>("BloodyJellyfishStaff").Type, mod.Find<ModItem>("CarmineBlade").Type, mod.Find<ModItem>("GlowingJellyStaff").Type, mod.Find<ModItem>("LightOfFrozenSea").Type, mod.Find<ModItem>("RedGlassSpear").Type, mod.Find<ModItem>("TentacleBow").Type},/*召唤方法*/"把[i:" + mod.Find<ModItem>("GlowingShrimpJam").Type.ToString() + "]投入大海", this,/*图像*/mod.GetTexture("NPCs/StarJellyfish"), this);
                BMod.Call("AddBoss",/*时期*/12.7f,/*Boss*/new List<int> { mod.Find<ModNPC>("LavaStone").Type }, this,/*名字*/"熔岩巨石怪",/*是否击杀*/(Func<bool>)(() => MythWorld.downedVol),/*召唤物*/new List<int> { mod.Find<ModItem>("StoneEye").Type },/*稀有掉落*/new List<int> {},/*常规掉落*/new List<int> {},/*召唤方法*/"用[i:" + mod.Find<ModItem>("StoneEye").Type.ToString() + "]在火山洞穴召唤", this,/*图像*/mod.GetTexture("NPCs/VolCano/LavaStone"), this);
            }
            /*Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                // 14 is moolord, 12 is duke fishron
                bossChecklist.Call("AddBossWithInfo", "灯笼鬼王", 10.8f, (Func<bool>)(() => MythWorld.downedDLGW), "Use a [i:" + ItemType("BloodLamp") + "] in the Desert biome at any time");
            }*/
            base.PostSetupContent();
        }
        
        public void drawVitricBackground(On.Terraria.Main.orig_DrawBackgroundBlackFill orig, Terraria.Main self)
        {
            orig(self);
            Terraria.Player player = Terraria.Main.LocalPlayer;
            MythPlayer mplayer = Terraria.Main.player[Terraria.Main.myPlayer].GetModPlayer<MythPlayer>();
            Mod mod = ModLoader.GetMod("MythMod");

            if (mplayer.ZoneOcean)
            {
                Vector2 basepoint = Vector2.Zero;
                for (int k = 4; k >= 0; k--)
                {
                    drawLayer(basepoint, mod.GetTexture("Backgrounds/Coral" + k), k + 1);
                }

                for (int k = (int)(player.position.X - basepoint.X) - (int)(Terraria.Main.screenWidth * 1.5f); k <= (int)(player.position.X - basepoint.X) + (int)(Terraria.Main.screenWidth * 1.5f); k += 30)
                {
                }

                for (int i = -2 + (int)(player.position.X - Terraria.Main.screenWidth / 2) / 16; i <= 2 + (int)(player.position.X + Terraria.Main.screenWidth / 2) / 16; i++)
                {
                    for (int j = -2 + (int)(player.position.Y - Terraria.Main.screenHeight) / 16; j <= 2 + (int)(player.position.Y + Terraria.Main.screenHeight) / 16; j++)
                    {
                        if (Terraria.Lighting.Brightness(i, j) == 0 || ((Terraria.Main.tile[i, j].HasTile && Terraria.Main.tile[i, j].collisionType == 1) || Terraria.Main.tile[i, j].WallType != 0))
                        {
                            Color color = Color.Black * (1 - Terraria.Lighting.Brightness(i, j) * 2);
                            Terraria.Main.spriteBatch.Draw(Terraria.Main.BlackTile.Value, new Vector2(i * 16, j * 16) - Terraria.Main.screenPosition, color);
                        }
                        else if (i % 4 == 0 && j % 4 == 0 && Terraria.Main.tile[i, j].WallType == 0)
                        {
                            Terraria.Lighting.AddLight(new Vector2(i * 16, j * 16), new Vector3(0.3f, 0.35f, 0.4f) * 2.1f);
                        }
                    }
                }
            }
        }

        public void drawLayer(Vector2 basepoint, Texture2D texture, int parallax)
        {
            for (int k = 0; k <= 4; k++)
            {
                Mod mod = ModLoader.GetMod("MythMod");
                Terraria.Main.spriteBatch.Draw(texture,
                    new Vector2(basepoint.X + (k * 384 * 4) + getParallaxOffset(basepoint.X, parallax * 0.1f) - (int)Terraria.Main.screenPosition.X, basepoint.Y - (int)Terraria.Main.screenPosition.Y),
                    new Rectangle(0, 0, 1536, 900), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0);
            }
        }

        public int getParallaxOffset(float startpoint, float factor)
        {
            return (int)((Terraria.Main.LocalPlayer.position.X - startpoint) * factor);
        }
        private void LoadClient()
        {
            Filters.Scene["MythMod:LanternMoon"] = new Filter(new LanternMoonScreenShaderData("FilterMiniTower").UseColor(0.4f, 0.1f, 1f).UseOpacity(0.5f), (Terraria.Graphics.Effects.EffectPriority)4);
            SkyManager.Instance["MythMod:LanternMoon"] = new LanternMoonSky();
            Mod mod = ModLoader.GetMod("MythMod");
        }
        public override void UpdateMusic(ref int music, ref SceneEffectPriority priority)/* tModPorter Note: Removed. Use ModSceneEffect.Music and .Priority, aswell as ModSceneEffect.IsSceneEffectActive */
        {
            Mod mod = ModLoader.GetMod("MythMod");
            if (Terraria.Main.musicVolume != 0f && Terraria.Main.myPlayer != -1 && !Terraria.Main.gameMenu && Terraria.Main.LocalPlayer.active && Terraria.NPC.CountNPCS(mod.Find<ModNPC>("StarJellyfish").Type) <= 0 && Terraria.NPC.CountNPCS(mod.Find<ModNPC>("LanternGhostKing").Type) <= 0 && Terraria.NPC.CountNPCS(mod.Find<ModNPC>("AncientTangerineTreeEye").Type) <= 0)
            {
                if (Terraria.Main.LocalPlayer.GetModPlayer<MythPlayer>().ZoneOcean && !Terraria.Main.LocalPlayer.GetModPlayer<MythPlayer>().ZoneDeepocean)
                {
                    music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/CurtisSchweitzer-Haiku");
                    priority = SceneEffectPriority.BossHigh;
                }
                if (Terraria.Main.LocalPlayer.GetModPlayer<MythPlayer>().ZoneDeepocean && !Terraria.Main.LocalPlayer.GetModPlayer<MythPlayer>().ZoneVolcano)
                {
                    music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/CurtisSchweitzer-OceanExploration2");
                    priority = SceneEffectPriority.BossHigh;
                }
                if (Terraria.Main.LocalPlayer.GetModPlayer<MythPlayer>().ZoneVolcano)
                {
                    music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/CurtisSchweitzer-ArcticBattle1");
                    priority = SceneEffectPriority.BossHigh;
                }
                if (Terraria.Main.LocalPlayer.GetModPlayer<MythPlayer>().LanternMoon && Terraria.Main.LocalPlayer.GetModPlayer<MythPlayer>().LanternMoonWave <= 15 && !LanternGhostKing.Canai)
                {
                    music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Foxtail-Grass Studio - メグリネ");
                    priority = SceneEffectPriority.BossHigh;
                }
                if (Terraria.Main.LocalPlayer.GetModPlayer<MythPlayer>().LanternMoon && Terraria.Main.LocalPlayer.GetModPlayer<MythPlayer>().LanternMoonWave > 15 && Terraria.Main.LocalPlayer.GetModPlayer<MythPlayer>().LanternMoonWave <=25)
                {
                    music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Foxtail-Grass Studio - 不思議のとびらを覗いたら");
                    priority = SceneEffectPriority.BossHigh;
                }
            }
        }
        public static short SetStaticDefaultsGlowMask(ModItem modItem)
        {
            Mod mod = ModLoader.GetMod("MythMod");
            if (!Terraria.Main.dedServ)
            {
                Texture2D[] glowMasks = new Texture2D[Terraria.Main.GlowMask.Value.Length + 1];
                for (int i = 0; i < Terraria.Main.GlowMask.Value.Length; i++)
                {
                    glowMasks[i] = Terraria.Main.GlowMask[i].Value;
                }
                glowMasks[glowMasks.Length - 1] = mod.GetTexture("Glows/" + modItem.GetType().Name + "_Glow");
                Terraria.Main.GlowMask.Value = glowMasks;
                return (short)(glowMasks.Length - 1);
            }
            else return 0;
        }
        private void Main_DrawProjectiles(On.Terraria.Main.orig_DrawProjectiles orig, Terraria.Main self)
        {
            TrailManager.DrawTrails(Terraria.Main.spriteBatch);
            orig(self);
        }
        private int Projectile_NewProjectile(On.Terraria.Projectile.orig_NewProjectile_float_float_float_float_int_int_float_int_float_float orig, float X, float Y, float SpeedX, float SpeedY, int Type, int Damage, float KnockBack, int Owner, float ai0, float ai1)
        {
            int index = orig(X, Y, SpeedX, SpeedY, Type, Damage, KnockBack, Owner, ai0, ai1);
            Terraria.Projectile projectile = Terraria.Main.projectile[index];

            TrailManager.DoTrailCreation(projectile);

            return index;
        }
        public override void Unload()
        {
            TrailManager = null;
        }
        public override void Load()
        {
            //Font = GetFont("方正喵呜体");
            // 注意设置正确的Pass名字，Scene的名字可以随便填，不和别的Mod以及原版冲突即可
            Filters.Scene["MythMod:ShockWave"] = new Filter(new ScreenShaderData(new Ref<Effect>(GetEffect("Effects/ShockWave")), "Test"), EffectPriority.Medium);
            Filters.Scene["MythMod:ShockWave"].Load();
            Mod mod = ModLoader.GetMod("MythMod");
            Filters.Scene["MythMod:GBlur"] = new Filter(new MythGlobalEffects(new Ref<Effect>(GetEffect("Effects/Wave")), "Test"), EffectPriority.Medium);
            Filters.Scene["MythMod:GBlur"].Load();
            ModTranslation modTranslation = LocalizationLoader.CreateTranslation(base, "Myth.on");
            modTranslation.AddTranslation(GameCulture.Chinese, "你躯体和周围空气的界线开始模糊，空间已经难以承受你释放的怒火");
            modTranslation.SetDefault("!");
            LocalizationLoader.AddTranslation(modTranslation);
            modTranslation = LocalizationLoader.CreateTranslation(this, "Myth.on1");
            modTranslation.AddTranslation(GameCulture.Chinese, "直面毁灭……");
            modTranslation.SetDefault("!");
            LocalizationLoader.AddTranslation(modTranslation);
            ModTranslation text = LocalizationLoader.CreateTranslation(this, "LivesLeft");
			text = LocalizationLoader.CreateTranslation(this, "双子魔眼已被打败!");
			text.SetDefault("双子魔眼已被打败!");
			LocalizationLoader.AddTranslation(text);

            HookBackGround.Load();

            TrailManager = new TrailManager(this);

            On.Terraria.Main.DrawProjectiles += Main_DrawProjectiles;
            On.Terraria.Projectile.NewProjectile_float_float_float_float_int_int_float_int_float_float += Projectile_NewProjectile;
            YinYangLife = new YinYangLife();
            YinYangLife.Activate();
            YinYangLifeUserInterface = new UserInterface();
            YinYangLifeUserInterface.SetState(YinYangLife);
            Stones = new Stones();
            Stones.Activate();
            StonesUserInterface = new UserInterface();
            StonesUserInterface.SetState(Stones);
            CrystalEffect = new CrystalEffect();
            CrystalEffect.Activate();
            CrystalEffectUserInterface = new UserInterface();
            CrystalEffectUserInterface.SetState(CrystalEffect);
            Starfish = new Starfish();
            Starfish.Activate();
            StarfishUserInterface = new UserInterface();
            StarfishUserInterface.SetState(Starfish);
            Lifebutton = new Lifebutton();
            Lifebutton.Activate();
            LifebuttonUserInterface = new UserInterface();
            LifebuttonUserInterface.SetState(Lifebutton);
            SpringAct = new SpringAct();
            SpringAct.Activate();
            SpringActUserInterface = new UserInterface();
            SpringActUserInterface.SetState(SpringAct);
            smartPhone = new smartPhone();
            smartPhone.Activate();
            smartPhoneUserInterface = new UserInterface();
            smartPhoneUserInterface.SetState(smartPhone);
            OceanWorld = new OceanWorld();
            OceanWorld.Activate();
            OceanWorldUserInterface = new UserInterface();
            OceanWorldUserInterface.SetState(OceanWorld);
            //if(Terraria.Main.LocalPlayer.HeldItem.type == 4)
            //{
            //Item item = new Item();
            //item.damage = 777;
            //Terraria.Main.itemTexture[item.type] = mod.GetTexture("BlackItems/星璇柱");
            //mod.AddItem(mod.Name ,item.modItem);
            //}
            npcEffect = GetEffect("Effects/Grey");
            npcEffect2 = GetEffect("Effects/Wave");
            Filters.Scene["MythMod:Grey"] = new Filter(new TestScreenShaderData(new Ref<Effect>(GetEffect("Effects/Grey")), "Test"), EffectPriority.Medium);
            Filters.Scene["MythMod:Grey"].Load();
            Instance = this;
            pixelShader = null;

            /*List<Texture2D> Icon = new List<Texture2D>();
            List<Texture2D> Panel = new List<Texture2D>();
            int Id = 10;
            int Pd = 10;
            Icon.Add(Instance.GetTexture(""));
            Icon.Add(Instance.GetTexture(""));
            Panel.Add(Instance.GetTexture(""));
            Panel.Add(Instance.GetTexture(""));
            if (mod != null)
            {
                mod.Call("Icon",Instance.GetTexture("icon"),Icon,Id);
                mod.Call("Panel", Instance.GetTexture("panel"), Icon, Id);
                mod.Call("PanelAndIcon", Instance.GetTexture("icon"), Icon, Id);
            }
            */

        }
        public MiscShaderData finalFractal;

        public Effect pixelShader;

        public static Color GetNPCColor(Terraria.NPC npc, Vector2? position = null, bool effects = true, float shadowOverride = 0f)
        {
            return npc.GetAlpha(MythMod.BuffEffects(npc, MythMod.GetLightColor((position != null) ? position.Value : npc.Center), (shadowOverride != 0f) ? shadowOverride : 0f, effects, npc.poisoned, npc.onFire, npc.onFire2, Terraria.Main.player[Terraria.Main.myPlayer].detectCreature, false, false, false, npc.venom, npc.midas, npc.ichor, npc.onFrostBurn, false, false, npc.dripping, npc.drippingSlime, npc.loveStruck, npc.stinky));
        }
        public static Color GetLightColor(Vector2 position)
        {
            return Terraria.Lighting.GetColor((int)(position.X / 16f), (int)(position.Y / 16f));
        }
        public static Color BuffEffects(Terraria.Entity codable, Color lightColor, float shadow = 0f, bool effects = true, bool poisoned = false, bool onFire = false, bool onFire2 = false, bool hunter = false, bool noItems = false, bool blind = false, bool bleed = false, bool venom = false, bool midas = false, bool ichor = false, bool onFrostBurn = false, bool burned = false, bool honey = false, bool dripping = false, bool drippingSlime = false, bool loveStruck = false, bool stinky = false)
        {
            float num = 1f;
            float num2 = 1f;
            float num3 = 1f;
            float num4 = 1f;
            if (effects && honey && Terraria.Main.rand.Next(30) == 0)
            {
                int num5 = Terraria.Dust.NewDust(codable.position, codable.width, codable.height, 152, 0f, 0f, 150, default(Color), 1f);
                Terraria.Main.dust[num5].velocity.Y = 0.3f;
                Terraria.Dust dust = Terraria.Main.dust[num5];
                dust.velocity.X = dust.velocity.X * 0.1f;
                Terraria.Main.dust[num5].scale += (float)Terraria.Main.rand.Next(3, 4) * 0.1f;
                Terraria.Main.dust[num5].alpha = 100;
                Terraria.Main.dust[num5].noGravity = true;
                Terraria.Main.dust[num5].velocity += codable.velocity * 0.1f;
                if (codable is Terraria.Player)
                {
                    Terraria.Main.playerDrawDust.Add(num5);
                }
            }
            if (poisoned)
            {
                if (effects && Terraria.Main.rand.Next(30) == 0)
                {
                    int num6 = Terraria.Dust.NewDust(codable.position, codable.width, codable.height, 46, 0f, 0f, 120, default(Color), 0.2f);
                    Terraria.Main.dust[num6].noGravity = true;
                    Terraria.Main.dust[num6].fadeIn = 1.9f;
                    if (codable is Terraria.Player)
                    {
                        Terraria.Main.playerDrawDust.Add(num6);
                    }
                }
                num *= 0.65f;
                num3 *= 0.75f;
            }
            if (venom)
            {
                if (effects && Terraria.Main.rand.Next(10) == 0)
                {
                    int num7 = Terraria.Dust.NewDust(codable.position, codable.width, codable.height, 171, 0f, 0f, 100, default(Color), 0.5f);
                    Terraria.Main.dust[num7].noGravity = true;
                    Terraria.Main.dust[num7].fadeIn = 1.5f;
                    if (codable is Terraria.Player)
                    {
                        Terraria.Main.playerDrawDust.Add(num7);
                    }
                }
                num2 *= 0.45f;
                num *= 0.75f;
            }
            if (midas)
            {
                num3 *= 0.3f;
                num *= 0.85f;
            }
            if (ichor)
            {
                if (codable is Terraria.NPC)
                {
                    lightColor = new Color(255, 255, 0, 255);
                }
                else
                {
                    num3 = 0f;
                }
            }
            if (burned)
            {
                if (effects)
                {
                    int num8 = Terraria.Dust.NewDust(new Vector2(codable.position.X - 2f, codable.position.Y - 2f), codable.width + 4, codable.height + 4, 6, codable.velocity.X * 0.4f, codable.velocity.Y * 0.4f, 100, default(Color), 2f);
                    Terraria.Main.dust[num8].noGravity = true;
                    Terraria.Main.dust[num8].velocity *= 1.8f;
                    Terraria.Dust dust2 = Terraria.Main.dust[num8];
                    dust2.velocity.Y = dust2.velocity.Y - 0.75f;
                    if (codable is Terraria.Player)
                    {
                        Terraria.Main.playerDrawDust.Add(num8);
                    }
                }
                if (codable is Terraria.Player)
                {
                    num = 1f;
                    num3 *= 0.6f;
                    num2 *= 0.7f;
                }
            }
            if (onFrostBurn)
            {
                if (effects)
                {
                    if (Terraria.Main.rand.Next(4) < 3)
                    {
                        int num9 = Terraria.Dust.NewDust(new Vector2(codable.position.X - 2f, codable.position.Y - 2f), codable.width + 4, codable.height + 4, 135, codable.velocity.X * 0.4f, codable.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                        Terraria.Main.dust[num9].noGravity = true;
                        Terraria.Main.dust[num9].velocity *= 1.8f;
                        Terraria.Dust dust3 = Terraria.Main.dust[num9];
                        dust3.velocity.Y = dust3.velocity.Y - 0.5f;
                        if (Terraria.Main.rand.Next(4) == 0)
                        {
                            Terraria.Main.dust[num9].noGravity = false;
                            Terraria.Main.dust[num9].scale *= 0.5f;
                        }
                        if (codable is Terraria.Player)
                        {
                            Terraria.Main.playerDrawDust.Add(num9);
                        }
                    }
                    Terraria.Lighting.AddLight((int)(codable.position.X / 16f), (int)(codable.position.Y / 16f + 1f), 0.1f, 0.6f, 1f);
                }
                if (codable is Terraria.Player)
                {
                    num *= 0.5f;
                    num2 *= 0.7f;
                }
            }
            if (onFire)
            {
                if (effects)
                {
                    if (Terraria.Main.rand.Next(4) != 0)
                    {
                        int num10 = Terraria.Dust.NewDust(codable.position - new Vector2(2f, 2f), codable.width + 4, codable.height + 4, 6, codable.velocity.X * 0.4f, codable.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                        Terraria.Main.dust[num10].noGravity = true;
                        Terraria.Main.dust[num10].velocity *= 1.8f;
                        Terraria.Dust dust4 = Terraria.Main.dust[num10];
                        dust4.velocity.Y = dust4.velocity.Y - 0.5f;
                        if (Terraria.Main.rand.Next(4) == 0)
                        {
                            Terraria.Main.dust[num10].noGravity = false;
                            Terraria.Main.dust[num10].scale *= 0.5f;
                        }
                        if (codable is Terraria.Player)
                        {
                            Terraria.Main.playerDrawDust.Add(num10);
                        }
                    }
                    Terraria.Lighting.AddLight((int)(codable.position.X / 16f), (int)(codable.position.Y / 16f + 1f), 1f, 0.3f, 0.1f);
                }
                if (codable is Terraria.Player)
                {
                    num3 *= 0.6f;
                    num2 *= 0.7f;
                }
            }
            if (dripping && shadow == 0f && Terraria.Main.rand.Next(4) != 0)
            {
                Vector2 position = codable.position;
                position.X -= 2f;
                position.Y -= 2f;
                if (Terraria.Main.rand.Next(2) == 0)
                {
                    int num11 = Terraria.Dust.NewDust(position, codable.width + 4, codable.height + 2, 211, 0f, 0f, 50, default(Color), 0.8f);
                    if (Terraria.Main.rand.Next(2) == 0)
                    {
                        Terraria.Main.dust[num11].alpha += 25;
                    }
                    if (Terraria.Main.rand.Next(2) == 0)
                    {
                        Terraria.Main.dust[num11].alpha += 25;
                    }
                    Terraria.Main.dust[num11].noLight = true;
                    Terraria.Main.dust[num11].velocity *= 0.2f;
                    Terraria.Dust dust5 = Terraria.Main.dust[num11];
                    dust5.velocity.Y = dust5.velocity.Y + 0.2f;
                    Terraria.Main.dust[num11].velocity += codable.velocity;
                    if (codable is Terraria.Player)
                    {
                        Terraria.Main.playerDrawDust.Add(num11);
                    }
                }
                else
                {
                    int num12 = Terraria.Dust.NewDust(position, codable.width + 8, codable.height + 8, 211, 0f, 0f, 50, default(Color), 1.1f);
                    if (Terraria.Main.rand.Next(2) == 0)
                    {
                        Terraria.Main.dust[num12].alpha += 25;
                    }
                    if (Terraria.Main.rand.Next(2) == 0)
                    {
                        Terraria.Main.dust[num12].alpha += 25;
                    }
                    Terraria.Main.dust[num12].noLight = true;
                    Terraria.Main.dust[num12].noGravity = true;
                    Terraria.Main.dust[num12].velocity *= 0.2f;
                    Terraria.Dust dust6 = Terraria.Main.dust[num12];
                    dust6.velocity.Y = dust6.velocity.Y + 1f;
                    Terraria.Main.dust[num12].velocity += codable.velocity;
                    if (codable is Terraria.Player)
                    {
                        Terraria.Main.playerDrawDust.Add(num12);
                    }
                }
            }
            if (drippingSlime && shadow == 0f)
            {
                int num13 = 175;
                Color color = new Color(0, 80, 255, 100);
                if (Terraria.Main.rand.Next(4) != 0 && Terraria.Main.rand.Next(2) == 0)
                {
                    Vector2 position2 = codable.position;
                    position2.X -= 2f;
                    position2.Y -= 2f;
                    int num14 = Terraria.Dust.NewDust(position2, codable.width + 4, codable.height + 2, 4, 0f, 0f, num13, color, 1.4f);
                    if (Terraria.Main.rand.Next(2) == 0)
                    {
                        Terraria.Main.dust[num14].alpha += 25;
                    }
                    if (Terraria.Main.rand.Next(2) == 0)
                    {
                        Terraria.Main.dust[num14].alpha += 25;
                    }
                    Terraria.Main.dust[num14].noLight = true;
                    Terraria.Main.dust[num14].velocity *= 0.2f;
                    Terraria.Dust dust7 = Terraria.Main.dust[num14];
                    dust7.velocity.Y = dust7.velocity.Y + 0.2f;
                    Terraria.Main.dust[num14].velocity += codable.velocity;
                    if (codable is Terraria.Player)
                    {
                        Terraria.Main.playerDrawDust.Add(num14);
                    }
                }
                num *= 0.8f;
                num2 *= 0.8f;
            }
            if (onFire2)
            {
                if (effects)
                {
                    if (Terraria.Main.rand.Next(4) != 0)
                    {
                        int num15 = Terraria.Dust.NewDust(codable.position - new Vector2(2f, 2f), codable.width + 4, codable.height + 4, 75, codable.velocity.X * 0.4f, codable.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                        Terraria.Main.dust[num15].noGravity = true;
                        Terraria.Main.dust[num15].velocity *= 1.8f;
                        Terraria.Dust dust8 = Terraria.Main.dust[num15];
                        dust8.velocity.Y = dust8.velocity.Y - 0.5f;
                        if (Terraria.Main.rand.Next(4) == 0)
                        {
                            Terraria.Main.dust[num15].noGravity = false;
                            Terraria.Main.dust[num15].scale *= 0.5f;
                        }
                        if (codable is Terraria.Player)
                        {
                            Terraria.Main.playerDrawDust.Add(num15);
                        }
                    }
                    Terraria.Lighting.AddLight((int)(codable.position.X / 16f), (int)(codable.position.Y / 16f + 1f), 1f, 0.3f, 0.1f);
                }
                if (codable is Terraria.Player)
                {
                    num3 *= 0.6f;
                    num2 *= 0.7f;
                }
            }
            if (noItems)
            {
                num *= 0.65f;
                num2 *= 0.8f;
            }
            if (blind)
            {
                num *= 0.7f;
                num2 *= 0.65f;
            }
            if (bleed)
            {
                bool flag = (codable is Terraria.Player) ? ((Terraria.Player)codable).dead : (codable is Terraria.NPC && ((Terraria.NPC)codable).life <= 0);
                if (effects && !flag && Terraria.Main.rand.Next(30) == 0)
                {
                    int num16 = Terraria.Dust.NewDust(codable.position, codable.width, codable.height, 5, 0f, 0f, 0, default(Color), 1f);
                    Terraria.Dust dust9 = Terraria.Main.dust[num16];
                    dust9.velocity.Y = dust9.velocity.Y + 0.5f;
                    Terraria.Main.dust[num16].velocity *= 0.25f;
                    if (codable is Terraria.Player)
                    {
                        Terraria.Main.playerDrawDust.Add(num16);
                    }
                }
                num2 *= 0.9f;
                num3 *= 0.9f;
            }
            if (loveStruck && effects && shadow == 0f && Terraria.Main.instance.IsActive && !Terraria.Main.gamePaused && Terraria.Main.rand.Next(5) == 0)
            {
                Vector2 value = new Vector2((float)Terraria.Main.rand.Next(-10, 11), (float)Terraria.Main.rand.Next(-10, 11));
                value.Normalize();
                value.X *= 0.66f;
                int num17 = Terraria.Gore.NewGore(codable.position + new Vector2((float)Terraria.Main.rand.Next(codable.width + 1), (float)Terraria.Main.rand.Next(codable.height + 1)), value * (float)Terraria.Main.rand.Next(3, 6) * 0.33f, 331, (float)Terraria.Main.rand.Next(40, 121) * 0.01f);
                Terraria.Main.gore[num17].sticky = false;
                Terraria.Main.gore[num17].velocity *= 0.4f;
                Terraria.Gore gore = Terraria.Main.gore[num17];
                gore.velocity.Y = gore.velocity.Y - 0.6f;
                if (codable is Terraria.Player)
                {
                    Terraria.Main.playerDrawGore.Add(num17);
                }
            }
            if (stinky && shadow == 0f)
            {
                num *= 0.7f;
                num3 *= 0.55f;
                if (effects && Terraria.Main.rand.Next(5) == 0 && Terraria.Main.instance.IsActive && !Terraria.Main.gamePaused)
                {
                    Vector2 value2 = new Vector2((float)Terraria.Main.rand.Next(-10, 11), (float)Terraria.Main.rand.Next(-10, 11));
                    value2.Normalize();
                    value2.X *= 0.66f;
                    value2.Y = Math.Abs(value2.Y);
                    Vector2 vector = value2 * (float)Terraria.Main.rand.Next(3, 5) * 0.25f;
                    int num18 = Terraria.Dust.NewDust(codable.position, codable.width, codable.height, 188, vector.X, vector.Y * 0.5f, 100, default(Color), 1.5f);
                    Terraria.Main.dust[num18].velocity *= 0.1f;
                    Terraria.Dust dust10 = Terraria.Main.dust[num18];
                    dust10.velocity.Y = dust10.velocity.Y - 0.5f;
                    if (codable is Terraria.Player)
                    {
                        Terraria.Main.playerDrawDust.Add(num18);
                    }
                }
            }
            lightColor.R = (byte)((float)lightColor.R * num);
            lightColor.G = (byte)((float)lightColor.G * num2);
            lightColor.B = (byte)((float)lightColor.B * num3);
            lightColor.A = (byte)((float)lightColor.A * num4);
            if (codable is Terraria.NPC)
            {
                NPCLoader.DrawEffects((Terraria.NPC)codable, ref lightColor);
            }
            if (hunter && (!(codable is Terraria.NPC) || ((Terraria.NPC)codable).lifeMax > 1))
            {
                if (effects && !Terraria.Main.gamePaused && Terraria.Main.instance.IsActive && Terraria.Main.rand.Next(50) == 0)
                {
                    int num19 = Terraria.Dust.NewDust(codable.position, codable.width, codable.height, 15, 0f, 0f, 150, default(Color), 0.8f);
                    Terraria.Main.dust[num19].velocity *= 0.1f;
                    Terraria.Main.dust[num19].noLight = true;
                    if (codable is Terraria.Player)
                    {
                        Terraria.Main.playerDrawDust.Add(num19);
                    }
                }
                byte b = 50;
                byte b2 = byte.MaxValue;
                byte b3 = 50;
                if (codable is Terraria.NPC && !((Terraria.NPC)codable).friendly && ((Terraria.NPC)codable).catchItem <= 0 && (((Terraria.NPC)codable).damage != 0 || ((Terraria.NPC)codable).lifeMax != 5))
                {
                    b = byte.MaxValue;
                    b2 = 50;
                }
                if (!(codable is Terraria.NPC) && lightColor.R < 150)
                {
                    lightColor.A = Terraria.Main.mouseTextColor;
                }
                if (lightColor.R < b)
                {
                    lightColor.R = b;
                }
                if (lightColor.G < b2)
                {
                    lightColor.G = b2;
                }
                if (lightColor.B < b3)
                {
                    lightColor.B = b3;
                }
            }
            return lightColor;
        }
        public override void UpdateUI(GameTime gameTime)/* tModPorter Note: Removed. Use ModSystem.UpdateUI */
        {
            TrailManager.UpdateTrails();
            if (YinYangLifeUserInterface != null && YinYangLife.Open)
                YinYangLifeUserInterface.Update(gameTime);
            if (StonesUserInterface != null && Stones.Open)
                StonesUserInterface.Update(gameTime);
            if (CrystalEffectUserInterface != null && CrystalEffect.Open)
                CrystalEffectUserInterface.Update(gameTime);
            if (StarfishUserInterface != null && Starfish.Open)
                StarfishUserInterface.Update(gameTime);
            if (LifebuttonUserInterface != null && Lifebutton.Open)
                LifebuttonUserInterface.Update(gameTime);
            if (SpringActUserInterface != null && SpringAct.Open)
                SpringActUserInterface.Update(gameTime);
            if (smartPhoneUserInterface != null && smartPhone.Open)
                smartPhoneUserInterface.Update(gameTime);
            if (OceanWorldUserInterface != null && OceanWorld.Open)
                OceanWorldUserInterface.Update(gameTime);
            base.UpdateUI(gameTime);
        }
        public static void DrawTexture(object sb, Texture2D texture, int shader, Terraria.Entity codable, Color? overrideColor = null, bool drawCentered = false)
        {
            Color value = (overrideColor != null) ? overrideColor.Value : ((codable is Terraria.NPC) ? MythMod.GetNPCColor((Terraria.NPC)codable, new Vector2?(codable.Center), false, 0f) : ((codable is Terraria.Projectile) ? ((Terraria.Projectile)codable).GetAlpha(MythMod.GetLightColor(codable.Center)) : MythMod.GetLightColor(codable.Center)));
            int framecount = (codable is Terraria.NPC) ? Terraria.Main.npcFrameCount[((Terraria.NPC)codable).type] : 1;
            Rectangle frame = (codable is Terraria.NPC) ? ((Terraria.NPC)codable).frame : new Rectangle(0, 0, texture.Width, texture.Height);
            float scale = (codable is Terraria.NPC) ? ((Terraria.NPC)codable).scale : ((Terraria.Projectile)codable).scale;
            float rotation = (codable is Terraria.NPC) ? ((Terraria.NPC)codable).rotation : ((Terraria.Projectile)codable).rotation;
            int direction = (codable is Terraria.NPC) ? ((Terraria.NPC)codable).spriteDirection : ((Terraria.Projectile)codable).spriteDirection;
            float y = (codable is Terraria.NPC) ? ((Terraria.NPC)codable).gfxOffY : 0f;
            MythMod.DrawTexture(sb, texture, shader, codable.position + new Vector2(0f, y), codable.width, codable.height, scale, rotation, direction, framecount, frame, new Color?(value), drawCentered);
        }
        public static Vector2 GetDrawPosition(Vector2 position, Vector2 origin, int width, int height, int texWidth, int texHeight, int framecount, float scale, bool drawCentered = false)
        {
            Vector2 value = new Vector2((float)((int)Terraria.Main.screenPosition.X), (float)((int)Terraria.Main.screenPosition.Y));
            if (drawCentered)
            {
                Vector2 value2 = new Vector2((float)(texWidth / 2), (float)(texHeight / framecount / 2));
                return position + new Vector2((float)width * 0.5f, (float)height * 0.5f) - value2 * scale + origin * scale - value;
            }
            return position - value + new Vector2((float)width * 0.5f, (float)height) - new Vector2((float)texWidth * scale / 2f, (float)texHeight * scale / (float)framecount) + origin * scale + new Vector2(0f, 5f);
        }
        public static void DrawTexture(object sb, Texture2D texture, int shader, Vector2 position, int width, int height, float scale, float rotation, int direction, int framecount, Rectangle frame, Color? overrideColor = null, bool drawCentered = false)
        {
            Vector2 vector = new Vector2((float)(texture.Width / 2), (float)(texture.Height / framecount / 2));
            Color color = (overrideColor != null) ? overrideColor.Value : MythMod.GetLightColor(position + new Vector2((float)width * 0.5f, (float)height * 0.5f));
            if (sb is SpriteBatch)
            {
                bool flag = shader > 0;
                if (flag)
                {
                    ((SpriteBatch)sb).End();
                    ((SpriteBatch)sb).Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
                    GameShaders.Armor.ApplySecondary(shader, Terraria.Main.player[Terraria.Main.myPlayer], null);
                }
                ((SpriteBatch)sb).Draw(texture, MythMod.GetDrawPosition(position, vector, width, height, texture.Width, texture.Height, framecount, scale, drawCentered), new Rectangle?(frame), color, rotation, vector, scale, (direction == 1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
                if (flag)
                {
                    ((SpriteBatch)sb).End();
                    ((SpriteBatch)sb).Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
                }
            }
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)/* tModPorter Note: Removed. Use ModSystem.ModifyInterfaceLayers */
        {
            int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndex != -1)
            {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "神话模组: 阴阳寿命",
                    delegate
                    {
                        if (YinYangLife.Open)
                        {
                            YinYangLife.Draw(Terraria.Main.spriteBatch);
                        }
                        if (Stones.Open)
                        {
                            Stones.Draw(Terraria.Main.spriteBatch);
                        }
                        if (CrystalEffect.Open)
                        {
                            CrystalEffect.Draw(Terraria.Main.spriteBatch);
                        }
                        if (Starfish.Open)
                        {
                            Starfish.Draw(Terraria.Main.spriteBatch);
                        }
                        if (OceanWorld.Open)
                        {
                            OceanWorld.Draw(Terraria.Main.spriteBatch);
                        }
                        if (Lifebutton.Open)
                        {
                            Lifebutton.Draw(Terraria.Main.spriteBatch);
                        }
                        if (SpringAct.Open)
                        {
                            SpringAct.Draw(Terraria.Main.spriteBatch);
                        }
                        if (smartPhone.Open)
                        {
                            smartPhone.Draw(Terraria.Main.spriteBatch);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
            base.ModifyInterfaceLayers(layers);
        }
    }
    public class TestScreenShaderData : ScreenShaderData
    {
        public TestScreenShaderData(string passName) : base(passName)
        {
        }
        public TestScreenShaderData(Ref<Effect> shader, string passName) : base(shader, passName)
        {
        }
        public override void Apply()
        {
            base.Apply();
        }
    }
}
