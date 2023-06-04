using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.LanternMoon
{
    public class AppleSlime1 : ModNPC
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("青苹果糖史莱姆");
			Main.npcFrameCount[base.NPC.type] = 4;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "青苹果糖史莱姆");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.NPC.aiStyle = 14;
			base.NPC.damage = 90;
			base.NPC.width = 40;
			base.NPC.height = 30;
			base.NPC.defense = 5;
			base.NPC.lifeMax = 400;
			base.NPC.knockBackResist = 0.8f;
			this.AnimationType = 121;
			base.NPC.alpha = 0;
			base.NPC.lavaImmune = false;
			base.NPC.noGravity = false;
            base.NPC.noTileCollide = true;
            base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
			base.NPC.buffImmune[24] = true;
		}
		public override void AI()
		{
			float num = 1.0025f;
			NPC npc = base.NPC;
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
		}
		public override bool PreKill()
		{
			return false;
		}
		public override void HitEffect(NPC.HitInfo hit)
		{
			if (Main.netMode != 1 && base.NPC.life <= 0)
			{
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/糖史莱姆碎块"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/糖史莱姆碎块"), 1f);
                Vector2 vector = base.NPC.Center + new Vector2(0f, (float)base.NPC.height / 2f);
				NPC.NewNPC((int)vector.X, (int)vector.Y, Mod.Find<ModNPC>("AppleSlime").Type, 0, 0f, 0f, 0f, 0f, 255);
			}
		}
	}
}
