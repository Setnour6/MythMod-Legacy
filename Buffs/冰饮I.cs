using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class 冰饮I : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("冰饮I");
            base.Description.SetDefault("附近有解暑的饮料,让你状态良好\n提升3%移速");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
            Main.buffNoTimeDisplay[base.Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed *= 1.03f; 
        }
	}
}
