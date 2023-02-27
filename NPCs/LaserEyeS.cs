using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.GameInput;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;

namespace MythMod.NPCs
{

    public class LaserEyeS : ModNPC
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
            base.DisplayName.SetDefault("小激光眼");
			Main.npcFrameCount[base.NPC.type] = 3;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "小激光眼");
		}

		// Token: 0x06001640 RID: 5696 RVA: 0x000E2920 File Offset: 0x000E0B20
		public override void SetDefaults()
		{
			base.NPC.damage = 0;
            base.NPC.lifeMax = 2500;
			base.NPC.npcSlots = 14f;
			base.NPC.width = 20;
			base.NPC.height = 34;
			base.NPC.defense = 200000;
			this.AnimationType = 125;
			base.NPC.value = 0f;
			base.NPC.aiStyle = -1;
			this.AIType = -1;
			base.NPC.knockBackResist = 0f;
			base.NPC.boss = true;
            base.NPC.dontTakeDamage = true;
            base.NPC.noGravity = true;
			base.NPC.noTileCollide = true;
			base.NPC.HitSound = SoundID.NPCHit3;
			this.Music = 12;
		}
        private bool A2 = true;
        // Token: 0x02000413 RID: 1043
        // Token: 0x06002314 RID: 8980 RVA: 0x0000D3C9 File Offset: 0x0000B5C9
        public override void AI()
        {
            bool dayTime = Main.dayTime;
            Player player = Main.player[base.NPC.target];
            bool expertMode = Main.expertMode;
            bool zoneUnderworldHeight = player.ZoneUnderworldHeight;
            base.NPC.TargetClosest(true);
            Vector2 vector = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
            Vector2 center = base.NPC.Center;
            float num = player.Center.X - vector.X;
            float num2 = player.Center.Y - vector.Y;
            float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
            int num4 = (base.NPC.ai[0] == 2f) ? 2 : 1;
            int num5 = (base.NPC.ai[0] == 2f) ? 50 : 35;
            float num6 = expertMode ? 5f : 4.5f;
            base.NPC.localAI[0] += 1;
            Vector2 vector6 = base.NPC.Center + new Vector2(1200, 0);
            if(A)
            {
                A = false;
                base.NPC.localAI[0] = 375;
                Vector2 vector4 = base.NPC.Center;
                Vector2 vector7 = vector4 + new Vector2(1200, 0).RotatedBy((double)(Math.PI / 15f) * 2);
                for(int u = 0; u < 25; u++)
                {
                    Dust.NewDust(new Vector2((float)base.NPC.Center.X, (float)base.NPC.Center.Y), 0, 0, 182, 0f, 0f, 0, default(Color), 1f);
                }
            }
            if(dayTime)
            {
                NPC.velocity += new Vector2(0 ,-0.8f);
            }
            if (!player.active || player.dead)
            {
                base.NPC.TargetClosest(false);
                player = Main.player[base.NPC.target];
                if (!player.active || player.dead)
                {
                    base.NPC.velocity = new Vector2(0f, -15f);
                    if (base.NPC.timeLeft > 150)
                    {
                        base.NPC.timeLeft = 150;
                    }
                    return;
                }
            }
            if (!dayTime)
            {
                Vector2 vector1 = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
                float num400 = player.Center.X - vector1.X;
                float num401 = player.Center.Y - vector1.Y;
                base.NPC.rotation = (float)Math.Atan2((double)num401, (double)num400) - 1.57f;
                NPC.velocity = new Vector2(0, 0);
                NPC.position = player.Center + new Vector2(0, 350 + 50 * (float)Math.Sin(base.NPC.localAI[0] / -40f)).RotatedBy(base.NPC.localAI[0] / 90f);
                Vector2 vector3 = new Vector2(num, num2) / num3;
                if (base.NPC.localAI[0] % 60 == 0)
                {
                    Projectile.NewProjectile(base.NPC.Center.X, base.NPC.Center.Y, vector3.X * 11f, vector3.Y * 11f, 100, 70, 0f, Main.myPlayer, 0f, 0f);
                }
                if (NPC.CountNPCS(125) > 0)
                {
                    NPC.dontTakeDamage = true;
                }
                else
                {
                    NPC.life = 0;
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
            vector2 -= new Vector2((float)base.Mod.GetTexture("NPCs/小激光眼光辉").Width, (float)(base.Mod.GetTexture("NPCs/小激光眼光辉").Height / Main.npcFrameCount[base.NPC.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.NPC.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.NPC.alpha, 297 - base.NPC.alpha, 297 - base.NPC.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/小激光眼光辉"), vector2, new Rectangle?(base.NPC.frame), color, base.NPC.rotation, vector, 1f, effects, 0f);
        }
        // Token: 0x02000413 RID: 1043
        public override void OnHitPlayer(Player player, int damage, bool crit)
        {
        }
        // Token: 0x02000413 RID: 1043
        public int dustTimer = 60;
		// Token: 0x06001646 RID: 5702 RVA: 0x000E4084 File Offset: 0x000E2284
	}
}
