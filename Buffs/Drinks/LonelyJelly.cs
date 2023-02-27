using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class LonelyJelly : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("孤独的水母");
            base.Description.SetDefault("生命回复增加5");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().LonelyJelly = true;
        }
	}
}
