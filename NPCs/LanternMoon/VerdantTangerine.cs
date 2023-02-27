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
            base.DisplayName.SetDefault("青翠年桔木");
			Main.npcFrameCount[base.npc.type] = 4;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "青翠年桔木");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.npc.aiStyle = -1;
			base.npc.damage = 100;
			base.npc.width = 182;
			base.npc.height = 262;
			base.npc.defense = 150;
			base.npc.lifeMax = 10000;
			base.npc.knockBackResist = 0;
			base.npc.lavaImmune = false;
			base.npc.noGravity = true;
			base.npc.noTileCollide = true;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
			base.npc.buffImmune[24] = true;
            base.npc.value = 20000;
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
                npc.localAI[0] = 0;
            }
            npc.localAI[0] += 1;
            if (Math.Abs(npc.velocity.X) > 0.05f)
            {
                if(y % 40 < 10)
                {
                    npc.frame.Y = 0;
                }
                if (y % 40 >= 10 && y % 40 < 20)
                {
                    npc.frame.Y = 262;
                }
                if (y % 40 >= 20 && y % 40 < 30)
                {
                    npc.frame.Y = 524;
                }
                if (y % 40 >= 30 && y % 40 < 40)
                {
                    npc.frame.Y = 786;
                }
            }
            else
            {
                npc.frame.Y = 0;
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
            if(npc.collideX && npc.collideY && (player.Center - npc.Center).Length() > 300f)
            {
                npc.noGravity = true;
                npc.noTileCollide = true;
                if(npc.velocity.Length() < 8)
                {
                    npc.velocity += (player.Center - npc.Center) / (player.Center - npc.Center).Length() * 0.25f;
                }
                npc.velocity *= 0.96f;
            }
            else
            {
                if (Math.Abs(npc.Center.X - player.Center.X) > X)
                {
                    npc.velocity.X += (player.Center.X - npc.Center.X) / Math.Abs(npc.Center.X - player.Center.X) * 0.3f;
                }
                if (Math.Abs(npc.Center.X - player.Center.X) > X && base.npc.collideX && npc.velocity.Y >= -4f && Math.Abs(npc.velocity.X) <= 8)
                {
                    npc.velocity.Y -= 3f;
                    npc.velocity.X += (player.Center.X - npc.Center.X) / Math.Abs(npc.Center.X - player.Center.X) * 2f;
                }
                if (Math.Abs(npc.velocity.Y) <= 0.3f && Math.Abs(npc.velocity.X) <= 8f && npc.velocity.Y != 0)
                {
                    npc.velocity.X += (player.Center.X - npc.Center.X) / Math.Abs(npc.Center.X - player.Center.X) * 0.5f;
                }
                if (Math.Abs(npc.Center.X - player.Center.X) <= X)
                {
                    npc.velocity.X *= 0.95f;
                }
                if (npc.Center.Y - player.Center.Y > -50 && npc.velocity.Y > -6f && npc.noGravity)
                {
                    npc.velocity.Y -= 0.15f;
                }
                if (npc.Center.Y - player.Center.Y <= -50)
                {
                    npc.velocity.Y += 0.15f;
                }
                if (npc.Center.Y > player.Center.Y - 50f || !npc.collideX)
                {
                    npc.noGravity = false;
                    npc.noTileCollide = false;
                }
                else
                {
                    npc.noTileCollide = true;
                    npc.noGravity = true;
                }
                if (Main.dayTime)
                {
                    npc.noTileCollide = true;
                    npc.velocity.Y += 1;
                }
            }
            
            if((player.Center - npc.Center).Length() < 500)
            {
                if (npc.localAI[0] % 900 < 300 && npc.localAI[0] % 80 == 0)
                {
                    Projectile.NewProjectile(npc.Center.X - 13f, npc.Center.Y + 24f, (player.Center.X - npc.Center.X + 13f) / 10f + Main.rand.Next(-2000, 2000) / 1000f, (player.Center.Y - npc.Center.Y - 24f) / 9f + Main.rand.Next(1800, 2400) / 200f, mod.ProjectileType("GreenFlame"), 100, 0f, Main.myPlayer, 0f, 0f);
                }
                if (npc.localAI[0] % 900 < 300 && npc.localAI[0] % 80 == 40)
                {
                    Projectile.NewProjectile(npc.Center.X + 13f, npc.Center.Y + 24f, (player.Center.X - npc.Center.X - 13f) / 10f + Main.rand.Next(-2000, 2000) / 1000f, (player.Center.Y - npc.Center.Y - 24f) / 9f + Main.rand.Next(1800, 2400) / 200f, mod.ProjectileType("GreenFlame"), 100, 0f, Main.myPlayer, 0f, 0f);
                }
                if (npc.localAI[0] % 900 >= 300 && npc.localAI[0] % 10 == 0)
                {
                    Projectile.NewProjectile(npc.Center.X + Main.rand.Next(-80, 80), npc.Center.Y + Main.rand.Next(-100, 100), (player.Center.X - npc.Center.X) / 24f + Main.rand.Next(-2000, 2000) / 1000f, (player.Center.Y - npc.Center.Y) / 10f + Main.rand.Next(1800, 2400) / 200f, mod.ProjectileType("桔子2"), 100, 0f, Main.myPlayer, 0f, 0f);
                }
            }
        }
        public override void NPCLoot()
        {
            bool expertMode = Main.expertMode;
            Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, 58, 25, false, 0, false, false);
            Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, mod.ItemType("OrangeBullet"), 33, false, 0, false, false);
        }
        public override bool PreNPCLoot()
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
        public override void HitEffect(int hitDirection, double damage)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.npc.life <= 0)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(new Vector2(base.npc.position.X, base.npc.position.Y + 150), base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/青翠年桔木碎块1"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/青翠年桔木碎块2"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/青翠年桔木碎块2"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/青翠年桔木碎块2"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/青翠年桔木碎块3"), 1f);
                for(int v = 0; v < 10;v++)
                {
                    Gore.NewGore(base.npc.position + new Vector2(Main.rand.Next(0, 180), Main.rand.Next(0, 240)), base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/青翠年桔木碎块4"), 1f);
                    Gore.NewGore(base.npc.position + new Vector2(Main.rand.Next(0, 180), Main.rand.Next(0, 240)), base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/青翠年桔木碎块5"), 1f);
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
                Gore.NewGore(base.npc.position + new Vector2(Main.rand.Next(0, 180), Main.rand.Next(0, 240)), base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/青翠年桔木碎块4"), 1f);
            }
            if (Main.rand.Next(15) == 1)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.npc.position + new Vector2(Main.rand.Next(0, 180), Main.rand.Next(0, 240)), base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/青翠年桔木碎块5"), 1f);
            }
        }

		// Token: 0x06001B1C RID: 6940 RVA: 0x0000B461 File Offset: 0x00009661
	}
}
