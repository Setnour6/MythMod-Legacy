using System;
using MythMod.NPCs;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class Break : ModBuff
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Break");
			base.Description.SetDefault("防御大幅下降");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
			this.longerExpertDebuff/* tModPorter Note: Removed. Use BuffID.Sets.LongerExpertDebuff instead */ = false;
			base.DisplayName.AddTranslation(GameCulture.Chinese, "圣光裂痕");
			base.Description.AddTranslation(GameCulture.Chinese, "防御大幅下降");
		}
        private int[] D = new int[200];
        public override void Update(NPC npc, ref int buffIndex)
        {
            for (int p = 0; p < 200; p++)
            {
                if (Main.npc[p] == npc && D[p] == 0)
                {
                    D[p] = npc.defense;
                    npc.defense = D[p] / 2;
                }
                if (!Main.npc[p].HasBuff(Mod.Find<ModBuff>("Break").Type) && D[p] != 0)
                {
                    npc.defense = D[p];
                    D[p] = 0;
                }
            }
		}
	}
}
