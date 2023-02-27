using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class DaturaImpression : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("曼陀罗印象");
            base.Description.SetDefault("闪避率增加6%");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().DaturaImpression = true;
        }
	}
}
