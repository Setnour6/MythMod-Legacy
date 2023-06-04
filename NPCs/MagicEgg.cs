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
			// base.DisplayName.SetDefault("魔卵");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "魔卵");
		}
		// Token: 0x06001809 RID: 6153 RVA: 0x0010AD00 File Offset: 0x00108F00
		public override void SetDefaults()
		{
			base.NPC.damage = 0;
			base.NPC.width = 44;
			base.NPC.height = 58;
			base.NPC.defense = 0;
			base.NPC.lifeMax = (Main.expertMode ? 250 : 200);
			if(MythWorld.Myth)
			{
				base.NPC.lifeMax = 150;
			}
			base.NPC.knockBackResist = 0f;
			base.NPC.value = (float)Item.buyPrice(0, 0, 0, 0);
            base.NPC.color = new Color(0, 0, 0, 0);
			base.NPC.alpha = 0;
            base.NPC.boss = false;
			base.NPC.lavaImmune = true;
			base.NPC.noGravity = false;
			base.NPC.noTileCollide = false;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
			base.NPC.aiStyle = -1;
			this.AIType = -1;
		}
		// Token: 0x06001B19 RID: 6937 RVA: 0x0014B900 File Offset: 0x00149B00
		public override void AI()
		{
			Vector2 vector = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
			base.NPC.localAI[0] += 1;
			if(base.NPC.localAI[0] >= 450)
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
				base.NPC.life = 0;
			    base.NPC.position.X = base.NPC.position.X + (float)(base.NPC.width / 2);
                base.NPC.position.Y = base.NPC.position.Y + (float)(base.NPC.height / 2);
                base.NPC.position.X = base.NPC.position.X - (float)(base.NPC.width / 2);
                base.NPC.position.Y = base.NPC.position.Y - (float)(base.NPC.height / 2);
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/魔卵碎块1"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/魔卵碎块2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/魔卵碎块3"), 1f);
			}
		}
		public override void HitEffect(NPC.HitInfo hit)
		{
			if (base.NPC.life <= 0)
			{
			    base.NPC.position.X = base.NPC.position.X + (float)(base.NPC.width / 2);
                base.NPC.position.Y = base.NPC.position.Y + (float)(base.NPC.height / 2);
                base.NPC.position.X = base.NPC.position.X - (float)(base.NPC.width / 2);
                base.NPC.position.Y = base.NPC.position.Y - (float)(base.NPC.height / 2);
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/魔卵碎块1"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/魔卵碎块2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/魔卵碎块3"), 1f);
			}
		}
	}
}
