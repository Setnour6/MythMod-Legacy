using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class StrawberryMojituo : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("草莓莫吉托");
            base.Description.SetDefault("生命回复增加7");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().StrawberryMojituo = true;
        }
	}
}
