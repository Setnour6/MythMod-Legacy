using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.Yuanbao
{
	public class PowerYuanbao : ModNPC
	{
		private int num1 = 0;
		private int num2;
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("力量元宝");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "力量元宝");
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
            vector2 -= new Vector2((float)base.Mod.GetTexture("NPCs/Yuanbao/力量元宝Glow").Width, (float)(base.Mod.GetTexture("NPCs/Yuanbao/力量元宝Glow").Height / Main.npcFrameCount[base.NPC.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.NPC.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.NPC.alpha, 297 - base.NPC.alpha, 297 - base.NPC.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/Yuanbao/力量元宝Glow"), vector2, new Rectangle?(base.NPC.frame), new Color(0.3f * (255 - NPC.alpha) / 255f, 0.3f * (255 - NPC.alpha) / 255f, 0.3f * (255 - NPC.alpha) / 255f, 0), base.NPC.rotation, vector, 1f, effects, 0f);
        }
        public override void SetDefaults()
		{
			base.NPC.damage = 0;
			base.NPC.width = 80;
			base.NPC.height = 44;
			base.NPC.defense = 0;
			base.NPC.lifeMax = 1000;
			base.NPC.knockBackResist = 0;
			base.NPC.alpha = 0;
			base.NPC.lavaImmune = true;
			base.NPC.noGravity = false;
			base.NPC.noTileCollide = false;
            base.NPC.aiStyle = -1;
        }
		public override void AI()
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.GoldTime == 0)
            {
                NPC.alpha += 5;
            }
            if(NPC.alpha >= 250)
            {
                NPC.active = false;
            }
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void HitEffect(NPC.HitInfo hit)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            SoundEngine.PlaySound(SoundID.Item10, new Vector2(base.NPC.position.X, base.NPC.position.Y));
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 10, (float)hitDirection, -1f, 0, default(Color), 1f);
            }
            for (int j = 0; j < 3; j++)
            {
                Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 10, (float)hitDirection, -1f, 0, default(Color), 1f);
            }
            if (base.NPC.life <= 0)
            {
                for (int j = 0; j < 4; j++)
                {
                    Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 10, (float)hitDirection, -1f, 0, default(Color), 1f);
                }
				for (int j = 0; j < 25; j++)
                {
                    Dust.NewDust(base.NPC.position, base.NPC.width, base.NPC.height, 10, (float)hitDirection, -1f, 0, default(Color), 1f);
                }
                float scaleFactor = (float)(Main.rand.Next(-8, 8) / 100f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/木元宝碎块1"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/木元宝碎块2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/木元宝碎块2"), 1f);
                Gore.NewGore(base.NPC.position, base.NPC.velocity * scaleFactor, base.Mod.GetGoreSlot("Gores/木元宝碎块3"), 1f);
                if(mplayer.GoldTime > 0)
                {
                    if (Main.expertMode)
                    {
                        mplayer.GoldPoint += 1;
                    }
                    else
                    {
                        mplayer.GoldPoint += 1;
                    }
                    if (mplayer.Double > 0)
                    {
                        if (Main.expertMode)
                        {
                            mplayer.GoldPoint += 1;
                        }
                        else
                        {
                            mplayer.GoldPoint += 1;
                        }
                    }
                    mplayer.PowerIncr += 300;
                    Player player = Main.player[Main.myPlayer];
                    player.AddBuff(base.Mod.Find<ModBuff>("PowerIncr").Type, 300, true);
                    string key = mplayer.GoldPoint.ToString();
                    Color messageColor = Color.RosyBrown;
                    Main.NewText(Language.GetTextValue("分数" + key), messageColor);
                }
            }
        }
		public override bool PreKill()
		{
			return false;
		}
		public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
		{
		}
	}
}
