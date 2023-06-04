using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class GoldBird : ModBuff
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("金乌");
            // base.Description.SetDefault("金乌为你而战");
			Main.buffNoTimeDisplay[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
			MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            if (player.ownedProjectileCounts[base.Mod.Find<ModProjectile>("GoldBird").Type] > 0)
			{
				modPlayer.GXJL = true;
			}
			if (!modPlayer.GXJL)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
				return;
			}
			player.buffTime[buffIndex] = 18000;
		}
	}
}
