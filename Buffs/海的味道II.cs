using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class 海的味道II : ModBuff
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("海的味道II");
            // base.Description.SetDefault("附近有海鲜\n提升7%闪避");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
            Main.buffNoTimeDisplay[base.Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            mplayer.Misspossibility += 7;
        }
	}
}
