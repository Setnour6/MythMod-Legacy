using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class StarSword : ModBuff
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("武器灌注:星渊毒素");
            // base.Description.SetDefault("准备好屠城了吗？");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
			this.longerExpertDebuff/* tModPorter Note: Removed. Use BuffID.Sets.LongerExpertDebuff instead */ = false;
		}
        public override void Update(Player player, ref int buffIndex)
        {
        }
	}
}
