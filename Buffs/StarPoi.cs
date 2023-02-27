using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class StarPoi : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("StarPoi");
            base.Description.SetDefault("海水已经被星渊毒素污染\n深海的黑暗抑制了毒素在你体内蔓延");
			Main.debuff[base.Type] = true;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
			Main.buffNoTimeDisplay[base.Type] = true;
			this.longerExpertDebuff/* tModPorter Note: Removed. Use BuffID.Sets.LongerExpertDebuff instead */ = true;
		}
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MythPlayer>().StarPoi = true;
        }
	}
}
