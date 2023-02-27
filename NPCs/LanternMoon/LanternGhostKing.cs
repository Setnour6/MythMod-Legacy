using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameInput;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;

namespace MythMod.NPCs.LanternMoon
{
    [AutoloadBossHead]
    public class LanternGhostKing : ModNPC
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("灯笼鬼王");
			Main.npcFrameCount[base.NPC.type] = 3;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "灯笼鬼王");
		}
        public override void SetDefaults()
		{
			base.NPC.damage = 100;
            if(Main.expertMode)
            {
                base.NPC.lifeMax = 20000;
                if(MythWorld.Myth)
                {
                    base.NPC.lifeMax = 20000;
                }
            }
            else
            {
                base.NPC.lifeMax = 30000;
            }
			base.NPC.npcSlots = 14f;
			base.NPC.width = 250;
			base.NPC.height = 150;
			base.NPC.defense = 50;
			base.NPC.value = 4000;
			base.NPC.aiStyle = -1;
            base.NPC.boss = false;
            this.AIType = -1;
			base.NPC.knockBackResist = 0f;
            base.NPC.dontTakeDamage = false;
            base.NPC.noGravity = true;
			base.NPC.noTileCollide = true;
			base.NPC.HitSound = SoundID.NPCHit3;
            this.Music = Mod.GetSoundSlot((Terraria.ModLoader.SoundType)51, "Sounds/Music/Foxtail-Grass Studio - メグリネ");
        }
        private int A2 = -2;
        private int U = 0;
        public static bool Canai = false;
        private bool NearDie = false;
        public override void FindFrame(int frameHeight)
        {
            base.NPC.frameCounter += 0.1f;
            base.NPC.frameCounter %= (double)Main.npcFrameCount[base.NPC.type];
            int num = (int)base.NPC.frameCounter;
            base.NPC.frame.Y = num * frameHeight;
        }
        private Vector2 VLan = new Vector2(0, 0);
        public override void AI()
        {
            Player player = Main.player[Main.myPlayer];
            if(Main.dayTime)
            {
                canDespawn = true;
            }
            else
            {
                canDespawn = false;
            }
            if (A2 == -2)
            {
                Cirposi = NPC.Center;
                Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, 0, 0, Mod.Find<ModProjectile>("LanternFlameMagic1").Type, 75, 0f, Main.myPlayer, 0f, 0f);
            }
            /*string key = A2.ToString();
            Color messageColor = Color.Purple;
            Main.NewText(Language.GetTextValue(key), messageColor);*/
            if(Canai)
            {
                A2 += 1;
            }
            else
            {
                A2 = -1;
            }
            Lighting.AddLight(NPC.Center, (float)(255 - NPC.alpha) * 0.75f / 255f * NPC.scale, (float)(255 - NPC.alpha) * 0.24f * NPC.scale / 255f, (float)(255 - NPC.alpha) * 0f / 255f * NPC.scale);
            if(NPC.CountNPCS(Mod.Find<ModNPC>("FloatLantern").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("LanternSprite").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("RedPackBomber").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("PaperCuttingBat").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("HappinessZombie").Type) > 0)
            {
                NPC.dontTakeDamage = true;
            }
            else
            {
                if(!NearDie)
                {
                    NPC.dontTakeDamage = false;
                }
            }
            if (NPC.CountNPCS(Mod.Find<ModNPC>("FloatLantern").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("LanternSprite").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("RedPackBomber").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("PaperCuttingBat").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("HappinessZombie").Type) <= 0 && !Canai)
            {
                Canai = true;
                NPC.boss = true;
                this.Music = Mod.GetSoundSlot((Terraria.ModLoader.SoundType)51, "Sounds/Music/AcuticNotes-Develo鬼王");
            }
            if (player.dead)
            {
                if (NPC.life < NPC.lifeMax)
                {
                    NPC.life += 10;
                }
                else
                {
                    NPC.life = NPC.lifeMax;
                }
            }
            if (A2 <= 0)
            {
                NPC.rotation = NPC.velocity.X / 120f;
                Vector2 v = player.Center + new Vector2((float)Math.Sin(A2 / 40f) * 500f, (float)Math.Sin((A2 + 200) / 40f) * 50f - 350) - NPC.Center;
                if (NPC.velocity.Length() < 9f)
                {
                    NPC.velocity += v / v.Length() * 0.35f;
                }
                NPC.velocity *= 0.96f;
                Cirpo = NPC.Center;
                CirRpur = 1200;
            }
            if (A2 < 700 && A2 > 0)
            {
                NPC.rotation = NPC.velocity.X / 120f;
                Vector2 v = player.Center + new Vector2((float)Math.Sin(A2 / 40f) * 500f, (float)Math.Sin((A2 + 200) / 40f) * 50f - 350) - NPC.Center;
                if (NPC.velocity.Length() < 9f)
                {
                    NPC.velocity += v / v.Length() * 0.35f;
                }
                NPC.velocity *= 0.96f;
                if (A2 % 30 == 1)
                {
                    Vector2 v2 = new Vector2(0, Main.rand.Next(0, 2500) / 10000f).RotatedByRandom(Math.PI * 2f);
                    Vector2 v4 = new Vector2(0, Main.rand.Next(0, 7000) / 1000f).RotatedByRandom(Math.PI * 2f);
                    if(A2 % 60 == 1)
                    {
                        Projectile.NewProjectile(NPC.Center.X + v4.X, NPC.Center.Y + 110f + v4.Y, NPC.velocity.X / 3f + v2.X, NPC.velocity.Y * 0.25f + v2.Y, Mod.Find<ModProjectile>("GoldLanternLine").Type, 75, 0f, Main.myPlayer, 0f, 0f);
                    }
                    for(int h = 0;h < 15;h++)
                    {
                        Vector2 vn = new Vector2(0, -20).RotatedBy(Main.rand.NextFloat(-2f, 2f) + NPC.rotation);
                        Projectile.NewProjectile(NPC.Center.X + vn.X * 5, NPC.Center.Y + vn.Y * 5, NPC.velocity.X + vn.X, NPC.velocity.Y + vn.Y, Mod.Find<ModProjectile>("GoldLanternLine4").Type, 25, 0f, Main.myPlayer, 0, 0);
                    }
                }
                Cirpo = NPC.Center;
                CirRpur = 1200;
            }
            if (A2 >= 700 && A2 < 1500)
            {
                if(A2 % 250 == 0)
                {
                    VLan = new Vector2(0, -300).RotatedBy(Main.rand.NextFloat(-0.25f, 0.25f) * Math.PI);
                }
                if(A2 % 250 < 20)
                {
                    NPC.velocity *= 0.95f;
                    NPC.rotation *= 0.95f;
                }
                if (A2 % 250 < 30 && A2 % 250 < 20)
                {
                    NPC.velocity *= 0;
                    NPC.rotation *= 0.95f;
                }
                if(A2 % 250 == 30)
                {
                    for(int i = 0;i < 12;i++)
                    {
                        Vector2 v1 = new Vector2(0, 100).RotatedBy(i / 6d * Math.PI);
                        Vector2 v2 = v1 + NPC.Center;
                        Projectile.NewProjectile(v2.X, v2.Y, 0, 0, Mod.Find<ModProjectile>("DarkLantern").Type, 50, 0f, Main.myPlayer, 120 - A2 % 250, (float)(i / 6d * Math.PI));
                    }
                }
                if (A2 % 250 == 60)
                {
                    for (int i = 0; i < 24; i++)
                    {
                        Vector2 v1 = new Vector2(0, 150).RotatedBy(i / 12d * Math.PI);
                        Vector2 v2 = v1 + NPC.Center;
                        Projectile.NewProjectile(v2.X, v2.Y, 0, 0, Mod.Find<ModProjectile>("DarkLantern").Type, 50, 0f, Main.myPlayer, 120 - A2 % 250, (float)(i / 12d * Math.PI));
                    }
                }
                if (A2 % 250 == 90)
                {
                    for (int i = 0; i < 36; i++)
                    {
                        Vector2 v1 = new Vector2(0, 200).RotatedBy(i / 18d * Math.PI);
                        Vector2 v2 = v1 + NPC.Center;
                        Projectile.NewProjectile(v2.X, v2.Y, 0, 0, Mod.Find<ModProjectile>("DarkLantern").Type, 50, 0f, Main.myPlayer, 120 - A2 % 250, (float)(i / 18d * Math.PI));
                    }
                }
                if(A2 % 250 == 120)
                {
                    SoundEngine.PlaySound(SoundID.Item36, NPC.position);
                    for (int i = 0; i < 8; i++)
                    {
                        Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("FireBallWave").Type, 0, 0, Main.myPlayer, 0f, 0f);
                    }
                }
                if (A2 % 250 > 120)
                {
                    Vector2 v = player.Center + VLan + player.velocity * 30f;
                    NPC.velocity += (v - NPC.Center) / (v - NPC.Center).Length() * 0.25f;
                    if(NPC.velocity.Length() > 20f)
                    {
                        NPC.velocity *= 0.96f;
                    }
                }
                Cirpo = NPC.Center;
                CirRpur = 1200;
            }
            if (A2 >= 1500 && A2 < 1700)
            {
                NPC.rotation *= 0.95f;
                NPC.velocity *= 0.95f;
                if(A2 == 1600)
                {
                    for (int j = 0; j < 150; j++)
                    {
                        Vector2 v2 = new Vector2(0, Main.rand.Next(Main.rand.Next(0, 1200), 1200)).RotatedByRandom(Math.PI * 2);
                        Projectile.NewProjectile(v2.X + NPC.Center.X, v2.Y + NPC.Center.Y, 0, 0, Mod.Find<ModProjectile>("DarkLanternBomb").Type, 50, 0f, Main.myPlayer, v2.Length() / 4f, 0);
                    }
                }
            }
            if (A2 >= 1700 && A2 < 2000)
            {
                NPC.rotation *= 0.95f;
                NPC.velocity *= 0.95f;
                if(A2 == 1700)
                {
                    for (int t = 0; t < 1000; t++)
                    {
                        if (Main.projectile[t].type == Mod.Find<ModProjectile>("DarkLantern").Type && Main.projectile[t].active && Main.projectile[t].timeLeft > 180)
                        {
                            Main.projectile[t].timeLeft = 180;
                        }
                    }
                }
                if(A2 % 9 == 0)
                {
                    float dx = (A2 - 1700) / 300f;
                    for (int j = 0; j < 6; j++)
                    {
                        Vector2 v2 = new Vector2(0, 1 + dx).RotatedBy(Math.PI * j / 3d + dx * dx * 4);
                        Projectile.NewProjectile(v2.X + NPC.Center.X, v2.Y + NPC.Center.Y, v2.X, v2.Y, Mod.Find<ModProjectile>("floatLantern2").Type, 50, 0f, Main.myPlayer, 0, 0);
                    }
                    for (int j = 0; j < 3; j++)
                    {
                        Vector2 v2 = new Vector2(0, 1 + dx).RotatedBy(Math.PI * j / 1.5 + dx * dx * 4);
                        Projectile.NewProjectile(v2.X + NPC.Center.X, v2.Y + NPC.Center.Y, v2.X, v2.Y, Mod.Find<ModProjectile>("floatLantern3").Type, 50, 0f, Main.myPlayer, 0, 0);
                    }
                    for (int j = 0; j < 3; j++)
                    {
                        Vector2 v2 = new Vector2(0, 1 + dx).RotatedBy(Math.PI * (j + 1.5) / 1.5 + dx * dx * 4);
                        Projectile.NewProjectile(v2.X + NPC.Center.X, v2.Y + NPC.Center.Y, v2.X, v2.Y, Mod.Find<ModProjectile>("floatLantern4").Type, 50, 0f, Main.myPlayer, 0, 0);
                    }
                }
            }
            if (A2 >= 2000 && A2 < 2500)
            {
                NPC.rotation *= 0.95f;
                Vector2 v = player.Center + new Vector2(0, -350) - NPC.Center;
                if (NPC.velocity.Length() < 9f)
                {
                    NPC.velocity += v / v.Length() * 0.35f;
                    NPC.velocity.X += player.velocity.X * 0.07f;
                }
                NPC.velocity *= 0.96f;
                if(A2 % 60 == 0)
                {
                    NPC.NewNPC((int)NPC.Center.X, (int)NPC.Center.Y + 100, Mod.Find<ModNPC>("FloatLantern").Type, 0, 0, 0, 0, 0, 255);
                }
                Cirpo = NPC.Center;
                CirRpur = 1200;
            }
            if (A2 >= 2500 && A2 < 3000)
            {
                NPC.rotation *= 0.95f;
                Vector2 vz = player.Center + new Vector2(0, -350) - NPC.Center;
                if (NPC.velocity.Length() < 9f)
                {
                    NPC.velocity += vz / vz.Length() * 0.35f;
                    NPC.velocity.X += player.velocity.X * 0.07f;
                }
                NPC.velocity *= 0.96f;
                if (A2 % 6 == 0)
                {
                    Vector2 v = new Vector2(0, -1.8f).RotatedBy(Main.rand.NextFloat(-1f, 1f));
                    Projectile.NewProjectile(player.Center.X + Main.rand.Next(-600,600), player.Center.Y - 500, v.X + NPC.velocity.X, v.Y + NPC.velocity.Y, Mod.Find<ModProjectile>("floatLantern").Type, 50, 0f, Main.myPlayer, 0,0);
                }
                if (A2 % 120 == 0)
                {
                    for(int i = 0;i < 5;i++)
                    {
                        Vector2 v0 = new Vector2(0, -Main.rand.Next(120, 570)).RotatedBy(Main.rand.NextFloat(-1.4f, 1.4f));
                        Vector2 v = v0 / 1000000f;
                        Projectile.NewProjectile(player.Center.X + v0.X, player.Center.Y + v0.Y, -v.X, -v.Y, Mod.Find<ModProjectile>("ExplodeLantern").Type, 50, 0f, Main.myPlayer, 0, 0);
                    }
                }
                Cirpo = NPC.Center;
                CirRpur = 1200;
            }
            if (A2 >= 13000 && A2 < 13700)
            {
                NPC.rotation *= 0.95f;
                NPC.velocity *= 0.95f;
                if (A2 % 9 == 0)
                {
                    float dx = (A2 - 1700) / 300f;
                    for (int j = 0; j < 6; j++)
                    {
                        Vector2 v2 = new Vector2(0, 1);
                        Projectile.NewProjectile(Cirpo.X + (j - 2.5f) * 360 + (float)(Math.Sin(A2 / 50f + j) * 150f), Cirpo.Y - 1400, v2.X, v2.Y, Mod.Find<ModProjectile>("floatLantern2").Type, 16, 0f, Main.myPlayer, 0, 0);
                        //Projectile.NewProjectile(Cirpo.X + (j - 2.5f) * 200 + (Adding % 100 - 50), Cirpo.Y - 1000, v2.X, v2.Y * 2.5f, mod.ProjectileType("GoldLanternLine6"), 50, 0f, Main.myPlayer, 0, 0);
                    }
                }
                if (A2 == 13000)
                {
                    for (int j = 0; j < 30; j++)
                    {
                        Projectile.NewProjectile(Cirposi.X, Cirposi.Y, 0, 0, Mod.Find<ModProjectile>("DarkLantern3").Type, 16, 0f, Main.myPlayer, j, 360);
                    }
                    for (int j = 0; j < 30; j++)
                    {
                        Projectile.NewProjectile(Cirposi.X, Cirposi.Y, 0, 0, Mod.Find<ModProjectile>("DarkLantern3").Type, 16, 0f, Main.myPlayer, j + 1, 720);
                    }
                    for (int j = 0; j < 30; j++)
                    {
                        Projectile.NewProjectile(Cirposi.X, Cirposi.Y, 0, 0, Mod.Find<ModProjectile>("DarkLantern3").Type, 16, 0f, Main.myPlayer, j + 2, 1080);
                    }
                }
                if (A2 % 300 == 0)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Vector2 v = new Vector2(0, 120).RotatedBy(j / 5d * Math.PI);
                        Vector2 v2 = v.RotatedBy(Math.PI * 1.5) / v.Length();
                        Projectile.NewProjectile(Cirposi.X + v.X, Cirposi.Y + v.Y, v2.X, v2.Y, Mod.Find<ModProjectile>("floatLantern2").Type, 16, 0f, Main.myPlayer, 0, 0);
                    }
                    for (int j = 0; j < 10; j++)
                    {
                        Vector2 v = new Vector2(0, 300).RotatedBy(j / 5d * Math.PI);
                        Vector2 v2 = v.RotatedBy(Math.PI * 1.5) / v.Length();
                        Projectile.NewProjectile(Cirposi.X + v.X, Cirposi.Y + v.Y, v2.X, v2.Y, Mod.Find<ModProjectile>("floatLantern2").Type, 16, 0f, Main.myPlayer, 0, 0);
                    }
                }
                Cirpo = NPC.Center + new Vector2(0, -500);
                CirRpur = 600;
                Adc = (float)(Math.Sin((A2 - 13000f) / 600d * Math.PI) / 400f);
            }
            if (A2 >= 13700 && A2 < 14400)
            {
                NPC.rotation *= 0.95f;
                NPC.velocity *= 0.95f;
                if (A2 % 200 == 0)
                {
                    for(int l = 0;l < 3;l++)
                    {
                        Projectile.NewProjectile(NPC.Center.X + Main.rand.Next(-1200, 1200), NPC.Center.Y, 0, 0, Mod.Find<ModProjectile>("Redlight").Type, 0, 0f, Main.myPlayer, 0, 0);
                    }
                }
                if(A2 == 13700)
                {
                    Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, 48, 0, Mod.Find<ModProjectile>("GoldLanternLine8").Type, 0, 0f, Main.myPlayer, 0, 0);
                }
                Cirpo = NPC.Center + new Vector2(0, -300);
                CirRpur = 1000;
            }
            if ((player.Center - Cirposi).Length() > CirR && A2 > 300)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, Mod.Find<ModProjectile>("Hit").Type, 100, 0f, Main.myPlayer, 0f, 0f);
            }
            if(A2 == 13700)
            {
                for (int t = 0; t < 1000; t++)
                {
                    if (Main.projectile[t].type == Mod.Find<ModProjectile>("DarkLantern3").Type && Main.projectile[t].active && Main.projectile[t].timeLeft > 60)
                    {
                        Main.projectile[t].timeLeft = 60;
                    }
                }
                for (int t = 0; t < 1000; t++)
                {
                    if (Main.projectile[t].type == Mod.Find<ModProjectile>("floatLantern2").Type && Main.projectile[t].active && Main.projectile[t].timeLeft > 60)
                    {
                        Main.projectile[t].timeLeft = 60;
                    }
                }
            }
            if (A2 == 2998)
            {
                A2 = 1;
            }
            if (A2 == 2999)
            {
                A2 = 1;
            }
            if (A2 >= 14680)
            {
                NPC.StrikeNPC(10005,0,1);
            }
            if (Main.dayTime)
            {
                NPC.velocity.Y += 1;
            }
            if(A2 % 15 == 0)
            {
                U += 1;
            }
            CirR = CirR * 0.99f + CirRpur * 0.01f;
            Cirposi = Cirposi * 0.99f + Cirpo * 0.01f;
        }
        public static float Adc = 0;
        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
        }
        public override bool CheckActive()
        {
            return this.canDespawn;
        }
        private bool canDespawn;
        public override void HitEffect(int hitDirection, double damage)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if(20000 - (int)(NPC.life / (float)NPC.lifeMax * 10000f) < 20000)
            {
                mplayer.LanternMoonPoint = 20000 - (int)(NPC.life / (float)NPC.lifeMax * 10000f);
            }
            if (base.NPC.life <= 0)
            {
                if(!NearDie)
                {
                    NearDie = true;
                    NPC.life = 10000;
                    NPC.active = true;
                    NPC.dontTakeDamage = true;
                    A2 = 12999;
                    return;
                }
                else
                {
                    for (int Maximun = 0; Maximun < 90; Maximun++)
                    {
                        Vector2 vc = Cirposi + new Vector2(0f, NPC.gfxOffY) + new Vector2(0, CirR).RotatedBy(Maximun / 45d * Math.PI + Adding);
                        for (int i = 0; i < 2; i++)
                        {
                            int num = Dust.NewDust(new Vector2(vc.X, vc.Y), NPC.width, NPC.height, 244, 0f, 0f, 100, default(Color), 2f);
                            Main.dust[num].velocity *= 3f;
                            if (Main.rand.Next(2) == 0)
                            {
                                Main.dust[num].scale = 0.5f;
                                Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                            }
                        }
                        for (int j = 0; j < 6; j++)
                        {
                            int num2 = Dust.NewDust(new Vector2(vc.X, vc.Y), NPC.width, NPC.height, 244, 0f, 0f, 100, default(Color), 3f);
                            Main.dust[num2].noGravity = true;
                            Main.dust[num2].velocity *= 5f;
                            num2 = Dust.NewDust(new Vector2(vc.X, vc.Y), NPC.width, NPC.height, 244, 0f, 0f, 100, default(Color), 2f);
                            Main.dust[num2].velocity *= 2f;
                        }
                        for (int k = 0; k < 3; k++)
                        {
                            float scaleFactorx = 0.33f;
                            if (k == 1)
                            {
                                scaleFactorx = 0.66f;
                            }
                            if (k == 2)
                            {
                                scaleFactorx = 1f;
                            }
                        }
                    }
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 25f)).RotatedByRandom(Math.PI * 2d);
                    Gore.NewGore(base.NPC.Center, base.NPC.velocity + v, base.Mod.GetGoreSlot("Gores/灯笼鬼王碎块1"), 1f);
                    v = new Vector2(0, Main.rand.NextFloat(0, 25f)).RotatedByRandom(Math.PI * 2d);
                    Gore.NewGore(base.NPC.Center, base.NPC.velocity + v, base.Mod.GetGoreSlot("Gores/灯笼鬼王碎块1"), 1f);
                    v = new Vector2(0, Main.rand.NextFloat(0, 25f)).RotatedByRandom(Math.PI * 2d);
                    Gore.NewGore(base.NPC.Center, base.NPC.velocity + v, base.Mod.GetGoreSlot("Gores/灯笼鬼王碎块2"), 1f);
                    v = new Vector2(0, Main.rand.NextFloat(0, 25f)).RotatedByRandom(Math.PI * 2d);
                    Gore.NewGore(base.NPC.Center, base.NPC.velocity + v, base.Mod.GetGoreSlot("Gores/灯笼鬼王碎块3"), 1f);
                    for (int i = 0; i < 30; i++)
                    {
                        v = new Vector2(0, Main.rand.NextFloat(0, 25f)).RotatedByRandom(Math.PI * 2d);
                        Gore.NewGore(base.NPC.Center, base.NPC.velocity + v, base.Mod.GetGoreSlot("Gores/灯笼鬼王碎块4"), 1f);
                    }

                    if (mplayer.LanternMoonWave == 15)
                    {
                        mplayer.LanternMoonPoint = 20010;
                    }
                    for (int k = 0; k <= 30; k++)
                    {
                        Vector2 v0 = new Vector2(0, Main.rand.Next(0, 140)).RotatedByRandom(Math.PI * 2);
                        int num4 = Projectile.NewProjectile(NPC.Center.X + v0.X, NPC.Center.Y + v0.Y, 0, 0, base.Mod.Find<ModProjectile>("MeltingpotBlaze").Type, 0, 0, Main.myPlayer, Main.rand.Next(1000, 3000) / 1000f, 0f);
                    }
                    for (int k = 0; k <= 10; k++)
                    {
                        Vector2 v0 = new Vector2(0, Main.rand.Next(0, 140)).RotatedByRandom(Math.PI * 2);
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 50000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 1800;
                        int num4 = Projectile.NewProjectile(NPC.Center.X + v0.X, NPC.Center.Y + v0.Y, (float)((float)l * Math.Cos((float)a)) * 0.36f, (float)((float)l * Math.Sin((float)a)) * 0.36f, base.Mod.Find<ModProjectile>("火山溅射").Type, 0, 0, Main.myPlayer, 0f, 0f);
                        Main.projectile[num4].scale = (float)Main.rand.Next(7000, 13000) / 10000f;
                    }
                }               
            }
        }
        private Vector2 Cirpo;
        public static Vector2 Cirposi;
        public static float CirR = 0;
        private float CirRpur = 1200;
        private float Adding = 0;
        private int Fy = 0;
        private int fyc = 0;
        private float Cl = 0;
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Adding += 0.004f;
            if(Adding <= 1)
            {
                Cl = Adding;
            }
            else
            {
                Cl = 1;
            }
            fyc += 1;
            if (fyc == 8)
            {
                fyc = 0;
                Fy += 1;
            }
            if (Fy > 3)
            {
                Fy = 0;
            }
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = TextureAssets.Npc[base.NPC.type].Value;
            /*for(int Maximun = 0;Maximun < 90;Maximun++)
            {
                Main.spriteBatch.Draw(mod.GetTexture("Projectiles/projectile5/LanternFire"), Cirposi - Main.screenPosition + new Vector2(0f, npc.gfxOffY) + new Vector2(0, CirR).RotatedBy(Maximun / 45d * Math.PI + Adding), new Rectangle?(new Rectangle(0, 30 * ((Fy + Maximun) % 4), 20, 30)), new Color(Cl * 0.8f, Cl * 0.8f, Cl * 0.8f,0), 0, new Vector2(10, 15), 1f, SpriteEffects.None, 1f);
            }*/
            Main.spriteBatch.Draw(texture, NPC.Center - Main.screenPosition + new Vector2(0f, NPC.gfxOffY), NPC.frame, NPC.GetAlpha(drawColor), NPC.rotation, new Vector2(250, 110), NPC.scale, SpriteEffects.None, 0f);
            return false;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (base.NPC.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Vector2 value = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
            Vector2 vector = new Vector2((float)(TextureAssets.Npc[base.NPC.type].Value.Width / 2), (float)(TextureAssets.Npc[base.NPC.type].Value.Height / Main.npcFrameCount[base.NPC.type] / 2));
            Vector2 vector2 = value - Main.screenPosition;
            vector2 -= new Vector2((float)base.Mod.GetTexture("NPCs/LanternMoon/灯笼鬼王Glow2").Width, (float)(base.Mod.GetTexture("NPCs/LanternMoon/灯笼鬼王Glow2").Height / Main.npcFrameCount[base.NPC.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.NPC.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(97 - base.NPC.alpha, 97 - base.NPC.alpha, 97 - base.NPC.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/LanternMoon/灯笼鬼王Glow2"), vector2 + new Vector2(0, 60), new Rectangle(0, U % 4 * 220, 500, 220), new Color(100, 100, 100, 0), base.NPC.rotation, vector, 1f, effects, 0f);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/LanternMoon/灯笼鬼王Glow3"), vector2 + new Vector2(0, 40), new Rectangle(0, U % 3 * 280, 500, 220), new Color(255, 255, 255, 255), base.NPC.rotation, vector, 1f, effects, 0f);
        }
        public override void OnKill()
        {
            if (!MythWorld.downedDLGW)
            {
                MythWorld.downedDLGW = true;
            }
            Player player = Main.player[Main.myPlayer];
            bool expertMode = Main.expertMode;
            if(!expertMode)
            {
                int type = 0;
                switch (Main.rand.Next(1, 7))
                {
                    case 1:
                        type = base.Mod.Find<ModItem>("LanternYoyo").Type;
                        break;
                    case 2:
                        type = base.Mod.Find<ModItem>("RedLanternGun").Type;
                        break;
                    case 3:
                        type = base.Mod.Find<ModItem>("IlluminatedNight").Type;
                        break;
                    case 4:
                        type = base.Mod.Find<ModItem>("LanternHairpin").Type;
                        break;
                    case 5:
                        type = base.Mod.Find<ModItem>("LampFire").Type;
                        break;
                    case 6:
                        type = base.Mod.Find<ModItem>("Wick").Type;
                        break;
                }
                Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, type, 1, false, 0, false, false);
            }
            else
            {
                Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("LanternKingTreasureBag").Type, 1, false, 0, false, false);
            }
            Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, 58, 25, false, 0, false, false);
            Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("Rice").Type, 10, false, 0, false, false);
        }
        public int dustTimer = 60;
	}
}
