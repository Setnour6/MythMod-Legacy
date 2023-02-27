using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class 酒香II : ModBuff
	{
		public override void SetStaticDefaults()
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
            player.GetCritChance(DamageClass.Magic) += 7;
            player.GetCritChance(DamageClass.Generic) += 7;
            player.GetCritChance(DamageClass.Ranged) += 7;
            player.GetCritChance(DamageClass.Throwing) += 7;
        }
	}
}
