using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.ModLoader;

namespace MythMod.NPCs
{
	// Token: 0x02000487 RID: 1159
    public class EvilPackBreak : ModNPC
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
			base.npc.lifeMax = 1;
			base.npc.knockBackResist = 0f;
			base.npc.value = (float)Item.buyPrice(0, 0, 0, 0);
            base.npc.color = new Color(0, 0, 0, 0);
			base.npc.alpha = 0;
            base.npc.boss = false;
			base.npc.lavaImmune = true;
			base.npc.noGravity = true;
			base.npc.noTileCollide = false;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
			base.npc.aiStyle = -1;
			this.aiType = -1;
			base.npc.dontTakeDamage = true;
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
            vector2 -= new Vector2((float)base.mod.GetTexture("NPCs/魔茧破开Glow").Width, (float)(base.mod.GetTexture("NPCs/魔茧破开Glow").Height / Main.npcFrameCount[base.npc.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.npc.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.npc.alpha, 297 - base.npc.alpha, 297 - base.npc.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/魔茧破开Glow"), vector2, new Rectangle?(base.npc.frame), new Color(95,95,95,0), base.npc.rotation, vector, 1f, effects, 0f);
        }
    }
}
