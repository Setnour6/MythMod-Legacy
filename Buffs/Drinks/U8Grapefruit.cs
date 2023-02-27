using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class U8Grapefruit : ModBuff
	{
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("U8西柚");
            base.Description.SetDefault("增加4%攻击,增加3生命回复");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().U8Grapefruit = true;
        }
	}
}
