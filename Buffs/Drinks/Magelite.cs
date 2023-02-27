using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class Magelite : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("玛格丽特");
            base.Description.SetDefault("闪避增加9%");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().Magelite = true;
        }
	}
}
