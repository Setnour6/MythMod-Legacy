using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.LanternMoon
{
    public class LachangGhost : ModNPC
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("腊肠妖灵");
			Main.npcFrameCount[base.NPC.type] = 1;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "腊肠妖灵");
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void SetDefaults()
		{
			base.NPC.aiStyle = 23;
			base.NPC.damage = 120;
			base.NPC.width = 84;
			base.NPC.height = 84;
			base.NPC.defense = 5;
			base.NPC.lifeMax = 600;
			base.NPC.knockBackResist = 0.1f;
			base.NPC.lavaImmune = false;
			base.NPC.noGravity = false;
			base.NPC.noTileCollide = false;
			base.NPC.HitSound = SoundID.NPCHit1;
			base.NPC.DeathSound = SoundID.NPCDeath1;
			base.NPC.buffImmune[24] = true;
            base.NPC.value = 7000;
            this.Banner = base.NPC.type;
            this.BannerItem = base.Mod.Find<ModItem>("BakenMonsterBanner").Type;
        }
        private int y = 0;
		// Token: 0x06001B19 RID: 6937 RVA: 0x0014B900 File Offset: 0x00149B00
		public override void AI()
        {
            if (Main.dayTime)
            {
                NPC.noTileCollide = true;
                NPC.velocity.Y += 1;
            }
        }
        public override bool PreKill()
		{
			return false;
		}
		public override void HitEffect(NPC.HitInfo hit)
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.NPC.life <= 0)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/腊肠妖灵碎块"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/腊肠妖灵碎块"), 1f);
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
            vector2 -= new Vector2((float)base.Mod.GetTexture("NPCs/LanternMoon/腊肠妖灵Glow").Width, (float)(base.Mod.GetTexture("NPCs/LanternMoon/腊肠妖灵Glow").Height / Main.npcFrameCount[base.NPC.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.NPC.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(97 - base.NPC.alpha, 97 - base.NPC.alpha, 97 - base.NPC.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/LanternMoon/腊肠妖灵Glow"), vector2, new Rectangle?(base.NPC.frame), color, base.NPC.rotation, vector, 1f, effects, 0f);
        }
    }
}
