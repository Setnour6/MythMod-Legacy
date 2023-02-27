using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.LanternMoon
{
	// Token: 0x020004EB RID: 1259
    public class PaperCuttingBat : ModNPC
	{
		// Token: 0x06001B17 RID: 6935 RVA: 0x0000B428 File Offset: 0x00009628
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("剪纸蝙蝠");
			Main.npcFrameCount[base.npc.type] = 5;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "剪纸蝙蝠");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		// Token: 0x06001B18 RID: 6936 RVA: 0x0014B828 File Offset: 0x00149A28
		public override void SetDefaults()
		{
			base.npc.aiStyle = 14;
			base.npc.damage = 90;
			base.npc.width = 44;
			base.npc.height = 32;
			base.npc.defense = 5;
			base.npc.lifeMax = 70;
			base.npc.knockBackResist = 0.8f;
			this.animationType = 121;
			base.npc.lavaImmune = false;
			base.npc.noGravity = false;
			base.npc.noTileCollide = false;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
			base.npc.buffImmune[24] = true;
            base.npc.value = 2000;
            this.banner = base.npc.type;
            this.bannerItem = base.mod.ItemType("PaperBatBanner");
        }

		// Token: 0x06001B19 RID: 6937 RVA: 0x0014B900 File Offset: 0x00149B00
		public override void AI()
		{
			float num = 1.0025f;
			NPC npc = base.npc;
			NPC npc2 = base.npc;
			if(Math.Abs(npc.velocity.X) <= 1.5f)
			{
				npc.velocity.X = npc.velocity.X * num;
			}
			else
			{
                npc.velocity.X = npc.velocity.X / num;
			}
			if(Math.Abs(npc2.velocity.Y) <= 1.5f)
			{
				npc2.velocity.Y = npc.velocity.Y * num;
			}
			else
			{
                npc2.velocity.Y = npc2.velocity.Y / num;
			}
            if (Main.dayTime)
            {
                npc.noTileCollide = true;
                npc.velocity.Y += 1;
            }
        }

		// Token: 0x06001B1A RID: 6938 RVA: 0x000037AF File Offset: 0x000019AF
		public override bool PreNPCLoot()
		{
			return false;
		}

		// Token: 0x06001B1B RID: 6939 RVA: 0x0014B944 File Offset: 0x00149B44
		public override void HitEffect(int hitDirection, double damage)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.npc.life <= 0)
			{
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/剪纸蝙蝠碎块"), 1f);
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
