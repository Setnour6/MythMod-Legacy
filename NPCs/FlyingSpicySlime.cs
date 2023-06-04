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
            // base.DisplayName.SetDefault("飞行尖刺史莱姆");
			Main.npcFrameCount[base.NPC.type] = 4;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "飞行尖刺史莱姆");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.NPC.aiStyle = 14;
			base.NPC.damage = 20;
			base.NPC.width = 40;
			base.NPC.height = 30;
			base.NPC.defense = 5;
			base.NPC.lifeMax = 23;
			base.NPC.knockBackResist = 0.8f;
			this.AnimationType = 121;
			base.NPC.alpha = 75;
			base.NPC.lavaImmune = false;
			base.NPC.noGravity = false;
			base.NPC.noTileCollide = false;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
			base.NPC.buffImmune[24] = true;
		}
        private int numk = 0;
		public override void AI()
		{
            NPC.localAI[0] += 1;
            if(NPC.localAI[0] % 120 == 0)
            {        
                for (int i = 0; i < 8; i++)
                {
                    Vector2 v = new Vector2(0, Main.rand.Next(0, 900)).RotatedByRandom(Math.PI * 2) * 0.01f;
                    Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, v.X, v.Y,605, 12, 0f, 255, 0f, 0f);
                }
            }
		}
		public override bool PreKill()
		{
			return false;
		}
		public override void HitEffect(NPC.HitInfo hit)
		{
			if (Main.netMode != 1 && base.NPC.life <= 0)
			{
				Vector2 vector = base.NPC.Center + new Vector2(0f, (float)base.NPC.height / 2f);
				NPC.NewNPC((int)vector.X, (int)vector.Y, 535, 0, 0f, 0f, 0f, 0f, 255);
			}
			for (int i = 0; i < 5; i++)
			{
				Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 4, (float)hitDirection, -1f, 0, default(Color), 1f);
			}
		}
	}
}
