using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.Linq;
using System.Text;

namespace MythMod.NPCs.CrystalSword
{
    [AutoloadBossHead]
    public class CrystalSwordEX : ModNPC
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("冰洲石剑EX");
            Main.npcFrameCount[base.npc.type] = 1;
        }
        private int m = 0;
        private bool k;
        private bool X = true;
        private Vector2 vg = new Vector2(0, -250f);
        private int[] num1 = new int[12];
        public override void SetDefaults()
        {
            base.npc.damage = 3000;
            base.npc.width = 40;
            base.npc.height = 40;
            base.npc.defense = 150;
            base.npc.lifeMax = 99999999;
            for (int i = 0; i < base.npc.buffImmune.Length; i++)
            {
                base.npc.buffImmune[i] = true;
            }
            base.npc.knockBackResist = 0f;
            base.npc.value = (float)Item.buyPrice(0, 18, 0, 0);
            base.npc.color = new Color(0, 0, 0, 0);
            base.npc.alpha = 0;
            base.npc.boss = true;
            base.npc.lavaImmune = true;
            base.npc.noGravity = true;
            base.npc.noTileCollide = true;
            base.npc.aiStyle = -1;
            this.aiType = -1;
            NPCID.Sets.TrailCacheLength[base.npc.type] = 4;
            NPCID.Sets.TrailingMode[base.npc.type] = 0;
            this.music = mod.GetSoundSlot((Terraria.ModLoader.SoundType)51, "Sounds/Music/Triodust-Hope");
        }
        private float Omega = 0;
        private float Omega2 = 0;
        private float Rota = 0;
        private bool flag1 = true;
        private bool flag2 = true;
        public override void BossHeadRotation(ref float rotation)
        {
            rotation = npc.rotation + (float)Math.PI / 4f;
        }
        public override void AI()
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.KillCrystal = npc.lifeMax - npc.life;
            base.npc.lifeMax = 4000000;
            if (m == 0)
            {
                npc.life = 4000000;
                m = 1;
            }
            base.npc.TargetClosest(false);
            Player player = Main.player[base.npc.target];
            bool expertMode = Main.expertMode;
            bool zoneUnderworldHeight = player.ZoneUnderworldHeight;
            Vector2 vector = new Vector2(base.npc.Center.X, base.npc.Center.Y);
            Vector2 center = base.npc.Center;
            float num = player.Center.X - vector.X;
            float num2 = player.Center.Y - vector.Y;
            float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
            npc.localAI[0] += 1;
            if (mplayer.KillCrystal <= 1000000)
            {
                npc.defense = (int)((player.Center - npc.Center).Length() * 8f);
                if (npc.localAI[0] % 1440 == 0)
                {
                    //npc.localAI[0] = 12960;
                    npc.localAI[0] = Main.rand.Next(10) * 1440;
                }
                if (npc.localAI[0] < 1440)
                {
                    if (npc.localAI[0] % 60 < 30)
                    {
                        npc.velocity *= 0.25f;
                        npc.rotation += Omega;
                        Omega += 0.04f;
                    }
                    if (npc.localAI[0] % 60 == 30)
                    {
                        Omega = 0;
                        npc.velocity = (player.Center - npc.Center) / num3 * 30f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                    if (npc.localAI[0] % 60 > 30)
                    {
                        npc.velocity *= 0.99f;
                        Vector2 v = (player.Center - npc.Center);
                        Vector2 v2 = player.Center - npc.Center - npc.velocity;
                        if (npc.velocity.Length() * npc.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                        {
                            npc.velocity *= 0.85f;
                        }
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                }
                if (npc.localAI[0] >= 1440 && npc.localAI[0] < 2880)
                {
                    if (npc.velocity.Length() > 0.00001)
                    {
                        npc.velocity *= 0.5f;
                    }
                    npc.rotation += Omega;
                    Omega = 0.45f;
                    if (npc.localAI[0] % 8 == 4)
                    {
                        Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword"), 3000, 2f, Main.myPlayer, (float)Math.PI * Main.rand.NextFloat(0, 2f), 0f);
                    }
                    if (npc.localAI[0] % 8 == 0)
                    {
                        Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword3"), 3000, 2f, Main.myPlayer, (float)Math.PI * Main.rand.NextFloat(0, 2f), 0f);
                    }
                    if (npc.localAI[0] % 120 == 0)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = npc.velocity.RotatedBy(Math.PI / 10d * (float)i) / (npc.velocity.Length()) * 1f;
                            Main.projectile[o].timeLeft = 600;
                        }
                    }
                }
                if (npc.localAI[0] >= 2880 && npc.localAI[0] < 4320)
                {
                    npc.velocity *= 0.5f;
                    npc.rotation += Omega;
                    Omega = 0.1f;
                    if (npc.localAI[0] % 15 == 4)
                    {
                        Projectile.NewProjectile(player.Center.X + Main.rand.Next(-600, 600), player.Center.Y - 800, Main.rand.Next(-600, 600) / 100f, 20f, base.mod.ProjectileType("CrystalSword2"), 3000, 2f, Main.myPlayer, (float)Math.PI * 0.17f, 0f);
                        Projectile.NewProjectile(player.Center.X + Main.rand.Next(-600, 600), player.Center.Y - 800, Main.rand.Next(-600, 600) / 100f, 20f, base.mod.ProjectileType("CrystalSword5"), 3000, 2f, Main.myPlayer, -(float)Math.PI * 0.17f, 0f);
                    }
                }
                if (npc.localAI[0] >= 4320 && npc.localAI[0] < 5760)
                {
                    if (npc.localAI[0] % 120 == 0)
                    {
                        npc.velocity = (player.Center - npc.Center) / num3 * 0.4f;
                        for (int i = -10; i < 10; i++)
                        {
                            if (i > 0)
                            {
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -npc.velocity.Y * i * 11, npc.velocity.X * i * 11, base.mod.ProjectileType("CrystalSword4"), 3000, 2f, Main.myPlayer, -1, 0f);
                            }
                            if (i < 0)
                            {
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -npc.velocity.Y * i * 11, npc.velocity.X * i * 11, base.mod.ProjectileType("CrystalSword4"), 3000, 2f, Main.myPlayer, 1, 0f);
                            }
                        }
                    }
                    if (npc.localAI[0] % 120 > 0)
                    {
                        Vector2 v = (player.Center - npc.Center);
                        Vector2 v2 = player.Center - npc.Center - npc.velocity;
                        if (npc.velocity.Length() * npc.velocity.Length() + v.Length() * v.Length() < (v2.Length() * v2.Length()))
                        {
                            npc.velocity *= 0.96f;
                        }
                        else
                        {
                            npc.velocity *= 1.05f;
                        }
                    }
                    npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                }
                if (npc.localAI[0] >= 5760 && npc.localAI[0] < 7200)
                {
                    if (npc.localAI[0] == 5760)
                    {
                        vg = player.Center + new Vector2(0, -500f);
                    }
                    Vector2 v2g = new Vector2(0, 200).RotatedBy(npc.localAI[0] / 15d);
                    Vector2 v3g = vg + new Vector2(v2g.X, v2g.Y / 4f);
                    if (npc.localAI[0] >= 5760 && npc.localAI[0] < 7200)
                    {
                        if (npc.localAI[0] >= 5760 && npc.localAI[0] < 6240)
                        {
                            npc.velocity += (v3g - npc.Center) / 60f;
                            npc.velocity *= 0.98f;
                            npc.rotation = (float)Math.PI / 2f + npc.velocity.X / 48f;
                            int numl = Dust.NewDust(npc.Center + new Vector2(0, 110).RotatedBy(npc.rotation - (float)Math.PI / 2f), 1, 1, 91, 0, 0, 0, default(Color), 1.8f);
                            Main.dust[numl].velocity *= 0;
                            Main.dust[numl].noGravity = true;
                            if (npc.localAI[0] == 6239)
                            {
                                int yu = Projectile.NewProjectile((npc.Center + new Vector2(0, 110).RotatedBy(npc.rotation - (float)Math.PI / 2f)).X, (npc.Center + new Vector2(0, 110).RotatedBy(npc.rotation - (float)Math.PI / 2f)).Y, npc.velocity.X, npc.velocity.Y, base.mod.ProjectileType("CrystalSwordOvalEffect"), 0, 0, Main.myPlayer, vg.X, vg.Y + 100f);
                                Main.projectile[yu].timeLeft = 6000;
                            }
                        }
                        if (npc.localAI[0] >= 6240 && npc.localAI[0] < 7200)
                        {
                            if (npc.localAI[0] % 120 < 60)
                            {
                                npc.velocity *= 0.5f;
                                npc.rotation += Omega;
                                Omega += 0.02f;
                                if (npc.localAI[0] % 120 == 10)
                                {
                                    Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword"), 3000, 2f, Main.myPlayer, (float)Math.PI * 0.17f, 0f);
                                    Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword"), 3000, 2f, Main.myPlayer, -(float)Math.PI * 0.17f, 0f);
                                }
                            }
                            if (npc.localAI[0] % 120 == 60)
                            {
                                Omega = 0;
                                npc.velocity = (player.Center - npc.Center) / num3 * 45f;
                                npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                            }
                            if (npc.localAI[0] % 120 > 60)
                            {
                                npc.velocity *= 0.99f;
                                Vector2 v = (player.Center - npc.Center);
                                Vector2 v2 = player.Center - npc.Center - npc.velocity;
                                if (npc.velocity.Length() * npc.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                                {
                                    npc.velocity *= 0.95f;
                                }
                                npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                            }
                        }
                    }
                }
                if (npc.localAI[0] >= 7200 && npc.localAI[0] < 8640)
                {
                    if (npc.localAI[0] >= 7200 && npc.localAI[0] < 7440)
                    {
                        npc.velocity *= 0.9f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        Vector2 v = (player.Center - npc.Center);
                        npc.velocity += v / v.Length() * 0.05f;
                        if (npc.localAI[0] == 7200)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                num1[i] = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            }
                        }
                        for (int i = 0; i < 12; i++)
                        {
                            Main.projectile[num1[i]].position = npc.Center + npc.velocity.RotatedBy(Math.PI / 6d * (float)i) / npc.velocity.Length() * (npc.localAI[0] - 7199);
                            Main.projectile[num1[i]].velocity = npc.velocity.RotatedBy(Math.PI / 6d * (float)i) / npc.velocity.Length() * 0.01f;
                            Main.projectile[num1[i]].timeLeft = 240;
                            Main.projectile[num1[i]].scale = (npc.localAI[0] - 7199) / 480f;
                        }
                    }
                    if (npc.localAI[0] >= 7920 && npc.localAI[0] < 8160)
                    {
                        npc.velocity *= 0.9f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        Vector2 v = (player.Center - npc.Center);
                        npc.velocity += v / v.Length() * 0.05f;
                        if (npc.localAI[0] == 7920)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                num1[i] = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            }
                        }
                        for (int i = 0; i < 12; i++)
                        {
                            Main.projectile[num1[i]].position = npc.Center + npc.velocity.RotatedBy(Math.PI / 6d * (float)i) / npc.velocity.Length() * (npc.localAI[0] - 7919);
                            Main.projectile[num1[i]].velocity = npc.velocity.RotatedBy(Math.PI / 6d * (float)i) / npc.velocity.Length() * 0.01f;
                            Main.projectile[num1[i]].timeLeft = 240;
                            Main.projectile[num1[i]].scale = (npc.localAI[0] - 7919) / 480f;
                        }
                    }
                    if (npc.localAI[0] >= 7440 && npc.localAI[0] < 7920)
                    {
                        if (npc.localAI[0] % 120 < 60)
                        {
                            npc.velocity *= 0.5f;
                            npc.rotation += Omega;
                            Omega += 0.02f;
                        }
                        if (npc.localAI[0] % 120 == 60)
                        {
                            Omega = 0;
                            npc.velocity = (player.Center - npc.Center) / num3 * 45f;
                            npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        }
                        if (npc.localAI[0] % 120 > 60)
                        {
                            npc.velocity *= 0.99f;
                            Vector2 v = (player.Center - npc.Center);
                            Vector2 v2 = player.Center - npc.Center - npc.velocity;
                            if (npc.velocity.Length() * npc.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                            {
                                npc.velocity *= 0.95f;
                            }
                            npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        }
                        if (npc.localAI[0] != 7919)
                        {
                            Rota += Omega2;
                            if (Omega2 < 0.03f)
                            {
                                Omega2 += 0.0003f;
                            }
                            for (int i = 0; i < 12; i++)
                            {
                                Main.projectile[num1[i]].position = npc.Center + npc.velocity.RotatedBy(Math.PI / 6d * (float)i + Rota) / npc.velocity.Length() * 240f;
                                Main.projectile[num1[i]].velocity = npc.velocity.RotatedBy(Math.PI / 6d * (float)i + Rota) / npc.velocity.Length() * 0.01f;
                                Main.projectile[num1[i]].timeLeft = 240;
                            }
                        }
                        if (npc.localAI[0] == 7919)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                Main.projectile[num1[i]].position = npc.Center + npc.velocity.RotatedBy(Math.PI * (float)i / 6d + Rota) / npc.velocity.Length() * 240f;
                                Main.projectile[num1[i]].velocity = npc.velocity.RotatedBy(Math.PI * (float)i / 6d + Rota) / npc.velocity.Length() * 2f;
                                Main.projectile[num1[i]].timeLeft = 240;
                                num1[i] = 0;
                            }
                            Rota = 0;
                            Omega2 = 0;
                        }
                    }
                    if (npc.localAI[0] >= 8160 && npc.localAI[0] < 8640)
                    {
                        if (npc.localAI[0] % 120 < 60)
                        {
                            npc.velocity *= 0.5f;
                            npc.rotation += Omega;
                            Omega += 0.02f;
                        }
                        if (npc.localAI[0] % 120 == 60)
                        {
                            Omega = 0;
                            npc.velocity = (player.Center - npc.Center) / num3 * 45f;
                            npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        }
                        if (npc.localAI[0] % 120 > 60)
                        {
                            npc.velocity *= 0.99f;
                            Vector2 v = (player.Center - npc.Center);
                            Vector2 v2 = player.Center - npc.Center - npc.velocity;
                            if (npc.velocity.Length() * npc.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                            {
                                npc.velocity *= 0.95f;
                            }
                            npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        }
                        if (npc.localAI[0] != 8639)
                        {
                            Rota += Omega2;
                            if (Omega2 < 0.03f)
                            {
                                Omega2 += 0.0003f;
                            }
                            for (int i = 0; i < 12; i++)
                            {
                                Main.projectile[num1[i]].position = npc.Center + npc.velocity.RotatedBy(Math.PI / 6d * (float)i + Rota) / npc.velocity.Length() * 240f;
                                Main.projectile[num1[i]].velocity = npc.velocity.RotatedBy(Math.PI / 6d * (float)i + Rota) / npc.velocity.Length() * 0.01f;
                                Main.projectile[num1[i]].timeLeft = 240;
                            }
                        }
                        if (npc.localAI[0] == 8639)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                Main.projectile[num1[i]].position = npc.Center + npc.velocity.RotatedBy(Math.PI * (float)i / 6d + Rota) / npc.velocity.Length() * 240f;
                                Main.projectile[num1[i]].velocity = npc.velocity.RotatedBy(Math.PI * (float)i / 6d + Rota) / npc.velocity.Length() * 2f;
                                Main.projectile[num1[i]].timeLeft = 240;
                                num1[i] = 0;
                            }
                            Rota = 0;
                            Omega2 = 0;
                        }
                    }
                }
                if (npc.localAI[0] >= 8640 && npc.localAI[0] < 10080)
                {
                    if (npc.localAI[0] < 9030)
                    {
                        npc.velocity *= 0.25f;
                        npc.rotation += Omega;
                        Omega += 0.04f;
                    }
                    if (npc.localAI[0] == 9030)
                    {
                        Omega = 0;
                        npc.velocity = (player.Center + new Vector2(0, -400f) - npc.Center) / num3 * 45f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                    if (npc.localAI[0] > 9030 && npc.localAI[0] < 9060)
                    {
                        npc.velocity *= 0.99f;
                        Vector2 v = (player.Center + new Vector2(0, -200f) - npc.Center);
                        Vector2 v2 = player.Center + new Vector2(0, -200f) - npc.Center - npc.velocity;
                        if (npc.velocity.Length() * npc.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                        {
                            npc.velocity *= 0.85f;
                        }
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                    npc.velocity *= 0.5f;
                    npc.rotation += Omega;
                    Omega = 0.1f;
                    if (npc.localAI[0] % 60 == 30)
                    {
                        for (int i = -20; i < 20; i++)
                        {
                            Projectile.NewProjectile(npc.Center.X + i * 120, npc.Center.Y - 800, 0, 7f, base.mod.ProjectileType("CrystalSword2"), 3000, 2f, Main.myPlayer, -(float)Math.PI * 0.17f, 0f);
                        }
                    }
                    if (npc.localAI[0] % 60 == 0)
                    {
                        for (int i = -20; i < 20; i++)
                        {
                            Projectile.NewProjectile(npc.Center.X + i * 120 + 60, npc.Center.Y - 800, 0, 7f, base.mod.ProjectileType("CrystalSword5"), 3000, 2f, Main.myPlayer, -(float)Math.PI * 0.17f, 0f);
                        }
                    }
                }
                if (npc.localAI[0] >= 10080 && npc.localAI[0] < 11520)
                {
                    if (npc.localAI[0] % 30 < 15)
                    {
                        npc.velocity *= 0.25f;
                        npc.rotation += Omega;
                        Omega += 0.06f;
                    }
                    if (npc.localAI[0] % 30 == 15)
                    {
                        Omega = 0;
                        float j = Main.rand.NextFloat(0.5f, 1.3f);
                        if (Main.rand.Next(2) == 0)
                        {
                            j *= -1;
                        }
                        npc.velocity = (player.Center - npc.Center).RotatedBy(j) / num3 * 45f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        for (int i = 0; i < 6; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = npc.velocity.RotatedBy(Math.PI / 3d * (float)i) / npc.velocity.Length() * 0.01f;
                            Main.projectile[o].timeLeft = 1080;
                        }
                    }
                    if (npc.localAI[0] % 30 > 15)
                    {
                        npc.velocity *= 0.99f;
                        Vector2 v = (player.Center - npc.Center);
                        Vector2 v2 = player.Center - npc.Center - npc.velocity;
                        if (npc.velocity.Length() * npc.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                        {
                            npc.velocity *= 0.85f;
                        }
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                }
                if (npc.localAI[0] >= 11520 && npc.localAI[0] < 12960)
                {
                    if (npc.localAI[0] % 90 < 45)
                    {
                        npc.velocity *= 0.25f;
                        npc.rotation += Omega;
                        Omega += 0.04f;
                    }
                    if (npc.localAI[0] % 90 == 45)
                    {
                        Omega = 0;
                        float j = Main.rand.NextFloat(0.15f, 0.4f);
                        if (Main.rand.Next(2) == 0)
                        {
                            j *= -1;
                        }
                        npc.velocity = (player.Center - npc.Center).RotatedBy(j) / num3 * 45f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        for (int i = 0; i < 15; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword8"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = npc.velocity.RotatedByRandom(Math.PI * 2d) / npc.velocity.Length() * Main.rand.NextFloat(11f, 32f);
                            Main.projectile[o].timeLeft = 600;
                        }
                    }
                    if (npc.localAI[0] % 90 > 45)
                    {
                        npc.velocity *= 0.99f;
                        Vector2 v = (player.Center - npc.Center);
                        Vector2 v2 = player.Center - npc.Center - npc.velocity;
                        if (npc.velocity.Length() * npc.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length() / 1.2f)
                        {
                            npc.velocity *= 0.85f;
                        }
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                }
                if (npc.localAI[0] >= 12960 && npc.localAI[0] < 14400)
                {
                    if (npc.localAI[0] % 150 < 45)
                    {
                        npc.velocity *= 0.25f;
                        npc.rotation += Omega;
                        Omega += 0.04f;
                    }
                    if (npc.localAI[0] % 150 == 45)
                    {
                        Omega = 0;
                        npc.velocity = (player.Center + new Vector2(0, -800) - npc.Center) / (player.Center + new Vector2(0, -800) - npc.Center).Length() * 25f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                    if (npc.localAI[0] % 150 > 45)
                    {
                        Vector2 v = (player.Center - npc.Center);
                        Vector2 v2 = player.Center - npc.Center - npc.velocity;
                        if (npc.Center.Y > player.Center.Y + 100f)
                        {
                            if (npc.localAI[0] % 150 > 100)
                            {
                                npc.velocity *= 0.85f;
                            }
                        }
                        else
                        {
                            if (npc.Center.X > player.Center.X && npc.velocity.X > 0)
                            {
                                if (npc.Center.Y < player.Center.Y - 200f)
                                {
                                    npc.velocity.Y += 1f;
                                }
                            }
                            if (npc.Center.X < player.Center.X && npc.velocity.X < 0)
                            {
                                if (npc.Center.Y < player.Center.Y - 200f)
                                {
                                    npc.velocity.Y += 1f;
                                }
                            }
                        }
                        if (npc.velocity.Length() > 3f && npc.localAI[0] % 6 == 1)
                        {
                            Projectile.NewProjectile(vector.X, vector.Y, npc.velocity.X * 0.05f, npc.velocity.Y * 0.05f, base.mod.ProjectileType("CrystalSword9"), 3000, 2f, Main.myPlayer, 0f, 0f);
                        }
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                }
            }
            if (mplayer.KillCrystal <= 2000000 && mplayer.KillCrystal > 1000000)
            {
                if (flag1)
                {
                    npc.localAI[0] = 0;
                    flag1 = false;
                }
                if (npc.localAI[0] % 1000 == 0)
                {
                    //npc.localAI[0] = 3000;
                    npc.localAI[0] = Main.rand.Next(4) * 1000;
                }
                if (npc.localAI[0] >= 0 && npc.localAI[0] < 1000)
                {
                    if (npc.localAI[0] % 60 < 30)
                    {
                        npc.velocity *= 0.25f;
                        npc.rotation += Omega;
                        Omega += 0.06f;
                    }
                    if (npc.localAI[0] % 60 == 30)
                    {
                        Omega = 0;
                        float j = Main.rand.NextFloat(0.5f, 1.3f);
                        if (Main.rand.Next(2) == 0)
                        {
                            j *= -1;
                        }
                        npc.velocity = (player.Center - npc.Center).RotatedBy(j) / num3 * 45f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        for (int i = 0; i < 24; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = npc.velocity.RotatedBy(Math.PI / 12d * (float)i) / npc.velocity.Length() * 0.01f;
                            Main.projectile[o].timeLeft = 1080;
                            Main.projectile[o].scale = 0.25f;
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = npc.velocity.RotatedBy(Math.PI / 3d * (float)i) / npc.velocity.Length() * 0.01f;
                            Main.projectile[o].timeLeft = 1080;
                        }
                    }
                    if (npc.localAI[0] % 60 > 30)
                    {
                        npc.velocity *= 0.99f;
                        Vector2 v = (player.Center - npc.Center);
                        Vector2 v2 = player.Center - npc.Center - npc.velocity;
                        if (npc.velocity.Length() * npc.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                        {
                            npc.velocity *= 0.85f;
                        }
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                }
                if (npc.localAI[0] >= 1000 && npc.localAI[0] < 2000)
                {
                    if (npc.localAI[0] % 60 < 30)
                    {
                        npc.velocity *= 0.25f;
                        npc.rotation += Omega;
                        Omega += 0.04f;
                        if (npc.localAI[0] % 10 == 0)
                        {
                            for (int i = 0; i < 8; i++)
                            {
                                int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                                Main.projectile[o].velocity = npc.velocity.RotatedBy(Math.PI / 4d * (float)i) / npc.velocity.Length() * 10f;
                                Main.projectile[o].timeLeft = 600;
                                //Main.projectile[o].scale = 0.25f;
                            }
                        }
                    }
                    if (npc.localAI[0] % 60 == 30)
                    {
                        Omega = 0;
                        npc.velocity = (player.Center - npc.Center) / num3 * 30f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                    if (npc.localAI[0] % 60 > 30)
                    {
                        npc.velocity *= 0.99f;
                        Vector2 v = (player.Center - npc.Center);
                        Vector2 v2 = player.Center - npc.Center - npc.velocity;
                        if (npc.velocity.Length() * npc.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                        {
                            npc.velocity *= 0.85f;
                        }
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                }
                if (npc.localAI[0] >= 2000 && npc.localAI[0] < 3000)
                {
                    if (npc.localAI[0] % 120 == 0 && !player.dead)
                    {
                        npc.position = player.position + new Vector2(0, -500);
                        npc.velocity *= 0;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                    if (npc.localAI[0] % 120 > 0 && npc.localAI[0] % 120 < 60)
                    {
                        npc.velocity.Y += 1f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        if(npc.localAI[0] % 5 == 0)
                        {
                            Projectile.NewProjectile(vector.X + 600, vector.Y, -2, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector.X - 600, vector.Y, 2, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                    if (npc.localAI[0] % 120 == 60 && !player.dead)
                    {
                        npc.position = player.position + new Vector2(0, 500);
                        npc.velocity *= 0;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                    if (npc.localAI[0] % 120 > 60)
                    {
                        npc.velocity.Y -= 1f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        if (npc.localAI[0] % 5 == 0)
                        {
                            Projectile.NewProjectile(vector.X + 600, vector.Y, -2, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector.X - 600, vector.Y, 2, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                if (npc.localAI[0] >= 3000 && npc.localAI[0] < 4000)
                {
                    if (npc.velocity.Length() > 0.00001)
                    {
                        npc.velocity *= 0.5f;
                    }
                    npc.rotation += Omega;
                    Omega = 0.45f;
                    if (npc.localAI[0] % 7 == 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = npc.velocity.RotatedBy(Math.PI / 1.5 * (float)i + npc.localAI[0] / 15f) / (npc.velocity.Length()) * 1f;
                            Main.projectile[o].timeLeft = 400;
                        }
                    }
                    if (npc.localAI[0] % 120 == 0)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = npc.velocity.RotatedBy(Math.PI / 10d * (float)i) / (npc.velocity.Length()) * 1f;
                            Main.projectile[o].timeLeft = 400;
                        }
                    }
                }
                npc.defense = (int)((player.Center - npc.Center).Length() * 4f);
            }
            if (mplayer.KillCrystal <= 4000000 && mplayer.KillCrystal > 2000000)
            {
                if (npc.localAI[0] % 1000 == 0)
                {
                    //npc.localAI[0] = 3000;
                    npc.localAI[0] = Main.rand.Next(13) * 1000;
                }
                if (flag2)
                {
                    npc.localAI[0] = 0;
                    flag2 = false;
                }
                if (npc.velocity.Length() > 6f)
                {
                    npc.defense = (int)((player.Center - npc.Center).Length() * 12f);
                }
                else;
                {
                    npc.defense = (int)((player.Center - npc.Center).Length() * 40f);
                }
                if (npc.localAI[0] >= 0 && npc.localAI[0] < 1000)
                {
                    if (npc.localAI[0] % 40 == 0)
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            npc.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (npc.localAI[0] % 40 < 20)
                    {
                        npc.velocity *= 0.25f;
                        npc.rotation += Omega;
                        Omega += 0.06f;
                    }
                    if (npc.localAI[0] % 40 == 20)
                    {
                        Omega = 0;
                        float j = Main.rand.NextFloat(0.5f, 1.3f);
                        if (Main.rand.Next(2) == 0)
                        {
                            j *= -1;
                        }
                        npc.velocity = (player.Center - npc.Center).RotatedBy(j) / num3 * 45f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        for (int i = 0; i < 24; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = npc.velocity.RotatedBy(Math.PI / 12d * (float)i) / npc.velocity.Length() * 0.1f;
                            Main.projectile[o].timeLeft = 1080;
                            Main.projectile[o].scale = 0.25f;
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = npc.velocity.RotatedBy(Math.PI / 3d * (float)i) / npc.velocity.Length() * 0.1f;
                            Main.projectile[o].timeLeft = 1080;
                        }
                    }
                    if (npc.localAI[0] % 40 > 20)
                    {
                        npc.velocity *= 0.99f;
                        Vector2 v = (player.Center - npc.Center);
                        Vector2 v2 = player.Center - npc.Center - npc.velocity;
                        if (npc.velocity.Length() * npc.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                        {
                            npc.velocity *= 0.85f;
                        }
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                }
                if (npc.localAI[0] >= 1000 && npc.localAI[0] < 2000)
                {
                    if (npc.localAI[0] % 60 == 0)
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            npc.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (npc.localAI[0] % 60 < 30)
                    {
                        npc.velocity *= 0.25f;
                        npc.rotation += Omega;
                        Omega += 0.04f;
                        if (npc.localAI[0] % 10 == 0)
                        {
                            for (int i = 0; i < 14; i++)
                            {
                                int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                                Main.projectile[o].velocity = npc.velocity.RotatedBy(Math.PI / 7d * (float)i) / npc.velocity.Length() * 10f;
                                Main.projectile[o].timeLeft = 600;
                                //Main.projectile[o].scale = 0.25f;
                            }
                        }
                    }
                    if (npc.localAI[0] % 60 == 30)
                    {
                        Omega = 0;
                        npc.velocity = (player.Center - npc.Center) / num3 * 40f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                    if (npc.localAI[0] % 60 > 30)
                    {
                        npc.velocity *= 0.99f;
                        Vector2 v = (player.Center - npc.Center);
                        Vector2 v2 = player.Center - npc.Center - npc.velocity;
                        if (npc.velocity.Length() * npc.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                        {
                            npc.velocity *= 0.85f;
                        }
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                }
                if (npc.localAI[0] >= 2000 && npc.localAI[0] < 3000)
                {
                    if (npc.localAI[0] % 120 == 0)
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            npc.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (npc.localAI[0] % 120 == 0 && !player.dead)
                    {
                        npc.position = player.position + new Vector2(0, -500);
                        npc.velocity *= 0;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                    if (npc.localAI[0] % 120 > 0 && npc.localAI[0] % 120 < 60)
                    {
                        npc.velocity.Y += 1f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        if (npc.localAI[0] % 5 == 0)
                        {
                            Projectile.NewProjectile(vector.X + 600, vector.Y, -2, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector.X - 600, vector.Y, 2, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                    if (npc.localAI[0] % 120 == 60 && !player.dead)
                    {
                        npc.position = player.position + new Vector2(0, 500);
                        npc.velocity *= 0;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                    if (npc.localAI[0] % 120 > 60)
                    {
                        npc.velocity.Y -= 1f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        if (npc.localAI[0] % 5 == 0)
                        {
                            Projectile.NewProjectile(vector.X + 600, vector.Y, -2, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector.X - 600, vector.Y, 2, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                if (npc.localAI[0] >= 3000 && npc.localAI[0] < 4000)
                {
                    if (npc.localAI[0] % 40 == 0)
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            npc.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (npc.velocity.Length() > 0.00001)
                    {
                        npc.velocity *= 0.5f;
                    }
                    npc.rotation += Omega;
                    Omega = 0.45f;
                    if (npc.localAI[0] % 7 == 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = npc.velocity.RotatedBy(Math.PI / 1.5 * (float)i + npc.localAI[0] / 15f) / (npc.velocity.Length()) * 15f;
                            Main.projectile[o].timeLeft = 400;
                        }
                    }
                    if (npc.localAI[0] % 120 == 0)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = npc.velocity.RotatedBy(Math.PI / 10d * (float)i) / (npc.velocity.Length()) * 1f;
                            Main.projectile[o].timeLeft = 400;
                        }
                    }
                }
                if (npc.localAI[0] >= 4000 && npc.localAI[0] < 5000)
                {
                    if (npc.localAI[0] % 60 == 0)
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            npc.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (npc.localAI[0] % 60 < 30)
                    {
                        npc.velocity *= 0.25f;
                        npc.rotation += Omega;
                        Omega += 0.04f;
                    }
                    if (npc.localAI[0] % 60 == 30)
                    {
                        Omega = 0;
                        npc.velocity = (player.Center - npc.Center) / num3 * 30f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                    if (npc.localAI[0] % 10 == 0)
                    {
                        if (npc.localAI[0] % 5 == 0)
                        {
                            Projectile.NewProjectile(player.Center.X + 300, player.Center.Y, -2, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(player.Center.X - 300, player.Center.Y, 2, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                    if (npc.localAI[0] % 60 > 30)
                    {
                        npc.velocity *= 0.99f;
                        Vector2 v = (player.Center - npc.Center);
                        Vector2 v2 = player.Center - npc.Center - npc.velocity;
                        if (npc.velocity.Length() * npc.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                        {
                            npc.velocity *= 0.85f;
                        }
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                }
                if (npc.localAI[0] >= 5000 && npc.localAI[0] < 6000)
                {
                    if (npc.localAI[0] % 40 == 0)
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            npc.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (npc.velocity.Length() > 0.00001)
                    {
                        npc.velocity *= 0.5f;
                    }
                    npc.rotation += Omega;
                    Omega = 0.45f;
                    if (npc.localAI[0] % 8 == 4)
                    {
                        Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword"), 3000, 2f, Main.myPlayer, (float)Math.PI * Main.rand.NextFloat(0, 2f), 0f);
                    }
                    if (npc.localAI[0] % 8 == 0)
                    {
                        Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword3"), 3000, 2f, Main.myPlayer, (float)Math.PI * Main.rand.NextFloat(0, 2f), 0f);
                    }
                    if (npc.localAI[0] % 120 == 0)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = npc.velocity.RotatedBy(Math.PI / 10d * (float)i) / (npc.velocity.Length()) * 1f;
                            Main.projectile[o].timeLeft = 600;
                        }
                    }
                }
                if (npc.localAI[0] >= 6000 && npc.localAI[0] < 7000)
                {
                    if (npc.localAI[0] % 40 == 0)
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            npc.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    npc.velocity *= 0.5f;
                    npc.rotation += Omega;
                    Omega = 0.1f;
                    if (npc.localAI[0] % 15 == 4)
                    {
                        Projectile.NewProjectile(player.Center.X + Main.rand.Next(-600, 600), player.Center.Y - 800, Main.rand.Next(-600, 600) / 100f, 20f, base.mod.ProjectileType("CrystalSword2"), 3000, 2f, Main.myPlayer, (float)Math.PI * 0.17f, 0f);
                        Projectile.NewProjectile(player.Center.X + Main.rand.Next(-600, 600), player.Center.Y - 800, Main.rand.Next(-600, 600) / 100f, 20f, base.mod.ProjectileType("CrystalSword5"), 3000, 2f, Main.myPlayer, -(float)Math.PI * 0.17f, 0f);
                    }
                }
                if (npc.localAI[0] >= 7000 && npc.localAI[0] < 8000)
                {
                    if (npc.localAI[0] % 120 == 0)
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            npc.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (npc.localAI[0] % 120 == 0)
                    {
                        npc.velocity = (player.Center - npc.Center) / num3 * 0.4f;
                        for (int i = -10; i < 10; i++)
                        {
                            if (i > 0)
                            {
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -npc.velocity.Y * i * 11, npc.velocity.X * i * 11, base.mod.ProjectileType("CrystalSword4"), 3000, 2f, Main.myPlayer, -1, 0f);
                            }
                            if (i < 0)
                            {
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -npc.velocity.Y * i * 11, npc.velocity.X * i * 11, base.mod.ProjectileType("CrystalSword4"), 3000, 2f, Main.myPlayer, 1, 0f);
                            }
                        }
                    }
                    if (npc.localAI[0] % 120 > 0)
                    {
                        Vector2 v = (player.Center - npc.Center);
                        Vector2 v2 = player.Center - npc.Center - npc.velocity;
                        if (npc.velocity.Length() * npc.velocity.Length() + v.Length() * v.Length() < (v2.Length() * v2.Length()))
                        {
                            npc.velocity *= 0.96f;
                        }
                        else
                        {
                            npc.velocity *= 1.05f;
                        }
                    }
                    npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                }
                if (npc.localAI[0] >= 8000 && npc.localAI[0] < 9000)
                {
                    if (npc.localAI[0] >= 8000 && npc.localAI[0] < 8166)
                    {
                        npc.velocity *= 0.9f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        Vector2 v = (player.Center - npc.Center);
                        npc.velocity += v / v.Length() * 0.05f;
                        if (npc.localAI[0] == 8000)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                num1[i] = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            }
                        }
                        for (int i = 0; i < 12; i++)
                        {
                            Main.projectile[num1[i]].position = npc.Center + npc.velocity.RotatedBy(Math.PI / 6d * (float)i) / npc.velocity.Length() * (npc.localAI[0] - 7999);
                            Main.projectile[num1[i]].velocity = npc.velocity.RotatedBy(Math.PI / 6d * (float)i) / npc.velocity.Length() * 0.01f;
                            Main.projectile[num1[i]].timeLeft = 240;
                            Main.projectile[num1[i]].scale = (npc.localAI[0] - 7999) / 333f;
                        }
                    }
                    if (npc.localAI[0] >= 8500 && npc.localAI[0] < 8666)
                    {
                        npc.velocity *= 0.9f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        Vector2 v = (player.Center - npc.Center);
                        npc.velocity += v / v.Length() * 0.05f;
                        if (npc.localAI[0] == 8500)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                num1[i] = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            }
                        }
                        for (int i = 0; i < 12; i++)
                        {
                            Main.projectile[num1[i]].position = npc.Center + npc.velocity.RotatedBy(Math.PI / 6d * (float)i) / npc.velocity.Length() * (npc.localAI[0] - 8499);
                            Main.projectile[num1[i]].velocity = npc.velocity.RotatedBy(Math.PI / 6d * (float)i) / npc.velocity.Length() * 0.01f;
                            Main.projectile[num1[i]].timeLeft = 240;
                            Main.projectile[num1[i]].scale = (npc.localAI[0] - 8499) / 333f;
                        }
                    }
                    if (npc.localAI[0] >= 8166 && npc.localAI[0] < 8500)
                    {
                        if (npc.localAI[0] % 40 == 0)
                        {
                            if (Main.rand.Next(3) == 0)
                            {
                                npc.localAI[0] = 8999;
                            }
                        }
                        if (npc.localAI[0] % 40 < 20)
                        {
                            npc.velocity *= 0.5f;
                            npc.rotation += Omega;
                            Omega += 0.02f;
                        }
                        if (npc.localAI[0] % 40 == 20)
                        {
                            Omega = 0;
                            npc.velocity = (player.Center - npc.Center) / num3 * 45f;
                            npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        }
                        if (npc.localAI[0] % 40 > 20)
                        {
                            npc.velocity *= 0.99f;
                            Vector2 v = (player.Center - npc.Center);
                            Vector2 v2 = player.Center - npc.Center - npc.velocity;
                            if (npc.velocity.Length() * npc.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                            {
                                npc.velocity *= 0.95f;
                            }
                            npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        }
                        if (npc.localAI[0] != 8499)
                        {
                            Rota += Omega2;
                            if (Omega2 < 0.03f)
                            {
                                Omega2 += 0.0003f;
                            }
                            for (int i = 0; i < 12; i++)
                            {
                                Main.projectile[num1[i]].position = npc.Center + npc.velocity.RotatedBy(Math.PI / 6d * (float)i + Rota) / npc.velocity.Length() * 240f;
                                Main.projectile[num1[i]].velocity = npc.velocity.RotatedBy(Math.PI / 6d * (float)i + Rota) / npc.velocity.Length() * 0.01f;
                                Main.projectile[num1[i]].timeLeft = 240;
                            }
                        }
                        if (npc.localAI[0] == 8499)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                Main.projectile[num1[i]].position = npc.Center + npc.velocity.RotatedBy(Math.PI * (float)i / 6d + Rota) / npc.velocity.Length() * 240f;
                                Main.projectile[num1[i]].velocity = npc.velocity.RotatedBy(Math.PI * (float)i / 6d + Rota) / npc.velocity.Length() * 2f;
                                Main.projectile[num1[i]].timeLeft = 240;
                                num1[i] = 0;
                            }
                            Rota = 0;
                            Omega2 = 0;
                        }
                    }
                    if (npc.localAI[0] >= 8666 && npc.localAI[0] < 9000)
                    {
                        if (npc.localAI[0] % 40 == 0)
                        {
                            if (Main.rand.Next(3) == 0)
                            {
                                npc.localAI[0] = 8999;
                            }
                        }
                        if (npc.localAI[0] % 40 < 20)
                        {
                            npc.velocity *= 0.5f;
                            npc.rotation += Omega;
                            Omega += 0.02f;
                        }
                        if (npc.localAI[0] % 40 == 20)
                        {
                            Omega = 0;
                            npc.velocity = (player.Center - npc.Center) / num3 * 45f;
                            npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        }
                        if (npc.localAI[0] % 40 > 20)
                        {
                            npc.velocity *= 0.99f;
                            Vector2 v = (player.Center - npc.Center);
                            Vector2 v2 = player.Center - npc.Center - npc.velocity;
                            if (npc.velocity.Length() * npc.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                            {
                                npc.velocity *= 0.95f;
                            }
                            npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        }
                        if (npc.localAI[0] != 8999)
                        {
                            Rota += Omega2;
                            if (Omega2 < 0.03f)
                            {
                                Omega2 += 0.0003f;
                            }
                            for (int i = 0; i < 12; i++)
                            {
                                Main.projectile[num1[i]].position = npc.Center + npc.velocity.RotatedBy(Math.PI / 6d * (float)i + Rota) / npc.velocity.Length() * 240f;
                                Main.projectile[num1[i]].velocity = npc.velocity.RotatedBy(Math.PI / 6d * (float)i + Rota) / npc.velocity.Length() * 0.01f;
                                Main.projectile[num1[i]].timeLeft = 240;
                            }
                        }
                        if (npc.localAI[0] == 8999)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                Main.projectile[num1[i]].position = npc.Center + npc.velocity.RotatedBy(Math.PI * (float)i / 6d + Rota) / npc.velocity.Length() * 240f;
                                Main.projectile[num1[i]].velocity = npc.velocity.RotatedBy(Math.PI * (float)i / 6d + Rota) / npc.velocity.Length() * 2f;
                                Main.projectile[num1[i]].timeLeft = 240;
                                num1[i] = 0;
                            }
                            Rota = 0;
                            Omega2 = 0;
                        }
                    }
                }
                if (npc.localAI[0] >= 9000 && npc.localAI[0] < 10000)
                {
                    if (npc.localAI[0] < 9030)
                    {
                        npc.velocity *= 0.25f;
                        npc.rotation += Omega;
                        Omega += 0.04f;
                    }
                    if (npc.localAI[0] == 9030)
                    {
                        Omega = 0;
                        npc.velocity = (player.Center + new Vector2(0, -400f) - npc.Center) / num3 * 45f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                    if (npc.localAI[0] > 9030 && npc.localAI[0] < 9060)
                    {
                        npc.velocity *= 0.99f;
                        Vector2 v = (player.Center + new Vector2(0, -200f) - npc.Center);
                        Vector2 v2 = player.Center + new Vector2(0, -200f) - npc.Center - npc.velocity;
                        if (npc.velocity.Length() * npc.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                        {
                            npc.velocity *= 0.85f;
                        }
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                    npc.velocity *= 0.5f;
                    npc.rotation += Omega;
                    Omega = 0.1f;
                    if (npc.localAI[0] % 60 == 0)
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            npc.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (npc.localAI[0] % 60 == 30)
                    {
                        for (int i = -20; i < 20; i++)
                        {
                            Projectile.NewProjectile(npc.Center.X + i * 120, npc.Center.Y - 800, 0, 7f, base.mod.ProjectileType("CrystalSword2"), 3000, 2f, Main.myPlayer, -(float)Math.PI * 0.17f, 0f);
                        }
                    }
                    if (npc.localAI[0] % 60 == 0)
                    {
                        for (int i = -20; i < 20; i++)
                        {
                            Projectile.NewProjectile(npc.Center.X + i * 120 + 60, npc.Center.Y - 800, 0, 7f, base.mod.ProjectileType("CrystalSword5"), 3000, 2f, Main.myPlayer, -(float)Math.PI * 0.17f, 0f);
                        }
                    }
                }
                if (npc.localAI[0] >= 10000 && npc.localAI[0] < 11000)
                {
                    if (npc.localAI[0] % 30 == 0)
                    {
                        if (Main.rand.Next(5) == 0)
                        {
                            npc.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (npc.localAI[0] % 30 < 15)
                    {
                        npc.velocity *= 0.25f;
                        npc.rotation += Omega;
                        Omega += 0.06f;
                    }
                    if (npc.localAI[0] % 30 == 15)
                    {
                        Omega = 0;
                        float j = Main.rand.NextFloat(0.5f, 1.3f);
                        if (Main.rand.Next(2) == 0)
                        {
                            j *= -1;
                        }
                        npc.velocity = (player.Center - npc.Center).RotatedBy(j) / num3 * 45f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        for (int i = 0; i < 6; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = npc.velocity.RotatedBy(Math.PI / 3d * (float)i) / npc.velocity.Length() * 0.01f;
                            Main.projectile[o].timeLeft = 1080;
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword7"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = npc.velocity.RotatedBy(Math.PI / 3d * (float)i + Math.PI / 6d) / npc.velocity.Length() * 1f;
                            Main.projectile[o].timeLeft = 1080;
                        }
                    }
                    if (npc.localAI[0] % 30 > 15)
                    {
                        npc.velocity *= 0.99f;
                        Vector2 v = (player.Center - npc.Center);
                        Vector2 v2 = player.Center - npc.Center - npc.velocity;
                        if (npc.velocity.Length() * npc.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                        {
                            npc.velocity *= 0.85f;
                        }
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                }
                if (npc.localAI[0] >= 11000 && npc.localAI[0] < 12000)
                {
                    if (npc.localAI[0] % 90 == 0)
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            npc.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (npc.localAI[0] % 90 < 45)
                    {
                        npc.velocity *= 0.25f;
                        npc.rotation += Omega;
                        Omega += 0.04f;
                    }
                    if (npc.localAI[0] % 90 == 45)
                    {
                        Omega = 0;
                        float j = Main.rand.NextFloat(0.15f, 0.4f);
                        if (Main.rand.Next(2) == 0)
                        {
                            j *= -1;
                        }
                        npc.velocity = (player.Center - npc.Center).RotatedBy(j) / num3 * 45f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        for (int i = 0; i < 15; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.mod.ProjectileType("CrystalSword8"), 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = npc.velocity.RotatedByRandom(Math.PI * 2d) / npc.velocity.Length() * Main.rand.NextFloat(11f, 32f);
                            Main.projectile[o].timeLeft = 600;
                        }
                    }
                    if (npc.localAI[0] % 90 > 45)
                    {
                        npc.velocity *= 0.99f;
                        Vector2 v = (player.Center - npc.Center);
                        Vector2 v2 = player.Center - npc.Center - npc.velocity;
                        if (npc.velocity.Length() * npc.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length() / 1.2f)
                        {
                            npc.velocity *= 0.85f;
                        }
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                }
                if (npc.localAI[0] >= 12000 && npc.localAI[0] < 13000)
                {
                    if (npc.localAI[0] % 150 == 0)
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            npc.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (npc.localAI[0] % 150 < 45)
                    {
                        npc.velocity *= 0.25f;
                        npc.rotation += Omega;
                        Omega += 0.04f;
                    }
                    if (npc.localAI[0] % 150 == 45)
                    {
                        Omega = 0;
                        npc.velocity = (player.Center + new Vector2(0, -800) - npc.Center) / (player.Center + new Vector2(0, -800) - npc.Center).Length() * 25f;
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                    if (npc.localAI[0] % 150 > 45)
                    {
                        Vector2 v = (player.Center - npc.Center);
                        Vector2 v2 = player.Center - npc.Center - npc.velocity;
                        if (npc.Center.Y > player.Center.Y + 100f)
                        {
                            if (npc.localAI[0] % 150 > 100)
                            {
                                npc.velocity *= 0.85f;
                            }
                        }
                        else
                        {
                            if (npc.Center.X > player.Center.X && npc.velocity.X > 0)
                            {
                                if (npc.Center.Y < player.Center.Y - 200f)
                                {
                                    npc.velocity.Y += 1f;
                                }
                            }
                            if (npc.Center.X < player.Center.X && npc.velocity.X < 0)
                            {
                                if (npc.Center.Y < player.Center.Y - 200f)
                                {
                                    npc.velocity.Y += 1f;
                                }
                            }
                        }
                        if (npc.velocity.Length() > 3f && npc.localAI[0] % 6 == 1)
                        {
                            Projectile.NewProjectile(vector.X, vector.Y, npc.velocity.X * 0.05f, npc.velocity.Y * 0.05f, base.mod.ProjectileType("CrystalSword9"), 3000, 2f, Main.myPlayer, 0f, 0f);
                        }
                        npc.rotation = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                    }
                }
            }
            if (!player.active || player.dead)
            {
                if(!canDespawn)
                {
                    canDespawn = true;
                    Color messageColor = new Color(0, 150, 255);
                    Main.NewText(Language.GetTextValue("得分:") + (mplayer.KillCrystal / 10000).ToString(), messageColor);
                }
                base.npc.TargetClosest(false);
                player = Main.player[base.npc.target];
                if (!player.active || player.dead)
                {
                    base.npc.velocity = new Vector2(0f, 10f);
                    if (base.npc.timeLeft > 150)
                    {
                        base.npc.timeLeft = 150;
                    }
                    return;
                }
            }
            else
            {
                canDespawn = false;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = Main.npcTexture[base.npc.type];
            Main.spriteBatch.Draw(texture, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), npc.frame, npc.GetAlpha(drawColor), npc.rotation, new Vector2(110, 110), npc.scale, SpriteEffects.None, 0f);
            return false;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 27, 1f, 0f);
            if (Main.rand.Next(3) == 1)
            {
                for (int j = 0; j < 2; j++)
                {
                    int u = Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, mod.DustType("Crystal"), 0, 0, 0, default(Color), 1f);
                    Main.dust[u].noGravity = false;
                    Main.dust[u].fadeIn = 1f + (float)Main.rand.NextFloat(-0.5f, 0.5f) * 0.1f;
                }
            }
            if (base.npc.life <= 0)
            {
                Color messageColor = new Color(0, 150, 255);
                Main.NewText(Language.GetTextValue("得分:400"), messageColor);
                base.npc.position.X = base.npc.position.X + (float)(base.npc.width / 2);
                base.npc.position.Y = base.npc.position.Y + (float)(base.npc.height / 2);
                base.npc.position.X = base.npc.position.X - (float)(base.npc.width / 2);
                base.npc.position.Y = base.npc.position.Y - (float)(base.npc.height / 2);
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/冰洲石剑1"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/冰洲石剑2"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/冰洲石剑3"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/冰洲石剑2"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/冰洲石剑3"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/冰洲石剑4"), 1f);
            }
        }
        private bool canDespawn;
        public override bool CheckActive()
        {
            return this.canDespawn;
        }
        public override void NPCLoot()
        {
            if (!MythWorld.downedBZSJ)
            {
                MythWorld.downedBZSJ = true;
            }
            if (!Main.expertMode)
            {
                int type = 0;
                switch (Main.rand.Next(1, 8))
                {
                    case 1:
                        type = base.mod.ItemType("CrystalBall");
                        break;
                    case 2:
                        type = base.mod.ItemType("CrystalBlade");
                        break;
                    case 3:
                        type = base.mod.ItemType("CrystalBow");
                        break;
                    case 4:
                        type = base.mod.ItemType("CrystalEagle");
                        break;
                    case 5:
                        type = base.mod.ItemType("CrystalRose");
                        break;
                    case 6:
                        type = base.mod.ItemType("CrystalSwordStaff");
                        break;
                    case 7:
                        type = base.mod.ItemType("CrystalThrownKnife");
                        break;
                }
                Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, type, 1, false, 0, false, false);
            }
            else
            {
                Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, mod.ItemType("CrystalSwordTreasureBag"), 1, false, 0, false, false);
            }
            if (Main.rand.Next(10) == 2)
            {
                Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, mod.ItemType("CrystalSwordPlatfo"), 1, false, 0, false, false);
            }
        }
    }
}
