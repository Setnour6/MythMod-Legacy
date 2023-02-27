using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class SunsetGlow : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("落日霞光");
            base.Description.SetDefault("魔法回复增加5");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().SunsetGlow = true;
        }
	}
}
