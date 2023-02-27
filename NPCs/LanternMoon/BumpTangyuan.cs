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
			Main.npcFrameCount[base.NPC.type] = 3;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "弹弹汤圆");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		// Token: 0x06001B18 RID: 6936 RVA: 0x0014B828 File Offset: 0x00149A28
		public override void SetDefaults()
		{
			base.NPC.aiStyle = 3;
			base.NPC.damage = 60;
			base.NPC.width = 34;
			base.NPC.height = 42;
			base.NPC.defense = 5;
			base.NPC.lifeMax = 800;
			base.NPC.knockBackResist = 0.8f;
			base.NPC.lavaImmune = false;
			base.NPC.noGravity = true;
			base.NPC.noTileCollide = false;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
			base.NPC.buffImmune[24] = true;
            base.NPC.value = 2000;
            this.Banner = base.NPC.type;
            this.BannerItem = base.Mod.Find<ModItem>("TangyuanBanner").Type;
        }
        private int y = 0;
        private int k = 0;
		// Token: 0x06001B19 RID: 6937 RVA: 0x0014B900 File Offset: 0x00149B00
		public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            y += 1;
            if(Math.Abs(NPC.velocity.Y) < 8)
            {
                NPC.frame.Y = 0;
            }
            if(NPC.velocity.Y == 0)
            {
                k += 1;
                if(k >= 3)
                {
                    NPC.velocity.Y -= 7f;
                }
            }
            else
            {
                k = 0;
            }
            if (Math.Abs(NPC.velocity.Y) < 16 && Math.Abs(NPC.velocity.Y) >= 8)
            {
                NPC.frame.Y = 42;
            }
            if (Math.Abs(NPC.velocity.Y) >= 16)
            {
                NPC.frame.Y = 84;
            }
            if (Main.dayTime)
            {
                NPC.noTileCollide = true;
                NPC.velocity.Y += 1;
            }
            if(Math.Abs(NPC.velocity.Y) < 8 && NPC.Center.X - player.Center.X < 0)
            {
                NPC.velocity.X += 0.3f;
            }
            if (Math.Abs(NPC.velocity.Y) < 8 && NPC.Center.X - player.Center.X > 0)
            {
                NPC.velocity.X -= 0.3f;
            }
            if (base.NPC.collideX)
            {
                base.NPC.velocity.X = base.NPC.velocity.X * -1f;
            }
            if (base.NPC.collideY)
            {
                if (base.NPC.velocity.Y > 0f)
                {
                    base.NPC.velocity.Y = Math.Abs(base.NPC.velocity.Y) * -1f - 12f;
                }
                else if (base.NPC.velocity.Y < 0f)
                {
                    base.NPC.velocity.Y = Math.Abs(base.NPC.velocity.Y) + 12f;
                }
            }

            if (base.NPC.collideX && base.NPC.collideY)
            {
                NPC.active = false;
            }
            NPC.velocity.Y += 0.4f;
        }
        public override void OnKill()
        {
            Player player = Main.player[Main.myPlayer];
            if (Main.rand.Next(60) == 1)
            {
                int num = Main.rand.Next(100);
                if (num < 85)
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, base.Mod.Find<ModItem>("SesameGun").Type, 1, false, 0, false, false);
                }
                if (num >= 85 && num < 97)
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, base.Mod.Find<ModItem>("PeanutGun").Type, 1, false, 0, false, false);
                }
                if (num >= 97)
                {
                    Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, base.Mod.Find<ModItem>("TaroGun").Type, 1, false, 0, false, false);
                }
            }
            if (Main.rand.Next(6) == 1)
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, base.Mod.Find<ModItem>("AGrainOfTangyuan").Type, 1, false, 0, false, false);
            }
        }
        // Token: 0x06001B1B RID: 6939 RVA: 0x0014B944 File Offset: 0x00149B44
        public override void HitEffect(int hitDirection, double damage)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.NPC.life <= 0)
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
                    Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/弹弹汤圆碎块"), 1f);
                    for (int j = 0; j < 25; j++)
                    {
                        Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 54, (float)hitDirection, -1f, 0, default(Color), 1f);
                    }
                }
                if (m >= 1000 && m < 2000)
                {
                    float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                    Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/弹弹汤圆碎块2"), 1f);
                    for (int j = 0; j < 25; j++)
                    {
                        Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 102, (float)hitDirection, -1f, 0, default(Color), 1f);
                    }
                }
                if (m >= 2000 && m <= 3000)
                {
                    float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                    Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/弹弹汤圆碎块3"), 1f);
                    for (int j = 0; j < 25; j++)
                    {
                        Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 52, (float)hitDirection, -1f, 0, default(Color), 1f);
                    }
                }
            }
        }

		// Token: 0x06001B1C RID: 6940 RVA: 0x0000B461 File Offset: 0x00009661
	}
}
