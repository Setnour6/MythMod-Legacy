using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.NPCs.Yuanbao
{
	public class FreezeYuanbao : ModNPC
	{
		private int num1 = 0;
		private int num2;
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("冰冻元宝");
            base.DisplayName.AddTranslation(GameCulture.Chinese, "冰冻元宝");
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
            vector2 -= new Vector2((float)base.mod.GetTexture("NPCs/Yuanbao/冰冻元宝Glow").Width, (float)(base.mod.GetTexture("NPCs/Yuanbao/冰冻元宝Glow").Height / Main.npcFrameCount[base.npc.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.npc.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.npc.alpha, 297 - base.npc.alpha, 297 - base.npc.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/Yuanbao/冰冻元宝Glow"), vector2, new Rectangle?(base.npc.frame), new Color(0.3f * (255 - npc.alpha) / 255f, 0.3f * (255 - npc.alpha) / 255f, 0.3f * (255 - npc.alpha) / 255f, 0), base.npc.rotation, vector, 1f, effects, 0f);
        }
        public override void SetDefaults()
		{
			base.npc.damage = 0;
			base.npc.width = 80;
			base.npc.height = 44;
			base.npc.defense = 0;
			base.npc.lifeMax = 1000;
			base.npc.knockBackResist = 0;
			base.npc.alpha = 0;
			base.npc.lavaImmune = true;
			base.npc.noGravity = false;
			base.npc.noTileCollide = false;
            base.npc.aiStyle = -1;
        }
        private int timeleft2 = 120;
        public override void AI()
		{
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (mplayer.GoldTime == 0)
            {
                npc.alpha += 5;
            }
            if(npc.alpha >= 250)
            {
                npc.active = false;
            }
            if (npc.velocity.Y == 0)
            {
                timeleft2 -= 1;
            }
            if (timeleft2 <= 0)
            {
                timeleft2 = 0;
                npc.alpha += 3;
            }
        }
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return 0f;
		}
		public override void HitEffect(int hitDirection, double damage)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            Main.PlaySound(2, (int)base.npc.position.X, (int)base.npc.position.Y, 10, 1f, 0f);
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 10, (float)hitDirection, -1f, 0, default(Color), 1f);
            }
            for (int j = 0; j < 3; j++)
            {
                Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 10, (float)hitDirection, -1f, 0, default(Color), 1f);
            }
            if (base.npc.life <= 0)
            {
                for (int j = 0; j < 4; j++)
                {
                    Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 10, (float)hitDirection, -1f, 0, default(Color), 1f);
                }
				for (int j = 0; j < 25; j++)
                {
                    Dust.NewDust(base.npc.position, base.npc.width, base.npc.height, 10, (float)hitDirection, -1f, 0, default(Color), 1f);
                }
                float scaleFactor = (float)(Main.rand.Next(-8, 8) / 100f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/木元宝碎块1"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/木元宝碎块2"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/木元宝碎块2"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/木元宝碎块3"), 1f);
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
                    Player player = Main.player[Main.myPlayer];
                    player.AddBuff(46, 300, true);
                    player.AddBuff(47, 120, true);
                    string key = mplayer.GoldPoint.ToString();
                    Color messageColor = Color.RosyBrown;
                    Main.NewText(Language.GetTextValue("分数" + key), messageColor);
                }
            }
        }
		public override bool PreNPCLoot()
		{
			return false;
		}
		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
		}
	}
}
