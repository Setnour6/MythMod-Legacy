using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class 热乎乎的美味I : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("热乎乎的美味I");
            base.Description.SetDefault("附近有新出炉的东西,让你状态良好\n提升生命回复速度");
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
