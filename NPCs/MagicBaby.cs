using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;

namespace MythMod.NPCs
{
	// Token: 0x02000487 RID: 1159
    public class MagicBaby : ModNPC
	{
		// Token: 0x06001808 RID: 6152 RVA: 0x00009BEC File Offset: 0x00007DEC
		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("巫毒娃娃");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "巫毒娃娃");
        }
        public override void SetDefaults()
		{
			base.NPC.damage = 0;
			base.NPC.width = 28;
			base.NPC.height = 44;
			base.NPC.defense = 0;
			base.NPC.lifeMax = (Main.expertMode ? 100000 : 100000);
			if(MythWorld.Myth)
			{
				base.NPC.lifeMax = 50000;
			}
			base.NPC.knockBackResist = 0f;
            base.NPC.color = new Color(0, 0, 0, 0);
			base.NPC.aiStyle = -1;
			this.AIType = -1;
			base.NPC.lavaImmune = false;
			base.NPC.noGravity = false;
			base.NPC.noTileCollide = false;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
		}
        public override void AI()
        {
            NPC.ai[0] -= 1;
            if(NPC.ai[0] < 60)
            {
                NPC.alpha = (int)(255 * (60 - NPC.ai[0]) / 60f);
                if (NPC.ai[0] <= 0)
                {
                    NPC.active = false;
                }
            }
            else
            {
                NPC.alpha = 0;
            }
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].HasBuff(Mod.Find<ModBuff>("BIAOJI").Type))
                {
                    Main.npc[i].AddBuff(NPC.buffType[0], 2, false);
                    Main.npc[i].AddBuff(NPC.buffType[1], 2, false);
                    Main.npc[i].AddBuff(NPC.buffType[2], 2, false);
                    Main.npc[i].AddBuff(NPC.buffType[3], 2, false);
                    Main.npc[i].AddBuff(NPC.buffType[4], 2, false);
                }
            }
		}
        public override void HitEffect(NPC.HitInfo hit)
        {
            for (int i = 0; i < 200; i++)
            {
                if(Main.npc[i].HasBuff(Mod.Find<ModBuff>("BIAOJI").Type))
                {
                    Main.npc[i].StrikeNPC((int)damage,0,hitDirection,false,false,false);
                }
            }
        }
    }
}
