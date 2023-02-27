using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class Missable : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("Missable");
            base.Description.SetDefault("闪避率增加6%");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().Missable = true;
        }
	}
}
