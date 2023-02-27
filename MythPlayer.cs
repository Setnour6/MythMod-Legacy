using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using MythMod.UI.YinYangLife;
using MythMod.UI.Stones;
using MythMod.UI.Starfish;
using MythMod.UI.Lifebutton;
using MythMod.UI.SpringAct;
using MythMod.UI.OceanWorld;
using MythMod.Dusts;
using MythMod.NPCs;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using System;
using Microsoft.Xna.Framework;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Ionic.Zlib;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using Terraria.Chat;
using Terraria.GameContent.Events;
using Terraria.GameContent.NetModules;
using Terraria.GameContent.Tile_Entities;
using Terraria.IO;
using Terraria.Net;
using Terraria.Net.Sockets;
using Terraria.Social;


namespace MythMod
{
    public class MythPlayer : ModPlayer
    {
        private bool num1 = true;
        public bool UsingItem { get; set; }
        public Vector2 FlyCamPosition;
        public override void ModifyScreenPosition()
        {
            Main.screenPosition += FlyCamPosition;
            FlyCamPosition = Vector2.Zero;
        }
        //YinLife是阴寿命，YinLifeMax是阴寿命最大值，YangLife是阳寿命，YangLifeMax是阳寿命最大值

        public int Waveshader = 0;
        public bool CalmOn = false;
        public int YinLife = 30, YinLifeMax = 30, YangLife = 30, YangLifeMax = 30;
        public float YinBar = 0;
        public float YangBar = 0;
        public bool LanternMoon;
        public int LanternMoonPoint;
        public int Moon2;
        public int WindC = 0;
        public int CatastropheWheel = 0;
        public int KillCrystal = 0;
        public int LanternMoonWave;
        public int OldWavePoint;
        public int PerWavePoint;
        public int num2 = 0;
        public int m = 0;
        public int m2 = 0;
        public int m3 = 0;
        public int movieTime = 0;
        public int num11 = 0;
        public int num100 = 0;
        public int Zonefloor = 0;
        public int Maxfloor = 1;
        public int GoldTime = 0;
        public int GoldPoint = 0;
        public int GoldLevel = 1;
        public int Ele = 0;
        public int Cu = 0;
        public int Ag = 0;
        public int Au = 0;
        public int MagicCool = 0;
        public int C = 0;
        public int GreenBlood = 0;
        public int Cooling = 0;
        public int Elecoin = 0;
        public int CrysSwo = 0;
        public int TwinslocalAIMyth = 0;
        public int Shake = 0;

        public bool GreenHat = false;
        public bool LonelyJelly = false;
        public bool MagicalPlanit = false;
        public bool Magelite = false;
        public bool OceanCatch = false;
        public bool PurpleFreeze = false;
        public bool SouthAmMitNight = false;
        public bool TrafficLight = false;
        public bool BayBerryBubble = false;
        public bool B25 = false;
        public bool BloodyMarie = false;
        public bool BlueHawaii = false;
        public bool Boluolita = false;
        public bool BurningHell = false;
        public bool CubaLibre = false;
        public bool DaturaImpression = false;
        public bool DryMartini = false;
        public bool FirstLove = false;
        public bool GoldFeishi = false;
        public bool JinglingFeishi = false;
        public bool JinglingMojituo = false;
        public bool Lavender = false;
        public bool LotusNight = false;
        public bool Mexican = false;
        public bool MoonTonight = false;
        public bool NorthLandSpring = false;
        public bool OrangeD = false;
        public bool PinaColada = false;
        public bool PinkLady = false;
        public bool PurpleCrystal = false;
        public bool Screwdriver = false;
        public bool SeaFlower = false;
        public bool SexOnTheBeach = false;
        public bool SglyBeer = false;
        public bool SingaporeSling = false;
        public bool StrawberryMojituo = false;
        public bool SummerStarrySky = false;
        public bool SunsetGlow = false;
        public bool TequilaSunrise = false;
        public bool U8Grapefruit = false;
        public bool WithOutBerry = false;
        public bool YoghurtCaribbean = false;

        public bool DONTTAKEDAMDGE = false;
        public int Duke = 0;
        public int BeeFeather = 0;
        public int MoonHeart = 0;
        public int KiBo = 0;
        public int Slip = 0;
        public bool YinYangRe = false;
        public int Fea = 0;
        public bool Missable = false;
        public bool ZoneVolcano;
        public bool ZoneRedTree;
        public bool TransD = false;
        public bool TransU = false;
        public bool firstClick;
        public bool ZTMSY;
        public bool ZoneOcean;
        public bool ZoneTown;
        public bool ZoneDeepocean;
        public bool ZoneCoral;
        public bool Sto = false;
        public float Cloud = 0;
        public Vector2 v1;
        public bool clear = true;
        public string worldnm = "";
        public bool trans = false;
        public bool create = false;
        public int WorS = 0;
        public int ab = 0;
        public Vector2 liftPos = new Vector2(0, 0);
        public int bubble = 0;
        public int Su = 0;
        public int Su2 = 0;
        public int FoodExp = 0;
        public int FoodLevel = 1;
        public int[] FoodLecelUpNeed = new int[16];
        public bool[,] BanFood = new bool[16, 30];
        public int signal = 0;
        public int TotalCoin = 0;
        public float SignalStrength = 0;
        public override void Initialize()
        {
            FoodLecelUpNeed[0] = 0;
            FoodLecelUpNeed[1] = 10;
            FoodLecelUpNeed[2] = 30;
            FoodLecelUpNeed[3] = 60;
            FoodLecelUpNeed[4] = 120;
            FoodLecelUpNeed[5] = 200;
            FoodLecelUpNeed[6] = 300;
            FoodLecelUpNeed[7] = 480;
            FoodLecelUpNeed[8] = 700;
            FoodLecelUpNeed[9] = 1000;
            FoodLecelUpNeed[10] = 1500;
            FoodLecelUpNeed[11] = 2200;
            FoodLecelUpNeed[12] = 3000;
            FoodLecelUpNeed[13] = 4000;
            FoodLecelUpNeed[14] = 5000;
            FoodLecelUpNeed[15] = 6000;
            this.LavaCryst = 0;
            this.FinalLava = false;
            if (ModLoader.GetMod("CalamityMod") != null)
            {
                CalmOn = true;
            }
            else
            {
                CalmOn = false;
            }
        }
        public override void ResetEffects()
        {
            UsingItem = false;
            this.GXJL = false;
            this.NJFZ = false;
            this.IcyAnimal = false;
            this.StarDustLight = false;
            this.SXSXZ = false;
            this.LargeTurquoise = false;
            this.LargeAquamarine = false;
            this.LargeOlivine = false;
            this.ExPoi = false;
            this.StarPoi = false;
            this.StarPoi2 = false;
            this.StarPoi3 = false;
            this.LowDisorder = false;
            this.Starfishes = false;
        }
        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            //Texture2D texture = base.mod.GetTexture("UIImages/Life");
            //Main.heartTexture = texture;
            //Main.heart2Texture = base.mod.GetTexture("UIImages/Life2");
        }
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (YinYangLife.IMFlDmg > 5)
            {
                if (Player.statLifeMax2 <= 200)
                {
                    Player.statLife = 100;
                }
                else
                {
                    Player.statLife = Player.statLifeMax2 / 2;
                }
                return false;
            }
            if (Player.name == "万象元素")
            {
                Player.active = true;
                Player.dead = false;
                Player.statLife = Player.statLifeMax2;
                return false;
            }
            else
            {
                MagicCool = 0;
                return true;
            }
        }
        public int IMMUNE = 0;
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource, ref int cooldownCounter)
        {
            if (DONTTAKEDAMDGE)
            {
                return false;
            }
            else if (Main.rand.Next(0, 100) <= Misspossibility && IMMUNE == 0)
            {
                Projectile.NewProjectile((float)Player.Center.X, (float)Player.Center.Y, 0, 0, Mod.Find<ModProjectile>("Miss").Type, 0, 0, Player.whoAmI, 0f, 0f);
                IMMUNE += 30;
                return false;
            }
            if (IMMUNE > 0)
            {
                return false;
            }
            else if (GreenBlood > 2 && Main.rand.Next(100) <= (Player.wet ? 20 : 10))
            {
                if (!Main.player[Main.myPlayer].moonLeech)
                {
                    int num6 = damage;
                    Player.HealEffect(num6, false);
                    Player.statLife += num6;
                    if (Player.statLife > Player.statLifeMax2)
                    {
                        Player.statLife = Player.statLifeMax2;
                    }
                    NetMessage.SendData(66, -1, -1, null, 0, (float)num6, 0f, 0f, 0, 0, 0);
                }
                IMMUNE += 30;
                return false;
            }
            else
            {
                if (CatastropheWheel >= 1)
                {
                    int num6 = damage / 2;
                    Player.HealEffect(num6, false);
                    Player.statLife += num6;
                    if (Player.statLife > Player.statLifeMax2)
                    {
                        Player.statLife = Player.statLifeMax2;
                    }
                    NetMessage.SendData(66, -1, -1, null, 0, (float)num6, 0f, 0f, 0, 0, 0);
                    return true;
                }
                if (Main.dayTime)
                {
                    DayR = false;
                }
                if (!Main.dayTime)
                {
                    NightR = false;
                }
                if (ab > 0 && Player.wet)
                {
                    damage /= 2;
                }
                damage = (int)(damage * (100 - DisHurt) / 100f);
                if (FlameShield > 0 && FlameShieldCool == 0)
                {
                    int h = Projectile.NewProjectile(Player.Center, new Vector2(0, 0), 296, 50, 10, Main.myPlayer, 0, 0);
                    Main.projectile[h].friendly = true;
                    Main.projectile[h].hostile = false;
                    FlameShieldCool = 120;
                }
                return true;
            }
        }
        public int DisHurt = 0;
        public int SD = 0;
        public int SD2 = 0;
        public int AddDef = 0;
        public static void SendData(int msgType, int remoteClient = -1, int ignoreClient = -1, NetworkText text = null, int number = 0, float number2 = 0f, float number3 = 0f, float number4 = 0f, int number5 = 0, int number6 = 0, int number7 = 0)
        {
        }
        public bool wExpert = false;
        public bool wMyth = false;
        public bool FinalLava;
        public bool DayR = true;
        public bool Ost = true;
        public bool NightR = true;
        public float Crazyindex = 0;
        public int FireMHold = 0;
        public int IceMHold = 0;
        public int ArrowMHold = 0;
        public int BloodMHold = 0;
        public int CurseMHold = 0;
        public int WitcMHold = 0;
        public int ElectricMHold = 0;
        public int MeteorMHold = 0;
        public int ProjMHold = 0;
        public int LazaMHold = 0;
        public int ShadMHold = 0;
        public int CoinMHold = 0;
        public int FreLoopMHold = 0;
        public int BstarMHold = 0;
        public int FlowMHold = 0;
        public int PoisonHeart = 0;
        public int FreezingPoint = 0;
        public int ExpolodePoint = 0;
        public int LightingPoint = 0;
        public int PoisonPoint = 0;
        public int BloodPoint = 0;
        public int[] Feathers = new int[40];
        public Vector2[] LaserV = new Vector2[1000];
        public Vector2[] CurseV = new Vector2[1000];
        public override void PreUpdate()
        {
            if (KiBo > 0)
            {
                KiBo -= 1;
                Player.statDefense *= 0;
            }
            else
            {
                KiBo = 0;
            }
            if (Shake > 0)
            {
                Shake -= 1;
                FlyCamPosition = new Vector2(Main.rand.Next(-16, 16), Main.rand.Next(-16, 16));
                if(Shake == 1)
                {
                    FlyCamPosition = Vector2.Zero;
                }
            }
            else
            {
                Shake = 0;
            }
            if (NPC.CountNPCS(125) + NPC.CountNPCS(126) > 0)
            {
                TwinslocalAIMyth += 1;
                if(TwinslocalAIMyth > 2300)
                {
                    TwinslocalAIMyth = 0;
                }
            }
            else
            {
                TwinslocalAIMyth = 0;
            }
            if (Waveshader > 0)
            {
                Waveshader -= 1;
            }
            else
            {
                Waveshader = 0;
            }
            if (Slip > 0)
            {
                Slip -= 1;
            }
            else
            {
                Slip = 0;
            }
            if (MoonHeart > 0)
            {
                MoonHeart -= 1;
            }
            else
            {
                MoonHeart = 0;
            }
            if (Fea > 0)
            {
                Fea -= 1;
            }
            else
            {
                Fea = 0;
            }
            if (BeeFeather > 0)
            {
                BeeFeather -= 1;
            }
            else
            {
                BeeFeather = 0;
            }
            if (Duke > 0)
            {
                Duke -= 1;
            }
            else
            {
                Duke = 0;
            }
            /*if (!Filters.Scene["MythMod:Grey"].IsActive())
            {
                // 开启滤镜
                Filters.Scene.Activate("MythMod:Grey");
            }
            MythMod.npcEffect.Parameters["mouseX"].SetValue(Main.mouseX / (float)Main.screenWidth);
            MythMod.npcEffect.Parameters["mouseY"].SetValue(Main.mouseY / (float)Main.screenHeight);*/
            if (PoisonHeart > 0)
            {
                PoisonHeart -= 1;
            }
            else
            {
                PoisonHeart = 0;
            }
            if (FlowMHold > 0)
            {
                FlowMHold -= 1;
            }
            else
            {
                FlowMHold = 0;
            }
            if (BstarMHold > 0)
            {
                BstarMHold -= 1;
            }
            else
            {
                BstarMHold = 0;
            }
            if (FreLoopMHold > 0)
            {
                FreLoopMHold -= 1;
            }
            else
            {
                FreLoopMHold = 0;
            }
            if (CoinMHold > 0)
            {
                CoinMHold -= 1;
            }
            else
            {
                CoinMHold = 0;
            }
            if (ShadMHold > 0)
            {
                ShadMHold -= 1;
            }
            else
            {
                ShadMHold = 0;
            }
            if (LazaMHold > 0)
            {
                LazaMHold -= 1;
            }
            else
            {
                LazaMHold = 0;
            }
            if (ProjMHold > 0)
            {
                ProjMHold -= 1;
            }
            else
            {
                ProjMHold = 0;
            }
            if (ElectricMHold > 0)
            {
                ElectricMHold -= 1;
            }
            else
            {
                ElectricMHold = 0;
            }
            if (MeteorMHold > 0)
            {
                MeteorMHold -= 1;
            }
            else
            {
                MeteorMHold = 0;
            }
            if (WitcMHold > 0)
            {
                WitcMHold -= 1;
            }
            else
            {
                WitcMHold = 0;
            }
            if (CurseMHold > 0)
            {
                CurseMHold -= 1;
            }
            else
            {
                CurseMHold = 0;
            }
            if (BloodMHold > 0)
            {
                BloodMHold -= 1;
            }
            else
            {
                BloodMHold = 0;
            }
            if (ArrowMHold > 0)
            {
                ArrowMHold -= 1;
            }
            else
            {
                ArrowMHold = 0;
            }
            if (IceMHold > 0)
            {
                IceMHold -= 1;
            }
            else
            {
                IceMHold = 0;
            }
            if (FireMHold > 0)
            {
                FireMHold -= 1;
            }
            else
            {
                FireMHold = 0;
            }
            if (CatastropheWheel > 0)
            {
                CatastropheWheel -= 1;
            }
            else
            {
                CatastropheWheel = 0;
            }
            if (WindC > 0)
            {
                WindC -= 1;
            }
            else
            {
                WindC = 0;
            }
            if (GreenBlood > 0)
            {
                GreenBlood -= 1;
            }
            else
            {
                GreenBlood = 0;
            }
            if (FlameShieldCool > 0)
            {
                FlameShieldCool -= 1;
            }
            else
            {
                FlameShieldCool = 0;
            }
            if (FlameShield > 0)
            {
                FlameShield -= 1;
            }
            else
            {
                FlameShield = 0;
            }
            SignalStrength *= 0.5f;
            if(FoodExp > FoodLecelUpNeed[1] && FoodLevel < 2)
            {
                FoodLevel = 2;
                Recipe recipe = Recipe.Create(Mod.Find<ModItem>("LittleCantaloupeJelly").Type, 3);
                recipe.AddIngredient(null, "CantaloupeJuice", 1);
                recipe.AddIngredient(23, 10);
                recipe.AddIngredient(126, 4);
                recipe.requiredTile[0] = 220;
                recipe.Register();
                Recipe recipe2 = Recipe.Create(Mod.Find<ModItem>("littleWatermelonJelly").Type, 3);
                recipe2.AddIngredient(null, "WaterMelonJuice", 1);
                recipe2.AddIngredient(23, 10);
                recipe2.AddIngredient(126, 4);
                recipe2.requiredTile[0] = 220;
                recipe2.Register();
            }
            if (FoodExp > FoodLecelUpNeed[2] && FoodLevel < 3)
            {
                FoodLevel = 3;
                //ModRecipe recipe = new ModRecipe(mod);
                //recipe.AddIngredient(null, "草莓汁", 4);
                //recipe.AddIngredient(949, 15);
                //recipe.requiredTile[0] = 306;
                //recipe.SetResult(mod.ItemType("草莓雪糕"), 1);
                //recipe.AddRecipe();
                Recipe recipe2 = Recipe.Create(Mod.Find<ModItem>("RoastedSaury").Type, 1);
                recipe2.AddIngredient(Mod.Find<ModItem>("UnroastedSaury").Type, 1);
                recipe2.AddIngredient(31, 1);
                recipe2.requiredTile[0] = 215;
                recipe2.Register();
                Recipe recipe3 = Recipe.Create(Mod.Find<ModItem>("WatermelonJelly").Type, 1);
                recipe3.AddIngredient(null, "WaterMelonJuice", 1);
                recipe3.AddIngredient(23, 10);
                recipe3.AddIngredient(126, 4);
                recipe3.requiredTile[0] = 220;
                recipe3.Register();
                Recipe recipe4 = Recipe.Create(Mod.Find<ModItem>("CantaloupeJelly").Type, 1);
                recipe4.AddIngredient(null, "CantaloupeJuice", 1);
                recipe4.AddIngredient(23, 10);
                recipe4.AddIngredient(126, 4);
                recipe4.requiredTile[0] = 220;
                Recipe recipe5 = Recipe.Create(Mod.Find<ModItem>("Curst").Type, 10);
                recipe5.AddIngredient(null, "Flour", 1);
                recipe5.AddIngredient(null, "Egg", 3);
                recipe5.requiredTile[0] = Mod.Find<ModTile>("榨汁机").Type;
                recipe5.Register();
                Recipe recipe7 = Recipe.Create(Mod.Find<ModItem>("RoastedSquid").Type, 1);
                recipe7.AddIngredient(null, "freshSquid", 1);
                recipe7.requiredTile[0] = 215;
                recipe7.Register();
            }
            if (FoodExp > FoodLecelUpNeed[3] && FoodLevel < 4)
            {
                FoodLevel = 4;
            }
            if (FoodExp > FoodLecelUpNeed[4] && FoodLevel < 5)
            {
                FoodLevel = 5;
            }
            if (FoodExp > FoodLecelUpNeed[5] && FoodLevel < 6)
            {
                FoodLevel = 6;
            }
            if (FoodExp > FoodLecelUpNeed[6] && FoodLevel < 7)
            {
                FoodLevel = 7;
            }
            if (FoodExp > FoodLecelUpNeed[7] && FoodLevel < 8)
            {
                FoodLevel = 8;
            }
            if (FoodExp > FoodLecelUpNeed[8] && FoodLevel < 9)
            {
                FoodLevel = 9;
            }
            if (FoodExp > FoodLecelUpNeed[9] && FoodLevel < 10)
            {
                FoodLevel = 10;
            }
            if (FoodExp > FoodLecelUpNeed[10] && FoodLevel < 11)
            {
                FoodLevel = 11;
            }
            if (FoodExp > FoodLecelUpNeed[11] && FoodLevel < 12)
            {
                FoodLevel = 12;
            }
            if (FoodExp > FoodLecelUpNeed[12] && FoodLevel < 13)
            {
                FoodLevel = 13;
            }
            if (FoodExp > FoodLecelUpNeed[13] && FoodLevel < 14)
            {
                FoodLevel = 14;
            }
            if (FoodExp > FoodLecelUpNeed[14] && FoodLevel < 15)
            {
                FoodLevel = 15;
            }
            if (FoodExp > FoodLecelUpNeed[15] && FoodLevel < 16)
            {
                FoodLevel = 16;
            }
            if (bubble > 0)
            {
                bubble -= 1;
            }
            else
            {
                bubble = 0;
            }
            if (AddDef > 8)
            {
                AddDef -= 7;
            }
            else if(AddDef > 0)
            {
                AddDef -= 1;
            }
            else
            {
                AddDef = 0;
            }
            if (DisHurt > 0)
            {
                DisHurt -= 1;
            }
            else
            {
                DisHurt = 0;
            }
            if (signal > 0)
            {
                signal -= 1;
            }
            else
            {
                signal = 0;
            }
            if (Su > 0)
            {
                Su -= 1;
                if (Su2 > 0)
                {
                    Su2 -= 1;
                }
                else
                {
                    Su2 = 0;
                }
            }
            else
            {
                Su = 0;
            }
            if (ab > 0)
            {
                ab -= 1;
            }
            else
            {
                ab = 0;
            }
            if (Player.HasBuff(Mod.Find<ModBuff>("嗜血狂暴").Type))
            {
                if(Crazyindex < 6)
                {
                    Crazyindex *= 0.99f;
                }
                else
                {
                    Crazyindex *= 0.985f;
                }
            }
            else
            {
                Crazyindex = 0;
            }
            if(MythWorld.Myth)
            {
                if(MythWorld.MythIndex ==1)
                {
                    if (Main.dayTime && NightR)
                    {
                        DayR = true;
                        YinLife += 1;
                        NightR = false;
                    }
                    if (!Main.dayTime && DayR)
                    {
                        NightR = true;
                        YangLife += 1;
                        DayR = false;
                    }
                }
                if (CalmOn)
                {
                    if (NPC.CountNPCS(4) != 0)
                    {
                        for (int r = 0; r < 200; r++)
                        {
                            if (Main.npc[r].type == 4)
                            {
                                if (Main.npc[r].life < 4000 && NPCs.AIs.Eoc == true)
                                {
                                    Main.npc[r].damage = 65;
                                    NPCs.AIs.Eoc = false;
                                    Vector2 vector = Main.npc[r].Center + new Vector2(0f, (float)Main.npc[r].height / 2f);
                                    NPC.NewNPC((int)vector.X, (int)vector.Y, Mod.Find<ModNPC>("克苏鲁之眼幻影").Type, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                if (Main.npc[r].life < 2000 && NPCs.AIs.Eoc2 == true)
                                {
                                    NPCs.AIs.Eoc2 = false;
                                    Vector2 vector = Main.npc[r].Center + new Vector2(0f, (float)Main.npc[r].height / 2f);
                                    NPC.NewNPC((int)vector.X, (int)vector.Y, Mod.Find<ModNPC>("克苏鲁之眼幻影").Type, 0, 0f, 0f, 0f, 0f, 255);
                                }
                                if (Main.npc[r].life < 500 && NPCs.AIs.Eoc3 == true)
                                {
                                    NPCs.AIs.Eoc3 = false;
                                    Vector2 vector = Main.npc[r].Center + new Vector2(200f, (float)Main.npc[r].height / 2f);
                                    Vector2 vector3 = Main.npc[r].Center + new Vector2(0f, (float)Main.npc[r].height / 2f);
                                    Vector2 vector2 = Main.npc[r].Center + new Vector2(-200f, (float)Main.npc[r].height / 2f);
                                    NPCs.AIs.vector19 = new Vector2(0, 50);
                                    NPCs.AIs.num71 = NPC.NewNPC((int)vector.X, (int)vector.Y, Mod.Find<ModNPC>("克苏鲁之眼幻影").Type, 0, 0f, 0f, 0f, 0f, 255);
                                    NPCs.AIs.num72 = NPC.NewNPC((int)vector.X, (int)vector.Y, Mod.Find<ModNPC>("克苏鲁之眼幻影").Type, 0, 0f, 0f, 0f, 0f, 255);
                                    if (MythWorld.MythIndex >= 3)
                                    {
                                        for (int i = 0; i < 5; i++)
                                        {
                                            Vector2 v = new Vector2(0, 800).RotatedByRandom(Math.PI * 2);
                                            NPC.NewNPC((int)vector3.X + (int)v.X, (int)vector3.Y + (int)v.Y, Mod.Find<ModNPC>("克苏鲁之眼幻影").Type, 0, 0f, 0f, 0f, 0f, 255);
                                        }
                                    }
                                }
                                if (NPC.CountNPCS(Mod.Find<ModNPC>("克苏鲁之眼幻影").Type) > 0)
                                {
                                    Main.npc[r].dontTakeDamage = true;
                                }
                                else
                                {
                                    Main.npc[r].dontTakeDamage = false;
                                }
                                if (MythWorld.MythIndex >= 2 && Main.npc[r].life < Main.npc[r].lifeMax * 0.3f)
                                {
                                    if (Main.npc[r].velocity.Length() > 3f && (int)Main.time % 25 == 0)
                                    {
                                        Vector2 C = Player.Center;
                                        Vector2 V = Player.velocity.RotatedBy(Main.rand.NextFloat((float)Math.PI * 0.5f, (float)Math.PI * 1.5f)) / Player.velocity.Length() * 350f;
                                        NPCs.AIs.num71 = NPC.NewNPC((int)(V + C).X, (int)(V + C).Y, Mod.Find<ModNPC>("克苏鲁之眼残影").Type, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                }
                            }
                        }
                    }
                    if (NPC.CountNPCS(50) != 0)
                    {
                        for (int r = 0; r < 200; r++)
                        {
                            if (Main.npc[r].type == 50)
                            {
                                if (Main.npc[r].type == 50 && MythWorld.Myth)
                                {
                                    bool flag12 = false;
                                    bool flag13 = true;
                                    if (Main.npc[r].ai[3] != 9968)
                                    {
                                        flag13 = false;
                                    }
                                    if (Main.npc[r].ai[1] == 5f)
                                    {
                                        flag12 = true;
                                        Main.npc[r].ai[0] += 15f;
                                    }
                                    else if (Main.npc[r].ai[1] == 6f)
                                    {
                                        flag12 = true;
                                        Main.npc[r].ai[0] += 18f;
                                    }
                                    if (Main.npc[r].velocity.Y == 0f && !flag12)
                                    {
                                        Main.npc[r].ai[0] += 25f;
                                    }
                                    if (Main.npc[r].life > 2000)
                                    {
                                        flag13 = true;
                                    }
                                    if (MythWorld.MythIndex >= 3)
                                    {
                                        if (Main.netMode != 1 && Main.npc[r].life <= 10000)
                                        {
                                            if (Main.netMode != 1 && Main.npc[r].life <= 7000)
                                            {
                                                if (Main.netMode != 1 && Main.npc[r].life <= 5000)
                                                {
                                                    int num = Main.rand.Next(140);
                                                    if (num == 1)
                                                    {
                                                        Vector2 vector = Main.npc[r].Center + new Vector2(0f, (float)Main.npc[r].height / 2f);
                                                        NPC.NewNPC((int)vector.X - 25, (int)vector.Y, Mod.Find<ModNPC>("飞行史莱姆").Type, 0, 0f, 0f, 0f, 0f, 255);
                                                        NPC.NewNPC((int)vector.X + 25, (int)vector.Y - 10, Mod.Find<ModNPC>("飞行尖刺史莱姆").Type, 0, 0f, 0f, 0f, 0f, 255);
                                                        Main.npc[r].ai[2] += 12f;
                                                        Main.npc[r].ai[0] += 700f;
                                                    }
                                                    Main.npc[r].velocity.Y *= 1.014f;
                                                    if (Main.npc[r].velocity.Y > 0)
                                                    {
                                                        Main.npc[r].velocity.Y *= 1.2f;
                                                    }
                                                }
                                                else
                                                {
                                                    int num4002 = Main.rand.Next(240);
                                                    if (num4002 == 1)
                                                    {
                                                        Vector2 vector = Main.npc[r].Center + new Vector2(0f, (float)Main.npc[r].height / 2f);
                                                        NPC.NewNPC((int)vector.X - 25, (int)vector.Y, Mod.Find<ModNPC>("飞行史莱姆").Type, 0, 0f, 0f, 0f, 0f, 255);
                                                        NPC.NewNPC((int)vector.X + 25, (int)vector.Y + 10, Mod.Find<ModNPC>("飞行尖刺史莱姆").Type, 0, 0f, 0f, 0f, 0f, 255);
                                                        Main.npc[r].ai[2] += 5f;
                                                        Main.npc[r].ai[0] += 110f;
                                                        if (Main.npc[r].velocity.Y > 0)
                                                        {
                                                            Main.npc[r].velocity.Y *= 1.2f;
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                int num1 = Main.rand.Next(360);
                                                if (num1 == 1)
                                                {
                                                    Vector2 vector = Main.npc[r].Center + new Vector2(0f, (float)Main.npc[r].height / 2f);
                                                    NPC.NewNPC((int)vector.X, (int)vector.Y, Mod.Find<ModNPC>("飞行史莱姆").Type, 0, 0f, 0f, 0f, 0f, 255);
                                                    Main.npc[r].ai[2] += 2f;
                                                    Main.npc[r].ai[0] += 35f;
                                                    if (Main.npc[r].velocity.Y > 0)
                                                    {
                                                        Main.npc[r].velocity.Y *= 1.1f;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (Main.netMode != 1 && Main.npc[r].life <= 5000)
                                        {
                                            if (Main.netMode != 1 && Main.npc[r].life <= 3000)
                                            {
                                                if (Main.netMode != 1 && Main.npc[r].life <= 1000)
                                                {
                                                    int num = Main.rand.Next(140);
                                                    if (num == 1)
                                                    {
                                                        Vector2 vector = Main.npc[r].Center + new Vector2(0f, (float)Main.npc[r].height / 2f);
                                                        NPC.NewNPC((int)vector.X - 25, (int)vector.Y, Mod.Find<ModNPC>("飞行史莱姆").Type, 0, 0f, 0f, 0f, 0f, 255);
                                                        NPC.NewNPC((int)vector.X + 25, (int)vector.Y - 10, Mod.Find<ModNPC>("飞行尖刺史莱姆").Type, 0, 0f, 0f, 0f, 0f, 255);
                                                        Main.npc[r].ai[2] += 4f;
                                                        Main.npc[r].ai[0] += 200f;
                                                    }
                                                    Main.npc[r].velocity.Y *= 1.014f;
                                                    if (Main.npc[r].velocity.Y > 0)
                                                    {
                                                        Main.npc[r].velocity.Y *= 1.2f;
                                                    }
                                                }
                                                else
                                                {
                                                    int num4002 = Main.rand.Next(240);
                                                    if (num4002 == 1)
                                                    {
                                                        Vector2 vector = Main.npc[r].Center + new Vector2(0f, (float)Main.npc[r].height / 2f);
                                                        NPC.NewNPC((int)vector.X - 25, (int)vector.Y, Mod.Find<ModNPC>("飞行史莱姆").Type, 0, 0f, 0f, 0f, 0f, 255);
                                                        if (Main.rand.Next(20) >= 15 && MythWorld.MythIndex >= 2)
                                                        {
                                                            NPC.NewNPC((int)vector.X + 25, (int)vector.Y + 10, Mod.Find<ModNPC>("飞行尖刺史莱姆").Type, 0, 0f, 0f, 0f, 0f, 255);
                                                        }
                                                        Main.npc[r].ai[2] += 1.5f;
                                                        Main.npc[r].ai[0] += 40f;
                                                        if (Main.npc[r].velocity.Y > 0)
                                                        {
                                                            Main.npc[r].velocity.Y *= 1.2f;
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                int num1 = Main.rand.Next(360);
                                                if (num1 == 1)
                                                {
                                                    Vector2 vector = Main.npc[r].Center + new Vector2(0f, (float)Main.npc[r].height / 2f);
                                                    NPC.NewNPC((int)vector.X, (int)vector.Y, Mod.Find<ModNPC>("飞行史莱姆").Type, 0, 0f, 0f, 0f, 0f, 255);
                                                    Main.npc[r].ai[2] += 0.8f;
                                                    Main.npc[r].ai[0] += 10f;
                                                    if (Main.npc[r].velocity.Y > 0)
                                                    {
                                                        Main.npc[r].velocity.Y *= 1.1f;
                                                    }
                                                }
                                            }
                                        }
                                        if (Main.time % 600 == 0 && MythWorld.MythIndex >= 3)
                                        {
                                            Vector2 vector3 = Main.npc[r].Center + new Vector2(0f, (float)Main.npc[r].height / 2f);
                                            for (int i = 0; i < 15; i++)
                                            {
                                                Vector2 v = new Vector2(0, 800).RotatedByRandom(Math.PI * 2);
                                                NPC.NewNPC((int)vector3.X + (int)v.X, (int)vector3.Y + (int)v.Y, 5, 0, 0f, 0f, 0f, 0f, 255);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            /*if (!player.behindBackWall && ZoneOcean)
            {
                int op = 0;
                for (int i = -32; i<32; i++)
                {
                    for (int j = -32; j < 32; j++)
                    {
                        if (Main.tile[(int)(player.Center.X / 16 + i), (int)(player.Center.Y / 16 + j)].wall == mod.WallType("BackGWall"))
                        {
                            op += 1;
                            if(op > 1)
                            {
                                Main.tile[(int)(player.Center.X / 16 + i), (int)(player.Center.Y / 16 + j)].wall = 0;
                            }
                        }
                        if (Main.tile[(int)(player.Center.X / 16), (int)(player.Center.Y / 16)].wall <= 0 && op == 0)
                        {
                            Main.tile[(int)(player.Center.X / 16), (int)(player.Center.Y / 16)].wall = (ushort)mod.WallType("BackGWall");
                        }
                    }
                }
            }*/
            if (Player.behindBackWall && Main.tile[(int)(Player.Center.X / 16), (int)(Player.Center.Y / 16)].WallType == Mod.Find<ModWall>("熔岩石墙").Type && ZoneVolcano)
            {
                if(Main.rand.Next(10) == 1)
                {
                    Vector2 v = new Vector2(0, Main.rand.Next(0, 6)).RotatedByRandom(Math.PI * 2);
                    Projectile.NewProjectile(Player.Center.X + Main.rand.Next(-Main.screenWidth / 2 - 20, Main.screenWidth / 2 + 20), Player.Center.Y + Main.screenWidth / 2 + 15 + Main.rand.Next(-100, 100), 0 + v.X, -22 + v.Y, base.Mod.Find<ModProjectile>("熔岩团").Type, 200, 0, Main.myPlayer, 0, 0f);
                }
                if(NPC.CountNPCS(Mod.Find<ModNPC>("诅咒熔岩巨石怪").Type) < 1)
                {
                    NPC.NewNPC((int)Player.Center.X, (int)Player.Center.Y + 2000, Mod.Find<ModNPC>("诅咒熔岩巨石怪").Type, 0, 0, 0, 0, 0, 255);
                }
                if(!MythWorld.downedVol)
                {
                    Player.lastDeathPostion = Player.Center;
                    Player.lastDeathTime = DateTime.Now;
                    Player.showLastDeath = true;
                    if (Main.myPlayer == Player.whoAmI)
                    {
                        Player.lostCoinString = Main.ValueToCoins(Player.lostCoins);
                    }
                    SoundEngine.PlaySound(SoundID.PlayerKilled, Player.position);
                    Player.headVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
                    Player.bodyVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
                    Player.legVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
                    Player.headVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
                    Player.bodyVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
                    Player.legVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
                    if (Player.stoned)
                    {
                        Player.headPosition = Vector2.Zero;
                        Player.bodyPosition = Vector2.Zero;
                        Player.legPosition = Vector2.Zero;
                    }
                    for (int j = 0; j < 100; j++)
                    {
                        Dust.NewDust(Player.position, Player.width, Player.height, 205, 0f, -2f, 0, default(Color), 1f);
                    }
                    Player.statLife = 0;
                    Player.dead = true;
                    Player.respawnTimer = 600;
                    Player.head = -1;
                    Player.body = -1;
                    Player.legs = -1;
                    Player.handon = -1;
                    Player.handoff = -1;
                    Player.back = -1;
                    Player.front = -1;
                    Player.shoe = -1;
                    Player.waist = -1;
                    Player.shield = -1;
                    Player.neck = -1;
                    Player.face = -1;
                    Player.balloon = -1;
                    Player.mount.Dismount(Player);
                    if (Main.expertMode)
                    {
                        Player.respawnTimer = (int)((double)Player.respawnTimer * 1.5);
                    }
                    Player.immuneAlpha = 0;
                    Player.palladiumRegen = false;
                    Player.iceBarrier = false;
                    Player.crystalLeaf = false;
                    if (Player.whoAmI == Main.myPlayer && Player.difficulty == 0)
                    {
                        Player.DropCoins();
                    }
                    else if (Player.difficulty == 1)
                    {
                        Player.DropItems();
                    }
                    else if (Player.difficulty == 2)
                    {
                        Player.DropItems();
                        Player.KillMeForGood();
                    }
                    Color messageColor2 = Color.Red;
                    Main.NewText(Language.GetTextValue(Player.name + "尝试闯入禁区"), messageColor2);
                }
            }
            SD2 -= 1;
            if(SD2 <= 0)
            {
                SD2 = 0;
                SD = 0;
            }
            else
            {
                if(Main.screenPosition.X + Main.mouseX - Player.Center.X > 0)
                {
                    Player.direction = 1;
                }
                else
                {
                    Player.direction = -1;
                }
            }
            //int num = CombatText.NewText(new Rectangle((int)player.position.X, (int)player.position.Y, player.width, player.height), CombatText.HealLife, 999, false, false);
            //CombatText combatText = Main.combatText[num];
            //NetMessage.SendData(81, -1, -1, NetworkText.FromLiteral("∞"), (int)combatText.color.PackedValue, combatText.position.X, combatText.position.Y, (float)999, 0, 0, 0);
            //BinaryWriter writer = NetMessage.buffer[256].writer;
            //writer.Write((string)"∞");
            Mod Fmod = ModLoader.GetMod("FKBossHealthBar");
            if (ModLoader.GetMod("FKBossHealthBar") != null)
            {
                if(MythWorld.Myth)
                {
                }
            }
            if (Main.worldName == worldnm)
            {
                if(Main.time % 300 == 0)
                {
                    for (int j = 0; j < 200; j++)
                    {
                        if (Main.npc[j].type == 1 || Main.npc[j].type == 3 || Main.npc[j].type == 16 || Main.npc[j].type == 45 || Main.npc[j].type == 52 || Main.npc[j].type == 49 || Main.npc[j].type == 150 || Main.npc[j].type == 113 || Main.npc[j].type == 114 || Main.npc[j].type == 54 || Main.npc[j].type == 54 || Main.npc[j].type == 58 || Main.npc[j].type == 508 || Main.npc[j].type == 54 || Main.npc[j].type < 0 || Main.npc[j].type == 16 || Main.npc[j].type == 93 || Main.npc[j].type == 77 || (Main.npc[j].type >= 498 && Main.npc[j].type <= 506) || Main.npc[j].type == 300 || Main.npc[j].type == 217 || Main.npc[j].type == 44 || Main.npc[j].type == 110 || Main.npc[j].type == 95 || Main.npc[j].type == 96 || Main.npc[j].type == 97 || Main.npc[j].type == 316 || Main.npc[j].type == 10 || Main.npc[j].type == 11 || Main.npc[j].type == 12 || Main.npc[j].type == 195 || Main.npc[j].type == 196 || Main.npc[j].type == 45 || Main.npc[j].type == 172 || Main.npc[j].type == 21 || Main.npc[j].type == 449 || Main.npc[j].type == 201 || Main.npc[j].type == 450 || Main.npc[j].type == 202 || Main.npc[j].type == 451 || Main.npc[j].type == 203 || Main.npc[j].type == 452 || Main.npc[j].type == 322 || Main.npc[j].type == 323 || Main.npc[j].type == 324 || Main.npc[j].type == 48)
                        {
                            Main.npc[j].active = false;
                        }
                    }
                }
                if(Main.bloodMoon)
                {
                    Main.bloodMoon = false;
                }
            }
            /*if (Main.mouseMiddle)
            {
                string key = YinYangLife.Open.ToString();
                Color messageColor = Color.Purple;
                Main.NewText(Language.GetTextValue(key), messageColor);
            }*/
            if (clear && MythWorld.Onew == false && Main.worldName == worldnm && create)
            {
                for (int l = 0; l < Main.maxTilesX; l++)
                {
                    for (int m = 0; m < Main.maxTilesY; m++)
                    {
                        Main.tile[l, m].ClearEverything();
                        CombatText.clearAll();
                    }
                }
                OceanWorldMain.jindu = 0;
                OceanWorld.Open = true;

                MythWorld.WorldType = 1;
                MythWorld.Onew = true;
                clear = false;
            }
            if(Main.worldName == worldnm && !trans)
            {
                if (Main.maxTilesX == 4200)
                {
                    Player.position = new Vector2(20, Main.maxTilesY / 10f + 60) * 16f;
                }
                if (Main.maxTilesX == 6400)
                {
                    Player.position = new Vector2(20, Main.maxTilesY / 10f + 180) * 16f;
                }
                if (Main.maxTilesX == 8400)
                {
                    Player.position = new Vector2(20, Main.maxTilesY / 10f + 300) * 16f;
                }
                trans = true;
            }
            if(Main.worldName != worldnm)
            {
                trans = false;
            }
            if (MythWorld.WorldCount == 2)
            {

            }
            SpringAct.Open = true;
            if (YinLife > YinLifeMax)
                YinLife = YinLifeMax;
            if (YangLife > YangLifeMax)
                YangLife = YangLifeMax;
            YinBar = (float)YinLife / (float)YinLifeMax;
            YangBar = (float)YangLife / (float)YangLifeMax;
            if (Player.statLife > 0 && num2 > 120)
            {
                num2 += 1;
                num1 = true;
            }
            else
            {
                num2 = 0;
            }
            if (IMMUNE > 0)
            {
                IMMUNE -= 1;
                Player.immune = true;
            }
            if (Stones.Open == false && movieTime > 0)
            {
                movieTime -= 1;
            }
            if (NPC.CountNPCS(370) == 0)
            {
                Cloud = 0;
            }
            if (Player.active || !Player.dead)
            {
                v1 = Main.screenPosition + new Vector2(Main.screenWidth / 2 - 16, Main.screenHeight / 2 - 24);
            }
            if (ZTMSY && NPC.CountNPCS(Mod.Find<ModNPC>("终天灭世眼").Type) < 1)
            {
                NPC.NewNPC((int)Player.Center.X, (int)Player.Center.Y, Mod.Find<ModNPC>("终天灭世眼").Type, 0, 0f, 0f, 0f, 0f, 255);
            }
            else
            {
                num100 = 0;
            }
            if (Starfishes)
            {
                Starfish.Open = true;
            }
            else
            {
                if (Starfish.Open)
                {
                    Projectile.NewProjectile(Player.Center.X + Player.direction * 25, Player.Center.Y, Player.direction * 4, 0, base.Mod.Find<ModProjectile>("海星1").Type, 0, 0.2f, Main.myPlayer, 0f, 0f);
                }
                Starfish.Open = false;
            }
            if (OpenLift && Main.time % 5 == 0 && LiftOpenDegree < 6)
            {
                LiftOpenDegree += 1;
                num11 = (int)Main.time;
            }
            if (LiftOpenDegree == 6)
            {
                int num12 = (int)Main.time - num11;
                OpenLift = false;
                if (num12 % 15 == 0)
                {
                    CloseLift = true;
                }
            }
            if (CloseLift && Main.time % 5 == 0 && LiftOpenDegree >= 0)
            {
                LiftOpenDegree -= 1;
            }
            if (LiftOpenDegree == -1 && !OpenLift)
            {
                CloseLift = false;
            }
            if (LiftU)
            {
                if (firstClick)
                {
                    Maxfloor = 0;
                    for (int k = (int)(Player.position.X / 16f - 5); k < (int)(Player.position.X / 16f + 5); k++)
                    {
                        if (Main.tile[k, (int)(Player.position.Y / 16f)].TileType == Mod.Find<ModTile>("电梯门").Type)
                        {
                            m = k;
                            for (int l = (int)(Player.position.Y / 16f); l < Main.maxTilesY; l += 4)
                            {
                                if (Main.tile[m, l].TileType == Mod.Find<ModTile>("电梯门").Type)
                                {
                                    Zonefloor += 1;
                                }
                            }
                            m3 = k;
                            for (int l = 0; l < Main.maxTilesY; l += 4)
                            {
                                if (Main.tile[m, l].TileType == Mod.Find<ModTile>("电梯门").Type)
                                {
                                    Maxfloor += 1;
                                }
                            }
                            firstClick = false;
                            break;
                        }
                    }
                }
                if (floor > Zonefloor && Main.time % 50 == 0)
                {
                    floor -= 1;
                }
                if (floor < Zonefloor && Main.time % 50 == 0)
                {
                    floor += 1;
                }
                if (floor == Zonefloor)
                {
                    OpenLift = true;
                    Lifebutton.Up2 = true;
                    Lifebutton.Open = true;
                    Zonefloor = 0;
                    LiftU = false;
                }
            }
            if (LiftD)
            {
                if (firstClick)
                {
                    Maxfloor = 0;
                    for (int k = (int)(Player.position.X / 16f - 5); k < (int)(Player.position.X / 16f + 5); k++)
                    {
                        if (Main.tile[k, (int)(Player.position.Y / 16f)].TileType == Mod.Find<ModTile>("电梯门").Type)
                        {
                            m = k;
                            for (int l = (int)(Player.position.Y / 16f); l < Main.maxTilesY; l += 4)
                            {
                                if (Main.tile[m, l].TileType == Mod.Find<ModTile>("电梯门").Type)
                                {
                                    Zonefloor += 1;
                                }
                            }
                            m3 = k;
                            for (int l = 0; l < Main.maxTilesY; l += 4)
                            {
                                if (Main.tile[m, l].TileType == Mod.Find<ModTile>("电梯门").Type)
                                {
                                    Maxfloor += 1;
                                }
                            }
                            firstClick = false;
                            break;
                        }
                    }
                }
                if (floor > Zonefloor && Main.time % 50 == 0)
                {
                    floor -= 1;
                }
                if (floor < Zonefloor && Main.time % 50 == 0)
                {
                    floor += 1;
                }
                if (floor == Zonefloor)
                {
                    OpenLift = true;
                    Lifebutton.Down2 = true;
                    Lifebutton.Open = true;
                    Zonefloor = 0;
                    LiftD = false;
                }
            }
            if (TransD)
            {
                FlyCamPosition = new Vector2(0, 2 * num3);
                Player.velocity *= 0;
                num3 += 2f;
                int p = 0;
                for (int k = (int)(Player.position.X / 16f - 5); k < (int)(Player.position.X / 16f + 5); k++)
                {
                    if (Main.tile[k, (int)((Player.position.Y + FlyCamPosition.Y) / 16f)].TileType == Mod.Find<ModTile>("电梯门").Type)
                    {
                        m2 = k;
                        for (int l = (int)((Player.position.Y + FlyCamPosition.Y) / 16f); l < Main.maxTilesY; l += 4)
                        {
                            if (Main.tile[m2, l].TileType == Mod.Find<ModTile>("电梯门").Type)
                            {
                                p += 1;
                            }
                        }
                    }
                }
                if (p != 0)
                {
                    floor = p / 3;
                }
                if (floor == aimFloor)
                {
                    num3 = 0;
                    LiftDontTake = true;
                    Player.position += FlyCamPosition;
                    OpenLift = true;
                    TransD = false;
                }
                if (LiftDontTake && num4 <= 0)
                {
                    num4 = 30;
                }
                if (LiftDontTake && num4 > 0)
                {
                    num4 -= 1;
                    if (num4 <= 0)
                    {
                        LiftDontTake = false;
                    }
                    Player.noFallDmg = true;
                }
            }
            if (TransU)
            {
                FlyCamPosition = new Vector2(0, -2 * num3);
                Player.velocity *= 0;
                num3 += 2f;
                int p = 0;
                for (int k = (int)(Player.position.X / 16f - 5); k < (int)(Player.position.X / 16f + 5); k++)
                {
                    if (Main.tile[k, (int)((Player.position.Y + FlyCamPosition.Y) / 16f)].TileType == Mod.Find<ModTile>("电梯门").Type)
                    {
                        m2 = k;
                        for (int l = (int)((Player.position.Y + FlyCamPosition.Y) / 16f); l < Main.maxTilesY; l += 4)
                        {
                            if (Main.tile[m2, l].TileType == Mod.Find<ModTile>("电梯门").Type)
                            {
                                p += 1;
                            }
                        }
                    }
                }
                if (p != 0)
                {
                    floor = p / 3;
                }
                if (floor == aimFloor)
                {
                    num3 = 0;
                    LiftDontTake = true;
                    Player.position += FlyCamPosition + new Vector2(0, -64);
                    OpenLift = true;
                    TransU = false;
                }
                if (LiftDontTake && num4 <= 0)
                {
                    num4 = 30;
                }
                if (LiftDontTake && num4 > 0)
                {
                    num4 -= 1;
                    if (num4 <= 0)
                    {
                        LiftDontTake = false;
                    }
                    Player.noFallDmg = true;
                }
            }
            if (Main.mouseMiddle && Player.name == "万象元素")
            {
                if (Main.mouseMiddleRelease)
                {
                    for (int m = 0; m < 1000; m++)
                    {
                        if (Main.projectile[m].hostile == true)
                        {
                            Main.projectile[m].velocity *= -1;
                            Main.projectile[m].hostile = false;
                            Main.projectile[m].friendly = true;
                            Main.projectile[m].damage *= 100;
                        }
                    }
                    string key = Misspossibility.ToString();
                    string key2 = FoodExp.ToString();
                    string key3 = MythWorld.MythIndex.ToString();
                    Color messageColor = new Color(201, 240, 255, 135);
                    Main.NewText(Language.GetTextValue(SignalStrength.ToString()), messageColor);
                    MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
                    mplayer.FoodExp += 3;
                    Main.NewText(Language.GetTextValue(mplayer.FoodLevel.ToString() + " /  " + ((float)(mplayer.FoodExp - mplayer.FoodLecelUpNeed[mplayer.FoodLevel - 1]) / (float)(mplayer.FoodLecelUpNeed[mplayer.FoodLevel] - mplayer.FoodLecelUpNeed[mplayer.FoodLevel - 1] + 0.0001f)).ToString()), messageColor);
                } 
                FREEZE += 1;
                if (FREEZE > 120)
                {
                    FREEZE = 0;
                    Absorb = 240;
                }
            }
            if (Absorb > 0)
            {
                Absorb -= 1;
                for (int m = 0; m < 1000; m++)
                {
                    if (Main.projectile[m].hostile == true)
                    {
                        Main.projectile[m].velocity = (Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - Main.projectile[m].Center) / (Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - Main.projectile[m].Center).Length() * (float)(240 - Absorb);
                        if ((Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - Main.projectile[m].Center).Length() < 200)
                        {
                            Main.projectile[m].active = false;
                        }
                    }
                }
                for (int m = 0; m < 200; m++)
                {
                    if (Main.npc[m].friendly == false)
                    {
                        Main.npc[m].velocity = (Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - Main.npc[m].Center) / (Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - Main.npc[m].Center).Length() * (float)(240 - Absorb);
                        if ((Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - Main.npc[m].Center).Length() < 200)
                        {
                            Main.npc[m].active = false;
                        }
                    }
                }
            }
            if (Absorb <= 10 && Absorb > 0)
            {
                for (int m = 0; m < 200; m++)
                {
                    if (Main.npc[m].friendly == false)
                    {
                        Main.npc[m].active = false;
                    }
                }
                MythWorld.typhoon = false;
            }
            if (!MythWorld.typhoon && MythWorld.downedMoonLoad)
            {
                if ((int)(Main.time / 5) % 300 == 1 && 6 == 1)
                {
                    MythWorld.typhoon = true;
                    Color messageColor = new Color(201, 240, 255, 135);
                    Main.NewText(Language.GetTextValue("你感到宁静的大陆风声四起"), messageColor);
                    MythWorld.typhoonTime = Main.rand.Next(10500, 27501);
                    MythWorld.typhoonTimeLeft = MythWorld.typhoonTime;
                    MythWorld.typhoonStrenth = Main.rand.Next(12500, Main.rand.Next(22500, 31000)) / 10000f;
                }
            }
            if (MythWorld.typhoon)
            {
                MythWorld.typhoonTimeLeft -= 1;
                if (MythWorld.typhoonTimeLeft < 1)
                {
                    MythWorld.typhoon = false;
                    MythWorld.typhoonTime = 0;
                }
                int Middletime = MythWorld.typhoonTime / 2 - MythWorld.typhoonTimeLeft;
                if (Main.windSpeed < MythWorld.typhoonStrenth && MythWorld.typhoonTime - MythWorld.typhoonTimeLeft < 300)
                {
                    Main.windSpeed += 0.0002f;
                }
                if (Main.windSpeed < MythWorld.typhoonStrenth && MythWorld.typhoonTime - MythWorld.typhoonTimeLeft >= 300 && MythWorld.typhoonTime - MythWorld.typhoonTimeLeft < 600)
                {
                    Main.windSpeed += 0.0004f;
                }
                if (Main.windSpeed < MythWorld.typhoonStrenth && MythWorld.typhoonTime - MythWorld.typhoonTimeLeft >= 600 && MythWorld.typhoonTime - MythWorld.typhoonTimeLeft < 900)
                {
                    Main.windSpeed += 0.0007f;
                }
                if (Main.windSpeed < MythWorld.typhoonStrenth && MythWorld.typhoonTime - MythWorld.typhoonTimeLeft >= 900 && MythWorld.typhoonTime - MythWorld.typhoonTimeLeft < 1200)
                {
                    Main.windSpeed += 0.0013f;
                }
                if (Main.windSpeed < MythWorld.typhoonStrenth && MythWorld.typhoonTime - MythWorld.typhoonTimeLeft >= 1200 && MythWorld.typhoonTime - MythWorld.typhoonTimeLeft < 1500)
                {
                    Main.windSpeed += 0.0025f;
                }
                if (MythWorld.typhoonTime - MythWorld.typhoonTimeLeft > 1500 && Math.Abs(Middletime) >= 1500)
                {
                    Main.windSpeed = MythWorld.typhoonStrenth;
                }
                if (Math.Abs(Middletime) < 1500)
                {
                    Main.windSpeed *= 0.995f;
                }
                if (Main.windSpeed > -MythWorld.typhoonStrenth && Middletime >= 1500 && Middletime < 1800)
                {
                    Main.windSpeed -= 0.0002f;
                }
                if (Main.windSpeed > -MythWorld.typhoonStrenth && Middletime >= 1800 && Middletime < 2100)
                {
                    Main.windSpeed -= 0.0004f;
                }
                if (Main.windSpeed > -MythWorld.typhoonStrenth && Middletime >= 2100 && Middletime < 2400)
                {
                    Main.windSpeed -= 0.0007f;
                }
                if (Main.windSpeed > -MythWorld.typhoonStrenth && Middletime >= 2400 && Middletime < 2700)
                {
                    Main.windSpeed -= 0.00013f;
                }
                if (Main.windSpeed > -MythWorld.typhoonStrenth && Middletime >= 2400 && Middletime < 2700)
                {
                    Main.windSpeed -= 0.00025f;
                }
                if (Middletime >= 2700)
                {
                    Main.windSpeed = -MythWorld.typhoonStrenth;
                }
                Main.maxRaining = (Math.Abs(Main.windSpeed) <= 1 ? Math.Abs(Main.windSpeed) : 1);
                Main.raining = true;
            }
            if (GoldTime > 0)
            {
                GoldTime -= 1;
            }
            if (GoldTime <= 0)
            {
                GoldTime = 0;
            }
            if (Cooling > 0)
            {
                Cooling -= 1;
            }
            if (Cooling <= 0)
            {
                Cooling = 0;
            }
            if (Ele > 0)
            {
                Ele -= 1;
            }
            if (Ele <= 0)
            {
                Ele = 0;
            }
            if (MagicCool > 0)
            {
                MagicCool -= 1;
            }
            if (MagicCool <= 0)
            {
                MagicCool = 0;
            }
            if(Player.name == ("万象元素"))
            {
                MagicCool = 0;
            }
            if (Main.dayTime)
            {
                LanternMoon = false;
                LanternMoonPoint = 0;
            }
            if (Player.ZoneCorrupt && NPC.CountNPCS(Mod.Find<ModNPC>("魔茧").Type) <= 0 && Main.rand.Next(10000) == 1)
            {
                Projectile.NewProjectile(Player.Center.X + Player.direction * 1000, Player.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("茧").Type, 0, 0, Main.myPlayer, 0f, 0);
            }



            if (LanternMoon)
            {
                if (LanternMoonPoint <= 80)
                {
                    LanternMoonWave = 1;
                    OldWavePoint = 0;
                    PerWavePoint = 80;
                }
                if (LanternMoonPoint > 80 && LanternMoonPoint <= 160)
                {
                    if (LanternMoonWave != 2)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 2:吉祥僵尸"), messageColor);
                        LanternMoonWave = 2;
                    }
                    PerWavePoint = 80;
                    OldWavePoint = 80;
                }
                if (LanternMoonPoint > 160 && LanternMoonPoint <= 250)
                {
                    if (LanternMoonWave != 3)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 3:剪纸蝙蝠和吉祥僵尸"), messageColor);
                        LanternMoonWave = 3;
                    }
                    PerWavePoint = 90;
                    OldWavePoint = 160;
                }
                if (LanternMoonPoint > 250 && LanternMoonPoint <= 400)
                {
                    if (LanternMoonWave != 4)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 4:剪纸蝙蝠和吉祥僵尸"), messageColor);
                        LanternMoonWave = 4;
                    }
                    PerWavePoint = 150;
                    OldWavePoint = 250;
                }
                if (LanternMoonPoint > 400 && LanternMoonPoint <= 600)
                {
                    if (LanternMoonWave != 5)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 5:剪纸蝙蝠,吉祥僵尸和鬼灯笼"), messageColor);
                        LanternMoonWave = 5;
                    }
                    PerWavePoint = 200;
                    OldWavePoint = 400;
                }
                if (LanternMoonPoint > 600 && LanternMoonPoint <= 850)
                {
                    if (LanternMoonWave != 6)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 6:剪纸蝙蝠,吉祥僵尸和鬼灯笼"), messageColor);
                        LanternMoonWave = 6;
                    }
                    PerWavePoint = 250;
                    OldWavePoint = 600;
                }
                if (LanternMoonPoint > 850 && LanternMoonPoint <= 1100)
                {
                    if (LanternMoonWave != 7)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 7:剪纸蝙蝠"), messageColor);
                        LanternMoonWave = 7;
                    }
                    PerWavePoint = 250;
                    OldWavePoint = 850;
                }
                if (LanternMoonPoint > 1100 && LanternMoonPoint <= 1400)
                {
                    if (LanternMoonWave != 8)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 8:鬼灯笼"), messageColor);
                        LanternMoonWave = 8;
                    }
                    PerWavePoint = 300;
                    OldWavePoint = 1100;
                }
                if (LanternMoonPoint > 1400 && LanternMoonPoint <= 2000)
                {
                    if (LanternMoonWave != 9)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 9:剪纸蝙蝠,吉祥僵尸,鬼灯笼和封包轰炸机"), messageColor);
                        LanternMoonWave = 9;
                    }
                    PerWavePoint = 600;
                    OldWavePoint = 1400;
                }
                if (LanternMoonPoint > 2000 && LanternMoonPoint <= 3000)
                {
                    if (LanternMoonWave != 10)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 10:剪纸蝙蝠,吉祥僵尸,鬼灯笼和封包轰炸机"), messageColor);
                        LanternMoonWave = 10;
                    }
                    PerWavePoint = 1000;
                    OldWavePoint = 2000;
                }
                if (LanternMoonPoint > 3000 && LanternMoonPoint <= 4000)
                {
                    if (LanternMoonWave != 11)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 11:剪纸蝙蝠,鬼灯笼和封包轰炸机"), messageColor);
                        LanternMoonWave = 11;
                    }
                    PerWavePoint = 1000;
                    OldWavePoint = 3000;
                }
                if (LanternMoonPoint > 4000 && LanternMoonPoint <= 5500)
                {
                    if (LanternMoonWave != 12)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 12:剪纸蝙蝠,灯笼幽灵,鬼灯笼和封包轰炸机"), messageColor);
                        LanternMoonWave = 12;
                    }
                    PerWavePoint = 1500;
                    OldWavePoint = 4000;
                }
                if (LanternMoonPoint > 5500 && LanternMoonPoint <= 7000)
                {
                    if (LanternMoonWave != 13)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 13:剪纸蝙蝠,吉祥僵尸,灯笼幽灵,鬼灯笼和封包轰炸机"), messageColor);
                        LanternMoonWave = 13;
                    }
                    PerWavePoint = 1500;
                    OldWavePoint = 5500;
                }
                if (LanternMoonPoint > 7000 && LanternMoonPoint <= 10000)
                {
                    if (LanternMoonWave != 14)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 14:灯笼幽灵,鬼灯笼和封包轰炸机"), messageColor);
                        LanternMoonWave = 14;
                    }
                    PerWavePoint = 3000;
                    OldWavePoint = 7000;
                }
                if (LanternMoonPoint > 10000 && LanternMoonPoint <= 20000)
                {
                    if (LanternMoonWave != 15)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 15:灯笼鬼王"), messageColor);
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("LanternGhostKing").Type, 0, 0, 0, 0, 0, 255);
                        LanternMoonWave = 15;
                    }
                    PerWavePoint = 10000;
                    OldWavePoint = 10000;
                }
                if (LanternMoonPoint > 20000 && LanternMoonPoint <= 21500)
                {
                    if (LanternMoonWave != 16)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 16:糖果史莱姆"), messageColor);
                        LanternMoonWave = 16;
                    }
                    PerWavePoint = 1500;
                    OldWavePoint = 20000;
                }
                if (LanternMoonPoint > 21500 && LanternMoonPoint <= 25000)
                {
                    if (LanternMoonWave != 17)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 17:更多的糖果史莱姆"), messageColor);
                        LanternMoonWave = 17;
                    }
                    PerWavePoint = 3500;
                    OldWavePoint = 21500;
                }
                if (LanternMoonPoint > 25000 && LanternMoonPoint <= 29000)
                {
                    if (LanternMoonWave != 18)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 18:再多的糖果史莱姆"), messageColor);
                        LanternMoonWave = 18;
                    }
                    PerWavePoint = 4000;
                    OldWavePoint = 25000;
                }
                if (LanternMoonPoint > 29000 && LanternMoonPoint <= 36000)
                {
                    if (LanternMoonWave != 19)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 19:糖果史莱姆和青翠年桔木"), messageColor);
                        LanternMoonWave = 19;
                    }
                    PerWavePoint = 7000;
                    OldWavePoint = 29000;
                }
                if (LanternMoonPoint > 36000 && LanternMoonPoint <= 45000)
                {
                    if (LanternMoonWave != 20)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 20:糖果史莱姆和青翠年桔木"), messageColor);
                        LanternMoonWave = 20;
                    }
                    PerWavePoint = 9000;
                    OldWavePoint = 36000;
                }
                if (LanternMoonPoint > 45000 && LanternMoonPoint <= 55000)
                {
                    if (LanternMoonWave != 21)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 21:糖果史莱姆,青翠年桔木和腊肠妖灵"), messageColor);
                        LanternMoonWave = 21;
                    }
                    PerWavePoint = 10000;
                    OldWavePoint = 45000;
                }
                if (LanternMoonPoint > 55000 && LanternMoonPoint <= 65000)
                {
                    if (LanternMoonWave != 22)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 22:糖果史莱姆,青翠年桔木,腊肠妖灵和弹弹汤圆"), messageColor);
                        LanternMoonWave = 22;
                    }
                    PerWavePoint = 10000;
                    OldWavePoint = 55000;
                }
                if (LanternMoonPoint > 65000 && LanternMoonPoint <= 77000)
                {
                    if (LanternMoonWave != 23)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 23:糖果史莱姆,青翠年桔木,腊肠妖灵,弹弹汤圆和兰花精灵"), messageColor);
                        LanternMoonWave = 23;
                    }
                    PerWavePoint = 12000;
                    OldWavePoint = 65000;
                }
                if (LanternMoonPoint > 77000 && LanternMoonPoint <= 90000)
                {
                    if (LanternMoonWave != 24)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 24:糖果史莱姆,青翠年桔木,腊肠妖灵,弹弹汤圆和兰花精灵"), messageColor);
                        LanternMoonWave = 24;
                    }
                    PerWavePoint = 13000;
                    OldWavePoint = 77000;
                }
                if (LanternMoonPoint > 90000 && LanternMoonPoint <= 100000)
                {
                    if (LanternMoonWave != 25)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 25:千年桔树妖"), messageColor);
                        NPC.NewNPC((int)Player.Center.X, (int)Player.Center.Y - 500, Mod.Find<ModNPC>("AncientTangerineTreeHat").Type, 0, 0, 0, 0, 0, 255);
                        NPC.NewNPC((int)Player.Center.X, (int)Player.Center.Y - 495, Mod.Find<ModNPC>("AncientTangerineTreeHatSHadow").Type, 0, 0, 0, 0, 0, 255);
                        NPC.NewNPC((int)Player.Center.X, (int)Player.Center.Y, Mod.Find<ModNPC>("AncientTangerineTree").Type, 0, 0, 0, 0, 0, 255);
                        NPC.NewNPC((int)Player.Center.X, (int)Player.Center.Y - 145, Mod.Find<ModNPC>("AncientTangerineTreeEye").Type, 0, 0, 0, 0, 0, 255);
                        LanternMoonWave = 25;
                    }
                    PerWavePoint = 10000;
                    OldWavePoint = 90000;
                }
                if (LanternMoonPoint >= 100000 && LanternMoonPoint <= 108000)
                {
                    if (LanternMoonWave != 26)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 26:顽童僵尸和钻地喷花"), messageColor);
                        LanternMoonWave = 26;
                    }
                    PerWavePoint = 8000;
                    OldWavePoint = 100000;
                }
                if (LanternMoonPoint >= 108000 && LanternMoonPoint <= 118000)
                {
                    if (LanternMoonWave != 27)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 27:顽童僵尸和钻地喷花"), messageColor);
                        LanternMoonWave = 27;
                    }
                    PerWavePoint = 10000;
                    OldWavePoint = 108000;
                }
                if (LanternMoonPoint > 118000 && LanternMoonPoint <= 130000)
                {
                    if (LanternMoonWave != 28)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 28:顽童僵尸,钻地喷花和花火蝶"), messageColor);
                        LanternMoonWave = 28;
                    }
                    PerWavePoint = 12000;
                    OldWavePoint = 118000;
                }
                if (LanternMoonPoint > 130000 && LanternMoonPoint <= 145000)
                {
                    if (LanternMoonWave != 29)
                    {
                        Color messageColor = Color.MediumPurple;
                        Main.NewText(Language.GetTextValue("波数: 29:顽童僵尸,钻地喷花,花火蝶和火焰风车"), messageColor);
                        LanternMoonWave = 29;
                    }
                    PerWavePoint = 15000;
                    OldWavePoint = 130000;
                }
                if (LanternMoonWave == 1)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("HappinessZombie").Type) < 30 && Main.rand.Next(28) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("HappinessZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("HappinessZombie").Type) < 30 && Main.rand.Next(28) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("HappinessZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 2)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("HappinessZombie").Type) < 30 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("HappinessZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("HappinessZombie").Type) < 30 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("HappinessZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 3)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("PaperCuttingBat").Type) < 15 && Main.rand.Next(15) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("PaperCuttingBat").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("PaperCuttingBat").Type) < 15 && Main.rand.Next(15) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("PaperCuttingBat").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("HappinessZombie").Type) < 15 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("HappinessZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("HappinessZombie").Type) < 15 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("HappinessZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 4)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("PaperCuttingBat").Type) < 20 && Main.rand.Next(10) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("PaperCuttingBat").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("PaperCuttingBat").Type) < 20 && Main.rand.Next(10) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("PaperCuttingBat").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("HappinessZombie").Type) < 20 && Main.rand.Next(15) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("HappinessZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("HappinessZombie").Type) < 20 && Main.rand.Next(15) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("HappinessZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 5)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FloatLantern").Type) < 2 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FloatLantern").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("PaperCuttingBat").Type) < 20 && Main.rand.Next(15) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("PaperCuttingBat").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("HappinessZombie").Type) < 20 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("HappinessZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("HappinessZombie").Type) < 20 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("HappinessZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 6)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FloatLantern").Type) < 4 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FloatLantern").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("PaperCuttingBat").Type) < 20 && Main.rand.Next(15) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("PaperCuttingBat").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("PaperCuttingBat").Type) < 20 && Main.rand.Next(15) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("PaperCuttingBat").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("HappinessZombie").Type) < 20 && Main.rand.Next(15) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("HappinessZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("HappinessZombie").Type) < 20 && Main.rand.Next(15) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("HappinessZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 7)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("PaperCuttingBat").Type) < 50 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("PaperCuttingBat").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("PaperCuttingBat").Type) < 50 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("PaperCuttingBat").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 8)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FloatLantern").Type) < 20 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FloatLantern").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FloatLantern").Type) < 20 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FloatLantern").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 9)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("RedPackBomber").Type) < 6 && Main.rand.Next(120) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("RedPackBomber").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FloatLantern").Type) < 6 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FloatLantern").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("RedPackBomber").Type) < 6 && Main.rand.Next(120) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("RedPackBomber").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FloatLantern").Type) < 6 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FloatLantern").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("PaperCuttingBat").Type) < 20 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("PaperCuttingBat").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("HappinessZombie").Type) < 20 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("HappinessZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("HappinessZombie").Type) < 20 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("HappinessZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 10)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("RedPackBomber").Type) < 8 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("RedPackBomber").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FloatLantern").Type) < 8 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FloatLantern").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("RedPackBomber").Type) < 8 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("RedPackBomber").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FloatLantern").Type) < 8 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FloatLantern").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("PaperCuttingBat").Type) < 20 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("PaperCuttingBat").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("PaperCuttingBat").Type) < 20 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("PaperCuttingBat").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("HappinessZombie").Type) < 14 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("HappinessZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("HappinessZombie").Type) < 14 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("HappinessZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 11)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("RedPackBomber").Type) < 10 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("RedPackBomber").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FloatLantern").Type) < 10 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FloatLantern").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("RedPackBomber").Type) < 10 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("RedPackBomber").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FloatLantern").Type) < 10 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FloatLantern").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("PaperCuttingBat").Type) < 20 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("PaperCuttingBat").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("PaperCuttingBat").Type) < 20 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("PaperCuttingBat").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 12)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("RedPackBomber").Type) < 10 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("RedPackBomber").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FloatLantern").Type) < 10 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FloatLantern").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("RedPackBomber").Type) < 10 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("RedPackBomber").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FloatLantern").Type) < 10 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FloatLantern").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("PaperCuttingBat").Type) < 20 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("PaperCuttingBat").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("PaperCuttingBat").Type) < 20 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("PaperCuttingBat").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LanternSprite").Type) < 10 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("LanternSprite").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LanternSprite").Type) < 10 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("LanternSprite").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 13)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("RedPackBomber").Type) < 10 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("RedPackBomber").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FloatLantern").Type) < 10 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FloatLantern").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("RedPackBomber").Type) < 10 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("RedPackBomber").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FloatLantern").Type) < 10 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FloatLantern").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("PaperCuttingBat").Type) < 20 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("PaperCuttingBat").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("PaperCuttingBat").Type) < 20 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("PaperCuttingBat").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LanternSprite").Type) < 10 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("LanternSprite").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LanternSprite").Type) < 10 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("LanternSprite").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("HappinessZombie").Type) < 14 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("HappinessZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("HappinessZombie").Type) < 14 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("HappinessZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 14)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("RedPackBomber").Type) < 24 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("RedPackBomber").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FloatLantern").Type) < 24 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FloatLantern").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LanternSprite").Type) < 24 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("LanternSprite").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("RedPackBomber").Type) < 24 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("RedPackBomber").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FloatLantern").Type) < 24 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FloatLantern").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LanternSprite").Type) < 24 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("LanternSprite").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 16)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime1").Type) < 6 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("MilkSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime1").Type) < 6 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("MilkSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime1").Type) < 6 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("StrawberrySlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime1").Type) < 6 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("StrawberrySlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 17)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("MilkSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("MilkSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("StrawberrySlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("StrawberrySlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("AppleSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("AppleSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("AppleSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("AppleSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("OrangeSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("OrangeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("OrangeSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("OrangeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 18)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("MilkSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("MilkSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("StrawberrySlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("StrawberrySlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("AppleSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("AppleSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("AppleSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("AppleSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("OrangeSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("OrangeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("OrangeSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("OrangeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("ChocolateSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("ChocolateSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("ChocolateSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("ChocolateSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("GrapeSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("GrapeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("GrapeSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("GrapeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LemonSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("LemonSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LemonSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("LemonSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 19)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("MilkSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("MilkSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("StrawberrySlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("StrawberrySlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("AppleSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("AppleSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("AppleSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("AppleSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("OrangeSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("OrangeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("OrangeSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("OrangeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("ChocolateSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("ChocolateSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("ChocolateSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("ChocolateSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("GrapeSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("GrapeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("GrapeSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("GrapeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LemonSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("LemonSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LemonSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("LemonSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("VerdantTangerine").Type) < 5 && Main.rand.Next(120) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y + Main.rand.Next(100, 400), Mod.Find<ModNPC>("VerdantTangerine").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("VerdantTangerine").Type) < 5 && Main.rand.Next(120) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y + Main.rand.Next(100, 400), Mod.Find<ModNPC>("VerdantTangerine").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 20)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("MilkSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("MilkSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("StrawberrySlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("StrawberrySlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("AppleSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("AppleSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("AppleSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("AppleSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("OrangeSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("OrangeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("OrangeSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("OrangeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("ChocolateSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("ChocolateSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("ChocolateSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("ChocolateSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("GrapeSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("GrapeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("GrapeSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("GrapeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LemonSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("LemonSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LemonSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("LemonSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("VerdantTangerine").Type) < 8 && Main.rand.Next(90) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y + Main.rand.Next(100, 400), Mod.Find<ModNPC>("VerdantTangerine").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("VerdantTangerine").Type) < 8 && Main.rand.Next(90) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y + Main.rand.Next(100, 400), Mod.Find<ModNPC>("VerdantTangerine").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 21)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("MilkSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("MilkSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("StrawberrySlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("StrawberrySlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("AppleSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("AppleSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("AppleSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("AppleSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("OrangeSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("OrangeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("OrangeSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("OrangeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("ChocolateSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("ChocolateSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("ChocolateSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("ChocolateSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("GrapeSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("GrapeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("GrapeSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("GrapeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LemonSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("LemonSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LemonSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("LemonSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("VerdantTangerine").Type) < 3 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y + Main.rand.Next(100, 400), Mod.Find<ModNPC>("VerdantTangerine").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("VerdantTangerine").Type) < 3 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y + Main.rand.Next(100, 400), Mod.Find<ModNPC>("VerdantTangerine").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LachangGhost").Type) < 3 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y + Main.rand.Next(100, 400), Mod.Find<ModNPC>("LachangGhost").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LachangGhost").Type) < 3 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y + Main.rand.Next(100, 400), Mod.Find<ModNPC>("LachangGhost").Type, 0, 0, 0, 0, 0, 255);
                    }

                }
                if (LanternMoonWave == 22)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("MilkSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("MilkSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("StrawberrySlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("StrawberrySlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("AppleSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("AppleSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("AppleSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("AppleSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("OrangeSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("OrangeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("OrangeSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("OrangeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("ChocolateSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("ChocolateSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("ChocolateSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("ChocolateSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("GrapeSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("GrapeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("GrapeSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("GrapeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LemonSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("LemonSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LemonSlime1").Type) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("LemonSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("VerdantTangerine").Type) < 3 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y + Main.rand.Next(100, 400), Mod.Find<ModNPC>("VerdantTangerine").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("VerdantTangerine").Type) < 3 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y + Main.rand.Next(100, 400), Mod.Find<ModNPC>("VerdantTangerine").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LachangGhost").Type) < 6 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y + Main.rand.Next(100, 400), Mod.Find<ModNPC>("LachangGhost").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LachangGhost").Type) < 6 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y + Main.rand.Next(100, 400), Mod.Find<ModNPC>("LachangGhost").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("BumpTangyuan").Type) < 6 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("BumpTangyuan").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("BumpTangyuan").Type) < 6 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("BumpTangyuan").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 23)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("MilkSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("MilkSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("StrawberrySlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("StrawberrySlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("AppleSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("AppleSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("AppleSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("AppleSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("OrangeSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("OrangeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("OrangeSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("OrangeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("ChocolateSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("ChocolateSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("ChocolateSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("ChocolateSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("GrapeSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("GrapeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("GrapeSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("GrapeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LemonSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("LemonSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LemonSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("LemonSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("VerdantTangerine").Type) < 3 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y + Main.rand.Next(100, 400), Mod.Find<ModNPC>("VerdantTangerine").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("VerdantTangerine").Type) < 3 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y + Main.rand.Next(100, 400), Mod.Find<ModNPC>("VerdantTangerine").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LachangGhost").Type) < 7 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y + Main.rand.Next(100, 400), Mod.Find<ModNPC>("LachangGhost").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LachangGhost").Type) < 7 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y + Main.rand.Next(100, 400), Mod.Find<ModNPC>("LachangGhost").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("BumpTangyuan").Type) < 8 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("BumpTangyuan").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("BumpTangyuan").Type) < 8 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("BumpTangyuan").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("OrchidSprite").Type) < 3 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("OrchidSprite").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("OrchidSprite").Type) < 3 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("OrchidSprite").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 24)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("MilkSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("MilkSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("StrawberrySlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("StrawberrySlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("AppleSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("AppleSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("AppleSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("AppleSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("OrangeSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("OrangeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("OrangeSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("OrangeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("ChocolateSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("ChocolateSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("ChocolateSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("ChocolateSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("GrapeSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("GrapeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("GrapeSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("GrapeSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LemonSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("LemonSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LemonSlime1").Type) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("LemonSlime1").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("VerdantTangerine").Type) < 5 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y + Main.rand.Next(100, 400), Mod.Find<ModNPC>("VerdantTangerine").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("VerdantTangerine").Type) < 5 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y + Main.rand.Next(100, 400), Mod.Find<ModNPC>("VerdantTangerine").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LachangGhost").Type) < 9 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y + Main.rand.Next(100, 400), Mod.Find<ModNPC>("LachangGhost").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("LachangGhost").Type) < 9 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y + Main.rand.Next(100, 400), Mod.Find<ModNPC>("LachangGhost").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("BumpTangyuan").Type) < 10 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("BumpTangyuan").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("BumpTangyuan").Type) < 10 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("BumpTangyuan").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("OrchidSprite").Type) < 5 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("OrchidSprite").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("OrchidSprite").Type) < 5 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("OrchidSprite").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 26)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("DiggingErrupt").Type) < 15 && Main.rand.Next(65) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("DiggingErrupt").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("DiggingErrupt").Type) < 15 && Main.rand.Next(65) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("DiggingErrupt").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StubbronChildZombie").Type) < 15 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("StubbronChildZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StubbronChildZombie").Type) < 15 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("StubbronChildZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 27)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("DiggingErrupt").Type) < 18 && Main.rand.Next(50) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("DiggingErrupt").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("DiggingErrupt").Type) < 18 && Main.rand.Next(50) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("DiggingErrupt").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StubbronChildZombie").Type) < 18 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("StubbronChildZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StubbronChildZombie").Type) < 18 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("StubbronChildZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 28)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("DiggingErrupt").Type) < 15 && Main.rand.Next(50) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("DiggingErrupt").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("DiggingErrupt").Type) < 15 && Main.rand.Next(50) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("DiggingErrupt").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StubbronChildZombie").Type) < 15 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("StubbronChildZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StubbronChildZombie").Type) < 15 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("StubbronChildZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FireFly").Type) < 5 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FireFly").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FireFly").Type) < 5 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FireFly").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FireFlyGreen").Type) < 5 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FireFlyGreen").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FireFlyGreen").Type) < 5 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FireFlyGreen").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 29)
                {
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("DiggingErrupt").Type) < 15 && Main.rand.Next(50) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("DiggingErrupt").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("DiggingErrupt").Type) < 15 && Main.rand.Next(50) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - Main.rand.Next(100, 400), Mod.Find<ModNPC>("DiggingErrupt").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StubbronChildZombie").Type) < 15 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("StubbronChildZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("StubbronChildZombie").Type) < 15 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("StubbronChildZombie").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FireFly").Type) < 7 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FireFly").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FireFly").Type) < 7 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FireFly").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FireFlyGreen").Type) < 7 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FireFlyGreen").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("FireFlyGreen").Type) < 7 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("FireFlyGreen").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("BurningWindmill").Type) < 4 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X - 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("BurningWindmill").Type, 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("BurningWindmill").Type) < 4 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)Player.Center.X + 1000, (int)Player.Center.Y - 300, Mod.Find<ModNPC>("BurningWindmill").Type, 0, 0, 0, 0, 0, 255);
                    }
                }
                Main.moonTexture[0] = (Mod.GetTexture("UIImages/LanternMoon"));
                Main.moonTexture[1] = (Mod.GetTexture("UIImages/LanternMoon"));
                Main.moonTexture[2] = (Mod.GetTexture("UIImages/LanternMoon"));               
            }
            if (MythWorld.Myth)
            {
                YinYangLife.Open = true;
            }
            else
            {
                YinYangLife.Open = false;
            }
            base.PreUpdate();
        }
        public int FREEZE = 0;
        public int Absorb = 0;
        public override void OnEnterWorld(Player player)
        {
            //base.OnEnterWorld(player);
            if (MythWorld.Myth)
            {
                YinYangLife.Open = true;
                //Stones.Open = true;
                //base.OnEnterWorld(player);
            }
            else
            {
                YinYangLife.Open = false;
            }
        }
        public int lavaI = 0;
        public int VIm = 0;
        public bool BanTra = false;
        public int Ry = 0;
        public bool BanTraBall = true;
        //123456
        public override void UpdateBiomes()
        {
            if (Ry > 0)
            {
                Ry -= 1;
            }
            if (Ry <= 0)
            {
                Ry = 0;
            }
            if (ZoneVolcano && VIm > 0)
            {
                VIm -= 1;
            }
            if(VIm <= 0)
            {
                VIm = 0;
            }
            if (Main.worldName == worldnm)
            {
                if(BanTraBall)
                {
                    BanTra = true;
                    Player.AddBuff(Mod.Find<ModBuff>("秩序之锁").Type, 2);
                }
                else
                {
                    BanTra = false;
                }
                if(lavaI > 0)
                {
                    lavaI -= 1;
                }
                if(lavaI <= 0)
                {
                    lavaI = 0;
                }
                if (false)
                {
                    Player.lastDeathPostion = Player.Center;
                    Player.lastDeathTime = DateTime.Now;
                    Player.showLastDeath = true;
                    if (Main.myPlayer == Player.whoAmI)
                    {
                        Player.lostCoinString = Main.ValueToCoins(Player.lostCoins);
                    }
                    SoundEngine.PlaySound(SoundID.PlayerKilled, Player.position);
                    Player.headVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
                    Player.bodyVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
                    Player.legVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
                    Player.headVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
                    Player.bodyVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
                    Player.legVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
                    if (Player.stoned)
                    {
                        Player.headPosition = Vector2.Zero;
                        Player.bodyPosition = Vector2.Zero;
                        Player.legPosition = Vector2.Zero;
                    }
                    for (int j = 0; j < 100; j++)
                    {
                        Dust.NewDust(Player.position, Player.width, Player.height, 205, 0f, -2f, 0, default(Color), 1f);
                    }
                    Player.statLife = 0;
                    Player.dead = true;
                    Player.respawnTimer = 600;
                    Player.head = -1;
                    Player.body = -1;
                    Player.legs = -1;
                    Player.handon = -1;
                    Player.handoff = -1;
                    Player.back = -1;
                    Player.front = -1;
                    Player.shoe = -1;
                    Player.waist = -1;
                    Player.shield = -1;
                    Player.neck = -1;
                    Player.face = -1;
                    Player.balloon = -1;
                    Player.mount.Dismount(Player);
                    if (Main.expertMode)
                    {
                        Player.respawnTimer = (int)((double)Player.respawnTimer * 1.5);
                    }
                    Player.immuneAlpha = 0;
                    Player.palladiumRegen = false;
                    Player.iceBarrier = false;
                    Player.crystalLeaf = false;
                    if (Player.whoAmI == Main.myPlayer && Player.difficulty == 0)
                    {
                        Player.DropCoins();
                    }
                    else if (Player.difficulty == 1)
                    {
                        Player.DropItems();
                    }
                    else if (Player.difficulty == 2)
                    {
                        Player.DropItems();
                        Player.KillMeForGood();
                    }
                }
                if (ZoneVolcano)
                {
                    if (Main.rand.Next(1500) == 142 && Main.tile[(int)(Player.position.X / 16), (int)(Player.position.Y / 16)].WallType == Mod.Find<ModWall>("玄武岩墙").Type)
                    {
                        Projectile.NewProjectile(Main.screenPosition.X + Main.rand.NextFloat(Main.screenWidth), Main.screenPosition.Y - Main.rand.Next(150, 400), 0, 1, base.Mod.Find<ModProjectile>("熔岩滚石").Type, 300, 8, Main.myPlayer, 10, 0f);
                    }
                }
                if (ZoneVolcano && VIm == 0)
                {
                    Player.mount.Dismount(Player);
                    Player.wingTime = 0;
                    Player.AddBuff(Mod.Find<ModBuff>("高温窒息").Type, 2);
                    //player.AddBuff(199, 2);
                }
                if (ZoneCoral)
                {
                    if (Main.rand.Next(0, 440) == 1)
                    {
                        //Projectile.NewProjectile(Main.screenPosition.X - 36, Main.screenPosition.Y + Main.screenHeight / 2, 0, 2, base.mod.ProjectileType("珊瑚"), 0, 0, Main.myPlayer, 10, 0f);
                        //Projectile.NewProjectile(Main.screenPosition.X + Main.screenWidth + 36, Main.screenPosition.Y + Main.screenHeight / 2, 0, 2, base.mod.ProjectileType("珊瑚"), 0, 0, Main.myPlayer, 10, 0f);
                    }
                    if (Main.rand.Next(0, 440) == 1)
                    {
                        //Projectile.NewProjectile(Main.screenPosition.X - 36, Main.screenPosition.Y + Main.screenHeight / 2, 0, 2, base.mod.ProjectileType("珊瑚1"), 0, 0, Main.myPlayer, 10, 0f);
                        //Projectile.NewProjectile(Main.screenPosition.X + Main.screenWidth + 36, Main.screenPosition.Y + Main.screenHeight / 2, 0, 2, base.mod.ProjectileType("珊瑚1"), 0, 0, Main.myPlayer, 10, 0f);
                    }
                    if (Main.rand.Next(0, 4) == 1 && !ZoneVolcano && Player.position.X / 16f < Main.maxTilesX / 4)
                    {
                        Projectile.NewProjectile(Main.screenPosition.X - 36, Main.screenPosition.Y + Main.screenHeight / 2, 0, 2, base.Mod.Find<ModProjectile>("珊瑚random").Type, 0, 0, Main.myPlayer, 10, 0f);
                        Projectile.NewProjectile(Main.screenPosition.X + Main.screenWidth + 36, Main.screenPosition.Y + Main.screenHeight / 2, 0, 2, base.Mod.Find<ModProjectile>("珊瑚random").Type, 0, 0, Main.myPlayer, 10, 0f);
                    }
                }
                if (Player.Center.X / 16f > Main.maxTilesX * 0.6f && Player.Center.X / 16f < Main.maxTilesX * 0.9f)
                {
                    ZoneVolcano = true;
                }
                else
                {
                    ZoneVolcano = false;
                }
                if (Player.Center.X / 16f > Main.maxTilesX * 0.56f && Player.Center.X / 16f < Main.maxTilesX * 0.6f)
                {
                    ZoneRedTree = true;
                }
                else
                {
                    ZoneRedTree = false;
                }
                if (Player.Center.X / 16f > Main.maxTilesX * 0.9f)
                {
                    ZoneTown = true;
                }
                else
                {
                    ZoneTown = false;
                }
                if (Player.wet)
                {
                    ZoneCoral = true;
                }
                else
                {
                    ZoneCoral = false;
                }
                if (!ZoneVolcano && !ZoneRedTree)
                {
                    ZoneOcean = true;
                    if(Main.maxTilesX == 4200)
                    {
                        if (Player.Center.Y / 16f > Main.maxTilesY * 0.27f)
                        {
                            ZoneDeepocean = true;
                        }
                        else
                        {
                            ZoneDeepocean = false;
                        }
                    }
                    if (Main.maxTilesX == 6400)
                    {
                        if (Player.Center.Y / 16f > Main.maxTilesY * 0.35f)
                        {
                            ZoneDeepocean = true;
                        }
                        else
                        {
                            ZoneDeepocean = false;
                        }
                    }
                }
                else
                {
                    ZoneOcean = false;
                    ZoneDeepocean = false;
                    ZoneCoral = false;
                }
            }
        }
        public override bool CustomBiomesMatch(Player other)
        {
            MythPlayer modOther = other.GetModPlayer<MythPlayer>();
            return ZoneVolcano == modOther.ZoneVolcano || ZoneDeepocean == modOther.ZoneDeepocean || ZoneRedTree == modOther.ZoneRedTree || ZoneTown == modOther.ZoneTown;
        }
        public override void CopyCustomBiomesTo(Player other)
        {
            MythPlayer modOther = other.GetModPlayer<MythPlayer>();
            modOther.ZoneVolcano = ZoneVolcano;
            modOther.ZoneRedTree = ZoneRedTree;
            modOther.ZoneOcean = ZoneOcean;
            modOther.ZoneDeepocean = ZoneDeepocean;
            modOther.ZoneCoral = ZoneCoral;
            modOther.ZoneTown = ZoneTown;
        }

        public override void SendCustomBiomes(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = ZoneVolcano;
            flags[1] = ZoneOcean;
            flags[2] = ZoneDeepocean;
            flags[3] = ZoneCoral;
            flags[4] = ZoneRedTree;
            flags[5] = ZoneTown;
            writer.Write(flags);
        }
        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            ZoneVolcano = flags[0];
            ZoneOcean = flags[1];
            ZoneDeepocean = flags[2];
            ZoneCoral = flags[3];
            ZoneRedTree = flags[4];
            ZoneTown = flags[5];
        }
        public override Texture2D GetMapBackgroundImage()
        {
            if (ZoneVolcano)
            {
                return Mod.GetTexture("VolcanoBG");
            }
            if (ZoneRedTree)
            {
                return Mod.GetTexture("RedTreeBG");
            }
            if (ZoneOcean && !Player.wet)
            {
                return Mod.GetTexture("OceanBG");
            }
            if (ZoneOcean && Player.wet)
            {
                return Mod.GetTexture("CoralBG");
            }
            if (ZoneTown)
            {
                return Mod.GetTexture("CoralBG");/*Need Change*/
            }
            return null;
        }
        public override void UpdateBadLifeRegen()
        {
            if (this.ExPoi)
            {
                if (base.Player.lifeRegen > 0)
                {
                    base.Player.lifeRegen = 0;
                }
                base.Player.lifeRegenTime = 0;
                base.Player.lifeRegen -= 150;
            }
            if (this.StarPoi2)
            {
                if (base.Player.lifeRegen > 0)
                {
                    base.Player.lifeRegen = 0;
                }
                base.Player.lifeRegenTime = 0;
                base.Player.lifeRegen -= 40;
            }
            if (this.StarPoi3)
            {
                if (base.Player.lifeRegen > 0)
                {
                    base.Player.lifeRegen = 0;
                }
                base.Player.lifeRegenTime = 0;
                base.Player.lifeRegen -= 150;
            }
        }
        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            bool flag = false;
            bool flag1 = false;
            if (mplayer.ZoneVolcano)
            {
                flag = true;
            }
            if (mplayer.ZoneOcean)
            {
                flag1 = true;
            }
            if (junk && flag1 && poolSize >= 150)
            {
                if (power < 40)
                {
                    switch (Main.rand.Next(3))
                    {
                        case 0:
                            caughtType = base.Mod.Find<ModItem>("锈铁剑").Type;
                            break;
                        case 1:
                            caughtType = base.Mod.Find<ModItem>("马尾藻").Type;
                            break;
                        case 2:
                            caughtType = base.Mod.Find<ModItem>("空瓶").Type;
                            break;
                    }
                }
                return;
            }
            if (power >= 20 && power <= 40 && poolSize >= 150)
            {
                if (Main.rand.Next(15) == 0 && power < 80)
                {
                    switch (Main.rand.Next(3))
                    {
                        case 0:
                            caughtType = base.Mod.Find<ModItem>("锈铁剑").Type;
                            break;
                        case 1:
                            caughtType = base.Mod.Find<ModItem>("马尾藻").Type;
                            break;
                        case 2:
                            caughtType = base.Mod.Find<ModItem>("空瓶").Type;
                            break;
                    }
                }
                if (power >= 60 && poolSize >= 150 && questFish == base.Mod.Find<ModItem>("鱿鱼").Type)
                {
                    caughtType = base.Mod.Find<ModItem>("鱿鱼").Type;
                    if (power >= 70 && Main.rand.Next(25) == 0 && power < 440)
                    {
                        caughtType = base.Mod.Find<ModItem>("发光磷虾").Type;
                    }
                    if (power >= 80)
                    {
                        if (power >= 70 && Main.rand.Next(25) == 0 && power < 240)
                        {
                            caughtType = base.Mod.Find<ModItem>("电鳐").Type;
                        }
                    }
                }
            }
        }
        public override void OnRespawn(Player player)
        {
            if(ZoneOcean || ZoneVolcano || ZoneDeepocean || ZoneCoral)
            {
                player.SpawnX = 160;
                player.SpawnY = (int)((Main.maxTilesY / 10f + 60) * 16f) ;
                player.FindSpawn();
            }
        }
        public override void UpdateDead()
        {
            if (ZoneOcean || ZoneVolcano || ZoneDeepocean || ZoneCoral)
            {
                Player.SpawnX = 160;
                Player.SpawnY = (int)((Main.maxTilesY / 10f + 60) * 16f);
                Player.FindSpawn();
            }
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (Player.name == "万象元素")
            {
                Player.Spawn();
                Player.respawnTimer = 0;
                if (Player.statLifeMax2 <= 200)
                {
                    Player.statLife = 100;
                }
                else
                {
                    Player.statLife = Player.statLifeMax2 / 2;
                }
                Player.immuneTime = 120;
                mplayer.YinLife = 30;
                mplayer.YangLife = 30;
            }
        }
        public static float FeatherCount = 0;
        public override void PostUpdateMiscEffects()
        {
            Misspossibility = 0;
            if (ZoneVolcano && !FinalLava)
            {
                if (LavaCryst <= 60)
                {
                    Player.statLifeMax2 += LavaCryst * 5;
                }
                else
                {
                    Player.statLifeMax2 += 300;
                }
            }
            if (FinalLava)
            {
                if (LavaCryst <= 60)
                {
                    Player.statLifeMax2 += LavaCryst * 5;
                }
                else
                {
                    Player.statLifeMax2 += 300;
                }
            }
            for(int i = 0;i < 40;i++)
            {
                if (CrystalEffectMain.MaxFea >= i)
                {
                    if (CrystalEffectMain.fea[i] == 320)
                    {
                        Misspossibility += 1;
                        Player.moveSpeed += 0.25f;
                        Player.wingTimeMax += 30;
                        Player.jumpSpeedBoost += 0.75f;
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("BirdFeather").Type)
                    {
                        Player.moveSpeed += 0.1f;
                        Player.wingTimeMax += 20;
                        Player.jumpSpeedBoost += 0.3f;
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("BlueBirdFeather").Type)
                    {
                        Player.moveSpeed += 0.1f;
                        Player.wingTimeMax += 20;
                        Player.statManaMax2 += 20;
                        Player.jumpSpeedBoost += 0.3f;
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("RedBirdFeather").Type)
                    {
                        Player.moveSpeed += 0.1f;
                        Player.wingTimeMax += 20;
                        Player.statLifeMax2 += 10;
                        Player.jumpSpeedBoost += 0.3f;
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("GoldBirdFeather").Type)
                    {
                        Misspossibility += 1;
                        Player.moveSpeed += 0.15f;
                        Player.wingTimeMax += 40;
                        Player.statLifeMax2 += 10;
                        Player.statManaMax2 += 20;
                        Player.jumpSpeedBoost += 0.45f;
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("BeeFeather").Type)
                    {
                        Misspossibility += 3;
                        Player.moveSpeed += 0.24f;
                        Player.wingTimeMax += 40;
                        Player.jumpSpeedBoost += 0.72f;
                    }
                    if (CrystalEffectMain.fea[i] == 1516)
                    {
                        Misspossibility += 3;
                        Player.moveSpeed += 0.6f;
                        Player.wingTimeMax += 60;
                        Player.jumpSpeedBoost += 1.8f;
                    }
                    if (CrystalEffectMain.fea[i] == 1517)
                    {
                        Misspossibility += 2;
                        Player.moveSpeed += 0.6f;
                        Player.wingTimeMax += 60;
                        Player.jumpSpeedBoost += 1.8f;
                    }
                    if (CrystalEffectMain.fea[i] == 1518)
                    {
                        Misspossibility += 2;
                        Player.moveSpeed += 0.6f;
                        Player.wingTimeMax += 60;
                        Player.jumpSpeedBoost += 1.8f;
                    }
                    if (CrystalEffectMain.fea[i] == 1519)
                    {
                        Misspossibility += 2;
                        Player.moveSpeed += 0.6f;
                        Player.wingTimeMax += 60;
                        Player.jumpSpeedBoost += 1.8f;
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("SnowFeather").Type)
                    {
                        Misspossibility += 1;
                        Player.moveSpeed += 0.16f;
                        Player.wingTimeMax += 30;
                        Player.jumpSpeedBoost += 0.48f;
                        Player.statLifeMax2 += 10;
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("TwilightFeather").Type)
                    {
                        Misspossibility += 1;
                        Player.moveSpeed += 0.4f;
                        Player.wingTimeMax += 54;
                        Player.jumpSpeedBoost += 1.20f;
                        Player.statLifeMax2 += 30;
                        Player.lifeRegen += 3;
                        Player.manaRegen += 3;
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("VoidFeather").Type)
                    {
                        Misspossibility += 10;
                        Player.moveSpeed += 1.1f;
                        Player.wingTimeMax += 144;
                        Player.jumpSpeedBoost += 3.3f;
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("SolarFeather").Type)
                    {
                        Misspossibility += 12;
                        Player.moveSpeed += 2f;
                        Player.wingTimeMax += 180;
                        Player.jumpSpeedBoost += 6f;
                        Player.statLifeMax2 += 100;
                        Player.statDefense += 15;
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("StardustFeather").Type)
                    {
                        Misspossibility += 12;
                        Player.moveSpeed += 2f;
                        Player.wingTimeMax += 180;
                        Player.jumpSpeedBoost += 6f;
                        Player.maxMinions += 5;
                        Player.statManaMax2 += 100;
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("DarkFeather").Type)
                    {
                        Misspossibility += 2;
                        Player.moveSpeed += 0.16f;
                        Player.wingTimeMax += 30;
                        Player.jumpSpeedBoost += 0.48f;
                        Player.GetCritChance(DamageClass.Generic) += 3;
                        Player.GetCritChance(DamageClass.Magic) += 3;
                        Player.GetCritChance(DamageClass.Throwing) += 3;
                        Player.GetCritChance(DamageClass.Ranged) += 3;
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("CrimsonFeather").Type)
                    {
                        Misspossibility += 2;
                        Player.moveSpeed += 0.34f;
                        Player.wingTimeMax += 48;
                        Player.jumpSpeedBoost += 1.02f;
                        Player.GetCritChance(DamageClass.Generic) += 3;
                        Player.GetCritChance(DamageClass.Magic) += 3;
                        Player.GetCritChance(DamageClass.Throwing) += 3;
                        Player.GetCritChance(DamageClass.Ranged) += 3;
                        Player.lifeRegen += 3;
                        if (Player.ZoneCrimson)
                        {
                            Misspossibility += 2;
                            Player.moveSpeed += 0.34f;
                            Player.wingTimeMax += 48;
                            Player.jumpSpeedBoost += 1.02f;
                            Player.GetCritChance(DamageClass.Generic) += 3;
                            Player.GetCritChance(DamageClass.Magic) += 3;
                            Player.GetCritChance(DamageClass.Throwing) += 3;
                            Player.GetCritChance(DamageClass.Ranged) += 3;
                            Player.lifeRegen += 3;
                        }
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("CorruptFeather").Type)
                    {
                        Misspossibility += 3;
                        Player.moveSpeed += 0.34f;
                        Player.wingTimeMax += 48;
                        Player.jumpSpeedBoost += 1.02f;
                        Player.GetCritChance(DamageClass.Generic) += 2;
                        Player.GetCritChance(DamageClass.Magic) += 2;
                        Player.GetCritChance(DamageClass.Throwing) += 2;
                        Player.GetCritChance(DamageClass.Ranged) += 2;
                        Player.statDefense += 4;
                        if (Player.ZoneCrimson)
                        {
                            Misspossibility += 3;
                            Player.moveSpeed += 0.34f;
                            Player.wingTimeMax += 48;
                            Player.jumpSpeedBoost += 1.02f;
                            Player.GetCritChance(DamageClass.Generic) += 2;
                            Player.GetCritChance(DamageClass.Magic) += 2;
                            Player.GetCritChance(DamageClass.Throwing) += 2;
                            Player.GetCritChance(DamageClass.Ranged) += 2;
                            Player.statDefense += 4;
                        }
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("GhostFeather").Type)
                    {
                        Misspossibility += 5;
                        Player.moveSpeed += 1f;
                        Player.wingTimeMax += 108;
                        Player.jumpSpeedBoost += 3f;
                        Player.GetCritChance(DamageClass.Generic) += 7;
                        Player.GetCritChance(DamageClass.Magic) += 7;
                        Player.GetCritChance(DamageClass.Throwing) += 7;
                        Player.GetCritChance(DamageClass.Ranged) += 7;
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("GoldFeather").Type)
                    {
                        Misspossibility += 3;
                        Player.moveSpeed += 0.27f;
                        Player.wingTimeMax += 48;
                        Player.jumpSpeedBoost += 0.81f;
                        Player.statLifeMax2 += 30;
                        Player.statManaMax2 += 30;
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("LeaveFeather").Type)
                    {
                        Misspossibility += 2;
                        Player.moveSpeed += 0.6f;
                        Player.wingTimeMax += 60;
                        Player.jumpSpeedBoost += 1.8f;
                        Player.lifeRegen += 3;
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("LeaveFeather").Type)
                    {
                        Misspossibility += 2;
                        Player.moveSpeed += 0.6f;
                        Player.wingTimeMax += 60;
                        Player.jumpSpeedBoost += 1.8f;
                        Player.lifeRegen += 3;
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("LightingFeather").Type)
                    {
                        Misspossibility += 3;
                        Player.moveSpeed += 0.84f;
                        Player.wingTimeMax += 78;
                        Player.jumpSpeedBoost += 2.52f;
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("DarkGoldFeather").Type)
                    {
                        Misspossibility += 4;
                        Player.moveSpeed += 1.3f;
                        Player.wingTimeMax += 180;
                        Player.jumpSpeedBoost += 3.9f;
                        Player.GetCritChance(DamageClass.Generic) += 4;
                        Player.GetCritChance(DamageClass.Magic) += 4;
                        Player.GetCritChance(DamageClass.Throwing) += 4;
                        Player.GetCritChance(DamageClass.Ranged) += 4;
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("PoisonFeather").Type)
                    {
                        Misspossibility += 2;
                        Player.moveSpeed += 0.5f;
                        Player.wingTimeMax += 30;
                        Player.jumpSpeedBoost += 1.5f;
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("RainbowFeather").Type)
                    {
                        Misspossibility += 1;
                        Player.moveSpeed += 0.7f;
                        Player.wingTimeMax += 48;
                        Player.jumpSpeedBoost += 2.1f;
                        Player.GetCritChance(DamageClass.Generic) += 1;
                        Player.GetCritChance(DamageClass.Magic) += 1;
                        Player.GetCritChance(DamageClass.Throwing) += 1;
                        Player.GetCritChance(DamageClass.Ranged) += 1;
                        Player.GetDamage(DamageClass.Melee) += 0.01f;
                        Player.GetDamage(DamageClass.Ranged) += 0.01f;
                        Player.GetDamage(DamageClass.Magic) += 0.01f;
                        Player.GetDamage(DamageClass.Summon) += 0.01f;
                        Player.GetDamage(DamageClass.Throwing) += 0.01f;
                        Player.statLifeMax2 += 10;
                        Player.statManaMax2 += 10;
                        Player.lifeRegen += 1;
                        Player.manaRegen += 1;
                        Player.statDefense += 2;
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("RedSnowFeather").Type)
                    {
                        Misspossibility += 2;
                        Player.moveSpeed += 0.86f;
                        Player.wingTimeMax += 60;
                        Player.jumpSpeedBoost += 2.58f;
                        Player.statLifeMax2 += 40;
                        Player.lifeRegen += 3;
                    }
                    if (CrystalEffectMain.fea[i] == Mod.Find<ModItem>("StarlightFeather").Type)
                    {
                        Misspossibility += 2;
                        Player.moveSpeed += 0.4f;
                        Player.wingTimeMax += 54;
                        Player.jumpSpeedBoost += 1.2f;
                        Player.statLifeMax2 += 50;
                        Player.manaRegen += 4;
                    }
                }
            }
            //Texture2D texture2 = base.mod.GetTexture("UIImages/Mana");
            //Main.manaTexture = texture2;

            //Texture2D texture3 = base.mod.GetTexture("UIImages/MiniMapFrame");
            //Main.miniMapFrameTexture = texture3;
            //Texture2D texture4 = base.mod.GetTexture("UIImages/MiniMapFrame2");
            //Main.miniMapFrame2Texture = texture4;
            //Texture2D texture5 = base.mod.GetTexture("UIImages/Text_Back");
            //Main.textBackTexture = texture5;
            //Texture2D texture6 = base.mod.GetTexture("UIImages/Map");
            //Main.mapTexture = texture6;
            //Texture2D texture7 = base.mod.GetTexture("UIImages/皮肤1/Inventory_Back");
            //Main.inventoryBackTexture = texture7;
            //Texture2D texture8 = base.mod.GetTexture("UIImages/皮肤1/Inventory_Back2");
            // Main.inventoryBack2Texture = texture8;
            //Texture2D texture9 = base.mod.GetTexture("UIImages/皮肤1/Inventory_Back3");
            // Main.inventoryBack3Texture = texture9;
            //Texture2D texture10 = base.mod.GetTexture("UIImages/皮肤1/Inventory_Back4");
            //Main.inventoryBack4Texture = texture10;
            //Texture2D texture11 = base.mod.GetTexture("UIImages/皮肤1/Inventory_Back5");
            //Main.inventoryBack5Texture = texture11;
            //Texture2D texture12 = base.mod.GetTexture("UIImages/皮肤1/Inventory_Back6");
            //Main.inventoryBack6Texture = texture12;
            //Texture2D texture13 = base.mod.GetTexture("UIImages/皮肤1/Inventory_Back7");
            //Main.inventoryBack7Texture = texture13;
            //Texture2D texture14 = base.mod.GetTexture("UIImages/皮肤1/Inventory_Back8");
            //Main.inventoryBack8Texture = texture14;
            //Texture2D texture15 = base.mod.GetTexture("UIImages/皮肤1/Inventory_Back9");
            //Main.inventoryBack9Texture = texture15;
            // Texture2D texture16 = base.mod.GetTexture("UIImages/皮肤1/Inventory_Back10");
            //Main.inventoryBack10Texture = texture16;
            //Texture2D texture17 = base.mod.GetTexture("UIImages/皮肤1/Inventory_Back11");
            //Main.inventoryBack11Texture = texture17;
            //Texture2D texture18 = base.mod.GetTexture("UIImages/皮肤1/Inventory_Back12");
            //Main.inventoryBack12Texture = texture18;
            //Texture2D texture19 = base.mod.GetTexture("UIImages/皮肤1/Inventory_Back13");
            //Main.inventoryBack13Texture = texture19;
            //Texture2D texture20 = base.mod.GetTexture("UIImages/皮肤1/Inventory_Back14");
            //Main.inventoryBack14Texture = texture20;
            //Texture2D texture21 = base.mod.GetTexture("UIImages/皮肤1/Inventory_Back15");
            //Main.inventoryBack15Texture = texture21;
            //Texture2D texture22 = base.mod.GetTexture("UIImages/皮肤1/Inventory_Back16");
            //Main.inventoryBack16Texture = texture22;
            if (MythWorld.Myth && base.Player.whoAmI == Main.myPlayer)
            {
                base.Player.GetDamage(DamageClass.Throwing) += 0.2f;
                base.Player.GetDamage(DamageClass.Ranged) += 0.2f;
                base.Player.GetDamage(DamageClass.Melee) += 0.2f;
                base.Player.GetDamage(DamageClass.Magic) += 0.2f;
                base.Player.GetDamage(DamageClass.Summon) += 0.2f;
            }
            if (Player.HasBuff(Mod.Find<ModBuff>("雨露").Type))
            {
                Player.GetDamage(DamageClass.Magic) *= 1 + Main.maxRaining / 3f;
                Player.GetDamage(DamageClass.Melee) *= 1 + Main.maxRaining / 3f;
                Player.GetDamage(DamageClass.Throwing) *= 1 + Main.maxRaining / 3f;
                Player.GetDamage(DamageClass.Summon) *= 1 + Main.maxRaining / 3f;
                Player.GetDamage(DamageClass.Ranged) *= 1 + Main.maxRaining / 3f;
                Player.lifeRegen += (int)(Main.maxRaining * 5f);
            }
            if (Player.HasBuff(Mod.Find<ModBuff>("嗜血狂暴").Type))
            {
                Player.GetDamage(DamageClass.Magic) *= 1 + Crazyindex * 0.02f;
                Player.GetDamage(DamageClass.Melee) *= 1 + Crazyindex * 0.02f;
                Player.GetDamage(DamageClass.Throwing) *= 1 + Crazyindex * 0.02f;
                Player.GetDamage(DamageClass.Summon) *= 1 + Crazyindex * 0.02f;
                Player.GetDamage(DamageClass.Ranged) *= 1 + Crazyindex * 0.02f;
            }
            if (Duke > 0)
            {
                Misspossibility += 12;
            }
            if (Player.HasBuff(Mod.Find<ModBuff>("Missable").Type))
            {
                Misspossibility += 6;
            }
            if (BeeFeather > 0)
            {
                Misspossibility += 6;
            }
            if (GreenHat)
            {
                Player.GetDamage(DamageClass.Magic) *= 1.06f;
                Player.GetDamage(DamageClass.Melee) *= 1.06f;
                Player.GetDamage(DamageClass.Throwing) *= 1.06f;
                Player.GetDamage(DamageClass.Summon) *= 1.06f;
                Player.GetDamage(DamageClass.Ranged) *= 1.06f;
                Player.GetCritChance(DamageClass.Generic) += 4;
                Player.GetCritChance(DamageClass.Ranged) += 4;
                Player.GetCritChance(DamageClass.Magic) += 4;
                Player.GetCritChance(DamageClass.Throwing) += 4;
            }
            if (LonelyJelly)
            {
                Player.lifeRegen += 5;
            }
            if (BayBerryBubble)
            {
                Player.GetDamage(DamageClass.Magic) *= 1.13f;
                Player.GetDamage(DamageClass.Melee) *= 1.13f;
                Player.GetDamage(DamageClass.Throwing) *= 1.13f;
                Player.GetDamage(DamageClass.Summon) *= 1.13f;
                Player.GetDamage(DamageClass.Ranged) *= 1.13f;
            }
            if (B25)
            {
                Player.GetDamage(DamageClass.Magic) *= 1.19f;
                Player.GetDamage(DamageClass.Melee) *= 1.19f;
                Player.GetDamage(DamageClass.Throwing) *= 1.19f;
                Player.GetDamage(DamageClass.Summon) *= 1.19f;
                Player.GetDamage(DamageClass.Ranged) *= 1.19f;
            }
            if (BloodyMarie)
            {
                Player.GetCritChance(DamageClass.Generic) += 11;
                Player.GetCritChance(DamageClass.Ranged) += 11;
                Player.GetCritChance(DamageClass.Magic) += 11;
                Player.GetCritChance(DamageClass.Throwing) += 11;
            }
            if (BlueHawaii)
            {
                Player.lifeRegen += 5;
            }
            if (Boluolita)
            {
                Player.lifeRegen += 3;
                Player.manaRegen += 4;
            }
            if (BurningHell)
            {
                Player.statDefense -= 18;
                Player.lifeRegen += 25;
            }
            if (CubaLibre)
            {
                Player.maxRunSpeed *= 1.07f;
            }
            if (DaturaImpression)
            {
                Misspossibility += 6;
            }
            if (DryMartini)
            {
                Misspossibility += 8;
            }
            if (FirstLove)
            {
                Player.GetCritChance(DamageClass.Generic) += 8;
                Player.GetCritChance(DamageClass.Ranged) += 8;
                Player.GetCritChance(DamageClass.Magic) += 8;
                Player.GetCritChance(DamageClass.Throwing) += 8;
            }
            if (GoldFeishi)
            {
                Player.statDefense += 9;
            }
            if (JinglingFeishi)
            {
                Player.GetDamage(DamageClass.Magic) *= 1.04f;
                Player.GetDamage(DamageClass.Melee) *= 1.04f;
                Player.GetDamage(DamageClass.Throwing) *= 1.04f;
                Player.GetDamage(DamageClass.Summon) *= 1.04f;
                Player.GetDamage(DamageClass.Ranged) *= 1.04f;
                Player.GetCritChance(DamageClass.Generic) += 6;
                Player.GetCritChance(DamageClass.Ranged) += 6;
                Player.GetCritChance(DamageClass.Magic) += 6;
                Player.GetCritChance(DamageClass.Throwing) += 6;
            }
            if (JinglingMojituo)
            {
                Player.GetDamage(DamageClass.Magic) *= 1.07f;
                Player.GetDamage(DamageClass.Melee) *= 1.07f;
                Player.GetDamage(DamageClass.Throwing) *= 1.07f;
                Player.GetDamage(DamageClass.Summon) *= 1.07f;
                Player.GetDamage(DamageClass.Ranged) *= 1.07f;
                Player.GetCritChance(DamageClass.Generic) += 3;
                Player.GetCritChance(DamageClass.Ranged) += 3;
                Player.GetCritChance(DamageClass.Magic) += 3;
                Player.GetCritChance(DamageClass.Throwing) += 3;
                Misspossibility += 2;
            }
            if (Lavender)
            {
                Player.GetDamage(DamageClass.Magic) *= 1.11f;
                Player.GetDamage(DamageClass.Melee) *= 1.11f;
                Player.GetDamage(DamageClass.Throwing) *= 1.11f;
                Player.GetDamage(DamageClass.Summon) *= 1.11f;
                Player.GetDamage(DamageClass.Ranged) *= 1.11f;
                Misspossibility += 9;
            }
            if (Mexican)
            {
                Player.statDefense += 10;
            }
            if (NorthLandSpring)
            {
                Player.lifeRegen += 5;
            }
            if (MoonTonight)
            {
                Player.manaRegen += 8;
            }
            if (OrangeD)
            {
                Player.GetDamage(DamageClass.Magic) *= 1.05f;
                Player.GetDamage(DamageClass.Melee) *= 1.05f;
                Player.GetDamage(DamageClass.Throwing) *= 1.05f;
                Player.GetDamage(DamageClass.Summon) *= 1.05f;
                Player.GetDamage(DamageClass.Ranged) *= 1.05f;
                Player.statDefense += 5;
            }
            if (PinaColada)
            {
                Misspossibility += 4;
                Player.statDefense += 9;
            }
            if (PurpleCrystal)
            {
                Misspossibility += 10;
            }
            if (PinkLady)
            {
                Misspossibility += 5;
                Player.GetCritChance(DamageClass.Generic) += 10;
                Player.GetCritChance(DamageClass.Ranged) += 10;
                Player.GetCritChance(DamageClass.Magic) += 10;
                Player.GetCritChance(DamageClass.Throwing) += 10;
            }
            if (Screwdriver)
            {
                Player.statDefense -= 20;
                Player.GetDamage(DamageClass.Magic) *= 1.2f;
                Player.GetDamage(DamageClass.Melee) *= 1.2f;
                Player.GetDamage(DamageClass.Throwing) *= 1.2f;
                Player.GetDamage(DamageClass.Summon) *= 1.2f;
                Player.GetDamage(DamageClass.Ranged) *= 1.2f;
            }
            if (SeaFlower)
            {
                Player.GetDamage(DamageClass.Magic) *= 1.07f;
                Player.GetDamage(DamageClass.Melee) *= 1.07f;
                Player.GetDamage(DamageClass.Throwing) *= 1.07f;
                Player.GetDamage(DamageClass.Summon) *= 1.07f;
                Player.GetDamage(DamageClass.Ranged) *= 1.07f;
            }
            if (SexOnTheBeach)
            {
                Player.GetDamage(DamageClass.Magic) *= 1.08f;
                Player.GetDamage(DamageClass.Melee) *= 1.08f;
                Player.GetDamage(DamageClass.Throwing) *= 1.08f;
                Player.GetDamage(DamageClass.Summon) *= 1.08f;
                Player.GetDamage(DamageClass.Ranged) *= 1.08f;
            }
            if (SglyBeer)
            {
                Player.GetDamage(DamageClass.Magic) *= 1.09f;
                Player.GetDamage(DamageClass.Melee) *= 1.09f;
                Player.GetDamage(DamageClass.Throwing) *= 1.09f;
                Player.GetDamage(DamageClass.Summon) *= 1.09f;
                Player.GetDamage(DamageClass.Ranged) *= 1.09f;
            }
            if (SingaporeSling)
            {
                Player.lifeRegen += 6;
            }
            if (StrawberryMojituo)
            {
                Player.lifeRegen += 7;
            }
            if (SummerStarrySky)
            {
                Player.manaRegen += 4;
            }
            if (SunsetGlow)
            {
                Player.manaRegen += 5;
            }
            if (TequilaSunrise)
            {
                Player.manaRegen += 6;
            }
            if (U8Grapefruit)
            {
                Player.GetDamage(DamageClass.Magic) *= 1.04f;
                Player.GetDamage(DamageClass.Melee) *= 1.04f;
                Player.GetDamage(DamageClass.Throwing) *= 1.04f;
                Player.GetDamage(DamageClass.Summon) *= 1.04f;
                Player.GetDamage(DamageClass.Ranged) *= 1.04f;
                Player.lifeRegen += 3;
            }
            if (WithOutBerry)
            {
                Player.GetDamage(DamageClass.Magic) *= 1.09f;
                Player.GetDamage(DamageClass.Melee) *= 1.09f;
                Player.GetDamage(DamageClass.Throwing) *= 1.09f;
                Player.GetDamage(DamageClass.Summon) *= 1.09f;
                Player.GetDamage(DamageClass.Ranged) *= 1.09f;
                Player.lifeRegen += 1;
            }
            if (YoghurtCaribbean)
            {
                Player.GetDamage(DamageClass.Magic) *= 1.1f;
                Player.GetDamage(DamageClass.Melee) *= 1.1f;
                Player.GetDamage(DamageClass.Throwing) *= 1.1f;
                Player.GetDamage(DamageClass.Summon) *= 1.1f;
                Player.GetDamage(DamageClass.Ranged) *= 1.1f;
            }
            if (Magelite)
            {
                Misspossibility += 9;
            }
            if (MagicalPlanit)
            {
                Player.GetDamage(DamageClass.Magic) *= 1.02f;
                Player.GetDamage(DamageClass.Melee) *= 1.02f;
                Player.GetDamage(DamageClass.Throwing) *= 1.02f;
                Player.GetDamage(DamageClass.Summon) *= 1.02f;
                Player.GetDamage(DamageClass.Ranged) *= 1.02f;
                Player.GetCritChance(DamageClass.Generic) += 2;
                Player.GetCritChance(DamageClass.Ranged) += 2;
                Player.GetCritChance(DamageClass.Magic) += 2;
                Player.GetCritChance(DamageClass.Throwing) += 2;
                Misspossibility += 2;
                Player.lifeRegen += 2;
                Player.statDefense += 4;
            }
            if (OceanCatch)
            {
                Player.statDefense += 14;
            }
            if (PurpleFreeze)
            {
                Player.GetCritChance(DamageClass.Generic) += 12;
                Player.GetCritChance(DamageClass.Ranged) += 12;
                Player.GetCritChance(DamageClass.Magic) += 12;
                Player.GetCritChance(DamageClass.Throwing) += 12;
            }
            if (SouthAmMitNight)
            {
                Player.moveSpeed *= 1.1f;
                Player.wingTimeMax = (int)(Player.wingTimeMax * 1.2f);
            }
            if (TrafficLight)
            {
                Misspossibility += 6;
                Player.GetDamage(DamageClass.Magic) *= 1.08f;
                Player.GetDamage(DamageClass.Melee) *= 1.08f;
                Player.GetDamage(DamageClass.Throwing) *= 1.08f;
                Player.GetDamage(DamageClass.Summon) *= 1.08f;
                Player.GetDamage(DamageClass.Ranged) *= 1.08f;
                Player.statDefense -= 7;
            }
            if (MoonHeart > 0)
            {
                Misspossibility += 17;
            }
            if (Slip > 0)
            {
                Misspossibility += 8;
            }
            if (Fea > 0)
            {
                Misspossibility += 3;
            }
            if(AddDef > 8)
            {
                Player.statDefense += AddDef + 7;
            }
            if (PowerIncr > 0)
            {
                Player.GetDamage(DamageClass.Magic) += 3;
                Player.GetDamage(DamageClass.Melee) += 3;
                Player.GetDamage(DamageClass.Summon) += 3;
                Player.GetDamage(DamageClass.Ranged) += 3;
                Player.GetDamage(DamageClass.Throwing) += 3;
                PowerIncr -= 1;
                PowerIncr2 = true;
            }
            else
            {
                PowerIncr = 0;
                PowerIncr2 = false;
            }
            if (PowerDecr > 0)
            {
                Player.GetDamage(DamageClass.Magic) *= 0.01f;
                Player.GetDamage(DamageClass.Melee) *= 0.01f;
                Player.GetDamage(DamageClass.Summon) *= 0.01f;
                Player.GetDamage(DamageClass.Ranged) *= 0.01f;
                Player.GetDamage(DamageClass.Throwing) *= 0.01f;
                PowerDecr -= 1;
                PowerDecr2 = true;
            }
            else
            {
                PowerDecr = 0;
                PowerDecr2 = false;
            }
            if (Double > 0)
            {
                Double -= 1;
                X2 = true;
            }
            else
            {
                Double = 0;
                X2 = false;
            }
            if(YinLife <= 0 || YangLife <= 0)
            {
                /*player.statLifeMax2 = 20;*/
            }
        }
        public override void SaveData(TagCompound tag)/* tModPorter Suggestion: Edit tag parameter instead of returning new TagCompound */
        {
            List<string> list = new List<string>();
            TagCompound tagCompound = new TagCompound();
            tagCompound.Add("boost", list);
            for(int i = 0; i < 40;i++)
            {
                if(Feathers[i] > 3929)
                {
                    tagCompound.Add(i.ToString() + "Feather", Lang.GetItemName(Feathers[i]).ToString());
                    tagCompound.Add("Feather" + i.ToString(), 0);
                }
                else
                {
                    tagCompound.Add(i.ToString() + "Feather", "");
                    tagCompound.Add("Feather" + i.ToString(), Feathers[i]);
                }
            }
            tagCompound.Add("阴寿命", YinLife);
            tagCompound.Add("阳寿命", YangLife);
            tagCompound.Add("Lav2", LavaCryst);
            tagCompound.Add("FLav", FinalLava);
            tagCompound.Add("Foex", FoodExp);
            tagCompound.Add("eCoin", Elecoin);
            for(int x = 1; x < 15;x++)
            {
                for (int y = 1; y < 29; y++)
                {
                    tagCompound.Add("BanF" + x.ToString() + "," + y.ToString(), BanFood[x, y]);
                }
            }
            return tagCompound;
        }
        public override void LoadData(TagCompound tag)
        {
            for (int x = 1; x < 15; x++)
            {
                for (int y = 1; y < 29; y++)
                {
                    BanFood[x, y] = tag.GetBool("BanF" + x.ToString() + "," + y.ToString());
                }
            }
            YinLife = tag.GetInt("阴寿命");
            string[] S = new string[40];
            int[] I = new int[40];
            for (int i = 0; i < 40; i++)
            {
                if (tag.GetString(i.ToString() + "Feather") != "")
                {
                    S[i] = tag.GetString(i.ToString() + "Feather");
                }
                if(S[i] == "鸟毛")
                {
                    I[i] = Mod.Find<ModItem>("BirdFeather").Type;
                }
                if (S[i] == "冠蓝鸦毛")
                {
                    I[i] = Mod.Find<ModItem>("BlueBirdFeather").Type;
                }
                if (S[i] == "腐化魔羽")
                {
                    I[i] = Mod.Find<ModItem>("CorruptFeather").Type;
                }
                if (S[i] == "猩红血羽")
                {
                    I[i] = Mod.Find<ModItem>("CrimsonFeather").Type;
                }
                if (S[i] == "暗夜幽羽")
                {
                    I[i] = Mod.Find<ModItem>("DarkFeather").Type;
                }
                if (S[i] == "幽冥羽")
                {
                    I[i] = Mod.Find<ModItem>("GhostFeather").Type;
                }
                if (S[i] == "金鸟毛")
                {
                    I[i] = Mod.Find<ModItem>("GoldBirdFeather").Type;
                }
                if (S[i] == "灿金之羽")
                {
                    I[i] = Mod.Find<ModItem>("GoldFeather").Type;
                }
                if (S[i] == "叶之羽")
                {
                    I[i] = Mod.Find<ModItem>("LeaveFeather").Type;
                }
                if (S[i] == "雷霆羽")
                {
                    I[i] = Mod.Find<ModItem>("LightingFeather").Type;
                }
                if (S[i] == "毒羽")
                {
                    I[i] = Mod.Find<ModItem>("PoisonFeather").Type;
                }
                if (S[i] == "彩虹之羽")
                {
                    I[i] = Mod.Find<ModItem>("RainbowFeather").Type;
                }
                if (S[i] == "红雀毛")
                {
                    I[i] = Mod.Find<ModItem>("RedBirdFeather").Type;
                }
                if (S[i] == "雪里红羽")
                {
                    I[i] = Mod.Find<ModItem>("RedSnowFeather").Type;
                }
                if (S[i] == "纯白雪羽")
                {
                    I[i] = Mod.Find<ModItem>("SnowFeather").Type;
                }
                if (S[i] == "星尘羽")
                {
                    I[i] = Mod.Find<ModItem>("StardustFeather").Type;
                }
                if (S[i] == "日耀羽")
                {
                    I[i] = Mod.Find<ModItem>("SolarFeather").Type;
                }
                if (S[i] == "荧星之羽")
                {
                    I[i] = Mod.Find<ModItem>("StarlightFeather").Type;
                }
                if (S[i] == "暮光羽")
                {
                    I[i] = Mod.Find<ModItem>("TwilightFeather").Type;
                }
                if (S[i] == "虚空幻羽")
                {
                    I[i] = Mod.Find<ModItem>("VoidFeather").Type;
                }
                if (tag.GetInt("Feather" + i.ToString()) != 0)
                {
                    Feathers[i] = tag.GetInt("Feather" + i.ToString());
                }
                else
                {
                    Feathers[i] = I[i];
                }
                CrystalEffectMain.fea[i] = Feathers[i];
            }
            YangLife = tag.GetInt("阳寿命");
            LavaCryst = tag.GetInt("Lav2");
            FinalLava = tag.GetBool("FLav");
            FoodExp = tag.GetInt("Foex");
            Elecoin = tag.GetInt("eCoin");
            IList<string> list = tag.GetList<string>("boost");
        }
        public override void LoadLegacy(BinaryReader reader)
        {
            int num = reader.ReadInt32();
            if (num == 0)
            {
                BitsByte bitsByte = reader.ReadByte();
                return;
            }
            ErrorLogger.Log("血量" + num);
        }
        //123456
        public int FlameShield = 0;
        private int FlameShieldCool = 0;
        public override bool CanBeHitByNPC(NPC npc, ref int cooldownSlot)
        {
            return base.CanBeHitByNPC(npc, ref cooldownSlot);
        }
        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (this.LargeTurquoise)
            {
                int num = base.Player.FindItem(base.Mod.Find<ModItem>("LargeTurquoise").Type);
                if (num >= 0)
                {
                    base.Player.inventory[num].stack--;
                    Item.NewItem((int)base.Player.position.X, (int)base.Player.position.Y, base.Player.width, base.Player.height, base.Mod.Find<ModItem>("LargeTurquoise").Type, 1, false, 0, false, false);
                    if (base.Player.inventory[num].stack <= 0)
                    {
                        base.Player.inventory[num] = new Item();
                    }
                }
            }
            if (this.LargeAquamarine)
            {
                int num = base.Player.FindItem(base.Mod.Find<ModItem>("LargeAquamarine").Type);
                if (num >= 0)
                {
                    base.Player.inventory[num].stack--;
                    Item.NewItem((int)base.Player.position.X, (int)base.Player.position.Y, base.Player.width, base.Player.height, base.Mod.Find<ModItem>("LargeAquamarine").Type, 1, false, 0, false, false);
                    if (base.Player.inventory[num].stack <= 0)
                    {
                        base.Player.inventory[num] = new Item();
                    }
                }
            }
            if (this.LargeOlivine)
            {
                int num = base.Player.FindItem(base.Mod.Find<ModItem>("LargeOlivine").Type);
                if (num >= 0)
                {
                    base.Player.inventory[num].stack--;
                    Item.NewItem((int)base.Player.position.X, (int)base.Player.position.Y, base.Player.width, base.Player.height, base.Mod.Find<ModItem>("LargeOlivine").Type, 1, false, 0, false, false);
                    if (base.Player.inventory[num].stack <= 0)
                    {
                        base.Player.inventory[num] = new Item();
                    }
                }
            }
            if (Player.name == "万象元素")
            {
                Player.active = true;
                Player.dead = false;
                Player.statLife = Player.statLifeMax2;
            }
        }
        public float Misspossibility = 0;
        public bool GXJL;
        public bool NJFZ;
        public bool IcyAnimal;
        public bool StarDustLight;
        public bool SXSXZ;
        public bool LargeTurquoise;
        public int PowerIncr = 0;
        public int PowerDecr = 0;
        public int Double = 0;
        public bool PowerIncr2 = false;
        public bool PowerDecr2 = false;
        public bool X2 = false;
        public bool LargeAquamarine;
        public bool LargeOlivine;
        public bool ExPoi;
        public bool StarPoi;
        public bool StarPoi2;
        public bool StarPoi3;
        public bool LowDisorder;
        public bool Starfishes;
        public int LavaCryst;
        public bool OpenLift;
        public bool CloseLift;
        public bool LiftU;
        public bool LiftD;
        public bool LiftDontTake;
        public int LiftOpenDegree;
        public int floor = 1;
        public int aimFloor = 1;
        public float num3 = 0;
        public float num4 = 0;

        public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)/* tModPorter Suggestion: Return an Item array to add to the players starting items. Use ModifyStartingInventory for modifying them if needed */
        {
            if (Main.expertMode == true)
            {
                {
                    Item item = new Item();
                    item.SetDefaults(Mod.Find<ModItem>("神话卷轴").Type);
                    item.stack = 1;
                    items.Add(item);
                }
            }
        }
    }
}