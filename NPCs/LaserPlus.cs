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

namespace MythMod.NPCs
{
        [AutoloadBossHead]

    public class LaserPlus : ModNPC
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
            base.DisplayName.SetDefault("激光眼");
			Main.npcFrameCount[base.npc.type] = 3;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "激光眼");
		}

		// Token: 0x06001640 RID: 5696 RVA: 0x000E2920 File Offset: 0x000E0B20
		public override void SetDefaults()
		{
			base.npc.damage = 75;
            base.npc.lifeMax = 2500;
			base.npc.npcSlots = 14f;
			base.npc.width = 110;
			base.npc.height = 200;
			base.npc.defense = 200000;
			this.animationType = 125;
			base.npc.value = 0f;
			base.npc.aiStyle = -1;
			this.aiType = -1;
			base.npc.knockBackResist = 0f;
			base.npc.boss = true;
			base.npc.noGravity = true;
			base.npc.noTileCollide = true;
			base.npc.HitSound = SoundID.NPCHit3;
            npc.dontTakeDamage = true;
            this.music = 12;
            NPCID.Sets.TrailCacheLength[base.npc.type] = 6;
            NPCID.Sets.TrailingMode[base.npc.type] = 0;
		}
        private bool A2 = true;
        // Token: 0x02000413 RID: 1043
        // Token: 0x06002314 RID: 8980 RVA: 0x0000D3C9 File Offset: 0x0000B5C9
        public override void AI()
        {
            bool dayTime = Main.dayTime;
            Player player = Main.player[base.npc.target];
            bool expertMode = Main.expertMode;
            bool zoneUnderworldHeight = player.ZoneUnderworldHeight;
            base.npc.TargetClosest(true);
            Vector2 vector = new Vector2(base.npc.Center.X, base.npc.Center.Y);
            Vector2 center = base.npc.Center;
            float num = player.Center.X - vector.X;
            float num2 = player.Center.Y - vector.Y;
            float num3 = (float)Math.Sqrt((double)(num * num + num2 * num2));
            int num4 = (base.npc.ai[0] == 2f) ? 2 : 1;
            int num5 = (base.npc.ai[0] == 2f) ? 50 : 35;
            float num6 = expertMode ? 5f : 4.5f;
            base.npc.localAI[0] += 1;
            Vector2 vector6 = base.npc.Center + new Vector2(1200, 0);
            if(A)
            {
                A = false;
                base.npc.localAI[0] = 375;
                Vector2 vector4 = base.npc.Center;
                Vector2 vector7 = vector4 + new Vector2(1200, 0).RotatedBy((double)(Math.PI / 15f) * 2);
            }
            if(dayTime)
            {
                npc.velocity += new Vector2(0 ,-0.8f);
            }
            if (!player.active || player.dead)
            {
                base.npc.TargetClosest(false);
                player = Main.player[base.npc.target];
                if (!player.active || player.dead)
                {
                    base.npc.velocity = new Vector2(0f, -15f);
                    if (base.npc.timeLeft > 150)
                    {
                        base.npc.timeLeft = 150;
                    }
                    return;
                }
            }
            if(!dayTime)
            {
            Vector2 vector3 = new Vector2(num, num2) / num3;
            if(base.npc.localAI[0] % 12 == 0 && base.npc.localAI[0] < 1300)
            {
                Projectile.NewProjectile(base.npc.Center.X, base.npc.Center.Y, vector3.X * 20f, vector3.Y * 20f, 100, 70, 0f, Main.myPlayer, 0f, 0f);
            }
            if(base.npc.localAI[0] % 48 == 0 && base.npc.localAI[0] < 1300)
            {
                Vector2 vector9 = vector3.RotatedBy(Math.PI * 0.26f);
                Vector2 vector10 = vector3.RotatedBy(Math.PI * -0.26f);
                Vector2 vector11 = new Vector2(num, num2) / num3 * 90;
                Vector2 vector12 = vector11 + base.npc.Center;
                Projectile.NewProjectile(vector12.X, vector12.Y, vector10.X * 20f, vector10.Y * 20f, 100, 70, 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(vector12.X, vector12.Y, vector9.X * 20f, vector9.Y * 20f, 100, 70, 0f, Main.myPlayer, 0f, 0f);
            }
            float num25 = (float)Math.Sqrt((double)(num - 500) * (double)(num - 500) + num2 * num2);
            if(base.npc.localAI[0] % 3 == 0 && base.npc.localAI[0] < 700 && base.npc.localAI[0] > 400)
            {
                Vector2 vector8 = new Vector2(num - 500f, num2) / num25 * 50f * (num25 / 1000f);
                base.npc.velocity = vector8;
            }
            float num26 = (float)Math.Sqrt((double)(num2 - 500) * (double)(num2 - 500) + num * num);
            if(base.npc.localAI[0] % 3 == 0 && base.npc.localAI[0] < 1000 && base.npc.localAI[0] > 699)
            {
                Vector2 vector8 = new Vector2(num, num2 - 500f) / num26 * 50f * (num26 / 1000f);
                base.npc.velocity = vector8;
            }
            float num27 = (float)Math.Sqrt((double)(num + 500) * (double)(num + 500) + num2 * num2);
            if(base.npc.localAI[0] % 3 == 0 && base.npc.localAI[0] < 1300 && base.npc.localAI[0] > 999)
            {
                Vector2 vector8 = new Vector2(num + 500f, num2) / num27 * 50f * (num27 / 1000f);
                base.npc.velocity = vector8;
            }
            if(base.npc.localAI[0] > 1300 && base.npc.localAI[0] <= 1305)
            {
                Vector2 vector8 = new Vector2(num, num2) / num3 * 32f;
                base.npc.velocity = vector8;
                Vector2 vector1 = new Vector2(base.npc.Center.X, base.npc.Center.Y);
                float num400 = player.Center.X - vector1.X;
                float num401 = player.Center.Y - vector1.Y;
                base.npc.rotation = (float)Math.Atan2((double)num401, (double)num400) - 1.57f;
            }
            if(base.npc.localAI[0] > 1400 && base.npc.localAI[0] <= 1600 && num3 > 1400)
            {
                Vector2 vector8 = new Vector2(num, num2) / num3 * 32f;
                base.npc.velocity = vector8;
                Vector2 vector1 = new Vector2(base.npc.Center.X, base.npc.Center.Y);
                float num400 = player.Center.X - vector1.X;
                float num401 = player.Center.Y - vector1.Y;
                base.npc.rotation = (float)Math.Atan2((double)num401, (double)num400) - 1.57f;
            }
            if(base.npc.localAI[0] < 1600 && base.npc.localAI[0] > 1700 && base.npc.Center.X > player.Center.X)
            {
                base.npc.velocity = new Vector2(player.Center.X + 500 - base.npc.Center.X, player.Center.Y - base.npc.Center.Y) / num3 * 12f;
                Vector2 vector1 = new Vector2(base.npc.Center.X, base.npc.Center.Y);
                float num400 = player.Center.X - vector1.X;
                float num401 = player.Center.Y - vector1.Y;
                base.npc.rotation = (float)Math.Atan2((double)num401, (double)num400) - 1.57f;
            }
            if(base.npc.localAI[0] < 1700 && base.npc.localAI[0] > 1600 && base.npc.Center.X < player.Center.X)
            {
                base.npc.velocity = new Vector2(player.Center.X - 500 - base.npc.Center.X, player.Center.Y - base.npc.Center.Y) / num3 * 12f;
                Vector2 vector1 = new Vector2(base.npc.Center.X, base.npc.Center.Y);
                float num400 = player.Center.X - vector1.X;
                float num401 = player.Center.Y - vector1.Y;
                base.npc.rotation = (float)Math.Atan2((double)num401, (double)num400) - 1.57f;
            }
            if(base.npc.localAI[0] < 1300)
            {
                Vector2 vector1 = new Vector2(base.npc.Center.X, base.npc.Center.Y);
                float num400 = player.Center.X - vector1.X;
                float num401 = player.Center.Y - vector1.Y;
                base.npc.rotation = (float)Math.Atan2((double)num401, (double)num400) - 1.57f;
            }
            if(base.npc.localAI[0] > 1700)
            {
                base.npc.localAI[0] = 400;
            }
            if ((double)base.npc.life > (double)base.npc.lifeMax * 0.4)
            {
                if (Main.netMode != 1)
                {
                    base.npc.chaseable = false;
                    base.npc.dontTakeDamage = true;
                    base.npc.TargetClosest(true);
                    this.dustTimer--;
                }
            }
            if (NPC.CountNPCS(126) > 0)
            {
                npc.dontTakeDamage = true;
            }
            else
            {
                npc.reflectingProjectiles = true;
                npc.life -= 7;
                if (npc.life < 7)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        Projectile.NewProjectile(base.npc.Center.X, base.npc.Center.Y, (float)Math.Sin(Math.PI * (float)i / 8f) * 20f, (float)Math.Cos(Math.PI * (float)i / 8f) * 20f, 100, 70, 0f, Main.myPlayer, 0f, 0f);
                    }
                    npc.life = 0;
                    npc.active = false;
                }
            }
            }
        }
        public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            damage *= 0;
        }
        public override void ModifyHitByItem(Player player, Item item, ref int damage, ref float knockback, ref bool crit)
        {
            damage *= 0;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
			SpriteEffects effects = SpriteEffects.None;
            if (base.npc.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
			int frameHeight = 200;
            Vector2 value = new Vector2(base.npc.Center.X, base.npc.Center.Y);
            Vector2 vector = new Vector2((float)(Main.npcTexture[base.npc.type].Width / 2) + 2, (float)(Main.npcTexture[base.npc.type].Height / Main.npcFrameCount[base.npc.type] / 2) + 4);
            Vector2 vector2 = value - Main.screenPosition;
            for (int k = 0; k < npc.oldPos.Length; k++)
            {
				Vector2 drawPos = npc.oldPos[k] - Main.screenPosition + vector + new Vector2(0f, npc.gfxOffY);
                Color color = npc.GetAlpha(lightColor) * ((float)(npc.oldPos.Length - k) / (float)npc.oldPos.Length);
                spriteBatch.Draw(Main.npcTexture[npc.type], drawPos, new Rectangle(0 ,frameHeight * (2 - (((int)npc.frameCounter + (int)(k / 1.58333333f)) % 3)), (int)(base.mod.GetTexture("NPCs/LaserPlus").Width) ,frameHeight), color, npc.rotation, vector, npc.scale, effects, 0f);
            }
            return true;
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
            vector2 -= new Vector2((float)base.mod.GetTexture("NPCs/织网激光眼光辉").Width, (float)(base.mod.GetTexture("NPCs/织网激光眼光辉").Height / Main.npcFrameCount[base.npc.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.npc.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.npc.alpha, 297 - base.npc.alpha, 297 - base.npc.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/织网激光眼光辉"), vector2, new Rectangle?(base.npc.frame), color, base.npc.rotation, vector, 1f, effects, 0f);
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
