using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class CubaLibre : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("自由古巴");
            base.Description.SetDefault("移动速度增加7%");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().CubaLibre = true;
        }
	}
}
