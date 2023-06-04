using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class Boluolita : ModBuff
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("菠萝丽塔");
            // base.Description.SetDefault("生命回复增加3,魔法回复增加4");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().Boluolita = true;
        }
	}
}
