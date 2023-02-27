using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class B25 : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("B25轰炸机");
            base.Description.SetDefault("攻击力增加19%");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().B25 = true;
        }
	}
}
