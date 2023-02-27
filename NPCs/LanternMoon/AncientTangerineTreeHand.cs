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
    public class AncientTangerineTreeHand : ModNPC
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Thousand years orange monster");
			Main.npcFrameCount[base.npc.type] = 1;
			base.DisplayName.AddTranslation(GameCulture.Chinese, "千年桔树的枝条");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.npc.aiStyle = -1;
			base.npc.damage = 50;
			base.npc.width = 160;
			base.npc.height = 160;
			base.npc.defense = 90;
            if (Main.expertMode)
            {
                base.npc.lifeMax = 30000;
                if (MythWorld.Myth)
                {
                    base.npc.lifeMax = 20000;
                }
            }
            else
            {
                base.npc.lifeMax = 40000;
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
        }
        private int i0 = 0;
        private int K = -1;
        private Vector2 p0;
        private Vector2 pM;
        public override void HitEffect(int hitDirection, double damage)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if(npc.life <= 0)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(V02, new Vector2(0, scaleFactor).RotatedByRandom(Math.PI * 2d), base.mod.GetGoreSlot("NPCs/LanternMoon/AncientTangerineTreeArm"), 1f);
                float scaleFactor2 = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(V01, new Vector2(0, scaleFactor2).RotatedByRandom(Math.PI * 2d), base.mod.GetGoreSlot("NPCs/LanternMoon/AncientTangerineTreeArm"), 1f);
                float scaleFactor3 = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(npc.position, new Vector2(0, scaleFactor3).RotatedByRandom(Math.PI * 2d), base.mod.GetGoreSlot("NPCs/LanternMoon/AncientTangerineTreeHandEmpty"), 1f);
            }
        }
        public override bool CheckActive()
        {
            return Main.dayTime;
        }
        private int H = -1;
        public override void AI()
        {
            if (i0 == 0)
            {
                npc.localAI[0] = 0;
                i0 += 1;
                for (int i = 0; i < 200; i++)
                {
                    if (Main.npc[i].type == mod.NPCType("AncientTangerineTreeEye"))
                    {
                        H = i;
                        p0 = Main.npc[H].Center;
                        break;
                    }
                }
            }
            if (NPC.CountNPCS(mod.NPCType("AncientTangerineTreeEye")) <= 0)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(V02, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("NPCs/LanternMoon/AncientTangerineTreeArm"), 1f);
                float scaleFactor2 = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(V01, base.npc.velocity * scaleFactor2, base.mod.GetGoreSlot("NPCs/LanternMoon/AncientTangerineTreeArm"), 1f);
                float scaleFactor3 = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(npc.position, base.npc.velocity * scaleFactor3, base.mod.GetGoreSlot("NPCs/LanternMoon/AncientTangerineTreeHandEmpty"), 1f);
                npc.active = false;
            }
            Player player = Main.player[Main.myPlayer];
            if (NPC.CountNPCS(mod.NPCType("VerdantTangerine")) + NPC.CountNPCS(mod.NPCType("LachangGhost")) + NPC.CountNPCS(mod.NPCType("BumpTangyuan")) + NPC.CountNPCS(mod.NPCType("OrchidSprite")) + NPC.CountNPCS(mod.NPCType("StrawberrySlime") + NPC.CountNPCS(mod.NPCType("StrawberrySlime1")) + NPC.CountNPCS(mod.NPCType("MilkSlime")) + NPC.CountNPCS(mod.NPCType("MilkSlime1")) + NPC.CountNPCS(mod.NPCType("OrangeSlime")) + NPC.CountNPCS(mod.NPCType("OrangeSlime1")) + NPC.CountNPCS(mod.NPCType("AppleSlime")) + NPC.CountNPCS(mod.NPCType("AppleSlime1")) + NPC.CountNPCS(mod.NPCType("ChocolateSlime")) + NPC.CountNPCS(mod.NPCType("ChocolateSlime1")) + NPC.CountNPCS(mod.NPCType("GrapeSlime")) + NPC.CountNPCS(mod.NPCType("GrapeSlime1")) + NPC.CountNPCS(mod.NPCType("LemonSlime")) + NPC.CountNPCS(mod.NPCType("LemonSlime1"))) > 0)
            {
                npc.dontTakeDamage = true;
            }
            else
            {
                npc.dontTakeDamage = false;
            }
            if (AncientTangerineTreeEye.canai)
            {
                npc.localAI[0] += 1;
                npc.rotation = (float)(Math.Atan2(((player.Center - new Vector2(0, 145)) - npc.Center).Y, ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((npc.ai[0] + 1.04) * npc.ai[1])) - npc.Center).X));
                if (npc.localAI[0] < 400)
                {
                    npc.velocity += ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((npc.ai[0] + 1.04) * npc.ai[1])) - npc.Center) / ((player.Center - new Vector2(0, 145)) - npc.Center).Length() * 0.3f;
                    npc.velocity *= 0.95f;
                    if (npc.localAI[0] % 80 == 0)
                    {
                        Vector2 v2 = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 8f;
                        for (int h = 0; h < 6; h++)
                        {
                            Vector2 v = v2.RotatedBy(h / 3d * Math.PI);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, v.X, v.Y, mod.ProjectileType("Leaves"), 40, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                if (npc.localAI[0] >= 400 && npc.localAI[0] < 800)
                {
                    npc.velocity += ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((npc.ai[0] + 1.04) * npc.ai[1])) - npc.Center) / ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((npc.ai[0] + 1.04) * npc.ai[1])) - npc.Center).Length() * 0.3f;
                    npc.velocity *= 0.95f;
                }
                if (npc.localAI[0] >= 800 && npc.localAI[0] < 1200)
                {
                    npc.velocity += ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((npc.ai[0] + 1.04) * npc.ai[1])) - npc.Center) / ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((npc.ai[0] + 1.04) * npc.ai[1])) - npc.Center).Length() * 0.3f;
                    npc.velocity *= 0.95f;
                    if (npc.localAI[0] == 800)
                    {
                        K = Projectile.NewProjectile(npc.Center.X - 16, npc.Center.Y, npc.velocity.X, npc.velocity.Y, mod.ProjectileType("GreenLightSmall"), 90, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
                if (npc.localAI[0] >= 1200 && npc.localAI[0] < 1600)
                {
                    npc.velocity += ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((npc.ai[0] + 1.04) * npc.ai[1])) - npc.Center) / ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((npc.ai[0] + 1.04) * npc.ai[1])) - npc.Center).Length() * 0.3f;
                    npc.velocity *= 0.95f;
                }
                if (npc.localAI[0] >= 1600 && npc.localAI[0] < 2000)
                {
                    npc.velocity += ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((npc.ai[0] + 1.04) * npc.ai[1])) - npc.Center) / ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((npc.ai[0] + 1.04) * npc.ai[1])) - npc.Center).Length() * 0.3f;
                    npc.velocity *= 0.95f;
                    if (npc.localAI[0] % 400 == (int)(npc.ai[0] * 240))
                    {
                        Vector2 v2 = (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 8f;
                        for (int h = 0; h < 6; h++)
                        {
                            Vector2 v = v2.RotatedBy((h - 2.5) / 16d * Math.PI);
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, v.X, v.Y, mod.ProjectileType("Leaves"), 40, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                if (npc.localAI[0] >= 2000 && npc.localAI[0] < 2400)
                {
                    npc.velocity += ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((npc.ai[0] + 1.04) * npc.ai[1])) - npc.Center) / ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((npc.ai[0] + 1.04) * npc.ai[1])) - npc.Center).Length() * 0.3f;
                    npc.velocity *= 0.95f;
                }
                if (npc.localAI[0] >= 2400)
                {
                    npc.localAI[0] = 0;
                }
            }
            else
            {
                npc.rotation = (float)(Math.Atan2(((player.Center - new Vector2(0, 145)) - npc.Center).Y, ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((npc.ai[0] + 1.04) * npc.ai[1])) - npc.Center).X));
                npc.velocity += ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((npc.ai[0] + 1.04) * npc.ai[1])) - npc.Center) / ((player.Center - new Vector2(0, 145)) - npc.Center).Length() * 0.3f;
                npc.velocity *= 0.95f;
            }
            if (Main.dayTime)
            {
                npc.velocity.Y += 1;
            }
            
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            if(H != -1)
            {
                if(Main.npc[H].type == mod.NPCType("AncientTangerineTreeEye"))
                {
                    p0 = Main.npc[H].Center;
                    pM = (npc.Center + p0) / 2f + new Vector2(0, 64);
                    float A1 = (float)(Math.Atan2((npc.Center - pM).Y, (npc.Center - pM).X)) + (float)Math.PI / 2f;
                    float A2 = (float)(Math.Atan2((pM - p0).Y, (pM - p0).X)) + (float)Math.PI / 2f;
                    Vector2 p1 = (npc.Center + pM) / 2f;
                    Vector2 p2 = (pM + p0) / 2f;
                    Color color1 = Lighting.GetColor((int)(p1.X / 16d), (int)(p1.Y / 16d));
                    color1 = npc.GetAlpha(color1) * ((255 - npc.alpha) / 255f);
                    Color color2 = Lighting.GetColor((int)(p1.X / 16d), (int)(p1.Y / 16d));
                    color2 = npc.GetAlpha(color2) * ((255 - npc.alpha) / 255f);
                    V01 = p1;
                    V02 = p2;
                    Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/LanternMoon/AncientTangerineTreeArm"), p1 - Main.screenPosition, null, color1, A1, new Vector2(60, 210), 1f, SpriteEffects.None, 0f);
                    Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/LanternMoon/AncientTangerineTreeArm"), p2 - Main.screenPosition, null, color2, A2, new Vector2(60, 210), 1f, SpriteEffects.None, 0f);
                }
            }
            return true;
        }
        private Vector2 V01;
        private Vector2 V02;
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
            vector2 -= new Vector2((float)base.mod.GetTexture("NPCs/LanternMoon/AncientTangerineTreeHandGlow").Width, (float)(base.mod.GetTexture("NPCs/LanternMoon/AncientTangerineTreeHandGlow").Height / Main.npcFrameCount[base.npc.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.npc.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.npc.alpha, 297 - base.npc.alpha, 297 - base.npc.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/LanternMoon/AncientTangerineTreeHandGlow"), vector2 + (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 8f, new Rectangle?(base.npc.frame), new Color(155, 155, 155, 0), base.npc.rotation, vector, 1f, effects, 0f);
            if(!Main.gamePaused)
            {
                if (K != -1)
                {
                    if (Main.projectile[K].type == mod.ProjectileType("GreenLightSmall") && (Main.projectile[K].position - npc.Center).Length() < 50)
                    {
                        Main.projectile[K].position = vector2 + (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 8f + Main.screenPosition - new Vector2(Main.projectile[K].width / 2f, Main.projectile[K].height / 2f);
                    }
                }
            }
            //Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/LanternMoon/千年桔树妖之眼珠"), vector2 + (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 15f, new Rectangle?(base.npc.frame), new Color(255, 255, 255, 0), base.npc.rotation, vector, 1f, effects, 0f);
        }
    }
}
