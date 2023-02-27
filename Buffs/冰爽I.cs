using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class 冰爽I : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("冰爽I");
            base.Description.SetDefault("附近有解暑的东西,让你状态良好\n提升3%攻速");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
            Main.buffNoTimeDisplay[base.Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetAttackSpeed(DamageClass.Melee) *= 1.03f; ;
        }
	}
}
