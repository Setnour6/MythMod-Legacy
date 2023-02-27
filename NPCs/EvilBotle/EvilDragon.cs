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
            Main.npcFrameCount[base.npc.type] = 5;
        }
		public override void SetDefaults()
		{
			base.npc.aiStyle = 14;
			base.npc.damage = 40;
			base.npc.width = 40;
			base.npc.height = 30;
			base.npc.defense = 5;
			base.npc.lifeMax = 230;
			base.npc.knockBackResist = 0.8f;
			this.animationType = 121;
			base.npc.alpha = 75;
			base.npc.lavaImmune = false;
			base.npc.noGravity = false;
			base.npc.noTileCollide = false;
			//base.npc.HitSound = SoundID.NPCHit1;
			//base.npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 2000;
            base.npc.buffImmune[24] = true;
		}
        private int numk = 0;
		public override void AI()
		{
            NPC npc = base.npc;
            float num = 1.0025f;
			NPC npc2 = base.npc;
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
            return new Color?(new Color(255, 255, 255, base.npc.alpha));
        }
        public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 25; i++)
			{
				Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 27, (float)hitDirection, -1f, 0, default(Color), 2f);
			}
		}
	}
}
