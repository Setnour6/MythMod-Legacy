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
        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            //Texture2D texture = base.mod.GetTexture("UIImages/Life");
            //Main.heartTexture = texture;
            //Main.heart2Texture = base.mod.GetTexture("UIImages/Life2");
        }
        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (YinYangLife.IMFlDmg > 5)
            {
                if (player.statLifeMax2 <= 200)
                {
                    player.statLife = 100;
                }
                else
                {
                    player.statLife = player.statLifeMax2 / 2;
                }
                return false;
            }
            if (player.name == "万象元素")
            {
                player.active = true;
                player.dead = false;
                player.statLife = player.statLifeMax2;
                return false;
            }
            else
            {
                MagicCool = 0;
                return true;
            }
        }
        public int IMMUNE = 0;
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (DONTTAKEDAMDGE)
            {
                return false;
            }
            else if (Main.rand.Next(0, 100) <= Misspossibility && IMMUNE == 0)
            {
                Projectile.NewProjectile((float)player.Center.X, (float)player.Center.Y, 0, 0, mod.ProjectileType("Miss"), 0, 0, player.whoAmI, 0f, 0f);
                IMMUNE += 30;
                return false;
            }
            if (IMMUNE > 0)
            {
                return false;
            }
            else if (GreenBlood > 2 && Main.rand.Next(100) <= (player.wet ? 20 : 10))
            {
                if (!Main.player[Main.myPlayer].moonLeech)
                {
                    int num6 = damage;
                    player.HealEffect(num6, false);
                    player.statLife += num6;
                    if (player.statLife > player.statLifeMax2)
                    {
                        player.statLife = player.statLifeMax2;
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
                    player.HealEffect(num6, false);
                    player.statLife += num6;
                    if (player.statLife > player.statLifeMax2)
                    {
                        player.statLife = player.statLifeMax2;
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
                if (ab > 0 && player.wet)
                {
                    damage /= 2;
                }
                damage = (int)(damage * (100 - DisHurt) / 100f);
                if (FlameShield > 0 && FlameShieldCool == 0)
                {
                    int h = Projectile.NewProjectile(player.Center, new Vector2(0, 0), 296, 50, 10, Main.myPlayer, 0, 0);
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
                player.statDefense *= 0;
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
                ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(null, "CantaloupeJuice", 1);
                recipe.AddIngredient(23, 10);
                recipe.AddIngredient(126, 4);
                recipe.requiredTile[0] = 220;
                recipe.SetResult(mod.ItemType("LittleCantaloupeJelly"), 3);
                recipe.AddRecipe();
                ModRecipe recipe2 = new ModRecipe(mod);
                recipe2.AddIngredient(null, "WaterMelonJuice", 1);
                recipe2.AddIngredient(23, 10);
                recipe2.AddIngredient(126, 4);
                recipe2.requiredTile[0] = 220;
                recipe2.SetResult(mod.ItemType("littleWatermelonJelly"), 3);
                recipe2.AddRecipe();
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
                ModRecipe recipe2 = new ModRecipe(mod);
                recipe2.AddIngredient(mod.ItemType("UnroastedSaury"), 1);
                recipe2.AddIngredient(31, 1);
                recipe2.requiredTile[0] = 215;
                recipe2.SetResult(mod.ItemType("RoastedSaury"), 1);
                recipe2.AddRecipe();
                ModRecipe recipe3 = new ModRecipe(mod);
                recipe3.AddIngredient(null, "WaterMelonJuice", 1);
                recipe3.AddIngredient(23, 10);
                recipe3.AddIngredient(126, 4);
                recipe3.requiredTile[0] = 220;
                recipe3.SetResult(mod.ItemType("WatermelonJelly"), 1);
                recipe3.AddRecipe();
                ModRecipe recipe4 = new ModRecipe(mod);
                recipe4.AddIngredient(null, "CantaloupeJuice", 1);
                recipe4.AddIngredient(23, 10);
                recipe4.AddIngredient(126, 4);
                recipe4.requiredTile[0] = 220;
                recipe4.SetResult(mod.ItemType("CantaloupeJelly"), 1);
                ModRecipe recipe5 = new ModRecipe(mod);
                recipe5.AddIngredient(null, "Flour", 1);
                recipe5.AddIngredient(null, "Egg", 3);
                recipe5.requiredTile[0] = mod.TileType("榨汁机");
                recipe5.SetResult(mod.ItemType("Curst"), 10);
                recipe5.AddRecipe();
                ModRecipe recipe7 = new ModRecipe(mod);
                recipe7.AddIngredient(null, "freshSquid", 1);
                recipe7.requiredTile[0] = 215;
                recipe7.SetResult(mod.ItemType("RoastedSquid"), 1);
                recipe7.AddRecipe();
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
            if (player.HasBuff(mod.BuffType("嗜血狂暴")))
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
                                    NPC.NewNPC((int)vector.X, (int)vector.Y, mod.NPCType("克苏鲁之眼幻影"), 0, 0f, 0f, 0f, 0f, 255);
                                }
                                if (Main.npc[r].life < 2000 && NPCs.AIs.Eoc2 == true)
                                {
                                    NPCs.AIs.Eoc2 = false;
                                    Vector2 vector = Main.npc[r].Center + new Vector2(0f, (float)Main.npc[r].height / 2f);
                                    NPC.NewNPC((int)vector.X, (int)vector.Y, mod.NPCType("克苏鲁之眼幻影"), 0, 0f, 0f, 0f, 0f, 255);
                                }
                                if (Main.npc[r].life < 500 && NPCs.AIs.Eoc3 == true)
                                {
                                    NPCs.AIs.Eoc3 = false;
                                    Vector2 vector = Main.npc[r].Center + new Vector2(200f, (float)Main.npc[r].height / 2f);
                                    Vector2 vector3 = Main.npc[r].Center + new Vector2(0f, (float)Main.npc[r].height / 2f);
                                    Vector2 vector2 = Main.npc[r].Center + new Vector2(-200f, (float)Main.npc[r].height / 2f);
                                    NPCs.AIs.vector19 = new Vector2(0, 50);
                                    NPCs.AIs.num71 = NPC.NewNPC((int)vector.X, (int)vector.Y, mod.NPCType("克苏鲁之眼幻影"), 0, 0f, 0f, 0f, 0f, 255);
                                    NPCs.AIs.num72 = NPC.NewNPC((int)vector.X, (int)vector.Y, mod.NPCType("克苏鲁之眼幻影"), 0, 0f, 0f, 0f, 0f, 255);
                                    if (MythWorld.MythIndex >= 3)
                                    {
                                        for (int i = 0; i < 5; i++)
                                        {
                                            Vector2 v = new Vector2(0, 800).RotatedByRandom(Math.PI * 2);
                                            NPC.NewNPC((int)vector3.X + (int)v.X, (int)vector3.Y + (int)v.Y, mod.NPCType("克苏鲁之眼幻影"), 0, 0f, 0f, 0f, 0f, 255);
                                        }
                                    }
                                }
                                if (NPC.CountNPCS(mod.NPCType("克苏鲁之眼幻影")) > 0)
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
                                        Vector2 C = player.Center;
                                        Vector2 V = player.velocity.RotatedBy(Main.rand.NextFloat((float)Math.PI * 0.5f, (float)Math.PI * 1.5f)) / player.velocity.Length() * 350f;
                                        NPCs.AIs.num71 = NPC.NewNPC((int)(V + C).X, (int)(V + C).Y, mod.NPCType("克苏鲁之眼残影"), 0, 0f, 0f, 0f, 0f, 255);
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
                                                        NPC.NewNPC((int)vector.X - 25, (int)vector.Y, mod.NPCType("飞行史莱姆"), 0, 0f, 0f, 0f, 0f, 255);
                                                        NPC.NewNPC((int)vector.X + 25, (int)vector.Y - 10, mod.NPCType("飞行尖刺史莱姆"), 0, 0f, 0f, 0f, 0f, 255);
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
                                                        NPC.NewNPC((int)vector.X - 25, (int)vector.Y, mod.NPCType("飞行史莱姆"), 0, 0f, 0f, 0f, 0f, 255);
                                                        NPC.NewNPC((int)vector.X + 25, (int)vector.Y + 10, mod.NPCType("飞行尖刺史莱姆"), 0, 0f, 0f, 0f, 0f, 255);
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
                                                    NPC.NewNPC((int)vector.X, (int)vector.Y, mod.NPCType("飞行史莱姆"), 0, 0f, 0f, 0f, 0f, 255);
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
                                                        NPC.NewNPC((int)vector.X - 25, (int)vector.Y, mod.NPCType("飞行史莱姆"), 0, 0f, 0f, 0f, 0f, 255);
                                                        NPC.NewNPC((int)vector.X + 25, (int)vector.Y - 10, mod.NPCType("飞行尖刺史莱姆"), 0, 0f, 0f, 0f, 0f, 255);
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
                                                        NPC.NewNPC((int)vector.X - 25, (int)vector.Y, mod.NPCType("飞行史莱姆"), 0, 0f, 0f, 0f, 0f, 255);
                                                        if (Main.rand.Next(20) >= 15 && MythWorld.MythIndex >= 2)
                                                        {
                                                            NPC.NewNPC((int)vector.X + 25, (int)vector.Y + 10, mod.NPCType("飞行尖刺史莱姆"), 0, 0f, 0f, 0f, 0f, 255);
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
                                                    NPC.NewNPC((int)vector.X, (int)vector.Y, mod.NPCType("飞行史莱姆"), 0, 0f, 0f, 0f, 0f, 255);
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
            if (player.behindBackWall && Main.tile[(int)(player.Center.X / 16), (int)(player.Center.Y / 16)].wall == mod.WallType("熔岩石墙") && ZoneVolcano)
            {
                if(Main.rand.Next(10) == 1)
                {
                    Vector2 v = new Vector2(0, Main.rand.Next(0, 6)).RotatedByRandom(Math.PI * 2);
                    Projectile.NewProjectile(player.Center.X + Main.rand.Next(-Main.screenWidth / 2 - 20, Main.screenWidth / 2 + 20), player.Center.Y + Main.screenWidth / 2 + 15 + Main.rand.Next(-100, 100), 0 + v.X, -22 + v.Y, base.mod.ProjectileType("熔岩团"), 200, 0, Main.myPlayer, 0, 0f);
                }
                if(NPC.CountNPCS(mod.NPCType("诅咒熔岩巨石怪")) < 1)
                {
                    NPC.NewNPC((int)player.Center.X, (int)player.Center.Y + 2000, mod.NPCType("诅咒熔岩巨石怪"), 0, 0, 0, 0, 0, 255);
                }
                if(!MythWorld.downedVol)
                {
                    player.lastDeathPostion = player.Center;
                    player.lastDeathTime = DateTime.Now;
                    player.showLastDeath = true;
                    if (Main.myPlayer == player.whoAmI)
                    {
                        player.lostCoinString = Main.ValueToCoins(player.lostCoins);
                    }
                    Main.PlaySound(5, (int)player.position.X, (int)player.position.Y, 1, 1f, 0f);
                    player.headVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
                    player.bodyVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
                    player.legVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
                    player.headVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
                    player.bodyVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
                    player.legVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
                    if (player.stoned)
                    {
                        player.headPosition = Vector2.Zero;
                        player.bodyPosition = Vector2.Zero;
                        player.legPosition = Vector2.Zero;
                    }
                    for (int j = 0; j < 100; j++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, 205, 0f, -2f, 0, default(Color), 1f);
                    }
                    player.statLife = 0;
                    player.dead = true;
                    player.respawnTimer = 600;
                    player.head = -1;
                    player.body = -1;
                    player.legs = -1;
                    player.handon = -1;
                    player.handoff = -1;
                    player.back = -1;
                    player.front = -1;
                    player.shoe = -1;
                    player.waist = -1;
                    player.shield = -1;
                    player.neck = -1;
                    player.face = -1;
                    player.balloon = -1;
                    player.mount.Dismount(player);
                    if (Main.expertMode)
                    {
                        player.respawnTimer = (int)((double)player.respawnTimer * 1.5);
                    }
                    player.immuneAlpha = 0;
                    player.palladiumRegen = false;
                    player.iceBarrier = false;
                    player.crystalLeaf = false;
                    if (player.whoAmI == Main.myPlayer && player.difficulty == 0)
                    {
                        player.DropCoins();
                    }
                    else if (player.difficulty == 1)
                    {
                        player.DropItems();
                    }
                    else if (player.difficulty == 2)
                    {
                        player.DropItems();
                        player.KillMeForGood();
                    }
                    Color messageColor2 = Color.Red;
                    Main.NewText(Language.GetTextValue(player.name + "尝试闯入禁区"), messageColor2);
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
                if(Main.screenPosition.X + Main.mouseX - player.Center.X > 0)
                {
                    player.direction = 1;
                }
                else
                {
                    player.direction = -1;
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
                    player.position = new Vector2(20, Main.maxTilesY / 10f + 60) * 16f;
                }
                if (Main.maxTilesX == 6400)
                {
                    player.position = new Vector2(20, Main.maxTilesY / 10f + 180) * 16f;
                }
                if (Main.maxTilesX == 8400)
                {
                    player.position = new Vector2(20, Main.maxTilesY / 10f + 300) * 16f;
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
            if (player.statLife > 0 && num2 > 120)
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
                player.immune = true;
            }
            if (Stones.Open == false && movieTime > 0)
            {
                movieTime -= 1;
            }
            if (NPC.CountNPCS(370) == 0)
            {
                Cloud = 0;
            }
            if (player.active || !player.dead)
            {
                v1 = Main.screenPosition + new Vector2(Main.screenWidth / 2 - 16, Main.screenHeight / 2 - 24);
            }
            if (ZTMSY && NPC.CountNPCS(mod.NPCType("终天灭世眼")) < 1)
            {
                NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("终天灭世眼"), 0, 0f, 0f, 0f, 0f, 255);
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
                    Projectile.NewProjectile(player.Center.X + player.direction * 25, player.Center.Y, player.direction * 4, 0, base.mod.ProjectileType("海星1"), 0, 0.2f, Main.myPlayer, 0f, 0f);
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
                    for (int k = (int)(player.position.X / 16f - 5); k < (int)(player.position.X / 16f + 5); k++)
                    {
                        if (Main.tile[k, (int)(player.position.Y / 16f)].type == mod.TileType("电梯门"))
                        {
                            m = k;
                            for (int l = (int)(player.position.Y / 16f); l < Main.maxTilesY; l += 4)
                            {
                                if (Main.tile[m, l].type == mod.TileType("电梯门"))
                                {
                                    Zonefloor += 1;
                                }
                            }
                            m3 = k;
                            for (int l = 0; l < Main.maxTilesY; l += 4)
                            {
                                if (Main.tile[m, l].type == mod.TileType("电梯门"))
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
                    for (int k = (int)(player.position.X / 16f - 5); k < (int)(player.position.X / 16f + 5); k++)
                    {
                        if (Main.tile[k, (int)(player.position.Y / 16f)].type == mod.TileType("电梯门"))
                        {
                            m = k;
                            for (int l = (int)(player.position.Y / 16f); l < Main.maxTilesY; l += 4)
                            {
                                if (Main.tile[m, l].type == mod.TileType("电梯门"))
                                {
                                    Zonefloor += 1;
                                }
                            }
                            m3 = k;
                            for (int l = 0; l < Main.maxTilesY; l += 4)
                            {
                                if (Main.tile[m, l].type == mod.TileType("电梯门"))
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
                player.velocity *= 0;
                num3 += 2f;
                int p = 0;
                for (int k = (int)(player.position.X / 16f - 5); k < (int)(player.position.X / 16f + 5); k++)
                {
                    if (Main.tile[k, (int)((player.position.Y + FlyCamPosition.Y) / 16f)].type == mod.TileType("电梯门"))
                    {
                        m2 = k;
                        for (int l = (int)((player.position.Y + FlyCamPosition.Y) / 16f); l < Main.maxTilesY; l += 4)
                        {
                            if (Main.tile[m2, l].type == mod.TileType("电梯门"))
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
                    player.position += FlyCamPosition;
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
                    player.noFallDmg = true;
                }
            }
            if (TransU)
            {
                FlyCamPosition = new Vector2(0, -2 * num3);
                player.velocity *= 0;
                num3 += 2f;
                int p = 0;
                for (int k = (int)(player.position.X / 16f - 5); k < (int)(player.position.X / 16f + 5); k++)
                {
                    if (Main.tile[k, (int)((player.position.Y + FlyCamPosition.Y) / 16f)].type == mod.TileType("电梯门"))
                    {
                        m2 = k;
                        for (int l = (int)((player.position.Y + FlyCamPosition.Y) / 16f); l < Main.maxTilesY; l += 4)
                        {
                            if (Main.tile[m2, l].type == mod.TileType("电梯门"))
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
                    player.position += FlyCamPosition + new Vector2(0, -64);
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
                    player.noFallDmg = true;
                }
            }
            if (Main.mouseMiddle && player.name == "万象元素")
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
            if(player.name == ("万象元素"))
            {
                MagicCool = 0;
            }
            if (Main.dayTime)
            {
                LanternMoon = false;
                LanternMoonPoint = 0;
            }
            if (player.ZoneCorrupt && NPC.CountNPCS(mod.NPCType("魔茧")) <= 0 && Main.rand.Next(10000) == 1)
            {
                Projectile.NewProjectile(player.Center.X + player.direction * 1000, player.Center.Y, 0, 0, base.mod.ProjectileType("茧"), 0, 0, Main.myPlayer, 0f, 0);
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
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("LanternGhostKing"), 0, 0, 0, 0, 0, 255);
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
                        NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - 500, mod.NPCType("AncientTangerineTreeHat"), 0, 0, 0, 0, 0, 255);
                        NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - 495, mod.NPCType("AncientTangerineTreeHatSHadow"), 0, 0, 0, 0, 0, 255);
                        NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("AncientTangerineTree"), 0, 0, 0, 0, 0, 255);
                        NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - 145, mod.NPCType("AncientTangerineTreeEye"), 0, 0, 0, 0, 0, 255);
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
                    if (NPC.CountNPCS(mod.NPCType("HappinessZombie")) < 30 && Main.rand.Next(28) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("HappinessZombie"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("HappinessZombie")) < 30 && Main.rand.Next(28) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("HappinessZombie"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 2)
                {
                    if (NPC.CountNPCS(mod.NPCType("HappinessZombie")) < 30 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("HappinessZombie"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("HappinessZombie")) < 30 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("HappinessZombie"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 3)
                {
                    if (NPC.CountNPCS(mod.NPCType("PaperCuttingBat")) < 15 && Main.rand.Next(15) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("PaperCuttingBat"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("PaperCuttingBat")) < 15 && Main.rand.Next(15) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("PaperCuttingBat"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("HappinessZombie")) < 15 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("HappinessZombie"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("HappinessZombie")) < 15 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("HappinessZombie"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 4)
                {
                    if (NPC.CountNPCS(mod.NPCType("PaperCuttingBat")) < 20 && Main.rand.Next(10) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("PaperCuttingBat"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("PaperCuttingBat")) < 20 && Main.rand.Next(10) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("PaperCuttingBat"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("HappinessZombie")) < 20 && Main.rand.Next(15) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("HappinessZombie"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("HappinessZombie")) < 20 && Main.rand.Next(15) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("HappinessZombie"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 5)
                {
                    if (NPC.CountNPCS(mod.NPCType("FloatLantern")) < 2 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("FloatLantern"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("PaperCuttingBat")) < 20 && Main.rand.Next(15) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("PaperCuttingBat"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("HappinessZombie")) < 20 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("HappinessZombie"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("HappinessZombie")) < 20 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("HappinessZombie"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 6)
                {
                    if (NPC.CountNPCS(mod.NPCType("FloatLantern")) < 4 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("FloatLantern"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("PaperCuttingBat")) < 20 && Main.rand.Next(15) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("PaperCuttingBat"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("PaperCuttingBat")) < 20 && Main.rand.Next(15) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("PaperCuttingBat"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("HappinessZombie")) < 20 && Main.rand.Next(15) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("HappinessZombie"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("HappinessZombie")) < 20 && Main.rand.Next(15) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("HappinessZombie"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 7)
                {
                    if (NPC.CountNPCS(mod.NPCType("PaperCuttingBat")) < 50 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("PaperCuttingBat"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("PaperCuttingBat")) < 50 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("PaperCuttingBat"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 8)
                {
                    if (NPC.CountNPCS(mod.NPCType("FloatLantern")) < 20 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("FloatLantern"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("FloatLantern")) < 20 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("FloatLantern"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 9)
                {
                    if (NPC.CountNPCS(mod.NPCType("RedPackBomber")) < 6 && Main.rand.Next(120) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("RedPackBomber"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("FloatLantern")) < 6 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("FloatLantern"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("RedPackBomber")) < 6 && Main.rand.Next(120) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("RedPackBomber"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("FloatLantern")) < 6 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("FloatLantern"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("PaperCuttingBat")) < 20 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("PaperCuttingBat"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("HappinessZombie")) < 20 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("HappinessZombie"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("HappinessZombie")) < 20 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("HappinessZombie"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 10)
                {
                    if (NPC.CountNPCS(mod.NPCType("RedPackBomber")) < 8 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("RedPackBomber"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("FloatLantern")) < 8 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("FloatLantern"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("RedPackBomber")) < 8 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("RedPackBomber"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("FloatLantern")) < 8 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("FloatLantern"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("PaperCuttingBat")) < 20 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("PaperCuttingBat"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("PaperCuttingBat")) < 20 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("PaperCuttingBat"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("HappinessZombie")) < 14 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("HappinessZombie"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("HappinessZombie")) < 14 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("HappinessZombie"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 11)
                {
                    if (NPC.CountNPCS(mod.NPCType("RedPackBomber")) < 10 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("RedPackBomber"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("FloatLantern")) < 10 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("FloatLantern"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("RedPackBomber")) < 10 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("RedPackBomber"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("FloatLantern")) < 10 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("FloatLantern"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("PaperCuttingBat")) < 20 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("PaperCuttingBat"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("PaperCuttingBat")) < 20 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("PaperCuttingBat"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 12)
                {
                    if (NPC.CountNPCS(mod.NPCType("RedPackBomber")) < 10 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("RedPackBomber"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("FloatLantern")) < 10 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("FloatLantern"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("RedPackBomber")) < 10 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("RedPackBomber"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("FloatLantern")) < 10 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("FloatLantern"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("PaperCuttingBat")) < 20 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("PaperCuttingBat"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("PaperCuttingBat")) < 20 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("PaperCuttingBat"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LanternSprite")) < 10 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("LanternSprite"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LanternSprite")) < 10 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("LanternSprite"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 13)
                {
                    if (NPC.CountNPCS(mod.NPCType("RedPackBomber")) < 10 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("RedPackBomber"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("FloatLantern")) < 10 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("FloatLantern"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("RedPackBomber")) < 10 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("RedPackBomber"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("FloatLantern")) < 10 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("FloatLantern"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("PaperCuttingBat")) < 20 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("PaperCuttingBat"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("PaperCuttingBat")) < 20 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("PaperCuttingBat"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LanternSprite")) < 10 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("LanternSprite"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LanternSprite")) < 10 && Main.rand.Next(80) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("LanternSprite"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("HappinessZombie")) < 14 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("HappinessZombie"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("HappinessZombie")) < 14 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("HappinessZombie"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 14)
                {
                    if (NPC.CountNPCS(mod.NPCType("RedPackBomber")) < 24 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("RedPackBomber"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("FloatLantern")) < 24 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("FloatLantern"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LanternSprite")) < 24 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("LanternSprite"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("RedPackBomber")) < 24 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("RedPackBomber"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("FloatLantern")) < 24 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("FloatLantern"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LanternSprite")) < 24 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("LanternSprite"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 16)
                {
                    if (NPC.CountNPCS(mod.NPCType("MilkSlime1")) < 6 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("MilkSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("MilkSlime1")) < 6 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("MilkSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StrawberrySlime1")) < 6 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("StrawberrySlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StrawberrySlime1")) < 6 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("StrawberrySlime1"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 17)
                {
                    if (NPC.CountNPCS(mod.NPCType("MilkSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("MilkSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("MilkSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("MilkSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StrawberrySlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("StrawberrySlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StrawberrySlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("StrawberrySlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("AppleSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("AppleSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("AppleSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("AppleSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("OrangeSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("OrangeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("OrangeSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("OrangeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 18)
                {
                    if (NPC.CountNPCS(mod.NPCType("MilkSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("MilkSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("MilkSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("MilkSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StrawberrySlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("StrawberrySlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StrawberrySlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("StrawberrySlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("AppleSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("AppleSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("AppleSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("AppleSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("OrangeSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("OrangeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("OrangeSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("OrangeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("ChocolateSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("ChocolateSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("ChocolateSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("ChocolateSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("GrapeSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("GrapeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("GrapeSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("GrapeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LemonSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("LemonSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LemonSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("LemonSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 19)
                {
                    if (NPC.CountNPCS(mod.NPCType("MilkSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("MilkSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("MilkSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("MilkSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StrawberrySlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("StrawberrySlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StrawberrySlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("StrawberrySlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("AppleSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("AppleSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("AppleSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("AppleSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("OrangeSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("OrangeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("OrangeSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("OrangeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("ChocolateSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("ChocolateSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("ChocolateSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("ChocolateSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("GrapeSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("GrapeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("GrapeSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("GrapeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LemonSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("LemonSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LemonSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("LemonSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("VerdantTangerine")) < 5 && Main.rand.Next(120) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y + Main.rand.Next(100, 400), mod.NPCType("VerdantTangerine"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("VerdantTangerine")) < 5 && Main.rand.Next(120) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y + Main.rand.Next(100, 400), mod.NPCType("VerdantTangerine"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 20)
                {
                    if (NPC.CountNPCS(mod.NPCType("MilkSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("MilkSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("MilkSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("MilkSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StrawberrySlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("StrawberrySlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StrawberrySlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("StrawberrySlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("AppleSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("AppleSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("AppleSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("AppleSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("OrangeSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("OrangeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("OrangeSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("OrangeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("ChocolateSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("ChocolateSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("ChocolateSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("ChocolateSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("GrapeSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("GrapeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("GrapeSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("GrapeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LemonSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("LemonSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LemonSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("LemonSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("VerdantTangerine")) < 8 && Main.rand.Next(90) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y + Main.rand.Next(100, 400), mod.NPCType("VerdantTangerine"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("VerdantTangerine")) < 8 && Main.rand.Next(90) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y + Main.rand.Next(100, 400), mod.NPCType("VerdantTangerine"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 21)
                {
                    if (NPC.CountNPCS(mod.NPCType("MilkSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("MilkSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("MilkSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("MilkSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StrawberrySlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("StrawberrySlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StrawberrySlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("StrawberrySlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("AppleSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("AppleSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("AppleSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("AppleSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("OrangeSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("OrangeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("OrangeSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("OrangeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("ChocolateSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("ChocolateSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("ChocolateSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("ChocolateSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("GrapeSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("GrapeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("GrapeSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("GrapeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LemonSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("LemonSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LemonSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("LemonSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("VerdantTangerine")) < 3 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y + Main.rand.Next(100, 400), mod.NPCType("VerdantTangerine"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("VerdantTangerine")) < 3 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y + Main.rand.Next(100, 400), mod.NPCType("VerdantTangerine"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LachangGhost")) < 3 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y + Main.rand.Next(100, 400), mod.NPCType("LachangGhost"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LachangGhost")) < 3 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y + Main.rand.Next(100, 400), mod.NPCType("LachangGhost"), 0, 0, 0, 0, 0, 255);
                    }

                }
                if (LanternMoonWave == 22)
                {
                    if (NPC.CountNPCS(mod.NPCType("MilkSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("MilkSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("MilkSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("MilkSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StrawberrySlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("StrawberrySlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StrawberrySlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("StrawberrySlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("AppleSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("AppleSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("AppleSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("AppleSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("OrangeSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("OrangeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("OrangeSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("OrangeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("ChocolateSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("ChocolateSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("ChocolateSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("ChocolateSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("GrapeSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("GrapeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("GrapeSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("GrapeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LemonSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("LemonSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LemonSlime1")) < 2 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("LemonSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("VerdantTangerine")) < 3 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y + Main.rand.Next(100, 400), mod.NPCType("VerdantTangerine"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("VerdantTangerine")) < 3 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y + Main.rand.Next(100, 400), mod.NPCType("VerdantTangerine"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LachangGhost")) < 6 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y + Main.rand.Next(100, 400), mod.NPCType("LachangGhost"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LachangGhost")) < 6 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y + Main.rand.Next(100, 400), mod.NPCType("LachangGhost"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("BumpTangyuan")) < 6 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("BumpTangyuan"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("BumpTangyuan")) < 6 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("BumpTangyuan"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 23)
                {
                    if (NPC.CountNPCS(mod.NPCType("MilkSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("MilkSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("MilkSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("MilkSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StrawberrySlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("StrawberrySlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StrawberrySlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("StrawberrySlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("AppleSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("AppleSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("AppleSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("AppleSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("OrangeSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("OrangeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("OrangeSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("OrangeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("ChocolateSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("ChocolateSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("ChocolateSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("ChocolateSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("GrapeSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("GrapeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("GrapeSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("GrapeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LemonSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("LemonSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LemonSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("LemonSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("VerdantTangerine")) < 3 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y + Main.rand.Next(100, 400), mod.NPCType("VerdantTangerine"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("VerdantTangerine")) < 3 && Main.rand.Next(60) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y + Main.rand.Next(100, 400), mod.NPCType("VerdantTangerine"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LachangGhost")) < 7 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y + Main.rand.Next(100, 400), mod.NPCType("LachangGhost"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LachangGhost")) < 7 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y + Main.rand.Next(100, 400), mod.NPCType("LachangGhost"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("BumpTangyuan")) < 8 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("BumpTangyuan"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("BumpTangyuan")) < 8 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("BumpTangyuan"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("OrchidSprite")) < 3 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("OrchidSprite"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("OrchidSprite")) < 3 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("OrchidSprite"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 24)
                {
                    if (NPC.CountNPCS(mod.NPCType("MilkSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("MilkSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("MilkSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("MilkSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StrawberrySlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("StrawberrySlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StrawberrySlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("StrawberrySlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("AppleSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("AppleSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("AppleSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("AppleSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("OrangeSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("OrangeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("OrangeSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("OrangeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("ChocolateSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("ChocolateSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("ChocolateSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("ChocolateSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("GrapeSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("GrapeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("GrapeSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("GrapeSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LemonSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("LemonSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LemonSlime1")) < 1 && Main.rand.Next(40) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("LemonSlime1"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("VerdantTangerine")) < 5 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y + Main.rand.Next(100, 400), mod.NPCType("VerdantTangerine"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("VerdantTangerine")) < 5 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y + Main.rand.Next(100, 400), mod.NPCType("VerdantTangerine"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LachangGhost")) < 9 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y + Main.rand.Next(100, 400), mod.NPCType("LachangGhost"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("LachangGhost")) < 9 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y + Main.rand.Next(100, 400), mod.NPCType("LachangGhost"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("BumpTangyuan")) < 10 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("BumpTangyuan"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("BumpTangyuan")) < 10 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("BumpTangyuan"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("OrchidSprite")) < 5 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("OrchidSprite"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("OrchidSprite")) < 5 && Main.rand.Next(30) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("OrchidSprite"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 26)
                {
                    if (NPC.CountNPCS(mod.NPCType("DiggingErrupt")) < 15 && Main.rand.Next(65) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("DiggingErrupt"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("DiggingErrupt")) < 15 && Main.rand.Next(65) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("DiggingErrupt"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StubbronChildZombie")) < 15 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("StubbronChildZombie"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StubbronChildZombie")) < 15 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("StubbronChildZombie"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 27)
                {
                    if (NPC.CountNPCS(mod.NPCType("DiggingErrupt")) < 18 && Main.rand.Next(50) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("DiggingErrupt"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("DiggingErrupt")) < 18 && Main.rand.Next(50) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("DiggingErrupt"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StubbronChildZombie")) < 18 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("StubbronChildZombie"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StubbronChildZombie")) < 18 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("StubbronChildZombie"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 28)
                {
                    if (NPC.CountNPCS(mod.NPCType("DiggingErrupt")) < 15 && Main.rand.Next(50) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("DiggingErrupt"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("DiggingErrupt")) < 15 && Main.rand.Next(50) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("DiggingErrupt"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StubbronChildZombie")) < 15 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("StubbronChildZombie"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StubbronChildZombie")) < 15 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("StubbronChildZombie"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("FireFly")) < 5 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("FireFly"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("FireFly")) < 5 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("FireFly"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("FireFlyGreen")) < 5 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("FireFlyGreen"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("FireFlyGreen")) < 5 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("FireFlyGreen"), 0, 0, 0, 0, 0, 255);
                    }
                }
                if (LanternMoonWave == 29)
                {
                    if (NPC.CountNPCS(mod.NPCType("DiggingErrupt")) < 15 && Main.rand.Next(50) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("DiggingErrupt"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("DiggingErrupt")) < 15 && Main.rand.Next(50) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - Main.rand.Next(100, 400), mod.NPCType("DiggingErrupt"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StubbronChildZombie")) < 15 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("StubbronChildZombie"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("StubbronChildZombie")) < 15 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("StubbronChildZombie"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("FireFly")) < 7 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("FireFly"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("FireFly")) < 7 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("FireFly"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("FireFlyGreen")) < 7 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("FireFlyGreen"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("FireFlyGreen")) < 7 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("FireFlyGreen"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("BurningWindmill")) < 4 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X - 1000, (int)player.Center.Y - 300, mod.NPCType("BurningWindmill"), 0, 0, 0, 0, 0, 255);
                    }
                    if (NPC.CountNPCS(mod.NPCType("BurningWindmill")) < 4 && Main.rand.Next(20) == 1)
                    {
                        NPC.NewNPC((int)player.Center.X + 1000, (int)player.Center.Y - 300, mod.NPCType("BurningWindmill"), 0, 0, 0, 0, 0, 255);
                    }
                }
                Main.moonTexture[0] = (mod.GetTexture("UIImages/LanternMoon"));
                Main.moonTexture[1] = (mod.GetTexture("UIImages/LanternMoon"));
                Main.moonTexture[2] = (mod.GetTexture("UIImages/LanternMoon"));               
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
                    player.AddBuff(mod.BuffType("秩序之锁"), 2);
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
                    player.lastDeathPostion = player.Center;
                    player.lastDeathTime = DateTime.Now;
                    player.showLastDeath = true;
                    if (Main.myPlayer == player.whoAmI)
                    {
                        player.lostCoinString = Main.ValueToCoins(player.lostCoins);
                    }
                    Main.PlaySound(5, (int)player.position.X, (int)player.position.Y, 1, 1f, 0f);
                    player.headVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
                    player.bodyVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
                    player.legVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
                    player.headVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
                    player.bodyVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
                    player.legVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + 0f;
                    if (player.stoned)
                    {
                        player.headPosition = Vector2.Zero;
                        player.bodyPosition = Vector2.Zero;
                        player.legPosition = Vector2.Zero;
                    }
                    for (int j = 0; j < 100; j++)
                    {
                        Dust.NewDust(player.position, player.width, player.height, 205, 0f, -2f, 0, default(Color), 1f);
                    }
                    player.statLife = 0;
                    player.dead = true;
                    player.respawnTimer = 600;
                    player.head = -1;
                    player.body = -1;
                    player.legs = -1;
                    player.handon = -1;
                    player.handoff = -1;
                    player.back = -1;
                    player.front = -1;
                    player.shoe = -1;
                    player.waist = -1;
                    player.shield = -1;
                    player.neck = -1;
                    player.face = -1;
                    player.balloon = -1;
                    player.mount.Dismount(player);
                    if (Main.expertMode)
                    {
                        player.respawnTimer = (int)((double)player.respawnTimer * 1.5);
                    }
                    player.immuneAlpha = 0;
                    player.palladiumRegen = false;
                    player.iceBarrier = false;
                    player.crystalLeaf = false;
                    if (player.whoAmI == Main.myPlayer && player.difficulty == 0)
                    {
                        player.DropCoins();
                    }
                    else if (player.difficulty == 1)
                    {
                        player.DropItems();
                    }
                    else if (player.difficulty == 2)
                    {
                        player.DropItems();
                        player.KillMeForGood();
                    }
                }
                if (ZoneVolcano)
                {
                    if (Main.rand.Next(1500) == 142 && Main.tile[(int)(player.position.X / 16), (int)(player.position.Y / 16)].wall == mod.WallType("玄武岩墙"))
                    {
                        Projectile.NewProjectile(Main.screenPosition.X + Main.rand.NextFloat(Main.screenWidth), Main.screenPosition.Y - Main.rand.Next(150, 400), 0, 1, base.mod.ProjectileType("熔岩滚石"), 300, 8, Main.myPlayer, 10, 0f);
                    }
                }
                if (ZoneVolcano && VIm == 0)
                {
                    player.mount.Dismount(player);
                    player.wingTime = 0;
                    player.AddBuff(mod.BuffType("高温窒息"), 2);
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
                    if (Main.rand.Next(0, 4) == 1 && !ZoneVolcano && player.position.X / 16f < Main.maxTilesX / 4)
                    {
                        Projectile.NewProjectile(Main.screenPosition.X - 36, Main.screenPosition.Y + Main.screenHeight / 2, 0, 2, base.mod.ProjectileType("珊瑚random"), 0, 0, Main.myPlayer, 10, 0f);
                        Projectile.NewProjectile(Main.screenPosition.X + Main.screenWidth + 36, Main.screenPosition.Y + Main.screenHeight / 2, 0, 2, base.mod.ProjectileType("珊瑚random"), 0, 0, Main.myPlayer, 10, 0f);
                    }
                }
                if (player.Center.X / 16f > Main.maxTilesX * 0.6f && player.Center.X / 16f < Main.maxTilesX * 0.9f)
                {
                    ZoneVolcano = true;
                }
                else
                {
                    ZoneVolcano = false;
                }
                if (player.Center.X / 16f > Main.maxTilesX * 0.56f && player.Center.X / 16f < Main.maxTilesX * 0.6f)
                {
                    ZoneRedTree = true;
                }
                else
                {
                    ZoneRedTree = false;
                }
                if (player.Center.X / 16f > Main.maxTilesX * 0.9f)
                {
                    ZoneTown = true;
                }
                else
                {
                    ZoneTown = false;
                }
                if (player.wet)
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
                        if (player.Center.Y / 16f > Main.maxTilesY * 0.27f)
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
                        if (player.Center.Y / 16f > Main.maxTilesY * 0.35f)
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
                return mod.GetTexture("VolcanoBG");
            }
            if (ZoneRedTree)
            {
                return mod.GetTexture("RedTreeBG");
            }
            if (ZoneOcean && !player.wet)
            {
                return mod.GetTexture("OceanBG");
            }
            if (ZoneOcean && player.wet)
            {
                return mod.GetTexture("CoralBG");
            }
            if (ZoneTown)
            {
                return mod.GetTexture("CoralBG");/*Need Change*/
            }
            return null;
        }
        public override void UpdateBadLifeRegen()
        {
            if (this.ExPoi)
            {
                if (base.player.lifeRegen > 0)
                {
                    base.player.lifeRegen = 0;
                }
                base.player.lifeRegenTime = 0;
                base.player.lifeRegen -= 150;
            }
            if (this.StarPoi2)
            {
                if (base.player.lifeRegen > 0)
                {
                    base.player.lifeRegen = 0;
                }
                base.player.lifeRegenTime = 0;
                base.player.lifeRegen -= 40;
            }
            if (this.StarPoi3)
            {
                if (base.player.lifeRegen > 0)
                {
                    base.player.lifeRegen = 0;
                }
                base.player.lifeRegenTime = 0;
                base.player.lifeRegen -= 150;
            }
        }
        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
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
                            caughtType = base.mod.ItemType("锈铁剑");
                            break;
                        case 1:
                            caughtType = base.mod.ItemType("马尾藻");
                            break;
                        case 2:
                            caughtType = base.mod.ItemType("空瓶");
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
                            caughtType = base.mod.ItemType("锈铁剑");
                            break;
                        case 1:
                            caughtType = base.mod.ItemType("马尾藻");
                            break;
                        case 2:
                            caughtType = base.mod.ItemType("空瓶");
                            break;
                    }
                }
                if (power >= 60 && poolSize >= 150 && questFish == base.mod.ItemType("鱿鱼"))
                {
                    caughtType = base.mod.ItemType("鱿鱼");
                    if (power >= 70 && Main.rand.Next(25) == 0 && power < 440)
                    {
                        caughtType = base.mod.ItemType("发光磷虾");
                    }
                    if (power >= 80)
                    {
                        if (power >= 70 && Main.rand.Next(25) == 0 && power < 240)
                        {
                            caughtType = base.mod.ItemType("电鳐");
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
                player.SpawnX = 160;
                player.SpawnY = (int)((Main.maxTilesY / 10f + 60) * 16f);
                player.FindSpawn();
            }
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (player.name == "万象元素")
            {
                player.Spawn();
                player.respawnTimer = 0;
                if (player.statLifeMax2 <= 200)
                {
                    player.statLife = 100;
                }
                else
                {
                    player.statLife = player.statLifeMax2 / 2;
                }
                player.immuneTime = 120;
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
                    player.statLifeMax2 += LavaCryst * 5;
                }
                else
                {
                    player.statLifeMax2 += 300;
                }
            }
            if (FinalLava)
            {
                if (LavaCryst <= 60)
                {
                    player.statLifeMax2 += LavaCryst * 5;
                }
                else
                {
                    player.statLifeMax2 += 300;
                }
            }
            for(int i = 0;i < 40;i++)
            {
                if (CrystalEffectMain.MaxFea >= i)
                {
                    if (CrystalEffectMain.fea[i] == 320)
                    {
                        Misspossibility += 1;
                        player.moveSpeed += 0.25f;
                        player.wingTimeMax += 30;
                        player.jumpSpeedBoost += 0.75f;
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("BirdFeather"))
                    {
                        player.moveSpeed += 0.1f;
                        player.wingTimeMax += 20;
                        player.jumpSpeedBoost += 0.3f;
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("BlueBirdFeather"))
                    {
                        player.moveSpeed += 0.1f;
                        player.wingTimeMax += 20;
                        player.statManaMax2 += 20;
                        player.jumpSpeedBoost += 0.3f;
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("RedBirdFeather"))
                    {
                        player.moveSpeed += 0.1f;
                        player.wingTimeMax += 20;
                        player.statLifeMax2 += 10;
                        player.jumpSpeedBoost += 0.3f;
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("GoldBirdFeather"))
                    {
                        Misspossibility += 1;
                        player.moveSpeed += 0.15f;
                        player.wingTimeMax += 40;
                        player.statLifeMax2 += 10;
                        player.statManaMax2 += 20;
                        player.jumpSpeedBoost += 0.45f;
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("BeeFeather"))
                    {
                        Misspossibility += 3;
                        player.moveSpeed += 0.24f;
                        player.wingTimeMax += 40;
                        player.jumpSpeedBoost += 0.72f;
                    }
                    if (CrystalEffectMain.fea[i] == 1516)
                    {
                        Misspossibility += 3;
                        player.moveSpeed += 0.6f;
                        player.wingTimeMax += 60;
                        player.jumpSpeedBoost += 1.8f;
                    }
                    if (CrystalEffectMain.fea[i] == 1517)
                    {
                        Misspossibility += 2;
                        player.moveSpeed += 0.6f;
                        player.wingTimeMax += 60;
                        player.jumpSpeedBoost += 1.8f;
                    }
                    if (CrystalEffectMain.fea[i] == 1518)
                    {
                        Misspossibility += 2;
                        player.moveSpeed += 0.6f;
                        player.wingTimeMax += 60;
                        player.jumpSpeedBoost += 1.8f;
                    }
                    if (CrystalEffectMain.fea[i] == 1519)
                    {
                        Misspossibility += 2;
                        player.moveSpeed += 0.6f;
                        player.wingTimeMax += 60;
                        player.jumpSpeedBoost += 1.8f;
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("SnowFeather"))
                    {
                        Misspossibility += 1;
                        player.moveSpeed += 0.16f;
                        player.wingTimeMax += 30;
                        player.jumpSpeedBoost += 0.48f;
                        player.statLifeMax2 += 10;
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("TwilightFeather"))
                    {
                        Misspossibility += 1;
                        player.moveSpeed += 0.4f;
                        player.wingTimeMax += 54;
                        player.jumpSpeedBoost += 1.20f;
                        player.statLifeMax2 += 30;
                        player.lifeRegen += 3;
                        player.manaRegen += 3;
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("VoidFeather"))
                    {
                        Misspossibility += 10;
                        player.moveSpeed += 1.1f;
                        player.wingTimeMax += 144;
                        player.jumpSpeedBoost += 3.3f;
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("SolarFeather"))
                    {
                        Misspossibility += 12;
                        player.moveSpeed += 2f;
                        player.wingTimeMax += 180;
                        player.jumpSpeedBoost += 6f;
                        player.statLifeMax2 += 100;
                        player.statDefense += 15;
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("StardustFeather"))
                    {
                        Misspossibility += 12;
                        player.moveSpeed += 2f;
                        player.wingTimeMax += 180;
                        player.jumpSpeedBoost += 6f;
                        player.maxMinions += 5;
                        player.statManaMax2 += 100;
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("DarkFeather"))
                    {
                        Misspossibility += 2;
                        player.moveSpeed += 0.16f;
                        player.wingTimeMax += 30;
                        player.jumpSpeedBoost += 0.48f;
                        player.meleeCrit += 3;
                        player.magicCrit += 3;
                        player.thrownCrit += 3;
                        player.rangedCrit += 3;
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("CrimsonFeather"))
                    {
                        Misspossibility += 2;
                        player.moveSpeed += 0.34f;
                        player.wingTimeMax += 48;
                        player.jumpSpeedBoost += 1.02f;
                        player.meleeCrit += 3;
                        player.magicCrit += 3;
                        player.thrownCrit += 3;
                        player.rangedCrit += 3;
                        player.lifeRegen += 3;
                        if (player.ZoneCrimson)
                        {
                            Misspossibility += 2;
                            player.moveSpeed += 0.34f;
                            player.wingTimeMax += 48;
                            player.jumpSpeedBoost += 1.02f;
                            player.meleeCrit += 3;
                            player.magicCrit += 3;
                            player.thrownCrit += 3;
                            player.rangedCrit += 3;
                            player.lifeRegen += 3;
                        }
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("CorruptFeather"))
                    {
                        Misspossibility += 3;
                        player.moveSpeed += 0.34f;
                        player.wingTimeMax += 48;
                        player.jumpSpeedBoost += 1.02f;
                        player.meleeCrit += 2;
                        player.magicCrit += 2;
                        player.thrownCrit += 2;
                        player.rangedCrit += 2;
                        player.statDefense += 4;
                        if (player.ZoneCrimson)
                        {
                            Misspossibility += 3;
                            player.moveSpeed += 0.34f;
                            player.wingTimeMax += 48;
                            player.jumpSpeedBoost += 1.02f;
                            player.meleeCrit += 2;
                            player.magicCrit += 2;
                            player.thrownCrit += 2;
                            player.rangedCrit += 2;
                            player.statDefense += 4;
                        }
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("GhostFeather"))
                    {
                        Misspossibility += 5;
                        player.moveSpeed += 1f;
                        player.wingTimeMax += 108;
                        player.jumpSpeedBoost += 3f;
                        player.meleeCrit += 7;
                        player.magicCrit += 7;
                        player.thrownCrit += 7;
                        player.rangedCrit += 7;
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("GoldFeather"))
                    {
                        Misspossibility += 3;
                        player.moveSpeed += 0.27f;
                        player.wingTimeMax += 48;
                        player.jumpSpeedBoost += 0.81f;
                        player.statLifeMax2 += 30;
                        player.statManaMax2 += 30;
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("LeaveFeather"))
                    {
                        Misspossibility += 2;
                        player.moveSpeed += 0.6f;
                        player.wingTimeMax += 60;
                        player.jumpSpeedBoost += 1.8f;
                        player.lifeRegen += 3;
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("LeaveFeather"))
                    {
                        Misspossibility += 2;
                        player.moveSpeed += 0.6f;
                        player.wingTimeMax += 60;
                        player.jumpSpeedBoost += 1.8f;
                        player.lifeRegen += 3;
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("LightingFeather"))
                    {
                        Misspossibility += 3;
                        player.moveSpeed += 0.84f;
                        player.wingTimeMax += 78;
                        player.jumpSpeedBoost += 2.52f;
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("DarkGoldFeather"))
                    {
                        Misspossibility += 4;
                        player.moveSpeed += 1.3f;
                        player.wingTimeMax += 180;
                        player.jumpSpeedBoost += 3.9f;
                        player.meleeCrit += 4;
                        player.magicCrit += 4;
                        player.thrownCrit += 4;
                        player.rangedCrit += 4;
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("PoisonFeather"))
                    {
                        Misspossibility += 2;
                        player.moveSpeed += 0.5f;
                        player.wingTimeMax += 30;
                        player.jumpSpeedBoost += 1.5f;
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("RainbowFeather"))
                    {
                        Misspossibility += 1;
                        player.moveSpeed += 0.7f;
                        player.wingTimeMax += 48;
                        player.jumpSpeedBoost += 2.1f;
                        player.meleeCrit += 1;
                        player.magicCrit += 1;
                        player.thrownCrit += 1;
                        player.rangedCrit += 1;
                        player.meleeDamage += 0.01f;
                        player.rangedDamage += 0.01f;
                        player.magicDamage += 0.01f;
                        player.minionDamage += 0.01f;
                        player.thrownDamage += 0.01f;
                        player.statLifeMax2 += 10;
                        player.statManaMax2 += 10;
                        player.lifeRegen += 1;
                        player.manaRegen += 1;
                        player.statDefense += 2;
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("RedSnowFeather"))
                    {
                        Misspossibility += 2;
                        player.moveSpeed += 0.86f;
                        player.wingTimeMax += 60;
                        player.jumpSpeedBoost += 2.58f;
                        player.statLifeMax2 += 40;
                        player.lifeRegen += 3;
                    }
                    if (CrystalEffectMain.fea[i] == mod.ItemType("StarlightFeather"))
                    {
                        Misspossibility += 2;
                        player.moveSpeed += 0.4f;
                        player.wingTimeMax += 54;
                        player.jumpSpeedBoost += 1.2f;
                        player.statLifeMax2 += 50;
                        player.manaRegen += 4;
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
            if (MythWorld.Myth && base.player.whoAmI == Main.myPlayer)
            {
                base.player.thrownDamage += 0.2f;
                base.player.rangedDamage += 0.2f;
                base.player.meleeDamage += 0.2f;
                base.player.magicDamage += 0.2f;
                base.player.minionDamage += 0.2f;
            }
            if (player.HasBuff(mod.BuffType("雨露")))
            {
                player.magicDamage *= 1 + Main.maxRaining / 3f;
                player.meleeDamage *= 1 + Main.maxRaining / 3f;
                player.thrownDamage *= 1 + Main.maxRaining / 3f;
                player.minionDamage *= 1 + Main.maxRaining / 3f;
                player.rangedDamage *= 1 + Main.maxRaining / 3f;
                player.lifeRegen += (int)(Main.maxRaining * 5f);
            }
            if (player.HasBuff(mod.BuffType("嗜血狂暴")))
            {
                player.magicDamage *= 1 + Crazyindex * 0.02f;
                player.meleeDamage *= 1 + Crazyindex * 0.02f;
                player.thrownDamage *= 1 + Crazyindex * 0.02f;
                player.minionDamage *= 1 + Crazyindex * 0.02f;
                player.rangedDamage *= 1 + Crazyindex * 0.02f;
            }
            if (Duke > 0)
            {
                Misspossibility += 12;
            }
            if (player.HasBuff(mod.BuffType("Missable")))
            {
                Misspossibility += 6;
            }
            if (BeeFeather > 0)
            {
                Misspossibility += 6;
            }
            if (GreenHat)
            {
                player.magicDamage *= 1.06f;
                player.meleeDamage *= 1.06f;
                player.thrownDamage *= 1.06f;
                player.minionDamage *= 1.06f;
                player.rangedDamage *= 1.06f;
                player.meleeCrit += 4;
                player.rangedCrit += 4;
                player.magicCrit += 4;
                player.thrownCrit += 4;
            }
            if (LonelyJelly)
            {
                player.lifeRegen += 5;
            }
            if (BayBerryBubble)
            {
                player.magicDamage *= 1.13f;
                player.meleeDamage *= 1.13f;
                player.thrownDamage *= 1.13f;
                player.minionDamage *= 1.13f;
                player.rangedDamage *= 1.13f;
            }
            if (B25)
            {
                player.magicDamage *= 1.19f;
                player.meleeDamage *= 1.19f;
                player.thrownDamage *= 1.19f;
                player.minionDamage *= 1.19f;
                player.rangedDamage *= 1.19f;
            }
            if (BloodyMarie)
            {
                player.meleeCrit += 11;
                player.rangedCrit += 11;
                player.magicCrit += 11;
                player.thrownCrit += 11;
            }
            if (BlueHawaii)
            {
                player.lifeRegen += 5;
            }
            if (Boluolita)
            {
                player.lifeRegen += 3;
                player.manaRegen += 4;
            }
            if (BurningHell)
            {
                player.statDefense -= 18;
                player.lifeRegen += 25;
            }
            if (CubaLibre)
            {
                player.maxRunSpeed *= 1.07f;
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
                player.meleeCrit += 8;
                player.rangedCrit += 8;
                player.magicCrit += 8;
                player.thrownCrit += 8;
            }
            if (GoldFeishi)
            {
                player.statDefense += 9;
            }
            if (JinglingFeishi)
            {
                player.magicDamage *= 1.04f;
                player.meleeDamage *= 1.04f;
                player.thrownDamage *= 1.04f;
                player.minionDamage *= 1.04f;
                player.rangedDamage *= 1.04f;
                player.meleeCrit += 6;
                player.rangedCrit += 6;
                player.magicCrit += 6;
                player.thrownCrit += 6;
            }
            if (JinglingMojituo)
            {
                player.magicDamage *= 1.07f;
                player.meleeDamage *= 1.07f;
                player.thrownDamage *= 1.07f;
                player.minionDamage *= 1.07f;
                player.rangedDamage *= 1.07f;
                player.meleeCrit += 3;
                player.rangedCrit += 3;
                player.magicCrit += 3;
                player.thrownCrit += 3;
                Misspossibility += 2;
            }
            if (Lavender)
            {
                player.magicDamage *= 1.11f;
                player.meleeDamage *= 1.11f;
                player.thrownDamage *= 1.11f;
                player.minionDamage *= 1.11f;
                player.rangedDamage *= 1.11f;
                Misspossibility += 9;
            }
            if (Mexican)
            {
                player.statDefense += 10;
            }
            if (NorthLandSpring)
            {
                player.lifeRegen += 5;
            }
            if (MoonTonight)
            {
                player.manaRegen += 8;
            }
            if (OrangeD)
            {
                player.magicDamage *= 1.05f;
                player.meleeDamage *= 1.05f;
                player.thrownDamage *= 1.05f;
                player.minionDamage *= 1.05f;
                player.rangedDamage *= 1.05f;
                player.statDefense += 5;
            }
            if (PinaColada)
            {
                Misspossibility += 4;
                player.statDefense += 9;
            }
            if (PurpleCrystal)
            {
                Misspossibility += 10;
            }
            if (PinkLady)
            {
                Misspossibility += 5;
                player.meleeCrit += 10;
                player.rangedCrit += 10;
                player.magicCrit += 10;
                player.thrownCrit += 10;
            }
            if (Screwdriver)
            {
                player.statDefense -= 20;
                player.magicDamage *= 1.2f;
                player.meleeDamage *= 1.2f;
                player.thrownDamage *= 1.2f;
                player.minionDamage *= 1.2f;
                player.rangedDamage *= 1.2f;
            }
            if (SeaFlower)
            {
                player.magicDamage *= 1.07f;
                player.meleeDamage *= 1.07f;
                player.thrownDamage *= 1.07f;
                player.minionDamage *= 1.07f;
                player.rangedDamage *= 1.07f;
            }
            if (SexOnTheBeach)
            {
                player.magicDamage *= 1.08f;
                player.meleeDamage *= 1.08f;
                player.thrownDamage *= 1.08f;
                player.minionDamage *= 1.08f;
                player.rangedDamage *= 1.08f;
            }
            if (SglyBeer)
            {
                player.magicDamage *= 1.09f;
                player.meleeDamage *= 1.09f;
                player.thrownDamage *= 1.09f;
                player.minionDamage *= 1.09f;
                player.rangedDamage *= 1.09f;
            }
            if (SingaporeSling)
            {
                player.lifeRegen += 6;
            }
            if (StrawberryMojituo)
            {
                player.lifeRegen += 7;
            }
            if (SummerStarrySky)
            {
                player.manaRegen += 4;
            }
            if (SunsetGlow)
            {
                player.manaRegen += 5;
            }
            if (TequilaSunrise)
            {
                player.manaRegen += 6;
            }
            if (U8Grapefruit)
            {
                player.magicDamage *= 1.04f;
                player.meleeDamage *= 1.04f;
                player.thrownDamage *= 1.04f;
                player.minionDamage *= 1.04f;
                player.rangedDamage *= 1.04f;
                player.lifeRegen += 3;
            }
            if (WithOutBerry)
            {
                player.magicDamage *= 1.09f;
                player.meleeDamage *= 1.09f;
                player.thrownDamage *= 1.09f;
                player.minionDamage *= 1.09f;
                player.rangedDamage *= 1.09f;
                player.lifeRegen += 1;
            }
            if (YoghurtCaribbean)
            {
                player.magicDamage *= 1.1f;
                player.meleeDamage *= 1.1f;
                player.thrownDamage *= 1.1f;
                player.minionDamage *= 1.1f;
                player.rangedDamage *= 1.1f;
            }
            if (Magelite)
            {
                Misspossibility += 9;
            }
            if (MagicalPlanit)
            {
                player.magicDamage *= 1.02f;
                player.meleeDamage *= 1.02f;
                player.thrownDamage *= 1.02f;
                player.minionDamage *= 1.02f;
                player.rangedDamage *= 1.02f;
                player.meleeCrit += 2;
                player.rangedCrit += 2;
                player.magicCrit += 2;
                player.thrownCrit += 2;
                Misspossibility += 2;
                player.lifeRegen += 2;
                player.statDefense += 4;
            }
            if (OceanCatch)
            {
                player.statDefense += 14;
            }
            if (PurpleFreeze)
            {
                player.meleeCrit += 12;
                player.rangedCrit += 12;
                player.magicCrit += 12;
                player.thrownCrit += 12;
            }
            if (SouthAmMitNight)
            {
                player.moveSpeed *= 1.1f;
                player.wingTimeMax = (int)(player.wingTimeMax * 1.2f);
            }
            if (TrafficLight)
            {
                Misspossibility += 6;
                player.magicDamage *= 1.08f;
                player.meleeDamage *= 1.08f;
                player.thrownDamage *= 1.08f;
                player.minionDamage *= 1.08f;
                player.rangedDamage *= 1.08f;
                player.statDefense -= 7;
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
                player.statDefense += AddDef + 7;
            }
            if (PowerIncr > 0)
            {
                player.magicDamage += 3;
                player.meleeDamage += 3;
                player.minionDamage += 3;
                player.rangedDamage += 3;
                player.thrownDamage += 3;
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
                player.magicDamage *= 0.01f;
                player.meleeDamage *= 0.01f;
                player.minionDamage *= 0.01f;
                player.rangedDamage *= 0.01f;
                player.thrownDamage *= 0.01f;
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
        public override TagCompound Save()
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
        public override void Load(TagCompound tag)
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
                    I[i] = mod.ItemType("BirdFeather");
                }
                if (S[i] == "冠蓝鸦毛")
                {
                    I[i] = mod.ItemType("BlueBirdFeather");
                }
                if (S[i] == "腐化魔羽")
                {
                    I[i] = mod.ItemType("CorruptFeather");
                }
                if (S[i] == "猩红血羽")
                {
                    I[i] = mod.ItemType("CrimsonFeather");
                }
                if (S[i] == "暗夜幽羽")
                {
                    I[i] = mod.ItemType("DarkFeather");
                }
                if (S[i] == "幽冥羽")
                {
                    I[i] = mod.ItemType("GhostFeather");
                }
                if (S[i] == "金鸟毛")
                {
                    I[i] = mod.ItemType("GoldBirdFeather");
                }
                if (S[i] == "灿金之羽")
                {
                    I[i] = mod.ItemType("GoldFeather");
                }
                if (S[i] == "叶之羽")
                {
                    I[i] = mod.ItemType("LeaveFeather");
                }
                if (S[i] == "雷霆羽")
                {
                    I[i] = mod.ItemType("LightingFeather");
                }
                if (S[i] == "毒羽")
                {
                    I[i] = mod.ItemType("PoisonFeather");
                }
                if (S[i] == "彩虹之羽")
                {
                    I[i] = mod.ItemType("RainbowFeather");
                }
                if (S[i] == "红雀毛")
                {
                    I[i] = mod.ItemType("RedBirdFeather");
                }
                if (S[i] == "雪里红羽")
                {
                    I[i] = mod.ItemType("RedSnowFeather");
                }
                if (S[i] == "纯白雪羽")
                {
                    I[i] = mod.ItemType("SnowFeather");
                }
                if (S[i] == "星尘羽")
                {
                    I[i] = mod.ItemType("StardustFeather");
                }
                if (S[i] == "日耀羽")
                {
                    I[i] = mod.ItemType("SolarFeather");
                }
                if (S[i] == "荧星之羽")
                {
                    I[i] = mod.ItemType("StarlightFeather");
                }
                if (S[i] == "暮光羽")
                {
                    I[i] = mod.ItemType("TwilightFeather");
                }
                if (S[i] == "虚空幻羽")
                {
                    I[i] = mod.ItemType("VoidFeather");
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
                int num = base.player.FindItem(base.mod.ItemType("LargeTurquoise"));
                if (num >= 0)
                {
                    base.player.inventory[num].stack--;
                    Item.NewItem((int)base.player.position.X, (int)base.player.position.Y, base.player.width, base.player.height, base.mod.ItemType("LargeTurquoise"), 1, false, 0, false, false);
                    if (base.player.inventory[num].stack <= 0)
                    {
                        base.player.inventory[num] = new Item();
                    }
                }
            }
            if (this.LargeAquamarine)
            {
                int num = base.player.FindItem(base.mod.ItemType("LargeAquamarine"));
                if (num >= 0)
                {
                    base.player.inventory[num].stack--;
                    Item.NewItem((int)base.player.position.X, (int)base.player.position.Y, base.player.width, base.player.height, base.mod.ItemType("LargeAquamarine"), 1, false, 0, false, false);
                    if (base.player.inventory[num].stack <= 0)
                    {
                        base.player.inventory[num] = new Item();
                    }
                }
            }
            if (this.LargeOlivine)
            {
                int num = base.player.FindItem(base.mod.ItemType("LargeOlivine"));
                if (num >= 0)
                {
                    base.player.inventory[num].stack--;
                    Item.NewItem((int)base.player.position.X, (int)base.player.position.Y, base.player.width, base.player.height, base.mod.ItemType("LargeOlivine"), 1, false, 0, false, false);
                    if (base.player.inventory[num].stack <= 0)
                    {
                        base.player.inventory[num] = new Item();
                    }
                }
            }
            if (player.name == "万象元素")
            {
                player.active = true;
                player.dead = false;
                player.statLife = player.statLifeMax2;
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

        public override void SetupStartInventory(IList<Item> items)
        {
            if (Main.expertMode == true)
            {
                {
                    Item item = new Item();
                    item.SetDefaults(mod.ItemType("神话卷轴"));
                    item.stack = 1;
                    items.Add(item);
                }
            }
        }
    }
}