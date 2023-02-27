using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class 酒香II : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("酒香II");
            base.Description.SetDefault("好酒,好酒\n提升7%暴击");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
            Main.buffNoTimeDisplay[base.Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.magicCrit += 7;
            player.meleeCrit += 7;
            player.rangedCrit += 7;
            player.thrownCrit += 7;
        }
	}
}
