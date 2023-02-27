using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class 冰饮III : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("冰饮III");
            base.Description.SetDefault("附近有解暑的饮料,让你状态良好\n提升11%移速");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
            Main.buffNoTimeDisplay[base.Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed *= 1.11f; 
        }
	}
}
