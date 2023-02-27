using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class IcyAnimal : ModBuff
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("冰晶雪兽");
            base.Description.SetDefault("冰晶雪兽为你而战");
			Main.buffNoTimeDisplay[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            if (player.ownedProjectileCounts[base.Mod.Find<ModProjectile>("IcyAnimal").Type] > 0)
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
