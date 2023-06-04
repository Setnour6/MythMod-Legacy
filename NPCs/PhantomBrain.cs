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
            // base.DisplayName.SetDefault("克苏鲁之脑");
			Main.npcFrameCount[base.NPC.type] = 4;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "克苏鲁之脑");
		}
        private bool A2 = true;
		private int num4;	
		public override void SetDefaults()
		{
			base.NPC.damage = 0;
			base.NPC.width = 200;
			base.NPC.height = 182;
			base.NPC.defense = 0;
			base.NPC.lifeMax = 2040;
			base.NPC.knockBackResist = 0.7f;
			base.NPC.alpha = 0;
			base.NPC.lavaImmune = false;
			base.NPC.noGravity = true;
			base.NPC.noTileCollide = true;
		}
		public override void AI()
        {
			Player player = Main.player[base.NPC.target];
            if((player.Center - NPC.Center).Length() >= 100f)
            {
                Vector2 v = (player.Center - NPC.Center) / ((player.Center - NPC.Center).Length() + 0.01f) * 6f;
                NPC.velocity = v;
            }

            if((player.Center - NPC.Center).Length() < 100f)
            {
                NPC.velocity *= 0.98f;
                NPC.alpha += 5;
                if(NPC.alpha >= 255)
                {
                    NPC.position = NPC.position + new Vector2(0, Main.rand.NextFloat(300, 800)).RotatedByRandom(Math.PI * 2);
                    A2 = false;
                }
            }
            if(!A2)
            {
                NPC.alpha -= 5;
                if (NPC.alpha <= 0)
                {
                    NPC.alpha = 0;
                    A2 = true;
                }
            }
            if(NPC.CountNPCS(266) < 1)
            {
                NPC.active = false;
            }
        }
		public override void HitEffect(NPC.HitInfo hit)
		{
            NPC.life = NPC.lifeMax;
		}
        public override void FindFrame(int frameHeight)
        {
            base.NPC.frameCounter += 0.15f;
            base.NPC.frameCounter %= (double)Main.npcFrameCount[base.NPC.type];
            int num = (int)base.NPC.frameCounter;
            base.NPC.frame.Y = num * frameHeight;
        }
    }
}
