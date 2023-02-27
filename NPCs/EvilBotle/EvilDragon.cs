using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.EvilBotle
{
    public class EvilDragon : ModNPC
	{
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("古咒飞龙");
            Main.npcFrameCount[base.NPC.type] = 5;
        }
		public override void SetDefaults()
		{
			base.NPC.aiStyle = 14;
			base.NPC.damage = 40;
			base.NPC.width = 40;
			base.NPC.height = 30;
			base.NPC.defense = 5;
			base.NPC.lifeMax = 230;
			base.NPC.knockBackResist = 0.8f;
			this.AnimationType = 121;
			base.NPC.alpha = 75;
			base.NPC.lavaImmune = false;
			base.NPC.noGravity = false;
			base.NPC.noTileCollide = false;
			//base.npc.HitSound = SoundID.NPCHit1;
			//base.npc.DeathSound = SoundID.NPCDeath1;
            NPC.value = 2000;
            base.NPC.buffImmune[24] = true;
		}
        private int numk = 0;
		public override void AI()
		{
            NPC npc = base.NPC;
            float num = 1.0025f;
			NPC npc2 = base.NPC;
			if(Math.Abs(npc.velocity.X) <= 1.5f)
			{
				npc.velocity.X = npc.velocity.X * num;
			}
			else
			{
                npc.velocity.X = npc.velocity.X / num;
			}
			if(Math.Abs(npc2.velocity.Y) <= 1.5f)
			{
				npc2.velocity.Y = npc.velocity.Y * num;
			}
			else
			{
                npc2.velocity.Y = npc2.velocity.Y / num;
			}
            npc.localAI[0] += 1;
		}
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, base.NPC.alpha));
        }
        public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 25; i++)
			{
				Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 27, (float)hitDirection, -1f, 0, default(Color), 2f);
			}
		}
	}
}
