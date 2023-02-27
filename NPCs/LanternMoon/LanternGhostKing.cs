using System;
using Microsoft.Xna.Framework;
using Terraria;
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
			Main.npcFrameCount[base.npc.type] = 3;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "灯笼鬼王");
		}
        public override void SetDefaults()
		{
			base.npc.damage = 100;
            if(Main.expertMode)
            {
                base.npc.lifeMax = 20000;
                if(MythWorld.Myth)
                {
                    base.npc.lifeMax = 20000;
                }
            }
            else
            {
                base.npc.lifeMax = 30000;
            }
			base.npc.npcSlots = 14f;
			base.npc.width = 250;
			base.npc.height = 150;
			base.npc.defense = 50;
			base.npc.value = 4000;
			base.npc.aiStyle = -1;
            base.npc.boss = false;
            this.aiType = -1;
			base.npc.knockBackResist = 0f;
            base.npc.dontTakeDamage = false;
            base.npc.noGravity = true;
			base.npc.noTileCollide = true;
			base.npc.HitSound = SoundID.NPCHit3;
            this.music = mod.GetSoundSlot((Terraria.ModLoader.SoundType)51, "Sounds/Music/Foxtail-Grass Studio - メグリネ");
        }
        private int A2 = -2;
        private int U = 0;
        public static bool Canai = false;
        private bool NearDie = false;
        public override void FindFrame(int frameHeight)
        {
            base.npc.frameCounter += 0.1f;
            base.npc.frameCounter %= (double)Main.npcFrameCount[base.npc.type];
            int num = (int)base.npc.frameCounter;
            base.npc.frame.Y = num * frameHeight;
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
                Cirposi = npc.Center;
                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("LanternFlameMagic1"), 75, 0f, Main.myPlayer, 0f, 0f);
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
            Lighting.AddLight(npc.Center, (float)(255 - npc.alpha) * 0.75f / 255f * npc.scale, (float)(255 - npc.alpha) * 0.24f * npc.scale / 255f, (float)(255 - npc.alpha) * 0f / 255f * npc.scale);
            if(NPC.CountNPCS(mod.NPCType("FloatLantern")) + NPC.CountNPCS(mod.NPCType("LanternSprite")) + NPC.CountNPCS(mod.NPCType("RedPackBomber")) + NPC.CountNPCS(mod.NPCType("PaperCuttingBat")) + NPC.CountNPCS(mod.NPCType("HappinessZombie")) > 0)
            {
                npc.dontTakeDamage = true;
            }
            else
            {
                if(!NearDie)
                {
                    npc.dontTakeDamage = false;
                }
            }
            if (NPC.CountNPCS(mod.NPCType("FloatLantern")) + NPC.CountNPCS(mod.NPCType("LanternSprite")) + NPC.CountNPCS(mod.NPCType("RedPackBomber")) + NPC.CountNPCS(mod.NPCType("PaperCuttingBat")) + NPC.CountNPCS(mod.NPCType("HappinessZombie")) <= 0 && !Canai)
            {
                Canai = true;
                npc.boss = true;
                this.music = mod.GetSoundSlot((Terraria.ModLoader.SoundType)51, "Sounds/Music/AcuticNotes-Develo鬼王");
            }
            if (player.dead)
            {
                if (npc.life < npc.lifeMax)
                {
                    npc.life += 10;
                }
                else
                {
                    npc.life = npc.lifeMax;
                }
            }
            if (A2 <= 0)
            {
                npc.rotation = npc.velocity.X / 120f;
                Vector2 v = player.Center + new Vector2((float)Math.Sin(A2 / 40f) * 500f, (float)Math.Sin((A2 + 200) / 40f) * 50f - 350) - npc.Center;
                if (npc.velocity.Length() < 9f)
                {
                    npc.velocity += v / v.Length() * 0.35f;
                }
                npc.velocity *= 0.96f;
                Cirpo = npc.Center;
                CirRpur = 1200;
            }
            if (A2 < 700 && A2 > 0)
            {
                npc.rotation = npc.velocity.X / 120f;
                Vector2 v = player.Center + new Vector2((float)Math.Sin(A2 / 40f) * 500f, (float)Math.Sin((A2 + 200) / 40f) * 50f - 350) - npc.Center;
                if (npc.velocity.Length() < 9f)
                {
                    npc.velocity += v / v.Length() * 0.35f;
                }
                npc.velocity *= 0.96f;
                if (A2 % 30 == 1)
                {
                    Vector2 v2 = new Vector2(0, Main.rand.Next(0, 2500) / 10000f).RotatedByRandom(Math.PI * 2f);
                    Vector2 v4 = new Vector2(0, Main.rand.Next(0, 7000) / 1000f).RotatedByRandom(Math.PI * 2f);
                    if(A2 % 60 == 1)
                    {
                        Projectile.NewProjectile(npc.Center.X + v4.X, npc.Center.Y + 110f + v4.Y, npc.velocity.X / 3f + v2.X, npc.velocity.Y * 0.25f + v2.Y, mod.ProjectileType("GoldLanternLine"), 75, 0f, Main.myPlayer, 0f, 0f);
                    }
                    for(int h = 0;h < 15;h++)
                    {
                        Vector2 vn = new Vector2(0, -20).RotatedBy(Main.rand.NextFloat(-2f, 2f) + npc.rotation);
                        Projectile.NewProjectile(npc.Center.X + vn.X * 5, npc.Center.Y + vn.Y * 5, npc.velocity.X + vn.X, npc.velocity.Y + vn.Y, mod.ProjectileType("GoldLanternLine4"), 25, 0f, Main.myPlayer, 0, 0);
                    }
                }
                Cirpo = npc.Center;
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
                    npc.velocity *= 0.95f;
                    npc.rotation *= 0.95f;
                }
                if (A2 % 250 < 30 && A2 % 250 < 20)
                {
                    npc.velocity *= 0;
                    npc.rotation *= 0.95f;
                }
                if(A2 % 250 == 30)
                {
                    for(int i = 0;i < 12;i++)
                    {
                        Vector2 v1 = new Vector2(0, 100).RotatedBy(i / 6d * Math.PI);
                        Vector2 v2 = v1 + npc.Center;
                        Projectile.NewProjectile(v2.X, v2.Y, 0, 0, mod.ProjectileType("DarkLantern"), 50, 0f, Main.myPlayer, 120 - A2 % 250, (float)(i / 6d * Math.PI));
                    }
                }
                if (A2 % 250 == 60)
                {
                    for (int i = 0; i < 24; i++)
                    {
                        Vector2 v1 = new Vector2(0, 150).RotatedBy(i / 12d * Math.PI);
                        Vector2 v2 = v1 + npc.Center;
                        Projectile.NewProjectile(v2.X, v2.Y, 0, 0, mod.ProjectileType("DarkLantern"), 50, 0f, Main.myPlayer, 120 - A2 % 250, (float)(i / 12d * Math.PI));
                    }
                }
                if (A2 % 250 == 90)
                {
                    for (int i = 0; i < 36; i++)
                    {
                        Vector2 v1 = new Vector2(0, 200).RotatedBy(i / 18d * Math.PI);
                        Vector2 v2 = v1 + npc.Center;
                        Projectile.NewProjectile(v2.X, v2.Y, 0, 0, mod.ProjectileType("DarkLantern"), 50, 0f, Main.myPlayer, 120 - A2 % 250, (float)(i / 18d * Math.PI));
                    }
                }
                if(A2 % 250 == 120)
                {
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 36, 1f, 0f);
                    for (int i = 0; i < 8; i++)
                    {
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, base.mod.ProjectileType("FireBallWave"), 0, 0, Main.myPlayer, 0f, 0f);
                    }
                }
                if (A2 % 250 > 120)
                {
                    Vector2 v = player.Center + VLan + player.velocity * 30f;
                    npc.velocity += (v - npc.Center) / (v - npc.Center).Length() * 0.25f;
                    if(npc.velocity.Length() > 20f)
                    {
                        npc.velocity *= 0.96f;
                    }
                }
                Cirpo = npc.Center;
                CirRpur = 1200;
            }
            if (A2 >= 1500 && A2 < 1700)
            {
                npc.rotation *= 0.95f;
                npc.velocity *= 0.95f;
                if(A2 == 1600)
                {
                    for (int j = 0; j < 150; j++)
                    {
                        Vector2 v2 = new Vector2(0, Main.rand.Next(Main.rand.Next(0, 1200), 1200)).RotatedByRandom(Math.PI * 2);
                        Projectile.NewProjectile(v2.X + npc.Center.X, v2.Y + npc.Center.Y, 0, 0, mod.ProjectileType("DarkLanternBomb"), 50, 0f, Main.myPlayer, v2.Length() / 4f, 0);
                    }
                }
            }
            if (A2 >= 1700 && A2 < 2000)
            {
                npc.rotation *= 0.95f;
                npc.velocity *= 0.95f;
                if(A2 == 1700)
                {
                    for (int t = 0; t < 1000; t++)
                    {
                        if (Main.projectile[t].type == mod.ProjectileType("DarkLantern") && Main.projectile[t].active && Main.projectile[t].timeLeft > 180)
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
                        Projectile.NewProjectile(v2.X + npc.Center.X, v2.Y + npc.Center.Y, v2.X, v2.Y, mod.ProjectileType("floatLantern2"), 50, 0f, Main.myPlayer, 0, 0);
                    }
                    for (int j = 0; j < 3; j++)
                    {
                        Vector2 v2 = new Vector2(0, 1 + dx).RotatedBy(Math.PI * j / 1.5 + dx * dx * 4);
                        Projectile.NewProjectile(v2.X + npc.Center.X, v2.Y + npc.Center.Y, v2.X, v2.Y, mod.ProjectileType("floatLantern3"), 50, 0f, Main.myPlayer, 0, 0);
                    }
                    for (int j = 0; j < 3; j++)
                    {
                        Vector2 v2 = new Vector2(0, 1 + dx).RotatedBy(Math.PI * (j + 1.5) / 1.5 + dx * dx * 4);
                        Projectile.NewProjectile(v2.X + npc.Center.X, v2.Y + npc.Center.Y, v2.X, v2.Y, mod.ProjectileType("floatLantern4"), 50, 0f, Main.myPlayer, 0, 0);
                    }
                }
            }
            if (A2 >= 2000 && A2 < 2500)
            {
                npc.rotation *= 0.95f;
                Vector2 v = player.Center + new Vector2(0, -350) - npc.Center;
                if (npc.velocity.Length() < 9f)
                {
                    npc.velocity += v / v.Length() * 0.35f;
                    npc.velocity.X += player.velocity.X * 0.07f;
                }
                npc.velocity *= 0.96f;
                if(A2 % 60 == 0)
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 100, mod.NPCType("FloatLantern"), 0, 0, 0, 0, 0, 255);
                }
                Cirpo = npc.Center;
                CirRpur = 1200;
            }
            if (A2 >= 2500 && A2 < 3000)
            {
                npc.rotation *= 0.95f;
                Vector2 vz = player.Center + new Vector2(0, -350) - npc.Center;
                if (npc.velocity.Length() < 9f)
                {
                    npc.velocity += vz / vz.Length() * 0.35f;
                    npc.velocity.X += player.velocity.X * 0.07f;
                }
                npc.velocity *= 0.96f;
                if (A2 % 6 == 0)
                {
                    Vector2 v = new Vector2(0, -1.8f).RotatedBy(Main.rand.NextFloat(-1f, 1f));
                    Projectile.NewProjectile(player.Center.X + Main.rand.Next(-600,600), player.Center.Y - 500, v.X + npc.velocity.X, v.Y + npc.velocity.Y, mod.ProjectileType("floatLantern"), 50, 0f, Main.myPlayer, 0,0);
                }
                if (A2 % 120 == 0)
                {
                    for(int i = 0;i < 5;i++)
                    {
                        Vector2 v0 = new Vector2(0, -Main.rand.Next(120, 570)).RotatedBy(Main.rand.NextFloat(-1.4f, 1.4f));
                        Vector2 v = v0 / 1000000f;
                        Projectile.NewProjectile(player.Center.X + v0.X, player.Center.Y + v0.Y, -v.X, -v.Y, mod.ProjectileType("ExplodeLantern"), 50, 0f, Main.myPlayer, 0, 0);
                    }
                }
                Cirpo = npc.Center;
                CirRpur = 1200;
            }
            if (A2 >= 13000 && A2 < 13700)
            {
                npc.rotation *= 0.95f;
                npc.velocity *= 0.95f;
                if (A2 % 9 == 0)
                {
                    float dx = (A2 - 1700) / 300f;
                    for (int j = 0; j < 6; j++)
                    {
                        Vector2 v2 = new Vector2(0, 1);
                        Projectile.NewProjectile(Cirpo.X + (j - 2.5f) * 360 + (float)(Math.Sin(A2 / 50f + j) * 150f), Cirpo.Y - 1400, v2.X, v2.Y, mod.ProjectileType("floatLantern2"), 16, 0f, Main.myPlayer, 0, 0);
                        //Projectile.NewProjectile(Cirpo.X + (j - 2.5f) * 200 + (Adding % 100 - 50), Cirpo.Y - 1000, v2.X, v2.Y * 2.5f, mod.ProjectileType("GoldLanternLine6"), 50, 0f, Main.myPlayer, 0, 0);
                    }
                }
                if (A2 == 13000)
                {
                    for (int j = 0; j < 30; j++)
                    {
                        Projectile.NewProjectile(Cirposi.X, Cirposi.Y, 0, 0, mod.ProjectileType("DarkLantern3"), 16, 0f, Main.myPlayer, j, 360);
                    }
                    for (int j = 0; j < 30; j++)
                    {
                        Projectile.NewProjectile(Cirposi.X, Cirposi.Y, 0, 0, mod.ProjectileType("DarkLantern3"), 16, 0f, Main.myPlayer, j + 1, 720);
                    }
                    for (int j = 0; j < 30; j++)
                    {
                        Projectile.NewProjectile(Cirposi.X, Cirposi.Y, 0, 0, mod.ProjectileType("DarkLantern3"), 16, 0f, Main.myPlayer, j + 2, 1080);
                    }
                }
                if (A2 % 300 == 0)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Vector2 v = new Vector2(0, 120).RotatedBy(j / 5d * Math.PI);
                        Vector2 v2 = v.RotatedBy(Math.PI * 1.5) / v.Length();
                        Projectile.NewProjectile(Cirposi.X + v.X, Cirposi.Y + v.Y, v2.X, v2.Y, mod.ProjectileType("floatLantern2"), 16, 0f, Main.myPlayer, 0, 0);
                    }
                    for (int j = 0; j < 10; j++)
                    {
                        Vector2 v = new Vector2(0, 300).RotatedBy(j / 5d * Math.PI);
                        Vector2 v2 = v.RotatedBy(Math.PI * 1.5) / v.Length();
                        Projectile.NewProjectile(Cirposi.X + v.X, Cirposi.Y + v.Y, v2.X, v2.Y, mod.ProjectileType("floatLantern2"), 16, 0f, Main.myPlayer, 0, 0);
                    }
                }
                Cirpo = npc.Center + new Vector2(0, -500);
                CirRpur = 600;
                Adc = (float)(Math.Sin((A2 - 13000f) / 600d * Math.PI) / 400f);
            }
            if (A2 >= 13700 && A2 < 14400)
            {
                npc.rotation *= 0.95f;
                npc.velocity *= 0.95f;
                if (A2 % 200 == 0)
                {
                    for(int l = 0;l < 3;l++)
                    {
                        Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-1200, 1200), npc.Center.Y, 0, 0, mod.ProjectileType("Redlight"), 0, 0f, Main.myPlayer, 0, 0);
                    }
                }
                if(A2 == 13700)
                {
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 48, 0, mod.ProjectileType("GoldLanternLine8"), 0, 0f, Main.myPlayer, 0, 0);
                }
                Cirpo = npc.Center + new Vector2(0, -300);
                CirRpur = 1000;
            }
            if ((player.Center - Cirposi).Length() > CirR && A2 > 300)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("Hit"), 100, 0f, Main.myPlayer, 0f, 0f);
            }
            if(A2 == 13700)
            {
                for (int t = 0; t < 1000; t++)
                {
                    if (Main.projectile[t].type == mod.ProjectileType("DarkLantern3") && Main.projectile[t].active && Main.projectile[t].timeLeft > 60)
                    {
                        Main.projectile[t].timeLeft = 60;
                    }
                }
                for (int t = 0; t < 1000; t++)
                {
                    if (Main.projectile[t].type == mod.ProjectileType("floatLantern2") && Main.projectile[t].active && Main.projectile[t].timeLeft > 60)
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
                npc.StrikeNPC(10005,0,1);
            }
            if (Main.dayTime)
            {
                npc.velocity.Y += 1;
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
            if(20000 - (int)(npc.life / (float)npc.lifeMax * 10000f) < 20000)
            {
                mplayer.LanternMoonPoint = 20000 - (int)(npc.life / (float)npc.lifeMax * 10000f);
            }
            if (base.npc.life <= 0)
            {
                if(!NearDie)
                {
                    NearDie = true;
                    npc.life = 10000;
                    npc.active = true;
                    npc.dontTakeDamage = true;
                    A2 = 12999;
                    return;
                }
                else
                {
                    for (int Maximun = 0; Maximun < 90; Maximun++)
                    {
                        Vector2 vc = Cirposi + new Vector2(0f, npc.gfxOffY) + new Vector2(0, CirR).RotatedBy(Maximun / 45d * Math.PI + Adding);
                        for (int i = 0; i < 2; i++)
                        {
                            int num = Dust.NewDust(new Vector2(vc.X, vc.Y), npc.width, npc.height, 244, 0f, 0f, 100, default(Color), 2f);
                            Main.dust[num].velocity *= 3f;
                            if (Main.rand.Next(2) == 0)
                            {
                                Main.dust[num].scale = 0.5f;
                                Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                            }
                        }
                        for (int j = 0; j < 6; j++)
                        {
                            int num2 = Dust.NewDust(new Vector2(vc.X, vc.Y), npc.width, npc.height, 244, 0f, 0f, 100, default(Color), 3f);
                            Main.dust[num2].noGravity = true;
                            Main.dust[num2].velocity *= 5f;
                            num2 = Dust.NewDust(new Vector2(vc.X, vc.Y), npc.width, npc.height, 244, 0f, 0f, 100, default(Color), 2f);
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
                    Gore.NewGore(base.npc.Center, base.npc.velocity + v, base.mod.GetGoreSlot("Gores/灯笼鬼王碎块1"), 1f);
                    v = new Vector2(0, Main.rand.NextFloat(0, 25f)).RotatedByRandom(Math.PI * 2d);
                    Gore.NewGore(base.npc.Center, base.npc.velocity + v, base.mod.GetGoreSlot("Gores/灯笼鬼王碎块1"), 1f);
                    v = new Vector2(0, Main.rand.NextFloat(0, 25f)).RotatedByRandom(Math.PI * 2d);
                    Gore.NewGore(base.npc.Center, base.npc.velocity + v, base.mod.GetGoreSlot("Gores/灯笼鬼王碎块2"), 1f);
                    v = new Vector2(0, Main.rand.NextFloat(0, 25f)).RotatedByRandom(Math.PI * 2d);
                    Gore.NewGore(base.npc.Center, base.npc.velocity + v, base.mod.GetGoreSlot("Gores/灯笼鬼王碎块3"), 1f);
                    for (int i = 0; i < 30; i++)
                    {
                        v = new Vector2(0, Main.rand.NextFloat(0, 25f)).RotatedByRandom(Math.PI * 2d);
                        Gore.NewGore(base.npc.Center, base.npc.velocity + v, base.mod.GetGoreSlot("Gores/灯笼鬼王碎块4"), 1f);
                    }

                    if (mplayer.LanternMoonWave == 15)
                    {
                        mplayer.LanternMoonPoint = 20010;
                    }
                    for (int k = 0; k <= 30; k++)
                    {
                        Vector2 v0 = new Vector2(0, Main.rand.Next(0, 140)).RotatedByRandom(Math.PI * 2);
                        int num4 = Projectile.NewProjectile(npc.Center.X + v0.X, npc.Center.Y + v0.Y, 0, 0, base.mod.ProjectileType("MeltingpotBlaze"), 0, 0, Main.myPlayer, Main.rand.Next(1000, 3000) / 1000f, 0f);
                    }
                    for (int k = 0; k <= 10; k++)
                    {
                        Vector2 v0 = new Vector2(0, Main.rand.Next(0, 140)).RotatedByRandom(Math.PI * 2);
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 50000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 1800;
                        int num4 = Projectile.NewProjectile(npc.Center.X + v0.X, npc.Center.Y + v0.Y, (float)((float)l * Math.Cos((float)a)) * 0.36f, (float)((float)l * Math.Sin((float)a)) * 0.36f, base.mod.ProjectileType("火山溅射"), 0, 0, Main.myPlayer, 0f, 0f);
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
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
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
            Texture2D texture = Main.npcTexture[base.npc.type];
            /*for(int Maximun = 0;Maximun < 90;Maximun++)
            {
                Main.spriteBatch.Draw(mod.GetTexture("Projectiles/projectile5/LanternFire"), Cirposi - Main.screenPosition + new Vector2(0f, npc.gfxOffY) + new Vector2(0, CirR).RotatedBy(Maximun / 45d * Math.PI + Adding), new Rectangle?(new Rectangle(0, 30 * ((Fy + Maximun) % 4), 20, 30)), new Color(Cl * 0.8f, Cl * 0.8f, Cl * 0.8f,0), 0, new Vector2(10, 15), 1f, SpriteEffects.None, 1f);
            }*/
            Main.spriteBatch.Draw(texture, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), npc.frame, npc.GetAlpha(drawColor), npc.rotation, new Vector2(250, 110), npc.scale, SpriteEffects.None, 0f);
            return false;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (base.npc.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Vector2 value = new Vector2(base.npc.Center.X, base.npc.Center.Y);
            Vector2 vector = new Vector2((float)(Main.npcTexture[base.npc.type].Width / 2), (float)(Main.npcTexture[base.npc.type].Height / Main.npcFrameCount[base.npc.type] / 2));
            Vector2 vector2 = value - Main.screenPosition;
            vector2 -= new Vector2((float)base.mod.GetTexture("NPCs/LanternMoon/灯笼鬼王Glow2").Width, (float)(base.mod.GetTexture("NPCs/LanternMoon/灯笼鬼王Glow2").Height / Main.npcFrameCount[base.npc.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.npc.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(97 - base.npc.alpha, 97 - base.npc.alpha, 97 - base.npc.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/LanternMoon/灯笼鬼王Glow2"), vector2 + new Vector2(0, 60), new Rectangle(0, U % 4 * 220, 500, 220), new Color(100, 100, 100, 0), base.npc.rotation, vector, 1f, effects, 0f);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/LanternMoon/灯笼鬼王Glow3"), vector2 + new Vector2(0, 40), new Rectangle(0, U % 3 * 280, 500, 220), new Color(255, 255, 255, 255), base.npc.rotation, vector, 1f, effects, 0f);
        }
        public override void NPCLoot()
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
                        type = base.mod.ItemType("LanternYoyo");
                        break;
                    case 2:
                        type = base.mod.ItemType("RedLanternGun");
                        break;
                    case 3:
                        type = base.mod.ItemType("IlluminatedNight");
                        break;
                    case 4:
                        type = base.mod.ItemType("LanternHairpin");
                        break;
                    case 5:
                        type = base.mod.ItemType("LampFire");
                        break;
                    case 6:
                        type = base.mod.ItemType("Wick");
                        break;
                }
                Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, type, 1, false, 0, false, false);
            }
            else
            {
                Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("LanternKingTreasureBag"), 1, false, 0, false, false);
            }
            Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, 58, 25, false, 0, false, false);
            Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("Rice"), 10, false, 0, false, false);
        }
        public int dustTimer = 60;
	}
}
