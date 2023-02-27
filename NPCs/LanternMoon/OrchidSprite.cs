using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.LanternMoon
{
    public class OrchidSprite : ModNPC
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("兰花精灵");
			Main.npcFrameCount[base.npc.type] = 9;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "兰花精灵");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.npc.aiStyle = 3;
			base.npc.damage = 125;
			base.npc.width = 52;
			base.npc.height = 58;
			base.npc.defense = 5;
			base.npc.lifeMax = 6000;
			base.npc.knockBackResist = 0.15f;
			base.npc.lavaImmune = false;
			base.npc.noGravity = false;
			base.npc.noTileCollide = false;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
			base.npc.buffImmune[24] = true;
            base.npc.value = 10000;
            this.banner = base.npc.type;
            this.bannerItem = base.mod.ItemType("FlowerSpriteBanner");
        }
        private int y = 0;
        private int l = 0;
        private bool N = true;
        private bool M = true;
        public override void AI()
		{
            Player p = Main.player[Main.myPlayer];
            y += 1;
            if(N)
            {
                l = Main.rand.Next(100, 450);
                N = false;
            }
            if ((npc.Center - p.Center).Length() > l)
            {
                npc.spriteDirection = npc.velocity.X > 0 ? 1 : -1;
                npc.aiStyle = 3;
                if (npc.velocity.Y != 0)
                {
                    npc.frame.Y = 0;
                }
                else
                {
                    if (y % 30 >= 15)
                    {
                        npc.frame.Y = 58;
                    }
                    else
                    {
                        npc.frame.Y = 116;
                    }
                }
                M = true;
            }
            else
            {
                if (M)
                {
                    y = 0;
                    M = false;
                }
                npc.spriteDirection = npc.Center.X - p.Center.X > 0 ? -1 : 1;
                npc.aiStyle = -1;
                npc.velocity.X *= 0.9f;
                if (y % 30 < 5)
                {
                    npc.frame.Y = 174;
                }
                if (y % 30 >= 5 && y % 30 < 10)
                {
                    npc.frame.Y = 232;
                }
                if (y % 30 >= 10 && y % 30 < 15)
                {
                    npc.frame.Y = 290;
                    Vector2 v = ((npc.Center - p.Center) / (npc.Center - p.Center).Length() * 15f).RotatedBy(((y % 30) - 12) / 6f * Math.PI);
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, -v.X, -v.Y, mod.ProjectileType("兰花剑气"), 150, 0f, Main.myPlayer, 0f, 0f);
                }
                if (y % 30 >= 15 && y % 30 < 20)
                {
                    npc.frame.Y = 348;
                }
                if (y % 30 >= 20 && y % 30 < 25)
                {
                    npc.frame.Y = 406;
                }
                if (y % 30 >= 25 && y % 30 < 30)
                {
                    npc.frame.Y = 464;
                }
            }
            if (Main.dayTime)
            {
                npc.noTileCollide = true;
                npc.velocity.Y += 1;
            }
        }
        public override bool PreNPCLoot()
		{
			return false;
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
            vector2 -= new Vector2((float)base.mod.GetTexture("NPCs/LanternMoon/兰花精灵Glow").Width, (float)(base.mod.GetTexture("NPCs/LanternMoon/兰花精灵Glow").Height / Main.npcFrameCount[base.npc.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.npc.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(97 - base.npc.alpha, 97 - base.npc.alpha, 97 - base.npc.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/LanternMoon/兰花精灵Glow"), vector2, new Rectangle(0, npc.frame.Y, 52, 58), new Color(150, 150, 150, 0), base.npc.rotation, vector, 1f, effects, 0f);
        }
        // Token: 0x06001B1B RID: 6939 RVA: 0x0014B944 File Offset: 0x00149B44
        public override void HitEffect(int hitDirection, double damage)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.npc.life <= 0)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/兰花精灵碎块1"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/兰花精灵碎块2"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/兰花精灵碎块3"), 1f);
                if (mplayer.LanternMoonWave != 25)
                {
                    if (Main.expertMode)
                    {
                        mplayer.LanternMoonPoint += 60;
                        if (MythWorld.Myth)
                        {
                            mplayer.LanternMoonPoint += 60;
                        }
                    }
                    else
                    {
                        mplayer.LanternMoonPoint += 30;
                    }
                }
            }
        }
        public override void NPCLoot()
        {
            Player player = Main.player[Main.myPlayer];
            if(Main.rand.Next(20) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("PhalaenopsisStaff"), 1, false, 0, false, false);
            }
        }
        // Token: 0x06001B1C RID: 6940 RVA: 0x0000B461 File Offset: 0x00009661
    }
}
