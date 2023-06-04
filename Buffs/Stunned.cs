using System;
using MythMod.NPCs;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
	// Token: 0x0200002B RID: 43
    public class Stunned : ModBuff
	{
		// Token: 0x060000F9 RID: 249 RVA: 0x0002EB44 File Offset: 0x0002CD44
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("Stunned");
			// base.Description.SetDefault("Cannot move");
			Main.debuff[base.Type] = true;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
			this.longerExpertDebuff/* tModPorter Note: Removed. Use BuffID.Sets.LongerExpertDebuff instead */ = false;
			base.DisplayName.AddTranslation(GameCulture.Chinese, "迷恋");
			base.Description.AddTranslation(GameCulture.Chinese, "浪漫的爱情使你心醉，以至于忘记了一切……");
		}

		// Token: 0x060000FA RID: 250 RVA: 0x000026E2 File Offset: 0x000008E2
		public override void Update(NPC npc, ref int buffIndex)
		{
            npc.GetGlobalNPC<MythGlobalNPC>().Stunned = true;
		}
	}
}
