using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
	// Token: 0x02000014 RID: 20
    public class 高级护体神盾 : ModBuff
	{
		// Token: 0x060000B3 RID: 179 RVA: 0x0002DB34 File Offset: 0x0002BD34
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("高级护体神盾");
            // base.Description.SetDefault("你铜皮铁骨");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0002DBA8 File Offset: 0x0002BDA8
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 110;
        }
	}
}
