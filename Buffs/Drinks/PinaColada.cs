using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class PinaColada : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("椰林飘香");
            base.Description.SetDefault("防御增加9,闪避增加4%");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().PinaColada = true;
        }
	}
}
