﻿using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class ExPoi : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("ExPoi");
            base.Description.SetDefault("撕心裂肺的刺痛");
			Main.debuff[base.Type] = true;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
			this.longerExpertDebuff = true;
		}
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MythPlayer>().ExPoi = true;
        }
	}
}
