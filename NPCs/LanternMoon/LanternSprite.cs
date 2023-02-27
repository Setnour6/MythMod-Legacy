using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameInput;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;

namespace MythMod.NPCs.LanternMoon
{

    public class LanternSprite : ModNPC
	{
        private bool A = true;
        private int num10;
        private int num11;
        private int num12;
        private int num13;
        private int num14;
        private int num15;
        private int num16;
        private int num17;
        private int num18;
        private int num19;
        private int num20;
        private int num21;
        private int num22;
        private int num23;
        private int num24;
		// Token: 0x0600163F RID: 5695 RVA: 0x00008D5D File Offset: 0x00006F5D
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("灯笼幽灵");
			Main.npcFrameCount[base.npc.type] = 4;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "灯笼幽灵");
		}

		// Token: 0x06001640 RID: 5696 RVA: 0x000E2920 File Offset: 0x000E0B20
		public override void SetDefaults()
		{
			base.npc.damage = 150;
            base.npc.lifeMax = 900;
			base.npc.npcSlots = 14f;
			base.npc.width = 22;
			base.npc.height = 48;
			base.npc.defense = 0;
			base.npc.value = 4000;
			base.npc.aiStyle = 22;
			base.npc.knockBackResist = 0.6f;
            base.npc.dontTakeDamage = false;
            base.npc.noGravity = true;
			base.npc.noTileCollide = true;
			base.npc.HitSound = SoundID.NPCHit3;
            this.banner = base.npc.type;
            this.bannerItem = base.mod.ItemType("SoulLanternBanner");
        }
        private int A2 = 0;
        private int y = 0;
        private int U = 0;
        // Token: 0x02000413 RID: 1043
        // Token: 0x06002314 RID: 8980 RVA: 0x0000D3C9 File Offset: 0x0000B5C9

        public override void AI()
        {
            Player player = Main.player[Main.myPlayer];
            npc.rotation = npc.velocity.X / 30f;
            A2 += 1;
            y += 1;
            if(A2 % 60 < 15)
            {
                npc.frame.Y = 0;
            }
            if (A2 % 60 >= 15 && A2 % 60 < 30)
            {
                npc.frame.Y = 48;
            }
            if (A2 % 60 >= 30 && A2 % 60 < 45)
            {
                npc.frame.Y = 96;
            }
            if (A2 % 60 >= 45 && A2 % 60 < 60)
            {
                npc.frame.Y = 144;
            }
            if (Main.dayTime)
            {
                npc.velocity.Y += 1;
            }
            if (y % 60 < 15)
            {
                U = 0;
            }
            if (y % 60 >= 15 && y % 60 < 30)
            {
                U = 48;
            }
            if (y % 60 >= 30 && y % 60 < 45)
            {
                U = 96;
            }
            if (y % 60 >= 45 && y % 60 < 60)
            {
                U = 144;
            }
        }
        // Token: 0x02000413 RID: 1043
        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.npc.life <= 0)
            {
                float scaleFactor = (float)(Main.rand.Next(-200, 200) / 100);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/灯笼幽灵碎块1"), 1f);
                Gore.NewGore(base.npc.position, base.npc.velocity * scaleFactor, base.mod.GetGoreSlot("Gores/灯笼幽灵碎块2"), 1f);
                if (mplayer.LanternMoonWave != 15)
                {
                    if (Main.expertMode)
                    {
                        mplayer.LanternMoonPoint += 50;
                        if (MythWorld.Myth)
                        {
                            mplayer.LanternMoonPoint += 50;
                        }
                    }
                    else
                    {
                        mplayer.LanternMoonPoint += 25;
                    }
                }
            }
        }
        public override void NPCLoot()
        {
            bool expertMode = Main.expertMode;
            Item.NewItem((int)base.npc.position.X, (int)base.npc.position.Y, base.npc.width, base.npc.height, 58, 2, false, 0, false, false);
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
            vector2 -= new Vector2((float)base.mod.GetTexture("NPCs/LanternMoon/灯笼幽灵Glow").Width, (float)(base.mod.GetTexture("NPCs/LanternMoon/灯笼幽灵Glow").Height / Main.npcFrameCount[base.npc.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.npc.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(97 - base.npc.alpha, 97 - base.npc.alpha, 97 - base.npc.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/LanternMoon/灯笼幽灵Glow"), vector2, new Rectangle(0, U, 22, 48), new Color(255, 255, 255, 0), base.npc.rotation, vector, 1f, effects, 0f);
        }
        // Token: 0x02000413 RID: 1043
        public int dustTimer = 60;
		// Token: 0x06001646 RID: 5702 RVA: 0x000E4084 File Offset: 0x000E2284
	}
}
