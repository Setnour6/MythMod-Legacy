using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class TrafficLight : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("红绿灯");
            base.Description.SetDefault("减少7防御,增加8%攻击,增加6%闪避");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().SouthAmMitNight = true;
        }
	}
}
