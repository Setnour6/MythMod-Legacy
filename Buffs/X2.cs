using System;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
	// Token: 0x02000014 RID: 20
    public class X2 : ModBuff
	{
		// Token: 0x060000B3 RID: 179 RVA: 0x0002DB34 File Offset: 0x0002BD34
		public override void SetDefaults()
		{
            base.DisplayName.SetDefault("得分双倍");
            base.Description.SetDefault("");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = false;
			Main.buffNoSave[base.Type] = true;
			this.longerExpertDebuff = false;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0002DBA8 File Offset: 0x0002BDA8
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MythPlayer>().X2 = true;
        }
	}
}
