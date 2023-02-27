using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class GreenHat : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("小绿帽");
            base.Description.SetDefault("攻击力增加6%,暴击率增加4%");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().GreenHat = true;
        }
	}
}
