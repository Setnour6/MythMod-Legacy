using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
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
			Main.npcFrameCount[base.NPC.type] = 1;
			base.DisplayName.AddTranslation(GameCulture.Chinese, "千年桔树的枝条");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.NPC.aiStyle = -1;
			base.NPC.damage = 50;
			base.NPC.width = 160;
			base.NPC.height = 160;
			base.NPC.defense = 90;
            if (Main.expertMode)
            {
                base.NPC.lifeMax = 30000;
                if (MythWorld.Myth)
                {
                    base.NPC.lifeMax = 20000;
                }
            }
            else
            {
                base.NPC.lifeMax = 40000;
            }
            NPC.behindTiles = true;
            base.NPC.dontTakeDamage = false;
            base.NPC.knockBackResist = 0f;
			base.NPC.value = (float)Item.buyPrice(0, 50, 0, 0);
			base.NPC.alpha = 0;
            base.NPC.scale = 1;
            base.NPC.lavaImmune = true;
			base.NPC.noGravity = true;
			base.NPC.noTileCollide = true;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
        }
        private int i0 = 0;
        private int K = -1;
        private Vector2 p0;
        private Vector2 pM;
        public override void HitEffect(int hitDirection, double damage)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if(NPC.life <= 0)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(V02, new Vector2(0, scaleFactor).RotatedByRandom(Math.PI * 2d), base.Mod.GetGoreSlot("NPCs/LanternMoon/AncientTangerineTreeArm"), 1f);
                float scaleFactor2 = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(V01, new Vector2(0, scaleFactor2).RotatedByRandom(Math.PI * 2d), base.Mod.GetGoreSlot("NPCs/LanternMoon/AncientTangerineTreeArm"), 1f);
                float scaleFactor3 = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(NPC.position, new Vector2(0, scaleFactor3).RotatedByRandom(Math.PI * 2d), base.Mod.GetGoreSlot("NPCs/LanternMoon/AncientTangerineTreeHandEmpty"), 1f);
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
                NPC.localAI[0] = 0;
                i0 += 1;
                for (int i = 0; i < 200; i++)
                {
                    if (Main.npc[i].type == Mod.Find<ModNPC>("AncientTangerineTreeEye").Type)
                    {
                        H = i;
                        p0 = Main.npc[H].Center;
                        break;
                    }
                }
            }
            if (NPC.CountNPCS(Mod.Find<ModNPC>("AncientTangerineTreeEye").Type) <= 0)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(V02, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("NPCs/LanternMoon/AncientTangerineTreeArm"), 1f);
                float scaleFactor2 = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(V01, base.NPC.velocity * scaleFactor2, base.Mod.GetGoreSlot("NPCs/LanternMoon/AncientTangerineTreeArm"), 1f);
                float scaleFactor3 = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(NPC.position, base.NPC.velocity * scaleFactor3, base.Mod.GetGoreSlot("NPCs/LanternMoon/AncientTangerineTreeHandEmpty"), 1f);
                NPC.active = false;
            }
            Player player = Main.player[Main.myPlayer];
            if (NPC.CountNPCS(Mod.Find<ModNPC>("VerdantTangerine").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("LachangGhost").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("BumpTangyuan").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("OrchidSprite").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime").Type + NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime1").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime1").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("OrangeSlime").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("OrangeSlime1").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("AppleSlime").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("AppleSlime1").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("ChocolateSlime").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("ChocolateSlime1").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("GrapeSlime").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("GrapeSlime1").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("LemonSlime").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("LemonSlime1").Type)) > 0)
            {
                NPC.dontTakeDamage = true;
            }
            else
            {
                NPC.dontTakeDamage = false;
            }
            if (AncientTangerineTreeEye.canai)
            {
                NPC.localAI[0] += 1;
                NPC.rotation = (float)(Math.Atan2(((player.Center - new Vector2(0, 145)) - NPC.Center).Y, ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((NPC.ai[0] + 1.04) * NPC.ai[1])) - NPC.Center).X));
                if (NPC.localAI[0] < 400)
                {
                    NPC.velocity += ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((NPC.ai[0] + 1.04) * NPC.ai[1])) - NPC.Center) / ((player.Center - new Vector2(0, 145)) - NPC.Center).Length() * 0.3f;
                    NPC.velocity *= 0.95f;
                    if (NPC.localAI[0] % 80 == 0)
                    {
                        Vector2 v2 = (player.Center - NPC.Center) / (player.Center - NPC.Center).Length() * 8f;
                        for (int h = 0; h < 6; h++)
                        {
                            Vector2 v = v2.RotatedBy(h / 3d * Math.PI);
                            Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("Leaves").Type, 40, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                if (NPC.localAI[0] >= 400 && NPC.localAI[0] < 800)
                {
                    NPC.velocity += ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((NPC.ai[0] + 1.04) * NPC.ai[1])) - NPC.Center) / ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((NPC.ai[0] + 1.04) * NPC.ai[1])) - NPC.Center).Length() * 0.3f;
                    NPC.velocity *= 0.95f;
                }
                if (NPC.localAI[0] >= 800 && NPC.localAI[0] < 1200)
                {
                    NPC.velocity += ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((NPC.ai[0] + 1.04) * NPC.ai[1])) - NPC.Center) / ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((NPC.ai[0] + 1.04) * NPC.ai[1])) - NPC.Center).Length() * 0.3f;
                    NPC.velocity *= 0.95f;
                    if (NPC.localAI[0] == 800)
                    {
                        K = Projectile.NewProjectile(NPC.Center.X - 16, NPC.Center.Y, NPC.velocity.X, NPC.velocity.Y, Mod.Find<ModProjectile>("GreenLightSmall").Type, 90, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
                if (NPC.localAI[0] >= 1200 && NPC.localAI[0] < 1600)
                {
                    NPC.velocity += ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((NPC.ai[0] + 1.04) * NPC.ai[1])) - NPC.Center) / ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((NPC.ai[0] + 1.04) * NPC.ai[1])) - NPC.Center).Length() * 0.3f;
                    NPC.velocity *= 0.95f;
                }
                if (NPC.localAI[0] >= 1600 && NPC.localAI[0] < 2000)
                {
                    NPC.velocity += ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((NPC.ai[0] + 1.04) * NPC.ai[1])) - NPC.Center) / ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((NPC.ai[0] + 1.04) * NPC.ai[1])) - NPC.Center).Length() * 0.3f;
                    NPC.velocity *= 0.95f;
                    if (NPC.localAI[0] % 400 == (int)(NPC.ai[0] * 240))
                    {
                        Vector2 v2 = (player.Center - NPC.Center) / (player.Center - NPC.Center).Length() * 8f;
                        for (int h = 0; h < 6; h++)
                        {
                            Vector2 v = v2.RotatedBy((h - 2.5) / 16d * Math.PI);
                            Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("Leaves").Type, 40, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                }
                if (NPC.localAI[0] >= 2000 && NPC.localAI[0] < 2400)
                {
                    NPC.velocity += ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((NPC.ai[0] + 1.04) * NPC.ai[1])) - NPC.Center) / ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((NPC.ai[0] + 1.04) * NPC.ai[1])) - NPC.Center).Length() * 0.3f;
                    NPC.velocity *= 0.95f;
                }
                if (NPC.localAI[0] >= 2400)
                {
                    NPC.localAI[0] = 0;
                }
            }
            else
            {
                NPC.rotation = (float)(Math.Atan2(((player.Center - new Vector2(0, 145)) - NPC.Center).Y, ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((NPC.ai[0] + 1.04) * NPC.ai[1])) - NPC.Center).X));
                NPC.velocity += ((player.Center - new Vector2(0, 145) + new Vector2(0, -480).RotatedBy((NPC.ai[0] + 1.04) * NPC.ai[1])) - NPC.Center) / ((player.Center - new Vector2(0, 145)) - NPC.Center).Length() * 0.3f;
                NPC.velocity *= 0.95f;
            }
            if (Main.dayTime)
            {
                NPC.velocity.Y += 1;
            }
            
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if(H != -1)
            {
                if(Main.npc[H].type == Mod.Find<ModNPC>("AncientTangerineTreeEye").Type)
                {
                    p0 = Main.npc[H].Center;
                    pM = (NPC.Center + p0) / 2f + new Vector2(0, 64);
                    float A1 = (float)(Math.Atan2((NPC.Center - pM).Y, (NPC.Center - pM).X)) + (float)Math.PI / 2f;
                    float A2 = (float)(Math.Atan2((pM - p0).Y, (pM - p0).X)) + (float)Math.PI / 2f;
                    Vector2 p1 = (NPC.Center + pM) / 2f;
                    Vector2 p2 = (pM + p0) / 2f;
                    Color color1 = Lighting.GetColor((int)(p1.X / 16d), (int)(p1.Y / 16d));
                    color1 = NPC.GetAlpha(color1) * ((255 - NPC.alpha) / 255f);
                    Color color2 = Lighting.GetColor((int)(p1.X / 16d), (int)(p1.Y / 16d));
                    color2 = NPC.GetAlpha(color2) * ((255 - NPC.alpha) / 255f);
                    V01 = p1;
                    V02 = p2;
                    Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/LanternMoon/AncientTangerineTreeArm"), p1 - Main.screenPosition, null, color1, A1, new Vector2(60, 210), 1f, SpriteEffects.None, 0f);
                    Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/LanternMoon/AncientTangerineTreeArm"), p2 - Main.screenPosition, null, color2, A2, new Vector2(60, 210), 1f, SpriteEffects.None, 0f);
                }
            }
            return true;
        }
        private Vector2 V01;
        private Vector2 V02;
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Player player = Main.player[Main.myPlayer];
            SpriteEffects effects = SpriteEffects.None;
            if (base.NPC.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Vector2 value = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
            Vector2 vector = new Vector2((float)(TextureAssets.Npc[base.NPC.type].Value.Width / 2), (float)(TextureAssets.Npc[base.NPC.type].Value.Height / Main.npcFrameCount[base.NPC.type] / 2));
            Vector2 vector2 = value - Main.screenPosition;
            vector2 -= new Vector2((float)base.Mod.GetTexture("NPCs/LanternMoon/AncientTangerineTreeHandGlow").Width, (float)(base.Mod.GetTexture("NPCs/LanternMoon/AncientTangerineTreeHandGlow").Height / Main.npcFrameCount[base.NPC.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.NPC.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.NPC.alpha, 297 - base.NPC.alpha, 297 - base.NPC.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/LanternMoon/AncientTangerineTreeHandGlow"), vector2 + (player.Center - NPC.Center) / (player.Center - NPC.Center).Length() * 8f, new Rectangle?(base.NPC.frame), new Color(155, 155, 155, 0), base.NPC.rotation, vector, 1f, effects, 0f);
            if(!Main.gamePaused)
            {
                if (K != -1)
                {
                    if (Main.projectile[K].type == Mod.Find<ModProjectile>("GreenLightSmall").Type && (Main.projectile[K].position - NPC.Center).Length() < 50)
                    {
                        Main.projectile[K].position = vector2 + (player.Center - NPC.Center) / (player.Center - NPC.Center).Length() * 8f + Main.screenPosition - new Vector2(Main.projectile[K].width / 2f, Main.projectile[K].height / 2f);
                    }
                }
            }
            //Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/LanternMoon/千年桔树妖之眼珠"), vector2 + (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 15f, new Rectangle?(base.npc.frame), new Color(255, 255, 255, 0), base.npc.rotation, vector, 1f, effects, 0f);
        }
    }
}
