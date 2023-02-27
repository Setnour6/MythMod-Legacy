using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class SeaFlower : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("花与海");
            base.Description.SetDefault("伤害增加7%");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().SeaFlower = true;
        }
	}
}
