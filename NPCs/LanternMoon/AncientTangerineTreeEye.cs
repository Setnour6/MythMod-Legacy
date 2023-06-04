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
    [AutoloadBossHead]
    public class AncientTangerineTreeEye : ModNPC
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("Thousand years orange monster");
			Main.npcFrameCount[base.NPC.type] = 1;
			base.DisplayName.AddTranslation(GameCulture.Chinese, "千年桔树妖");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.NPC.aiStyle = -1;
			base.NPC.damage = 0;
			base.NPC.width = 242;
			base.NPC.height = 226;
			base.NPC.defense = 90;
            if (Main.expertMode)
            {
                base.NPC.lifeMax = 450000;
                if (MythWorld.Myth)
                {
                    base.NPC.lifeMax = 300000;
                }
            }
            else
            {
                base.NPC.lifeMax = 300000;
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
            base.NPC.boss = true;
            this.Music = Mod.GetSoundSlot((Terraria.ModLoader.SoundType)51, "Sounds/Music/Powerless-Eclipse橘子树");
        }
        private int i0 = 0;
        public static bool canai = false;
        private bool can2ai = false;
        public override void HitEffect(NPC.HitInfo hit)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.LanternMoonPoint = 100000 - (int)(NPC.life / (float)NPC.lifeMax * 10000f);
            if (base.NPC.life <= 0)
            {
                for (int k = 0; k <= 30; k++)
                {
                    Vector2 v = new Vector2(0, Main.rand.Next(0, 140)).RotatedByRandom(Math.PI * 2);
                    int num4 = Projectile.NewProjectile(NPC.Center.X + v.X, NPC.Center.Y + v.Y, 0, 0, base.Mod.Find<ModProjectile>("GreenFireGas").Type, 0, 0, Main.myPlayer, Main.rand.Next(1000, 3000) / 1000f, 0f);
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
                NPC.localAI[0] = 0;
                i0 += 1;
                for (int h = 0; h < 4; h++)
                {
                    NPC.NewNPC((int)NPC.Center.X, (int)NPC.Center.Y, Mod.Find<ModNPC>("AncientTangerineTreeHand").Type, 0, h * 0.30333f + 0.4f, 1);
                }
                for (int h = 0; h < 6; h++)
                {
                    M[h] = -1;
                }
                for (int h = 0; h < 4; h++)
                {
                    NPC.NewNPC((int)NPC.Center.X, (int)NPC.Center.Y, Mod.Find<ModNPC>("AncientTangerineTreeHand").Type, 0, h * 0.30333f + 0.4f, -1);
                }
            }
            if (NPC.CountNPCS(Mod.Find<ModNPC>("VerdantTangerine").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("LachangGhost").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("BumpTangyuan").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("OrchidSprite").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime").Type + NPC.CountNPCS(Mod.Find<ModNPC>("StrawberrySlime1").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("MilkSlime1").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("OrangeSlime").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("OrangeSlime1").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("AppleSlime").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("AppleSlime1").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("ChocolateSlime").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("ChocolateSlime1").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("GrapeSlime").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("GrapeSlime1").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("LemonSlime").Type) + NPC.CountNPCS(Mod.Find<ModNPC>("LemonSlime1").Type)) > 0)
            {
                NPC.dontTakeDamage = true;
            }
            else
            {
                NPC.dontTakeDamage = false;
                if(!canai)
                {
                    canai = true;
                }
            }
            if (NPC.CountNPCS(Mod.Find<ModNPC>("AncientTangerineTreeHand").Type) <= 0)
            {
                if(canai && i0 != 0)
                {
                    can2ai = true;
                }
                NPC.defense = 90;
            }
            else
            {
                NPC.defense = 600;
            }
            if (Main.dayTime)
            {
                NPC.velocity.Y += 1;
            }
            if (canai)
            {
                if (!can2ai)
                {
                    NPC.localAI[0] += 1;                   
                    if (NPC.localAI[0] < 400)
                    {
                        if (NPC.localAI[0] % 80 == 0)
                        {
                            for (int h = 0; h < 6; h++)
                            {
                                Vector2 vk = new Vector2(0, 32).RotatedBy((h + 1.5) / 3d * Math.PI);
                                Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, vk.X, vk.Y, Mod.Find<ModProjectile>("GreenFlame").Type, 50, 0f, Main.myPlayer, 0f, 0f);
                            }
                        }
                        NPC.velocity += ((player.Center - new Vector2(0, 145)) - NPC.Center) / ((player.Center - new Vector2(0, 145)) - NPC.Center).Length() * 0.3f;
                        NPC.velocity *= 0.95f;
                    }
                    if (NPC.localAI[0] >= 400 && NPC.localAI[0] < 800)
                    {
                        NPC.velocity += ((player.Center - new Vector2(0, 145)) - NPC.Center) / ((player.Center - new Vector2(0, 145)) - NPC.Center).Length() * 0.3f;
                        NPC.velocity *= 0.95f;
                        if (NPC.localAI[0] % 180 == 60)
                        {
                            if (Main.rand.Next(2) == 1)
                            {
                                for (int h = 0; h < 6; h++)
                                {
                                    Projectile.NewProjectile(NPC.Center.X + h * 240 - 1440, NPC.Center.Y - 300, 0, 20, Mod.Find<ModProjectile>("VineRlif").Type, 0, 0f, Main.myPlayer, 0f, 0f);
                                }
                            }
                            else
                            {
                                for (int h = 0; h < 6; h++)
                                {
                                    Projectile.NewProjectile(NPC.Center.X - h * 240 + 1440, NPC.Center.Y - 300, 0, 20, Mod.Find<ModProjectile>("VineRlif").Type, 0, 0f, Main.myPlayer, 0f, 0f);
                                }
                            }
                        }
                    }
                    if (NPC.localAI[0] >= 800 && NPC.localAI[0] < 1200)
                    {
                        NPC.velocity += ((player.Center - new Vector2(0, 145)) - NPC.Center) / ((player.Center - new Vector2(0, 145)) - NPC.Center).Length() * 0.3f;
                        NPC.velocity *= 0.95f;
                        if (NPC.localAI[0] == 800)
                        {
                            K = Projectile.NewProjectile(NPC.Center.X - 16, NPC.Center.Y + 16, NPC.velocity.X, NPC.velocity.Y, Mod.Find<ModProjectile>("GreenLight").Type, 90, 0f, Main.myPlayer, 0f, 0f);
                        }
                    }
                    if (NPC.localAI[0] >= 1200 && NPC.localAI[0] < 1600)
                    {
                        NPC.velocity += ((player.Center - new Vector2(0, 145)) - NPC.Center) / ((player.Center - new Vector2(0, 145)) - NPC.Center).Length() * 0.3f;
                        NPC.velocity *= 0.95f;
                        if (NPC.localAI[0] % 5 == 0)
                        {
                            NPC.NewNPC((int)NPC.Center.X + Main.rand.Next(-500, 500), (int)NPC.Center.Y - 800, Mod.Find<ModNPC>("Tangerine").Type, 0, Main.rand.NextFloat(-0.15f, 0.15f), 0);
                        }
                    }
                    if (NPC.localAI[0] >= 1600 && NPC.localAI[0] < 2000)
                    {
                        NPC.velocity += ((player.Center - new Vector2(0, 145)) - NPC.Center) / ((player.Center - new Vector2(0, 145)) - NPC.Center).Length() * 0.3f;
                        NPC.velocity *= 0.95f;
                    }
                    if (NPC.localAI[0] >= 2000 && NPC.localAI[0] < 2400)
                    {
                        NPC.velocity += ((player.Center - new Vector2(0, 145)) - NPC.Center) / ((player.Center - new Vector2(0, 145)) - NPC.Center).Length() * 0.3f;
                        NPC.velocity *= 0.95f;
                        if (NPC.localAI[0] % 60 == 0)
                        {
                            Vector2 v2 = (player.Center - NPC.Center) / (player.Center - NPC.Center).Length() * 8f;
                            for (int h = 0; h < 6; h++)
                            {
                                Vector2 v = v2.RotatedBy((h - 2.5) / 16d * Math.PI);
                                Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("Leaves").Type, 40, 0f, Main.myPlayer, 0f, 0f);
                            }
                        }
                    }
                    if (NPC.localAI[0] >= 2400)
                    {
                        NPC.localAI[0] = 0;
                    }
                }
                else
                {
                    NPC.localAI[0] += 1;
                    if (NPC.localAI[0] < 400)
                    {
                        if (NPC.localAI[0] == 2)
                        {
                            ReliPos = NPC.Center;
                            for (int h = 0; h < 6; h++)
                            {
                                M[h] = Projectile.NewProjectile(NPC.Center.X - 16, NPC.Center.Y + 16, NPC.velocity.X, NPC.velocity.Y, Mod.Find<ModProjectile>("GreenLight2").Type, 90, 0f, Main.myPlayer, 0f, h-2.5f);
                            }
                        }
                        NPC.velocity += ((player.Center - new Vector2(0, 145)) - NPC.Center) / ((player.Center - new Vector2(0, 145)) - NPC.Center).Length() * 0.3f;
                        NPC.velocity *= 0.95f;
                    }
                    if (ReliPos != Vector2.Zero)
                    {
                        DeltaPos = NPC.Center - ReliPos;
                    }
                    if (NPC.localAI[0] >= 400 && NPC.localAI[0] < 1000)
                    {
                        if (NPC.localAI[0] % 40 == 0 && NPC.localAI[0] < 900)
                        {
                            Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, 0, 0, Mod.Find<ModProjectile>("OrangeLeafBall2").Type, 50, 0f, Main.myPlayer, 1, (908 - NPC.localAI[0]) * 4);
                        }
                        if (NPC.localAI[0] % 40 == 0 && NPC.localAI[0] < 900)
                        {
                            Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, 0, 0, Mod.Find<ModProjectile>("OrangeLeafBall2").Type, 50, 0f, Main.myPlayer, -1, (908 - NPC.localAI[0]) * 4);
                        }
                        if (NPC.localAI[0] % 40 == 0 && NPC.localAI[0] < 900)
                        {
                            Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, 0, 0, Mod.Find<ModProjectile>("OrangeLeafBall3").Type, 50, 0f, Main.myPlayer, 1, (908 - NPC.localAI[0]) * 4);
                        }
                        if (NPC.localAI[0] % 40 == 0 && NPC.localAI[0] < 900)
                        {
                            Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, 0, 0, Mod.Find<ModProjectile>("OrangeLeafBall3").Type, 50, 0f, Main.myPlayer, -1, (908 - NPC.localAI[0]) * 4);
                        }
                        NPC.velocity += ((player.Center - new Vector2(0, 145)) - NPC.Center) / ((player.Center - new Vector2(0, 145)) - NPC.Center).Length() * 0.3f;
                        NPC.velocity *= 0.95f;
                    }
                    if (NPC.localAI[0] >= 1000 && NPC.localAI[0] < 1300)
                    {
                        NPC.velocity += ((player.Center - new Vector2(0, 145)) - NPC.Center) / ((player.Center - new Vector2(0, 145)) - NPC.Center).Length() * 0.3f;
                        NPC.velocity *= 0.95f;
                    }
                    if (NPC.localAI[0] >= 1300 && NPC.localAI[0] < 1500)
                    {
                        if(NPC.localAI[0] % 60 == 0)
                        {
                            for (int h = 0; h < 12; h++)
                            {
                                Projectile.NewProjectile(NPC.Center.X - h * 240 + 1440, NPC.Center.Y - 300, 0, 20, Mod.Find<ModProjectile>("VineRlif2").Type, 0, 0f, Main.myPlayer, 0f, 0f);
                            }
                        }
                        NPC.velocity += ((player.Center - new Vector2(0, 145)) - NPC.Center) / ((player.Center - new Vector2(0, 145)) - NPC.Center).Length() * 0.3f;
                        NPC.velocity *= 0.95f;
                    }
                    if (NPC.localAI[0] >= 1500 && NPC.localAI[0] < 2000)
                    {
                        if (NPC.localAI[0] % 6 == 0)
                        {
                            for (int h = 0; h < 3; h++)
                            {
                                Vector2 v = new Vector2(0,2).RotatedBy(h / 1.5 * Math.PI + (NPC.localAI[0] * NPC.localAI[0]) / 1000000f);
                                int u = Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, NPC.velocity.X + v.X, NPC.velocity.Y + v.Y, Mod.Find<ModProjectile>("GreenLeafBall").Type, 50, 0f, Main.myPlayer, 0f, 0f);
                                Main.projectile[u].timeLeft = 240;
                            }
                        }
                        if (NPC.localAI[0] % 60 == 0)
                        {
                            for (int h = 0; h < 16; h++)
                            {
                                Vector2 v = new Vector2(0, 4).RotatedBy(h / 8d * Math.PI);
                                Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, NPC.velocity.X + v.X, NPC.velocity.Y + v.Y, Mod.Find<ModProjectile>("OrangeLeafBall").Type, 50, 0f, Main.myPlayer, 0f, 0f);
                            }
                        }
                        if (NPC.localAI[0] % 60 == 30)
                        {
                            for (int h = 0; h < 3; h++)
                            {
                                Vector2 v = new Vector2(0, 3).RotatedBy(h / 1.5d * Math.PI);
                                for (int z = 0; z < 5; z++)
                                {
                                    Vector2 v2 = v.RotatedBy((z - 2.5) / 6.5d);
                                    Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, NPC.velocity.X + v2.X, NPC.velocity.Y + v2.Y, Mod.Find<ModProjectile>("Leaves").Type, 40, 0f, Main.myPlayer, 0f, 0f);
                                }
                            }
                        }
                        NPC.velocity += ((player.Center - new Vector2(0, 145)) - NPC.Center) / ((player.Center - new Vector2(0, 145)) - NPC.Center).Length() * 0.3f;
                        NPC.velocity *= 0.95f;
                    }
                    if (NPC.localAI[0] >= 2000 && NPC.localAI[0] < 2500)
                    {
                        if (NPC.localAI[0] % 60 == 0)
                        {
                            for(int i = 0;i < 20;i++)
                            {
                                Vector2 v = new Vector2(0, 3).RotatedBy(i / 10d * Math.PI);
                                int u = Projectile.NewProjectile(NPC.Center.X + v.X, NPC.Center.Y + v.Y, v.X, v.Y, Mod.Find<ModProjectile>("藤蔓").Type, 50, 0f, Main.myPlayer, 0f, 0f);
                            }
                        }
                        NPC.velocity += ((player.Center - new Vector2(0, 145)) - NPC.Center) / ((player.Center - new Vector2(0, 145)) - NPC.Center).Length() * 0.3f;
                        NPC.velocity *= 0.95f;
                    }
                    if (NPC.localAI[0] >= 2500 && NPC.localAI[0] < 3000)
                    {
                        if (NPC.localAI[0] % 60 == 0)
                        {
                            Vector2 v = new Vector2(0, 40).RotatedBy(NPC.localAI[0] / 40d);
                            Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("GreenFlame").Type, 50, 0f, Main.myPlayer, 0f, 0f);
                        }
                        if (NPC.localAI[0] % 200 == 0)
                        {
                            Vector2 v = new Vector2(0, 40).RotatedBy(NPC.localAI[0] / 40d);
                            K0 = Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("GreenLight3").Type, 90, 0f, Main.myPlayer, 1, 0f);
                        }
                        if (NPC.localAI[0] % 200 == 100)
                        {
                            Vector2 v = new Vector2(0, 40).RotatedBy(NPC.localAI[0] / 40d);
                            K1 = Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("GreenLight3").Type, 90, 0f, Main.myPlayer, -1, 0f);
                        }
                        NPC.velocity += ((player.Center - new Vector2(0, 145)) - NPC.Center) / ((player.Center - new Vector2(0, 145)) - NPC.Center).Length() * 0.3f;
                        NPC.velocity *= 0.95f;
                    }
                    if (NPC.localAI[0] >= 3000)
                    {
                        NPC.localAI[0] = 0;
                    }
                }
            }
            else
            {
                NPC.velocity += ((player.Center - new Vector2(0, 145)) - NPC.Center) / ((player.Center - new Vector2(0, 145)) - NPC.Center).Length() * 0.3f;
                NPC.velocity *= 0.95f;
            }
            Center0 = NPC.Center;
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
        public override void OnKill()
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
                        type = base.Mod.Find<ModItem>("OrangeSummonStaff").Type;
                        break;
                    case 2:
                        type = base.Mod.Find<ModItem>("OrangeFurlBlade").Type;
                        break;
                    case 3:
                        type = base.Mod.Find<ModItem>("OrangeBlade").Type;
                        break;
                    case 4:
                        type = base.Mod.Find<ModItem>("OrangeStaff").Type;
                        break;
                }
                Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, type, 1, false, 0, false, false);
            }
            else
            {
                Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("OrangeMonstorTreasureBag").Type, 1, false, 0, false, false);
            }
            Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("SeedBag").Type, 1, false, 0, false, false);
            Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, 58, 25, false, 0, false, false);
        }
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
            vector2 -= new Vector2((float)base.Mod.GetTexture("NPCs/LanternMoon/千年桔树妖之眼珠").Width, (float)(base.Mod.GetTexture("NPCs/LanternMoon/千年桔树妖之眼珠").Height / Main.npcFrameCount[base.NPC.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.NPC.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.NPC.alpha, 297 - base.NPC.alpha, 297 - base.NPC.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/LanternMoon/千年桔树妖之眼Glow"), vector2 + (player.Center - NPC.Center) / (player.Center - NPC.Center).Length() * 8f, new Rectangle?(base.NPC.frame), new Color(155, 155, 155, 0), base.NPC.rotation, vector, 1f, effects, 0f);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/LanternMoon/千年桔树妖之眼珠"), vector2 + (player.Center - NPC.Center) / (player.Center - NPC.Center).Length() * 15f, new Rectangle?(base.NPC.frame), new Color(255, 255, 255, 0), base.NPC.rotation, vector, 1f, effects, 0f);
            if (!Main.gamePaused)
            {
                if (K != -1)
                {
                    if (Main.projectile[K].type == Mod.Find<ModProjectile>("GreenLight").Type && (Main.projectile[K].position - NPC.Center).Length() < 50)
                    {
                        Main.projectile[K].position = vector2 + (player.Center - NPC.Center) / (player.Center - NPC.Center).Length() * 15f + Main.screenPosition - new Vector2(Main.projectile[K].width / 2f, Main.projectile[K].height / 2f);
                    }
                }
                if (K0 != -1)
                {
                    if (Main.projectile[K0].type == Mod.Find<ModProjectile>("GreenLight3").Type && (Main.projectile[K0].position - NPC.Center).Length() < 50)
                    {
                        Main.projectile[K0].position = vector2 + (player.Center - NPC.Center) / (player.Center - NPC.Center).Length() * 15f + Main.screenPosition - new Vector2(Main.projectile[K0].width / 2f, Main.projectile[K0].height / 2f);
                    }
                }
                if (K1 != -1)
                {
                    if (Main.projectile[K1].type == Mod.Find<ModProjectile>("GreenLight3").Type && (Main.projectile[K1].position - NPC.Center).Length() < 50)
                    {
                        Main.projectile[K1].position = vector2 + (player.Center - NPC.Center) / (player.Center - NPC.Center).Length() * 15f + Main.screenPosition - new Vector2(Main.projectile[K1].width / 2f, Main.projectile[K1].height / 2f);
                    }
                }
                if (can2ai)
                {
                    for(int h = 0;h < 6;h++)
                    {
                        if(M[h] != -1 && Main.projectile[M[h]].type == Mod.Find<ModProjectile>("GreenLight2").Type)
                        {
                            Main.projectile[M[h]].position = vector2 + (player.Center - NPC.Center) / (player.Center - NPC.Center).Length() * 15f + Main.screenPosition - new Vector2(Main.projectile[M[h]].width / 2f, Main.projectile[M[h]].height / 2f);
                        }
                    }
                }
            }
        }
    }
}
