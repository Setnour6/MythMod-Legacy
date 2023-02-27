using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class YoghurtCaribbean : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("酸奶加勒比");
            base.Description.SetDefault("增加10%攻击");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().YoghurtCaribbean = true;
        }
	}
}
