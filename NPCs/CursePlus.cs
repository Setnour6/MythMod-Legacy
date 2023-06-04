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
    [AutoloadBossHead]

    public class CursePlus : ModNPC
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
        private float num25;
        public override void SetStaticDefaults()
        {
            // base.DisplayName.SetDefault("魔焰眼");
            Main.npcFrameCount[base.NPC.type] = 3;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "魔焰眼");
        }
        public override void SetDefaults()
        {
            base.NPC.damage = 75;
            base.NPC.lifeMax = 2500;
            base.NPC.npcSlots = 14f;
            base.NPC.width = 110;
            base.NPC.height = 200;
            base.NPC.defense = 200000;
            this.AnimationType = 125;
            base.NPC.value = 0f;
            base.NPC.aiStyle = -1;
            this.AIType = -1;
            base.NPC.knockBackResist = 0f;
            base.NPC.boss = true;
            base.NPC.noGravity = true;
            base.NPC.noTileCollide = true;
            base.NPC.HitSound = SoundID.NPCHit3;
            NPC.dontTakeDamage = true;
            this.Music = 12;
            NPCID.Sets.TrailCacheLength[base.NPC.type] = 6;
            NPCID.Sets.TrailingMode[base.NPC.type] = 0;
        }
        private bool A2 = true;
        public override void ModifyHitByProjectile(Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            damage *= 0;
        }
        public override void ModifyHitByItem(Player player, Item item, ref NPC.HitModifiers modifiers)
        {
            damage *= 0;
        }
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
            if (A)
            {
                A = false;
                base.NPC.localAI[0] = 375;
                Vector2 vector4 = base.NPC.Center;
                Vector2 vector7 = vector4 + new Vector2(1200, 0).RotatedBy((double)(Math.PI / 15f) * 2);
            }
            if (dayTime)
            {
                NPC.velocity += new Vector2(0, -0.8f);
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
                Vector2 vector3 = new Vector2(num, num2) / num3;
                if (base.NPC.localAI[0] % 3 == 0 && base.NPC.localAI[0] < 1300)
                {
                    Projectile.NewProjectile(base.NPC.Center.X, base.NPC.Center.Y, vector3.X * 10f, vector3.Y * 10f, 101, 70, 0f, Main.myPlayer, 0f, 0f);
                }
                if (base.NPC.localAI[0] % 22 == 0 && base.NPC.localAI[0] < 1300)
                {
                    Projectile.NewProjectile(base.NPC.Center.X, base.NPC.Center.Y, vector3.X * 20f, vector3.Y * 20f, 96, 70, 0f, Main.myPlayer, 0f, 0f);
                }
                if (base.NPC.localAI[0] % 3 == 0 && base.NPC.localAI[0] < 1300 && base.NPC.localAI[0] > 400)
                {
                    Vector2 vector8 = new Vector2(num, num2) / num3 * 5f * (1 + num3 / 1000f);
                    base.NPC.velocity = vector8;
                }
                if (base.NPC.localAI[0] > 1300 && base.NPC.localAI[0] <= 1305)
                {
                    Vector2 vector8 = new Vector2(num, num2) / num3 * 36f;
                    base.NPC.velocity = vector8;
                    Vector2 vector1 = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
                    float num400 = player.Center.X - vector1.X;
                    float num401 = player.Center.Y - vector1.Y;
                    base.NPC.rotation = (float)Math.Atan2((double)num401, (double)num400) - 1.57f;
                }
                if (base.NPC.localAI[0] > 1300 && base.NPC.localAI[0] <= 2000)
                {
                    int num9 = Dust.NewDust(base.NPC.Center, 2, 2, 75, 0, 0, 0, default(Color), 1.5f);
                    Main.dust[num9].noGravity = true;
                }
                if (base.NPC.localAI[0] > 1400 && base.NPC.localAI[0] <= 1900 && num3 > 1400)
                {
                    Vector2 vector8 = new Vector2(num, num2) / num3 * 36f;
                    base.NPC.velocity = vector8;
                    Vector2 vector1 = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
                    float num400 = player.Center.X - vector1.X;
                    float num401 = player.Center.Y - vector1.Y;
                    base.NPC.rotation = (float)Math.Atan2((double)num401, (double)num400) - 1.57f;
                }
                if (base.NPC.localAI[0] < 2000 && base.NPC.localAI[0] > 1900 && base.NPC.Center.X > player.Center.X)
                {
                    base.NPC.velocity = new Vector2(player.Center.X + 600 - base.NPC.Center.X, player.Center.Y - base.NPC.Center.Y) / num3 * 12f;
                    Vector2 vector1 = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
                    float num400 = player.Center.X - vector1.X;
                    float num401 = player.Center.Y - vector1.Y;
                    base.NPC.rotation = (float)Math.Atan2((double)num401, (double)num400) - 1.57f;
                }
                if (base.NPC.localAI[0] < 2000 && base.NPC.localAI[0] > 1900 && base.NPC.Center.X < player.Center.X)
                {
                    base.NPC.velocity = new Vector2(player.Center.X - 600 - base.NPC.Center.X, player.Center.Y - base.NPC.Center.Y) / num3 * 12f;
                    Vector2 vector1 = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
                    float num400 = player.Center.X - vector1.X;
                    float num401 = player.Center.Y - vector1.Y;
                    base.NPC.rotation = (float)Math.Atan2((double)num401, (double)num400) - 1.57f;
                }
                if (base.NPC.localAI[0] < 1300)
                {
                    Vector2 vector1 = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
                    float num400 = player.Center.X - vector1.X;
                    float num401 = player.Center.Y - vector1.Y;
                    base.NPC.rotation = (float)Math.Atan2((double)num401, (double)num400) - 1.57f;
                }
                if (base.NPC.localAI[0] > 2000)
                {
                    base.NPC.localAI[0] = 400;
                }
                if ((double)base.NPC.life > (double)base.NPC.lifeMax * 0.4)
                {
                    if (Main.netMode != 1)
                    {
                        base.NPC.chaseable = false;
                        base.NPC.dontTakeDamage = true;
                        base.NPC.TargetClosest(true);
                        this.dustTimer--;
                    }
                }
                if (NPC.CountNPCS(125) > 0)
                {
                    NPC.dontTakeDamage = true;
                }
                else
                {
                    NPC.life -= 7;
                    NPC.reflectingProjectiles = true;
                    if (NPC.life < 7)
                    {
                        int u = NPC.NewNPC((int)NPC.Center.X, (int)NPC.Center.Y, 126, 0, 0f, 0f, 0f, 99999f, 255);
                        Main.npc[u].life = 1000;
                        Main.npc[u].StrikeNPC(2000, 0, 1, true);
                        int nump = Projectile.NewProjectile(Main.npc[u].Center.X, Main.npc[u].Center.Y, 0, 0, 125, 50000, 2, player.whoAmI, 0f, 0f);
                        Main.projectile[nump].timeLeft = 4;
                        for (int i = 0; i < 500; i++)
                        {
                            float num7 = (float)Main.rand.Next(0, 62832) / 4000f;
                            float num8 = (float)Main.rand.Next(0, 62832) / 4000f;
                            int num9 = Dust.NewDust(base.NPC.Center, 1, 1, 75, 0, 0, 0, default(Color), 6f);
                            Main.dust[num9].velocity.X = (float)Math.Cos(num7) * num8;
                            Main.dust[num9].velocity.Y = (float)Math.Sin(num7) * num8;
                            Main.dust[num9].noGravity = true;
                        }
                        Item.NewItem((int)player.position.X, (int)player.position.Y - 100, base.NPC.width, base.NPC.height, base.Mod.Find<ModItem>("TwinsChest").Type, 1, false, 0, false, false);
                        Item.NewItem((int)player.position.X, (int)player.position.Y - 100, base.NPC.width, base.NPC.height, 58, 1, false, 0, false, false);
                        Item.NewItem((int)player.position.X, (int)player.position.Y - 100, base.NPC.width, base.NPC.height, 58, 1, false, 0, false, false);
                        Item.NewItem((int)player.position.X, (int)player.position.Y - 100, base.NPC.width, base.NPC.height, 58, 1, false, 0, false, false);
                        Item.NewItem((int)player.position.X, (int)player.position.Y - 100, base.NPC.width, base.NPC.height, 58, 1, false, 0, false, false);
                        Item.NewItem((int)player.position.X, (int)player.position.Y - 100, base.NPC.width, base.NPC.height, 58, 1, false, 0, false, false);
                        Item.NewItem((int)player.position.X, (int)player.position.Y - 100, base.NPC.width, base.NPC.height, 58, 1, false, 0, false, false);
                        Item.NewItem((int)player.position.X, (int)player.position.Y - 100, base.NPC.width, base.NPC.height, 58, 1, false, 0, false, false);
                        Item.NewItem((int)player.position.X, (int)player.position.Y - 100, base.NPC.width, base.NPC.height, 58, 1, false, 0, false, false);
                        Item.NewItem((int)player.position.X, (int)player.position.Y - 100, base.NPC.width, base.NPC.height, 58, 1, false, 0, false, false);
                        Item.NewItem((int)player.position.X, (int)player.position.Y - 100, base.NPC.width, base.NPC.height, 58, 1, false, 0, false, false);
                        Item.NewItem((int)player.position.X, (int)player.position.Y - 100, base.NPC.width, base.NPC.height, 58, 1, false, 0, false, false);
                        Item.NewItem((int)player.position.X, (int)player.position.Y - 100, base.NPC.width, base.NPC.height, 58, 1, false, 0, false, false);
                        Item.NewItem((int)player.position.X, (int)player.position.Y - 100, base.NPC.width, base.NPC.height, 58, 1, false, 0, false, false);
                        Item.NewItem((int)player.position.X, (int)player.position.Y - 100, base.NPC.width, base.NPC.height, 58, 1, false, 0, false, false);
                        NPC.life = 0;
                        NPC.active = false;
                    }
                }
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (base.NPC.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            int frameHeight = 200;
            Vector2 value = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
            Vector2 vector = new Vector2((float)(TextureAssets.Npc[base.NPC.type].Value.Width / 2) + 2, (float)(TextureAssets.Npc[base.NPC.type].Value.Height / Main.npcFrameCount[base.NPC.type] / 2) + 4);
            Vector2 vector2 = value - Main.screenPosition;
            for (int k = 0; k < NPC.oldPos.Length; k++)
            {
                Vector2 drawPos = NPC.oldPos[k] - Main.screenPosition + vector + new Vector2(0f, NPC.gfxOffY);
                Color color = NPC.GetAlpha(lightColor) * ((float)(NPC.oldPos.Length - k) / (float)NPC.oldPos.Length);
                spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, drawPos, new Rectangle(0, frameHeight * (2 - (((int)NPC.frameCounter + (int)(k / 1.58333333f)) % 3)), (int)(base.Mod.GetTexture("NPCs/CursePlus").Width), frameHeight), color, NPC.rotation, vector, NPC.scale, effects, 0f);
            }
            for (int l = 0; l < NPC.oldPos.Length; l++)
            {
                Vector2 drawPos = NPC.oldPos[l] - Main.screenPosition + vector + new Vector2(0f, NPC.gfxOffY);
                Color color = NPC.GetAlpha(lightColor) * ((float)(NPC.oldPos.Length - l) / (float)NPC.oldPos.Length);
                spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, drawPos, new Rectangle(0, frameHeight * (2 - (((int)NPC.frameCounter + (int)(l / 1.58333333f)) % 3)), (int)(base.Mod.GetTexture("NPCs/咒炎炼狱眼光辉").Width), frameHeight), color, NPC.rotation, vector, NPC.scale, effects, 0f);
            }
            return true;
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
            vector2 -= new Vector2((float)base.Mod.GetTexture("NPCs/咒炎炼狱眼光辉").Width, (float)(base.Mod.GetTexture("NPCs/咒炎炼狱眼光辉").Height / Main.npcFrameCount[base.NPC.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.NPC.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.NPC.alpha, 297 - base.NPC.alpha, 297 - base.NPC.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/咒炎炼狱眼光辉"), vector2, new Rectangle?(base.NPC.frame), color, base.NPC.rotation, vector, 1f, effects, 0f);
        }
        // Token: 0x02000413 RID: 1043
        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
        }
        // Token: 0x02000413 RID: 1043
        public int dustTimer = 60;
        // Token: 0x06001646 RID: 5702 RVA: 0x000E4084 File Offset: 0x000E2284
    }
}
