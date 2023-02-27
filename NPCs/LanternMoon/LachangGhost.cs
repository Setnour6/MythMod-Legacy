using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.LanternMoon
{
    public class LachangGhost : ModNPC
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("腊肠妖灵");
			Main.npcFrameCount[base.npc.type] = 1;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "腊肠妖灵");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.npc.aiStyle = 23;
			base.npc.damage = 120;
			base.npc.width = 84;
			base.npc.height = 84;
			base.npc.defense = 5;
			base.npc.lifeMax = 600;
			base.npc.knockBackResist = 0.1f;
			base.npc.lavaImmune = false;
			base.npc.noGravity = false;
			base.npc.noTileCollide = false;
			base.npc.HitSound = SoundID.NPCHit1;
			base.npc.DeathSound = SoundID.NPCDeath1;
			base.npc.buffImmune[24] = true;
            base.npc.value = 7000;
            this.banner = base.npc.type;
            this.bannerItem = base.mod.ItemType("BakenMonsterBanner");
        }
        private int y = 0;
		// Token: 0x06001B19 RID: 6937 RVA: 0x0014B900 File Offset: 0x00149B00
		public override void AI()
        {
            if (Main.dayTime)
            {
                npc.noTileCollide = true;
                npc.velocity.Y += 1;
            }
        }
        public override bool PreNPCLoot()
		{
			return false;
		}
		public override void HitEffect(int hitDirection, double damage)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.npc.life <= 0)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/腊肠妖灵碎块"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/腊肠妖灵碎块"), 1f);
                if (mplayer.LanternMoonWave != 25)
                {
                    if (Main.expertMode)
                    {
                        mplayer.LanternMoonPoint += 20;
                        if (MythWorld.Myth)
                        {
                            mplayer.LanternMoonPoint += 20;
                        }
                    }
                    else
                    {
                        mplayer.LanternMoonPoint += 10;
                    }
                }
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
            vector2 -= new Vector2((float)base.mod.GetTexture("NPCs/LanternMoon/腊肠妖灵Glow").Width, (float)(base.mod.GetTexture("NPCs/LanternMoon/腊肠妖灵Glow").Height / Main.npcFrameCount[base.npc.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.npc.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(97 - base.npc.alpha, 97 - base.npc.alpha, 97 - base.npc.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/LanternMoon/腊肠妖灵Glow"), vector2, new Rectangle?(base.npc.frame), color, base.npc.rotation, vector, 1f, effects, 0f);
        }
    }
}
