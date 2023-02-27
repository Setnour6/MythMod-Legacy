using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class 酒香I : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("酒香I");
            base.Description.SetDefault("好酒,好酒\n提升3%暴击");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
            Main.buffNoTimeDisplay[base.Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.magicCrit += 3;
            player.meleeCrit += 3;
            player.rangedCrit += 3;
            player.thrownCrit += 3;
        }
	}
}
