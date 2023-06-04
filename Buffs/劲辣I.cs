using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class 劲辣I : ModBuff
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("劲辣I");
            // base.Description.SetDefault("附近有辣椒的味道,这味儿对,辣!\n提升3%伤害");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
            Main.buffNoTimeDisplay[base.Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Magic) *= 1.03f;
            player.GetDamage(DamageClass.Melee) *= 1.03f;
            player.GetDamage(DamageClass.Ranged) *= 1.03f;
            player.GetDamage(DamageClass.Summon) *= 1.03f;
            player.GetDamage(DamageClass.Throwing) *= 1.03f;
        }
	}
}
