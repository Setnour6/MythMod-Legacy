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
    public class MagicEgg : ModNPC
	{
		// Token: 0x06001808 RID: 6152 RVA: 0x00009BEC File Offset: 0x00007DEC
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("魔卵");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "魔卵");
		}
		// Token: 0x06001809 RID: 6153 RVA: 0x0010AD00 File Offset: 0x00108F00
		public override void SetDefaults()
		{
			base.npc.damage = 0;
			base.npc.width = 44;
			base.npc.height = 58;
			base.npc.defense = 0;
			base.npc.lifeMax = (Main.expertMode ? 250 : 200);
			if(MythWorld.Myth)
			{
				base.npc.lifeMax = 150;
			}
			base.npc.knockBackResist = 0f;
			base.npc.value = (float)Item.buyPrice(0, 0, 0, 0);
            base.npc.color = new Color(0, 0, 0, 0);
			base.npc.alpha = 0;
            base.npc.boss = false;
			base.npc.lavaImmune = true;
			base.npc.noGravity = false;
			base.npc.noTileCollide = false;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
			base.npc.aiStyle = -1;
			this.aiType = -1;
		}
		// Token: 0x06001B19 RID: 6937 RVA: 0x0014B900 File Offset: 0x00149B00
		public override void AI()
		{
			Vector2 vector = new Vector2(base.npc.Center.X, base.npc.Center.Y);
			base.npc.localAI[0] += 1;
			if(base.npc.localAI[0] >= 450)
			{
				if(Main.rand.Next(100) <= 85)
				{
					NPC.NewNPC((int)vector.X, (int)vector.Y, 7, 0, 0f, 0f, 0f, 0f, 255);
				}
				else if(NPC.CountNPCS(98) >= 2)
				{
					NPC.NewNPC((int)vector.X, (int)vector.Y, 7, 0, 0f, 0f, 0f, 0f, 255);
				}
				else
				{
					NPC.NewNPC((int)vector.X, (int)vector.Y, 98, 0, 0f, 0f, 0f, 0f, 255);
				}
				base.npc.life = 0;
			    base.npc.position.X = base.npc.position.X + (float)(base.npc.width / 2);
                base.npc.position.Y = base.npc.position.Y + (float)(base.npc.height / 2);
                base.npc.position.X = base.npc.position.X - (float)(base.npc.width / 2);
                base.npc.position.Y = base.npc.position.Y - (float)(base.npc.height / 2);
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/魔卵碎块1"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/魔卵碎块2"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/魔卵碎块3"), 1f);
			}
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (base.npc.life <= 0)
			{
			    base.npc.position.X = base.npc.position.X + (float)(base.npc.width / 2);
                base.npc.position.Y = base.npc.position.Y + (float)(base.npc.height / 2);
                base.npc.position.X = base.npc.position.X - (float)(base.npc.width / 2);
                base.npc.position.Y = base.npc.position.Y - (float)(base.npc.height / 2);
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/魔卵碎块1"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/魔卵碎块2"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/魔卵碎块3"), 1f);
			}
		}
	}
}
