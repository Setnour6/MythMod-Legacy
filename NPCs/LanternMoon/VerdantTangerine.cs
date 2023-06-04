using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.LanternMoon
{
    [AutoloadBossHead]
    public class VerdantTangerine : ModNPC
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("青翠年桔木");
			Main.npcFrameCount[base.NPC.type] = 4;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "青翠年桔木");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.NPC.aiStyle = -1;
			base.NPC.damage = 100;
			base.NPC.width = 182;
			base.NPC.height = 262;
			base.NPC.defense = 150;
			base.NPC.lifeMax = 10000;
			base.NPC.knockBackResist = 0;
			base.NPC.lavaImmune = false;
			base.NPC.noGravity = true;
			base.NPC.noTileCollide = true;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
			base.NPC.buffImmune[24] = true;
            base.NPC.value = 20000;
        }
        private int y = 0;
        private int U = 0;
        private int X = 0;
        public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            y += 1;
            if(X == 0)
            {
                X = Main.rand.Next(200, 500);
                NPC.localAI[0] = 0;
            }
            NPC.localAI[0] += 1;
            if (Math.Abs(NPC.velocity.X) > 0.05f)
            {
                if(y % 40 < 10)
                {
                    NPC.frame.Y = 0;
                }
                if (y % 40 >= 10 && y % 40 < 20)
                {
                    NPC.frame.Y = 262;
                }
                if (y % 40 >= 20 && y % 40 < 30)
                {
                    NPC.frame.Y = 524;
                }
                if (y % 40 >= 30 && y % 40 < 40)
                {
                    NPC.frame.Y = 786;
                }
            }
            else
            {
                NPC.frame.Y = 0;
            }
            if (y % 60 < 15)
            {
                U = 0;
            }
            if (y % 60 >= 15 && y % 60 < 30)
            {
                U = 256;
            }
            if (y % 60 >= 30 && y % 60 < 45)
            {
                U = 512;
            }
            if (y % 60 >= 45 && y % 60 < 60)
            {
                U = 768;
            }
            if(NPC.collideX && NPC.collideY && (player.Center - NPC.Center).Length() > 300f)
            {
                NPC.noGravity = true;
                NPC.noTileCollide = true;
                if(NPC.velocity.Length() < 8)
                {
                    NPC.velocity += (player.Center - NPC.Center) / (player.Center - NPC.Center).Length() * 0.25f;
                }
                NPC.velocity *= 0.96f;
            }
            else
            {
                if (Math.Abs(NPC.Center.X - player.Center.X) > X)
                {
                    NPC.velocity.X += (player.Center.X - NPC.Center.X) / Math.Abs(NPC.Center.X - player.Center.X) * 0.3f;
                }
                if (Math.Abs(NPC.Center.X - player.Center.X) > X && base.NPC.collideX && NPC.velocity.Y >= -4f && Math.Abs(NPC.velocity.X) <= 8)
                {
                    NPC.velocity.Y -= 3f;
                    NPC.velocity.X += (player.Center.X - NPC.Center.X) / Math.Abs(NPC.Center.X - player.Center.X) * 2f;
                }
                if (Math.Abs(NPC.velocity.Y) <= 0.3f && Math.Abs(NPC.velocity.X) <= 8f && NPC.velocity.Y != 0)
                {
                    NPC.velocity.X += (player.Center.X - NPC.Center.X) / Math.Abs(NPC.Center.X - player.Center.X) * 0.5f;
                }
                if (Math.Abs(NPC.Center.X - player.Center.X) <= X)
                {
                    NPC.velocity.X *= 0.95f;
                }
                if (NPC.Center.Y - player.Center.Y > -50 && NPC.velocity.Y > -6f && NPC.noGravity)
                {
                    NPC.velocity.Y -= 0.15f;
                }
                if (NPC.Center.Y - player.Center.Y <= -50)
                {
                    NPC.velocity.Y += 0.15f;
                }
                if (NPC.Center.Y > player.Center.Y - 50f || !NPC.collideX)
                {
                    NPC.noGravity = false;
                    NPC.noTileCollide = false;
                }
                else
                {
                    NPC.noTileCollide = true;
                    NPC.noGravity = true;
                }
                if (Main.dayTime)
                {
                    NPC.noTileCollide = true;
                    NPC.velocity.Y += 1;
                }
            }
            
            if((player.Center - NPC.Center).Length() < 500)
            {
                if (NPC.localAI[0] % 900 < 300 && NPC.localAI[0] % 80 == 0)
                {
                    Projectile.NewProjectile(NPC.Center.X - 13f, NPC.Center.Y + 24f, (player.Center.X - NPC.Center.X + 13f) / 10f + Main.rand.Next(-2000, 2000) / 1000f, (player.Center.Y - NPC.Center.Y - 24f) / 9f + Main.rand.Next(1800, 2400) / 200f, Mod.Find<ModProjectile>("GreenFlame").Type, 100, 0f, Main.myPlayer, 0f, 0f);
                }
                if (NPC.localAI[0] % 900 < 300 && NPC.localAI[0] % 80 == 40)
                {
                    Projectile.NewProjectile(NPC.Center.X + 13f, NPC.Center.Y + 24f, (player.Center.X - NPC.Center.X - 13f) / 10f + Main.rand.Next(-2000, 2000) / 1000f, (player.Center.Y - NPC.Center.Y - 24f) / 9f + Main.rand.Next(1800, 2400) / 200f, Mod.Find<ModProjectile>("GreenFlame").Type, 100, 0f, Main.myPlayer, 0f, 0f);
                }
                if (NPC.localAI[0] % 900 >= 300 && NPC.localAI[0] % 10 == 0)
                {
                    Projectile.NewProjectile(NPC.Center.X + Main.rand.Next(-80, 80), NPC.Center.Y + Main.rand.Next(-100, 100), (player.Center.X - NPC.Center.X) / 24f + Main.rand.Next(-2000, 2000) / 1000f, (player.Center.Y - NPC.Center.Y) / 10f + Main.rand.Next(1800, 2400) / 200f, Mod.Find<ModProjectile>("桔子2").Type, 100, 0f, Main.myPlayer, 0f, 0f);
                }
            }
        }
        public override void OnKill()
        {
            bool expertMode = Main.expertMode;
            Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, 58, 25, false, 0, false, false);
            Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, Mod.Find<ModItem>("OrangeBullet").Type, 33, false, 0, false, false);
        }
        public override bool PreKill()
		{
			return false;
		}
        /*public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (base.npc.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Vector2 value = new Vector2(base.npc.Center.X, base.npc.Center.Y);
            Vector2 vector = new Vector2((float)(Main.npcTexture[base.npc.type].Width / 2), (float)(Main.npcTexture[base.npc.type].Height / Main.npcFrameCount[base.npc.type] / 2));
            Vector2 vector2 = value - Main.screenPosition;
            vector2 -= new Vector2((float)base.mod.GetTexture("NPCs/LanternMoon/年桔树眼睛").Width, (float)(base.mod.GetTexture("NPCs/LanternMoon/年桔树眼睛").Height / Main.npcFrameCount[base.npc.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.npc.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(97 - base.npc.alpha, 97 - base.npc.alpha, 97 - base.npc.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/LanternMoon/年桔树眼睛"), vector2, new Rectangle(0,U,180,256), new Color(255,255,255,0), base.npc.rotation, vector, 1f, effects, 0f);
        }*/
        // Token: 0x06001B1B RID: 6939 RVA: 0x0014B944 File Offset: 0x00149B44
        public override void HitEffect(NPC.HitInfo hit)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.NPC.life <= 0)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(new Vector2(base.NPC.position.X, base.NPC.position.Y + 150), base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/青翠年桔木碎块1"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/青翠年桔木碎块2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/青翠年桔木碎块2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/青翠年桔木碎块2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/青翠年桔木碎块3"), 1f);
                for(int v = 0; v < 10;v++)
                {
                    Gore.NewGore(base.NPC.position + new Vector2(Main.rand.Next(0, 180), Main.rand.Next(0, 240)), base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/青翠年桔木碎块4"), 1f);
                    Gore.NewGore(base.NPC.position + new Vector2(Main.rand.Next(0, 180), Main.rand.Next(0, 240)), base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/青翠年桔木碎块5"), 1f);
                }
                if (mplayer.LanternMoonWave != 25)
                {
                    if (Main.expertMode)
                    {
                        mplayer.LanternMoonPoint += 240;
                        if (MythWorld.Myth)
                        {
                            mplayer.LanternMoonPoint += 240;
                        }
                    }
                    else
                    {
                        mplayer.LanternMoonPoint += 120;
                    }
                }
            }
            if(Main.rand.Next(15) == 1)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.NPC.position + new Vector2(Main.rand.Next(0, 180), Main.rand.Next(0, 240)), base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/青翠年桔木碎块4"), 1f);
            }
            if (Main.rand.Next(15) == 1)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.NPC.position + new Vector2(Main.rand.Next(0, 180), Main.rand.Next(0, 240)), base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/青翠年桔木碎块5"), 1f);
            }
        }

		// Token: 0x06001B1C RID: 6940 RVA: 0x0000B461 File Offset: 0x00009661
	}
}
