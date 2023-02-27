using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.LanternMoon
{
	// Token: 0x020004EB RID: 1259
    public class ChocolateSlime1 : ModNPC
	{
		// Token: 0x06001B17 RID: 6935 RVA: 0x0000B428 File Offset: 0x00009628
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("巧克力糖史莱姆");
			Main.npcFrameCount[base.npc.type] = 4;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "巧克力糖史莱姆");
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
			base.npc.width = 40;
			base.npc.height = 30;
			base.npc.defense = 5;
			base.npc.lifeMax = 400;
			base.npc.knockBackResist = 0.8f;
			this.animationType = 121;
			base.npc.alpha = 0;
			base.npc.lavaImmune = false;
			base.npc.noGravity = false;
			base.npc.noTileCollide = true;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
			base.npc.buffImmune[24] = true;
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
		}

		// Token: 0x06001B1A RID: 6938 RVA: 0x000037AF File Offset: 0x000019AF
		public override bool PreNPCLoot()
		{
			return false;
		}

		// Token: 0x06001B1B RID: 6939 RVA: 0x0014B944 File Offset: 0x00149B44
		public override void HitEffect(int hitDirection, double damage)
		{
			if (Main.netMode != 1 && base.npc.life <= 0)
			{
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/糖史莱姆碎块"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/糖史莱姆碎块"), 1f);
                Vector2 vector = base.npc.Center + new Vector2(0f, (float)base.npc.height / 2f);
				NPC.NewNPC((int)vector.X, (int)vector.Y, mod.NPCType("ChocolateSlime"), 0, 0f, 0f, 0f, 0f, 255);
			}
		}

		// Token: 0x06001B1C RID: 6940 RVA: 0x0000B461 File Offset: 0x00009661
	}
}
