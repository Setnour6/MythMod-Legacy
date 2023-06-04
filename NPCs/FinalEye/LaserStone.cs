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
            // base.DisplayName.SetDefault("Stone");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "激光封印石");
		}
		public override void SetDefaults()
		{
			base.NPC.knockBackResist = 0f;
			base.NPC.noGravity = true;
			base.NPC.damage = 60;
			base.NPC.width = 32;
			base.NPC.height = 32;
			base.NPC.defense = 5;
			base.NPC.lifeMax = 2000000;
			base.NPC.aiStyle = -1;
			this.AIType = -1;
			base.NPC.HitSound = SoundID.NPCHit2;
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
		public override void HitEffect(NPC.HitInfo hit)
		{
		}
        // Token: 0x02000413 RID: 1043
        public override void OnKill()
        {
        }
	}
}
