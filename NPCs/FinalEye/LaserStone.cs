using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.FinalEye
{
	// Token: 0x02000420 RID: 1056
    public class LaserStone : ModNPC
	{
		// Token: 0x06001475 RID: 5237 RVA: 0x000082F6 File Offset: 0x000064F6
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("Stone");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "激光封印石");
		}
		public override void SetDefaults()
		{
			base.npc.knockBackResist = 0f;
			base.npc.noGravity = true;
			base.npc.damage = 60;
			base.npc.width = 32;
			base.npc.height = 32;
			base.npc.defense = 5;
			base.npc.lifeMax = 2000000;
			base.npc.aiStyle = -1;
			this.aiType = -1;
			base.npc.HitSound = SoundID.NPCHit2;
		}

		// Token: 0x06001477 RID: 5239 RVA: 0x000B3A6C File Offset: 0x000B1C6C
		public override void AI()
		{
		}

		// Token: 0x06001478 RID: 5240 RVA: 0x000A9970 File Offset: 0x000A7B70
		public override void FindFrame(int frameHeight)
		{
		}
		// Token: 0x0600147B RID: 5243 RVA: 0x000A99DC File Offset: 0x000A7BDC
		public override void HitEffect(int hitDirection, double damage)
		{
		}
        // Token: 0x02000413 RID: 1043
        public override void NPCLoot()
        {
        }
	}
}
