using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class PowerIncr : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("力量暴增");
            base.Description.SetDefault("攻击力暴增");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().PowerIncr2 = true;
        }
	}
}
