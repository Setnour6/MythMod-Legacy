﻿using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class StarPoi3 : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("星渊毒素");
            base.Description.SetDefault("阳光下,星渊毒素在疯狂的溶解你的身体");
			Main.buffNoTimeDisplay[base.Type] = true;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
			this.longerExpertDebuff = false;
		}
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MythPlayer>().StarPoi3 = true;
        }
	}
}
