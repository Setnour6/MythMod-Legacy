using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class 雨露 : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("雨露");
            base.Description.SetDefault("下雨越大你的攻击伤害越高,且你的生命在雨中缓缓回复");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
			this.longerExpertDebuff/* tModPorter Note: Removed. Use BuffID.Sets.LongerExpertDebuff instead */ = false;
		}
	}
}
