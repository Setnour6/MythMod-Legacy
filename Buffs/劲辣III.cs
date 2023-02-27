using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class 劲辣III : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("劲辣III");
            base.Description.SetDefault("附近有辣椒的味道,这味儿对,辣!\n提升11%伤害");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
            Main.buffNoTimeDisplay[base.Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.magicDamage *= 1.11f;
            player.meleeDamage *= 1.11f;
            player.rangedDamage *= 1.11f;
            player.minionDamage *= 1.11f;
            player.thrownDamage *= 1.11f;
        }
	}
}
