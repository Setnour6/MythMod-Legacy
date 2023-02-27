using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class ShieldPotion : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("矿物精华形成的保护层环绕着你");
            base.Description.SetDefault("防御力+24");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
		}
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 24;
        }
	}
}
