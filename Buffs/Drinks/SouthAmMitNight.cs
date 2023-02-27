using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class SouthAmMitNight : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("南美不眠夜");
            base.Description.SetDefault("移速增加10%,增大飞行时间");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().SouthAmMitNight = true;
        }
	}
}
