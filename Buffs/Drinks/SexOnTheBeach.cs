using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class SexOnTheBeach : ModBuff
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("激情海岸");
            // base.Description.SetDefault("伤害增加8%");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().SexOnTheBeach = true;
        }
	}
}
