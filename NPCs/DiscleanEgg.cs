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
			// base.DisplayName.SetDefault("不洁之卵");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "不洁之卵");
		}
		// Token: 0x06001809 RID: 6153 RVA: 0x0010AD00 File Offset: 0x00108F00
		public override void SetDefaults()
		{
			base.NPC.damage = 50;
			base.NPC.width = 58;
			base.NPC.height = 58;
			base.NPC.defense = 0;
			base.NPC.lifeMax = 100;
			if(MythWorld.Myth)
			{
				base.NPC.lifeMax = 150;
			}
			base.NPC.knockBackResist = 0.7f;
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
        private float omega = 0;
		// Token: 0x06001B19 RID: 6937 RVA: 0x0014B900 File Offset: 0x00149B00
		public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            if(omega == 0)
            {
                omega = Main.rand.NextFloat((float)(Math.PI * 2));
                NPC.velocity.X = player.velocity.X;
            }
            if(NPC.Center.Y < player.Center.Y - 150)
            {
                base.NPC.noTileCollide = true;
                base.NPC.knockBackResist = 0f;
            }
            else
            {
                base.NPC.noTileCollide = false;
                base.NPC.knockBackResist = 0.7f;
            }
            NPC.rotation += omega * NPC.velocity.Length() * 0.01f;
			Vector2 vector = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
            if ((player.Center - NPC.Center).Length() <= 500f)
            {
                base.NPC.localAI[0] += 1;
            }
			if(base.NPC.localAI[0] >= 450)
			{
                NPC.NewNPC((int)vector.X, (int)vector.Y, 489, 0, 0f, 1f, 0f, 0f, 255);
                NPC.NewNPC((int)vector.X - 10, (int)vector.Y, 489, 0, 1f, 0f, 0f, 0f, 255);
                NPC.NewNPC((int)vector.X + 10, (int)vector.Y, 490, 0, 0f, 1f, 0f, 0f, 255);
                base.NPC.life = 0;
			    base.NPC.position.X = base.NPC.position.X + (float)(base.NPC.width / 2);
                base.NPC.position.Y = base.NPC.position.Y + (float)(base.NPC.height / 2);
                base.NPC.position.X = base.NPC.position.X - (float)(base.NPC.width / 2);
                base.NPC.position.Y = base.NPC.position.Y - (float)(base.NPC.height / 2);
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/血卵碎块1"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/血卵碎块2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/血卵碎块3"), 1f);
			}
		}
		public override void HitEffect(NPC.HitInfo hit)
		{
			if (base.NPC.life <= 0)
			{
                Vector2 vector = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
                NPC.NewNPC((int)vector.X, (int)vector.Y, 489, 0, 0f, 1f, 0f, 0f, 255);
                NPC.NewNPC((int)vector.X - 10, (int)vector.Y, 489, 0, 1f, 0f, 0f, 0f, 255);
                NPC.NewNPC((int)vector.X + 10, (int)vector.Y, 490, 0, 0f, 1f, 0f, 0f, 255);
                base.NPC.position.X = base.NPC.position.X + (float)(base.NPC.width / 2);
                base.NPC.position.Y = base.NPC.position.Y + (float)(base.NPC.height / 2);
                base.NPC.position.X = base.NPC.position.X - (float)(base.NPC.width / 2);
                base.NPC.position.Y = base.NPC.position.Y - (float)(base.NPC.height / 2);
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/血卵碎块1"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/血卵碎块2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/血卵碎块3"), 1f);
            }
		}
	}
}
