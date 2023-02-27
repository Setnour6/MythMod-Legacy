using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class BloodyMarie : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("印度玛莎拉");
            base.Description.SetDefault("暴击增加11%");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().BloodyMarie = true;
        }
	}
}
