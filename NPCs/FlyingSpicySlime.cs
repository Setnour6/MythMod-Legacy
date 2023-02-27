using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs
{
    public class FlyingSpicySlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("飞行尖刺史莱姆");
			Main.npcFrameCount[base.npc.type] = 4;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "飞行尖刺史莱姆");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.npc.aiStyle = 14;
			base.npc.damage = 20;
			base.npc.width = 40;
			base.npc.height = 30;
			base.npc.defense = 5;
			base.npc.lifeMax = 23;
			base.npc.knockBackResist = 0.8f;
			this.animationType = 121;
			base.npc.alpha = 75;
			base.npc.lavaImmune = false;
			base.npc.noGravity = false;
			base.npc.noTileCollide = false;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
			base.npc.buffImmune[24] = true;
		}
        private int numk = 0;
		public override void AI()
		{
            npc.localAI[0] += 1;
            if(npc.localAI[0] % 120 == 0)
            {        
                for (int i = 0; i < 8; i++)
                {
                    Vector2 v = new Vector2(0, Main.rand.Next(0, 900)).RotatedByRandom(Math.PI * 2) * 0.01f;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, v.X, v.Y,605, 12, 0f, 255, 0f, 0f);
                }
            }
		}
		public override bool PreNPCLoot()
		{
			return false;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (Main.netMode != 1 && base.npc.life <= 0)
			{
				Vector2 vector = base.npc.Center + new Vector2(0f, (float)base.npc.height / 2f);
				NPC.NewNPC((int)vector.X, (int)vector.Y, 535, 0, 0f, 0f, 0f, 0f, 255);
			}
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 4, (float)hitDirection, -1f, 0, default(Color), 1f);
			}
		}
	}
}
