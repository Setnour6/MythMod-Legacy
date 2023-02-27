using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class MoonTonight : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("今晚的月亮");
            base.Description.SetDefault("魔法回复增加8");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().MoonTonight = true;
        }
	}
}
