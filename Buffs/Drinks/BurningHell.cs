using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class BurningHell : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("燃烧地狱");
            base.Description.SetDefault("生命回复增加25,防御减少18");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().BurningHell = true;
        }
	}
}
