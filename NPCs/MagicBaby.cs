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
			base.DisplayName.SetDefault("巫毒娃娃");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "巫毒娃娃");
        }
        public override void SetDefaults()
		{
			base.npc.damage = 0;
			base.npc.width = 28;
			base.npc.height = 44;
			base.npc.defense = 0;
			base.npc.lifeMax = (Main.expertMode ? 100000 : 100000);
			if(MythWorld.Myth)
			{
				base.npc.lifeMax = 50000;
			}
			base.npc.knockBackResist = 0f;
            base.npc.color = new Color(0, 0, 0, 0);
			base.npc.aiStyle = -1;
			this.aiType = -1;
			base.npc.lavaImmune = false;
			base.npc.noGravity = false;
			base.npc.noTileCollide = false;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
		}
        public override void AI()
        {
            npc.ai[0] -= 1;
            if(npc.ai[0] < 60)
            {
                npc.alpha = (int)(255 * (60 - npc.ai[0]) / 60f);
                if (npc.ai[0] <= 0)
                {
                    npc.active = false;
                }
            }
            else
            {
                npc.alpha = 0;
            }
            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].HasBuff(mod.BuffType("BIAOJI")))
                {
                    Main.npc[i].AddBuff(npc.buffType[0], 2, false);
                    Main.npc[i].AddBuff(npc.buffType[1], 2, false);
                    Main.npc[i].AddBuff(npc.buffType[2], 2, false);
                    Main.npc[i].AddBuff(npc.buffType[3], 2, false);
                    Main.npc[i].AddBuff(npc.buffType[4], 2, false);
                }
            }
		}
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 200; i++)
            {
                if(Main.npc[i].HasBuff(mod.BuffType("BIAOJI")))
                {
                    Main.npc[i].StrikeNPC((int)damage,0,hitDirection,false,false,false);
                }
            }
        }
    }
}
