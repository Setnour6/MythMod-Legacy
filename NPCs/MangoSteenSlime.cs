using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs
{
	// Token: 0x020004EB RID: 1259
    public class MangoSteenSlime : ModNPC
	{
		// Token: 0x06001B17 RID: 6935 RVA: 0x0000B428 File Offset: 0x00009628
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("山竹史莱姆");
			Main.npcFrameCount[base.NPC.type] = 4;
		}

		// Token: 0x06001B18 RID: 6936 RVA: 0x0014B828 File Offset: 0x00149A28
		public override void SetDefaults()
		{
			base.NPC.aiStyle = 14;
			base.NPC.damage = 162;
			base.NPC.width = 40;
			base.NPC.height = 30;
			base.NPC.defense = 35;
			base.NPC.lifeMax = 285;
			base.NPC.knockBackResist = 0.8f;
			this.AnimationType = 121;
			base.NPC.alpha = 30;
			base.NPC.lavaImmune = false;
			base.NPC.noGravity = false;
			base.NPC.noTileCollide = false;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
			base.NPC.buffImmune[24] = true;
		}

		// Token: 0x06001B19 RID: 6937 RVA: 0x0014B900 File Offset: 0x00149B00
		public override void AI()
		{
			float num = 1.0025f;
			NPC npc = base.NPC;
			npc.velocity.X = npc.velocity.X * num;
			NPC npc2 = base.NPC;
			npc2.velocity.Y = npc2.velocity.Y * num;
		}

		// Token: 0x06001B1A RID: 6938 RVA: 0x000037AF File Offset: 0x000019AF
		public override bool PreKill()
		{
                Item.NewItem((int)base.NPC.position.X, (int)base.NPC.position.Y, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("山竹之魂").Type, Main.rand.Next(2,5), false, 0, false, false);
			return false;
		}

		// Token: 0x06001B1B RID: 6939 RVA: 0x0014B944 File Offset: 0x00149B44
		public override void HitEffect(int hitDirection, double damage)
		{
			if (Main.netMode != 1 && base.NPC.life <= 0)
			{
				Vector2 vector = base.NPC.Center + new Vector2(0f, (float)base.NPC.height / 2f);
				NPC.NewNPC((int)vector.X, (int)vector.Y, 1, 0, 0f, 0f, 0f, 0f, 255);
			}
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 4, (float)hitDirection, -1f, 0, default(Color), 1f);
			}
		}

		// Token: 0x06001B1C RID: 6940 RVA: 0x0000B461 File Offset: 0x00009661
	}
}
