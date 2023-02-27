using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class FirstLove : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("初恋");
            base.Description.SetDefault("暴击率增加8%");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().FirstLove = true;
        }
	}
}
