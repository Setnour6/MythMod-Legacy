using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class WithOutBerry : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("莓你不行");
            base.Description.SetDefault("增加9%攻击,增加1生命回复");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().WithOutBerry = true;
        }
	}
}
