using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class BayBerryBubble : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("杨梅吐气");
            base.Description.SetDefault("攻击力增加13%");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().BayBerryBubble = true;
        }
	}
}
