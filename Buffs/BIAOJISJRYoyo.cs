using System;
using MythMod.NPCs;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class BIAOJISJRYoyo : ModBuff
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("BIAOJISJRYoyo");
			base.Description.SetDefault("");
			Main.debuff[base.Type] = true;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
			this.longerExpertDebuff/* tModPorter Note: Removed. Use BuffID.Sets.LongerExpertDebuff instead */ = false;
			base.DisplayName.AddTranslation(GameCulture.Chinese, "标记");
			base.Description.AddTranslation(GameCulture.Chinese, "");
		}
	}
}
