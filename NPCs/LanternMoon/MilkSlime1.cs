using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.LanternMoon
{
    public class MilkSlime1 : ModNPC
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("奶糖史莱姆");
			Main.npcFrameCount[base.npc.type] = 4;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "奶糖史莱姆");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.npc.aiStyle = 14;
			base.npc.damage = 90;
			base.npc.width = 40;
			base.npc.height = 30;
			base.npc.defense = 5;
			base.npc.lifeMax = 400;
			base.npc.knockBackResist = 0.8f;
			this.animationType = 121;
			base.npc.alpha = 0;
			base.npc.lavaImmune = false;
			base.npc.noGravity = false;
            base.npc.noTileCollide = true;
            base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
			base.npc.buffImmune[24] = true;
		}
		public override void AI()
		{
			float num = 1.0025f;
			NPC npc = base.npc;
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
		}
		public override bool PreNPCLoot()
		{
			return false;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (Main.netMode != 1 && base.npc.life <= 0)
			{
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/糖史莱姆碎块"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/糖史莱姆碎块"), 1f);
                Vector2 vector = base.npc.Center + new Vector2(0f, (float)base.npc.height / 2f);
				NPC.NewNPC((int)vector.X, (int)vector.Y, mod.NPCType("MilkSlime"), 0, 0f, 0f, 0f, 0f, 255);
			}
		}
	}
}
