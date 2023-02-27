using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.LanternMoon
{
	// Token: 0x020004EB RID: 1259
    public class HappinessZombie : ModNPC
	{
		// Token: 0x06001B17 RID: 6935 RVA: 0x0000B428 File Offset: 0x00009628
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("吉祥僵尸");
			Main.npcFrameCount[base.NPC.type] = 3;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "吉祥僵尸");
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
			base.NPC.height = 48;
			base.NPC.defense = 5;
			base.NPC.lifeMax = 90;
			base.NPC.knockBackResist = 0.8f;
			base.NPC.lavaImmune = false;
			base.NPC.noGravity = false;
			base.NPC.noTileCollide = false;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
			base.NPC.buffImmune[24] = true;
            base.NPC.value = 2000;
            this.Banner = base.NPC.type;
            this.BannerItem = base.Mod.Find<ModItem>("SpringzombieBanner").Type;
        }
        private int y = 0;
		// Token: 0x06001B19 RID: 6937 RVA: 0x0014B900 File Offset: 0x00149B00
		public override void AI()
		{
            y += 1;
            if(NPC.velocity.Y != 0)
            {
                NPC.frame.Y = 96;
            }
            else
            {
                if(y % 30 >= 15)
                {
                    NPC.frame.Y = 0;
                }
                else
                {
                    NPC.frame.Y = 48;
                }
            }
            if (NPC.life < NPC.lifeMax * 0.5f)
            {
                NPC.aiStyle = 3;
            }
            NPC.spriteDirection = NPC.velocity.X > 0 ? 1 : -1;
            if (Main.dayTime)
            {
                NPC.noTileCollide = true;
                NPC.velocity.Y += 1;
            }
        }
        // Token: 0x06001B1A RID: 6938 RVA: 0x000037AF File Offset: 0x000019AF
        public override bool PreKill()
		{
			return false;
		}

		// Token: 0x06001B1B RID: 6939 RVA: 0x0014B944 File Offset: 0x00149B44
		public override void HitEffect(int hitDirection, double damage)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.NPC.life <= 0)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/吉祥僵尸碎块"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, 4, 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, 5, 1f);
                if (mplayer.LanternMoonWave != 15)
                {
                    if (Main.expertMode)
                    {
                        mplayer.LanternMoonPoint += 10;
                        if (MythWorld.Myth)
                        {
                            mplayer.LanternMoonPoint += 10;
                        }
                    }
                    else
                    {
                        mplayer.LanternMoonPoint += 5;
                    }
                }
            }
        }

		// Token: 0x06001B1C RID: 6940 RVA: 0x0000B461 File Offset: 0x00009661
	}
}
