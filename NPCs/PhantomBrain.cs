using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;

namespace MythMod.NPCs
{
    [AutoloadBossHead]
    public class PhantomBrain : ModNPC
	{
		
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("克苏鲁之脑");
			Main.npcFrameCount[base.npc.type] = 4;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "克苏鲁之脑");
		}
        private bool A2 = true;
		private int num4;	
		public override void SetDefaults()
		{
			base.npc.damage = 0;
			base.npc.width = 200;
			base.npc.height = 182;
			base.npc.defense = 0;
			base.npc.lifeMax = 2040;
			base.npc.knockBackResist = 0.7f;
			base.npc.alpha = 0;
			base.npc.lavaImmune = false;
			base.npc.noGravity = true;
			base.npc.noTileCollide = true;
		}
		public override void AI()
        {
			Player player = Main.player[base.npc.target];
            if((player.Center - npc.Center).Length() >= 100f)
            {
                Vector2 v = (player.Center - npc.Center) / ((player.Center - npc.Center).Length() + 0.01f) * 6f;
                npc.velocity = v;
            }

            if((player.Center - npc.Center).Length() < 100f)
            {
                npc.velocity *= 0.98f;
                npc.alpha += 5;
                if(npc.alpha >= 255)
                {
                    npc.position = npc.position + new Vector2(0, Main.rand.NextFloat(300, 800)).RotatedByRandom(Math.PI * 2);
                    A2 = false;
                }
            }
            if(!A2)
            {
                npc.alpha -= 5;
                if (npc.alpha <= 0)
                {
                    npc.alpha = 0;
                    A2 = true;
                }
            }
            if(NPC.CountNPCS(266) < 1)
            {
                npc.active = false;
            }
        }
		public override void HitEffect(int hitDirection, double damage)
		{
            npc.life = npc.lifeMax;
		}
        public override void FindFrame(int frameHeight)
        {
            base.npc.frameCounter += 0.15f;
            base.npc.frameCounter %= (double)Main.npcFrameCount[base.npc.type];
            int num = (int)base.npc.frameCounter;
            base.npc.frame.Y = num * frameHeight;
        }
    }
}
