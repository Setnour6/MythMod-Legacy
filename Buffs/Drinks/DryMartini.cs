using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class DryMartini : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("干马天尼");
            base.Description.SetDefault("闪避率增加8%");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().DryMartini = true;
        }
	}
}
