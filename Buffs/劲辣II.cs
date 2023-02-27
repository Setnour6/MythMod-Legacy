using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class 劲辣II : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("劲辣II");
            base.Description.SetDefault("附近有辣椒的味道,这味儿对,辣!\n提升7%伤害");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
            Main.buffNoTimeDisplay[base.Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.magicDamage *= 1.07f;
            player.meleeDamage *= 1.07f;
            player.rangedDamage *= 1.07f;
            player.minionDamage *= 1.07f;
            player.thrownDamage *= 1.07f;
        }
	}
}
