using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class Screwdriver : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("螺丝刀鸡尾酒");
            base.Description.SetDefault("伤害增加20%,防御减少20");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().Screwdriver = true;
        }
	}
}
