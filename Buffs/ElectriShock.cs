using System;
using Terraria;
using MythMod.NPCs;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class ElectriShock : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("ElectriShock");
            base.Description.SetDefault("ElectriShock");
			Main.debuff[base.Type] = true;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
			this.longerExpertDebuff = false;
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
            npc.GetGlobalNPC<MythGlobalNPC>().ElectriShock = true;
		}
	}
}
