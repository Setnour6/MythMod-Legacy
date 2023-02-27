﻿using System;
using MythMod.NPCs;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
	// Token: 0x0200002B RID: 43
    public class Freeze : ModBuff
	{
		// Token: 0x060000F9 RID: 249 RVA: 0x0002EB44 File Offset: 0x0002CD44
		public override void SetDefaults()
		{
			base.DisplayName.SetDefault("Freeze");
			base.Description.SetDefault("冻结");
			Main.debuff[base.Type] = true;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
			this.longerExpertDebuff = false;
			base.DisplayName.AddTranslation(GameCulture.Chinese, "冻结");
			base.Description.AddTranslation(GameCulture.Chinese, "冻结");
		}
	}
}
