using System;
using MythMod.NPCs;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Buffs
{
    public class Immue : ModBuff
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Immue");
			base.Description.SetDefault("防御力提升很多很多");
			Main.debuff[base.Type] = false;
			Main.pvpBuff[base.Type] = true;
			Main.buffNoSave[base.Type] = true;
			this.longerExpertDebuff/* tModPorter Note: Removed. Use BuffID.Sets.LongerExpertDebuff instead */ = false;
			base.DisplayName.AddTranslation(GameCulture.Chinese, "免伤");
			base.Description.AddTranslation(GameCulture.Chinese, "防御力提升很多很多");
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
            npc.defense += 1000 ;
            npc.defDefense += 100;

        }
	}
}
