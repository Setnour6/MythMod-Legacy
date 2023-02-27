using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.NPCs.Yasitaya
{
    /*[AutoloadHead]*/
    [AutoloadBossHead]
    public class Yasitaya : ModNPC
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("Yasitaya");
            Main.npcFrameCount[base.npc.type] = 50;
            NPCID.Sets.ExtraFramesCount[base.npc.type] = 9;
            NPCID.Sets.AttackFrameCount[base.npc.type] = 4;
            NPCID.Sets.DangerDetectRange[base.npc.type] = 400;
            NPCID.Sets.AttackType[base.npc.type] = 0;
            NPCID.Sets.AttackTime[base.npc.type] = 60;
            NPCID.Sets.AttackAverageChance[base.npc.type] = 15;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "雅斯塔亚");
        }
        private bool canDespawn = false;
        public override bool CheckActive()
        {
            return this.canDespawn;
        }
        public override void SetDefaults()
        {
            base.npc.townNPC = true;
            base.npc.friendly = true;
            base.npc.width = 40;
            base.npc.height = 56;
            base.npc.aiStyle = 7;
            base.npc.damage = 100;
            base.npc.defense = 100;
            base.npc.lifeMax = 500;
            base.npc.HitSound = SoundID.NPCHit1;
            base.npc.DeathSound = SoundID.NPCDeath6;
            base.npc.knockBackResist = 0.5f;
            this.animationType = 22;
        }

        public override string TownNPCName()
        {
            return "";
        }
        public bool Fly = false;
        public bool Battle = false;
        public bool Jump = false;
        public bool Tran = false;
        public bool Attacking = false;
        public bool Sent = false;
        public bool HasBeendown = false;
        public int Attacktime = 0;
        public int Chaos = 0;
        public int WingC = 0;
        public int WingCC = 0;
        public int locala = 0;
        public int localb = 0;
        public int Talk = 0;
        public int timer = 0;
        public bool Bantran = false;
        public int[] atta = new int[16];
        public Vector2 Vk;

        public override void AI()
        {
            Player player = Main.player[Main.myPlayer];
            if (!Battle)
            {
                if (npc.life >= 10)
                {
                    npc.dontTakeDamage = false;
                }
                else
                {
                    npc.life += 2;
                }
                localb += 1;
                if (localb >= 5 && npc.life < npc.lifeMax)
                {
                    localb = 0;
                    npc.life += 1;
                }
                npc.townNPC = true;
                npc.friendly = true;
                if (Fly)
                {
                    WingCC += 1;
                    if (WingCC > 8)
                    {
                        WingC += 1;
                        WingCC = 0;
                    }
                }
                else
                {
                    WingC = 0;
                    WingCC = 0;
                }
                if (!npc.collideY)
                {
                    Fly = true;
                }
                else
                {
                    Fly = false;
                }
                float[] Px = new float[1201];
                float[] PxClo = new float[1201];
                Vector2[] DangerC = new Vector2[1201];
                int[] Theaten = new int[1201];
                int Pxmin = 2000;
                for (int j = 0; j < 1000; j++)
                {
                    Theaten[j] = 0;
                    PxClo[j] = 1000;
                    Px[j] = 1000;
                    if (Main.projectile[j].active && Main.projectile[j].hostile)
                    {
                        for (int z = 2; z < 20; z++)
                        {
                            float num7 = (npc.Center - (Main.projectile[j].Center + Main.projectile[j].velocity * z)).Length();
                            if (num7 < 100)
                            {
                                Px[j] = num7;
                            }
                            if (Px[j] < PxClo[j])
                            {
                                DangerC[j] = npc.Center - (Main.projectile[j].Center + Main.projectile[j].velocity * z);
                                PxClo[j] = Px[j];
                                Theaten[j] = Main.projectile[j].damage;
                            }
                        }
                    }
                }
                for (int j = 0; j < 200; j++)
                {
                    Theaten[j + 1000] = 0;
                    PxClo[j + 1000] = 1000;
                    Px[j + 1000] = 1000;
                    if (Main.npc[j].active && !Main.npc[j].friendly && Main.npc[j].damage > 120)
                    {
                        for (int z = 2; z < 20; z++)
                        {
                            float num7 = (npc.Center - (Main.npc[j].Center + Main.npc[j].velocity * z)).Length();
                            if (num7 < 100)
                            {
                                Px[j + 1000] = num7;
                            }
                            if (Px[j + 1000] < PxClo[j + 1000])
                            {
                                DangerC[j + 1000] = npc.Center - (Main.npc[j].Center + Main.npc[j].velocity * z);
                                PxClo[j + 1000] = Px[j + 1000];
                                Theaten[j + 1000] = Main.npc[j].damage;
                            }
                        }
                    }
                }
                /*string key = Main.npc[Ixmin].TypeName.ToString(); ;
                string key2 = Ix[Ixmin].ToString();
                Main.NewText(Language.GetTextValue(key2 + key), Color.Yellow);*/
                Vector2 ve = Vector2.Zero;
                int Dang = 0;
                for (int j = 0; j < 1200; j++)
                {
                    if (DangerC[j] != Vector2.Zero && DangerC[j].Length() < 100)
                    {
                        ve += DangerC[j] / (DangerC[j].Length() * DangerC[j].Length()) * Theaten[j];
                        Dang += 1;
                    }
                }
                if (Dang > 4)
                {
                    Tran = true;
                }
                if (Tran)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Vector2 Vk = new Vector2(0, Main.rand.NextFloat(25, 600f)).RotatedBy(Main.rand.NextFloat(0, (float)Math.PI * 2f));
                        Vector2 Vm = npc.Center + Vk;
                        if (!Main.tile[(int)(Vm.X / 16), (int)(Vm.Y / 16)].active() && !Main.tile[(int)(Vm.X / 16), (int)(Vm.Y / 16) + 1].active() && !Main.tile[(int)(Vm.X / 16), (int)(Vm.Y / 16) - 1].active() &&
                            !Main.tile[(int)(Vm.X / 16) + 1, (int)(Vm.Y / 16)].active() && !Main.tile[(int)(Vm.X / 16) + 1, (int)(Vm.Y / 16) + 1].active() && !Main.tile[(int)(Vm.X / 16) + 1, (int)(Vm.Y / 16) - 1].active() &&
                            !Main.tile[(int)(Vm.X / 16) - 1, (int)(Vm.Y / 16)].active() && !Main.tile[(int)(Vm.X / 16) - 1, (int)(Vm.Y / 16) + 1].active() && !Main.tile[(int)(Vm.X / 16) - 1, (int)(Vm.Y / 16) - 1].active())
                        {
                            float[] Py = new float[1201];
                            float[] PyClo = new float[1201];
                            Vector2[] DangerD = new Vector2[1201];
                            int[] Theatem = new int[1201];
                            int Pymin = 2000;
                            for (int j = 0; j < 1000; j++)
                            {
                                Theatem[j] = 0;
                                PyClo[j] = 1000;
                                Py[j] = 1000;
                                if (Main.projectile[j].active && Main.projectile[j].hostile)
                                {
                                    for (int z = 2; z < 20; z++)
                                    {
                                        float num7 = (Vm - (Main.projectile[j].Center + Main.projectile[j].velocity * z)).Length();
                                        if (num7 < 100)
                                        {
                                            Py[j] = num7;
                                        }
                                        if (Py[j] < PyClo[j])
                                        {
                                            DangerD[j] = Vm - (Main.projectile[j].Center + Main.projectile[j].velocity * z);
                                            PyClo[j] = Py[j];
                                            Theatem[j] = Main.projectile[j].damage;
                                        }
                                    }
                                }
                            }
                            for (int j = 0; j < 200; j++)
                            {
                                Theatem[j + 1000] = 0;
                                PyClo[j + 1000] = 1000;
                                Py[j + 1000] = 1000;
                                if (Main.npc[j].active && !Main.npc[j].friendly && Main.npc[j].damage > 120 && Main.npc[i].type == mod.NPCType("Yasitaya"))
                                {
                                    for (int z = 2; z < 20; z++)
                                    {
                                        float num7 = (Vm - (Main.npc[j].Center + Main.npc[j].velocity * z)).Length();
                                        if (num7 < 100)
                                        {
                                            Py[j + 1000] = num7;
                                        }
                                        if (Py[j + 1000] < PyClo[j + 1000])
                                        {
                                            DangerD[j + 1000] = Vm - (Main.npc[j].Center + Main.npc[j].velocity * z);
                                            PyClo[j + 1000] = Py[j + 1000];
                                            Theatem[j] = Main.npc[j].damage;
                                        }
                                    }
                                }
                            }
                            int Danh = 0;
                            for (int j = 0; j < 1200; j++)
                            {
                                if (DangerD[j] != Vector2.Zero && DangerD[j].Length() < 100)
                                {
                                    Danh += 1;
                                }
                            }
                            if (Danh == 0)
                            {
                                for (int za = 0; za < 100; za++)
                                {
                                    Vector2 vz = new Vector2(0, Main.rand.NextFloat(0, 5f)).RotatedByRandom(Math.PI * 2d);
                                    Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 255, vz.X, vz.Y, 0, default(Color), 1f);
                                }
                                npc.position += Vk;
                                for (int za = 0; za < 100; za++)
                                {
                                    Vector2 vz = new Vector2(0, Main.rand.NextFloat(0, 5f)).RotatedByRandom(Math.PI * 2d);
                                    Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 255, vz.X, vz.Y, 0, default(Color), 1f);
                                }
                                Tran = false;
                                Chaos = 50;
                                break;
                            }
                        }
                    }
                }
                Vector2 VPre = Vector2.Zero;
                if (Fly)
                {
                    VPre += ve;
                    if (ve.Length() > 4)
                    {
                        npc.velocity += ve / ve.Length() * 4f;
                    }
                    else
                    {
                        npc.velocity += ve;
                    }
                    if (npc.velocity.Length() > 8)
                    {
                        npc.velocity = npc.velocity / npc.velocity.Length() * 8f;
                    }
                    if (npc.velocity.X * ve.X + npc.velocity.Y * ve.Y < -8)
                    {
                        Tran = true;
                    }
                }
                else
                {
                    VPre += ve;
                    if (ve.Length() > 3)
                    {
                        npc.velocity += ve / ve.Length() * 3f;
                    }
                    else
                    {
                        npc.velocity += ve;
                    }
                    if (npc.velocity.Length() > 3)
                    {
                        npc.velocity = npc.velocity / npc.velocity.Length() * 3f;
                    }
                    if (npc.velocity.X * ve.X + npc.velocity.Y * ve.Y < -8)
                    {
                        Tran = true;
                    }
                }
                if (npc.wet)
                {
                    npc.velocity.Y -= 0.1f;
                }
                float[] Ix = new float[201];
                int Ixmin = 2000;
                int Count = 0;
                if (!Attacking)
                {
                    for (int j = 0; j < 200; j++)
                    {
                        Ix[j] = -1;
                        if (Collision.CanHit(npc.Center, 1, 1, Main.npc[j].Center, 1, 1) && Main.npc[j].active && Main.npc[j].type != mod.NPCType("Yasitaya") && !Main.npc[j].friendly && Main.npc[j].type != NPCID.TargetDummy)
                        {
                            float num7 = (npc.Center - Main.npc[j].Center).Length();
                            if (num7 < 800)
                            {
                                Ix[j] = num7;
                            }
                        }
                    }
                    for (int j = 0; j < 200; j++)
                    {
                        if (Ix[j] != -1)
                        {
                            Count += 1;
                            if (Ixmin == 2000)
                            {
                                Ixmin = j;
                            }
                            if (Ix[j] < Ix[Ixmin])
                            {
                                Ixmin = j;
                            }
                        }
                    }
                }
                if (Count > 0)
                {
                    Attacking = true;
                    npc.aiStyle = -1;
                    if (Ix[Ixmin] <= 120)
                    {
                        if ((Main.npc[Ixmin].Center.X - npc.Center.X) != 0)
                        {
                            npc.direction = Math.Sign(Main.npc[Ixmin].Center.X - npc.Center.X);
                        }
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("YasitayaBlade"), 200, 4, 255, 0f, 0f);
                        Attacktime = 25;
                    }
                }
                if (Attacktime > 0)
                {
                    Attacktime -= 1;
                }
                else
                {
                    Attacktime = 0;
                    npc.aiStyle = 7;
                    Attacking = false;
                }
                if (Chaos > 0)
                {
                    Chaos -= 1;
                    Vector2 vz = new Vector2(0, Main.rand.NextFloat(0, Chaos / 30f)).RotatedByRandom(Math.PI * 2d);
                    Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 255, vz.X, vz.Y, 0, default(Color), Chaos / 60f);
                }
                else
                {
                    Chaos = 0;
                }
                if (Talk > 0)
                {
                    Talk -= 1;
                    if (Talk == 360)
                    {
                        string key2 = "你…真的…好厉害";
                        Main.NewText(Language.GetTextValue(key2), Color.Yellow);
                    }
                    if (Talk == 240)
                    {
                        string key2 = "再打下去…我就要…死了";
                        Main.NewText(Language.GetTextValue(key2), Color.Yellow);
                    }
                    if (Talk == 120)
                    {
                        string key2 = "过来我这";
                        Main.NewText(Language.GetTextValue(key2), Color.Yellow);
                        Sent = true;
                    }
                    if (Talk == 500)
                    {
                        string key2 = "当然,我还有一把";
                        Main.NewText(Language.GetTextValue(key2), Color.Yellow);
                        Attacking = true;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("YasitayaBlade2"), 1, 4, 255, 0f, 0f);
                        Attacktime = 25;
                        Talk = 0;
                    }
                }
                else
                {
                    Talk = 0;
                    if (Sent)
                    {
                        if ((player.Center - npc.Center).Length() < 48)
                        {
                            string key2 = "这是我从小用到大的武器,今天送给你了,好好珍惜";
                            Main.NewText(Language.GetTextValue(key2), Color.Yellow);
                            Talk = 600;
                            Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y - 40, base.npc.width, base.npc.height, base.mod.ItemType("YasitayaWeapon"), 1, false, 0, false, false);
                            Sent = false;
                        }
                    }
                }
            }
            else
            {
                timer++;
                if (npc.life < 2000)
                {
                    npc.townNPC = true;
                    npc.friendly = true;
                    npc.aiStyle = 7;
                    npc.damage = 100;
                    npc.defense = 100;
                    npc.lifeMax = 500;
                    npc.life = 500;
                    Talk = 480;
                    Battle = false;
                    string key2 = "停下!";
                    Main.NewText(Language.GetTextValue(key2), Color.Yellow);
                }

                //飞行
                locala += 1;
                npc.friendly = false;
                npc.townNPC = false;
                if (Fly)
                {
                    WingCC += 1;
                    if (WingCC > 8)
                    {
                        WingC += 1;
                        WingCC = 0;
                    }
                }
                else
                {
                    WingC = 0;
                    WingCC = 0;
                }
                if (!npc.collideY)
                {
                    Fly = true;
                }
                else
                {
                    Fly = false;
                }
                float[] Px = new float[1201];
                float[] PxClo = new float[1201];
                Vector2[] DangerC = new Vector2[1201];
                int[] Theaten = new int[1201];
                int Pxmin = 2000;
                for (int j = 0; j < 1000; j++)
                {
                    Theaten[j] = 0;
                    PxClo[j] = 1000;
                    Px[j] = 1000;
                    if (Main.projectile[j].active && Main.projectile[j].friendly && Main.projectile[j].damage > 30)
                    {
                        for (int z = 2; z < 20; z++)
                        {
                            float num7 = (npc.Center - (Main.projectile[j].Center + Main.projectile[j].velocity * z)).Length();
                            if (num7 < 100)
                            {
                                Px[j] = num7;
                            }
                            if (Px[j] < PxClo[j])
                            {
                                DangerC[j] = npc.Center - (Main.projectile[j].Center + Main.projectile[j].velocity * z);
                                PxClo[j] = Px[j];
                                Theaten[j] = Main.projectile[j].damage;
                            }
                        }
                    }
                }

                //传送闪避
                if (timer < 500)
                {
                    Bantran = false;
                }
                if (timer >= 500 && timer < 1000)
                {
                    Bantran = true;
                }
                /*string key = Main.npc[Ixmin].TypeName.ToString(); 
                string key2 = Battle.ToString();
                Main.NewText(Language.GetTextValue(key2), Color.Yellow);*/
                Vector2 ve = Vector2.Zero;
                int Dang = 0;
                for (int j = 0; j < 1000; j++)
                {
                    if (DangerC[j] != Vector2.Zero && DangerC[j].Length() < 100)
                    {
                        ve += DangerC[j] / (DangerC[j].Length() * DangerC[j].Length()) * Theaten[j];
                        Dang += 1;
                    }
                }
                if (!Bantran)
                {
                    if (Dang > 4 && Chaos == 0)
                    {
                        Tran = true;
                    }
                }
                if (Tran)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        Vector2 Vk = new Vector2(0, Main.rand.NextFloat(25, 600f)).RotatedBy(Main.rand.NextFloat(0, (float)Math.PI * 2f));
                        Vector2 Vm = npc.Center + Vk;
                        if (!Main.tile[(int)(Vm.X / 16), (int)(Vm.Y / 16)].active() && !Main.tile[(int)(Vm.X / 16), (int)(Vm.Y / 16) + 1].active() && !Main.tile[(int)(Vm.X / 16), (int)(Vm.Y / 16) - 1].active() &&
                            !Main.tile[(int)(Vm.X / 16) + 1, (int)(Vm.Y / 16)].active() && !Main.tile[(int)(Vm.X / 16) + 1, (int)(Vm.Y / 16) + 1].active() && !Main.tile[(int)(Vm.X / 16) + 1, (int)(Vm.Y / 16) - 1].active() &&
                            !Main.tile[(int)(Vm.X / 16) - 1, (int)(Vm.Y / 16)].active() && !Main.tile[(int)(Vm.X / 16) - 1, (int)(Vm.Y / 16) + 1].active() && !Main.tile[(int)(Vm.X / 16) - 1, (int)(Vm.Y / 16) - 1].active())
                        {
                            float[] Py = new float[1201];
                            float[] PyClo = new float[1201];
                            Vector2[] DangerD = new Vector2[1201];
                            int[] Theatem = new int[1201];
                            int Pymin = 2000;
                            for (int j = 0; j < 1000; j++)
                            {
                                Theatem[j] = 0;
                                PyClo[j] = 1000;
                                Py[j] = 1000;
                                if (Main.projectile[j].active && Main.projectile[j].friendly && Main.projectile[j].damage > 30)
                                {
                                    for (int z = 2; z < 20; z++)
                                    {
                                        float num7 = (Vm - (Main.projectile[j].Center + Main.projectile[j].velocity * z)).Length();
                                        if (num7 < 100)
                                        {
                                            Py[j] = num7;
                                        }
                                        if (Py[j] < PyClo[j])
                                        {
                                            DangerD[j] = Vm - (Main.projectile[j].Center + Main.projectile[j].velocity * z);
                                            PyClo[j] = Py[j];
                                            Theatem[j] = Main.projectile[j].damage;
                                        }
                                    }
                                }
                            }
                            int Danh = 0;
                            for (int j = 0; j < 1200; j++)
                            {
                                if (DangerD[j] != Vector2.Zero && DangerD[j].Length() < 100)
                                {
                                    Danh += 1;
                                }
                            }
                            if (Danh == 0)
                            {
                                for (int za = 0; za < 100; za++)
                                {
                                    Vector2 vz = new Vector2(0, Main.rand.NextFloat(0, 5f)).RotatedByRandom(Math.PI * 2d);
                                    Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 255, vz.X, vz.Y, 0, default(Color), 1f);
                                }
                                npc.position += Vk;
                                for (int za = 0; za < 100; za++)
                                {
                                    Vector2 vz = new Vector2(0, Main.rand.NextFloat(0, 5)).RotatedByRandom(Math.PI * 2d);
                                    Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 255, vz.X, vz.Y, 0, default(Color), 1f);
                                }
                                Tran = false;
                                Chaos = 50;
                                break;
                            }
                        }
                    }
                }
                float theta = locala / 100f;
                float da = 1;
                float db = 1;
                float dc = locala / 20f;
                float dn = 3;
                float x = (float)(da * Math.Sin(dn * theta)) * 600;
                float y = (float)(db * Math.Sin(theta)) * 400;
                Vector2 vShouldBe = Vector2.Zero;

                //攻击
                if (timer < 500)
                {
                    vShouldBe = new Vector2(x, y) + player.Center;
                }
                if (timer >= 500 && timer <= 600)
                {
                    vShouldBe = new Vector2(0, -600) + player.Center;
                }
                if (timer == 600)
                {
                    Vk = player.Center + new Vector2(0, 1000);
                }
                if (timer > 600 && timer < 800)
                {
                    vShouldBe = Vk;
                }
                if (timer > 800 && timer < 1000)
                {
                    vShouldBe = player.Center + new Vector2(120, 0);
                    if (timer > 840)
                    {
                        npc.spriteDirection = -1;
                    }
                }
                Vector2 Vadd = (vShouldBe - npc.Center) / (vShouldBe - npc.Center).Length() * 2f;
                Vector2 VPre = Vector2.Zero;
                if (Fly)
                {
                    if (timer < 620)
                    {
                        VPre += ve;
                        npc.velocity += Vadd;
                        if (ve.Length() > 8)
                        {
                            npc.velocity += ve / ve.Length() * 8f;
                        }
                        else
                        {
                            npc.velocity += ve;
                        }
                        if (npc.velocity.Length() > 16)
                        {
                            npc.velocity = npc.velocity / npc.velocity.Length() * 16f;
                        }
                    }
                    if (timer < 1000 && timer > 800)
                    {
                        VPre += ve;
                        npc.velocity += Vadd;
                        if (ve.Length() > 8)
                        {
                            npc.velocity += ve / ve.Length() * 8f;
                        }
                        else
                        {
                            npc.velocity += ve;
                        }
                        if (npc.velocity.Length() > 16)
                        {
                            npc.velocity = npc.velocity / npc.velocity.Length() * 16f;
                        }
                    }
                    if (npc.velocity.X * ve.X + npc.velocity.Y * ve.Y < -8 && Chaos == 0)
                    {
                        if (!Bantran)
                        {
                            Tran = true;
                        }
                    }
                }
                else
                {
                    if (timer < 600)
                    {
                        npc.velocity += Vadd / 2.5f;
                        VPre += ve;
                        if (ve.Length() > 6)
                        {
                            npc.velocity += ve / ve.Length() * 6f;
                        }
                        else
                        {
                            npc.velocity += ve;
                        }
                        if (npc.velocity.Length() > 6)
                        {
                            npc.velocity = npc.velocity / npc.velocity.Length() * 6f;
                        }
                    }
                    if (timer < 1000 && timer > 800)
                    {
                        npc.velocity += Vadd / 2.5f;
                        VPre += ve;
                        if (ve.Length() > 6)
                        {
                            npc.velocity += ve / ve.Length() * 6f;
                        }
                        else
                        {
                            npc.velocity += ve;
                        }
                        if (npc.velocity.Length() > 6)
                        {
                            npc.velocity = npc.velocity / npc.velocity.Length() * 6f;
                        }
                    }
                    if (npc.velocity.X * ve.X + npc.velocity.Y * ve.Y < -8 && Chaos == 0)
                    {
                        if (!Bantran)
                        {
                            Tran = true;
                        }
                    }
                }
                if (timer < 500)
                {
                    Shock = false;
                    vShouldBe = new Vector2(x, y) + player.Center;
                    int Countz = 0;
                    if ((npc.Center - player.Center).Length() < 150)
                    {
                        Countz = 1;
                    }
                    if ((npc.Center - player.Center).Length() > 320)
                    {
                        Countz = 2;
                    }
                    if (Attacktime == 0)
                    {
                        if (npc.velocity.X != 0)
                        {
                            npc.spriteDirection = Math.Sign(npc.velocity.X);
                            npc.direction = Math.Sign(npc.velocity.X);
                        }
                    }
                    if (Countz == 1 && !Attacking && locala > 240)
                    {
                        Attacking = true;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("YasitayaBlade2"), 90, 4, 255, 0f, 0f);
                        if (npc.velocity.X != 0)
                        {
                            npc.spriteDirection = Math.Sign(npc.velocity.X);
                            npc.direction = Math.Sign(npc.velocity.X);
                        }
                        Attacktime = 25;
                    }
                    if (Countz == 2 && !Attacking && locala > 240)
                    {
                        Attacking = true;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("YasitayaBlade3"), 90, 4, 255, 0f, 0f);
                        if (npc.velocity.X != 0)
                        {
                            npc.spriteDirection = Math.Sign(npc.velocity.X);
                            npc.direction = Math.Sign(npc.velocity.X);
                        }
                        Attacktime = 40;
                    }
                    if (Attacktime > 0)
                    {
                        Attacktime -= 1;
                    }
                    else
                    {
                        Attacktime = 0;
                        Attacking = false;
                    }
                }
                if (timer >= 500 && timer < 800)
                {
                    if (timer == 500)
                    {
                        Projectile.NewProjectile(npc.Center.X - 164, npc.Center.Y - 150, 0, 0, mod.ProjectileType("GiantSword"), 90, 4, 255, 0f, 0f);
                    }
                    if (timer == 600)
                    {
                        for (int k = 0; k < 18; k++)
                        {
                            int h = Projectile.NewProjectile(npc.Center.X - 19 + (k - 8.5f) * 150, npc.Center.Y - 150 + (float)(60 * Math.Sin((k - 8.5f) / 3d)), 0, 0, mod.ProjectileType("BloodSwordGas"), 30, 0.5f, 255, Math.Abs((k - 8.5f) * 4f), 0);
                            Main.projectile[h].ai[0] = Math.Abs((k - 8.5f) * 4f) + 30;
                        }
                    }
                    if (timer >= 600)
                    {
                        if (!npc.collideY)
                        {
                            npc.velocity.Y += 1.3f;
                            npc.velocity.X *= 0;
                        }
                        else
                        {
                            if (!Shock)
                            {
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 150, 0, 0, mod.ProjectileType("CrackBomb"), 90, 4, 255, 0f, 0f);
                                Shock = true;
                            }
                        }
                    }
                    else
                    {
                    }
                }
                if (timer >= 800 && timer < 1000)
                {
                    if (timer == 900)
                    {
                        Projectile.NewProjectile(npc.Center.X - 164, npc.Center.Y - 150, 0, 0, mod.ProjectileType("DarkKnife"), 60, 4, 255, 0f, 0f);
                    }
                }
                if (timer > 1000)
                {
                    timer = 0;
                }
                if (Chaos > 0)
                {
                    Chaos -= 1;
                    Vector2 vz = new Vector2(0, Main.rand.NextFloat(0, Chaos / 30f)).RotatedByRandom(Math.PI * 2d);
                    Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 255, vz.X, vz.Y, 0, default(Color), Chaos / 60f);
                }
                else
                {
                    Chaos = 0;
                }
                npc.dontTakeDamage = false;
            }
            if (player.dead && Battle)
            {
                npc.townNPC = true;
                npc.friendly = true;
                npc.aiStyle = 7;
                npc.damage = 100;
                npc.defense = 100;
                npc.lifeMax = 500;
                npc.boss = false;
                npc.life = 500;
                npc.active = true;
                locala = 0;
                Battle = false;
                string key2 = "我下手好像…重了点";
                Main.NewText(Language.GetTextValue(key2), Color.Yellow);
            }
        }
        private bool Shock = false;
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (NPC.AnyNPCs(npc.type))
            {
                return 0f;
            }
            return 2f;
        }
        public override string GetChat()
        {
            IList<string> list = new List<string>();
            if (Main.dayTime)
            {
                list.Add("你在干嘛啊");
                if (NPC.CountNPCS(22) != 0)
                {
                    list.Add("对了,要好好感谢向导");
                }
                if (NPC.CountNPCS(54) != 0)
                {
                    list.Add("其实服装师以前成就厉害的,暗影魔法大师呢");
                }
                list.Add("没事不要烦我");
                list.Add("干嘛!");
                list.Add("额，好吧，我承认我的脾气有点暴躁");
                list.Add("我觉得你是不是喜欢我");
                list.Add("你烦不烦啊!");
                /*list.Add("不就是砍了你一刀么,没什么大不了");*/
                list.Add("嘻嘻嘻");
            }
            else
            {
                list.Add("晚上就应该出去浪");
                list.Add("你在干嘛啊");
                if (NPC.CountNPCS(22) != 0)
                {
                    list.Add("对了,要好好感谢向导");
                }
                if (NPC.CountNPCS(54) != 0)
                {
                    list.Add("其实服装师以前成就厉害的,暗影魔法大师呢");
                }
                list.Add("没事不要烦我");
                list.Add("干嘛!");
                list.Add("额，好吧，我承认我的脾气有点暴躁");
                list.Add("我觉得你是不是喜欢我");
                list.Add("你烦不烦啊!");
                /*list.Add("不就是砍了你一刀么,没什么大不了");*/
                list.Add("嘻嘻嘻");
            }
            return list[Main.rand.Next(list.Count)];
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("挑战");
            button2 = Language.GetTextValue("帮助");
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            if (npc.life < 2000 && Battle)
            {
                npc.townNPC = true;
                npc.friendly = true;
                npc.aiStyle = 7;
                npc.damage = 100;
                npc.defense = 100;
                npc.lifeMax = 500;
                npc.boss = false;
                npc.life = 500;
                npc.active = true;
                Talk = 480;
                locala = 0;
                Battle = false;
                string key2 = "停下!";
                Main.NewText(Language.GetTextValue(key2), Color.Yellow);
            }
            if (npc.life < 10 && !Battle)
            {
                npc.dontTakeDamage = true;
                npc.active = true;
                npc.life += 10;
            }
            if (npc.life >= 10 && !Battle)
            {
                npc.dontTakeDamage = false;
            }
        }
        /*String Ta = "挑战";*/
        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            shop = false;
            /*Main.npcChatText = "";*/
            if (firstButton)
            {
                if (!HasBeendown)
                {
                    npc.friendly = false;
                    npc.aiStyle = -1;
                    npc.lifeMax = 50000;
                    npc.life = 50000;
                    npc.boss = true;
                    locala = 0;
                    Battle = true;
                }
                else
                {
                    Main.npcChatText = "挑战? 捉迷藏吗";
                }
            }
            else
            {
                IList<string> list = new List<string>();
                list.Add("用诡药和大理石块可以合成封印碎片,把它放进大理石神庙碎片堆");
                list.Add("向日葵也可以制作武器");
                list.Add("游戏前期弹弓非常的好用");
                if (MythWorld.Myth)
                {
                    list.Add("血肉墙每隔一段时间自动反向,千万小心");
                    list.Add("阴阳寿命可以用来在作战时原地复活,但一定要快,Boss跑了之后复活就浪费了");
                    list.Add("你可以通过击杀Boss恢复阴阳寿命,也可以通过药剂恢复");
                    list.Add("与克苏鲁之眼交战的时候,会有黑暗诅咒,你啥都看不见,往地上扔物品能帮你大致看清楚");
                    list.Add("悄悄告诉你,荣耀之剑都.是.玩.具");
                    list.Add("血肉墙体内藏有一个超级神器暗金刀?那只是传说罢了");
                    list.Add("机械骷髅王的激光陀螺受到单侧攻击就会加速,当速度快到它无法承受它才会消失");
                    list.Add("机械骷髅王的手臂尽量保留一条,要不然战斗会变得更加艰难");
                    list.Add("毁灭者的红色保护罩能极大地提升其内部体节的防御力,如果可能,尽量在第一时间破坏");
                    list.Add("双子魔眼最好不要同时进入第二形态,噢,那真的……");
                    list.Add("世纪之花放出的绿色烟雾一定要躲开,对你有毒,它却在里面疯狂回血");
                    list.Add("石巨人放出来的能源灯只能打碎那些亮着的,否则很麻烦");
                    list.Add("阴阳寿命现在已经完全是福利了,可以用于原地复活,清零后不会有负面影响");
                }
                list.Add("羽毛槽位与它能承载的羽毛品相有关,你不能把颜色优于槽位的羽毛装进去");
                list.Add("想做手机却不想钓鱼?去打封魔石瓶,里面封印的力量和一次上古航海有关");
                list.Add("用机械Boss掉落的激光电池可以做出路由器,在它附近拿出你的手机,按下右键可以联网");
                list.Add("海边收集到的神秘碎片千万不要丢掉,它们能帮你去到另一个大陆");
                list.Add("获得符咒的最佳方法是刷Boss");
                list.Add("传说云间生长着一株光之花");
                list.Add("棍棒可以解决绝大多数近身威胁");
                list.Add("在恶魔祭坛可以用泥土合成泥塑颅骨,如果你弱到连史莱姆王都打不过,那你还是先玩玩泥塑颅骨吧");
                list.Add("闪避伤害后,仍然会获得无敌时间");
                list.Add("手电筒可以用来探测地形,前期的时候相当好用");
                list.Add("羽毛可能藏在树上,把树砍倒就会掉落,或者在世界树顶部收集");
                list.Add("冰冻符咒可以在Boss残血的时候使用,趁着冰冻速速击杀它,因为残血Boss的恐怖程度……");
                list.Add("月总后霜月和南瓜月会加强,期间掉落的魂是个好东西");
                list.Add("空中的飞龙有极低概率掉落雷之花,同样,邪教徒的飞龙也会掉落影之花");
                list.Add("带着神圣之地的水晶去问向导,当你做出结晶原萃的时候,嘿嘿,法师界无人能敌");
                list.Add("激光剑是晶光剑的升级版,颜值与输出并存");

                if (WorldGen.crimson)
                {
                    list.Add("猩红之地有一定概率长出鲜血獠牙,样子是可怕了点,但你不去惹它啥事没有");
                }
                else
                {
                    list.Add("如果你在腐化之地的峭壁上发现一个吊着的蛹,没有足够把握不要捅它");
                }
                list.Add("如果你真的打不过那些Boss,试着把它引过来我这,我能帮你一把");
                list.Add("海洋封印台的启动需要完成拼图,具体拼法台子上写了");
                Main.npcChatText = list[Main.rand.Next(list.Count)];
            }
        }
        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            /*shop.item[nextSlot].SetDefaults(base.mod.ItemType("StarMark"), false);
			shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 70, 0, 0));
			nextSlot++;*/
        }
        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 150;
            knockback = 2f;
        }
        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 180;
            randExtraCooldown = 60;
        }
        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            //projType = base.mod.ProjectileType("Alpenstock");
            //attackDelay = 1;
        }
        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 2f;
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
            vector2 -= new Vector2((float)base.mod.GetTexture("NPCs/Yasitaya/YasitayaGlow").Width, (float)(base.mod.GetTexture("NPCs/Yasitaya/YasitayaGlow").Height / Main.npcFrameCount[base.npc.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.npc.gfxOffY);
            Color color2 = Lighting.GetColor((int)(npc.Center.X / 16d), (int)(npc.Center.Y / 16d));
            Color color = Utils.MultiplyRGBA(new Color(297 - base.npc.alpha, 297 - base.npc.alpha, 297 - base.npc.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/Yasitaya/YasitayaGlow"), vector2, new Rectangle?(base.npc.frame), color * (0.25f), base.npc.rotation, vector, 1f, effects, 0f);
            if (Chaos > 0)
            {
                Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/Yasitaya/YasitayaTran"), npc.Center - Main.screenPosition + new Vector2(12 * npc.spriteDirection, 0), new Rectangle(0, 0, 50, 46), color2, base.npc.rotation, new Vector2(25, 23), 1f, effects, 0f);
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (WingC > 3)
            {
                WingC = 0;
            }
            Color color2 = Lighting.GetColor((int)(npc.Center.X / 16d), (int)(npc.Center.Y / 16d));
            if (Fly)
            {
                SpriteEffects effects = SpriteEffects.None;
                if (base.npc.spriteDirection == 1)
                {
                    effects = SpriteEffects.FlipHorizontally;
                }
                Vector2 value = new Vector2(base.npc.Center.X, base.npc.Center.Y);
                Vector2 vector = new Vector2((float)(Main.npcTexture[base.npc.type].Width / 2), (float)(Main.npcTexture[base.npc.type].Height / Main.npcFrameCount[base.npc.type] / 2));
                Vector2 vector2 = value - Main.screenPosition;
                vector2 -= new Vector2((float)base.mod.GetTexture("NPCs/Yasitaya/YasitayaWings").Width, (float)(base.mod.GetTexture("NPCs/Yasitaya/YasitayaWings").Height / 4)) * 1f / 2f;
                vector2 += vector * 1f + new Vector2(0f, 4f + base.npc.gfxOffY);

                Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/Yasitaya/YasitayaWings"), vector2 + new Vector2(18, 28) + new Vector2(2 * (1 - npc.spriteDirection) * 2, 0), new Rectangle(0, WingC * 56, 86, 56), color2, base.npc.rotation, new Vector2(43, 56), 1f, effects, 0f);

            }
            return true;
        }
    }
}
