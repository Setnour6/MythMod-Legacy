using System;
using Microsoft.Xna.Framework;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
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
			// base.DisplayName.SetDefault("魔茧");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "魔茧");
		}
		// Token: 0x06001809 RID: 6153 RVA: 0x0010AD00 File Offset: 0x00108F00
		public override void SetDefaults()
		{
			base.NPC.damage = 0;
			base.NPC.width = 80;
			base.NPC.height = 256;
			base.NPC.defense = 0;
			base.NPC.lifeMax = 600;
			base.NPC.knockBackResist = 0f;
			base.NPC.value = (float)Item.buyPrice(0, 0, 0, 0);
            base.NPC.color = new Color(0, 0, 0, 0);
			base.NPC.alpha = 0;
            base.NPC.boss = false;
			base.NPC.lavaImmune = true;
			base.NPC.noGravity = true;
			base.NPC.noTileCollide = true;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
			base.NPC.aiStyle = -1;
			this.AIType = -1;
		}
        private float omega = 0;
        private float E = 0;
        // Token: 0x06001B19 RID: 6937 RVA: 0x0014B900 File Offset: 0x00149B00
        public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            NPC.rotation += omega;
            omega -= NPC.rotation * 0.03f;
            omega *= 0.97f;
        }
		public override void HitEffect(NPC.HitInfo hit)
		{
			if (base.NPC.life <= 0)
			{
                Vector2 vector = new Vector2(base.NPC.position.X, base.NPC.position.Y);
                NPC.NewNPC((int)vector.X + 40, (int)vector.Y + 256, Mod.Find<ModNPC>("CorruptMoth").Type, 0, 0f, 1f, 0f, 0f, 255);
                NPC.NewNPC((int)vector.X + 40, (int)vector.Y + 256, Mod.Find<ModNPC>("EvilPackBreak").Type, 0, 0f, 1f, 0f, 0f, 255);
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(new Vector2(NPC.position.X, NPC.position.Y + 128), base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/魔茧碎块"), 1f);
            }
            if(Math.Abs(omega) < 0.2f)
            {
                omega -= hitDirection * Main.rand.NextFloat(0.2f) * (float)damage / 100f <= 0.2f * hitDirection ? 0.02f : hitDirection * Main.rand.NextFloat(0.2f) * (float)damage / 1000f;
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (base.NPC.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Vector2 value = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
            Vector2 vector = new Vector2((float)(TextureAssets.Npc[base.NPC.type].Value.Width / 2), (float)(TextureAssets.Npc[base.NPC.type].Value.Height / Main.npcFrameCount[base.NPC.type] / 2));
            Vector2 vector2 = value - Main.screenPosition;
            vector2 -= new Vector2((float)base.Mod.GetTexture("NPCs/魔茧Glow").Width, (float)(base.Mod.GetTexture("NPCs/魔茧Glow").Height / Main.npcFrameCount[base.NPC.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.NPC.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.NPC.alpha, 297 - base.NPC.alpha, 297 - base.NPC.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/魔茧Glow"), vector2, new Rectangle?(base.NPC.frame), new Color(95, 95, 95, 0), base.NPC.rotation, vector, 1f, effects, 0f);
        }
    }
}
