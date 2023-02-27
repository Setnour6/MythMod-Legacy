using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class PurpleCrystal : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("紫水晶");
            base.Description.SetDefault("闪避增加10%");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().PurpleCrystal = true;
        }
	}
}
