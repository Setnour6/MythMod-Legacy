using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class MagicalPlanit : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("魔幻星球");
            base.Description.SetDefault("伤害增加2%,闪避增加2%,暴击增加2%,生命回复增加2,防御增加4");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().MagicalPlanit = true;
        }
	}
}
