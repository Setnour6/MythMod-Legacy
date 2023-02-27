using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class 劲辣I : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("劲辣I");
            base.Description.SetDefault("附近有辣椒的味道,这味儿对,辣!\n提升3%伤害");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
            Main.buffNoTimeDisplay[base.Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.magicDamage *= 1.03f;
            player.meleeDamage *= 1.03f;
            player.rangedDamage *= 1.03f;
            player.minionDamage *= 1.03f;
            player.thrownDamage *= 1.03f;
        }
	}
}
