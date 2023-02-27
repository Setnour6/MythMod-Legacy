using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class LowDisorder : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("低阶混乱");
            base.Description.SetDefault("使用不稳定的传送杖将消耗生命");
			Main.debuff[base.Type] = true;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
			this.longerExpertDebuff/* tModPorter Note: Removed. Use BuffID.Sets.LongerExpertDebuff instead */ = false;
		}
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MythPlayer>().LowDisorder = true;
        }
	}
}
