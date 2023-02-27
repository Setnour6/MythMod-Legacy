using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
	// Token: 0x02000014 RID: 20
    public class 秩序之锁 : ModBuff
	{
		// Token: 0x060000B3 RID: 179 RVA: 0x0002DB34 File Offset: 0x0002BD34
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("秩序之锁");
            base.Description.SetDefault("一个不明的强大魔法源,干扰了你所有的传送");
			Main.debuff[base.Type] = true;
			Main.pvpBuff[base.Type] = true;
            Main.buffNoSave[base.Type] = true;
            Main.buffNoTimeDisplay[base.Type] = true;
            this.longerExpertDebuff = false;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0002DBA8 File Offset: 0x0002BDA8
        public override void Update(Player player, ref int buffIndex)
        {
        }
	}
}
