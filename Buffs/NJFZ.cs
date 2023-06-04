using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class NJFZ : ModBuff
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("蜜桔");
            // base.Description.SetDefault("蜜桔为你而战");
			Main.buffNoTimeDisplay[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
		}
		public override void Update(Player player, ref int buffIndex)
		{
			MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            if (player.ownedProjectileCounts[base.Mod.Find<ModProjectile>("桔子Zh").Type] > 0)
			{
				modPlayer.NJFZ = true;
			}
			if (!modPlayer.NJFZ)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
				return;
			}
			player.buffTime[buffIndex] = 18000;
		}
	}
}
