using System;
using MythMod.NPCs;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class BIAOJI : ModBuff
	{
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("BIAOJI");
			// base.Description.SetDefault("被制成了巫毒娃娃");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
			this.longerExpertDebuff/* tModPorter Note: Removed. Use BuffID.Sets.LongerExpertDebuff instead */ = false;
			base.DisplayName.AddTranslation(GameCulture.Chinese, "标记");
			base.Description.AddTranslation(GameCulture.Chinese, "被制成了巫毒娃娃");
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
            npc.GetGlobalNPC<MythGlobalNPC>().BIAOJI = true;
		}
	}
}
