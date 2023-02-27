using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class JinglingFeishi : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("精灵菲仕");
            base.Description.SetDefault("攻击力增加4%,暴击率增加6%");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().JinglingFeishi = true;
        }
	}
}
