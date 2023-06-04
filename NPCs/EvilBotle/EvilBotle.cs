using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using System.IO;
using Terraria.ID;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;

namespace MythMod.NPCs.EvilBotle
{
    [AutoloadBossHead]
    public class EvilBotle : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("封魔石瓶");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "封魔石瓶");
        }
        private bool X = true;
        private int num10;
        private int ADDnum = 0;
        private float num13;
        private bool T = false;
        public override void SetDefaults()
        {
            NPC.behindTiles = true;
            base.NPC.damage = 0;
            base.NPC.width = 120;
            base.NPC.height = 160;
            base.NPC.defense = 40;
            bossBag/* tModPorter Note: Removed. Spawn the treasure bag alongside other loot via npcLoot.Add(ItemDropRule.BossBag(type)) */ = Mod.Find<ModItem>("EvilBotleTreasureBag").Type;
            base.NPC.lifeMax = (Main.expertMode ? 11000 : 8000);
            if (MythWorld.Myth)
            {
                base.NPC.lifeMax = 17000;
            }
            for (int i = 0; i < base.NPC.buffImmune.Length; i++)
            {
                base.NPC.buffImmune[i] = true;
            }
            NPC.knockBackResist = 0f;
            base.NPC.value = (float)Item.buyPrice(0, 2, 0, 0);
            base.NPC.color = new Color(0, 0, 0, 0);
            base.NPC.aiStyle = -1;
            this.AIType = -1;
            base.NPC.boss = true;
            base.NPC.lavaImmune = true;
            base.NPC.noGravity = false;
            base.NPC.noTileCollide = false;
            base.NPC.HitSound = SoundID.NPCHit2;
            base.NPC.DeathSound = SoundID.NPCDeath5;
            this.Music = 12;
        }
        public bool Lowerthan12000 = false;
        public bool Lowerthan1000 = false;
        public int Atype = 0;
        public float Al = 0;
        public override void AI()
        {
            base.NPC.TargetClosest(false);
            Player player = Main.player[base.NPC.target];
            bool flag2 = (double)base.NPC.life <= (double)base.NPC.lifeMax * 0.8;
            bool expertMode = Main.expertMode;
            bool zoneUnderworldHeight = player.ZoneUnderworldHeight;
            Vector2 vector = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
            Vector2 center = base.NPC.Center;
            float num = player.Center.X - vector.X;
            float num2 = player.Center.Y - vector.Y;
            float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
            base.NPC.localAI[0] += 1;
            ADDnum += 1;
            if (!player.active || player.dead)
            {
                base.NPC.TargetClosest(false);
                player = Main.player[base.NPC.target];
                if (!player.active || player.dead)
                {
                    base.NPC.alpha += 5;
                    if (base.NPC.timeLeft > 150)
                    {
                        base.NPC.timeLeft = 150;
                    }
                    if (base.NPC.alpha >= 254)
                    {
                        base.NPC.velocity = new Vector2(0f, 1000f);
                        NPC.noTileCollide = true;
                        NPC.active = false;
                    }
                    return;
                }
            }
            if(NPC.CountNPCS(Mod.Find<ModNPC>("EvilBotleFake").Type) > 0)
            {
                NPC.dontTakeDamage = true;
                if(Al < 1)
                {
                    Al += 0.01f;
                }
            }
            else
            {
                NPC.dontTakeDamage = false;
                if (Al > 0)
                {
                    Al -= 0.01f;
                }
            }
            if (!MythWorld.Myth)
            {
                if (NPC.localAI[0] < 1200 && NPC.localAI[0] % 40 == 0)
                {
                    int Dam = 30;
                    if (Main.expertMode)
                    {
                        Dam = 20;
                        if (MythWorld.Myth)
                        {
                            Dam = 15;
                        }
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        Vector2 v = new Vector2(Main.rand.Next(-400, 400) * NPC.spriteDirection, Main.rand.Next(-1300, -600)).RotatedBy(Main.rand.NextFloat(-0.75f, 0.75f)) * 0.01f;
                        Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y - 35, v.X, v.Y - 4, Mod.Find<ModProjectile>("DarkFlameball").Type, Dam, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
                /*if (npc.localAI[0] % 600 == 0)
                {
                    Vector2 vu = base.npc.Center + new Vector2(0f, (float)base.npc.height / 2f);
                    NPC.NewNPC((int)vu.X, (int)vu.Y - 35, mod.NPCType("EvilDragon"), 0, 0f, 0f, 0f, 0f, 255);
                }*/
                if (NPC.localAI[0] % 600 == 0)
                {
                    Vector2 vu = base.NPC.Center + new Vector2(0f, (float)base.NPC.height / 2f);
                    NPC.NewNPC((int)vu.X, (int)vu.Y - 35, Mod.Find<ModNPC>("EvilBotleFake").Type, 0, 0f, 0f, 0f, 0f, 255);
                }
                if (NPC.localAI[0] >= 1200 && NPC.localAI[0] < 2400)
                {
                    int Dam = 30;
                    if (Main.expertMode)
                    {
                        Dam = 20;
                        if (MythWorld.Myth)
                        {
                            Dam = 15;
                        }
                    }
                    if (NPC.localAI[0] % 60 == 0)
                    {
                        Vector2 v = new Vector2(Main.rand.Next(-400, 400) * NPC.spriteDirection, Main.rand.Next(-1300, -600)).RotatedBy(Main.rand.NextFloat(-0.75f, 0.75f)) * 0.01f;
                        Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y - 35, v.X, v.Y - 4, Mod.Find<ModProjectile>("DarkFlameball").Type, Dam, 0f, Main.myPlayer, 0f, 0f);
                    }
                    if (NPC.localAI[0] == 1200)
                    {
                        Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y - 200, 0, 0, Mod.Find<ModProjectile>("DarkFlameMagic").Type, Dam, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
                if (NPC.localAI[0] >= 2400)
                {
                    NPC.localAI[0] = 0;
                }
            }
            else
            {
                if (NPC.life > NPC.lifeMax * 0.6f && NPC.localAI[0] % 40 == 0)
                {
                    int Dam = 30;
                    if (Main.expertMode)
                    {
                        Dam = 20;
                        if (MythWorld.Myth)
                        {
                            Dam = 15;
                        }
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        Vector2 v = new Vector2(Main.rand.Next(-400, 400) * NPC.spriteDirection, Main.rand.Next(-1300, -600)).RotatedBy(Main.rand.NextFloat(-0.75f, 0.75f)) * 0.01f;
                        Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y - 35, v.X, v.Y - 4, Mod.Find<ModProjectile>("DarkFlameball").Type, Dam, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
                if (NPC.life <= NPC.lifeMax * 0.6f)
                {
                    if(!Lowerthan12000)
                    {
                        this.Music = Mod.GetSoundSlot((Terraria.ModLoader.SoundType)51, "Sounds/Music/Bottle");
                        Lowerthan12000 = true;
                        NPC.localAI[0] = -300;
                    }
                    if (NPC.life <= 1000)
                    {
                        /*if (!Lowerthan1000)
                        {
                            Lowerthan1000 = true;
                            Vector2 vu = base.npc.Center + new Vector2(0f, (float)base.npc.height / 2f);
                            NPC.NewNPC((int)vu.X, (int)vu.Y - 35, mod.NPCType("EvilBotleBreak"), 0, 0f, 0f, 0f, 0f, 255);
                        }*/
                    }
                    if(Lowerthan1000)
                    {
                        Blife = NPC.life;
                    }
                    if (NPC.localAI[0] > 0 && NPC.localAI[0] < 600)
                    {
                        if(NPC.localAI[0] == 1)
                        {
                            Atype = Main.rand.Next(2);
                        }
                        if(Atype == 0)
                        {
                            if (NPC.localAI[0] % 6 == 2)
                            {
                                Vector2 v = new Vector2(Main.rand.NextFloat(-0.5f, 0.5f) * NPC.spriteDirection, Main.rand.Next(-800, -790)) * 0.01f;
                                Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y - 55, v.X, v.Y + 6, Mod.Find<ModProjectile>("EvilCloud").Type, 0, 0f, Main.myPlayer, 0f, 0f);
                            }
                            if (NPC.localAI[0] >= 120 && NPC.localAI[0] < 650)
                            {
                                Vector2 p0 = NPC.Center + new Vector2(0, 250);
                                float X = Main.rand.NextFloat(-400f, 400f);
                                float Y = (float)Math.Sqrt(90000 - 0.75f * X * X);
                                Vector2 vc = new Vector2(X, Y) * Main.rand.NextFloat(-1f, 1f);
                                int z = Dust.NewDust(NPC.Center - new Vector2(4, 4) + p0 + vc, 2, 2, 109, 0, 0, 0, default(Color), Main.rand.NextFloat(2.5f, 5f));
                                Main.dust[z].noGravity = true;
                                float X0 = Main.rand.NextFloat(-200f, 200f);
                                float Y0 = -(float)Math.Sqrt(30000 - 0.75f * X0 * X0);
                                Vector2 vc0 = new Vector2(X0, Y0) * Main.rand.NextFloat(-1f, 1f);
                                int z0 = Dust.NewDust(NPC.Center - new Vector2(4, 4) + p0 + vc0, 2, 2, 109, 0, 0, 0, default(Color), Main.rand.NextFloat(2.5f, 5f));
                                Main.dust[z0].noGravity = true;
                            }
                        }
                        if(Atype == 1)
                        {
                            if (NPC.localAI[0] % 16 == 2)
                            {
                                Vector2 v = new Vector2((NPC.localAI[0] % 300 - 150) * 7, 0);
                                Projectile.NewProjectile(NPC.Center.X + v.X, NPC.Center.Y - 55, 0, -6, Mod.Find<ModProjectile>("LigRelis").Type, 0, 0f, Main.myPlayer, 0f, 0f);
                            }
                            if (NPC.localAI[0] % 16 == 10)
                            {
                                Vector2 v = new Vector2(-(NPC.localAI[0] % 300 - 150) * 7, 0);
                                Projectile.NewProjectile(NPC.Center.X + v.X, NPC.Center.Y - 55, 0, -6, Mod.Find<ModProjectile>("LigRelis").Type, 0, 0f, Main.myPlayer, 0f, 0f);
                            }
                        }
                    }
                    if (NPC.localAI[0] > 600 && NPC.localAI[0] < 1200)
                    {
                        if (NPC.localAI[0] == 601)
                        {
                            Atype = Main.rand.Next(2);
                        }
                        int Dam = 30;
                        if (Main.expertMode)
                        {
                            Dam = 20;
                            if (MythWorld.Myth)
                            {
                                Dam = 15;
                            }
                        }
                        if (Atype == 0)
                        {
                            if (NPC.localAI[0] % 6 == 2)
                            {
                                Vector2 v = new Vector2(Main.rand.Next(-400, 400) * NPC.spriteDirection, Main.rand.Next(-2000, -1100)).RotatedBy(Main.rand.NextFloat(-0.75f, 0.75f)) * 0.01f;
                                Projectile.NewProjectile(NPC.Center.X + 12, NPC.Center.Y - 35, v.X, v.Y + Main.rand.NextFloat(-6f, -4.5f), Mod.Find<ModProjectile>("SuperDarkFlameball").Type, Dam * 2, 0f, Main.myPlayer, 0f, 0f);
                            }
                        }
                        if (Atype == 1)
                        {
                            if (NPC.localAI[0] % 120 == 2)
                            {
                                for (int t = 0; t < 20; t++)
                                {
                                    Vector2 v = new Vector2((float)Math.Sin(NPC.localAI[0] / 30f) * 400, Main.rand.Next(-2000, -1100)).RotatedBy(Main.rand.NextFloat(-0.75f, 0.75f)) * 0.01f;
                                    Projectile.NewProjectile(NPC.Center.X + 12, NPC.Center.Y - 35, v.X, v.Y + Main.rand.NextFloat(-9f, -1.5f), Mod.Find<ModProjectile>("SuperDarkFlameball").Type, Dam * 2, 0f, Main.myPlayer, 0f, 0f);
                                }
                            }
                        }
                    }
                    /*if (npc.localAI[0] % 600 == 0)
                    {
                        Vector2 vu = base.npc.Center + new Vector2(0f, (float)base.npc.height / 2f);
                        NPC.NewNPC((int)vu.X, (int)vu.Y - 35, mod.NPCType("EvilDragon"), 0, 0f, 0f, 0f, 0f, 255);
                    }*/
                    if (NPC.localAI[0] % 1200 == 0)
                    {
                        Vector2 vu = base.NPC.Center + new Vector2(0f, (float)base.NPC.height / 2f);
                        NPC.NewNPC((int)vu.X, (int)vu.Y - 35, Mod.Find<ModNPC>("EvilBotleFake").Type, 0, 0f, 0f, 0f, 0f, 255);
                    }
                    if (NPC.localAI[0] > 1200 && NPC.localAI[0] < 2400)
                    {
                        if (NPC.localAI[0] == 1201)
                        {
                            Atype = Main.rand.Next(3);
                        }
                        int Dam = 11;
                        Vector2 v8 = player.Center;
                        if(Atype == 0)
                        {
                            if (NPC.localAI[0] % 6 == 2)
                            {
                                Projectile.NewProjectile(v8.X, v8.Y, 0, 0, Mod.Find<ModProjectile>("DarkFlameMagicFirst").Type, 0, 0f, Main.myPlayer, Dam, 0f);
                            }
                        }
                        if (Atype == 1)
                        {
                            if (NPC.localAI[0] % 20 == 2)
                            {
                                Vector2 va = new Vector2(0, Main.rand.NextFloat(60f, 360f)).RotatedByRandom(Math.PI * 2d);
                                Projectile.NewProjectile(v8.X + va.X, v8.Y + va.Y, 0, 0, Mod.Find<ModProjectile>("DarkFlameMagicFirst").Type, 0, 0f, Main.myPlayer, Dam, 0f);
                            }
                        }
                        if (Atype == 2)
                        {
                            if (NPC.localAI[0] % 120 == 2)
                            {
                                for (int t = 0; t < 30; t++)
                                {
                                    Vector2 va = new Vector2(0, Main.rand.NextFloat(60f, 1200f)).RotatedByRandom(Math.PI * 2d);
                                    Projectile.NewProjectile(v8.X + va.X, v8.Y + va.Y, 0, 0, Mod.Find<ModProjectile>("DarkFlameMagicFirst").Type, 0, 0f, Main.myPlayer, Dam, 0f);
                                }
                            }
                        }
                        /*else
                        {
                            Projectile.NewProjectile(npc.Center.X + v.X, npc.Center.Y - 200 + v.Y, 0, 0, mod.ProjectileType("DarkFlameMagicTriangle"), Dam, 0f, Main.myPlayer, 0f, 0f);
                        }*/
                    }
                    /*if (npc.localAI[0] >= 1200 && npc.localAI[0] < 2400)
                    {
                        if (npc.localAI[0] % 90 == 0)
                        {
                            Vector2 v = new Vector2(Main.rand.Next(-400, 400) * npc.spriteDirection, Main.rand.Next(-1300, -600)).RotatedBy(Main.rand.NextFloat(-0.75f, 0.75f)) * 0.01f;
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 35, v.X, v.Y - 4, mod.ProjectileType("DarkFlameball"), 70, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }*/
                    if (NPC.localAI[0] > 2400 && NPC.localAI[0] < 3600)
                    {
                        Vector2 v8 = player.Center;
                        if (NPC.localAI[0] == 2401)
                        {
                            Atype = Main.rand.Next(2);
                        }
                        if (Atype == 0)
                        {
                            if (NPC.localAI[0] % 6 == 0)
                            {
                                Vector2 v = new Vector2(Main.rand.Next(-4, 4) * NPC.spriteDirection, Main.rand.Next(-800, -790)) * 0.01f;
                                Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y - 35, v.X, v.Y - 4, Mod.Find<ModProjectile>("DarkFlame").Type, 25, 0f, Main.myPlayer, 0f, 0f);
                            }
                            if (NPC.localAI[0] % 9 == 0)
                            {
                                Projectile.NewProjectile(player.Center.X + Main.rand.Next(-800, 800), NPC.Center.Y - 35, 0, -4, Mod.Find<ModProjectile>("DarkBoom0").Type, 0, 0f, Main.myPlayer, 0f, 0f);
                            }
                            if (NPC.localAI[0] % 20 == 0)
                            {
                                Vector2 vp = new Vector2(0, Main.rand.Next(200, 400)).RotatedByRandom(Math.PI * 2);
                                Projectile.NewProjectile(player.Center.X + vp.X, player.Center.Y + vp.Y, 0, 0, Mod.Find<ModProjectile>("DarkFire").Type, 17, 0f, Main.myPlayer, 0f, 0f);
                            }
                        }
                        if (Atype == 1)
                        {
                            if (NPC.localAI[0] % 6 == 0)
                            {
                                Vector2 va = new Vector2(0, Main.rand.NextFloat(60f, 600f)).RotatedByRandom(Math.PI * 2d);
                                if(Main.tile[(int)((v8.X + va.X) / 16), (int)((v8.Y + va.Y) / 16)].HasTile)
                                {
                                    va = new Vector2(0, Main.rand.NextFloat(60f, 900f)).RotatedByRandom(Math.PI * 2d);
                                }
                                Projectile.NewProjectile(v8.X + va.X, v8.Y + va.Y, 0, 0, Mod.Find<ModProjectile>("PurpleRush").Type, 0, 0f, Main.myPlayer, Main.rand.Next(3) + 1, 0f);
                            }
                            if (NPC.localAI[0] % 20 == 0)
                            {
                                Vector2 vp = new Vector2(0, Main.rand.Next(200, 400)).RotatedByRandom(Math.PI * 2);
                                Projectile.NewProjectile(player.Center.X + vp.X, player.Center.Y + vp.Y, 0, 0, Mod.Find<ModProjectile>("DarkFire").Type, 17, 0f, Main.myPlayer, 0f, 0f);
                            }
                        }
                    }
                    if (NPC.localAI[0] == 3601)
                    {
                        Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y - 95, 0, 0, Mod.Find<ModProjectile>("DarkLazerBall").Type, 50, 0f, Main.myPlayer, 0, 0f);
                    }
                    /*if (npc.localAI[0] >= 0 && npc.localAI[0] < 3600)
                    {
                        if (npc.localAI[0] % 6 == 0)
                        {
                            Vector2 v = new Vector2(Main.rand.Next(-4, 4) * npc.spriteDirection, Main.rand.Next(-800, -790)) * 0.01f;
                            Projectile.NewProjectile(npc.Center.X - 5, npc.Center.Y - 58, v.X, v.Y - 4, mod.ProjectileType("DarkFlame2"), 150, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }*/
                    if (NPC.localAI[0] >= 4211)
                    {
                        NPC.localAI[0] = 0;
                    }
                }
            }
            if(Addlig > 0.5f)
            {
                Addlig *= 0.95f;
            }
        }
        public static float Blife = 1000;
        public static float Addlig = 0.5f;
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (base.NPC.life <= 0)
            {
                for (int j = 0; j < 80; j++)
                {
                    Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 5, (float)hitDirection, -1f, 0, default(Color), 1f);
                }
                base.NPC.position.X = base.NPC.position.X + (float)(base.NPC.width / 2);
                base.NPC.position.Y = base.NPC.position.Y + (float)(base.NPC.height / 2);
                base.NPC.position.X = base.NPC.position.X - (float)(base.NPC.width / 2);
                base.NPC.position.Y = base.NPC.position.Y - (float)(base.NPC.height / 2);
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/EvilBotleGore1"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/EvilBotleGore2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/EvilBotleGore3"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/EvilBotleGore4"), 1f);
            }
        }
        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
        }
        public Vector2[] Pm = new Vector2[1024];
        public int Wo = 0;
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Vector2[] P = new Vector2[50];
            Vector2[] Pn = new Vector2[1024];
            int[] N = new int[50];
            float[] L = new float[50];
            int[] T = new int[50];
            int[] Ts = new int[50];
            Vector2 V0 = NPC.Center + new Vector2(0, -78);
            int m = 0;
            int n = 0;
            int u = 0;
            int w = 0;
            for (int i = 0; i < 49; i++)
            {
                N[i] = -1;
            }
            for (int i = 0; i < 1000; i++)
            {                
                if(Main.projectile[i].type == Mod.Find<ModProjectile>("DarkFlame").Type && Main.projectile[i].active)
                {
                    N[m] = i;
                    m += 1; 
                }
            }
            for (int i = 0; i < 49; i++)
            {
                if (N[i] != -1)
                {
                    T[i] = Main.projectile[N[i]].timeLeft;
                    Ts[i] = N[i];
                    /*string key2 = Main.projectile[N[i]].ToString();
                    Main.NewText(Language.GetTextValue(key2), Color.Yellow);*/
                }
                else
                {
                    break;
                }
            }            
            for (int t = 180; t > 2; t--)
            {
                for (int i = 0; i < m; i++)
                {
                    if (T[i] == t)
                    {
                        P[n] = Main.projectile[Ts[i]].Center;
                        n += 1;
                    }
                }
            }
            /*for (int i = 0; i < 49; i++)
            {
                if(P[i] != new Vector2(0, 0))
                {
                    if(i == 0)
                    {
                        L[u] = (P[i] - V0).Length();
                        u += 1;
                    }
                    else
                    {
                        L[u] = (P[i] - P[i - 1]).Length();
                        u += 1;
                    }
                }
                else
                {
                    break;
                }
            }*/
            for (int i = 0; i < 49; i++)
            {
                if (P[i] != new Vector2(0, 0))
                {
                    if (i >= 2)
                    {
                        for (float j = 0; j < 4; j += 1)
                        {
                            float dt = j / 10f;
                            float A = (1 - dt) * (1 - dt);
                            float B = (1 - dt) * dt * 2;
                            float C = dt * dt;

                                Pn[w] = A * P[i - 2] + B * P[i - 1] + C * P[i];

                            w += 1;
                        }
                    }
                }
                else
                {
                    if(w < 60)
                    {
                        Wo = w;
                    }
                    else
                    {
                        Wo = 60;
                    }
                    break;
                }
            }
            for (int i = 0;i < w;i++)
            {
                if (Pn[i] != new Vector2(0, 0))
                {
                    Pm[i] = Pn[i];
                    /*string key = Pn[i].ToString();
                    Color messageColor = Color.Purple;
                    Main.NewText(Language.GetTextValue(key), messageColor);*/
                    /*float c = (-(i - 50) * (i - 110)) / 8000f;
                    if(c > 0 && i % 4 == 0)
                    {
                        Main.spriteBatch.Draw(base.mod.GetTexture("UIImages/heatmapColdPurpleCircle"), -Main.screenPosition + Pn[i], new Rectangle(0, 0, 256, 256), new Color(c, c, c, 0), 0, new Vector2(128, 128), 1f, SpriteEffects.None, 0f);
                    }
                    string key = i.ToString();
                    Main.NewText(Language.GetTextValue(key), Color.Purple);*/
                }
            }
            for (int im = 0; im < 10; im += 2)
            {
                float size = 0;
                for (float i = im; i < im + 1.2f; i += 0.01f)
                {
                    float theta = i + ADDnum / 30f * (20 - im) / 20f;
                    float da = 1;
                    float db = 1;
                    float dc = ADDnum / 20f;
                    float dn = 3;
                    if (im == 2)
                    {
                        dn = 2;
                    }
                    if (im == 4)
                    {
                        dn = 8;
                    }
                    float scale = (float)(Math.Sin(ADDnum / 20f * ((10 - im) / 10f) + 20 * im) * 10 + 50);
                    if (im == 2)
                    {
                        scale = (float)(Math.Sin(ADDnum / 20f * ((10 - im) / 10f) + 20 * im + 71) * 12 + 60);
                    }
                    if (im == 4)
                    {
                        scale = (float)(Math.Sin(ADDnum / 20f * ((10 - im) / 10f) + 20 * im + 35) * 8 + 44);
                    }
                    if (i < im + 0.3f)
                    {
                        if (size < 1f)
                        {
                            size += 0.1f;
                        }
                    }
                    if (i > im + 1.05f)
                    {
                        if (size > 0)
                        {
                            size -= 0.09f;
                        }
                    }
                    float x = (float)(da * Math.Sin(dn * theta + dc)) * scale;
                    float y = (float)(db * Math.Sin(theta)) * scale;
                    Vector2 v = new Vector2(x, y);
                    if(Math.Cos(dn * theta + dc) > 0)
                    {
                        if (im == 3)
                        {
                            Main.spriteBatch.Draw(base.Mod.GetTexture("UIImages/Pixel"), -Main.screenPosition + NPC.Center + v, new Rectangle(0, 0, 1, 1), new Color((int)(20 * Al * 0.8f * Math.Sqrt(Addlig)), 0, (int)(200 * Al * 0.8f * Addlig), 0), 0, new Vector2(0.5f, 0.5f), size * 3f * (Addlig + 0.5f), SpriteEffects.None, 0f);
                        }
                        else if (im == 5)
                        {
                            Main.spriteBatch.Draw(base.Mod.GetTexture("UIImages/Pixel"), -Main.screenPosition + NPC.Center + v, new Rectangle(0, 0, 1, 1), new Color((int)(41 * Al * 0.8f * Math.Sqrt(Addlig)), 0, (int)(170 * Al * 0.8f * Addlig), 0), 0, new Vector2(0.5f, 0.5f), size * 3f * (Addlig + 0.5f), SpriteEffects.None, 0f);
                        }
                        else
                        {
                            Main.spriteBatch.Draw(base.Mod.GetTexture("UIImages/Pixel"), -Main.screenPosition + NPC.Center + v, new Rectangle(0, 0, 1, 1), new Color((int)(62 * Al * 0.8f * Math.Sqrt(Addlig)), 0, (int)(151 * Al * 0.8f * Addlig), 0), 0, new Vector2(0.5f, 0.5f), size * 3f * (Addlig + 0.5f), SpriteEffects.None, 0f);
                        }
                    }
                }
            }
            return true;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if(Lowerthan12000)
            {
                if(NPC.localAI[0] < 0)
                {
                    float xd = (NPC.localAI[0] + 300) / 300f * 1.625f;
                    float St = (float)(Math.Log(3 * xd + 1 + Math.Sin(xd * 5) * 2)) * 0.49f;
                    Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/EvilBotle/EvilBotleGlow"), -Main.screenPosition + NPC.Center + new Vector2(0, 4), null, new Color(St,St,St, 0), 0, new Vector2(60f, 80f), 1, SpriteEffects.None, 0f);
                }
                else
                {
                    Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/EvilBotle/EvilBotleGlow"), -Main.screenPosition + NPC.Center + new Vector2(0, 4), null, new Color(1f, 1f, 1f, 0), 0, new Vector2(60f, 80f), 1, SpriteEffects.None, 0f);
                }
            }
            for (int im = 0; im < 10; im += 2)
            {
                float size = 0;
                for (float i = im; i < im + 1.2f; i += 0.01f)
                {
                    float theta = i + ADDnum / 30f * (20 - im) / 20f;
                    float da = 1;
                    float db = 1;
                    float dc = ADDnum / 20f;
                    float dn = 3;
                    if (im == 2)
                    {
                        dn = 2;
                    }
                    if (im == 4)
                    {
                        dn = 8;
                    }
                    float scale = (float)(Math.Sin(ADDnum / 20f * ((10 - im) / 10f) + 20 * im) * 10 + 50);
                    if (im == 2)
                    {
                        scale = (float)(Math.Sin(ADDnum / 20f * ((10 - im) / 10f) + 20 * im + 71) * 12 + 60);
                    }
                    if (im == 4)
                    {
                        scale = (float)(Math.Sin(ADDnum / 20f * ((10 - im) / 10f) + 20 * im + 35) * 8 + 44);
                    }
                    if (i < im + 0.3f)
                    {
                        if (size < 1f)
                        {
                            size += 0.1f;
                        }
                    }
                    if (i > im + 1.05f)
                    {
                        if (size > 0)
                        {
                            size -= 0.09f;
                        }
                    }
                    float x = (float)(da * Math.Sin(dn * theta + dc)) * scale;
                    float y = (float)(db * Math.Sin(theta)) * scale;
                    Vector2 v = new Vector2(x, y);
                    if (Math.Cos(dn * theta + dc) <= 0)
                    {
                        if (im == 3)
                        {
                            Main.spriteBatch.Draw(base.Mod.GetTexture("UIImages/Pixel"), -Main.screenPosition + NPC.Center + v, new Rectangle(0, 0, 1, 1), new Color((int)(20 * Al * 0.8f * Math.Sqrt(Addlig)), 0, (int)(200 * Al * 0.8f * Addlig), 0), 0, new Vector2(0.5f, 0.5f), size * 3f * (Addlig + 0.5f), SpriteEffects.None, 0f);
                        }
                        else if (im == 5)
                        {
                            Main.spriteBatch.Draw(base.Mod.GetTexture("UIImages/Pixel"), -Main.screenPosition + NPC.Center + v, new Rectangle(0, 0, 1, 1), new Color((int)(41 * Al * 0.8f * Math.Sqrt(Addlig)), 0, (int)(170 * Al * 0.8f * Addlig), 0), 0, new Vector2(0.5f, 0.5f), size * 3f * (Addlig + 0.5f), SpriteEffects.None, 0f);
                        }
                        else
                        {
                            Main.spriteBatch.Draw(base.Mod.GetTexture("UIImages/Pixel"), -Main.screenPosition + NPC.Center + v, new Rectangle(0, 0, 1, 1), new Color((int)(62 * Al * 0.8f * Math.Sqrt(Addlig)), 0, (int)(151 * Al * 0.8f * Addlig), 0), 0, new Vector2(0.5f, 0.5f), size * 3f * (Addlig + 0.5f), SpriteEffects.None, 0f);
                        }
                    }
                }
            }

            List<CustomVertexInfo> bars = new List<CustomVertexInfo>();
            /*string key = Wo.ToString();
            Main.NewText(Language.GetTextValue(key), Color.Purple);*/
            // 把所有的点都生成出来，按照顺序
            for (int i = 1; i < Wo; ++i)
            {
                if (Pm[i] == Vector2.Zero) break;
                //spriteBatch.Draw(mod.GetTexture("UIImages/Star"), projectile.position + projectile.velocity.RotatedBy(Math.PI / 2d * Dir) * 20 - Main.screenPosition, null, new Color(0.2f, 0f, 0f, 0f), 0f, new Vector2(36f, 36f), (float)Math.Sin(projectile.timeLeft / 30d * Math.PI) * 0.2f, SpriteEffects.None, 0f);
                //spriteBatch.Draw(mod.GetTexture("UIImages/Star"), projectile.position + projectile.velocity.RotatedBy(Math.PI / 2d * Dir) * 20 - Main.screenPosition, null, new Color(0.2f, 0f, 0f, 0f), (float)(Math.PI / 2d), new Vector2(36f, 36f), (float)Math.Sin(projectile.timeLeft / 30d * Math.PI) * 0.6f, SpriteEffects.None, 0f);

                int width = 0;
                width = (int)(i / 2f + 20);
                var normalDir = Pm[i] - Pm[i - 1];
                normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));

                var alpha = (float)0;
                if (i < Wo - 80)
                {
                    alpha = 0;
                }
                else
                {
                    alpha = (i - Wo + 80) / 80f;
                }
                var factor = i / (float)Wo;
                var color = Color.Lerp(Color.White, Color.Blue, factor);
                var w = MathHelper.Lerp(1f, 0.05f, alpha);

                /*if(i > 2)
                {
                    for (int j = 1; j < 9; ++j)
                    {
                        float t = j / 10f;
                        float ti = t - 0.1f;
                        Vector2 vk0 = (projectile.oldPos[i - 2] * (1 - t) * (1 - t) + projectile.oldPos[i - 1] * t * 2 * (1 - t) + projectile.oldPos[i] * t * t);
                        Vector2 vk1 = (projectile.oldPos[i - 2] * (1 - ti) * (1 - ti) + projectile.oldPos[i - 1] * ti * 2 * (1 - ti) + projectile.oldPos[i] * ti * ti);
                        normalDir = vk1 - vk0;
                        normalDir = Vector2.Normalize(new Vector2(-normalDir.Y, normalDir.X));
                        bars.Add(new CustomVertexInfo(vk0 + normalDir * width, color, new Vector3((float)Math.Sqrt(factor), 1, w)));
                        bars.Add(new CustomVertexInfo(vk0 + normalDir * -width, color, new Vector3((float)Math.Sqrt(factor), 0, w)));
                    }
                }*/

                bars.Add(new CustomVertexInfo(Pm[i] + normalDir * width, color, new Vector3((float)Math.Sqrt(factor), 1, w)));
                bars.Add(new CustomVertexInfo(Pm[i] + normalDir * -width, color, new Vector3((float)Math.Sqrt(factor), 0, w)));
            }

            List<CustomVertexInfo> triangleList = new List<CustomVertexInfo>();

            if (bars.Count > 2)
            {

                // 按照顺序连接三角形
                triangleList.Add(bars[0]);
                var vertex = new CustomVertexInfo((bars[0].Position + bars[1].Position) * 0.5f, Color.White, new Vector3(0, 0.5f, 1));
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
                MythMod.DefaultEffectDarkRedGold.Parameters["uTransform"].SetValue(model * projection);
                MythMod.DefaultEffectDarkRedGold.Parameters["uTime"].SetValue(-(float)Main.time * 0.03f);
                Main.graphics.GraphicsDevice.Textures[0] = MythMod.MainColorColdPurple;
                Main.graphics.GraphicsDevice.Textures[1] = MythMod.MainShape;
                Main.graphics.GraphicsDevice.Textures[2] = MythMod.MaskColor;
                Main.graphics.GraphicsDevice.SamplerStates[0] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[1] = SamplerState.PointWrap;
                Main.graphics.GraphicsDevice.SamplerStates[2] = SamplerState.PointWrap;

                //Main.graphics.GraphicsDevice.Textures[0] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[1] = Main.magicPixel;
                //Main.graphics.GraphicsDevice.Textures[2] = Main.magicPixel;

                MythMod.DefaultEffectDarkRedGold.CurrentTechnique.Passes[0].Apply();


                Main.graphics.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, triangleList.ToArray(), 0, triangleList.Count / 3);

                Main.graphics.GraphicsDevice.RasterizerState = originalState;
                spriteBatch.End();
                spriteBatch.Begin();
            }
        }


        // 自定义顶点数据结构，注意这个结构体里面的顺序需要和shader里面的数据相同
        private struct CustomVertexInfo : IVertexType
        {
            private static VertexDeclaration _vertexDeclaration = new VertexDeclaration(new VertexElement[3]
            {
                new VertexElement(0, VertexElementFormat.Vector2, VertexElementUsage.Position, 0),
                new VertexElement(8, VertexElementFormat.Color, VertexElementUsage.Color, 0),
                new VertexElement(12, VertexElementFormat.Vector3, VertexElementUsage.TextureCoordinate, 0)
            });
            public Vector2 Position;
            public Color Color;
            public Vector3 TexCoord;

            public CustomVertexInfo(Vector2 position, Color color, Vector3 texCoord)
            {
                this.Position = position;
                this.Color = color;
                this.TexCoord = texCoord;
            }

            public VertexDeclaration VertexDeclaration
            {
                get
                {
                    return _vertexDeclaration;
                }
            }
        }
        public override void OnKill()
        {
            bool expertMode = Main.expertMode;
            if (expertMode)
            {
                Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y - 40, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("EvilBotleTreasureBag").Type, 1, false, 0, false, false);
            }
            else
            {
                int type = 0;
                switch (Main.rand.Next(1, 9))
                {
                    case 1:
                        type = base.Mod.Find<ModItem>("DarkStaff").Type;
                        break;
                    case 2:
                        type = base.Mod.Find<ModItem>("EvilBomb").Type;
                        break;
                    case 3:
                        type = base.Mod.Find<ModItem>("EvilRing").Type;
                        break;
                    case 4:
                        type = base.Mod.Find<ModItem>("EvilSlingshot").Type;
                        break;
                    case 5:
                        type = base.Mod.Find<ModItem>("EvilSword").Type;
                        break;
                    case 6:
                        type = base.Mod.Find<ModItem>("ShadowYoyo").Type;
                        break;
                    case 7:
                        type = base.Mod.Find<ModItem>("EvilShadowBlade").Type;
                        break;
                    case 8:
                        type = base.Mod.Find<ModItem>("GeometryEvil").Type;
                        break;
                }
                Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y - 40, base.NPC.width, base.NPC.height, type, 1, false, 0, false, false);
                if (Main.rand.Next(10) == 1)
                {
                    //Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y - 40, base.npc.width, base.npc.height, base.mod.ItemType("BloodyTuskPlatfo"), 1, false, 0, false, false);
                }
            }
            int type2 = 0;
            switch (Main.rand.Next(1, 4))
            {
                case 1:
                    type2 = 3096;
                    break;
                case 2:
                    type2 = 3120;
                    break;
                case 3:
                    type2 = 3037;
                    break;
            }
            Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y - 40, base.NPC.width, base.NPC.height, type2, 1, false, 0, false, false);
            Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y - 95, 0, 0, Mod.Find<ModProjectile>("EvilBotleKill").Type, 200, 0f, Main.myPlayer, 0f, 0f);
            if (!MythWorld.downedBottle)
            {
                MythWorld.downedBottle = true;
            }
        }
    }
}
