using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using Terraria.Graphics.Effects;
using Microsoft.Xna.Framework.Input;
using Terraria.Graphics.Shaders;
using Terraria.DataStructures;
using Terraria.Graphics;
using Terraria.GameContent.Shaders;
using Terraria.GameContent.Skies;


namespace MythMod.NPCs.LanternMoon
{
    [AutoloadBossHead]
    public class AncientTangerineTreeEye : ModNPC
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Thousand years orange monster");
			Main.npcFrameCount[base.npc.type] = 1;
			base.DisplayName.AddTranslation(GameCulture.Chinese, "千年桔树妖");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.npc.aiStyle = -1;
			base.npc.damage = 0;
			base.npc.width = 242;
			base.npc.height = 226;
			base.npc.defense = 90;
            if (Main.expertMode)
            {
                base.npc.lifeMax = 450000;
                if (MythWorld.Myth)
                {
                    base.npc.lifeMax = 300000;
                }
            }
            else
            {
                base.npc.lifeMax = 300000;
            }
            npc.behindTiles = true;
            base.npc.dontTakeDamage = false;
            base.npc.knockBackResist = 0f;
			base.npc.value = (float)Item.buyPrice(0, 50, 0, 0);
			base.npc.alpha = 0;
            base.npc.scale = 1;
            base.npc.lavaImmune = true;
			base.npc.noGravity = true;
			base.npc.noTileCollide = true;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
            base.npc.boss = true;
            this.music = mod.GetSoundSlot((Terraria.ModLoader.SoundType)51, "Sounds/Music/Powerless-Eclipse橘子树");
        }
        private int i0 = 0;
        public static bool canai = false;
        private bool can2ai = false;
        public override void HitEffect(int hitDirection, double damage)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.LanternMoonPoint = 100000 - (int)(npc.life / (float)npc.lifeMax * 10000f);
            if (base.npc.life <= 0)
            {
                for (int k = 0; k <= 30; k++)
                {
                    Vector2 v = new Vector2(0, Main.rand.Next(0, 140)).RotatedByRandom(Math.PI * 2);
                    int num4 = Projectile.NewProjectile(npc.Center.X + v.X, npc.Center.Y + v.Y, 0, 0, base.mod.ProjectileType("GreenFireGas"), 0, 0, Main.myPlayer, Main.rand.Next(1000, 3000) / 1000f, 0f);
                }
                mplayer.LanternMoonPoint = 100010;
            }
        }
        public override bool CheckActive()
        {
            return Main.dayTime;
        }
        public override void AI()
        {
            Player player = Main.player[Main.myPlayer];
            if (i0 == 0)
            {
                npc.localAI[0] = 0;
                i0 += 1;
                for (int h = 0; h < 4; h++)
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AncientTangerineTreeHand"), 0, h * 0.30333f + 0.4f, 1);
                }
                for (int h = 0; h < 6; h++)
                {
                    M[h] = -1;
                }
                for (int h = 0; h < 4; h++)
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("AncientTangerineTreeHand"), 0, h * 0.30333f + 0.4f, -1);
                }
            }
            if (NPC.CountNPCS(mod.NPCType("VerdantTangerine")) + NPC.CountNPCS(mod.NPCType("LachangGhost")) + NPC.CountNPCS(mod.NPCType("BumpTangyuan")) + NPC.CountNPCS(mod.NPCType("OrchidSprite")) + NPC.CountNPCS(mod.NPCType("StrawberrySlime") + NPC.CountNPCS(mod.NPCType("StrawberrySlime1")) + NPC.CountNPCS(mod.NPCType("MilkSlime")) + NPC.CountNPCS(mod.NPCType("MilkSlime1")) + NPC.CountNPCS(mod.NPCType("OrangeSlime")) + NPC.CountNPCS(mod.NPCType("OrangeSlime1")) + NPC.CountNPCS(mod.NPCType("AppleSlime")) + NPC.CountNPCS(mod.NPCType("AppleSlime1")) + NPC.CountNPCS(mod.NPCType("ChocolateSlime")) + NPC.CountNPCS(mod.NPCType("ChocolateSlime1")) + NPC.CountNPCS(mod.NPCType("GrapeSlime")) + NPC.CountNPCS(mod.NPCType("GrapeSlime1")) + NPC.CountNPCS(mod.NPCType("LemonSlime")) + NPC.CountNPCS(mod.NPCType("LemonSlime1"))) > 0)
            {
                npc.dontTakeDamage = true;
            }
            else
            {
                npc.dontTakeDamage = false;
                if(!canai)
                {
                    canai = true;
                }
            }
            if (NPC.CountNPCS(mod.NPCType("AncientTangerineTreeHand")) <= 0)
            {
                if(canai && i0 != 0)
                {
                    can2ai = true;
                }
                npc.defense = 90;
            }
            else
            {
                npc.defense = 600;
            }
            if (Main.dayTime)
            {
                npc.velocity.Y += 1;
            }
            if (canai)
            {
                if (!can2ai)
                {
                    npc.localAI[0] += 1;                   
                    if (npc.localAI[0] < 400)
                    {
                        if (npc.localAI[0] % 80 == 0)
                        {
                            for (int h = 0; h < 6; h++)
                            {
                                Vector2 vk = new Vector2(0, 32).RotatedBy((h + 1.5) / 3d * Math.PI);
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vk.X, vk.Y, mod.ProjectileType("GreenFlame"), 50, 0f, Main.myPlayer, 0f, 0f);
                            }
                        }
                        npc.velocity += ((player.Center - new Vector2(0, 145)) - npc.Center) / ((player.Center - new Vector2(0, 145)) - npc.Center).Length() * 0.3f;
                        npc.velocity *= 0.95f;
                    }
                    if (npc.localAI[0] >= 400 && npc.localAI[0] < 800)
                    {
                        npc.velocity += ((player.Center - new Vector2(0, 145)) - npc.Center) / ((player.Center - new Vector2(0, 145)) - npc.Center).Length() * 0.3f;
                        npc.velocity *= 0.95f;
                        if (npc.localAI[0] % 180 == 60)
                        {
                            if (Main.rand.Next(2) == 1)
                            {
                                for (int h = 0; h < 6; h++)
                                {
                                    Projectile.NewProjectile(npc.Center.X + h * 240 - 1440, npc.Center.Y - 300, 0, 20, mod.ProjectileType("VineRlif"), 0, 0f, Main.myPlayer, 0f, 0f);
                                }
                            }
                            else
                            {
                                for (int h = 0; h < 6; h++)
                                {
                                    Projectile.NewProjectile(npc.Center.X - h * 240 + 1440, npc.Center.Y - 300, 0, 20, mod.ProjectileType("VineRlif"), 0, 0f, Main.myPlayer, 0f, 0f);
                                }
                            }
                        }
                    }
                    if (npc.localAI[0] >= 800 && npc.localAI[0] < 1200)
                    {
                        npc.velocity += ((player.Center - new Vector2(0, 145)) - npc.Center) / ((player.Center - new Vector2(0, 145)) - npc.Center).Length() * 0.3f;
                        npc.velocity *= 0.95f;
                        if (npc.localAI[0] == 800)
                        {
                            K = Projectile.NewProjectile(npc.Center.X - 16, npc.Center.Y + 16, npc.velocity.X, npc.velocity.Y, mod.ProjectileType("GreenLight"), 90, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                    if (npc.localAI[0] >= 1200 && npc.localAI[0] < 1600)
                    {
                        npc.velocity += ((player.Center - new Vector2(0, 145)) - npc.Center) / ((player.Center - new Vector2(0, 145)) - npc.Center).Length() * 0.3f;
                        npc.velocity *= 0.95f;
                        if (npc.localAI[0] % 5 == 0)
                        {
                            NPC.NewNPC((int)npc.Center.X + Main.rand.Next(-500, 500), (int)npc.Center.Y - 800, mod.NPCType("Tangerine"), 0, Main.rand.NextFloat(-0.15f, 0.15f), 0);
                        }
                    }
                    if (npc.localAI[0] >= 1600 && npc.localAI[0] < 2000)
                    {
                        npc.velocity += ((player.Center - new Vector2(0, 145)) - npc.Center) / ((player.Center - new Vector2(0, 145)) - npc.Center).Length() * 0.3f;
                        npc.velocity *= 0.95f;
                    }
                    if (npc.localAI[0] >= 2000 && npc.localAI[0] < 2400)
                    {
                        npc.velocity += ((player.Center - new Vector2(0, 145)) - npc.Center) / ((player.Center - new Vector2(0, 145)) - npc.Center).Length() * 0.3f;
                        npc.velocity *= 0.95f;
                        if (npc.localAI[0] % 60 == 0)
                        {
                            Vector2 v2 = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 8f;
                            for (int h = 0; h < 6; h++)
                            {
                                Vector2 v = v2.RotatedBy((h - 2.5) / 16d * Math.PI);
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, v.X, v.Y, mod.ProjectileType("Leaves"), 40, 0f, Main.myPlayer, 0f, 0f);
                            }
                        }
                    }
                    if (npc.localAI[0] >= 2400)
                    {
                        npc.localAI[0] = 0;
                    }
                }
                else
                {
                    npc.localAI[0] += 1;
                    if (npc.localAI[0] < 400)
                    {
                        if (npc.localAI[0] == 2)
                        {
                            ReliPos = npc.Center;
                            for (int h = 0; h < 6; h++)
                            {
                                M[h] = Projectile.NewProjectile(npc.Center.X - 16, npc.Center.Y + 16, npc.velocity.X, npc.velocity.Y, mod.ProjectileType("GreenLight2"), 90, 0f, Main.myPlayer, 0f, h-2.5f);
                            }
                        }
                        npc.velocity += ((player.Center - new Vector2(0, 145)) - npc.Center) / ((player.Center - new Vector2(0, 145)) - npc.Center).Length() * 0.3f;
                        npc.velocity *= 0.95f;
                    }
                    if (ReliPos != Vector2.Zero)
                    {
                        DeltaPos = npc.Center - ReliPos;
                    }
                    if (npc.localAI[0] >= 400 && npc.localAI[0] < 1000)
                    {
                        if (npc.localAI[0] % 40 == 0 && npc.localAI[0] < 900)
                        {
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("OrangeLeafBall2"), 50, 0f, Main.myPlayer, 1, (908 - npc.localAI[0]) * 4);
                        }
                        if (npc.localAI[0] % 40 == 0 && npc.localAI[0] < 900)
                        {
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("OrangeLeafBall2"), 50, 0f, Main.myPlayer, -1, (908 - npc.localAI[0]) * 4);
                        }
                        if (npc.localAI[0] % 40 == 0 && npc.localAI[0] < 900)
                        {
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("OrangeLeafBall3"), 50, 0f, Main.myPlayer, 1, (908 - npc.localAI[0]) * 4);
                        }
                        if (npc.localAI[0] % 40 == 0 && npc.localAI[0] < 900)
                        {
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, 0, mod.ProjectileType("OrangeLeafBall3"), 50, 0f, Main.myPlayer, -1, (908 - npc.localAI[0]) * 4);
                        }
                        npc.velocity += ((player.Center - new Vector2(0, 145)) - npc.Center) / ((player.Center - new Vector2(0, 145)) - npc.Center).Length() * 0.3f;
                        npc.velocity *= 0.95f;
                    }
                    if (npc.localAI[0] >= 1000 && npc.localAI[0] < 1300)
                    {
                        npc.velocity += ((player.Center - new Vector2(0, 145)) - npc.Center) / ((player.Center - new Vector2(0, 145)) - npc.Center).Length() * 0.3f;
                        npc.velocity *= 0.95f;
                    }
                    if (npc.localAI[0] >= 1300 && npc.localAI[0] < 1500)
                    {
                        if(npc.localAI[0] % 60 == 0)
                        {
                            for (int h = 0; h < 12; h++)
                            {
                                Projectile.NewProjectile(npc.Center.X - h * 240 + 1440, npc.Center.Y - 300, 0, 20, mod.ProjectileType("VineRlif2"), 0, 0f, Main.myPlayer, 0f, 0f);
                            }
                        }
                        npc.velocity += ((player.Center - new Vector2(0, 145)) - npc.Center) / ((player.Center - new Vector2(0, 145)) - npc.Center).Length() * 0.3f;
                        npc.velocity *= 0.95f;
                    }
                    if (npc.localAI[0] >= 1500 && npc.localAI[0] < 2000)
                    {
                        if (npc.localAI[0] % 6 == 0)
                        {
                            for (int h = 0; h < 3; h++)
                            {
                                Vector2 v = new Vector2(0,2).RotatedBy(h / 1.5 * Math.PI + (npc.localAI[0] * npc.localAI[0]) / 1000000f);
                                int u = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, npc.velocity.X + v.X, npc.velocity.Y + v.Y, mod.ProjectileType("GreenLeafBall"), 50, 0f, Main.myPlayer, 0f, 0f);
                                Main.projectile[u].timeLeft = 240;
                            }
                        }
                        if (npc.localAI[0] % 60 == 0)
                        {
                            for (int h = 0; h < 16; h++)
                            {
                                Vector2 v = new Vector2(0, 4).RotatedBy(h / 8d * Math.PI);
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, npc.velocity.X + v.X, npc.velocity.Y + v.Y, mod.ProjectileType("OrangeLeafBall"), 50, 0f, Main.myPlayer, 0f, 0f);
                            }
                        }
                        if (npc.localAI[0] % 60 == 30)
                        {
                            for (int h = 0; h < 3; h++)
                            {
                                Vector2 v = new Vector2(0, 3).RotatedBy(h / 1.5d * Math.PI);
                                for (int z = 0; z < 5; z++)
                                {
                                    Vector2 v2 = v.RotatedBy((z - 2.5) / 6.5d);
                                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, npc.velocity.X + v2.X, npc.velocity.Y + v2.Y, mod.ProjectileType("Leaves"), 40, 0f, Main.myPlayer, 0f, 0f);
                                }
                            }
                        }
                        npc.velocity += ((player.Center - new Vector2(0, 145)) - npc.Center) / ((player.Center - new Vector2(0, 145)) - npc.Center).Length() * 0.3f;
                        npc.velocity *= 0.95f;
                    }
                    if (npc.localAI[0] >= 2000 && npc.localAI[0] < 2500)
                    {
                        if (npc.localAI[0] % 60 == 0)
                        {
                            for(int i = 0;i < 20;i++)
                            {
                                Vector2 v = new Vector2(0, 3).RotatedBy(i / 10d * Math.PI);
                                int u = Projectile.NewProjectile(npc.Center.X + v.X, npc.Center.Y + v.Y, v.X, v.Y, mod.ProjectileType("藤蔓"), 50, 0f, Main.myPlayer, 0f, 0f);
                            }
                        }
                        npc.velocity += ((player.Center - new Vector2(0, 145)) - npc.Center) / ((player.Center - new Vector2(0, 145)) - npc.Center).Length() * 0.3f;
                        npc.velocity *= 0.95f;
                    }
                    if (npc.localAI[0] >= 2500 && npc.localAI[0] < 3000)
                    {
                        if (npc.localAI[0] % 60 == 0)
                        {
                            Vector2 v = new Vector2(0, 40).RotatedBy(npc.localAI[0] / 40d);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, v.X, v.Y, mod.ProjectileType("GreenFlame"), 50, 0f, Main.myPlayer, 0f, 0f);
                        }
                        if (npc.localAI[0] % 200 == 0)
                        {
                            Vector2 v = new Vector2(0, 40).RotatedBy(npc.localAI[0] / 40d);
                            K0 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, v.X, v.Y, mod.ProjectileType("GreenLight3"), 90, 0f, Main.myPlayer, 1, 0f);
                        }
                        if (npc.localAI[0] % 200 == 100)
                        {
                            Vector2 v = new Vector2(0, 40).RotatedBy(npc.localAI[0] / 40d);
                            K1 = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, v.X, v.Y, mod.ProjectileType("GreenLight3"), 90, 0f, Main.myPlayer, -1, 0f);
                        }
                        npc.velocity += ((player.Center - new Vector2(0, 145)) - npc.Center) / ((player.Center - new Vector2(0, 145)) - npc.Center).Length() * 0.3f;
                        npc.velocity *= 0.95f;
                    }
                    if (npc.localAI[0] >= 3000)
                    {
                        npc.localAI[0] = 0;
                    }
                }
            }
            else
            {
                npc.velocity += ((player.Center - new Vector2(0, 145)) - npc.Center) / ((player.Center - new Vector2(0, 145)) - npc.Center).Length() * 0.3f;
                npc.velocity *= 0.95f;
            }
            Center0 = npc.Center;
            AI0 += 0.02f;
        }
        public static float AI0 = 0;
        public static Vector2 ReliPos;
        public static Vector2 DeltaPos;
        public static Vector2 Center0;
        private int K = -1;
        private int K0 = -1;
        private int K1 = -1;
        private int[] M = new int[6];
        public override void NPCLoot()
		{
            if (!MythWorld.downedQNGSY)
            {
                MythWorld.downedQNGSY = true;
            }
            Player player = Main.player[Main.myPlayer];
            bool expertMode = Main.expertMode;
            if (!expertMode)
            {
                int type = 0;
                switch (Main.rand.Next(1, 5))
                {
                    case 1:
                        type = base.mod.ItemType("OrangeSummonStaff");
                        break;
                    case 2:
                        type = base.mod.ItemType("OrangeFurlBlade");
                        break;
                    case 3:
                        type = base.mod.ItemType("OrangeBlade");
                        break;
                    case 4:
                        type = base.mod.ItemType("OrangeStaff");
                        break;
                }
                Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, type, 1, false, 0, false, false);
            }
            else
            {
                Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("OrangeMonstorTreasureBag"), 1, false, 0, false, false);
            }
            Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, base.mod.ItemType("SeedBag"), 1, false, 0, false, false);
            Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, 58, 25, false, 0, false, false);
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Player player = Main.player[Main.myPlayer];
            SpriteEffects effects = SpriteEffects.None;
            if (base.npc.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Vector2 value = new Vector2(base.npc.Center.X, base.npc.Center.Y);
            Vector2 vector = new Vector2((float)(Main.npcTexture[base.npc.type].Width / 2), (float)(Main.npcTexture[base.npc.type].Height / Main.npcFrameCount[base.npc.type] / 2));
            Vector2 vector2 = value - Main.screenPosition;
            vector2 -= new Vector2((float)base.mod.GetTexture("NPCs/LanternMoon/千年桔树妖之眼珠").Width, (float)(base.mod.GetTexture("NPCs/LanternMoon/千年桔树妖之眼珠").Height / Main.npcFrameCount[base.npc.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.npc.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.npc.alpha, 297 - base.npc.alpha, 297 - base.npc.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/LanternMoon/千年桔树妖之眼Glow"), vector2 + (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 8f, new Rectangle?(base.npc.frame), new Color(155, 155, 155, 0), base.npc.rotation, vector, 1f, effects, 0f);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/LanternMoon/千年桔树妖之眼珠"), vector2 + (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 15f, new Rectangle?(base.npc.frame), new Color(255, 255, 255, 0), base.npc.rotation, vector, 1f, effects, 0f);
            if (!Main.gamePaused)
            {
                if (K != -1)
                {
                    if (Main.projectile[K].type == mod.ProjectileType("GreenLight") && (Main.projectile[K].position - npc.Center).Length() < 50)
                    {
                        Main.projectile[K].position = vector2 + (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 15f + Main.screenPosition - new Vector2(Main.projectile[K].width / 2f, Main.projectile[K].height / 2f);
                    }
                }
                if (K0 != -1)
                {
                    if (Main.projectile[K0].type == mod.ProjectileType("GreenLight3") && (Main.projectile[K0].position - npc.Center).Length() < 50)
                    {
                        Main.projectile[K0].position = vector2 + (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 15f + Main.screenPosition - new Vector2(Main.projectile[K0].width / 2f, Main.projectile[K0].height / 2f);
                    }
                }
                if (K1 != -1)
                {
                    if (Main.projectile[K1].type == mod.ProjectileType("GreenLight3") && (Main.projectile[K1].position - npc.Center).Length() < 50)
                    {
                        Main.projectile[K1].position = vector2 + (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 15f + Main.screenPosition - new Vector2(Main.projectile[K1].width / 2f, Main.projectile[K1].height / 2f);
                    }
                }
                if (can2ai)
                {
                    for(int h = 0;h < 6;h++)
                    {
                        if(M[h] != -1 && Main.projectile[M[h]].type == mod.ProjectileType("GreenLight2"))
                        {
                            Main.projectile[M[h]].position = vector2 + (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 15f + Main.screenPosition - new Vector2(Main.projectile[M[h]].width / 2f, Main.projectile[M[h]].height / 2f);
                        }
                    }
                }
            }
        }
    }
}
