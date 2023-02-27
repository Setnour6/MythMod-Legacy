using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class Lavender : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("薰衣草菲仕");
            base.Description.SetDefault("攻击力增加11%,闪避增加9%");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().Lavender = true;
        }
	}
}
