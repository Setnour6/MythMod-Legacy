using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria;
using Terraria.GameContent;
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
            // base.DisplayName.SetDefault("冰洲石剑EX");
            Main.npcFrameCount[base.NPC.type] = 1;
        }
        private int m = 0;
        private bool k;
        private bool X = true;
        private Vector2 vg = new Vector2(0, -250f);
        private int[] num1 = new int[12];
        public override void SetDefaults()
        {
            base.NPC.damage = 3000;
            base.NPC.width = 40;
            base.NPC.height = 40;
            base.NPC.defense = 150;
            base.NPC.lifeMax = 99999999;
            for (int i = 0; i < base.NPC.buffImmune.Length; i++)
            {
                base.NPC.buffImmune[i] = true;
            }
            base.NPC.knockBackResist = 0f;
            base.NPC.value = (float)Item.buyPrice(0, 18, 0, 0);
            base.NPC.color = new Color(0, 0, 0, 0);
            base.NPC.alpha = 0;
            base.NPC.boss = true;
            base.NPC.lavaImmune = true;
            base.NPC.noGravity = true;
            base.NPC.noTileCollide = true;
            base.NPC.aiStyle = -1;
            this.AIType = -1;
            NPCID.Sets.TrailCacheLength[base.NPC.type] = 4;
            NPCID.Sets.TrailingMode[base.NPC.type] = 0;
            this.Music = Mod.GetSoundSlot((Terraria.ModLoader.SoundType)51, "Sounds/Music/Triodust-Hope");
        }
        private float Omega = 0;
        private float Omega2 = 0;
        private float Rota = 0;
        private bool flag1 = true;
        private bool flag2 = true;
        public override void BossHeadRotation(ref float rotation)
        {
            rotation = NPC.rotation + (float)Math.PI / 4f;
        }
        public override void AI()
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.KillCrystal = NPC.lifeMax - NPC.life;
            base.NPC.lifeMax = 4000000;
            if (m == 0)
            {
                NPC.life = 4000000;
                m = 1;
            }
            base.NPC.TargetClosest(false);
            Player player = Main.player[base.NPC.target];
            bool expertMode = Main.expertMode;
            bool zoneUnderworldHeight = player.ZoneUnderworldHeight;
            Vector2 vector = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
            Vector2 center = base.NPC.Center;
            float num = player.Center.X - vector.X;
            float num2 = player.Center.Y - vector.Y;
            float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
            NPC.localAI[0] += 1;
            if (mplayer.KillCrystal <= 1000000)
            {
                NPC.defense = (int)((player.Center - NPC.Center).Length() * 8f);
                if (NPC.localAI[0] % 1440 == 0)
                {
                    //npc.localAI[0] = 12960;
                    NPC.localAI[0] = Main.rand.Next(10) * 1440;
                }
                if (NPC.localAI[0] < 1440)
                {
                    if (NPC.localAI[0] % 60 < 30)
                    {
                        NPC.velocity *= 0.25f;
                        NPC.rotation += Omega;
                        Omega += 0.04f;
                    }
                    if (NPC.localAI[0] % 60 == 30)
                    {
                        Omega = 0;
                        NPC.velocity = (player.Center - NPC.Center) / num3 * 30f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                    if (NPC.localAI[0] % 60 > 30)
                    {
                        NPC.velocity *= 0.99f;
                        Vector2 v = (player.Center - NPC.Center);
                        Vector2 v2 = player.Center - NPC.Center - NPC.velocity;
                        if (NPC.velocity.Length() * NPC.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                        {
                            NPC.velocity *= 0.85f;
                        }
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                }
                if (NPC.localAI[0] >= 1440 && NPC.localAI[0] < 2880)
                {
                    if (NPC.velocity.Length() > 0.00001)
                    {
                        NPC.velocity *= 0.5f;
                    }
                    NPC.rotation += Omega;
                    Omega = 0.45f;
                    if (NPC.localAI[0] % 8 == 4)
                    {
                        Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword").Type, 3000, 2f, Main.myPlayer, (float)Math.PI * Main.rand.NextFloat(0, 2f), 0f);
                    }
                    if (NPC.localAI[0] % 8 == 0)
                    {
                        Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword3").Type, 3000, 2f, Main.myPlayer, (float)Math.PI * Main.rand.NextFloat(0, 2f), 0f);
                    }
                    if (NPC.localAI[0] % 120 == 0)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = NPC.velocity.RotatedBy(Math.PI / 10d * (float)i) / (NPC.velocity.Length()) * 1f;
                            Main.projectile[o].timeLeft = 600;
                        }
                    }
                }
                if (NPC.localAI[0] >= 2880 && NPC.localAI[0] < 4320)
                {
                    NPC.velocity *= 0.5f;
                    NPC.rotation += Omega;
                    Omega = 0.1f;
                    if (NPC.localAI[0] % 15 == 4)
                    {
                        Projectile.NewProjectile(player.Center.X + Main.rand.Next(-600, 600), player.Center.Y - 800, Main.rand.Next(-600, 600) / 100f, 20f, base.Mod.Find<ModProjectile>("CrystalSword2").Type, 3000, 2f, Main.myPlayer, (float)Math.PI * 0.17f, 0f);
                        Projectile.NewProjectile(player.Center.X + Main.rand.Next(-600, 600), player.Center.Y - 800, Main.rand.Next(-600, 600) / 100f, 20f, base.Mod.Find<ModProjectile>("CrystalSword5").Type, 3000, 2f, Main.myPlayer, -(float)Math.PI * 0.17f, 0f);
                    }
                }
                if (NPC.localAI[0] >= 4320 && NPC.localAI[0] < 5760)
                {
                    if (NPC.localAI[0] % 120 == 0)
                    {
                        NPC.velocity = (player.Center - NPC.Center) / num3 * 0.4f;
                        for (int i = -10; i < 10; i++)
                        {
                            if (i > 0)
                            {
                                Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, -NPC.velocity.Y * i * 11, NPC.velocity.X * i * 11, base.Mod.Find<ModProjectile>("CrystalSword4").Type, 3000, 2f, Main.myPlayer, -1, 0f);
                            }
                            if (i < 0)
                            {
                                Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, -NPC.velocity.Y * i * 11, NPC.velocity.X * i * 11, base.Mod.Find<ModProjectile>("CrystalSword4").Type, 3000, 2f, Main.myPlayer, 1, 0f);
                            }
                        }
                    }
                    if (NPC.localAI[0] % 120 > 0)
                    {
                        Vector2 v = (player.Center - NPC.Center);
                        Vector2 v2 = player.Center - NPC.Center - NPC.velocity;
                        if (NPC.velocity.Length() * NPC.velocity.Length() + v.Length() * v.Length() < (v2.Length() * v2.Length()))
                        {
                            NPC.velocity *= 0.96f;
                        }
                        else
                        {
                            NPC.velocity *= 1.05f;
                        }
                    }
                    NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                }
                if (NPC.localAI[0] >= 5760 && NPC.localAI[0] < 7200)
                {
                    if (NPC.localAI[0] == 5760)
                    {
                        vg = player.Center + new Vector2(0, -500f);
                    }
                    Vector2 v2g = new Vector2(0, 200).RotatedBy(NPC.localAI[0] / 15d);
                    Vector2 v3g = vg + new Vector2(v2g.X, v2g.Y / 4f);
                    if (NPC.localAI[0] >= 5760 && NPC.localAI[0] < 7200)
                    {
                        if (NPC.localAI[0] >= 5760 && NPC.localAI[0] < 6240)
                        {
                            NPC.velocity += (v3g - NPC.Center) / 60f;
                            NPC.velocity *= 0.98f;
                            NPC.rotation = (float)Math.PI / 2f + NPC.velocity.X / 48f;
                            int numl = Dust.NewDust(NPC.Center + new Vector2(0, 110).RotatedBy(NPC.rotation - (float)Math.PI / 2f), 1, 1, 91, 0, 0, 0, default(Color), 1.8f);
                            Main.dust[numl].velocity *= 0;
                            Main.dust[numl].noGravity = true;
                            if (NPC.localAI[0] == 6239)
                            {
                                int yu = Projectile.NewProjectile((NPC.Center + new Vector2(0, 110).RotatedBy(NPC.rotation - (float)Math.PI / 2f)).X, (NPC.Center + new Vector2(0, 110).RotatedBy(NPC.rotation - (float)Math.PI / 2f)).Y, NPC.velocity.X, NPC.velocity.Y, base.Mod.Find<ModProjectile>("CrystalSwordOvalEffect").Type, 0, 0, Main.myPlayer, vg.X, vg.Y + 100f);
                                Main.projectile[yu].timeLeft = 6000;
                            }
                        }
                        if (NPC.localAI[0] >= 6240 && NPC.localAI[0] < 7200)
                        {
                            if (NPC.localAI[0] % 120 < 60)
                            {
                                NPC.velocity *= 0.5f;
                                NPC.rotation += Omega;
                                Omega += 0.02f;
                                if (NPC.localAI[0] % 120 == 10)
                                {
                                    Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword").Type, 3000, 2f, Main.myPlayer, (float)Math.PI * 0.17f, 0f);
                                    Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword").Type, 3000, 2f, Main.myPlayer, -(float)Math.PI * 0.17f, 0f);
                                }
                            }
                            if (NPC.localAI[0] % 120 == 60)
                            {
                                Omega = 0;
                                NPC.velocity = (player.Center - NPC.Center) / num3 * 45f;
                                NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                            }
                            if (NPC.localAI[0] % 120 > 60)
                            {
                                NPC.velocity *= 0.99f;
                                Vector2 v = (player.Center - NPC.Center);
                                Vector2 v2 = player.Center - NPC.Center - NPC.velocity;
                                if (NPC.velocity.Length() * NPC.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                                {
                                    NPC.velocity *= 0.95f;
                                }
                                NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                            }
                        }
                    }
                }
                if (NPC.localAI[0] >= 7200 && NPC.localAI[0] < 8640)
                {
                    if (NPC.localAI[0] >= 7200 && NPC.localAI[0] < 7440)
                    {
                        NPC.velocity *= 0.9f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        Vector2 v = (player.Center - NPC.Center);
                        NPC.velocity += v / v.Length() * 0.05f;
                        if (NPC.localAI[0] == 7200)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                num1[i] = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            }
                        }
                        for (int i = 0; i < 12; i++)
                        {
                            Main.projectile[num1[i]].position = NPC.Center + NPC.velocity.RotatedBy(Math.PI / 6d * (float)i) / NPC.velocity.Length() * (NPC.localAI[0] - 7199);
                            Main.projectile[num1[i]].velocity = NPC.velocity.RotatedBy(Math.PI / 6d * (float)i) / NPC.velocity.Length() * 0.01f;
                            Main.projectile[num1[i]].timeLeft = 240;
                            Main.projectile[num1[i]].scale = (NPC.localAI[0] - 7199) / 480f;
                        }
                    }
                    if (NPC.localAI[0] >= 7920 && NPC.localAI[0] < 8160)
                    {
                        NPC.velocity *= 0.9f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        Vector2 v = (player.Center - NPC.Center);
                        NPC.velocity += v / v.Length() * 0.05f;
                        if (NPC.localAI[0] == 7920)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                num1[i] = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            }
                        }
                        for (int i = 0; i < 12; i++)
                        {
                            Main.projectile[num1[i]].position = NPC.Center + NPC.velocity.RotatedBy(Math.PI / 6d * (float)i) / NPC.velocity.Length() * (NPC.localAI[0] - 7919);
                            Main.projectile[num1[i]].velocity = NPC.velocity.RotatedBy(Math.PI / 6d * (float)i) / NPC.velocity.Length() * 0.01f;
                            Main.projectile[num1[i]].timeLeft = 240;
                            Main.projectile[num1[i]].scale = (NPC.localAI[0] - 7919) / 480f;
                        }
                    }
                    if (NPC.localAI[0] >= 7440 && NPC.localAI[0] < 7920)
                    {
                        if (NPC.localAI[0] % 120 < 60)
                        {
                            NPC.velocity *= 0.5f;
                            NPC.rotation += Omega;
                            Omega += 0.02f;
                        }
                        if (NPC.localAI[0] % 120 == 60)
                        {
                            Omega = 0;
                            NPC.velocity = (player.Center - NPC.Center) / num3 * 45f;
                            NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        }
                        if (NPC.localAI[0] % 120 > 60)
                        {
                            NPC.velocity *= 0.99f;
                            Vector2 v = (player.Center - NPC.Center);
                            Vector2 v2 = player.Center - NPC.Center - NPC.velocity;
                            if (NPC.velocity.Length() * NPC.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                            {
                                NPC.velocity *= 0.95f;
                            }
                            NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        }
                        if (NPC.localAI[0] != 7919)
                        {
                            Rota += Omega2;
                            if (Omega2 < 0.03f)
                            {
                                Omega2 += 0.0003f;
                            }
                            for (int i = 0; i < 12; i++)
                            {
                                Main.projectile[num1[i]].position = NPC.Center + NPC.velocity.RotatedBy(Math.PI / 6d * (float)i + Rota) / NPC.velocity.Length() * 240f;
                                Main.projectile[num1[i]].velocity = NPC.velocity.RotatedBy(Math.PI / 6d * (float)i + Rota) / NPC.velocity.Length() * 0.01f;
                                Main.projectile[num1[i]].timeLeft = 240;
                            }
                        }
                        if (NPC.localAI[0] == 7919)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                Main.projectile[num1[i]].position = NPC.Center + NPC.velocity.RotatedBy(Math.PI * (float)i / 6d + Rota) / NPC.velocity.Length() * 240f;
                                Main.projectile[num1[i]].velocity = NPC.velocity.RotatedBy(Math.PI * (float)i / 6d + Rota) / NPC.velocity.Length() * 2f;
                                Main.projectile[num1[i]].timeLeft = 240;
                                num1[i] = 0;
                            }
                            Rota = 0;
                            Omega2 = 0;
                        }
                    }
                    if (NPC.localAI[0] >= 8160 && NPC.localAI[0] < 8640)
                    {
                        if (NPC.localAI[0] % 120 < 60)
                        {
                            NPC.velocity *= 0.5f;
                            NPC.rotation += Omega;
                            Omega += 0.02f;
                        }
                        if (NPC.localAI[0] % 120 == 60)
                        {
                            Omega = 0;
                            NPC.velocity = (player.Center - NPC.Center) / num3 * 45f;
                            NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        }
                        if (NPC.localAI[0] % 120 > 60)
                        {
                            NPC.velocity *= 0.99f;
                            Vector2 v = (player.Center - NPC.Center);
                            Vector2 v2 = player.Center - NPC.Center - NPC.velocity;
                            if (NPC.velocity.Length() * NPC.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                            {
                                NPC.velocity *= 0.95f;
                            }
                            NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        }
                        if (NPC.localAI[0] != 8639)
                        {
                            Rota += Omega2;
                            if (Omega2 < 0.03f)
                            {
                                Omega2 += 0.0003f;
                            }
                            for (int i = 0; i < 12; i++)
                            {
                                Main.projectile[num1[i]].position = NPC.Center + NPC.velocity.RotatedBy(Math.PI / 6d * (float)i + Rota) / NPC.velocity.Length() * 240f;
                                Main.projectile[num1[i]].velocity = NPC.velocity.RotatedBy(Math.PI / 6d * (float)i + Rota) / NPC.velocity.Length() * 0.01f;
                                Main.projectile[num1[i]].timeLeft = 240;
                            }
                        }
                        if (NPC.localAI[0] == 8639)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                Main.projectile[num1[i]].position = NPC.Center + NPC.velocity.RotatedBy(Math.PI * (float)i / 6d + Rota) / NPC.velocity.Length() * 240f;
                                Main.projectile[num1[i]].velocity = NPC.velocity.RotatedBy(Math.PI * (float)i / 6d + Rota) / NPC.velocity.Length() * 2f;
                                Main.projectile[num1[i]].timeLeft = 240;
                                num1[i] = 0;
                            }
                            Rota = 0;
                            Omega2 = 0;
                        }
                    }
                }
                if (NPC.localAI[0] >= 8640 && NPC.localAI[0] < 10080)
                {
                    if (NPC.localAI[0] < 9030)
                    {
                        NPC.velocity *= 0.25f;
                        NPC.rotation += Omega;
                        Omega += 0.04f;
                    }
                    if (NPC.localAI[0] == 9030)
                    {
                        Omega = 0;
                        NPC.velocity = (player.Center + new Vector2(0, -400f) - NPC.Center) / num3 * 45f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                    if (NPC.localAI[0] > 9030 && NPC.localAI[0] < 9060)
                    {
                        NPC.velocity *= 0.99f;
                        Vector2 v = (player.Center + new Vector2(0, -200f) - NPC.Center);
                        Vector2 v2 = player.Center + new Vector2(0, -200f) - NPC.Center - NPC.velocity;
                        if (NPC.velocity.Length() * NPC.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                        {
                            NPC.velocity *= 0.85f;
                        }
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                    NPC.velocity *= 0.5f;
                    NPC.rotation += Omega;
                    Omega = 0.1f;
                    if (NPC.localAI[0] % 60 == 30)
                    {
                        for (int i = -20; i < 20; i++)
                        {
                            Projectile.NewProjectile(NPC.Center.X + i * 120, NPC.Center.Y - 800, 0, 7f, base.Mod.Find<ModProjectile>("CrystalSword2").Type, 3000, 2f, Main.myPlayer, -(float)Math.PI * 0.17f, 0f);
                        }
                    }
                    if (NPC.localAI[0] % 60 == 0)
                    {
                        for (int i = -20; i < 20; i++)
                        {
                            Projectile.NewProjectile(NPC.Center.X + i * 120 + 60, NPC.Center.Y - 800, 0, 7f, base.Mod.Find<ModProjectile>("CrystalSword5").Type, 3000, 2f, Main.myPlayer, -(float)Math.PI * 0.17f, 0f);
                        }
                    }
                }
                if (NPC.localAI[0] >= 10080 && NPC.localAI[0] < 11520)
                {
                    if (NPC.localAI[0] % 30 < 15)
                    {
                        NPC.velocity *= 0.25f;
                        NPC.rotation += Omega;
                        Omega += 0.06f;
                    }
                    if (NPC.localAI[0] % 30 == 15)
                    {
                        Omega = 0;
                        float j = Main.rand.NextFloat(0.5f, 1.3f);
                        if (Main.rand.Next(2) == 0)
                        {
                            j *= -1;
                        }
                        NPC.velocity = (player.Center - NPC.Center).RotatedBy(j) / num3 * 45f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        for (int i = 0; i < 6; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = NPC.velocity.RotatedBy(Math.PI / 3d * (float)i) / NPC.velocity.Length() * 0.01f;
                            Main.projectile[o].timeLeft = 1080;
                        }
                    }
                    if (NPC.localAI[0] % 30 > 15)
                    {
                        NPC.velocity *= 0.99f;
                        Vector2 v = (player.Center - NPC.Center);
                        Vector2 v2 = player.Center - NPC.Center - NPC.velocity;
                        if (NPC.velocity.Length() * NPC.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                        {
                            NPC.velocity *= 0.85f;
                        }
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                }
                if (NPC.localAI[0] >= 11520 && NPC.localAI[0] < 12960)
                {
                    if (NPC.localAI[0] % 90 < 45)
                    {
                        NPC.velocity *= 0.25f;
                        NPC.rotation += Omega;
                        Omega += 0.04f;
                    }
                    if (NPC.localAI[0] % 90 == 45)
                    {
                        Omega = 0;
                        float j = Main.rand.NextFloat(0.15f, 0.4f);
                        if (Main.rand.Next(2) == 0)
                        {
                            j *= -1;
                        }
                        NPC.velocity = (player.Center - NPC.Center).RotatedBy(j) / num3 * 45f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        for (int i = 0; i < 15; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword8").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = NPC.velocity.RotatedByRandom(Math.PI * 2d) / NPC.velocity.Length() * Main.rand.NextFloat(11f, 32f);
                            Main.projectile[o].timeLeft = 600;
                        }
                    }
                    if (NPC.localAI[0] % 90 > 45)
                    {
                        NPC.velocity *= 0.99f;
                        Vector2 v = (player.Center - NPC.Center);
                        Vector2 v2 = player.Center - NPC.Center - NPC.velocity;
                        if (NPC.velocity.Length() * NPC.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length() / 1.2f)
                        {
                            NPC.velocity *= 0.85f;
                        }
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                }
                if (NPC.localAI[0] >= 12960 && NPC.localAI[0] < 14400)
                {
                    if (NPC.localAI[0] % 150 < 45)
                    {
                        NPC.velocity *= 0.25f;
                        NPC.rotation += Omega;
                        Omega += 0.04f;
                    }
                    if (NPC.localAI[0] % 150 == 45)
                    {
                        Omega = 0;
                        NPC.velocity = (player.Center + new Vector2(0, -800) - NPC.Center) / (player.Center + new Vector2(0, -800) - NPC.Center).Length() * 25f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                    if (NPC.localAI[0] % 150 > 45)
                    {
                        Vector2 v = (player.Center - NPC.Center);
                        Vector2 v2 = player.Center - NPC.Center - NPC.velocity;
                        if (NPC.Center.Y > player.Center.Y + 100f)
                        {
                            if (NPC.localAI[0] % 150 > 100)
                            {
                                NPC.velocity *= 0.85f;
                            }
                        }
                        else
                        {
                            if (NPC.Center.X > player.Center.X && NPC.velocity.X > 0)
                            {
                                if (NPC.Center.Y < player.Center.Y - 200f)
                                {
                                    NPC.velocity.Y += 1f;
                                }
                            }
                            if (NPC.Center.X < player.Center.X && NPC.velocity.X < 0)
                            {
                                if (NPC.Center.Y < player.Center.Y - 200f)
                                {
                                    NPC.velocity.Y += 1f;
                                }
                            }
                        }
                        if (NPC.velocity.Length() > 3f && NPC.localAI[0] % 6 == 1)
                        {
                            Projectile.NewProjectile(vector.X, vector.Y, NPC.velocity.X * 0.05f, NPC.velocity.Y * 0.05f, base.Mod.Find<ModProjectile>("CrystalSword9").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                        }
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                }
            }
            if (mplayer.KillCrystal <= 2000000 && mplayer.KillCrystal > 1000000)
            {
                if (flag1)
                {
                    NPC.localAI[0] = 0;
                    flag1 = false;
                }
                if (NPC.localAI[0] % 1000 == 0)
                {
                    //npc.localAI[0] = 3000;
                    NPC.localAI[0] = Main.rand.Next(4) * 1000;
                }
                if (NPC.localAI[0] >= 0 && NPC.localAI[0] < 1000)
                {
                    if (NPC.localAI[0] % 60 < 30)
                    {
                        NPC.velocity *= 0.25f;
                        NPC.rotation += Omega;
                        Omega += 0.06f;
                    }
                    if (NPC.localAI[0] % 60 == 30)
                    {
                        Omega = 0;
                        float j = Main.rand.NextFloat(0.5f, 1.3f);
                        if (Main.rand.Next(2) == 0)
                        {
                            j *= -1;
                        }
                        NPC.velocity = (player.Center - NPC.Center).RotatedBy(j) / num3 * 45f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        for (int i = 0; i < 24; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = NPC.velocity.RotatedBy(Math.PI / 12d * (float)i) / NPC.velocity.Length() * 0.01f;
                            Main.projectile[o].timeLeft = 1080;
                            Main.projectile[o].scale = 0.25f;
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = NPC.velocity.RotatedBy(Math.PI / 3d * (float)i) / NPC.velocity.Length() * 0.01f;
                            Main.projectile[o].timeLeft = 1080;
                        }
                    }
                    if (NPC.localAI[0] % 60 > 30)
                    {
                        NPC.velocity *= 0.99f;
                        Vector2 v = (player.Center - NPC.Center);
                        Vector2 v2 = player.Center - NPC.Center - NPC.velocity;
                        if (NPC.velocity.Length() * NPC.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                        {
                            NPC.velocity *= 0.85f;
                        }
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                }
                if (NPC.localAI[0] >= 1000 && NPC.localAI[0] < 2000)
                {
                    if (NPC.localAI[0] % 60 < 30)
                    {
                        NPC.velocity *= 0.25f;
                        NPC.rotation += Omega;
                        Omega += 0.04f;
                        if (NPC.localAI[0] % 10 == 0)
                        {
                            for (int i = 0; i < 8; i++)
                            {
                                int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                                Main.projectile[o].velocity = NPC.velocity.RotatedBy(Math.PI / 4d * (float)i) / NPC.velocity.Length() * 10f;
                                Main.projectile[o].timeLeft = 600;
                                //Main.projectile[o].scale = 0.25f;
                            }
                        }
                    }
                    if (NPC.localAI[0] % 60 == 30)
                    {
                        Omega = 0;
                        NPC.velocity = (player.Center - NPC.Center) / num3 * 30f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                    if (NPC.localAI[0] % 60 > 30)
                    {
                        NPC.velocity *= 0.99f;
                        Vector2 v = (player.Center - NPC.Center);
                        Vector2 v2 = player.Center - NPC.Center - NPC.velocity;
                        if (NPC.velocity.Length() * NPC.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                        {
                            NPC.velocity *= 0.85f;
                        }
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                }
                if (NPC.localAI[0] >= 2000 && NPC.localAI[0] < 3000)
                {
                    if (NPC.localAI[0] % 120 == 0 && !player.dead)
                    {
                        NPC.position = player.position + new Vector2(0, -500);
                        NPC.velocity *= 0;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                    if (NPC.localAI[0] % 120 > 0 && NPC.localAI[0] % 120 < 60)
                    {
                        NPC.velocity.Y += 1f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        if(NPC.localAI[0] % 5 == 0)
                        {
                            Projectile.NewProjectile(vector.X + 600, vector.Y, -2, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector.X - 600, vector.Y, 2, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                    if (NPC.localAI[0] % 120 == 60 && !player.dead)
                    {
                        NPC.position = player.position + new Vector2(0, 500);
                        NPC.velocity *= 0;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                    if (NPC.localAI[0] % 120 > 60)
                    {
                        NPC.velocity.Y -= 1f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        if (NPC.localAI[0] % 5 == 0)
                        {
                            Projectile.NewProjectile(vector.X + 600, vector.Y, -2, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector.X - 600, vector.Y, 2, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                if (NPC.localAI[0] >= 3000 && NPC.localAI[0] < 4000)
                {
                    if (NPC.velocity.Length() > 0.00001)
                    {
                        NPC.velocity *= 0.5f;
                    }
                    NPC.rotation += Omega;
                    Omega = 0.45f;
                    if (NPC.localAI[0] % 7 == 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = NPC.velocity.RotatedBy(Math.PI / 1.5 * (float)i + NPC.localAI[0] / 15f) / (NPC.velocity.Length()) * 1f;
                            Main.projectile[o].timeLeft = 400;
                        }
                    }
                    if (NPC.localAI[0] % 120 == 0)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = NPC.velocity.RotatedBy(Math.PI / 10d * (float)i) / (NPC.velocity.Length()) * 1f;
                            Main.projectile[o].timeLeft = 400;
                        }
                    }
                }
                NPC.defense = (int)((player.Center - NPC.Center).Length() * 4f);
            }
            if (mplayer.KillCrystal <= 4000000 && mplayer.KillCrystal > 2000000)
            {
                if (NPC.localAI[0] % 1000 == 0)
                {
                    //npc.localAI[0] = 3000;
                    NPC.localAI[0] = Main.rand.Next(13) * 1000;
                }
                if (flag2)
                {
                    NPC.localAI[0] = 0;
                    flag2 = false;
                }
                if (NPC.velocity.Length() > 6f)
                {
                    NPC.defense = (int)((player.Center - NPC.Center).Length() * 12f);
                }
                else;
                {
                    NPC.defense = (int)((player.Center - NPC.Center).Length() * 40f);
                }
                if (NPC.localAI[0] >= 0 && NPC.localAI[0] < 1000)
                {
                    if (NPC.localAI[0] % 40 == 0)
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            NPC.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (NPC.localAI[0] % 40 < 20)
                    {
                        NPC.velocity *= 0.25f;
                        NPC.rotation += Omega;
                        Omega += 0.06f;
                    }
                    if (NPC.localAI[0] % 40 == 20)
                    {
                        Omega = 0;
                        float j = Main.rand.NextFloat(0.5f, 1.3f);
                        if (Main.rand.Next(2) == 0)
                        {
                            j *= -1;
                        }
                        NPC.velocity = (player.Center - NPC.Center).RotatedBy(j) / num3 * 45f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        for (int i = 0; i < 24; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = NPC.velocity.RotatedBy(Math.PI / 12d * (float)i) / NPC.velocity.Length() * 0.1f;
                            Main.projectile[o].timeLeft = 1080;
                            Main.projectile[o].scale = 0.25f;
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = NPC.velocity.RotatedBy(Math.PI / 3d * (float)i) / NPC.velocity.Length() * 0.1f;
                            Main.projectile[o].timeLeft = 1080;
                        }
                    }
                    if (NPC.localAI[0] % 40 > 20)
                    {
                        NPC.velocity *= 0.99f;
                        Vector2 v = (player.Center - NPC.Center);
                        Vector2 v2 = player.Center - NPC.Center - NPC.velocity;
                        if (NPC.velocity.Length() * NPC.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                        {
                            NPC.velocity *= 0.85f;
                        }
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                }
                if (NPC.localAI[0] >= 1000 && NPC.localAI[0] < 2000)
                {
                    if (NPC.localAI[0] % 60 == 0)
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            NPC.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (NPC.localAI[0] % 60 < 30)
                    {
                        NPC.velocity *= 0.25f;
                        NPC.rotation += Omega;
                        Omega += 0.04f;
                        if (NPC.localAI[0] % 10 == 0)
                        {
                            for (int i = 0; i < 14; i++)
                            {
                                int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                                Main.projectile[o].velocity = NPC.velocity.RotatedBy(Math.PI / 7d * (float)i) / NPC.velocity.Length() * 10f;
                                Main.projectile[o].timeLeft = 600;
                                //Main.projectile[o].scale = 0.25f;
                            }
                        }
                    }
                    if (NPC.localAI[0] % 60 == 30)
                    {
                        Omega = 0;
                        NPC.velocity = (player.Center - NPC.Center) / num3 * 40f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                    if (NPC.localAI[0] % 60 > 30)
                    {
                        NPC.velocity *= 0.99f;
                        Vector2 v = (player.Center - NPC.Center);
                        Vector2 v2 = player.Center - NPC.Center - NPC.velocity;
                        if (NPC.velocity.Length() * NPC.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                        {
                            NPC.velocity *= 0.85f;
                        }
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                }
                if (NPC.localAI[0] >= 2000 && NPC.localAI[0] < 3000)
                {
                    if (NPC.localAI[0] % 120 == 0)
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            NPC.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (NPC.localAI[0] % 120 == 0 && !player.dead)
                    {
                        NPC.position = player.position + new Vector2(0, -500);
                        NPC.velocity *= 0;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                    if (NPC.localAI[0] % 120 > 0 && NPC.localAI[0] % 120 < 60)
                    {
                        NPC.velocity.Y += 1f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        if (NPC.localAI[0] % 5 == 0)
                        {
                            Projectile.NewProjectile(vector.X + 600, vector.Y, -2, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector.X - 600, vector.Y, 2, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                    if (NPC.localAI[0] % 120 == 60 && !player.dead)
                    {
                        NPC.position = player.position + new Vector2(0, 500);
                        NPC.velocity *= 0;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                    if (NPC.localAI[0] % 120 > 60)
                    {
                        NPC.velocity.Y -= 1f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        if (NPC.localAI[0] % 5 == 0)
                        {
                            Projectile.NewProjectile(vector.X + 600, vector.Y, -2, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector.X - 600, vector.Y, 2, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                if (NPC.localAI[0] >= 3000 && NPC.localAI[0] < 4000)
                {
                    if (NPC.localAI[0] % 40 == 0)
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            NPC.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (NPC.velocity.Length() > 0.00001)
                    {
                        NPC.velocity *= 0.5f;
                    }
                    NPC.rotation += Omega;
                    Omega = 0.45f;
                    if (NPC.localAI[0] % 7 == 0)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = NPC.velocity.RotatedBy(Math.PI / 1.5 * (float)i + NPC.localAI[0] / 15f) / (NPC.velocity.Length()) * 15f;
                            Main.projectile[o].timeLeft = 400;
                        }
                    }
                    if (NPC.localAI[0] % 120 == 0)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = NPC.velocity.RotatedBy(Math.PI / 10d * (float)i) / (NPC.velocity.Length()) * 1f;
                            Main.projectile[o].timeLeft = 400;
                        }
                    }
                }
                if (NPC.localAI[0] >= 4000 && NPC.localAI[0] < 5000)
                {
                    if (NPC.localAI[0] % 60 == 0)
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            NPC.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (NPC.localAI[0] % 60 < 30)
                    {
                        NPC.velocity *= 0.25f;
                        NPC.rotation += Omega;
                        Omega += 0.04f;
                    }
                    if (NPC.localAI[0] % 60 == 30)
                    {
                        Omega = 0;
                        NPC.velocity = (player.Center - NPC.Center) / num3 * 30f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                    if (NPC.localAI[0] % 10 == 0)
                    {
                        if (NPC.localAI[0] % 5 == 0)
                        {
                            Projectile.NewProjectile(player.Center.X + 300, player.Center.Y, -2, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(player.Center.X - 300, player.Center.Y, 2, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                        }
                    }
                    if (NPC.localAI[0] % 60 > 30)
                    {
                        NPC.velocity *= 0.99f;
                        Vector2 v = (player.Center - NPC.Center);
                        Vector2 v2 = player.Center - NPC.Center - NPC.velocity;
                        if (NPC.velocity.Length() * NPC.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                        {
                            NPC.velocity *= 0.85f;
                        }
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                }
                if (NPC.localAI[0] >= 5000 && NPC.localAI[0] < 6000)
                {
                    if (NPC.localAI[0] % 40 == 0)
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            NPC.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (NPC.velocity.Length() > 0.00001)
                    {
                        NPC.velocity *= 0.5f;
                    }
                    NPC.rotation += Omega;
                    Omega = 0.45f;
                    if (NPC.localAI[0] % 8 == 4)
                    {
                        Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword").Type, 3000, 2f, Main.myPlayer, (float)Math.PI * Main.rand.NextFloat(0, 2f), 0f);
                    }
                    if (NPC.localAI[0] % 8 == 0)
                    {
                        Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword3").Type, 3000, 2f, Main.myPlayer, (float)Math.PI * Main.rand.NextFloat(0, 2f), 0f);
                    }
                    if (NPC.localAI[0] % 120 == 0)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = NPC.velocity.RotatedBy(Math.PI / 10d * (float)i) / (NPC.velocity.Length()) * 1f;
                            Main.projectile[o].timeLeft = 600;
                        }
                    }
                }
                if (NPC.localAI[0] >= 6000 && NPC.localAI[0] < 7000)
                {
                    if (NPC.localAI[0] % 40 == 0)
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            NPC.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    NPC.velocity *= 0.5f;
                    NPC.rotation += Omega;
                    Omega = 0.1f;
                    if (NPC.localAI[0] % 15 == 4)
                    {
                        Projectile.NewProjectile(player.Center.X + Main.rand.Next(-600, 600), player.Center.Y - 800, Main.rand.Next(-600, 600) / 100f, 20f, base.Mod.Find<ModProjectile>("CrystalSword2").Type, 3000, 2f, Main.myPlayer, (float)Math.PI * 0.17f, 0f);
                        Projectile.NewProjectile(player.Center.X + Main.rand.Next(-600, 600), player.Center.Y - 800, Main.rand.Next(-600, 600) / 100f, 20f, base.Mod.Find<ModProjectile>("CrystalSword5").Type, 3000, 2f, Main.myPlayer, -(float)Math.PI * 0.17f, 0f);
                    }
                }
                if (NPC.localAI[0] >= 7000 && NPC.localAI[0] < 8000)
                {
                    if (NPC.localAI[0] % 120 == 0)
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            NPC.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (NPC.localAI[0] % 120 == 0)
                    {
                        NPC.velocity = (player.Center - NPC.Center) / num3 * 0.4f;
                        for (int i = -10; i < 10; i++)
                        {
                            if (i > 0)
                            {
                                Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, -NPC.velocity.Y * i * 11, NPC.velocity.X * i * 11, base.Mod.Find<ModProjectile>("CrystalSword4").Type, 3000, 2f, Main.myPlayer, -1, 0f);
                            }
                            if (i < 0)
                            {
                                Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, -NPC.velocity.Y * i * 11, NPC.velocity.X * i * 11, base.Mod.Find<ModProjectile>("CrystalSword4").Type, 3000, 2f, Main.myPlayer, 1, 0f);
                            }
                        }
                    }
                    if (NPC.localAI[0] % 120 > 0)
                    {
                        Vector2 v = (player.Center - NPC.Center);
                        Vector2 v2 = player.Center - NPC.Center - NPC.velocity;
                        if (NPC.velocity.Length() * NPC.velocity.Length() + v.Length() * v.Length() < (v2.Length() * v2.Length()))
                        {
                            NPC.velocity *= 0.96f;
                        }
                        else
                        {
                            NPC.velocity *= 1.05f;
                        }
                    }
                    NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                }
                if (NPC.localAI[0] >= 8000 && NPC.localAI[0] < 9000)
                {
                    if (NPC.localAI[0] >= 8000 && NPC.localAI[0] < 8166)
                    {
                        NPC.velocity *= 0.9f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        Vector2 v = (player.Center - NPC.Center);
                        NPC.velocity += v / v.Length() * 0.05f;
                        if (NPC.localAI[0] == 8000)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                num1[i] = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            }
                        }
                        for (int i = 0; i < 12; i++)
                        {
                            Main.projectile[num1[i]].position = NPC.Center + NPC.velocity.RotatedBy(Math.PI / 6d * (float)i) / NPC.velocity.Length() * (NPC.localAI[0] - 7999);
                            Main.projectile[num1[i]].velocity = NPC.velocity.RotatedBy(Math.PI / 6d * (float)i) / NPC.velocity.Length() * 0.01f;
                            Main.projectile[num1[i]].timeLeft = 240;
                            Main.projectile[num1[i]].scale = (NPC.localAI[0] - 7999) / 333f;
                        }
                    }
                    if (NPC.localAI[0] >= 8500 && NPC.localAI[0] < 8666)
                    {
                        NPC.velocity *= 0.9f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        Vector2 v = (player.Center - NPC.Center);
                        NPC.velocity += v / v.Length() * 0.05f;
                        if (NPC.localAI[0] == 8500)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                num1[i] = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            }
                        }
                        for (int i = 0; i < 12; i++)
                        {
                            Main.projectile[num1[i]].position = NPC.Center + NPC.velocity.RotatedBy(Math.PI / 6d * (float)i) / NPC.velocity.Length() * (NPC.localAI[0] - 8499);
                            Main.projectile[num1[i]].velocity = NPC.velocity.RotatedBy(Math.PI / 6d * (float)i) / NPC.velocity.Length() * 0.01f;
                            Main.projectile[num1[i]].timeLeft = 240;
                            Main.projectile[num1[i]].scale = (NPC.localAI[0] - 8499) / 333f;
                        }
                    }
                    if (NPC.localAI[0] >= 8166 && NPC.localAI[0] < 8500)
                    {
                        if (NPC.localAI[0] % 40 == 0)
                        {
                            if (Main.rand.Next(3) == 0)
                            {
                                NPC.localAI[0] = 8999;
                            }
                        }
                        if (NPC.localAI[0] % 40 < 20)
                        {
                            NPC.velocity *= 0.5f;
                            NPC.rotation += Omega;
                            Omega += 0.02f;
                        }
                        if (NPC.localAI[0] % 40 == 20)
                        {
                            Omega = 0;
                            NPC.velocity = (player.Center - NPC.Center) / num3 * 45f;
                            NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        }
                        if (NPC.localAI[0] % 40 > 20)
                        {
                            NPC.velocity *= 0.99f;
                            Vector2 v = (player.Center - NPC.Center);
                            Vector2 v2 = player.Center - NPC.Center - NPC.velocity;
                            if (NPC.velocity.Length() * NPC.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                            {
                                NPC.velocity *= 0.95f;
                            }
                            NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        }
                        if (NPC.localAI[0] != 8499)
                        {
                            Rota += Omega2;
                            if (Omega2 < 0.03f)
                            {
                                Omega2 += 0.0003f;
                            }
                            for (int i = 0; i < 12; i++)
                            {
                                Main.projectile[num1[i]].position = NPC.Center + NPC.velocity.RotatedBy(Math.PI / 6d * (float)i + Rota) / NPC.velocity.Length() * 240f;
                                Main.projectile[num1[i]].velocity = NPC.velocity.RotatedBy(Math.PI / 6d * (float)i + Rota) / NPC.velocity.Length() * 0.01f;
                                Main.projectile[num1[i]].timeLeft = 240;
                            }
                        }
                        if (NPC.localAI[0] == 8499)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                Main.projectile[num1[i]].position = NPC.Center + NPC.velocity.RotatedBy(Math.PI * (float)i / 6d + Rota) / NPC.velocity.Length() * 240f;
                                Main.projectile[num1[i]].velocity = NPC.velocity.RotatedBy(Math.PI * (float)i / 6d + Rota) / NPC.velocity.Length() * 2f;
                                Main.projectile[num1[i]].timeLeft = 240;
                                num1[i] = 0;
                            }
                            Rota = 0;
                            Omega2 = 0;
                        }
                    }
                    if (NPC.localAI[0] >= 8666 && NPC.localAI[0] < 9000)
                    {
                        if (NPC.localAI[0] % 40 == 0)
                        {
                            if (Main.rand.Next(3) == 0)
                            {
                                NPC.localAI[0] = 8999;
                            }
                        }
                        if (NPC.localAI[0] % 40 < 20)
                        {
                            NPC.velocity *= 0.5f;
                            NPC.rotation += Omega;
                            Omega += 0.02f;
                        }
                        if (NPC.localAI[0] % 40 == 20)
                        {
                            Omega = 0;
                            NPC.velocity = (player.Center - NPC.Center) / num3 * 45f;
                            NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        }
                        if (NPC.localAI[0] % 40 > 20)
                        {
                            NPC.velocity *= 0.99f;
                            Vector2 v = (player.Center - NPC.Center);
                            Vector2 v2 = player.Center - NPC.Center - NPC.velocity;
                            if (NPC.velocity.Length() * NPC.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                            {
                                NPC.velocity *= 0.95f;
                            }
                            NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        }
                        if (NPC.localAI[0] != 8999)
                        {
                            Rota += Omega2;
                            if (Omega2 < 0.03f)
                            {
                                Omega2 += 0.0003f;
                            }
                            for (int i = 0; i < 12; i++)
                            {
                                Main.projectile[num1[i]].position = NPC.Center + NPC.velocity.RotatedBy(Math.PI / 6d * (float)i + Rota) / NPC.velocity.Length() * 240f;
                                Main.projectile[num1[i]].velocity = NPC.velocity.RotatedBy(Math.PI / 6d * (float)i + Rota) / NPC.velocity.Length() * 0.01f;
                                Main.projectile[num1[i]].timeLeft = 240;
                            }
                        }
                        if (NPC.localAI[0] == 8999)
                        {
                            for (int i = 0; i < 12; i++)
                            {
                                Main.projectile[num1[i]].position = NPC.Center + NPC.velocity.RotatedBy(Math.PI * (float)i / 6d + Rota) / NPC.velocity.Length() * 240f;
                                Main.projectile[num1[i]].velocity = NPC.velocity.RotatedBy(Math.PI * (float)i / 6d + Rota) / NPC.velocity.Length() * 2f;
                                Main.projectile[num1[i]].timeLeft = 240;
                                num1[i] = 0;
                            }
                            Rota = 0;
                            Omega2 = 0;
                        }
                    }
                }
                if (NPC.localAI[0] >= 9000 && NPC.localAI[0] < 10000)
                {
                    if (NPC.localAI[0] < 9030)
                    {
                        NPC.velocity *= 0.25f;
                        NPC.rotation += Omega;
                        Omega += 0.04f;
                    }
                    if (NPC.localAI[0] == 9030)
                    {
                        Omega = 0;
                        NPC.velocity = (player.Center + new Vector2(0, -400f) - NPC.Center) / num3 * 45f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                    if (NPC.localAI[0] > 9030 && NPC.localAI[0] < 9060)
                    {
                        NPC.velocity *= 0.99f;
                        Vector2 v = (player.Center + new Vector2(0, -200f) - NPC.Center);
                        Vector2 v2 = player.Center + new Vector2(0, -200f) - NPC.Center - NPC.velocity;
                        if (NPC.velocity.Length() * NPC.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                        {
                            NPC.velocity *= 0.85f;
                        }
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                    NPC.velocity *= 0.5f;
                    NPC.rotation += Omega;
                    Omega = 0.1f;
                    if (NPC.localAI[0] % 60 == 0)
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            NPC.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (NPC.localAI[0] % 60 == 30)
                    {
                        for (int i = -20; i < 20; i++)
                        {
                            Projectile.NewProjectile(NPC.Center.X + i * 120, NPC.Center.Y - 800, 0, 7f, base.Mod.Find<ModProjectile>("CrystalSword2").Type, 3000, 2f, Main.myPlayer, -(float)Math.PI * 0.17f, 0f);
                        }
                    }
                    if (NPC.localAI[0] % 60 == 0)
                    {
                        for (int i = -20; i < 20; i++)
                        {
                            Projectile.NewProjectile(NPC.Center.X + i * 120 + 60, NPC.Center.Y - 800, 0, 7f, base.Mod.Find<ModProjectile>("CrystalSword5").Type, 3000, 2f, Main.myPlayer, -(float)Math.PI * 0.17f, 0f);
                        }
                    }
                }
                if (NPC.localAI[0] >= 10000 && NPC.localAI[0] < 11000)
                {
                    if (NPC.localAI[0] % 30 == 0)
                    {
                        if (Main.rand.Next(5) == 0)
                        {
                            NPC.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (NPC.localAI[0] % 30 < 15)
                    {
                        NPC.velocity *= 0.25f;
                        NPC.rotation += Omega;
                        Omega += 0.06f;
                    }
                    if (NPC.localAI[0] % 30 == 15)
                    {
                        Omega = 0;
                        float j = Main.rand.NextFloat(0.5f, 1.3f);
                        if (Main.rand.Next(2) == 0)
                        {
                            j *= -1;
                        }
                        NPC.velocity = (player.Center - NPC.Center).RotatedBy(j) / num3 * 45f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        for (int i = 0; i < 6; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = NPC.velocity.RotatedBy(Math.PI / 3d * (float)i) / NPC.velocity.Length() * 0.01f;
                            Main.projectile[o].timeLeft = 1080;
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword7").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = NPC.velocity.RotatedBy(Math.PI / 3d * (float)i + Math.PI / 6d) / NPC.velocity.Length() * 1f;
                            Main.projectile[o].timeLeft = 1080;
                        }
                    }
                    if (NPC.localAI[0] % 30 > 15)
                    {
                        NPC.velocity *= 0.99f;
                        Vector2 v = (player.Center - NPC.Center);
                        Vector2 v2 = player.Center - NPC.Center - NPC.velocity;
                        if (NPC.velocity.Length() * NPC.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length())
                        {
                            NPC.velocity *= 0.85f;
                        }
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                }
                if (NPC.localAI[0] >= 11000 && NPC.localAI[0] < 12000)
                {
                    if (NPC.localAI[0] % 90 == 0)
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            NPC.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (NPC.localAI[0] % 90 < 45)
                    {
                        NPC.velocity *= 0.25f;
                        NPC.rotation += Omega;
                        Omega += 0.04f;
                    }
                    if (NPC.localAI[0] % 90 == 45)
                    {
                        Omega = 0;
                        float j = Main.rand.NextFloat(0.15f, 0.4f);
                        if (Main.rand.Next(2) == 0)
                        {
                            j *= -1;
                        }
                        NPC.velocity = (player.Center - NPC.Center).RotatedBy(j) / num3 * 45f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                        for (int i = 0; i < 15; i++)
                        {
                            int o = Projectile.NewProjectile(vector.X, vector.Y, 0, 0, base.Mod.Find<ModProjectile>("CrystalSword8").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[o].velocity = NPC.velocity.RotatedByRandom(Math.PI * 2d) / NPC.velocity.Length() * Main.rand.NextFloat(11f, 32f);
                            Main.projectile[o].timeLeft = 600;
                        }
                    }
                    if (NPC.localAI[0] % 90 > 45)
                    {
                        NPC.velocity *= 0.99f;
                        Vector2 v = (player.Center - NPC.Center);
                        Vector2 v2 = player.Center - NPC.Center - NPC.velocity;
                        if (NPC.velocity.Length() * NPC.velocity.Length() + v.Length() * v.Length() < v2.Length() * v2.Length() / 1.2f)
                        {
                            NPC.velocity *= 0.85f;
                        }
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                }
                if (NPC.localAI[0] >= 12000 && NPC.localAI[0] < 13000)
                {
                    if (NPC.localAI[0] % 150 == 0)
                    {
                        if (Main.rand.Next(2) == 0)
                        {
                            NPC.localAI[0] = Main.rand.Next(13) * 1000;
                        }
                    }
                    if (NPC.localAI[0] % 150 < 45)
                    {
                        NPC.velocity *= 0.25f;
                        NPC.rotation += Omega;
                        Omega += 0.04f;
                    }
                    if (NPC.localAI[0] % 150 == 45)
                    {
                        Omega = 0;
                        NPC.velocity = (player.Center + new Vector2(0, -800) - NPC.Center) / (player.Center + new Vector2(0, -800) - NPC.Center).Length() * 25f;
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
                    }
                    if (NPC.localAI[0] % 150 > 45)
                    {
                        Vector2 v = (player.Center - NPC.Center);
                        Vector2 v2 = player.Center - NPC.Center - NPC.velocity;
                        if (NPC.Center.Y > player.Center.Y + 100f)
                        {
                            if (NPC.localAI[0] % 150 > 100)
                            {
                                NPC.velocity *= 0.85f;
                            }
                        }
                        else
                        {
                            if (NPC.Center.X > player.Center.X && NPC.velocity.X > 0)
                            {
                                if (NPC.Center.Y < player.Center.Y - 200f)
                                {
                                    NPC.velocity.Y += 1f;
                                }
                            }
                            if (NPC.Center.X < player.Center.X && NPC.velocity.X < 0)
                            {
                                if (NPC.Center.Y < player.Center.Y - 200f)
                                {
                                    NPC.velocity.Y += 1f;
                                }
                            }
                        }
                        if (NPC.velocity.Length() > 3f && NPC.localAI[0] % 6 == 1)
                        {
                            Projectile.NewProjectile(vector.X, vector.Y, NPC.velocity.X * 0.05f, NPC.velocity.Y * 0.05f, base.Mod.Find<ModProjectile>("CrystalSword9").Type, 3000, 2f, Main.myPlayer, 0f, 0f);
                        }
                        NPC.rotation = (float)(Math.Atan2(NPC.velocity.Y, NPC.velocity.X));
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
                base.NPC.TargetClosest(false);
                player = Main.player[base.NPC.target];
                if (!player.active || player.dead)
                {
                    base.NPC.velocity = new Vector2(0f, 10f);
                    if (base.NPC.timeLeft > 150)
                    {
                        base.NPC.timeLeft = 150;
                    }
                    return;
                }
            }
            else
            {
                canDespawn = false;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = TextureAssets.Npc[base.NPC.type].Value;
            Main.spriteBatch.Draw(texture, NPC.Center - Main.screenPosition + new Vector2(0f, NPC.gfxOffY), NPC.frame, NPC.GetAlpha(drawColor), NPC.rotation, new Vector2(110, 110), NPC.scale, SpriteEffects.None, 0f);
            return false;
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            SoundEngine.PlaySound(SoundID.Item27, NPC.position);
            if (Main.rand.Next(3) == 1)
            {
                for (int j = 0; j < 2; j++)
                {
                    int u = Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, Mod.Find<ModDust>("Crystal").Type, 0, 0, 0, default(Color), 1f);
                    Main.dust[u].noGravity = false;
                    Main.dust[u].fadeIn = 1f + (float)Main.rand.NextFloat(-0.5f, 0.5f) * 0.1f;
                }
            }
            if (base.NPC.life <= 0)
            {
                Color messageColor = new Color(0, 150, 255);
                Main.NewText(Language.GetTextValue("得分:400"), messageColor);
                base.NPC.position.X = base.NPC.position.X + (float)(base.NPC.width / 2);
                base.NPC.position.Y = base.NPC.position.Y + (float)(base.NPC.height / 2);
                base.NPC.position.X = base.NPC.position.X - (float)(base.NPC.width / 2);
                base.NPC.position.Y = base.NPC.position.Y - (float)(base.NPC.height / 2);
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/冰洲石剑1"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/冰洲石剑2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/冰洲石剑3"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/冰洲石剑2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/冰洲石剑3"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/冰洲石剑4"), 1f);
            }
        }
        private bool canDespawn;
        public override bool CheckActive()
        {
            return this.canDespawn;
        }
        public override void OnKill()
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
                        type = base.Mod.Find<ModItem>("CrystalBall").Type;
                        break;
                    case 2:
                        type = base.Mod.Find<ModItem>("CrystalBlade").Type;
                        break;
                    case 3:
                        type = base.Mod.Find<ModItem>("CrystalBow").Type;
                        break;
                    case 4:
                        type = base.Mod.Find<ModItem>("CrystalEagle").Type;
                        break;
                    case 5:
                        type = base.Mod.Find<ModItem>("CrystalRose").Type;
                        break;
                    case 6:
                        type = base.Mod.Find<ModItem>("CrystalSwordStaff").Type;
                        break;
                    case 7:
                        type = base.Mod.Find<ModItem>("CrystalThrownKnife").Type;
                        break;
                }
                Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, type, 1, false, 0, false, false);
            }
            else
            {
                Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, Mod.Find<ModItem>("CrystalSwordTreasureBag").Type, 1, false, 0, false, false);
            }
            if (Main.rand.Next(10) == 2)
            {
                Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, Mod.Find<ModItem>("CrystalSwordPlatfo").Type, 1, false, 0, false, false);
            }
        }
    }
}
