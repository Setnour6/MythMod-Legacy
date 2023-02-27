using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class 甜蜜I : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("甜蜜I");
            base.Description.SetDefault("附近有很甜的东西,让你状态良好\n提升生命回复速度");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
            Main.buffNoTimeDisplay[base.Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 2;
        }
	}
}
