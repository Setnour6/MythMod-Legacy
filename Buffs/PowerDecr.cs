using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class PowerDecr : ModBuff
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("力量丧失");
            // base.Description.SetDefault("攻击力丧失");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().PowerDecr2 = true;
        }
	}
}
