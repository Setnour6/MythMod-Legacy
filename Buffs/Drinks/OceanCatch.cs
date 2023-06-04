using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class OceanCatch : ModBuff
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("海底捞");
            // base.Description.SetDefault("防御增加14");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().OceanCatch = true;
        }
	}
}
