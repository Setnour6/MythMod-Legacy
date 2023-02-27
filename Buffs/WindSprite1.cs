using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class WindSprite1 : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("风之精灵");
            base.Description.SetDefault("风之精灵将守护你");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
            Main.buffNoTimeDisplay[base.Type] = true;
            this.longerExpertDebuff/* tModPorter Note: Removed. Use BuffID.Sets.LongerExpertDebuff instead */ = false;
		}
	}
}
