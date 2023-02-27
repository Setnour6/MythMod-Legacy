using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class PinkLady : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("红粉佳人");
            base.Description.SetDefault("闪避增加5%,暴击增加10%");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().PinkLady = true;
        }
	}
}
