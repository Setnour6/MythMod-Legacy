using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class 嗜血狂暴 : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("嗜血狂暴");
            base.Description.SetDefault("越攻击攻击力越大");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
			this.longerExpertDebuff = false;
		}
	}
}
