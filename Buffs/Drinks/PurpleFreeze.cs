using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class PurpleFreeze : ModBuff
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("紫气东来");
            // base.Description.SetDefault("暴击增加12%");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().PurpleFreeze = true;
        }
	}
}
