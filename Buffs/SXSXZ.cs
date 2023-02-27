using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
	// Token: 0x02000014 RID: 20
    public class SXSXZ : ModBuff
	{
		// Token: 0x060000B3 RID: 179 RVA: 0x0002DB34 File Offset: 0x0002BD34
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("嗜血水螅杖");
            base.Description.SetDefault("嗜血水螅为你而战");
			Main.buffNoTimeDisplay[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0002DBA8 File Offset: 0x0002BDA8
		public override void Update(Player player, ref int buffIndex)
		{
			MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            if (player.ownedProjectileCounts[base.mod.ProjectileType("嗜血水螅杖")] > 0)
			{
				modPlayer.SXSXZ = true;
			}
			if (!modPlayer.SXSXZ)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
				return;
			}
			player.buffTime[buffIndex] = 18000;
		}
	}
}
