using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.LanternMoon
{
	// Token: 0x020004EB RID: 1259
    public class BumpTangyuan : ModNPC
	{
		// Token: 0x06001B17 RID: 6935 RVA: 0x0000B428 File Offset: 0x00009628
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("弹弹汤圆");
			Main.npcFrameCount[base.npc.type] = 3;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "弹弹汤圆");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		// Token: 0x06001B18 RID: 6936 RVA: 0x0014B828 File Offset: 0x00149A28
		public override void SetDefaults()
		{
			base.npc.aiStyle = 3;
			base.npc.damage = 60;
			base.npc.width = 34;
			base.npc.height = 42;
			base.npc.defense = 5;
			base.npc.lifeMax = 800;
			base.npc.knockBackResist = 0.8f;
			base.npc.lavaImmune = false;
			base.npc.noGravity = true;
			base.npc.noTileCollide = false;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
			base.npc.buffImmune[24] = true;
            base.npc.value = 2000;
            this.banner = base.npc.type;
            this.bannerItem = base.mod.ItemType("TangyuanBanner");
        }
        private int y = 0;
        private int k = 0;
		// Token: 0x06001B19 RID: 6937 RVA: 0x0014B900 File Offset: 0x00149B00
		public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            y += 1;
            if(Math.Abs(npc.velocity.Y) < 8)
            {
                npc.frame.Y = 0;
            }
            if(npc.velocity.Y == 0)
            {
                k += 1;
                if(k >= 3)
                {
                    npc.velocity.Y -= 7f;
                }
            }
            else
            {
                k = 0;
            }
            if (Math.Abs(npc.velocity.Y) < 16 && Math.Abs(npc.velocity.Y) >= 8)
            {
                npc.frame.Y = 42;
            }
            if (Math.Abs(npc.velocity.Y) >= 16)
            {
                npc.frame.Y = 84;
            }
            if (Main.dayTime)
            {
                npc.noTileCollide = true;
                npc.velocity.Y += 1;
            }
            if(Math.Abs(npc.velocity.Y) < 8 && npc.Center.X - player.Center.X < 0)
            {
                npc.velocity.X += 0.3f;
            }
            if (Math.Abs(npc.velocity.Y) < 8 && npc.Center.X - player.Center.X > 0)
            {
                npc.velocity.X -= 0.3f;
            }
            if (base.npc.collideX)
            {
                base.npc.velocity.X = base.npc.velocity.X * -1f;
            }
            if (base.npc.collideY)
            {
                if (base.npc.velocity.Y > 0f)
                {
                    base.npc.velocity.Y = Math.Abs(base.npc.velocity.Y) * -1f - 12f;
                }
                else if (base.npc.velocity.Y < 0f)
                {
                    base.npc.velocity.Y = Math.Abs(base.npc.velocity.Y) + 12f;
                }
            }

            if (base.npc.collideX && base.npc.collideY)
            {
                npc.active = false;
            }
            npc.velocity.Y += 0.4f;
        }
        public override void NPCLoot()
        {
            Player player = Main.player[Main.myPlayer];
            if (Main.rand.Next(60) == 1)
            {
                int num = Main.rand.Next(100);
                if (num < 85)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("SesameGun"), 1, false, 0, false, false);
                }
                if (num >= 85 && num < 97)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("PeanutGun"), 1, false, 0, false, false);
                }
                if (num >= 97)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("TaroGun"), 1, false, 0, false, false);
                }
            }
            if (Main.rand.Next(6) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, base.mod.ItemType("AGrainOfTangyuan"), 1, false, 0, false, false);
            }
        }
        // Token: 0x06001B1B RID: 6939 RVA: 0x0014B944 File Offset: 0x00149B44
        public override void HitEffect(int hitDirection, double damage)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.npc.life <= 0)
            {
                if (mplayer.LanternMoonWave != 25)
                {
                    if (Main.expertMode)
                    {
                        mplayer.LanternMoonPoint += 40;
                        if (MythWorld.Myth)
                        {
                            mplayer.LanternMoonPoint += 40;
                        }
                    }
                    else
                    {
                        mplayer.LanternMoonPoint += 20;
                    }
                }
                int m = Main.rand.Next(3000);
                if(m < 1000)
                {
                    float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                    Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/弹弹汤圆碎块"), 1f);
                    for (int j = 0; j < 25; j++)
                    {
                        Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 54, (float)hitDirection, -1f, 0, default(Color), 1f);
                    }
                }
                if (m >= 1000 && m < 2000)
                {
                    float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                    Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/弹弹汤圆碎块2"), 1f);
                    for (int j = 0; j < 25; j++)
                    {
                        Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 102, (float)hitDirection, -1f, 0, default(Color), 1f);
                    }
                }
                if (m >= 2000 && m <= 3000)
                {
                    float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                    Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/弹弹汤圆碎块3"), 1f);
                    for (int j = 0; j < 25; j++)
                    {
                        Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 52, (float)hitDirection, -1f, 0, default(Color), 1f);
                    }
                }
            }
        }

		// Token: 0x06001B1C RID: 6940 RVA: 0x0000B461 File Offset: 0x00009661
	}
}
