using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class LavaCup : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("熔岩杯子");
            base.Description.SetDefault("多喝岩浆哦");
			Main.buffNoTimeDisplay[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
			player.buffTime[buffIndex] = 18000;
		}
	}
}
