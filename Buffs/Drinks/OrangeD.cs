using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class OrangeD : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("橙汁鸡尾酒");
            base.Description.SetDefault("防御增加5,伤害增加5%");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().OrangeD = true;
        }
	}
}
