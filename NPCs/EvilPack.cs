using System;
using Microsoft.Xna.Framework;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
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
    public class EvilPack : ModNPC
	{
		// Token: 0x06001808 RID: 6152 RVA: 0x00009BEC File Offset: 0x00007DEC
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("魔茧");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "魔茧");
		}
		// Token: 0x06001809 RID: 6153 RVA: 0x0010AD00 File Offset: 0x00108F00
		public override void SetDefaults()
		{
			base.npc.damage = 0;
			base.npc.width = 80;
			base.npc.height = 256;
			base.npc.defense = 0;
			base.npc.lifeMax = 600;
			base.npc.knockBackResist = 0f;
			base.npc.value = (float)Item.buyPrice(0, 0, 0, 0);
            base.npc.color = new Color(0, 0, 0, 0);
			base.npc.alpha = 0;
            base.npc.boss = false;
			base.npc.lavaImmune = true;
			base.npc.noGravity = true;
			base.npc.noTileCollide = true;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
			base.npc.aiStyle = -1;
			this.aiType = -1;
		}
        private float omega = 0;
        private float E = 0;
        // Token: 0x06001B19 RID: 6937 RVA: 0x0014B900 File Offset: 0x00149B00
        public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            npc.rotation += omega;
            omega -= npc.rotation * 0.03f;
            omega *= 0.97f;
        }
		public override void HitEffect(int hitDirection, double damage)
		{
			if (base.npc.life <= 0)
			{
                Vector2 vector = new Vector2(base.npc.position.X, base.npc.position.Y);
                NPC.NewNPC((int)vector.X + 40, (int)vector.Y + 256, mod.NPCType("CorruptMoth"), 0, 0f, 1f, 0f, 0f, 255);
                NPC.NewNPC((int)vector.X + 40, (int)vector.Y + 256, mod.NPCType("EvilPackBreak"), 0, 0f, 1f, 0f, 0f, 255);
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(new Vector2(npc.position.X, npc.position.Y + 128), base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/魔茧碎块"), 1f);
            }
            if(Math.Abs(omega) < 0.2f)
            {
                omega -= hitDirection * Main.rand.NextFloat(0.2f) * (float)damage / 100f <= 0.2f * hitDirection ? 0.02f : hitDirection * Main.rand.NextFloat(0.2f) * (float)damage / 1000f;
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (base.npc.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Vector2 value = new Vector2(base.npc.Center.X, base.npc.Center.Y);
            Vector2 vector = new Vector2((float)(Main.npcTexture[base.npc.type].Width / 2), (float)(Main.npcTexture[base.npc.type].Height / Main.npcFrameCount[base.npc.type] / 2));
            Vector2 vector2 = value - Main.screenPosition;
            vector2 -= new Vector2((float)base.mod.GetTexture("NPCs/魔茧Glow").Width, (float)(base.mod.GetTexture("NPCs/魔茧Glow").Height / Main.npcFrameCount[base.npc.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.npc.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.npc.alpha, 297 - base.npc.alpha, 297 - base.npc.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/魔茧Glow"), vector2, new Rectangle?(base.npc.frame), new Color(95, 95, 95, 0), base.npc.rotation, vector, 1f, effects, 0f);
        }
    }
}
