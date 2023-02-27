using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class Mexican : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("墨西哥人");
            base.Description.SetDefault("防御增加10");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().Mexican = true;
        }
	}
}
