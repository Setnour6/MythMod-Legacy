using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Shaders;

namespace MythMod.NPCs
{
    public class MythGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        private bool Eoc = true;
        private bool Eoc2 = true;
        private bool Eoc3 = true;
        private bool Boc = true;
        private bool num52 = true;
        private bool num54 = true;
        private bool num74 = true;
        private bool num86 = true;
        private bool num87 = true;
        private bool num94 = true;
        private float num10 = 0;
        private float num76 = 0;
        private float num82 = 1;
        private float num88 = 1;
        private float num89 = 1;
        private int num11 = 0;
        private int num58 = 0;
        private int num53;
        private int num55;
        private int num56;
        private int num57;
        private int num59;
        private int num62;
        private int num63;
        private int num64;
        private int num65;
        private int num66;
        private int num71;
        private int num72;
        private int num73 = 0;
        private int num75;
        private int num77;
        private int num78;
        private int num79;
        private int num81;
        private int num83;
        private int num84;
        private int num85 = 0;
        private int num90 = 0;
        private int num91 = 0;
        private int num92 = 0;
        private int num93 = 0;
        private int num1 = 0;
        private int npcClock = 0;
        private Vector2 vector9 = new Vector2(0, 29);
        private Vector2 vector14;
        private Vector2 vector16;
        private Vector2 vector17;
        private Vector2 vector19;
        private int Misspo = 0;

        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (type == 38 && Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(base.Mod.Find<ModItem>("FireWorkBallShout").Type, false);
                shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 0, 5, 0));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(base.Mod.Find<ModItem>("FireWorkBallShoutDouble").Type, false);
                shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 0, 25, 0));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(base.Mod.Find<ModItem>("FireWorkBall").Type, false);
                shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 1, 0, 0));
                nextSlot++;
            }
            if (type == 368 && Main.hardMode && NPC.downedMoonlord)
            {
                shop.item[nextSlot].SetDefaults(base.Mod.Find<ModItem>("Code3").Type, false);
                shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 50, 0, 0));
                nextSlot++;
            }
            if (type == 369 && mplayer.ZoneOcean)
            {
                shop.item[nextSlot].SetDefaults(base.Mod.Find<ModItem>("GlowingShrimpJam").Type, false);
                shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 25, 0, 0));
                nextSlot++;
            }
            if (type == 453 && Main.eclipse && NPC.downedMoonlord)
            {
                shop.item[nextSlot].SetDefaults(base.Mod.Find<ModItem>("GoldRoundYoyo").Type, false);
                shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(2, 0, 0, 0));
                nextSlot++;
            }
            if (type == 124)
            {
            }
            if (type == 368 && (int)((Main.time - Main.time % 3600) / 3600) % 4 == 0)
            {
                shop.item[nextSlot].SetDefaults(base.Mod.Find<ModItem>("Rice").Type, false);
                shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 0, 5, 0));
                nextSlot++;
            }
            if (type == 227)
            {
                if (mplayer.ZoneVolcano)
                {
                    shop.item[nextSlot].SetDefaults(base.Mod.Find<ModItem>("BurningRainbow").Type, false);
                    shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 5, 0, 0));
                    nextSlot++;
                }
                if (mplayer.ZoneOcean)
                {
                    shop.item[nextSlot].SetDefaults(base.Mod.Find<ModItem>("ShallowBeach").Type, false);
                    shop.item[nextSlot].shopCustomPrice = new int?(Item.buyPrice(0, 5, 0, 0));
                    nextSlot++;
                }
            }
        }
        public override void SetDefaults(NPC npc)
        {
            if (MythWorld.Myth && npc.lifeMax >= 10)
            {
                npc.lifeMax = (int)((double)npc.lifeMax * 1.2);
                npc.damage = (int)((double)npc.damage * 1.5);
                npc.value *= 2;
                if (MythWorld.MythIndex > 1)
                {
                    for (int k = 1; k < MythWorld.MythIndex; k++)
                    {
                        npc.lifeMax = (int)((double)npc.lifeMax * 1.5);
                        npc.damage = (int)((double)npc.damage * 1.5f);
                        npc.value *= 1.5f;
                    }
                }
                if (npc.type == 370)
                {
                    npc.lifeMax = (int)(npc.lifeMax * 0.8);
                    npc.damage = (int)((double)npc.damage * 0.8);
                }
                if (npc.type == 134)
                {
                    npc.lifeMax = (int)((double)npc.lifeMax * 1.12);
                    npc.damage = (int)((double)npc.damage * 0.95);
                }
                if (npc.type == 50)
                {
                    npc.lifeMax = (int)((double)npc.lifeMax / 28f * 36) + 1;
                    npc.damage = (int)((double)npc.damage * 0.75f);
                }
                if (npc.type == 4)
                {
                    npc.lifeMax = (int)((double)npc.lifeMax / 91 * 78f);
                    npc.damage = (int)((double)npc.damage * 1.7);
                }
                if (npc.type == 35)
                {
                    npc.lifeMax = (int)((double)npc.lifeMax * 0.88f);
                    npc.damage = (int)((double)npc.damage * 1.3f);
                }
                if (npc.type == 125)
                {
                    npc.lifeMax = (int)((double)npc.lifeMax * 0.68f);
                }
                if (npc.type == 126)
                {
                    npc.lifeMax = (int)((double)npc.lifeMax * 0.68f);
                }
                if (npc.type == 127)
                {
                    npc.lifeMax = (int)((double)npc.lifeMax * 0.55f);
                }
                if (npc.type == 128)
                {
                    npc.lifeMax = (int)((double)npc.lifeMax * 0.75f);
                }
                if (npc.type == 129)
                {
                    npc.lifeMax = (int)((double)npc.lifeMax * 0.75f);
                }
                if (npc.type == 130)
                {
                    npc.lifeMax = (int)((double)npc.lifeMax * 0.75f);
                }
                if (npc.type == 131)
                {
                    npc.lifeMax = (int)((double)npc.lifeMax * 0.75f);
                }
                if (npc.type == 5)
                {
                    npc.lifeMax = (int)((double)npc.lifeMax * 3.5f);
                    npc.damage = (int)((double)npc.damage * 4);
                }
                if (npc.type == 267)
                {
                    npc.lifeMax = (int)((double)npc.lifeMax / 4);
                }
                if (npc.type == 113)
                {
                    npc.lifeMax = (int)((double)npc.lifeMax * 0.8f);
                    npc.damage = (int)((double)npc.damage * 8f);
                    npc.defense = (int)((double)npc.defense * 0);
                }
                if (npc.type == 114)
                {
                    npc.damage = (int)((double)npc.damage * 2f);
                    npc.defense = (int)((double)npc.defense * 0);
                }
                if (npc.type == 112)
                {
                    npc.lifeMax = (int)((double)npc.lifeMax * 0.5f);
                }
                if (npc.type == 13)
                {
                    npc.npcSlots = 10000f;
                    npc.lifeMax = (int)((double)npc.lifeMax * 0.1f);
                    npc.damage = (int)((double)npc.damage * 8f);
                    npc.defense = (int)((double)npc.defense * 0);
                }
                if (npc.type == 371)
                {
                    npc.lifeMax = 1;
                }
                if (npc.type == 14)
                {
                    npc.lifeMax = (int)((double)npc.lifeMax * 1.4f);
                    npc.damage = (int)((double)npc.damage * 7);
                    npc.defense = (int)((double)npc.defense * 120);
                    if (MythWorld.MythIndex >= 3)
                    {
                        npc.dontTakeDamage = true;
                    }
                }
                if (npc.type == 222)
                {
                    npc.lifeMax = (int)((double)npc.lifeMax * 0.7f);
                    npc.damage = (int)((double)npc.damage * 1.2f);
                    npc.defense = (int)((double)npc.defense * 1.2f);
                }
                if (npc.type == 245)
                {
                    npc.lifeMax = (int)((double)npc.lifeMax * 2f);
                    npc.damage = (int)((double)npc.damage * 1.2f);
                    npc.defense = (int)((double)npc.defense * 1.2f);
                }
                if (npc.type == 15)
                {
                    npc.dontTakeDamage = true;
                    npc.lifeMax = (int)((double)npc.lifeMax * 0.6f);
                    npc.damage = (int)((double)npc.damage * 4);
                    npc.defense = (int)((double)npc.defense * 240);
                    if (MythWorld.MythIndex >= 3)
                    {
                        npc.dontTakeDamage = true;
                    }
                }
                if (npc.type == 133)
                {
                    npc.noTileCollide = true;
                }
                if (npc.type == 266)
                {
                    npc.lifeMax = (int)((double)npc.lifeMax * 1.2f);
                    npc.damage = (int)((double)npc.damage * 1f);
                    npc.defense = (int)((double)npc.defense * 0.2f);
                    npc.knockBackResist = (int)((double)npc.knockBackResist * 0f);
                }
            }
        }
        public override void AI(NPC npc)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.KiBo > 0 && !npc.friendly)
            {
                npc.defense = 0;
            }
            if (mplayer.ZoneOcean && !npc.boss)
            {
                if (npc.type != Mod.Find<ModNPC>("海蓝史莱姆").Type && npc.type != Mod.Find<ModNPC>("深渊暗流史莱姆").Type && npc.type != Mod.Find<ModNPC>("小丑鱼").Type && npc.type != Mod.Find<ModNPC>("水雷").Type && npc.type != Mod.Find<ModNPC>("旗鱼").Type && npc.type != Mod.Find<ModNPC>("灯笼鱼").Type && npc.type != Mod.Find<ModNPC>("海月水母").Type && npc.type != Mod.Find<ModNPC>("警报水母").Type && npc.type != Mod.Find<ModNPC>("星渊水母").Type && npc.type != Mod.Find<ModNPC>("星渊水螅").Type && npc.type != Mod.Find<ModNPC>("水螅").Type && npc.type != Mod.Find<ModNPC>("黑星宝螺").Type && npc.type != Mod.Find<ModNPC>("枪虾").Type && npc.type != Mod.Find<ModNPC>("海蛇尾").Type)
                {
                    //npc.life = 0;
                    //npc.lifeMax = 0;
                }
            }
            if (!npc.friendly && mplayer.bubble > 0 && Main.time % 60 == 0)
            {
                Player player = Main.player[npc.target];
                if ((npc.Center - player.Center).Length() < 200)
                {
                    for (int g = 0; g < 3; g++)
                    {
                        Vector2 v = new Vector2(0, Main.rand.NextFloat(4, 12)).RotatedByRandom(Math.PI * 2);
                        Projectile.NewProjectile(player.Center, v, Mod.Find<ModProjectile>("VoidBubble").Type, 150, 2, Main.myPlayer, 0f, 0f);
                    }
                }
            }
            if (MythWorld.Myth)
            {
                if (npc.type == 35/*骷髅王*/)
                {
                    if (npc.life <= 11000 && npc.life > 4400)
                    {
                        int num203 = Main.rand.Next(201);

                        int num202 = Main.rand.Next(2500);
                        if (num202 == 1 && NPC.CountNPCS(36) < 4)
                        {

                            Vector2 vector = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                            NPC.NewNPC((int)vector.X, (int)vector.Y, 36, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        if (Main.time % 480 == 0)
                        {
                            int num205 = Main.rand.Next(-250000, 250000);

                            Vector2 vector6 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);

                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205)) * 2, (float)(Math.Cos(num205)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 + 3.1415926535897932384626433832795f / 6)) * 2, (float)(Math.Cos(num205 + 3.1415926535897932384626433832795f / 6)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 + 3.1415926535897932384626433832795f / 3)) * 2, (float)(Math.Cos(num205 + 3.1415926535897932384626433832795f / 3)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 + 3.1415926535897932384626433832795f / 2)) * 2, (float)(Math.Cos(num205 + 3.1415926535897932384626433832795f / 2)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 + 3.1415926535897932384626433832795f / 1.5f)) * 2, (float)(Math.Cos(num205 + 3.1415926535897932384626433832795f / 1.5f)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 + 3.1415926535897932384626433832795f / 1.2f)) * 2, (float)(Math.Cos(num205 + 3.1415926535897932384626433832795f / 1.2f)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 - 3.1415926535897932384626433832795f)) * 2, (float)(Math.Cos(num205 - 3.1415926535897932384626433832795f)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 - 3.1415926535897932384626433832795f / 6)) * 2, (float)(Math.Cos(num205 - 3.1415926535897932384626433832795f / 6)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 - 3.1415926535897932384626433832795f / 3)) * 2, (float)(Math.Cos(num205 - 3.1415926535897932384626433832795f / 3)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 - 3.1415926535897932384626433832795f / 2)) * 2, (float)(Math.Cos(num205 - 3.1415926535897932384626433832795f / 2)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 - 3.1415926535897932384626433832795f / 1.5f)) * 2, (float)(Math.Cos(num205 - 3.1415926535897932384626433832795f / 1.5f)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 - 3.1415926535897932384626433832795f / 1.2f)) * 2, (float)(Math.Cos(num205 - 3.1415926535897932384626433832795f / 1.2f)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Vector2 vector7 = npc.Center;
                            float num23 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector7.X;
                            float num24 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector7.Y;
                            Math.Sqrt((double)(num23 * num23 + num24 * num24));
                            if (Collision.CanHit(vector7, 1, 1, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
                            {
                                float num25 = 7f;
                                float num26 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector7.X + (float)Main.rand.Next(-20, 21);
                                float num27 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector7.Y + (float)Main.rand.Next(-20, 21);
                                float num28 = (float)Math.Sqrt((double)(num26 * num26 + num27 * num27));
                                num28 = num25 / num28;
                                num26 *= num28;
                                num27 *= num28;
                                Vector2 vector8 = new Vector2(num26 * 1f + (float)Main.rand.Next(-50, 51) * 0.01f, num27 * 1f + (float)Main.rand.Next(-50, 51) * 0.01f);
                                vector8.Normalize();
                                vector8 *= num25;
                                vector8 += npc.velocity;
                                num26 = vector8.X;
                                num27 = vector8.Y;
                                int num29 = 48;
                                int num30 = 270;
                                vector7 += vector8 * 5f;
                                int num31 = Projectile.NewProjectile(vector7.X, vector7.Y, num26, num27, num30, num29, 0f, Main.myPlayer, -1f, 0f);
                                int num32 = Projectile.NewProjectile(vector7.X, vector7.Y, num26, num27, num30, num29, 0f, Main.myPlayer, -1f, 0f);
                                int num33 = Projectile.NewProjectile(vector7.X, vector7.Y, num26, num27, num30, num29, 0f, Main.myPlayer, -1f, 0f);
                                int num34 = Projectile.NewProjectile(vector7.X, vector7.Y, num26, num27, num30, num29, 0f, Main.myPlayer, -1f, 0f);
                                Main.projectile[num31].timeLeft = 300;
                                Main.projectile[num32].timeLeft = 300;
                                Main.projectile[num33].timeLeft = 300;
                                Main.projectile[num34].timeLeft = 300;
                            }
                        }
                        if (Main.time % 480 == 240)
                        {
                            for (int y = 0; y < 12; y++)
                            {
                                Vector2 v = new Vector2(0, 5).RotatedBy(Math.PI * y / 6f + Math.PI * 0.15f);
                                int num31 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, v.X, v.Y, 270, 40, 0f, Main.myPlayer, -1f, 0f);
                                Main.projectile[num31].hostile = true;
                                Main.projectile[num31].friendly = false;
                            }
                        }
                    }
                    if (npc.life <= 4400 && npc.life > 1100)
                    {
                        int num203 = Main.rand.Next(201);

                        int num202 = Main.rand.Next(2500);
                        if (num202 == 1 && NPC.CountNPCS(36) < 4)
                        {

                            Vector2 vector = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                            NPC.NewNPC((int)vector.X, (int)vector.Y, 36, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        if (Main.time % 240 == 0)
                        {
                            int num205 = Main.rand.Next(-250000, 250000);

                            Vector2 vector6 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);

                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205)) * 2, (float)(Math.Cos(num205)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 + 3.1415926535897932384626433832795f / 6)) * 2, (float)(Math.Cos(num205 + 3.1415926535897932384626433832795f / 6)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 + 3.1415926535897932384626433832795f / 3)) * 2, (float)(Math.Cos(num205 + 3.1415926535897932384626433832795f / 3)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 + 3.1415926535897932384626433832795f / 2)) * 2, (float)(Math.Cos(num205 + 3.1415926535897932384626433832795f / 2)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 + 3.1415926535897932384626433832795f / 1.5f)) * 2, (float)(Math.Cos(num205 + 3.1415926535897932384626433832795f / 1.5f)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 + 3.1415926535897932384626433832795f / 1.2f)) * 2, (float)(Math.Cos(num205 + 3.1415926535897932384626433832795f / 1.2f)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 - 3.1415926535897932384626433832795f)) * 2, (float)(Math.Cos(num205 - 3.1415926535897932384626433832795f)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 - 3.1415926535897932384626433832795f / 6)) * 2, (float)(Math.Cos(num205 - 3.1415926535897932384626433832795f / 6)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 - 3.1415926535897932384626433832795f / 3)) * 2, (float)(Math.Cos(num205 - 3.1415926535897932384626433832795f / 3)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 - 3.1415926535897932384626433832795f / 2)) * 2, (float)(Math.Cos(num205 - 3.1415926535897932384626433832795f / 2)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 - 3.1415926535897932384626433832795f / 1.5f)) * 2, (float)(Math.Cos(num205 - 3.1415926535897932384626433832795f / 1.5f)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 - 3.1415926535897932384626433832795f / 1.2f)) * 2, (float)(Math.Cos(num205 - 3.1415926535897932384626433832795f / 1.2f)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Vector2 vector7 = npc.Center;
                            float num23 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector7.X;
                            float num24 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector7.Y;
                            Math.Sqrt((double)(num23 * num23 + num24 * num24));
                            if (Collision.CanHit(vector7, 1, 1, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
                            {
                                float num25 = 7f;
                                float num26 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector7.X + (float)Main.rand.Next(-20, 21);
                                float num27 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector7.Y + (float)Main.rand.Next(-20, 21);
                                float num28 = (float)Math.Sqrt((double)(num26 * num26 + num27 * num27));
                                num28 = num25 / num28;
                                num26 *= num28;
                                num27 *= num28;
                                Vector2 vector8 = new Vector2(num26 * 1f + (float)Main.rand.Next(-50, 51) * 0.01f, num27 * 1f + (float)Main.rand.Next(-50, 51) * 0.01f);
                                vector8.Normalize();
                                vector8 *= num25;
                                vector8 += npc.velocity;
                                num26 = vector8.X;
                                num27 = vector8.Y;
                                int num29 = 48;
                                int num30 = 270;
                                vector7 += vector8 * 5f;
                                int num31 = Projectile.NewProjectile(vector7.X, vector7.Y, num26, num27, num30, num29, 0f, Main.myPlayer, -1f, 0f);
                                int num32 = Projectile.NewProjectile(vector7.X, vector7.Y, num26, num27, num30, num29, 0f, Main.myPlayer, -1f, 0f);
                                int num33 = Projectile.NewProjectile(vector7.X, vector7.Y, num26, num27, num30, num29, 0f, Main.myPlayer, -1f, 0f);
                                int num34 = Projectile.NewProjectile(vector7.X, vector7.Y, num26, num27, num30, num29, 0f, Main.myPlayer, -1f, 0f);
                                Main.projectile[num31].timeLeft = 300;
                                Main.projectile[num32].timeLeft = 300;
                                Main.projectile[num33].timeLeft = 300;
                                Main.projectile[num34].timeLeft = 300;
                            }
                        }
                        if (Main.time % 240 == 120)
                        {
                            for (int y = 0; y < 12; y++)
                            {
                                Vector2 v = new Vector2(0, 5).RotatedBy(Math.PI * y / 6f + Math.PI * 0.15f);
                                int num31 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, v.X, v.Y, 270, 40, 0f, Main.myPlayer, -1f, 0f);
                                Main.projectile[num31].hostile = true;
                                Main.projectile[num31].friendly = false;
                            }
                        }
                    }
                    if (npc.life <= 1100)
                    {
                        int num203 = Main.rand.Next(201);

                        int num202 = Main.rand.Next(2500);
                        if (num202 == 1 && NPC.CountNPCS(36) < 4)
                        {

                            Vector2 vector = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                            NPC.NewNPC((int)vector.X, (int)vector.Y, 36, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        if (Main.time % 120 == 0)
                        {
                            int num205 = Main.rand.Next(-250000, 250000);

                            Vector2 vector6 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);

                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205)) * 2, (float)(Math.Cos(num205)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 + 3.1415926535897932384626433832795f / 6)) * 2, (float)(Math.Cos(num205 + 3.1415926535897932384626433832795f / 6)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 + 3.1415926535897932384626433832795f / 3)) * 2, (float)(Math.Cos(num205 + 3.1415926535897932384626433832795f / 3)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 + 3.1415926535897932384626433832795f / 2)) * 2, (float)(Math.Cos(num205 + 3.1415926535897932384626433832795f / 2)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 + 3.1415926535897932384626433832795f / 1.5f)) * 2, (float)(Math.Cos(num205 + 3.1415926535897932384626433832795f / 1.5f)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 + 3.1415926535897932384626433832795f / 1.2f)) * 2, (float)(Math.Cos(num205 + 3.1415926535897932384626433832795f / 1.2f)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 - 3.1415926535897932384626433832795f)) * 2, (float)(Math.Cos(num205 - 3.1415926535897932384626433832795f)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 - 3.1415926535897932384626433832795f / 6)) * 2, (float)(Math.Cos(num205 - 3.1415926535897932384626433832795f / 6)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 - 3.1415926535897932384626433832795f / 3)) * 2, (float)(Math.Cos(num205 - 3.1415926535897932384626433832795f / 3)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 - 3.1415926535897932384626433832795f / 2)) * 2, (float)(Math.Cos(num205 - 3.1415926535897932384626433832795f / 2)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 - 3.1415926535897932384626433832795f / 1.5f)) * 2, (float)(Math.Cos(num205 - 3.1415926535897932384626433832795f / 1.5f)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(vector6.X, vector6.Y, (float)(Math.Sin(num205 - 3.1415926535897932384626433832795f / 1.2f)) * 2, (float)(Math.Cos(num205 - 3.1415926535897932384626433832795f / 1.2f)) * 2, 293, 44, 0f, Main.myPlayer, 0f, 0f);
                            Vector2 vector7 = npc.Center;
                            float num23 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector7.X;
                            float num24 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2) - vector7.Y;
                            Math.Sqrt((double)(num23 * num23 + num24 * num24));
                            if (Collision.CanHit(vector7, 1, 1, Main.player[npc.target].position, Main.player[npc.target].width, Main.player[npc.target].height))
                            {
                                float num25 = 7f;
                                float num26 = Main.player[npc.target].position.X + (float)Main.player[npc.target].width * 0.5f - vector7.X + (float)Main.rand.Next(-20, 21);
                                float num27 = Main.player[npc.target].position.Y + (float)Main.player[npc.target].height * 0.5f - vector7.Y + (float)Main.rand.Next(-20, 21);
                                float num28 = (float)Math.Sqrt((double)(num26 * num26 + num27 * num27));
                                num28 = num25 / num28;
                                num26 *= num28;
                                num27 *= num28;
                                Vector2 vector8 = new Vector2(num26 * 1f + (float)Main.rand.Next(-50, 51) * 0.01f, num27 * 1f + (float)Main.rand.Next(-50, 51) * 0.01f);
                                vector8.Normalize();
                                vector8 *= num25;
                                vector8 += npc.velocity;
                                num26 = vector8.X;
                                num27 = vector8.Y;
                                int num29 = 48;
                                int num30 = 270;
                                vector7 += vector8 * 5f;
                                int num31 = Projectile.NewProjectile(vector7.X, vector7.Y, num26, num27, num30, num29, 0f, Main.myPlayer, -1f, 0f);
                                int num32 = Projectile.NewProjectile(vector7.X, vector7.Y, num26, num27, num30, num29, 0f, Main.myPlayer, -1f, 0f);
                                int num33 = Projectile.NewProjectile(vector7.X, vector7.Y, num26, num27, num30, num29, 0f, Main.myPlayer, -1f, 0f);
                                int num34 = Projectile.NewProjectile(vector7.X, vector7.Y, num26, num27, num30, num29, 0f, Main.myPlayer, -1f, 0f);
                                Main.projectile[num31].timeLeft = 300;
                                Main.projectile[num32].timeLeft = 300;
                                Main.projectile[num33].timeLeft = 300;
                                Main.projectile[num34].timeLeft = 300;
                            }
                        }
                        if (Main.time % 120 == 60)
                        {
                            for (int y = 0; y < 12; y++)
                            {
                                Vector2 v = new Vector2(0, 6).RotatedBy(Math.PI * y / 6f + Math.PI * 0.15f);
                                int num31 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, v.X, v.Y, 270, 40, 0f, Main.myPlayer, -1f, 0f);
                                Main.projectile[num31].hostile = true;
                                Main.projectile[num31].friendly = false;
                            }
                        }
                    }
                }
                if (npc.type == 439/*邪教徒*/)
                {
                    Player player = Main.player[npc.target];
                    if (MythWorld.MythIndex < 2)
                    {
                        if (npc.life < npc.lifeMax * 0.66f && NPC.CountNPCS(Mod.Find<ModNPC>("AncientFire").Type) < 1)
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, Mod.Find<ModNPC>("AncientFire").Type, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        if (npc.life < npc.lifeMax * 0.33f && NPC.CountNPCS(Mod.Find<ModNPC>("AncientShadow").Type) < 1)
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, Mod.Find<ModNPC>("AncientShadow").Type, 0, 0f, 0f, 0f, 0f, 255);
                        }
                    }
                    if (MythWorld.MythIndex == 2)
                    {
                        if (npc.life < npc.lifeMax * 0.66f && NPC.CountNPCS(Mod.Find<ModNPC>("AncientFire").Type) < 1)
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, Mod.Find<ModNPC>("AncientFire").Type, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        if (npc.life < npc.lifeMax * 0.33f && NPC.CountNPCS(Mod.Find<ModNPC>("AncientFire").Type) < 2)
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, Mod.Find<ModNPC>("AncientFire").Type, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        if (npc.life < npc.lifeMax * 0.33f && NPC.CountNPCS(Mod.Find<ModNPC>("AncientShadow").Type) < 1)
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, Mod.Find<ModNPC>("AncientShadow").Type, 0, 0f, 0f, 0f, 0f, 255);
                        }
                    }
                    if (MythWorld.MythIndex >= 3)
                    {
                        if (npc.life < npc.lifeMax * 0.66f && NPC.CountNPCS(Mod.Find<ModNPC>("AncientFire").Type) < 1)
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, Mod.Find<ModNPC>("AncientFire").Type, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        if (npc.life < npc.lifeMax * 0.33f && NPC.CountNPCS(Mod.Find<ModNPC>("AncientFire").Type) < 2)
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, Mod.Find<ModNPC>("AncientFire").Type, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        if (npc.life < npc.lifeMax * 0.1f && NPC.CountNPCS(Mod.Find<ModNPC>("AncientFire").Type) < 4)
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, Mod.Find<ModNPC>("AncientFire").Type, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        if (npc.life < npc.lifeMax * 0.66f && NPC.CountNPCS(Mod.Find<ModNPC>("AncientShadow").Type) < 1)
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, Mod.Find<ModNPC>("AncientShadow").Type, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        if (npc.life < npc.lifeMax * 0.33f && NPC.CountNPCS(Mod.Find<ModNPC>("AncientShadow").Type) < 2)
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, Mod.Find<ModNPC>("AncientShadow").Type, 0, 0f, 0f, 0f, 0f, 255);
                        }
                    }
                }
                if (npc.type == 262/*世纪之花*/)
                {
                    Player player = Main.player[npc.target];
                    Vector2 vector = new Vector2(npc.Center.X, npc.Center.Y);
                    Vector2 center = npc.Center;
                    float num = player.Center.X - vector.X;
                    float num2 = player.Center.Y - vector.Y;
                    float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
                    Vector2 vector3 = new Vector2(num, num2) / num3;
                    if (npc.life >= npc.lifeMax * 0.5)
                    {
                        if (npc.life <= npc.lifeMax * 0.8)
                        {
                            if ((int)(Main.time) % 180 == 0)
                            {
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector3.X * 6f, vector3.Y * 6f, base.Mod.Find<ModProjectile>("花刺").Type, 25, 0f, Main.myPlayer, 0f, 0f);
                            }
                            if ((int)(Main.time) % 180 == 90)
                            {
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector3.X * 4f, vector3.Y * 4f, base.Mod.Find<ModProjectile>("GreenThornBalll").Type, 40, 0.5f, Main.myPlayer, 0f, 0f);
                            }
                        }
                    }
                    if (npc.life < npc.lifeMax * 0.5)
                    {
                        if (npc.life <= npc.lifeMax * 0.8)
                        {
                            if ((int)(Main.time) % 900 == 0)
                            {
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vector3.X * 4f, vector3.Y * 4f, base.Mod.Find<ModProjectile>("PoisonSeed").Type, 40, 0.5f, Main.myPlayer, 0f, 0f);
                            }
                        }
                    }
                }
                if (npc.type == 398/*月总*/)
                {
                    if(!npc.dontTakeDamage)
                    {
                        num1 += 1;
                    }
                    else
                    {
                        num1 = 0;
                    }
                    if(num1 % 900 == 1)
                    {
                        Vector2 v = new Vector2(0, 350).RotatedByRandom(MathHelper.TwoPi);
                        for (int i = 0;i < 4;i++)
                        {
                            v = v.RotatedBy(Math.PI * 2 * i / 4);
                            Projectile.NewProjectile(npc.Center.X + v.X, npc.Center.Y + v.Y, v.Y / 100f, v.X / 100f, 465, 50, 0.5f, Main.myPlayer, 0f, 0f);
                        }
                    }
                    if (num1 % 900 == 451)
                    {
                        int deltaX = -400;
                        for (int i = 0; i < 40; i++)
                        {
                            deltaX += 20;
                            Projectile.NewProjectile(npc.Center.X + deltaX + Main.rand.Next(-30,30), npc.Center.Y - 800 - deltaX + Main.rand.Next(-300, 300), 0, 12, Mod.Find<ModProjectile>("月炎流火").Type, 50, 0.5f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                if (npc.type == 370/*猪鲨*/)
                {
                    Player player = Main.player[npc.target];
                    if (npc.life < npc.lifeMax * 0.5)
                    {
                        if ((int)(Main.time) % 900 == 0)
                        {
                            Projectile.NewProjectile(player.Center.X - 500, player.Center.Y, 0, 0, Mod.Find<ModProjectile>("WINDRelief").Type, 0, 0, Main.myPlayer, 0, 0);
                            Projectile.NewProjectile(player.Center.X + 500, player.Center.Y, 0, 0, Mod.Find<ModProjectile>("WINDRelief").Type, 0, 0, Main.myPlayer, 0, 0);
                            Projectile.NewProjectile(player.Center.X - 1100, player.Center.Y, 0, 0, Mod.Find<ModProjectile>("WINDRelief").Type, 0, 0, Main.myPlayer, 0, 0);
                            Projectile.NewProjectile(player.Center.X + 1100, player.Center.Y, 0, 0, Mod.Find<ModProjectile>("WINDRelief").Type, 0, 0, Main.myPlayer, 0, 0);
                        }
                        if (npc.velocity.Length() >= 3 && Main.rand.Next(10) == 1)
                        {
                            NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, 371, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        Vector2 v = new Vector2(0, Main.rand.Next(0, 900) / 1000f).RotatedByRandom(Math.PI * 2);
                        if (player.Center.Y >= mplayer.Cloud - 600)
                        {
                            if (Main.rand.Next(3) == 1)
                            {
                                Projectile.NewProjectile(player.Center.X + Main.rand.Next(-1000, 1000), mplayer.Cloud - 800 + Main.rand.Next(-800, 200), v.X, v.Y, Mod.Find<ModProjectile>("Mist").Type, 0, 0, Main.myPlayer, 0, 0);
                            }
                        }
                        else
                        {
                            if (Main.rand.Next(3) == 1)
                            {
                                Projectile.NewProjectile(player.Center.X + Main.rand.Next(-1000, 1000), player.Center.Y + Main.rand.Next(-800, 800), v.X, v.Y, Mod.Find<ModProjectile>("Mist").Type, 0, 0, Main.myPlayer, 0, 0);
                            }
                        }
                    }
                }
                if (npc.type == 125 && npc.life <= 15000 && NPC.CountNPCS(Mod.Find<ModNPC>("LaserEyeS").Type) < 1/*双子*/)
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, Mod.Find<ModNPC>("LaserEyeS").Type, 0, 0f, 0f, 0f, 0f, 255);
                }
                if (npc.type == 126 && npc.life <= 17500 && NPC.CountNPCS(Mod.Find<ModNPC>("CurseEyeS").Type) < 1/*双子*/)
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, Mod.Find<ModNPC>("CurseEyeS").Type, 0, 0f, 0f, 0f, 0f, 255);
                }
                if (npc.type == 222/*蜂王*/)
                {
                    Player player = Main.player[npc.target];
                    int pro = 0;
                    for (int m = 0; m < 600; m++)
                    {
                        if (Main.projectile[m].type == 55 && (Main.projectile[m].Center - npc.Center).Length() <= 50f)
                        {
                            pro++;
                        }
                    }
                    if (pro >= 1 && npc.frame.Y >= 488 && Main.time % 4 == 0)
                    {
                        Vector2 v = new Vector2(-npc.Center.X, -npc.Center.Y - 20f) + player.Center;
                        v = (v / v.Length() * 8f).RotatedBy(Main.rand.NextFloat(-0.25f, 0.25f));
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 20f, v.X, v.Y, 55, 40, 2f, Main.myPlayer, 0f, 0f);
                    }
                    if (npc.life < npc.lifeMax * 0.8f && npc.life >= npc.lifeMax * 0.4f)
                    {
                        if (Math.Abs(npc.velocity.Y) < 2f && Math.Abs(npc.velocity.X) > 8f && Math.Abs(npc.velocity.X) < 25f && (player.Center - npc.Center).Length() <= 800f && npc.frame.Y < 488)
                        {
                            npc.velocity.X *= 1.05f;
                        }
                    }
                    if (npc.life < npc.lifeMax * 0.4f && npc.life >= npc.lifeMax * 0.1f)
                    {
                        if (Math.Abs(npc.velocity.Y) < 2f && Math.Abs(npc.velocity.X) > 8f && Math.Abs(npc.velocity.X) < 35f && (player.Center - npc.Center).Length() <= 800f && npc.frame.Y < 488)
                        {
                            npc.velocity.X *= 1.09f;
                        }
                    }
                    if (npc.life < npc.lifeMax * 0.1f)
                    {
                        if (Math.Abs(npc.velocity.Y) < 2f && Math.Abs(npc.velocity.X) > 8f && Math.Abs(npc.velocity.X) < 45f && (player.Center - npc.Center).Length() <= 800f && npc.frame.Y < 488)
                        {
                            npc.velocity.X *= 1.14f;
                        }
                    }
                    if (npc.velocity.Length() >= 5f)
                    {
                        npc.alpha = (int)(npc.velocity.Length() - 5f) * 5;
                    }
                }
                if (npc.type == 267 && MythWorld.Myth/*克脑*/)
                {
                    int num4008 = Main.rand.Next(0, (int)30 * NPC.CountNPCS(267));
                    if (num4008 == 1)
                    {
                        Player player = Main.player[npc.target];
                        float num4009 = 8f;
                        Vector2 vector5 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        Vector2 v = new Vector2(player.Center.X - vector5.X, player.Center.Y - vector5.Y);
                        v = v / v.Length() * 6f;
                        int num4016 = Projectile.NewProjectile(vector5.X, vector5.Y, v.X, v.Y - 5f, 288, 22, 2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num4016].timeLeft = 600;
                        Main.projectile[num4016].tileCollide = true;
                        if (MythWorld.MythIndex >= 2)
                        {
                            v = v.RotatedBy(Math.PI * Main.rand.NextFloat(-0.3f, 0.3f)) * Main.rand.NextFloat(0.8f, 1.2f);
                            int num4017 = Projectile.NewProjectile(vector5.X, vector5.Y, v.X, v.Y - 5f, 288, 22, 2f, Main.myPlayer, 0f, 0f);
                            Main.projectile[num4017].timeLeft = 600;
                            Main.projectile[num4017].tileCollide = true;
                            if (MythWorld.MythIndex >= 3)
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    v = v.RotatedBy(Math.PI * Main.rand.NextFloat(-0.3f, 0.3f)) * Main.rand.NextFloat(0.8f, 1.2f);
                                    int num4018 = Projectile.NewProjectile(vector5.X, vector5.Y, v.X, v.Y - 5f, 288, 22, 2f, Main.myPlayer, 0f, 0f);
                                    Main.projectile[num4018].timeLeft = 600;
                                    Main.projectile[num4018].tileCollide = true;
                                }
                            }
                        }
                    }
                }
                if (npc.type == 113 && MythWorld.Myth/*肉山*/)
                {
                    Player player = Main.player[npc.target];
                    if (MythWorld.MythIndex == 1)
                    {
                        if (npc.life < 2001 && npc.life > 1500 && npc.velocity.X > 0)
                        {
                            npc.velocity.X = 7f;
                        }
                        if (npc.life < 1501 && npc.life > 1300 && npc.velocity.X > 0)
                        {
                            npc.velocity.X = 8f;
                        }
                        if (npc.life < 1301 && npc.life > 1000 && npc.velocity.X > 0)
                        {
                            npc.velocity.X = 10f;
                        }
                        if (npc.life < 1001 && npc.life > 800 && npc.velocity.X > 0)
                        {
                            npc.velocity.X = 12f;
                        }
                        if (npc.life < 800 && npc.velocity.X > 0)
                        {
                            npc.velocity.X = 14f;
                        }
                        if (npc.life < 2001 && npc.life > 1500 && npc.velocity.X < 0)
                        {
                            npc.velocity.X = -7f;
                        }
                        if (npc.life < 1501 && npc.life > 1300 && npc.velocity.X < 0)
                        {
                            npc.velocity.X = -8f;
                        }
                        if (npc.life < 1301 && npc.life > 1000 && npc.velocity.X < 0)
                        {
                            npc.velocity.X = -10f;
                        }
                        if (npc.life < 1001 && npc.life > 800 && npc.velocity.X < 0)
                        {
                            npc.velocity.X = -12f;
                        }
                        if (npc.life < 800 && npc.velocity.X < 0)
                        {
                            npc.velocity.X = -14f;
                        }
                    }
                    else if (MythWorld.MythIndex == 2)
                    {
                        if (npc.velocity.X > 0)
                        {
                            npc.velocity.X = ((20160 - npc.life) / (float)npc.lifeMax) * 17 + 4;
                        }
                        else
                        {
                            npc.velocity.X = -(((20160 - npc.life) / (float)npc.lifeMax) * 17 + 4);
                        }
                    }
                    else if (MythWorld.MythIndex >= 3)
                    {
                        if (npc.velocity.X > 0)
                        {
                            npc.velocity.X = ((30239 - npc.life) / (float)npc.lifeMax) * 24 + 5;
                        }
                        else
                        {
                            npc.velocity.X = -(((30239 - npc.life) / (float)npc.lifeMax) * 24 + 5);
                        }
                    }
                    if ((player.Center - npc.Center).Length() > 1000f)
                    {
                        if (Main.rand.Next(150) == 1)
                        {
                            NPC.NewNPC((int)(player.Center.X + npc.velocity.X * 1000f), (int)player.Center.Y - 150, Mod.Find<ModNPC>("DiscleanEgg").Type, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        if (Main.rand.Next(150) == 1)
                        {
                            NPC.NewNPC((int)(player.Center.X + Main.rand.Next(-100, 100)), (int)player.Center.Y - 750, Mod.Find<ModNPC>("DiscleanEgg").Type, 0, 0f, 0f, 0f, 0f, 255);
                        }
                    }
                    num90 += 1;
                    if(num90 == 1800)
                    {
                        Vector2 V = new Vector2(npc.Center.X * 2 - player.Center.X, player.Center.Y) / 16f;
                        if (!Main.tile[(int)V.X, (int)V.Y].HasTile && !Main.tile[(int)V.X + 1, (int)V.Y].HasTile && !Main.tile[(int)V.X - 1, (int)V.Y].HasTile && !Main.tile[(int)V.X + 1, (int)V.Y + 1].HasTile && !Main.tile[(int)V.X + 1, (int)V.Y - 1].HasTile && !Main.tile[(int)V.X - 1, (int)V.Y + 1].HasTile && !Main.tile[(int)V.X - 1, (int)V.Y - 1].HasTile)
                        {
                            player.position = V * 16f;
                            npc.velocity *= -1;
                        }
                        num90 = 0;
                    }
                }
                if (npc.type == 115/*饿鬼*/)
                {
                    Player player = Main.player[npc.target];
                    for (int u = 0; u < 200; u++)
                    {
                        if (Main.npc[u].type == 113 && (Main.npc[u].Center - player.Center).Length() < (npc.Center - player.Center).Length() + 400 && npc.Center.X * Main.npc[u].velocity.X / Math.Abs(Main.npc[u].velocity.X) - player.Center.X * Main.npc[u].velocity.X / Math.Abs(Main.npc[u].velocity.X) < 0)
                        {
                            npc.velocity += Main.npc[u].velocity * 0.25f;
                        }
                    }
                }
                if (npc.type == 128 && MythWorld.Myth/*机械装置*/)
                {
                    npc.localAI[1] += 1;
                    if (npc.localAI[1] % 300 == 0)
                    {
                        for (int k = 0; k < 26; k++)
                        {
                            Vector2 V = new Vector2(0, 5).RotatedByRandom(Math.PI * 2) * Main.rand.Next(-10000, 10000) / 10000f;
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, V.X, V.Y - 5f, 102, 70, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                if (npc.type == 131 && MythWorld.Myth/*机械装置*/)
                {
                    Player player = Main.player[npc.target];
                    npc.localAI[1] += 1;
                    if (npc.localAI[1] % 300 == 0)
                    {
                        for (int k = 0; k < 5; k++)
                        {
                            Vector2 V = (player.Center - npc.Center).RotatedBy((k - 3) / 30f * Math.PI) * (9 / (player.Center - npc.Center).Length());
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, V.X, V.Y, 100, 70, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                if (npc.type == 127 && MythWorld.Myth/*机械骷髅*/)
                {
                    Player player = Main.player[npc.target];
                    if (npc.life < npc.lifeMax / 2 && num87)
                    {
                        num76 += num82;
                        num88 += 1;
                        num89 += 1;
                        if (num74)
                        {
                            num74 = false;
                            num75 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("骷髅守护粒子").Type, 70, 0f, Main.myPlayer, 0f, 0f);
                            num77 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("骷髅守护粒子").Type, 70, 0f, Main.myPlayer, 0f, 0f);
                            num78 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("骷髅守护粒子").Type, 70, 0f, Main.myPlayer, 0f, 0f);
                            num79 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("骷髅守护粒子").Type, 70, 0f, Main.myPlayer, 0f, 0f);
                            num81 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("骷髅守护粒子").Type, 70, 0f, Main.myPlayer, 0f, 0f);
                            num83 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, Mod.Find<ModNPC>("PriSkeHurt").Type, 0, 0f, 0f, 0f, 0f, 255);
                            num84 = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, Mod.Find<ModNPC>("PriSkeHurt").Type, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        Vector3 vector20 = new Vector3((float)Math.Sin(Math.PI / 600f * num76) * 100f, (float)Math.Sin(Math.PI / 400f * num88) * 25f, (float)Math.Cos(Math.PI / 600f * num76) * 100f);
                        Vector3 vector21 = new Vector3(-(float)Math.Sin(Math.PI / 600f * num76) * 100f, (float)Math.Sin(Math.PI / 400f * num88) * 25f, -(float)Math.Cos(Math.PI / 600f * num76) * 100f);
                        Vector3 vector22 = new Vector3(-(float)Math.Cos(Math.PI / 600f * num76) * 100f, (float)Math.Sin(Math.PI / 400f * num88) * 25f, (float)Math.Sin(Math.PI / 600f * num76) * 100f);
                        Vector3 vector23 = new Vector3((float)Math.Cos(Math.PI / 600f * num76) * 100f, (float)Math.Sin(Math.PI / 400f * num88) * 25f, -(float)Math.Sin(Math.PI / 600f * num76) * 100f);
                        num82 += (npc.life - Main.npc[num83].life) / 250f;
                        Main.npc[num83].life = npc.life;
                        num82 -= (npc.life - Main.npc[num84].life) / 250f;
                        Main.npc[num84].life = npc.life;
                        if (Math.Abs(num82) < 50)
                        {
                            Main.projectile[num75].Center = new Vector2(vector20.X, vector20.Y + vector20.Z / 2f).RotatedBy((float)Math.Sin(Math.PI / 300f * num89) / 3f) + npc.Center + new Vector2((float)(Math.Sin(Math.PI / 300f * num89) * 35f), 0);
                            Main.projectile[num77].Center = new Vector2(vector21.X, vector21.Y + vector21.Z / 2f).RotatedBy((float)Math.Sin(Math.PI / 300f * num89) / 3f) + npc.Center + new Vector2((float)(Math.Sin(Math.PI / 300f * num89) * 35f), 0);
                            Main.projectile[num78].Center = new Vector2(vector22.X, vector22.Y + vector22.Z / 2f).RotatedBy((float)Math.Sin(Math.PI / 300f * num89) / 3f) + npc.Center + new Vector2((float)(Math.Sin(Math.PI / 300f * num89) * 35f), 0);
                            Main.projectile[num79].Center = new Vector2(vector23.X, vector23.Y + vector23.Z / 2f).RotatedBy((float)Math.Sin(Math.PI / 300f * num89) / 3f) + npc.Center + new Vector2((float)(Math.Sin(Math.PI / 300f * num89) * 35f), 0);
                            Main.projectile[num75].scale = 1 * (1 + vector20.Z / 300f);
                            Main.projectile[num77].scale = 1 * (1 + vector21.Z / 300f);
                            Main.projectile[num78].scale = 1 * (1 + vector22.Z / 300f);
                            Main.projectile[num79].scale = 1 * (1 + vector23.Z / 300f);
                            Main.projectile[num81].Center = new Vector2(0, 120 + (float)Math.Sin(Math.PI / 400f * num88) * 25f) + npc.Center;
                            Main.npc[num83].position = npc.Center;
                            Main.npc[num84].position = npc.Center - new Vector2(40, 0);
                        }
                        if (NPC.CountNPCS(Mod.Find<ModNPC>("PriSkeHurt").Type) > 0)
                        {
                            npc.dontTakeDamage = true;
                        }                        
                        if (Math.Abs(num82) > 50)
                        {
                            num85 += 1;
                            num82 = 51;
                            Main.projectile[num75].scale *= 0.98f;
                            Main.projectile[num77].scale *= 0.98f;
                            Main.projectile[num78].scale *= 0.98f;
                            Main.projectile[num79].scale *= 0.98f;
                            Main.projectile[num81].scale *= 0.98f;
                            if (Main.npc[num83].type == Mod.Find<ModNPC>("PriSkeHurt").Type)
                            {
                                Main.npc[num83].active = false;
                            }
                            if (Main.npc[num84].type == Mod.Find<ModNPC>("PriSkeHurt").Type)
                            {
                                Main.npc[num84].active = false;
                            }
                            Main.projectile[num75].Center = new Vector2(vector20.X, vector20.Y + vector20.Z / 2f) + npc.Center;
                            Main.projectile[num77].Center = new Vector2(vector21.X, vector21.Y + vector21.Z / 2f) + npc.Center;
                            Main.projectile[num78].Center = new Vector2(vector22.X, vector22.Y + vector22.Z / 2f) + npc.Center;
                            Main.projectile[num79].Center = new Vector2(vector23.X, vector23.Y + vector23.Z / 2f) + npc.Center;
                            Main.projectile[num81].Center = new Vector2(0, 120) + npc.Center;
                            Main.npc[num83].position = npc.Center;
                            Main.npc[num84].position = npc.Center - new Vector2(40, 0);
                        }
                        if (num85 >= 120 && num86)
                        {
                            num87 = false;
                            num86 = false;
                            Main.projectile[num75].active = false;
                            Main.projectile[num77].active = false;
                            Main.projectile[num78].active = false;
                            Main.projectile[num79].active = false;
                            Main.projectile[num81].active = false;
                            Main.projectile[num75].timeLeft = 0;
                            Main.projectile[num77].timeLeft = 0;
                            Main.projectile[num78].timeLeft = 0;
                            Main.projectile[num79].timeLeft = 0;
                            Main.projectile[num81].timeLeft = 0;
                            npc.dontTakeDamage = false;
                            num85 = 121;
                        }
                    }
                    if (NPC.CountNPCS(128) + NPC.CountNPCS(129) + NPC.CountNPCS(130) + NPC.CountNPCS(131) > 0)
                    {
                        npc.defense = 160;
                    }
                    else
                    {
                        npc.defense = 24;
                        num91 += 1;
                        if (num91 % 60 == 0 && num91 < 600)
                        {
                            for (int z = 0; z < 20; z++)
                            {
                                Vector2 v = new Vector2(0, Main.rand.Next(45, 650)).RotatedByRandom(Math.PI * 2);
                                Projectile.NewProjectile(player.Center.X + v.X, player.Center.Y + v.Y, 0, 0, Mod.Find<ModProjectile>("RedLazerBall").Type, 0, 0f, Main.myPlayer, 0f, 0f);
                            }
                        }
                        if (num91 > 600 && num91 < 1200)
                        {
                            if (num91 % 75 < 15)
                            {
                                Vector2 v = (player.Center - npc.Center).RotatedBy((num91 % 75 - 7.5d) / 5d) / (player.Center - npc.Center).Length() * 15f;
                                Projectile.NewProjectile(npc.Center.X + v.X * 5, npc.Center.Y + v.Y * 5, 0, 0, Mod.Find<ModProjectile>("RedLazerBall2").Type, 0, 0f, Main.myPlayer, v.X, v.Y);
                            }
                        }
                        if (num91 > 1200 && num91 < 1800)
                        {
                            if (num91 % 5 == 1)
                            {
                                Vector2 v0 = new Vector2(0, Main.rand.Next(45, 650)).RotatedByRandom(Math.PI * 2);
                                Vector2 v1 = -v0.RotatedBy(Main.rand.NextFloat(-0.15f, 0.15f)) / v0.Length() * 15f;
                                Projectile.NewProjectile(player.Center.X + v0.X, player.Center.Y + v0.Y, 0, 0, Mod.Find<ModProjectile>("RedLazerBall2").Type, 0, 0f, Main.myPlayer, v1.X, v1.Y);
                            }
                        }
                        if (num91 >= 1799 && num91 < 2400)
                        {
                            Vector2 v = new Vector2(0, 400);
                            if (num91 % 75 < 15)
                            {
                                Vector2 v1 = v.RotatedBy((num91 % 75 - 7.5) / 22.5d * Math.PI);
                                Vector2 v2 = -v1.RotatedBy(0.4) / v1.Length() * 15;
                                Projectile.NewProjectile(player.Center.X + v1.X, player.Center.Y + v1.Y, 0, 0, Mod.Find<ModProjectile>("RedLazerBall2").Type, 0, 0f, Main.myPlayer, v2.X, v2.Y);
                                v1 = v.RotatedBy((num91 % 75 - 7.5) / 22.5d * Math.PI + Math.PI * 0.66666666667);
                                v2 = -v1.RotatedBy(0.4) / v1.Length() * 15;
                                Projectile.NewProjectile(player.Center.X + v1.X, player.Center.Y + v1.Y, 0, 0, Mod.Find<ModProjectile>("RedLazerBall2").Type, 0, 0f, Main.myPlayer, v2.X, v2.Y);
                                v1 = v.RotatedBy((num91 % 75 - 7.5) / 22.5d * Math.PI + Math.PI * 1.33333333333);
                                v2 = -v1.RotatedBy(0.4) / v1.Length() * 15;
                                Projectile.NewProjectile(player.Center.X + v1.X, player.Center.Y + v1.Y, 0, 0, Mod.Find<ModProjectile>("RedLazerBall2").Type, 0, 0f, Main.myPlayer, v2.X, v2.Y);
                            }
                        }
                        if (num91 > 2400 && num91 < 3200)
                        {
                            if (num91 % 75 < 30)
                            {
                                Vector2 v = new Vector2((num91 % 75 - 15) * 80, -200 + (float)Math.Sin(player.velocity.Length()) * 100f);
                                Projectile.NewProjectile(npc.Center.X + v.X + player.velocity.X * 15f, npc.Center.Y + v.Y + player.velocity.Y * 15f, 0, 0, Mod.Find<ModProjectile>("RedLazerBall2").Type, 0, 0f, Main.myPlayer, 0, 15);
                            }
                        }
                        if (num91 > 3200 && num91 < 3600)
                        {
                            if (num91 % 10 == 0)
                            {
                                Vector2 v = new Vector2(0, Main.rand.NextFloat(15, 500)).RotatedByRandom(Math.PI * 2);
                                Vector2 vv = new Vector2(0, Main.rand.NextFloat(35, 50)).RotatedByRandom(Math.PI * 2);
                                float theta = Main.rand.NextFloat(0f, 100.5f);
                                for (int y = 0; y < 5; y++)
                                {
                                    Vector2 vvv = vv.RotatedBy(Math.PI * y / 2.5);
                                    Vector2 vvvv = -vvv / vvv.Length() * 15f;
                                    Projectile.NewProjectile(npc.Center.X + v.X + vvv.X, npc.Center.Y + v.Y + vvv.Y, 0, 0, Mod.Find<ModProjectile>("RedLazerBall2").Type, 0, 0f, Main.myPlayer, vvvv.X, vvvv.Y);
                                }
                            }
                        }
                        if (num91 > 3600)
                        {
                            num91 = 0;
                        }
                        if (npc.life < npc.lifeMax / 3f)
                        {
                            num92 += 1;
                            if (num92 % 60 == 0 && num92 < 3600)
                            {
                                for (int z = 0; z < 20; z++)
                                {
                                    Vector2 v = new Vector2(0, Main.rand.Next(45, 650)).RotatedByRandom(Math.PI * 2);
                                    Projectile.NewProjectile(player.Center.X + v.X, player.Center.Y + v.Y, 0, 0, Mod.Find<ModProjectile>("RedCircle").Type, 0, 0f, Main.myPlayer, 0f, 0f);
                                }
                            }
                            if (num92 > 3600)
                            {
                                num92 = 0;
                            }
                        }
                        /*if (npc.life < npc.lifeMax / 4f)
                        {
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("ShieldOfSke1"), 0, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("ShieldOfSke2"), 0, 0f, Main.myPlayer, 0f, 0f);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("ShieldOfSke3"), 0, 0f, Main.myPlayer, 0f, 0f);
                        }*/
                    }
                }
                if (npc.type == 266 && MythWorld.Myth/*克脑*/)
                {
                    num58++;
                    npc.knockBackResist = (float)(npc.knockBackResist * 0.8f);
                    if (Main.netMode != 1 && npc.life <= 1500)
                    {
                        int num220 = Main.rand.Next(250);
                    }
                    if (npc.life < 800 && Boc == true)
                    {
                        for (int k = 0; k < 26; k++)
                        {
                            Vector2 vector = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                            float num3 = (float)((float)k * 13 * Math.PI);
                        }
                        Boc = false;
                    }
                    if (!npc.dontTakeDamage && KSLZN && MythWorld.MythIndex >= 2)
                    {
                        for (int m = 0; m < 4; m++)
                        {
                            Vector2 vector = npc.Center + new Vector2(0, Main.rand.NextFloat(300, 800)).RotatedByRandom(Math.PI * 2);
                            NPC.NewNPC((int)vector.X, (int)vector.Y, Mod.Find<ModNPC>("PhantomBrain").Type, 0, 0f, 0f, 0f, 0f, 255);
                        }
                        KSLZN = false;
                    }
                    if (npc.life < 4000)
                    {
                        Player player = Main.player[npc.target];
                        if (num54)
                        {
                            num54 = false;
                            num53 = Projectile.NewProjectile(player.Center.X, player.Center.Y - (float)Math.Abs(npc.Center.Y - player.Center.Y) / 2f, 0, 0, base.Mod.Find<ModProjectile>("克苏鲁之脑镜像").Type, 0, 0f, Main.myPlayer, 0f, 0f);
                            num55 = Projectile.NewProjectile(player.Center.X, player.Center.Y + (float)Math.Abs(npc.Center.Y - player.Center.Y) / 2f, 0, 0, base.Mod.Find<ModProjectile>("克苏鲁之脑镜像").Type, 0, 0f, Main.myPlayer, 0f, 0f);
                            num56 = Projectile.NewProjectile(player.Center.X - (float)Math.Abs(npc.Center.X - player.Center.X) / 2f, player.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("克苏鲁之脑镜像").Type, 0, 0f, Main.myPlayer, 0f, 0f);
                            num57 = Projectile.NewProjectile(player.Center.X + (float)Math.Abs(npc.Center.X - player.Center.X) / 2f, player.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("克苏鲁之脑镜像").Type, 0, 0f, Main.myPlayer, 0f, 0f);
                            num59 = Projectile.NewProjectile(player.Center.X - (float)Math.Abs(npc.Center.X - player.Center.X) / 2f, player.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("克苏鲁之脑镜像").Type, 0, 0f, Main.myPlayer, 0f, 0f);
                            num62 = Projectile.NewProjectile(player.Center.X + (float)Math.Abs(npc.Center.X - player.Center.X) / 2f, player.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("克苏鲁之脑镜像").Type, 0, 0f, Main.myPlayer, 0f, 0f);
                            num63 = Projectile.NewProjectile(player.Center.X - (float)Math.Abs(npc.Center.X - player.Center.X) / 2f, player.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("克苏鲁之脑镜像").Type, 0, 0f, Main.myPlayer, 0f, 0f);
                            num64 = Projectile.NewProjectile(player.Center.X + (float)Math.Abs(npc.Center.X - player.Center.X) / 2f, player.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("克苏鲁之脑镜像").Type, 0, 0f, Main.myPlayer, 0f, 0f);
                            num65 = Projectile.NewProjectile(player.Center.X - (float)Math.Abs(npc.Center.X - player.Center.X) / 2f, player.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("克苏鲁之脑镜像").Type, 0, 0f, Main.myPlayer, 0f, 0f);
                            num66 = Projectile.NewProjectile(player.Center.X + (float)Math.Abs(npc.Center.X - player.Center.X) / 2f, player.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("克苏鲁之脑镜像").Type, 0, 0f, Main.myPlayer, 0f, 0f);
                        }
                        Main.projectile[num53].position.X = player.Center.X - 100f;
                        Main.projectile[num53].position.Y = player.Center.Y - (float)Math.Abs(npc.Center.Y - player.Center.Y) / 1.45f - 91f;
                        Main.projectile[num53].alpha = (255 - (3000 - npc.life) / 7) * (npc.alpha / 255 + 1);
                        //string key = Main.projectile[num53].alpha.ToString();
                        //Color messageColor = Color.Purple;
                        //Main.NewText(Language.GetTextValue(key), messageColor);
                        //if (Main.netMode == 2) // Server
                        //{
                        // NetMessage.BroadcastChatMessage(NetworkText.FromKey(key), messageColor);
                        //}
                        //else if (Main.netMode == 0) // Single Player
                        //{
                        //Main.NewText(Language.GetTextValue(key), messageColor);
                        //}
                        Main.projectile[num55].position.X = player.Center.X - 100f;
                        Main.projectile[num55].position.Y = player.Center.Y + (float)Math.Abs(npc.Center.Y - player.Center.Y) / 1.45f - 91f;
                        Main.projectile[num55].alpha = (255 - (3000 - npc.life) / 7) * (npc.alpha / 255 + 1);
                        Main.projectile[num56].position.X = player.Center.X - (float)Math.Abs(npc.Center.X - player.Center.X) / 1.45f - 100f;
                        Main.projectile[num56].position.Y = player.Center.Y - 91f;
                        Main.projectile[num56].alpha = (255 - (3000 - npc.life) / 7) * (npc.alpha / 255 + 1);
                        Main.projectile[num57].position.X = player.Center.X + (float)Math.Abs(npc.Center.X - player.Center.X) / 1.45f - 100f;
                        Main.projectile[num57].position.Y = player.Center.Y - 91f;
                        Main.projectile[num57].alpha = (255 - (3000 - npc.life) / 7) * (npc.alpha / 255 + 1);
                        float num60 = (float)Math.Sqrt((npc.Center.X - player.Center.X) * (npc.Center.X - player.Center.X) + (npc.Center.Y - player.Center.Y) * (npc.Center.Y - player.Center.Y));
                        float num61 = (float)Math.Sqrt(npc.velocity.X * npc.velocity.X + npc.velocity.Y * npc.velocity.Y) / 32f;
                        Main.projectile[num59].position = player.Center + new Vector2(num60, 0).RotatedBy(num58 / 600f * num61) - new Vector2(100, 91);
                        Main.projectile[num59].alpha = (255 - (3000 - npc.life) / 18) * (npc.alpha / 255 + 1);
                        Main.projectile[num62].position = player.Center + new Vector2(num60, 0).RotatedBy(num58 / 600f * num61 + Math.PI * 1 / 3) - new Vector2(100, 91);
                        Main.projectile[num62].alpha = (255 - (3000 - npc.life) / 18) * (npc.alpha / 255 + 1);
                        Main.projectile[num63].position = player.Center + new Vector2(num60, 0).RotatedBy(num58 / 600f * num61 + Math.PI * 2 / 3) - new Vector2(100, 91);
                        Main.projectile[num63].alpha = (255 - (3000 - npc.life) / 18) * (npc.alpha / 255 + 1);
                        Main.projectile[num64].position = player.Center + new Vector2(num60, 0).RotatedBy(num58 / 600f * num61 + Math.PI) - new Vector2(100, 91);
                        Main.projectile[num64].alpha = (255 - (3000 - npc.life) / 18) * (npc.alpha / 255 + 1);
                        Main.projectile[num65].position = player.Center + new Vector2(num60, 0).RotatedBy(num58 / 600f * num61 + Math.PI * 4 / 3) - new Vector2(100, 91);
                        Main.projectile[num65].alpha = (255 - (3000 - npc.life) / 18) * (npc.alpha / 255 + 1);
                        Main.projectile[num66].position = player.Center + new Vector2(num60, 0).RotatedBy(num58 / 600f * num61 + Math.PI * 5 / 3) - new Vector2(100, 91);
                        Main.projectile[num66].alpha = (255 - (3000 - npc.life) / 18) * (npc.alpha / 255 + 1);
                        if (num58 % 10 == 1)
                        {
                            Main.projectile[num53].frame += 1;
                            Main.projectile[num55].frame += 1;
                            Main.projectile[num56].frame += 1;
                            Main.projectile[num57].frame += 1;
                            if (npc.dontTakeDamage)
                            {
                                if (Main.projectile[num53].frame > 3)
                                {
                                    Main.projectile[num53].frame = 0;
                                }
                                if (Main.projectile[num55].frame > 3)
                                {
                                    Main.projectile[num55].frame = 0;
                                }
                                if (Main.projectile[num56].frame > 3)
                                {
                                    Main.projectile[num56].frame = 0;
                                }
                                if (Main.projectile[num57].frame > 3)
                                {
                                    Main.projectile[num57].frame = 0;
                                }
                                if (Main.projectile[num59].frame > 3)
                                {
                                    Main.projectile[num59].frame = 0;
                                }
                                if (Main.projectile[num62].frame > 3)
                                {
                                    Main.projectile[num62].frame = 0;
                                }
                                if (Main.projectile[num63].frame > 3)
                                {
                                    Main.projectile[num63].frame = 0;
                                }
                                if (Main.projectile[num64].frame > 3)
                                {
                                    Main.projectile[num64].frame = 0;
                                }
                                if (Main.projectile[num65].frame > 3)
                                {
                                    Main.projectile[num65].frame = 0;
                                }
                                if (Main.projectile[num66].frame > 3)
                                {
                                    Main.projectile[num66].frame = 0;
                                }
                            }
                            else
                            {
                                if (Main.projectile[num53].frame <= 3 || Main.projectile[num53].frame > 7)
                                {
                                    Main.projectile[num53].frame = 4;
                                }
                                if (Main.projectile[num55].frame <= 3 || Main.projectile[num55].frame > 7)
                                {
                                    Main.projectile[num55].frame = 4;
                                }
                                if (Main.projectile[num56].frame <= 3 || Main.projectile[num56].frame > 7)
                                {
                                    Main.projectile[num56].frame = 4;
                                }
                                if (Main.projectile[num57].frame <= 3 || Main.projectile[num57].frame > 7)
                                {
                                    Main.projectile[num57].frame = 4;
                                }
                                if (Main.projectile[num59].frame <= 3 || Main.projectile[num55].frame > 7)
                                {
                                    Main.projectile[num59].frame = 4;
                                }
                                if (Main.projectile[num62].frame <= 3 || Main.projectile[num56].frame > 7)
                                {
                                    Main.projectile[num62].frame = 4;
                                }
                                if (Main.projectile[num63].frame <= 3 || Main.projectile[num57].frame > 7)
                                {
                                    Main.projectile[num63].frame = 4;
                                }
                                if (Main.projectile[num64].frame <= 3 || Main.projectile[num55].frame > 7)
                                {
                                    Main.projectile[num64].frame = 4;
                                }
                                if (Main.projectile[num65].frame <= 3 || Main.projectile[num56].frame > 7)
                                {
                                    Main.projectile[num65].frame = 4;
                                }
                                if (Main.projectile[num66].frame <= 3 || Main.projectile[num57].frame > 7)
                                {
                                    Main.projectile[num66].frame = 4;
                                }
                            }
                        }
                    }
                }
                if (npc.type == 134 && MythWorld.Myth/*毁灭者*/)
                {
                    Player player = Main.player[npc.target];
                    if(npc.life < npc.lifeMax * 0.15f)
                    {
                        if(num94)
                        {
                            for(int i = -7;i < 8;i++)
                            {
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, Mod.Find<ModProjectile>("RedLazerBall3").Type, 0, 0f, Main.myPlayer, (float)(Math.PI * i / 7.5), 0f);
                            }
                            num94 = false;
                        }
                    }
                }
                {/*mplayer.PoisonHeart = 2;
                    num11 += 1;
                    npcClock += 1;
                    if (npc.life > 94000)
                    {
                        num11 = 0;
                    }
                    if (npc.life < 94000)
                    {
                        if (num11 % 2 == 0 && num11 > 3)
                        {
                            for (int i = 0; i <= 10; i++)
                            {
                                Vector2 vector12 = vector16.RotatedBy(Math.PI / 5f * i);
                                Vector2 vector15 = vector14 + vector12;
                                if (Main.tile[(int)vector15.X, (int)vector15.Y].type == (ushort)base.mod.TileType("机械砖"))
                                {
                                    WorldGen.KillTile((int)vector15.X, (int)vector15.Y, false, false, false);
                                }
                            }
                        }
                        if (num11 % 2 == 0)
                        {
                            //string key = num11.ToString();
                            //Color messageColor = Color.Purple;
                            for (int i = 0; i <= 10; i++)
                            {
                                Vector2 vector12 = vector9.RotatedBy(Math.PI / 5f * i);
                                Vector2 vector13 = player.Center * 0.0625f + vector12;
                                WorldGen.PlaceTile((int)vector13.X, (int)vector13.Y, (ushort)base.mod.TileType("机械砖"), true, false, -1, 0);
                            }
                            vector14 = player.Center * 0.0625f;
                            vector16 = vector9;
                        }
                    }
                    if (npc.life < 56000)
                    {
                        if (num52 == true)
                        {
                            num11 = 5;
                            num52 = false;
                        }
                        if (num11 % 300 == 7 && num11 > 8)
                        {
                            for (int i = -2; i <= 2; i++)
                            {
                                Vector2 vector13 = (vector17 + new Vector2(0, -150)) * 0.0625f + new Vector2(i, 2);
                                if (Main.tile[(int)vector13.X, (int)vector13.Y].type == (ushort)base.mod.TileType("机械砖2"))
                                {
                                    WorldGen.KillTile((int)vector13.X, (int)vector13.Y, false, false, false);
                                    int num67 = NPC.NewNPC((int)(vector13.X / 0.0625f), (int)(vector13.Y / 0.0625f), 139, 0, 0f, 0f, 0f, 0f, 255);
                                    Main.npc[num67].lifeMax = 225;
                                    Main.npc[num67].life = 225;
                                }
                                vector13 = (vector17 + new Vector2(0, -150)) * 0.0625f + new Vector2(i, -2);
                                if (Main.tile[(int)vector13.X, (int)vector13.Y].type == (ushort)base.mod.TileType("机械砖2"))
                                {
                                    WorldGen.KillTile((int)vector13.X, (int)vector13.Y, false, false, false);
                                    int num68 = NPC.NewNPC((int)(vector13.X / 0.0625f), (int)(vector13.Y / 0.0625f), 139, 0, 0f, 0f, 0f, 0f, 255);
                                    Main.npc[num68].lifeMax = 225;
                                    Main.npc[num68].life = 225;
                                }
                                vector13 = (vector17 + new Vector2(0, -150)) * 0.0625f + new Vector2(2, i);
                                if (Main.tile[(int)vector13.X, (int)vector13.Y].type == (ushort)base.mod.TileType("机械砖2"))
                                {
                                    WorldGen.KillTile((int)vector13.X, (int)vector13.Y, false, false, false);
                                    int num69 = NPC.NewNPC((int)(vector13.X / 0.0625f), (int)(vector13.Y / 0.0625f), 139, 0, 0f, 0f, 0f, 0f, 255);
                                    Main.npc[num69].lifeMax = 225;
                                    Main.npc[num69].life = 225;
                                }
                                vector13 = (vector17 + new Vector2(0, -150)) * 0.0625f + new Vector2(-2, i);
                                if (Main.tile[(int)vector13.X, (int)vector13.Y].type == (ushort)base.mod.TileType("机械砖2"))
                                {
                                    WorldGen.KillTile((int)vector13.X, (int)vector13.Y, false, false, false);
                                    int num70 = NPC.NewNPC((int)(vector13.X / 0.0625f), (int)(vector13.Y / 0.0625f), 139, 0, 0f, 0f, 0f, 0f, 255);
                                    Main.npc[num70].lifeMax = 225;
                                    Main.npc[num70].life = 225;
                                }
                            }
                        }
                        if (num11 % 300 == 7)
                        {
                            //string key = num11.ToString();
                            //Color messageColor = Color.Purple;
                            for (int i = -2; i <= 2; i++)
                            {
                                Vector2 vector13 = (player.Center + new Vector2(0, -150)) * 0.0625f + new Vector2(i, 2);
                                WorldGen.PlaceTile((int)vector13.X, (int)vector13.Y, (ushort)base.mod.TileType("机械砖2"), true, false, -1, 0);
                                vector13 = (player.Center + new Vector2(0, -150)) * 0.0625f + new Vector2(i, -2);
                                WorldGen.PlaceTile((int)vector13.X, (int)vector13.Y, (ushort)base.mod.TileType("机械砖2"), true, false, -1, 0);
                                vector13 = (player.Center + new Vector2(0, -150)) * 0.0625f + new Vector2(2, i);
                                WorldGen.PlaceTile((int)vector13.X, (int)vector13.Y, (ushort)base.mod.TileType("机械砖2"), true, false, -1, 0);
                                vector13 = (player.Center + new Vector2(0, -150)) * 0.0625f + new Vector2(-2, i);
                                WorldGen.PlaceTile((int)vector13.X, (int)vector13.Y, (ushort)base.mod.TileType("机械砖2"), true, false, -1, 0);
                            }
                            vector17 = player.Center;
                        }
                        if (num11 % 300 != 7 && num11 % 60 == 7)
                        {
                            bool num40 = false;
                            bool num41 = false;
                            bool num42 = false;
                            bool num43 = false;
                            for (int i = -2; i <= 2; i++)
                            {
                                Vector2 vector13 = (vector17 + new Vector2(0, -150)) * 0.0625f + new Vector2(i, 2);
                                if (Main.tile[(int)vector13.X, (int)vector13.Y].type == (ushort)base.mod.TileType("机械砖2"))
                                {
                                    num40 = true;
                                }
                                vector13 = (vector17 + new Vector2(0, -150)) * 0.0625f + new Vector2(i, -2);
                                if (Main.tile[(int)vector13.X, (int)vector13.Y].type == (ushort)base.mod.TileType("机械砖2"))
                                {
                                    num41 = true;
                                }
                                vector13 = (vector17 + new Vector2(0, -150)) * 0.0625f + new Vector2(2, i);
                                if (Main.tile[(int)vector13.X, (int)vector13.Y].type == (ushort)base.mod.TileType("机械砖2"))
                                {
                                    num42 = true;
                                }
                                vector13 = (vector17 + new Vector2(0, -150)) * 0.0625f + new Vector2(-2, i);
                                if (Main.tile[(int)vector13.X, (int)vector13.Y].type == (ushort)base.mod.TileType("机械砖2"))
                                {
                                    num43 = true;
                                }
                            }
                            if (num40 == true && num41 == true && num42 == true && num43 == true)
                            {
                                Vector2 vector18 = vector17 + new Vector2(0, -150);
                                NPC.NewNPC((int)(vector18.X), (int)(vector18.Y), 139, 0, 0f, 0f, 0f, 0f, 255);
                                for (int i = -20; i <= 20; i++)
                                {
                                    int num48 = Dust.NewDust(new Vector2((float)vector18.X + i / 0.625f, (float)vector18.Y), 0, 0, 183, 0f, 0f, 0, default(Color), 1f);
                                    int num49 = Dust.NewDust(new Vector2((float)vector18.X, (float)vector18.Y + i / 0.625f), 0, 0, 183, 0f, 0f, 0, default(Color), 1f);
                                    int num50 = Dust.NewDust(new Vector2((float)vector18.X + i / 0.625f, (float)vector18.Y + i / 0.625f), 0, 0, 183, 0f, 0f, 0, default(Color), 1f);
                                    int num51 = Dust.NewDust(new Vector2((float)vector18.X + i / 0.625f, (float)vector18.Y - i / 0.625f), 0, 0, 183, 0f, 0f, 0, default(Color), 1f);
                                    Main.dust[num48].noGravity = true;
                                    Main.dust[num49].noGravity = true;
                                    Main.dust[num50].noGravity = true;
                                    Main.dust[num51].noGravity = true;
                                    Main.dust[num48].velocity = new Vector2(0, 0);
                                    Main.dust[num49].velocity = new Vector2(0, 0);
                                    Main.dust[num50].velocity = new Vector2(0, 0);
                                    Main.dust[num51].velocity = new Vector2(0, 0);
                                }
                            }
                        }
                    }*/
                }//Old Codes
                if (npc.type == 135/*毁灭者*/)
                {
                    Player player = Main.player[npc.target];
                    num93 += 1;
                    if (npc.life < npc.lifeMax * 0.75f)
                    {
                        if(num93 % 120 == 0)
                        {
                            Vector2 v = player.Center + new Vector2(0, 150) - npc.Center;
                            if(v.Length() < 800)
                            {
                                v = v / v.Length() * 12f;
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("RedArrow").Type, npc.damage / 5, 0f, Main.myPlayer, 0f, 0f);
                            }
                        }
                    }
                    for (int u = 0; u < 200; u++)
                    {
                        if (Main.npc[u].type == Mod.Find<ModNPC>("ExploreMonster2").Type && Main.npc[u].active)
                        {
                            if ((Main.npc[u].Center - npc.Center).Length() < 300)
                            {
                                npc.defense = 1000;
                                break;
                            }
                        }
                        else
                        {
                            npc.defense = 25;
                        }
                    }
                }
                if (npc.type == 112/*肉山*/)
                {
                    Player player = Main.player[npc.target];
                    if ((npc.Center - player.Center).Length() < 150)
                    {
                        npc.velocity *= 0.95f;
                        npc.velocity -= (npc.Center - player.Center) / (npc.Center - player.Center).Length() * 0.4f;
                    }
                }
                if (npc.type == 249/*石巨人装置*/)
                {
                    Player player = Main.player[npc.target];
                    num12 += 1;
                    if (num12 % 30 == 0)
                    {
                        int num43 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 40f, npc.velocity.X, npc.velocity.Y, 185, 75, 0f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num43].friendly = false;
                    }
                    if (num12 % 30 == 4)
                    {
                        int num43 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y + 30f, npc.velocity.X, npc.velocity.Y, 185, 75, 0f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num43].friendly = false;
                    }
                }
                if (npc.type == 245 && npc.active/*石巨人*/)
                {
                    Player player = Main.player[npc.target];
                    num13 += 1 / NPC.CountNPCS(245);
                    Vector2 v = (player.Center - npc.Center) / (npc.Center - player.Center).Length() * 7f;
                    if (NPC.CountNPCS(249) == 0)
                    {
                        if (num13 % 120 == 0)
                        {
                            Projectile.NewProjectile(npc.Center.X + 5f, npc.Center.Y - 5f, v.X, v.Y, 259, 110, 0f, Main.myPlayer, 0f, 0f);
                        }
                        if (num13 % 120 == 30)
                        {
                            Projectile.NewProjectile(npc.Center.X + 5f, npc.Center.Y - 15f, v.X, v.Y, 259, 110, 0f, Main.myPlayer, 0f, 0f);
                        }
                        if (num13 % 120 == 60)
                        {
                            Projectile.NewProjectile(npc.Center.X - 5f, npc.Center.Y - 15f, v.X, v.Y, 259, 110, 0f, Main.myPlayer, 0f, 0f);
                        }
                        if (num13 % 120 == 90)
                        {
                            Projectile.NewProjectile(npc.Center.X - 5f, npc.Center.Y - 5f, v.X, v.Y, 259, 110, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                    else
                    {
                        if (num13 % 80 == 0)
                        {
                            Projectile.NewProjectile(npc.Center.X + 5f, npc.Center.Y - 5f, v.X, v.Y, 259, 110, 0f, Main.myPlayer, 0f, 0f);
                        }
                        if (num13 % 80 == 20)
                        {
                            Projectile.NewProjectile(npc.Center.X + 5f, npc.Center.Y - 15f, v.X, v.Y, 259, 110, 0f, Main.myPlayer, 0f, 0f);
                        }
                        if (num13 % 80 == 40)
                        {
                            Projectile.NewProjectile(npc.Center.X - 5f, npc.Center.Y - 15f, v.X, v.Y, 259, 110, 0f, Main.myPlayer, 0f, 0f);
                        }
                        if (num13 % 80 == 60)
                        {
                            Projectile.NewProjectile(npc.Center.X - 5f, npc.Center.Y - 5f, v.X, v.Y, 259, 110, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                    if (npc.life <= 10000 && golem)
                    {
                        golem = false;
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 30, Mod.Find<ModNPC>("GlomePower").Type, 0, 1f, 0f, 0f, 0f, 255);
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 30, Mod.Find<ModNPC>("GlomePower").Type, 0, 2f, 0f, 0f, 0f, 255);
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 30, Mod.Find<ModNPC>("GlomePower").Type, 0, 3f, 0f, 0f, 0f, 255);
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 30, Mod.Find<ModNPC>("GlomePower").Type, 0, 4f, 0f, 0f, 0f, 255);
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y - 30, Mod.Find<ModNPC>("GlomePower").Type, 0, 5f, 0f, 0f, 0f, 255);
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("GlomePower").Type) >= 1)
                    {
                        npc.dontTakeDamage = true;
                    }
                    if (NPC.CountNPCS(Mod.Find<ModNPC>("GlomePower").Type) == 0)
                    {
                        npc.dontTakeDamage = false;
                    }
                    if (npc.life > 12000)
                    {
                        golem = true;
                    }
                }
                if (npc.type == 14/*世吞*/)
                {
                    int num44 = Main.rand.Next(3000);
                    if (num44 == 1)
                    {
                        Vector2 vector6 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        float num35 = 0.783f;
                        double num36 = Math.Atan2((double)npc.velocity.X, (double)npc.velocity.Y) - (double)(num35 / 2f);
                        double num37 = (double)(num35 / 8f);
                        for (int k = 0; k < 13; k++)
                        {
                            int timeLeft = Main.rand.Next(400, 700);
                            double num39 = num36 + num37 * (double)(k + k * k) / 2.0 + (double)(32f * (float)k);
                            int num42 = Main.rand.Next(4);
                            if (num42 == 1)
                            {
                                int num43 = Projectile.NewProjectile(vector6.X, vector6.Y, (float)(-(float)Math.Sin(num39) * 6.0), (float)(-(float)Math.Cos(num39) * 6.0), 96, 44, 0f, Main.myPlayer, 0f, 0f);
                                Main.projectile[num43].timeLeft = 600;
                                Main.projectile[num43].tileCollide = false;
                            }
                        }
                    }
                }
            }
        }
        private bool golem = true;
        private int Laser = 0;
        private int Curse = 0;
        private int turnLaser = 240;
        private int turnCurse = 240;
        private int Ranlaser = 0;
        private int Rancurse = 0;
        private float Rlase = 0;
        private float Rcurs = 0;
        private bool CanRush = false;
        private bool CanRush2 = false;
        private int CountLaser = 0;
        private int LaserRan2 = 1;
        private bool LaserAC = true;
        private Vector2[] VlaserRot = new Vector2[40];
        private int[] ProjLas = new int[40];
        public override bool PreAI(NPC npc)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (npc.type == 127 && MythWorld.Myth/*机械骷髅*/)
            {
                if (NPC.CountNPCS(128) + NPC.CountNPCS(129) + NPC.CountNPCS(130) + NPC.CountNPCS(131) > 0)
                {
                    npc.defense = 160;
                }
                else
                {
                    npc.defense = 24;
                }
            }
            if (npc.HasBuff(Mod.Find<ModBuff>("Freeze").Type) && npc.type != Mod.Find<ModNPC>("MagicBaby").Type)
            {
                return false;
            }
            if (npc.HasBuff(Mod.Find<ModBuff>("Ban").Type))
            {
                return false;
            }
            if (npc.type == 50 && MythWorld.Myth/*史莱姆王*/)
            {
                bool flag12 = false;
                bool flag13 = true;
                if (npc.ai[3] != 9968)
                {
                    flag13 = false;
                }
                if (npc.ai[1] == 5f)
                {
                    flag12 = true;
                    npc.ai[0] += 15f;
                }
                else if (npc.ai[1] == 6f)
                {
                    flag12 = true;
                    npc.ai[0] += 18f;
                }
                if (npc.velocity.Y == 0f && !flag12)
                {
                    npc.ai[0] += 25f;
                }
                if (npc.life > 2000)
                {
                    flag13 = true;
                }
                if (MythWorld.MythIndex >= 3)
                {
                    if (Main.netMode != 1 && npc.life <= 10000)
                    {
                        if (Main.netMode != 1 && npc.life <= 7000)
                        {
                            if (Main.netMode != 1 && npc.life <= 5000)
                            {
                                int num = Main.rand.Next(140);
                                if (num == 1)
                                {
                                    Vector2 vector = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                                    NPC.NewNPC((int)vector.X - 25, (int)vector.Y, Mod.Find<ModNPC>("FlyingSlime").Type, 0, 0f, 0f, 0f, 0f, 255);
                                    NPC.NewNPC((int)vector.X + 25, (int)vector.Y - 10, Mod.Find<ModNPC>("FlyingSpicySlime").Type, 0, 0f, 0f, 0f, 0f, 255);
                                    npc.ai[2] += 12f;
                                    npc.ai[0] += 700f;
                                }
                                npc.velocity.Y *= 1.014f;
                                if (npc.velocity.Y > 0)
                                {
                                    npc.velocity.Y *= 1.2f;
                                }
                            }
                            else
                            {
                                int num4002 = Main.rand.Next(240);
                                if (num4002 == 1)
                                {
                                    Vector2 vector = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                                    NPC.NewNPC((int)vector.X - 25, (int)vector.Y, Mod.Find<ModNPC>("FlyingSlime").Type, 0, 0f, 0f, 0f, 0f, 255);
                                    NPC.NewNPC((int)vector.X + 25, (int)vector.Y + 10, Mod.Find<ModNPC>("FlyingSpicySlime").Type, 0, 0f, 0f, 0f, 0f, 255);
                                    npc.ai[2] += 5f;
                                    npc.ai[0] += 110f;
                                    if (npc.velocity.Y > 0)
                                    {
                                        npc.velocity.Y *= 1.2f;
                                    }
                                }
                            }
                        }
                        else
                        {
                            int num1 = Main.rand.Next(360);
                            if (num1 == 1)
                            {
                                Vector2 vector = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                                NPC.NewNPC((int)vector.X, (int)vector.Y, Mod.Find<ModNPC>("FlyingSlime").Type, 0, 0f, 0f, 0f, 0f, 255);
                                npc.ai[2] += 2f;
                                npc.ai[0] += 35f;
                                if (npc.velocity.Y > 0)
                                {
                                    npc.velocity.Y *= 1.1f;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (Main.netMode != 1 && npc.life <= 5000)
                    {
                        if (Main.netMode != 1 && npc.life <= 3000)
                        {
                            if (Main.netMode != 1 && npc.life <= 1000)
                            {
                                int num = Main.rand.Next(140);
                                if (num == 1)
                                {
                                    Vector2 vector = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                                    NPC.NewNPC((int)vector.X - 25, (int)vector.Y, Mod.Find<ModNPC>("FlyingSlime").Type, 0, 0f, 0f, 0f, 0f, 255);
                                    NPC.NewNPC((int)vector.X + 25, (int)vector.Y - 10, Mod.Find<ModNPC>("FlyingSpicySlime").Type, 0, 0f, 0f, 0f, 0f, 255);
                                    npc.ai[2] += 4f;
                                    npc.ai[0] += 200f;
                                }
                                npc.velocity.Y *= 1.014f;
                                if (npc.velocity.Y > 0)
                                {
                                    npc.velocity.Y *= 1.2f;
                                }
                            }
                            else
                            {
                                int num4002 = Main.rand.Next(240);
                                if (num4002 == 1)
                                {
                                    Vector2 vector = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                                    NPC.NewNPC((int)vector.X - 25, (int)vector.Y, Mod.Find<ModNPC>("FlyingSlime").Type, 0, 0f, 0f, 0f, 0f, 255);
                                    if (Main.rand.Next(20) >= 15 && MythWorld.MythIndex >= 2)
                                    {
                                        NPC.NewNPC((int)vector.X + 25, (int)vector.Y + 10, Mod.Find<ModNPC>("FlyingSpicySlime").Type, 0, 0f, 0f, 0f, 0f, 255);
                                    }
                                    npc.ai[2] += 1.5f;
                                    npc.ai[0] += 40f;
                                    if (npc.velocity.Y > 0)
                                    {
                                        npc.velocity.Y *= 1.2f;
                                    }
                                }
                            }
                        }
                        else
                        {
                            int num1 = Main.rand.Next(360);
                            if (num1 == 1)
                            {
                                Vector2 vector = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                                NPC.NewNPC((int)vector.X, (int)vector.Y, Mod.Find<ModNPC>("FlyingSlime").Type, 0, 0f, 0f, 0f, 0f, 255);
                                npc.ai[2] += 0.8f;
                                npc.ai[0] += 10f;
                                if (npc.velocity.Y > 0)
                                {
                                    npc.velocity.Y *= 1.1f;
                                }
                            }
                        }
                    }
                    if (Main.time % 600 == 0 && MythWorld.MythIndex >= 3)
                    {
                        Vector2 vector3 = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                        for (int i = 0; i < 15; i++)
                        {
                            Vector2 v = new Vector2(0, 800).RotatedByRandom(Math.PI * 2);
                            NPC.NewNPC((int)vector3.X + (int)v.X, (int)vector3.Y + (int)v.Y, 5, 0, 0f, 0f, 0f, 0f, 255);
                        }
                    }
                }
                if (npc.boss && MythWorld.Myth)
                {
                    return true;
                }
            }
            if(npc.type == 125 && MythWorld.Myth/*激光眼*/)
            {
                Player player = Main.player[npc.target];
                Laser += 1;
                if(npc.life >= npc.lifeMax * 0.4f)
                {
                    if (Laser > 0 && Laser < 600)
                    {
                        npc.velocity *= 0.98f;
                        if (npc.velocity.Length() < 2 && CanRush)
                        {
                            Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 22f;
                            npc.velocity += v;
                            CanRush = false;
                        }
                        if (!CanRush)
                        {
                            Rlase = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                            if (Laser % 15 == 0)
                            {
                                Vector2 v1 = npc.velocity.RotatedBy(Math.PI / 2d) / npc.velocity.Length();
                                Vector2 v2 = npc.velocity.RotatedBy(-Math.PI / 2d) / npc.velocity.Length();
                                Projectile.NewProjectile(npc.Center.X + v1.X * 25, npc.Center.Y + v1.Y * 25, v1.X, v1.Y, Mod.Find<ModProjectile>("RedArrow2").Type, npc.damage / 5, 0, Main.myPlayer, 0, 0);
                                Projectile.NewProjectile(npc.Center.X + v2.X * 25, npc.Center.Y + v2.Y * 25, v2.X, v2.Y, Mod.Find<ModProjectile>("RedArrow2").Type, npc.damage / 5, 0, Main.myPlayer, 0, 0);
                            }
                        }
                        if (npc.velocity.Length() < 5)
                        {
                            CanRush = true;
                            float r0 = (float)(Rlase % (Math.PI * 2d));
                            Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 15f;
                            float r1 = (float)(Math.Atan2(v.Y, v.X));
                            float r2 = r0 - r1;
                            if (r2 > Math.PI)
                            {
                                r1 += (float)(Math.PI * 2d);
                            }
                            if (r2 < -Math.PI)
                            {
                                r1 -= (float)(Math.PI * 2d);
                            }
                            Rlase = r0 * 0.9f + r1 * 0.1f;
                        }
                    }
                    if (Laser == 600)
                    {
                        Ranlaser = Main.rand.Next(100);
                    }
                    if (Laser == 1300)
                    {
                        Ranlaser = Main.rand.Next(100);
                    }
                    if (Laser > 600 && Laser < 700)
                    {
                        if (Laser % 3 == 0)
                        {
                            npc.velocity *= 0.8f;
                            Rlase += (float)(Math.PI / 50f) * (Ranlaser % 2 - 0.5f) * 2;
                            Vector2 v1 = new Vector2(0, 15).RotatedBy(npc.rotation);
                            Projectile.NewProjectile(npc.Center.X + v1.X * 2.5f, npc.Center.Y + v1.Y * 2.5f, 0, 0, Mod.Find<ModProjectile>("PurpleLazerBall2").Type, npc.damage / 5, 0, Main.myPlayer, v1.X, v1.Y);
                        }
                    }
                    if (Laser == 700)
                    {
                        for (int i = 0; i < 36; i++)
                        {
                            ProjLas[i] = -1;
                        }
                    }
                    if (Laser == 600)
                    {
                        for (int i = 0; i < 36; i++)
                        {
                            ProjLas[i] = -1;
                        }
                    }
                    if (Laser > 700 && Laser < 1300)
                    {
                        npc.velocity *= 0.95f;
                        if (npc.velocity.Length() < 2f && CanRush)
                        {
                            Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 22f;
                            npc.velocity += v;
                            CountLaser = 0;
                            CanRush = false;
                        }
                        if (!CanRush)
                        {
                            Rlase = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        }
                        if (npc.velocity.Length() > 7 && npc.velocity.Length() < 10)
                        {
                            LaserAC = true;
                        }
                        if (npc.velocity.Length() < 3)
                        {
                            if (LaserAC)
                            {
                                for (int i = 0; i < 36; i++)
                                {
                                    ProjLas[i] = -1;
                                }
                                LaserAC = false;
                            }
                            float r0 = (float)(Rlase % (Math.PI * 2d));
                            Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 15f;
                            float r1 = (float)(Math.Atan2(v.Y, v.X));
                            float r2 = r0 - r1;
                            if (r2 > Math.PI)
                            {
                                r1 += (float)(Math.PI * 2d);
                            }
                            if (r2 < -Math.PI)
                            {
                                r1 -= (float)(Math.PI * 2d);
                            }
                            Rlase = r0 * 0.9f + r1 * 0.1f;
                            if (Laser % 60 < 12)
                            {
                                CountLaser += 1;
                                VlaserRot[CountLaser] = v.RotatedBy((Laser % 60 - 6) / 5f);
                                ProjLas[CountLaser] = Projectile.NewProjectile(npc.Center.X + VlaserRot[CountLaser].X * 2.5f, npc.Center.Y + VlaserRot[CountLaser].Y * 2.5f, 0, 0, Mod.Find<ModProjectile>("PurpleLazerBall2").Type, npc.damage / 5, 0, Main.myPlayer, VlaserRot[CountLaser].X, VlaserRot[CountLaser].Y);
                            }
                            if (CountLaser >= 12)
                            {
                                CanRush = true;
                                CountLaser = 0;
                            }
                        }
                    }
                    if (Laser > 1300 && Laser < 2000)
                    {
                        float r0 = (float)(Rlase % (Math.PI * 2d));
                        Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 15f;
                        float r1 = (float)(Math.Atan2(v.Y, v.X));
                        float r2 = r0 - r1;
                        if (r2 > Math.PI)
                        {
                            r1 += (float)(Math.PI * 2d);
                        }
                        if (r2 < -Math.PI)
                        {
                            r1 -= (float)(Math.PI * 2d);
                        }
                        Rlase = r0 * 0.9f + r1 * 0.1f;
                        Vector2 vIntend = player.Center + new Vector2(450 * (Ranlaser % 2 - 0.5f) * 2, 0);
                        npc.velocity += (vIntend - npc.Center) / (vIntend - npc.Center).Length() * 2f;
                        if (npc.velocity.Length() > 25)
                        {
                            npc.velocity *= 25f / npc.velocity.Length();
                        }
                        npc.velocity *= 0.95f;
                        if (Laser % 120 == 0)
                        {
                            for (int i = 0; i < 36; i++)
                            {
                                ProjLas[i] = -1;
                            }
                            for (int i = 0; i < 17; i++)
                            {
                                Vector2 vi = new Vector2(0, 15).RotatedBy(i / 8.5 * Math.PI);
                                Projectile.NewProjectile(npc.Center.X + vi.X * 5f, npc.Center.Y + vi.Y * 5f, 0, 0, Mod.Find<ModProjectile>("PurpleLazerBall2").Type, npc.damage / 4, 0, Main.myPlayer, vi.X, vi.Y);
                            }
                        }
                        if (Laser % 12 == 0)
                        {
                            Vector2 vi = new Vector2(0, 15).RotatedBy(npc.rotation);
                            Projectile.NewProjectile(npc.Center.X + vi.X * 5f, npc.Center.Y + vi.Y * 5f, vi.X, vi.Y, 83, npc.damage / 4, 0, Main.myPlayer, 0, 0);
                        }
                    }
                    if (Laser > 2000 && Laser < 2700)
                    {
                        float r0 = (float)(Rlase % (Math.PI * 2d));
                        Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 15f;
                        float r1 = (float)(Math.Atan2(v.Y, v.X));
                        float r2 = r0 - r1;
                        if (r2 > Math.PI)
                        {
                            r1 += (float)(Math.PI * 2d);
                        }
                        if (r2 < -Math.PI)
                        {
                            r1 -= (float)(Math.PI * 2d);
                        }
                        Rlase = r0 * 0.9f + r1 * 0.1f;
                        Vector2 vIntend = player.Center + new Vector2(450 * (Ranlaser % 2 - 0.5f) * 2, 0).RotatedBy(-Math.PI / 2d * (Ranlaser % 2 - 0.5f));
                        npc.velocity += (vIntend - npc.Center) / (vIntend - npc.Center).Length() * 2f;
                        if (npc.velocity.Length() > 25)
                        {
                            npc.velocity *= 25f / npc.velocity.Length();
                        }
                        npc.velocity *= 0.95f;
                        if (Laser % 120 == 0)
                        {
                            for (int i = 0; i < 36; i++)
                            {
                                ProjLas[i] = -1;
                            }
                            for (int i = 0; i < 17; i++)
                            {
                                Vector2 vi = new Vector2(0, 15).RotatedBy(i / 8.5 * Math.PI);
                                Projectile.NewProjectile(npc.Center.X + vi.X * 5f, npc.Center.Y + vi.Y * 5f, 0, 0, Mod.Find<ModProjectile>("PurpleLazerBall2").Type, npc.damage / 4, 0, Main.myPlayer, vi.X, vi.Y);
                            }
                        }
                        if (Laser % 12 == 0)
                        {
                            Vector2 vi = new Vector2(0, 15).RotatedBy(npc.rotation);
                            Projectile.NewProjectile(npc.Center.X + vi.X * 5f, npc.Center.Y + vi.Y * 5f, vi.X, vi.Y, 83, npc.damage / 4, 0, Main.myPlayer, 0, 0);
                        }
                    }
                    for (int y = 0; y < 32; y++)
                    {
                        if (ProjLas[y] != -1 && Main.projectile[ProjLas[y]].active && Main.projectile[ProjLas[y]].type == Mod.Find<ModProjectile>("PurpleLazerBall2").Type)
                        {
                            Main.projectile[ProjLas[y]].position = new Vector2(npc.Center.X + VlaserRot[y].X * 5f, npc.Center.Y + VlaserRot[y].Y * 5f);
                        }
                    }
                    if (Laser > 2700)
                    {
                        Laser = 0;
                    }
                    npc.rotation = (float)(Rlase - Math.PI / 2d);
                    return false;
                }
                else
                {
                    if (turnLaser <= 0)
                    {
                        turnLaser = 0;
                        if (mplayer.TwinslocalAIMyth < 600)
                        {
                            npc.velocity *= 0.9f;
                            if (npc.velocity.Length() < 2 && CanRush)
                            {
                                Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 40f;
                                npc.velocity += v;
                                CanRush = false;
                            }
                            if (!CanRush)
                            {
                                Rlase = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                            }
                            if (npc.velocity.Length() < 5)
                            {
                                CanRush = true;
                                float r0 = (float)(Rlase % (Math.PI * 2d));
                                Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 15f;
                                float r1 = (float)(Math.Atan2(v.Y, v.X));
                                float r2 = r0 - r1;
                                if (r2 > Math.PI)
                                {
                                    r1 += (float)(Math.PI * 2d);
                                }
                                if (r2 < -Math.PI)
                                {
                                    r1 -= (float)(Math.PI * 2d);
                                }
                                Rlase = r0 * 0.9f + r1 * 0.1f;
                            }
                            if (mplayer.TwinslocalAIMyth % 90 == 0)
                            {
                                int Cur = -1;
                                for (int t = 0; t < 1000; t++)
                                {
                                    mplayer.LaserV[t] = Vector2.Zero;
                                    mplayer.CurseV[t] = Vector2.Zero;
                                }
                                for (int h = 0; h < 200; h++)
                                {
                                    if (Main.npc[h].type == 126 && Main.npc[h].active)
                                    {
                                        mplayer.CurseV[0] = Main.npc[h].Center + new Vector2(0, 48).RotatedBy(Main.npc[h].rotation);
                                        /*for (int t = 1; t < 100; t++)
                                        {
                                            mplayer.CurseV[t] = Main.npc[h].Center + new Vector2(0, 48).RotatedBy(Main.npc[h].rotation);
                                        }*/
                                        Cur = h;
                                        break;
                                    }
                                }
                                if (Cur != -1)
                                {
                                    Vector2 vadL = new Vector2(0, 48).RotatedBy(npc.rotation);
                                    Vector2 vadC = new Vector2(0, 48).RotatedBy(Main.npc[Cur].rotation);
                                    mplayer.LaserV[0] = npc.Center + new Vector2(0, 48).RotatedBy(npc.rotation) - new Vector2(13, 13);
                                    for (int t = 1; t < 1000; t++)
                                    {
                                        vadL *= 0.92f;
                                        vadC *= 0.92f;
                                        Vector2 vTwL = (mplayer.CurseV[t - 1] - mplayer.LaserV[t - 1]).RotatedBy(Main.rand.NextFloat(-0.6f, 0.6f)) / (mplayer.CurseV[t - 1] - mplayer.LaserV[t - 1]).Length() * Main.rand.NextFloat(4f, 20f) + vadL;
                                        mplayer.LaserV[t] = mplayer.LaserV[t - 1] + vTwL;
                                        Vector2 vTwC = (mplayer.LaserV[t - 1] - mplayer.CurseV[t - 1]).RotatedBy(Main.rand.NextFloat(-0.6f, 0.6f)) / (mplayer.LaserV[t - 1] - mplayer.CurseV[t - 1]).Length() * Main.rand.NextFloat(4f, 20f) + vadC;
                                        mplayer.CurseV[t] = mplayer.CurseV[t - 1] + vTwC;
                                        if ((mplayer.LaserV[t] - mplayer.CurseV[t]).Length() < 20)
                                        {
                                            Projectile.NewProjectile(mplayer.LaserV[0].X, mplayer.LaserV[0].Y, 0, 0, Mod.Find<ModProjectile>("TwinLig").Type, npc.damage / 3, 0, Main.myPlayer, 0, 0);
                                            for (int h = 0; h < 10; h++)
                                            {
                                                Vector2 v1 = new Vector2(0, 1).RotatedBy(h / 5d * Math.PI);
                                                Projectile.NewProjectile(npc.Center.X + v1.X * 25, npc.Center.Y + v1.Y * 25, v1.X, v1.Y, Mod.Find<ModProjectile>("RedArrow2").Type, npc.damage / 5, 0, Main.myPlayer, 0, 0);
                                                v1 = new Vector2(0, 1.2f).RotatedBy((h + 0.5) / 5d * Math.PI);
                                                Projectile.NewProjectile(npc.Center.X + v1.X * 25, npc.Center.Y + v1.Y * 25, v1.X, v1.Y, Mod.Find<ModProjectile>("RedArrow2").Type, npc.damage / 5, 0, Main.myPlayer, 0, 0);
                                            }
                                            break;
                                        }
                                        if ((mplayer.LaserV[t] - mplayer.CurseV[t - 1]).Length() < 20)
                                        {
                                            Projectile.NewProjectile(mplayer.LaserV[0].X, mplayer.LaserV[0].Y, 0, 0, Mod.Find<ModProjectile>("TwinLig").Type, npc.damage / 3, 0, Main.myPlayer, 0, 0);
                                            for (int h = 0; h < 10; h++)
                                            {
                                                Vector2 v1 = new Vector2(0, 1).RotatedBy(h / 5d * Math.PI);
                                                Projectile.NewProjectile(npc.Center.X + v1.X * 25, npc.Center.Y + v1.Y * 25, v1.X, v1.Y, Mod.Find<ModProjectile>("RedArrow2").Type, npc.damage / 5, 0, Main.myPlayer, 0, 0);
                                                v1 = new Vector2(0, 1.2f).RotatedBy((h + 0.5) / 5d * Math.PI);
                                                Projectile.NewProjectile(npc.Center.X + v1.X * 25, npc.Center.Y + v1.Y * 25, v1.X, v1.Y, Mod.Find<ModProjectile>("RedArrow2").Type, npc.damage / 5, 0, Main.myPlayer, 0, 0);
                                            }
                                            break;
                                        }
                                        if ((mplayer.LaserV[t - 1] - mplayer.CurseV[t]).Length() < 20)
                                        {
                                            Projectile.NewProjectile(mplayer.LaserV[0].X, mplayer.LaserV[0].Y, 0, 0, Mod.Find<ModProjectile>("TwinLig").Type, npc.damage / 3, 0, Main.myPlayer, 0, 0);
                                            for (int h = 0; h < 10; h++)
                                            {
                                                Vector2 v1 = new Vector2(0, 1).RotatedBy(h / 5d * Math.PI);
                                                Projectile.NewProjectile(npc.Center.X + v1.X * 25, npc.Center.Y + v1.Y * 25, v1.X, v1.Y, Mod.Find<ModProjectile>("RedArrow2").Type, npc.damage / 5, 0, Main.myPlayer, 0, 0);
                                                v1 = new Vector2(0, 1.2f).RotatedBy((h + 0.5) / 5d * Math.PI);
                                                Projectile.NewProjectile(npc.Center.X + v1.X * 25, npc.Center.Y + v1.Y * 25, v1.X, v1.Y, Mod.Find<ModProjectile>("RedArrow2").Type, npc.damage / 5, 0, Main.myPlayer, 0, 0);
                                            }
                                            break;
                                        }
                                        bool CanB = false;
                                        if (t > 8)
                                        {
                                            for (int x = 0; x < 8; x++)
                                            {
                                                for (int y = 0; y < 8; y++)
                                                {
                                                    if ((mplayer.LaserV[t - x] - mplayer.CurseV[t - y]).Length() < 20)
                                                    {
                                                        Projectile.NewProjectile(mplayer.LaserV[0].X, mplayer.LaserV[0].Y, 0, 0, Mod.Find<ModProjectile>("TwinLig").Type, npc.damage / 3, 0, Main.myPlayer, 0, 0);
                                                        for (int h = 0; h < 10; h++)
                                                        {
                                                            Vector2 v1 = new Vector2(0, 1).RotatedBy(h / 5d * Math.PI);
                                                            Projectile.NewProjectile(npc.Center.X + v1.X * 25, npc.Center.Y + v1.Y * 25, v1.X, v1.Y, Mod.Find<ModProjectile>("RedArrow2").Type, npc.damage / 5, 0, Main.myPlayer, 0, 0);
                                                            v1 = new Vector2(0, 1.2f).RotatedBy((h + 0.5) / 5d * Math.PI);
                                                            Projectile.NewProjectile(npc.Center.X + v1.X * 25, npc.Center.Y + v1.Y * 25, v1.X, v1.Y, Mod.Find<ModProjectile>("RedArrow2").Type, npc.damage / 5, 0, Main.myPlayer, 0, 0);
                                                        }
                                                        CanB = true;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        if (CanB)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        if (mplayer.TwinslocalAIMyth > 600 && mplayer.TwinslocalAIMyth < 1200)
                        {
                            npc.velocity *= 0.95f;
                            float r0 = (float)(Rlase % (Math.PI * 2d));
                            Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 15f;
                            float r1 = (float)(Math.Atan2(v.Y, v.X));
                            float r2 = r0 - r1;
                            if (r2 > Math.PI)
                            {
                                r1 += (float)(Math.PI * 2d);
                            }
                            if (r2 < -Math.PI)
                            {
                                r1 -= (float)(Math.PI * 2d);
                            }
                            if (mplayer.TwinslocalAIMyth % 2 == 0)
                            {
                                Vector2 v1 = v.RotatedBy(Math.Sin(mplayer.TwinslocalAIMyth / 16f));
                                Projectile.NewProjectile(npc.Center.X + v1.X * 2.5f, npc.Center.Y + v1.Y * 2.5f, 0, 0, Mod.Find<ModProjectile>("RedLazerBall2").Type, npc.damage / 3, 0, Main.myPlayer, v1.X, v1.Y);
                                v1 = v.RotatedBy(-Math.Sin(mplayer.TwinslocalAIMyth / 16f));
                                Projectile.NewProjectile(npc.Center.X + v1.X * 2.5f, npc.Center.Y + v1.Y * 2.5f, 0, 0, Mod.Find<ModProjectile>("RedLazerBall2").Type, npc.damage / 3, 0, Main.myPlayer, v1.X, v1.Y);
                                Rlase = r0 * 0.9f + r1 * 0.1f;
                            }
                        }
                        if (mplayer.TwinslocalAIMyth > 1200 && mplayer.TwinslocalAIMyth < 2000)
                        {
                            npc.velocity *= 0.95f;
                            if (npc.velocity.Length() < 2 && CanRush)
                            {
                                Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 32f;
                                LaserRan2 = (int)((Main.rand.Next(2) - 0.5) * 2d);
                                v = v.RotatedBy(Math.PI / 6d * LaserRan2);
                                npc.velocity += v;
                                CanRush = false;
                            }
                            if (!CanRush)
                            {
                                Rlase = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X) - Math.PI * LaserRan2 / 2d);
                                if (mplayer.TwinslocalAIMyth % 15 == 0)
                                {
                                    Vector2 v1 = new Vector2(0, 15).RotatedBy(npc.rotation);
                                    Projectile.NewProjectile(npc.Center.X + v1.X * 3f, npc.Center.Y + v1.Y * 3f, 0, 0, Mod.Find<ModProjectile>("RedLazerBall2").Type, npc.damage / 3, 0, Main.myPlayer, v1.X, v1.Y);
                                }
                            }
                            if (npc.velocity.Length() < 5)
                            {
                                CanRush = true;
                                float r0 = (float)(Rlase % (Math.PI * 2d));
                                Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 15f;
                                float r1 = (float)(Math.Atan2(v.Y, v.X));
                                float r2 = r0 - r1;
                                if (r2 > Math.PI)
                                {
                                    r1 += (float)(Math.PI * 2d);
                                }
                                if (r2 < -Math.PI)
                                {
                                    r1 -= (float)(Math.PI * 2d);
                                }
                                Rlase = r0 * 0.9f + r1 * 0.1f;
                            }
                        }
                        if (mplayer.TwinslocalAIMyth > 2000 && mplayer.TwinslocalAIMyth < 2300)
                        {
                            float r0 = (float)(Rlase % (Math.PI * 2d));
                            Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 15f;
                            float r1 = (float)(Math.Atan2(v.Y, v.X));
                            float r2 = r0 - r1;
                            if (r2 > Math.PI)
                            {
                                r1 += (float)(Math.PI * 2d);
                            }
                            if (r2 < -Math.PI)
                            {
                                r1 -= (float)(Math.PI * 2d);
                            }
                            Rlase = r0 * 0.9f + r1 * 0.1f;
                            if(mplayer.TwinslocalAIMyth % 10 == 0)
                            {
                                for (int h = 0; h < 6; h++)
                                {
                                    float z0 = (mplayer.TwinslocalAIMyth - 2000) / 100f;
                                    float z = z0 * z0 * z0;
                                    Vector2 v1 = new Vector2(0, 1).RotatedBy(h / 3d * Math.PI + z);
                                    Projectile.NewProjectile(npc.Center.X + v1.X * 25, npc.Center.Y + v1.Y * 25, v1.X, v1.Y, Mod.Find<ModProjectile>("RedArrow2").Type, npc.damage / 5, 0, Main.myPlayer, 0, 0);
                                }
                            }
                            npc.velocity *= 0.96f;
                        }
                        npc.rotation = (float)(Rlase - Math.PI / 2d);
                        return false;
                    }
                    else
                    {
                        turnLaser -= 1;
                        return true;
                    }
                }
            }
            if (npc.type == 126 && MythWorld.Myth/*魔焰眼*/)
            {
                Player player = Main.player[npc.target];
                if (npc.life >= npc.lifeMax * 0.4f)
                {
                    if(Curse == 0)
                    {
                        Rancurse = Main.rand.Next(100);
                    }
                    Curse += 1;
                    if (Curse > 0 && Curse < 600)
                    {
                        float r0 = (float)(Rcurs % (Math.PI * 2d));
                        Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 15f;
                        float r1 = (float)(Math.Atan2(v.Y, v.X));
                        float r2 = r0 - r1;
                        if (r2 > Math.PI)
                        {
                            r1 += (float)(Math.PI * 2d);
                        }
                        if (r2 < -Math.PI)
                        {
                            r1 -= (float)(Math.PI * 2d);
                        }
                        Rcurs = r0 * 0.9f + r1 * 0.1f;
                        Vector2 vIntend = player.Center + new Vector2(350 * (Rancurse % 2 - 0.5f) * 2, 0);
                        npc.velocity += (vIntend - npc.Center) / (vIntend - npc.Center).Length() * 2f;
                        if (npc.velocity.Length() > 25)
                        {
                            npc.velocity *= 25f / npc.velocity.Length();
                        }
                        npc.velocity *= 0.95f;
                        if (Curse % 60 == 0)
                        {
                            Vector2 vi = new Vector2(0, 15).RotatedBy(npc.rotation);
                            Projectile.NewProjectile(npc.Center.X + vi.X * 5f, npc.Center.Y + vi.Y * 5f, vi.X, vi.Y, Mod.Find<ModProjectile>("SuperCurseBallHost").Type, npc.damage, 0, Main.myPlayer, 0, 0);
                        }
                    }
                    if(Curse > 600 && Curse < 1500)
                    {
                        npc.velocity *= 0.9f;
                        if (npc.velocity.Length() < 2 && CanRush)
                        {
                            Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 40f;
                            npc.velocity += v;
                            CanRush = false;
                        }
                        if (!CanRush)
                        {
                            Rcurs = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                        }
                        if (npc.velocity.Length() < 5)
                        {
                            CanRush = true;
                            float r0 = (float)(Rcurs % (Math.PI * 2d));
                            Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 15f;
                            float r1 = (float)(Math.Atan2(v.Y, v.X));
                            float r2 = r0 - r1;
                            if (r2 > Math.PI)
                            {
                                r1 += (float)(Math.PI * 2d);
                            }
                            if (r2 < -Math.PI)
                            {
                                r1 -= (float)(Math.PI * 2d);
                            }
                            Rcurs = r0 * 0.9f + r1 * 0.1f;
                        }
                    }
                    if (Curse > 1500 && Curse < 2100)
                    {
                        float r0 = (float)(Rcurs % (Math.PI * 2d));
                        Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 15f;
                        float r1 = (float)(Math.Atan2(v.Y, v.X));
                        float r2 = r0 - r1;
                        if (r2 > Math.PI)
                        {
                            r1 += (float)(Math.PI * 2d);
                        }
                        if (r2 < -Math.PI)
                        {
                            r1 -= (float)(Math.PI * 2d);
                        }
                        Rcurs = r0 * 0.9f + r1 * 0.1f;
                        Vector2 vIntend = player.Center + new Vector2(500 * (Rancurse % 2 - 0.5f) * 2, 0);
                        npc.velocity += (vIntend - npc.Center) / (vIntend - npc.Center).Length() * 2f;
                        if (npc.velocity.Length() > 25)
                        {
                            npc.velocity *= 25f / npc.velocity.Length();
                        }
                        npc.velocity *= 0.95f;
                        if (Curse % 60 == 0)
                        {
                            int M = Main.rand.Next(6);
                            Vector2 vi = new Vector2(0, 15).RotatedBy(npc.rotation);
                            if(M == 0)
                            {
                                for(int j = 0;j < 12;j++)
                                {
                                    Vector2 vj = new Vector2(0, 5).RotatedBy(j / 6d * Math.PI);
                                    Projectile.NewProjectile(npc.Center.X + vi.X * 5f, npc.Center.Y + vi.Y * 5f, vi.X + vj.X, vi.Y + vj.Y, 96, npc.damage / 5, 0, Main.myPlayer, 0, 0);
                                }
                            }
                            if (M == 1)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    Vector2 vj = vi.RotatedBy((j - 3.5f) / 16d * Math.PI);
                                    Projectile.NewProjectile(npc.Center.X + vi.X * 5f, npc.Center.Y + vi.Y * 5f, vj.X, vj.Y, 96, npc.damage / 5, 0, Main.myPlayer, 0, 0);
                                }
                            }
                            if (M == 2)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    Vector2 vj = vi * j / 6f;
                                    Projectile.NewProjectile(npc.Center.X + vi.X * 5f, npc.Center.Y + vi.Y * 5f, vj.X, vj.Y, 96, npc.damage / 5, 0, Main.myPlayer, 0, 0);
                                }
                            }
                            if (M == 3)
                            {
                                for (int j = 0; j < 16; j++)
                                {
                                    Vector2 vj = vi + new Vector2(0, (j - 8) * 4);
                                    Projectile.NewProjectile(npc.Center.X + vi.X * 5f, npc.Center.Y + vi.Y * 5f, vj.X, vj.Y, 96, npc.damage / 5, 0, Main.myPlayer, 0, 0);
                                }
                            }
                            if (M == 4)
                            {
                                Projectile.NewProjectile(npc.Center.X + vi.X * 5f, npc.Center.Y + vi.Y * 5f, vi.X, vi.Y, Mod.Find<ModProjectile>("CurseBallSplit").Type, npc.damage / 5, 0, Main.myPlayer, 0, 0);
                            }
                            if (M == 5)
                            {
                                for (int j = 0; j < 4; j++)
                                {
                                    Vector2 vj = vi.RotatedBy((j - 1.5f) / 8d * Math.PI);
                                    Projectile.NewProjectile(npc.Center.X + vi.X * 5f, npc.Center.Y + vi.Y * 5f, vj.X, vj.Y, 96, npc.damage / 5, 0, Main.myPlayer, 0, 0);
                                }
                                for (int j = 0; j < 5; j++)
                                {
                                    Vector2 vj = vi.RotatedBy((j - 2f) / 8d * Math.PI) * 0.7f;
                                    Projectile.NewProjectile(npc.Center.X + vi.X * 5f, npc.Center.Y + vi.Y * 5f, vj.X, vj.Y, 96, npc.damage / 5, 0, Main.myPlayer, 0, 0);
                                }
                            }
                        }
                    }
                    if (Curse > 2100)
                    {
                        Curse = 0;
                    }
                    npc.rotation = (float)(Rcurs - Math.PI / 2d);
                    return false;
                }
                else
                {
                    if (turnCurse <= 0)
                    {
                        turnCurse = 0;
                        if (mplayer.TwinslocalAIMyth < 600)
                        {
                            if (mplayer.TwinslocalAIMyth % 90 == 1)
                            {
                                for (int h = 0; h < 16; h++)
                                {
                                    Vector2 v1 = new Vector2(0, 12).RotatedBy(h / 8d * Math.PI);
                                    Projectile.NewProjectile(npc.Center.X + v1.X * 2.5f, npc.Center.Y + v1.Y * 2.5f, v1.X, v1.Y, 96, npc.damage / 5, 0, Main.myPlayer, 0, 0);
                                }
                            }
                            npc.velocity *= 0.96f;
                            if (npc.velocity.Length() < 2 && CanRush)
                            {
                                Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 31f;
                                npc.velocity += v;
                                CanRush = false;
                            }
                            if (!CanRush)
                            {
                                Rcurs = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                            }
                            if (npc.velocity.Length() < 5)
                            {
                                CanRush = true;
                                float r0 = (float)(Rcurs % (Math.PI * 2d));
                                Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 15f;
                                float r1 = (float)(Math.Atan2(v.Y, v.X));
                                float r2 = r0 - r1;
                                if (r2 > Math.PI)
                                {
                                    r1 += (float)(Math.PI * 2d);
                                }
                                if (r2 < -Math.PI)
                                {
                                    r1 -= (float)(Math.PI * 2d);
                                }
                                Rcurs = r0 * 0.9f + r1 * 0.1f;
                            }
                        }
                        if(mplayer.TwinslocalAIMyth > 600 && mplayer.TwinslocalAIMyth < 1200)
                        {
                            Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() / 3f;
                            npc.velocity += v;
                            Rcurs = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                            if(npc.velocity.Length() > 13f)
                            {
                                npc.velocity *= 13f / npc.velocity.Length();
                            }
                            if(mplayer.TwinslocalAIMyth % 10 == 0)
                            {
                                Vector2 v1 = new Vector2(0, 10).RotatedBy(npc.rotation);
                                Projectile.NewProjectile(npc.Center.X + v1.X * 2.5f, npc.Center.Y + v1.Y * 2.5f, v1.X, v1.Y, 101,(int)(npc.damage / 2.6), 0, Main.myPlayer, 0, 0);
                            }
                            if (mplayer.TwinslocalAIMyth % 30 == 15)
                            {
                                Vector2 v1 = new Vector2(0, 8).RotatedBy(npc.rotation);
                                Projectile.NewProjectile(npc.Center.X + v1.X * 2.5f, npc.Center.Y + v1.Y * 2.5f, v1.X, v1.Y, 96, (int)(npc.damage / 2.6), 0, Main.myPlayer, 0, 0);
                            }
                        }
                        if (mplayer.TwinslocalAIMyth > 1200 && mplayer.TwinslocalAIMyth < 2000)
                        {
                            npc.velocity *= 0.96f;
                            if (npc.velocity.Length() < 2 && CanRush)
                            {
                                Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 31f;
                                npc.velocity += v;
                                Vector2 v1 = new Vector2(0, 12);
                                for (int h = 0; h < 4; h++)
                                {
                                    Vector2 v2 = v1.RotatedBy(h / 2d * Math.PI);
                                    for (int a = 0; a < 3; a++)
                                    {
                                        Vector2 v3 = v2.RotatedBy((a - 1) / 2.8);
                                        Projectile.NewProjectile(npc.Center.X + v3.X * 2.5f, npc.Center.Y + v3.Y * 2.5f, v3.X, v3.Y, 96, npc.damage / 5, 0, Main.myPlayer, 0, 0);
                                    }
                                }
                                CanRush = false;
                            }
                            if (!CanRush)
                            {
                                Rcurs = (float)(Math.Atan2(npc.velocity.Y, npc.velocity.X));
                            }
                            if (npc.velocity.Length() < 5)
                            {
                                CanRush = true;
                                float r0 = (float)(Rcurs % (Math.PI * 2d));
                                Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 15f;
                                float r1 = (float)(Math.Atan2(v.Y, v.X));
                                float r2 = r0 - r1;
                                if (r2 > Math.PI)
                                {
                                    r1 += (float)(Math.PI * 2d);
                                }
                                if (r2 < -Math.PI)
                                {
                                    r1 -= (float)(Math.PI * 2d);
                                }
                                Rcurs = r0 * 0.9f + r1 * 0.1f;
                            }
                        }
                        if (mplayer.TwinslocalAIMyth > 2000 && mplayer.TwinslocalAIMyth < 2300)
                        {
                            float r0 = (float)(Rcurs % (Math.PI * 2d));
                            Vector2 v = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 15f;
                            float r1 = (float)(Math.Atan2(v.Y, v.X));
                            float r2 = r0 - r1;
                            if (r2 > Math.PI)
                            {
                                r1 += (float)(Math.PI * 2d);
                            }
                            if (r2 < -Math.PI)
                            {
                                r1 -= (float)(Math.PI * 2d);
                            }
                            Rcurs = r0 * 0.9f + r1 * 0.1f;
                            npc.velocity *= 0.95f;
                            if(mplayer.TwinslocalAIMyth % 10 == 0)
                            {
                                Vector2 vz = new Vector2(0, Main.rand.NextFloat(15f, 600f)).RotatedByRandom(Math.PI * 2d);
                                Projectile.NewProjectile(player.Center.X + vz.X, player.Center.Y + vz.Y, 0, 0, Mod.Find<ModProjectile>("CurseBallStrengthen").Type, npc.damage / 3, 0, Main.myPlayer, 0, 0);
                            }
                        }
                        npc.rotation = (float)(Rcurs - Math.PI / 2d);
                    }
                    else
                    {
                        turnCurse -= 1;
                        return true;
                    }
                }
            }
            return true;
        }
        public override bool PreKill(NPC npc)
        {
            if (npc.type == 50 && npc.ai[3] == 9999)
            {
                return false;
            }
            return base.PreKill(npc);
        }
        public override void OnKill(NPC npc)
        {
            Player player = Main.LocalPlayer;
            if (npc.boss)
            {
                int kz = 100;
                if (Main.expertMode)
                {
                    kz = 60;
                }
                if (MythWorld.Myth)
                {
                    kz = 30 / MythWorld.MythIndex;
                }
                if (Main.rand.Next(kz) == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("MagicStone").Type, 1, false, 0, false, false);
                }
            }
            Mod Cmod = ModLoader.GetMod("CalamityMod");
            if (ModLoader.GetMod("CalamityMod") != null)
            {
                if (npc.type == Cmod.Find<ModNPC>("DesertScourgeHead").Type)
                {
                    if (MythWorld.Myth)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("SwordDESER").Type, 1, false, 0, false, false);
                    }
                }
                if (npc.type == Cmod.Find<ModNPC>("CrabulonIdle").Type)
                {
                    if (MythWorld.Myth)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("SwordCRA").Type, 1, false, 0, false, false);
                    }
                }
            }
            if(player.ZoneSnow)
            {
                if(Main.rand.Next(500) == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("FreezingClub").Type, 1, false, 0, false, false);
                }
                if(Main.bloodMoon && Main.hardMode)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("CrimsonAxePlus").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 74)
            {
                if (Main.rand.Next(5) == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("BirdFeather").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 298)
            {
                if (Main.rand.Next(5) == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("RedBirdFeather").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 297)
            {
                if (Main.rand.Next(5) == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("BlueBirdFeather").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 442)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("GoldBirdFeather").Type, 1, false, 0, false, false);
            }
            if (npc.type == 48)
            {
                if(Main.expertMode)
                {
                    if (Main.rand.Next(125) == 25)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("FeatherMagic").Type, 1, false, 0, false, false);
                    }
                }
                else
                {
                    if (Main.rand.Next(250) == 25)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("FeatherMagic").Type, 1, false, 0, false, false);
                    }
                }
            }
            if (player.ZoneCorrupt && Main.hardMode)
            {
                if (Main.rand.Next(350) == 25)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("CurseClub").Type, 1, false, 0, false, false);
                }
            }
            if (player.ZoneHallow && Main.hardMode)
            {
                if (Main.rand.Next(350) == 25)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("CrystalClub").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 301)
            {
                if (Main.rand.Next(150) == 25)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("CrowSickle").Type, 1, false, 0, false, false);
                }
            }
            if (player.ZoneCrimson && Main.hardMode)
            {
                if (Main.rand.Next(350) == 25)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("BloodLiquidClub").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 50)
            {
                if (MythWorld.Myth)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("KSChest").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 493)
            {
                if (MythWorld.Myth)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("StardustStaff").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 507)
            {
                if (MythWorld.Myth)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("NebulaMysteriousStaff").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 422)
            {
                if (MythWorld.Myth)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("AlienSpike").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 517)
            {
                if (MythWorld.Myth)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("SolarSwirl").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 439)
            {
                if (MythWorld.Myth)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("LuChest").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 245)
            {
                if (MythWorld.Myth)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("GolChest").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 2)
            {
                if (Main.rand.Next(1000) > 950)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("CrystalKnife").Type, 1, false, 0, false, false);
                }
            }
            if (npc.boss && !Main.hardMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("MagicI").Type, Main.rand.Next(1, 3), false, 0, false, false);
                if (Main.expertMode)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("MagicI").Type, Main.rand.Next(1, 3), false, 0, false, false);
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("MagicII").Type, Main.rand.Next(1, 2), false, 0, false, false);
                    if (MythWorld.Myth)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("MagicII").Type, Main.rand.Next(1, 2), false, 0, false, false);
                        if (Main.rand.Next(3) == 1)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("MagicIII").Type, 1, false, 0, false, false);
                        }
                    }
                }
            }
            if (npc.boss && Main.hardMode)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("MagicI").Type, Main.rand.Next(1, 5), false, 0, false, false);
                if (Main.expertMode)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("MagicII").Type, Main.rand.Next(1, 5), false, 0, false, false);
                    if (MythWorld.Myth)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("MagicII").Type, Main.rand.Next(1, 3), false, 0, false, false);
                        if (Main.rand.Next(2) == 1)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("MagicIII").Type, Main.rand.Next(1, 3), false, 0, false, false);
                            if (Main.rand.Next(2) == 1)
                            {
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("MagicIV").Type, 1, false, 0, false, false);
                            }
                        }
                        if (MythWorld.downedMoonLoad)
                        {
                            if (Main.rand.Next(3) == 1)
                            {
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("MagicIII").Type, 1, false, 0, false, false);
                                if (Main.rand.Next(2) == 1)
                                {
                                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("MagicIV").Type, 1, false, 0, false, false);
                                }
                            }
                        }
                    }
                }
            }
            if (npc.lifeMax > 200 && !npc.boss)
            {
                if (Main.rand.Next(20) == 1)
                {
                    if (Main.expertMode)
                    {
                        if (MythWorld.Myth)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("EmpMagic").Type, 1, false, 0, false, false);
                        }
                        else
                        {
                            if (Main.rand.Next(2) == 1)
                            {
                                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("EmpMagic").Type, 1, false, 0, false, false);
                            }
                        }
                    }
                    else
                    {
                        if (Main.rand.Next(5) == 1)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("EmpMagic").Type, 1, false, 0, false, false);
                        }
                    }
                }
            }
            if (npc.type == 398)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("MLChest").Type, 1, false, 0, false, false);
            }
            if (npc.type == 125)
            {
                if (MythWorld.Myth)
                {
                }
                else
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("LazarBattery").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 126)
            {
                if (MythWorld.Myth)
                {
                }
                else
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("LazarBattery").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 113)
            {
                if (MythWorld.Myth)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("FleChest").Type, 1, false, 0, false, false);
                }
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("SealTableOfOcean").Type, 1, false, 0, false, false);
            }
            if (npc.type == 127)
            {
                if (MythWorld.Myth)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("SkePChest").Type, 1, false, 0, false, false);
                }
                else
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("LazarBattery").Type, Main.expertMode ? 2 : 1, false, 0, false, false);
                }
            }
            if (npc.type == 134)
            {
                if (MythWorld.Myth)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("DesChest").Type, 1, false, 0, false, false);
                }
                else
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("LazarBattery").Type, Main.expertMode ? 2 : 1, false, 0, false, false);
                }
            }
            if (npc.type == 262)
            {
                if (MythWorld.Myth)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("PlaChest").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 370)
            {
                if (MythWorld.Myth)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("DukChest").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 35)
            {
                if (MythWorld.Myth)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("SkeChest").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 222)
            {
                if (MythWorld.Myth)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("QBChest").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 150 || npc.type == 51 || npc.type == 60 || npc.type == 49 || npc.type == 93 || npc.type == 151 || npc.type == 137)
            {
                if (Main.rand.Next(30) == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("BatMeat").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 345)
            {
                if (MythWorld.downedMoonLoad && Main.rand.Next(5) == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("SoulOfFrozen").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type >= 87 && npc.type <= 92)
            {
                if (Main.rand.Next(150) == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("ThunderFlower").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type >= 454 && npc.type <= 459)
            {
                if (Main.rand.Next(150) == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("ShadowFlower").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 344)
            {
                if (MythWorld.downedMoonLoad && Main.rand.Next(5) == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("SoulOfPine").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 346)
            {
                if (MythWorld.downedMoonLoad && Main.rand.Next(5) == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("MaChineSoul").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 140)
            {
                if (Main.rand.Next(100) == 14)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("AmbiguousNight").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 21 || npc.type == 201 || npc.type == 202 || npc.type == 203 || npc.type == 322 || npc.type == 323 || npc.type == 324 || npc.type == 449 || npc.type == 450 || npc.type == 451 || npc.type == 452 || npc.type == -46 || npc.type == -47 || npc.type == -48 || npc.type == -49 || npc.type == -50 || npc.type == -51 || npc.type == -52 || npc.type == -53)
            {
                if (Main.rand.Next(100) == 14)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("GreatBlade").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 64 && Main.hardMode)
            {
                if (Main.rand.Next(20) == 14)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("MysteriesBroken").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 67 && Main.hardMode)
            {
                if (Main.rand.Next(20) == 14)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("MysteriesBroken").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 65 && Main.hardMode)
            {
                if (Main.rand.Next(20) == 14)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("MysteriesBroken").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 221 && Main.hardMode)
            {
                if (Main.rand.Next(20) == 14)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("MysteriesBroken").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 4)
            {
                if (MythWorld.Myth)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("EOCChest").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 266)
            {
                if (MythWorld.Myth)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("BOCChest").Type, 1, false, 0, false, false);
                }
            }
            if (npc.type == 15)
            {
                if (MythWorld.Myth)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.Mod.Find<ModItem>("EOWChest").Type, 1, false, 0, false, false);
                }
            }
        }
        public override void ResetEffects(NPC npc)
        {
            this.Stunned = false;
            this.ElectriShock = false;
        }
        public override void HitEffect(NPC npc, NPC.HitInfo hit)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Player player = Main.LocalPlayer;
            if (mplayer.KiBo > 0)
            {
                npc.defense = 0;
            }
            if (player.HasBuff(Mod.Find<ModBuff>("嗜血狂暴").Type))
            {
                mplayer.Crazyindex += Main.rand.Next(1, 3);
            }
            if (npc.type == 135 && MythWorld.Myth/*毁灭者*/ && npc.life < npc.lifeMax * 0.5f)
            {
                if (Main.rand.Next(40) == 1)
                {
                    int y = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, Mod.Find<ModNPC>("ExploreMonster2").Type, 0, 0f, 0f, 0f, 0f, 255);
                    Main.npc[y].velocity = new Vector2(0, Main.rand.NextFloat(0.5f, 7f)).RotatedByRandom(Math.PI * 2);
                }
                if (Main.rand.Next(40) == 1)
                {
                    int y = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, Mod.Find<ModNPC>("ExploreMonster3").Type, 0, 0f, 0f, 0f, 0f, 255);
                    Main.npc[y].velocity = new Vector2(0, Main.rand.NextFloat(0.5f, 7f)).RotatedByRandom(Math.PI * 2);
                }
            }
            if (MythWorld.Myth)
            {
                if (npc.type == 13)
                {
                    if (npc.life <= 0)
                    {
                        Vector2 vector10 = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                        NPC.NewNPC((int)vector10.X, (int)vector10.Y, 6, 0, 0f, 0f, 0f, 0f, 255);
                        Vector2 vector6 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        float num35 = 0.783f;
                        double num36 = Math.Atan2((double)npc.velocity.X, (double)npc.velocity.Y) - (double)(num35 / 2f);
                        double num37 = (double)(num35 / 8f);
                        for (int k = 0; k < 6; k++)
                        {
                            int timeLeft = Main.rand.Next(400, 700);
                            double num39 = num36 + num37 * (double)(k + k * k) / 2.0 + (double)(32f * (float)k);
                            int num42 = Main.rand.Next(4);
                            if (num42 == 1)
                            {
                                int num43 = Projectile.NewProjectile(vector6.X, vector6.Y, (float)(-(float)Math.Sin(num39) * 6.0), (float)(-(float)Math.Cos(num39) * 6.0), 96, 88, 0f, Main.myPlayer, 0f, 0f);
                                Main.projectile[num43].timeLeft = 600;
                                Main.projectile[num43].tileCollide = false;
                            }
                        }
                    }
                }
                if(npc.type == 113 || npc.type == 114)
                {
                    int num42 = Main.rand.Next(6);
                    if (num42 == 1)
                    {
                        int num43 = Projectile.NewProjectile(npc.Center.X - npc.velocity.X * 5f, npc.Center.Y, 0, 0, Mod.Find<ModProjectile>("WOFGore" + Main.rand.Next(6).ToString()).Type, 88, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
                if (MythWorld.MythIndex >= 2 && npc.type == 13)
                {
                    if (Main.rand.Next(10) == 1)
                    {
                        int num = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("EndlessCurseFlame").Type, (int)((double)npc.damage * 0.5f), 0.5f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num].friendly = false;
                        Main.projectile[num].hostile = true;
                        Vector2 vector10 = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                        NPC.NewNPC((int)vector10.X, (int)vector10.Y, 6, 0, 0f, 0f, 0f, 0f, 255);
                        Vector2 vector6 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        float num35 = 0.783f;
                        double num36 = Math.Atan2((double)npc.velocity.X, (double)npc.velocity.Y) - (double)(num35 / 2f);
                        double num37 = (double)(num35 / 8f);
                        for (int k = 0; k < 6; k++)
                        {
                            int timeLeft = Main.rand.Next(400, 700);
                            double num39 = num36 + num37 * (double)(k + k * k) / 2.0 + (double)(32f * (float)k);
                            int num42 = Main.rand.Next(4);
                            if (num42 == 1)
                            {
                                int num43 = Projectile.NewProjectile(vector6.X, vector6.Y, (float)(-(float)Math.Sin(num39) * 6.0), (float)(-(float)Math.Cos(num39) * 6.0), 96, 88, 0f, Main.myPlayer, 0f, 0f);
                                Main.projectile[num43].timeLeft = 600;
                                Main.projectile[num43].tileCollide = false;
                            }
                        }
                    }
                }
                if (MythWorld.MythIndex >= 2 && npc.type == 14)
                {
                    if (Main.rand.Next(30) == 1)
                    {
                        int num = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("EndlessCurseFlame").Type, (int)((double)npc.damage * 0.5f), 0.5f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num].friendly = false;
                        Main.projectile[num].hostile = true;
                        Vector2 vector10 = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                        NPC.NewNPC((int)vector10.X, (int)vector10.Y, 6, 0, 0f, 0f, 0f, 0f, 255);
                        Vector2 vector6 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        float num35 = 0.783f;
                        double num36 = Math.Atan2((double)npc.velocity.X, (double)npc.velocity.Y) - (double)(num35 / 2f);
                        double num37 = (double)(num35 / 8f);
                        for (int k = 0; k < 6; k++)
                        {
                            int timeLeft = Main.rand.Next(400, 700);
                            double num39 = num36 + num37 * (double)(k + k * k) / 2.0 + (double)(32f * (float)k);
                            int num42 = Main.rand.Next(4);
                            if (num42 == 1)
                            {
                                int num43 = Projectile.NewProjectile(vector6.X, vector6.Y, (float)(-(float)Math.Sin(num39) * 6.0), (float)(-(float)Math.Cos(num39) * 6.0), 96, 88, 0f, Main.myPlayer, 0f, 0f);
                                Main.projectile[num43].timeLeft = 600;
                                Main.projectile[num43].tileCollide = false;
                            }
                        }
                    }
                }
                if (MythWorld.MythIndex >= 2 && npc.type == 15)
                {
                    if (Main.rand.Next(30) == 1)
                    {
                        int num = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("EndlessCurseFlame").Type, (int)((double)npc.damage * 0.5f), 0.5f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num].friendly = false;
                        Main.projectile[num].hostile = true;
                    }
                }
                if (npc.type == 131)
                {
                    /*if (npc.life <= 0)
                    {
                        Vector2 vector10 = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                        NPC.NewNPC((int)vector10.X, (int)vector10.Y, mod.NPCType("MachineLaser"), 0, 0f, 0f, 0f, 0f, 255);
                    }*/
                }
                if (npc.type == 128)
                {
                    /*if (npc.life <= 0)
                    {
                        Vector2 vector10 = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                        NPC.NewNPC((int)vector10.X, (int)vector10.Y, mod.NPCType("MachineGun"), 0, 0f, 0f, 0f, 0f, 255);
                    }*/
                }
                if (npc.type == 129)
                {
                    /*if (npc.life <= 0)
                    {
                        Vector2 vector10 = npc.Center + new Vector2(0f, (float)npc.height / 2f);
                        NPC.NewNPC((int)vector10.X, (int)vector10.Y, mod.NPCType("Geer"), 0, 0f, 0f, 0f, 0f, 255);
                    }*/
                }
                if (npc.type == 266)
                {
                    if (npc.life <= 1)
                    {
                        Main.projectile[num53].timeLeft = 0;
                        Main.projectile[num55].timeLeft = 0;
                        Main.projectile[num56].timeLeft = 0;
                        Main.projectile[num57].timeLeft = 0;
                        KSLZN = true;
                    }
                }
                if (npc.type == 127)
                {
                    if (npc.life <= 30000)
                    {
                        Main.projectile[num75].timeLeft = 0;
                        Main.projectile[num77].timeLeft = 0;
                        Main.projectile[num78].timeLeft = 0;
                        Main.projectile[num79].timeLeft = 0;
                        Main.projectile[num81].timeLeft = 0;
                    }
                }
            }
            if (MythWorld.Myth)
            {
                /*if (npc.type == 126 && npc.ai[3] != 99999)
                {
                    if (npc.life <= 700)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 50, mod.NPCType("CursePlus"), 0, 0f, 0f, 0f, 0f, 255);
                        npc.active = false;
                        npc.life = 0;
                        for (int i = 0; i < 500; i++)
                        {
                            float num7 = (float)Main.rand.Next(0, 62832) / 4000f;
                            float num8 = (float)Main.rand.Next(0, 62832) / 4000f;
                            int num9 = Dust.NewDust(npc.Center, 1, 1, 75, 0, 0, 0, default(Color), 6f);
                            Main.dust[num9].velocity.X = (float)Math.Cos(num7) * num8;
                            Main.dust[num9].velocity.Y = (float)Math.Sin(num7) * num8;
                            Main.dust[num9].noGravity = true;
                        }
                        if (NPC.CountNPCS(125) < 1)
                        {
                            for (int p = 0; p < 200; p++)
                            {
                                if (Main.npc[p].type == mod.NPCType("LaserPlus"))
                                {
                                    Main.NewText(Language.GetTextValue("机械装置还能维持" + (Main.npc[p].lifeMax / 420).ToString() + "秒,慢慢享受吧!"), Color.Purple);
                                    break;
                                }
                            }
                        }
                    }
                }
                if (npc.type == 245)
                {
                    if (npc.life < 1)
                    {
                        golem = true;
                    }
                }
                if (npc.type == 125)
                {
                    if (npc.life <= 700)
                    {
                        NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y + 50, mod.NPCType("LaserPlus"), 0, 0f, 0f, 0f, 0f, 255);
                        npc.active = false;
                        npc.life = 0;
                        for (int i = 0; i < 16; i++)
                        {
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)Math.Sin(Math.PI * (float)i / 8f) * 20f, (float)Math.Cos(Math.PI * (float)i / 8f) * 20f, 100, 70, 0f, Main.myPlayer, 0f, 0f);
                        }
                        if (NPC.CountNPCS(126) < 1)
                        {
                            string key = (Main.maxRaining).ToString();
                            Color messageColor = Color.Purple;
                            for (int p = 0; p < 200; p++)
                            {
                                if (Main.npc[p].type == mod.NPCType("CursePlus"))
                                {
                                    Main.NewText(Language.GetTextValue("机械装置还能维持" + (Main.npc[p].lifeMax / 420).ToString() + "秒,慢慢享受吧!"), messageColor);
                                    break;
                                }
                            }
                        }
                    }
                }*/
            }
            if (npc.boss)
            {
                if (npc.life <= 0)
                {
                    mplayer.YinLife += 5;
                    mplayer.YangLife += 5;
                }
            }
            if (false)
            {
                if (npc.life <= 0)
                {
                    if (!MythWorld.downedMoonLoad)
                    {
                        MythWorld.downedMoonLoad = true;
                    }
                    for (int i = 0; i < 66; i++)
                    {
                        if (i <= 37 && i >= 34)
                        {
                            WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 - 13, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                        }
                        if (i == 19)
                        {
                            WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 - 14, (ushort)base.Mod.Find<ModTile>("海洋封印台").Type, true, false, -1, 0);
                            WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 - 23, (ushort)base.Mod.Find<ModTile>("海洋封印台").Type, true, false, -1, 0);
                            WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 - 27, (ushort)base.Mod.Find<ModTile>("海洋封印台").Type, true, false, -1, 0);
                        }
                        if ((i <= 34 && i >= 32) || (i <= 39 && i >= 37))
                        {
                            WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 - 12, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                        }
                        if (i <= 36 && i >= 35)
                        {
                            WorldGen.PlaceWall(Main.maxTilesX - 650 + i, 120 - 12, (ushort)base.Mod.Find<ModWall>("海洋密室砖墙").Type, true);
                        }
                        if ((i <= 20 && i >= 18) || (i <= 32 && i >= 31) || (i <= 40 && i >= 39))
                        {
                            WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 - 11, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                        }
                        if (i <= 38 && i >= 33)
                        {
                            WorldGen.PlaceWall(Main.maxTilesX - 650 + i, 120 - 11, (ushort)base.Mod.Find<ModWall>("海洋密室砖墙").Type, true);
                        }
                        if ((i <= 21 && i >= 17) || (i <= 31 && i >= 31) || (i <= 41 && i >= 40))
                        {
                            WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 - 10, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                        }
                        if (i <= 39 && i >= 32)
                        {
                            WorldGen.PlaceWall(Main.maxTilesX - 650 + i, 120 - 10, (ushort)base.Mod.Find<ModWall>("海洋密室砖墙").Type, true);
                        }
                        if ((i <= 22 && i >= 16) || (i <= 31 && i >= 30) || (i <= 41 && i >= 41))
                        {
                            WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 - 9, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                        }
                        if (i <= 40 && i >= 32)
                        {
                            WorldGen.PlaceWall(Main.maxTilesX - 650 + i, 120 - 9, (ushort)base.Mod.Find<ModWall>("海洋密室砖墙").Type, true);
                        }
                        if ((i <= 23 && i >= 15) || (i <= 30 && i >= 30) || (i <= 42 && i >= 41))
                        {
                            WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 - 8, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                        }
                        if (i <= 40 && i >= 31)
                        {
                            WorldGen.PlaceWall(Main.maxTilesX - 650 + i, 120 - 8, (ushort)base.Mod.Find<ModWall>("海洋密室砖墙").Type, true);
                        }
                        if ((i <= 17 && i >= 14) || (i <= 30 && i >= 21) || (i <= 45 && i >= 41))
                        {
                            WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 - 7, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                        }
                        if ((i <= 20 && i >= 18) || (i <= 40 && i >= 31))
                        {
                            WorldGen.PlaceWall(Main.maxTilesX - 650 + i, 120 - 7, (ushort)base.Mod.Find<ModWall>("海洋密室砖墙").Type, true);
                        }
                        if ((i <= 16 && i >= 14) || (i <= 30 && i >= 22) || (i <= 47 && i >= 41))
                        {
                            WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 - 6, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                        }
                        if ((i <= 21 && i >= 17) || (i <= 40 && i >= 31))
                        {
                            WorldGen.PlaceWall(Main.maxTilesX - 650 + i, 120 - 6, (ushort)base.Mod.Find<ModWall>("海洋密室砖墙").Type, true);
                        }
                        if ((i <= 4 && i >= 3) || (i <= 7 && i >= 6) || (i <= 10 && i >= 9) || (i <= 15 && i >= 12) || (i <= 29 && i >= 24) || (i <= 50 && i >= 47))
                        {
                            WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 - 5, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                        }
                        if ((i <= 23 && i >= 16) || (i <= 46 && i >= 30))
                        {
                            WorldGen.PlaceWall(Main.maxTilesX - 650 + i, 120 - 5, (ushort)base.Mod.Find<ModWall>("海洋密室砖墙").Type, true);
                        }
                        if ((i <= 14 && i >= 2) || (i <= 29 && i >= 25) || (i <= 50 && i >= 48))
                        {
                            WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 - 4, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                        }
                        if ((i <= 24 && i >= 15) || (i <= 47 && i >= 30))
                        {
                            WorldGen.PlaceWall(Main.maxTilesX - 650 + i, 120 - 4, (ushort)base.Mod.Find<ModWall>("海洋密室砖墙").Type, true);
                        }
                        if (i <= 50 && i >= 49)
                        {
                            WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 - 3, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                        }
                        if (i <= 51 && i >= 49)
                        {
                            WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 - 2, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                        }
                        if (i <= 53 && i >= 49)
                        {
                            WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 - 1, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                        }
                        if (i >= 4 && i <= 50)
                        {
                            WorldGen.PlaceWall(Main.maxTilesX - 650 + i, 120 - 3, (ushort)base.Mod.Find<ModWall>("海洋密室砖墙").Type, true);
                        }
                        if (i >= 4 && i <= 50)
                        {
                            WorldGen.PlaceWall(Main.maxTilesX - 650 + i, 120 - 2, (ushort)base.Mod.Find<ModWall>("海洋密室砖墙").Type, true);
                        }
                        if (i >= 4 && i <= 50)
                        {
                            WorldGen.PlaceWall(Main.maxTilesX - 650 + i, 120 - 1, (ushort)base.Mod.Find<ModWall>("海洋密室砖墙").Type, true);
                        }
                        if (i >= 4 && i <= 51)
                        {
                            WorldGen.PlaceWall(Main.maxTilesX - 650 + i, 120, (ushort)base.Mod.Find<ModWall>("海洋密室砖墙").Type, true);
                        }
                        if (i <= 33 || i >= 44)
                        {
                            WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                        }
                        if (i <= 34 || i >= 41)
                        {
                            if (i >= 4 && i <= 62)
                            {
                                WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 + 1, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                            }
                        }
                        else
                        {
                            WorldGen.PlaceWall(Main.maxTilesX - 650 + i, 120 + 1, (ushort)base.Mod.Find<ModWall>("海洋密室砖墙").Type, true);
                            Main.tile[Main.maxTilesX - 650 + i, 120 + 1].LiquidAmount = 1;
                        }
                        if (i <= 35 || i >= 41)
                        {
                            if (i >= 6 && i <= 54)
                            {
                                WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 + 2, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                            }
                        }
                        else
                        {
                            WorldGen.PlaceWall(Main.maxTilesX - 650 + i, 120 + 2, (ushort)base.Mod.Find<ModWall>("海洋密室砖墙").Type, true);
                            Main.tile[Main.maxTilesX - 650 + i, 120 + 2].LiquidAmount = 1;
                        }
                        if (i <= 35 || i >= 41)
                        {
                            if (i >= 14 && i <= 43)
                            {
                                WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 + 3, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                            }
                        }
                        else
                        {
                            WorldGen.PlaceWall(Main.maxTilesX - 650 + i, 120 + 3, (ushort)base.Mod.Find<ModWall>("海洋密室砖墙").Type, true);
                            Main.tile[Main.maxTilesX - 650 + i, 120 + 3].LiquidAmount = 1;
                        }
                        if (i <= 34 || i >= 42)
                        {
                            if (i >= 17 && i <= 44)
                            {
                                WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 + 4, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                            }
                        }
                        else
                        {
                            WorldGen.PlaceWall(Main.maxTilesX - 650 + i, 120 + 4, (ushort)base.Mod.Find<ModWall>("海洋密室砖墙").Type, true);
                            Main.tile[Main.maxTilesX - 650 + i, 120 + 4].LiquidAmount = 1;
                        }
                        if (i <= 34 || i >= 42)
                        {
                            if (i >= 25 && i <= 44)
                            {
                                WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 + 5, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                            }
                        }
                        else
                        {
                            WorldGen.PlaceWall(Main.maxTilesX - 650 + i, 120 + 5, (ushort)base.Mod.Find<ModWall>("海洋密室砖墙").Type, true);
                            Main.tile[Main.maxTilesX - 650 + i, 120 + 5].LiquidAmount = 1;
                        }
                        if (i <= 34 || i >= 42)
                        {
                            if (i >= 25 && i <= 44)
                            {
                                WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 + 6, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                            }
                        }
                        else
                        {
                            WorldGen.PlaceWall(Main.maxTilesX - 650 + i, 120 + 6, (ushort)base.Mod.Find<ModWall>("海洋密室砖墙").Type, true);
                            Main.tile[Main.maxTilesX - 650 + i, 120 + 6].LiquidAmount = 1;
                        }
                        if (i <= 34 || i >= 42)
                        {
                            if (i >= 26 && i <= 44)
                            {
                                WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 + 7, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                            }
                        }
                        else
                        {
                            WorldGen.PlaceWall(Main.maxTilesX - 650 + i, 120 + 7, (ushort)base.Mod.Find<ModWall>("海洋密室砖墙").Type, true);
                            Main.tile[Main.maxTilesX - 650 + i, 120 + 8].LiquidAmount = 1;
                            Main.tile[Main.maxTilesX - 650 + i, 120 + 7].LiquidAmount = 1;
                            Main.tile[Main.maxTilesX - 650 + i, 120 + 6].LiquidAmount = 1;
                            Main.tile[Main.maxTilesX - 650 + i, 120 + 5].LiquidAmount = 1;
                            Main.tile[Main.maxTilesX - 650 + i, 120 + 4].LiquidAmount = 1;
                            Main.tile[Main.maxTilesX - 650 + i, 120 + 3].LiquidAmount = 1;
                            Main.tile[Main.maxTilesX - 650 + i, 120 + 2].LiquidAmount = 1;
                            Main.tile[Main.maxTilesX - 650 + i, 120 + 1].LiquidAmount = 1;
                            Main.tile[Main.maxTilesX - 650 + i, 120].LiquidAmount = 1;
                        }
                        if (i <= 34 || i >= 42)
                        {
                            if (i >= 26 && i <= 44)
                            {
                                WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 + 8, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                            }
                        }
                        else
                        {
                            WorldGen.PlaceWall(Main.maxTilesX - 650 + i, 120 + 8, (ushort)base.Mod.Find<ModWall>("海洋密室砖墙").Type, true);
                        }
                        if (i >= 27 && i <= 44)
                        {
                            WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 + 9, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                        }
                        if (i >= 29 && i <= 40)
                        {
                            WorldGen.PlaceTile(Main.maxTilesX - 650 + i, 120 + 10, (ushort)base.Mod.Find<ModTile>("海洋石砖").Type, true, false, -1, 0);
                        }
                    }
                }
            }
        }
        private int num12 = 0;
        private int num13 = 0;
        public override bool? DrawHealthBar(NPC npc, byte hbPosition, ref float scale, ref Vector2 position)
        {
            if (MythWorld.MythIndex == 4)
            {
                return false;
            }
            return base.DrawHealthBar(npc, hbPosition, ref scale, ref position);
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (this.Stunned)
            {
                npc.velocity.X = npc.velocity.X * 0f;
                npc.velocity.Y = npc.velocity.Y * 0f;
            }
            if (npc.HasBuff(Mod.Find<ModBuff>("Freeze2").Type) && !npc.HasBuff(Mod.Find<ModBuff>("Freeze").Type))
            {
                if (4f * npc.width * npc.height / 10300f * npc.scale > 1.5f)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        Dust.NewDust(npc.position, npc.width, npc.height, 33, 0, 0, 0, default(Color), 3f);
                    }
                }
                else
                {
                    for (int i = 0; i < 20; i++)
                    {
                        Dust.NewDust(npc.position, npc.width, npc.height, 33, 0, 0, 0, default(Color), 2f);
                    }
                }
            }
        }
        public override void PostDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (npc.HasBuff(Mod.Find<ModBuff>("Freeze").Type))
            {
                npc.color = new Color(50, 50, 50, 0);
                npc.position = npc.oldPosition;
                //spriteBatch.Draw(base.mod.GetTexture("UIImages/冰封"), npc.Center, null, new Color(1,1,1,1), 0, new Vector2(2, 2), 1f, SpriteEffects.None, 0f);
                if (4f * npc.width * npc.height / 10300f * npc.scale > 1.5f)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("UIImages/冰封"), npc.Center - Main.screenPosition, null, new Color(150, 150, 150, 50), 0, new Vector2(103, 100), 1.5f, SpriteEffects.None, 0f);
                }
                else
                {
                    spriteBatch.Draw(base.Mod.GetTexture("UIImages/冰封"), npc.Center - Main.screenPosition, null, new Color(150, 150, 150, 50), 0, new Vector2(103, 100), 4f * npc.width * npc.height / 10300f * npc.scale, SpriteEffects.None, 0f);
                }
                if (!npc.noGravity)
                {
                    npc.velocity.Y += 7.5f;
                }
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
            }
            if (MythWorld.Myth)
            {
                if (npc.type == 4)
                {
                    if(npc.life <= 3000 && npc.life >= 1800)
                    {
                        float Colo = (3000 - npc.life) / 1200f; 
                        spriteBatch.Draw(base.Mod.GetTexture("UIImages/Darkness"), npc.Center - Main.screenPosition, null, new Color(Colo, Colo, Colo, Colo), 0, new Vector2(1980, 1980), 1.5f, SpriteEffects.None, 0f);
                    }
                    if (npc.life <= 1800)
                    {
                        spriteBatch.Draw(base.Mod.GetTexture("UIImages/Darkness"), npc.Center - Main.screenPosition, null, new Color(1f, 1f, 1f, 1f), 0, new Vector2(1980, 1980), 1.5f, SpriteEffects.None, 0f);
                    }
                    /*spriteBatch.Draw(base.mod.GetTexture("UIImages/DarknessPure"), new Vector2(0, 0), new Rectangle(0, 0, Dx, Main.screenHeight + 100), new Color(1f, 1f, 1f, 1f), 0, new Vector2(264, 264), 1.5f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(base.mod.GetTexture("UIImages/DarknessPure"), new Vector2(0, 0), new Rectangle(Dx, 0, 528, Dy), new Color(1f, 1f, 1f, 1f), 0, new Vector2(264, 264), 1.5f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(base.mod.GetTexture("UIImages/DarknessPure"), new Vector2(0, 0), new Rectangle(Dx + 528, 0, Main.screenWidth - 528 - Dx + 100, Main.screenHeight + 100), new Color(1f, 1f, 1f, 1f), 0, new Vector2(264, 264), 1.5f, SpriteEffects.None, 0f);
                    spriteBatch.Draw(base.mod.GetTexture("UIImages/DarknessPure"), new Vector2(0, 0), new Rectangle(Dx, 0, 528, Main.screenHeight - Dy - 528 + 100), new Color(1f, 1f, 1f, 1f), 0, new Vector2(264, 264), 1.5f, SpriteEffects.None, 0f);*/
                }
            }
        }
        public int Hitcool = 0;
        public override bool PreDraw(NPC npc, SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (MythWorld.MythIndex == 4 && Hitcool == 0)
            {
                return false;
            }
            if(Hitcool > 0)
            {
                Hitcool -= 1;
            }
            else
            {
                Hitcool = 0;
            }
            if (this.GoldFlame)
            {
                if(Main.rand.Next(3) == 1)
                {
                    int num = Dust.NewDust(npc.position - new Vector2(4, 4), npc.Hitbox.Width, npc.Hitbox.Height, 64, 0, 0, 0, default(Color), Main.rand.NextFloat(1.1f, 2.2f));
                    Main.dust[num].noGravity = false;
                    Main.dust[num].fadeIn = 1f + (float)Main.rand.NextFloat(-0.5f, 0.5f) * 0.1f;
                }
                npc.lifeRegenCount -= 30;
            }
            if (this.ElectriShock)
            {
                if (!Main.gamePaused)
                {
                    if (num6 == 8)
                    {
                        num6 = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            float num44 = (float)Main.rand.Next(0, 3600) / 1800f * 3.14159265359f;
                            double num45 = Math.Cos((float)num44);
                            double num46 = Math.Sin((float)num44);
                            float num47 = (float)Main.rand.Next(50000, 100000) / 60000f;
                            if (npc.type == NPCID.TargetDummy)
                            {
                                int num40 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)num45 * (float)num47 * 0.5f, (float)num46 * (float)num47 * 0.5f, base.Mod.Find<ModProjectile>("Lighting2").Type, 35, 2f, Main.myPlayer, 0f, 0);
                                Main.projectile[num40].tileCollide = false;
                                Main.projectile[num40].timeLeft = 200;
                            }
                            else
                            {
                                int num40 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, (float)num45 * (float)num47 * 0.7f, (float)num46 * (float)num47 * 0.7f, base.Mod.Find<ModProjectile>("Lighting2").Type, 35, 2f, Main.myPlayer, 0f, 0);
                                Main.projectile[num40].tileCollide = false;
                                Main.projectile[num40].timeLeft = 200;
                            }
                        }
                    }
                    num6++;
                }
            }
            if (npc.HasBuff(Mod.Find<ModBuff>("Freeze").Type) && npc.type == NPCID.TargetDummy)
            {
                npc.color = new Color(50, 50, 50, 0);
                npc.position = npc.oldPosition;
                //spriteBatch.Draw(base.mod.GetTexture("UIImages/冰封"), npc.Center, null, new Color(1,1,1,1), 0, new Vector2(2, 2), 1f, SpriteEffects.None, 0f);
                if (4f * npc.width * npc.height / 10300f * npc.scale > 1.5f)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("UIImages/冰封"), npc.Center - Main.screenPosition, null, new Color(150, 150, 150, 50), 0, new Vector2(103, 100), 1.5f, SpriteEffects.None, 0f);
                }
                else
                {
                    spriteBatch.Draw(base.Mod.GetTexture("UIImages/冰封"), npc.Center - Main.screenPosition, null, new Color(150, 150, 150, 50), 0, new Vector2(103, 100), 4f * npc.width * npc.height / 10300f * npc.scale, SpriteEffects.None, 0f);
                }
            }
            if (num85 < 121 && NPC.CountNPCS(127) > 0)
            {
                float l;
                Vector2 vector24 = new Vector2(Main.projectile[num75].Center.X, Main.projectile[num75].Center.Y);
                Vector2 vector25 = new Vector2(Main.projectile[num78].Center.X, Main.projectile[num78].Center.Y);
                float num80 = (float)Math.Sqrt((vector24.X - vector25.X) * (vector24.X - vector25.X) + (vector24.Y - vector25.Y) * (vector24.Y - vector25.Y));
                Vector2 unit = vector25 - vector24;
                unit.Normalize();
                float r = unit.ToRotation() - (float)Math.PI / 2f;
                for (float i = 0; i < num80; i += 2)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/骷髅守护粒子连线"), vector24 + unit * i - Main.screenPosition, null, new Color(255 * (120 - num85) / 120f, 255 * (120 - num85) / 120f, 255 * (120 - num85) / 120f, 0), r, new Vector2(2, 2), 1f, SpriteEffects.None, 0f);
                }
                Vector2 vector27 = new Vector2(Main.projectile[num77].Center.X, Main.projectile[num77].Center.Y);
                num80 = (float)Math.Sqrt((vector25.X - vector27.X) * (vector25.X - vector27.X) + (vector25.Y - vector27.Y) * (vector25.Y - vector27.Y));
                unit = vector27 - vector25;
                unit.Normalize();
                float r1 = unit.ToRotation() - (float)Math.PI / 2f;
                for (float j = 0; j < num80; j += 2)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/骷髅守护粒子连线"), vector25 + unit * j - Main.screenPosition, null, new Color(255 * (120 - num85) / 120f, 255 * (120 - num85) / 120f, 255 * (120 - num85) / 120f, 0), r1, new Vector2(2, 2), 1f, SpriteEffects.None, 0f);
                }
                Vector2 vector29 = new Vector2(Main.projectile[num79].Center.X, Main.projectile[num79].Center.Y);
                num80 = (float)Math.Sqrt((vector27.X - vector29.X) * (vector27.X - vector29.X) + (vector27.Y - vector29.Y) * (vector27.Y - vector29.Y));
                unit = vector29 - vector27;
                unit.Normalize();
                float r2 = unit.ToRotation() - (float)Math.PI / 2f;
                for (float k = 0; k < num80; k += 2)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/骷髅守护粒子连线"), vector27 + unit * k - Main.screenPosition, null, new Color(255 * (120 - num85) / 120f, 255 * (120 - num85) / 120f, 255 * (120 - num85) / 120f, 0), r2, new Vector2(2, 2), 1f, SpriteEffects.None, 0f);
                }
                num80 = (float)Math.Sqrt((vector24.X - vector29.X) * (vector24.X - vector29.X) + (vector24.Y - vector29.Y) * (vector24.Y - vector29.Y));
                unit = vector24 - vector29;
                unit.Normalize();
                float r3 = unit.ToRotation() - (float)Math.PI / 2f;
                for (l = 0; l < num80; l += 2)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/骷髅守护粒子连线"), vector29 + unit * l - Main.screenPosition, null, new Color(255 * (120 - num85) / 120f, 255 * (120 - num85) / 120f, 255 * (120 - num85) / 120f, 0), r3, new Vector2(2, 2), 1f, SpriteEffects.None, 0f);
                }
                Vector2 vector26 = new Vector2(Main.projectile[num81].Center.X - 4, Main.projectile[num81].Center.Y);
                num80 = (float)Math.Sqrt((vector26.X - vector29.X) * (vector26.X - vector29.X) + (vector26.Y - vector29.Y) * (vector26.Y - vector29.Y));
                unit = vector26 - vector29;
                unit.Normalize();
                r3 = unit.ToRotation() - (float)Math.PI / 2f;
                for (l = 0; l < num80; l += 2)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/骷髅守护粒子连线"), vector29 + unit * l - Main.screenPosition, null, new Color(255 * (120 - num85) / 120f, 255 * (120 - num85) / 120f, 255 * (120 - num85) / 120f, 0), r3, new Vector2(2, 2), 1f, SpriteEffects.None, 0f);
                }
                num80 = (float)Math.Sqrt((vector26.X - vector24.X) * (vector26.X - vector24.X) + (vector26.Y - vector24.Y) * (vector26.Y - vector24.Y));
                unit = vector26 - vector24;
                unit.Normalize();
                r3 = unit.ToRotation() - (float)Math.PI / 2f;
                for (l = 0; l < num80; l += 2)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/骷髅守护粒子连线"), vector24 + unit * l - Main.screenPosition, null, new Color(255 * (120 - num85) / 120f, 255 * (120 - num85) / 120f, 255 * (120 - num85) / 120f, 0), r3, new Vector2(2, 2), 1f, SpriteEffects.None, 0f);
                }
                num80 = (float)Math.Sqrt((vector26.X - vector27.X) * (vector26.X - vector27.X) + (vector26.Y - vector27.Y) * (vector26.Y - vector27.Y));
                unit = vector26 - vector27;
                unit.Normalize();
                r3 = unit.ToRotation() - (float)Math.PI / 2f;
                for (l = 0; l < num80; l += 2)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/骷髅守护粒子连线"), vector27 + unit * l - Main.screenPosition, null, new Color(255 * (120 - num85) / 120f, 255 * (120 - num85) / 120f, 255 * (120 - num85) / 120f, 0), r3, new Vector2(2, 2), 1f, SpriteEffects.None, 0f);
                }
                num80 = (float)Math.Sqrt((vector26.X - vector25.X) * (vector26.X - vector25.X) + (vector26.Y - vector25.Y) * (vector26.Y - vector25.Y));
                unit = vector26 - vector25;
                unit.Normalize();
                r3 = unit.ToRotation() - (float)Math.PI / 2f;
                for (l = 0; l < num80; l += 2)
                {
                    spriteBatch.Draw(base.Mod.GetTexture("Projectiles/骷髅守护粒子连线"), vector25 + unit * l - Main.screenPosition, null, new Color(255 * (120 - num85) / 120f, 255 * (120 - num85) / 120f, 255 * (120 - num85) / 120f, 0), r3, new Vector2(2, 2), 1f, SpriteEffects.None, 0f);
                }
            }
            if (npc.type == 266 && !npc.dontTakeDamage)
            {
                num8 += 0.02f;
                Texture2D t = TextureAssets.Npc[266].Value;
                Player p = Main.player[Main.myPlayer];
                int num = TextureAssets.Npc[npc.type].Value.Height / 8;
                if (npc.life <= 3000)
                {
                    Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 0.5f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                    Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 0.5f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 0.5f), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                    Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 0.5f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                    Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 0.5f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 1.5f), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);

                    if (MythWorld.MythIndex >= 2)
                    {
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 1.5f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 1.5f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 1 / -9), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 1.5f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 2 / -9), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 1.5f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 3 / -9), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 1.5f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 4 / -9), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 1.5f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 5 / -9), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 1.5f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 6 / -9), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 1.5f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 7 / -9), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 1.5f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 8 / -9), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                    }
                    if (MythWorld.MythIndex >= 3)
                    {
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 3f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 3f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 1 / 15), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 3f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 2 / 15), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 3f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 3 / 15), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 3f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 4 / 15), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 3f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 5 / 15), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 3f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 6 / 15), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 3f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 7 / 15), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 3f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 8 / 15), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 3f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 9 / 15), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 3f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 10 / 15), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 3f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 11 / 15), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 3f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 12 / 15), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 3f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 13 / 15), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) * 3f).RotatedBy((npc.Center - p.Center).Length() / 200f * 0.5f + Math.PI * 14 / 15), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);

                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) / (npc.Center - p.Center).Length() * 300f).RotatedBy(Math.Sin(num8) * 2f), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) / (npc.Center - p.Center).Length() * 300f).RotatedBy(Math.Sin(num8) * 2f + Math.PI * 2 / 5f), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) / (npc.Center - p.Center).Length() * 300f).RotatedBy(Math.Sin(num8) * 2f + Math.PI * 4 / 5f), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) / (npc.Center - p.Center).Length() * 300f).RotatedBy(Math.Sin(num8) * 2f + Math.PI * 6 / 5f), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) / (npc.Center - p.Center).Length() * 300f).RotatedBy(Math.Sin(num8) * 2f + Math.PI * 8 / 5f), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((3000f - npc.life) / (3000f) + 0.1f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                    }
                }

                if (npc.life <= 2000)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) / (npc.Center - p.Center).Length() * 500f).RotatedBy(Math.Sin(num8 / 2f) * 2f + Math.PI * 2 * i / 7f), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((2000 - npc.life) / 2000f + 0.5f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                    }

                    for (int i = 0; i < 12; i++)
                    {
                        Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + ((npc.Center - p.Center) / (npc.Center - p.Center).Length() * 700f * (1 + (float)Math.Sin(num8 * 4) / 1.5f)).RotatedBy(Math.Sin(num8 / 2f) * 2f + Math.PI * 2 * i / 12f), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor) * 0.9f * ((2000 - npc.life) / 2000f + 0.5f), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                    }
                }

                Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + new Vector2((npc.Center.X - p.Center.X) * -1.8f, p.Center.Y - npc.Center.Y), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
                Main.spriteBatch.Draw(t, p.Center - Main.screenPosition + new Vector2(0f, p.gfxOffY) + new Vector2((npc.Center.X - p.Center.X) * -2.7f, -(p.Center.Y - npc.Center.Y) * 0.5f), new Rectangle?(new Rectangle(0, npc.frame.Y, t.Width, num)), npc.GetAlpha(lightColor), npc.rotation, new Vector2((float)t.Width / 2f, (float)num / 2f), npc.scale, SpriteEffects.None, 1f);
            }
            return true;
        }
        public bool KSLZN = true;
        private int num6 = 0;
        private float num8 = 0;
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
        }
        public bool Stunned;
        public bool BIAOJI;
        public bool ElectriShock;
        public bool GoldFlame;
        public override void OnHitByProjectile(NPC npc, Projectile projectile, NPC.HitInfo hit, int damageDone)
        {
        }
        public override void OnHitPlayer(NPC npc, Player target, Player.HurtInfo hurtInfo)
        {
            if(MythWorld.MythIndex == 4)
            {
                Hitcool = 60;
            }
            base.OnHitPlayer(npc, target, damage, crit);
        }
    }
}