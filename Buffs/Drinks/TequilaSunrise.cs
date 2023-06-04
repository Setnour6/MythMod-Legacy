using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class TequilaSunrise : ModBuff
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("特基拉日出");
            // base.Description.SetDefault("魔法回复增加6");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().TequilaSunrise = true;
        }
	}
}
