using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class SingaporeSling : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("新加坡司令");
            base.Description.SetDefault("生命回复增加6");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().SingaporeSling = true;
        }
	}
}
