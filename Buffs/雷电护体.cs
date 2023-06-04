using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class 雷电护体 : ModBuff
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("雷电护体");
            // base.Description.SetDefault("被闪电环绕");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
			this.longerExpertDebuff/* tModPorter Note: Removed. Use BuffID.Sets.LongerExpertDebuff instead */ = false;
		}
	}
}
