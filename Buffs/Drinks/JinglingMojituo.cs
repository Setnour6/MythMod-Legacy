using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs.Drinks
{
    public class JinglingMojituo : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("精灵莫吉托");
            base.Description.SetDefault("攻击力增加7%,暴击率增加3%,闪避增加2%");
			Main.buffNoTimeDisplay[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
            player.GetModPlayer<MythPlayer>().JinglingFeishi = true;
        }
	}
}
