﻿using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class 鲜果II : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("鲜果II");
            base.Description.SetDefault("附近有水果,让你状态良好\n提升魔力回复速度");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
            Main.buffNoTimeDisplay[base.Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.manaRegen += 5;
        }
	}
}
