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
    public class DiscleanEgg : ModNPC
	{
		// Token: 0x06001808 RID: 6152 RVA: 0x00009BEC File Offset: 0x00007DEC
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("不洁之卵");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "不洁之卵");
		}
		// Token: 0x06001809 RID: 6153 RVA: 0x0010AD00 File Offset: 0x00108F00
		public override void SetDefaults()
		{
			base.npc.damage = 50;
			base.npc.width = 58;
			base.npc.height = 58;
			base.npc.defense = 0;
			base.npc.lifeMax = 100;
			if(MythWorld.Myth)
			{
				base.npc.lifeMax = 150;
			}
			base.npc.knockBackResist = 0.7f;
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
        private float omega = 0;
		// Token: 0x06001B19 RID: 6937 RVA: 0x0014B900 File Offset: 0x00149B00
		public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            if(omega == 0)
            {
                omega = Main.rand.NextFloat((float)(Math.PI * 2));
                npc.velocity.X = player.velocity.X;
            }
            if(npc.Center.Y < player.Center.Y - 150)
            {
                base.npc.noTileCollide = true;
                base.npc.knockBackResist = 0f;
            }
            else
            {
                base.npc.noTileCollide = false;
                base.npc.knockBackResist = 0.7f;
            }
            npc.rotation += omega * npc.velocity.Length() * 0.01f;
			Vector2 vector = new Vector2(base.npc.Center.X, base.npc.Center.Y);
            if ((player.Center - npc.Center).Length() <= 500f)
            {
                base.npc.localAI[0] += 1;
            }
			if(base.npc.localAI[0] >= 450)
			{
                NPC.NewNPC((int)vector.X, (int)vector.Y, 489, 0, 0f, 1f, 0f, 0f, 255);
                NPC.NewNPC((int)vector.X - 10, (int)vector.Y, 489, 0, 1f, 0f, 0f, 0f, 255);
                NPC.NewNPC((int)vector.X + 10, (int)vector.Y, 490, 0, 0f, 1f, 0f, 0f, 255);
                base.npc.life = 0;
			    base.npc.position.X = base.npc.position.X + (float)(base.npc.width / 2);
                base.npc.position.Y = base.npc.position.Y + (float)(base.npc.height / 2);
                base.npc.position.X = base.npc.position.X - (float)(base.npc.width / 2);
                base.npc.position.Y = base.npc.position.Y - (float)(base.npc.height / 2);
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/血卵碎块1"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/血卵碎块2"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/血卵碎块3"), 1f);
			}
		}
		public override void HitEffect(int hitDirection, double damage)
		{
			if (base.npc.life <= 0)
			{
                Vector2 vector = new Vector2(base.npc.Center.X, base.npc.Center.Y);
                NPC.NewNPC((int)vector.X, (int)vector.Y, 489, 0, 0f, 1f, 0f, 0f, 255);
                NPC.NewNPC((int)vector.X - 10, (int)vector.Y, 489, 0, 1f, 0f, 0f, 0f, 255);
                NPC.NewNPC((int)vector.X + 10, (int)vector.Y, 490, 0, 0f, 1f, 0f, 0f, 255);
                base.npc.position.X = base.npc.position.X + (float)(base.npc.width / 2);
                base.npc.position.Y = base.npc.position.Y + (float)(base.npc.height / 2);
                base.npc.position.X = base.npc.position.X - (float)(base.npc.width / 2);
                base.npc.position.Y = base.npc.position.Y - (float)(base.npc.height / 2);
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/血卵碎块1"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/血卵碎块2"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/血卵碎块3"), 1f);
            }
		}
	}
}
