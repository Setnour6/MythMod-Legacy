using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class 酒香III : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("酒香III");
            base.Description.SetDefault("好酒,好酒\n提升11%暴击");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
            Main.buffNoTimeDisplay[base.Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetCritChance(DamageClass.Magic) += 11;
            player.GetCritChance(DamageClass.Generic) += 11;
            player.GetCritChance(DamageClass.Ranged) += 11;
            player.GetCritChance(DamageClass.Throwing) += 11;
        }
	}
}
