using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class SglyBeer : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("桑格利亚");
            base.Description.SetDefault("伤害增加9%");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().SglyBeer = true;
        }
	}
}
