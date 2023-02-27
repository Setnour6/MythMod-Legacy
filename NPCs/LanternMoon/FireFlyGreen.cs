using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.NPCs.LanternMoon
{
    public class FireFlyGreen : ModNPC
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("FireButterfly");
            Main.npcFrameCount[base.npc.type] = 3;
            base.DisplayName.AddTranslation(GameCulture.Chinese, "花火蝶");
        }

        public override void SetDefaults()
        {
            base.npc.lifeMax = 1200;
            base.npc.width = 10;
            base.npc.height = 10;
            base.npc.aiStyle = -1;
            base.npc.noGravity = true;
            npc.damage = 100;
            npc.friendly = false;
            base.npc.scale = 1f;
            base.npc.HitSound = SoundID.NPCHit1;
            base.npc.DeathSound = SoundID.NPCDeath1;
            this.aiType = 356;
            this.animationType = 444;
        }
        private int k0 = 0;
        public override void AI()
        {
            k0 += 1;
            if(k0 % 300 == 0)
            {
                Main.PlaySound(2, (int)base.npc.position.X, (int)base.npc.position.Y, 14, 0.36f, 0f);
                float num6 = (float)Main.rand.Next(0, 10000);
                double num8 = Main.rand.Next(-1000, 1000) / 100d;
                double num9 = (double)Math.Sqrt(100 - (int)num8 * (int)num8);
                Vector2 v1 = Vector2.Normalize(new Vector2((float)num8, (float)num9)) * 5;
                Vector2 mc = Main.screenPosition + new Vector2((float)num8, (float)num9);
                for (int i = 0; i < 15; i++)
                {
                    v1 = v1.RotatedBy(Math.PI / 7.5f);
                    Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                    int p = Dust.NewDust(npc.Center, 0, 0, mod.DustType("Greenfire"), v1.X * 5f, v1.Y * 5f, 0, default(Color), Main.rand.NextFloat(0.9f, 1.6f));
                    Main.dust[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9)) * 5f;
                    Main.dust[p].fadeIn = 1.4f;
                }
            }
            Lighting.AddLight(base.npc.position, 0f, 0.3f, 0f);
            int j0 = Dust.NewDust(new Vector2((float)npc.Center.X, (float)npc.Center.Y) + new Vector2(0, 15).RotatedBy(Main.time / 10f), 0, 0, 89, 0f, 0f, 0, default(Color), Main.rand.NextFloat(0.9f, 1.6f));
            Main.dust[j0].noGravity = true;
            Main.dust[j0].velocity *= 0.15f;
            float num = base.npc.ai[0];
            float num2 = base.npc.ai[1];
            if (Main.netMode != 1)
            {
                if (base.npc.ai[2] == 0f)
                {
                    int num3 = 0;
                    int num4 = 4;
                    int num5 = 6;
                    int num6 = 3;
                    int num7 = 7;
                    int num8 = 2;
                    int num9 = 1;
                    int num10 = 5;
                    int num11 = Main.rand.Next(100);
                    if (num11 == 0)
                    {
                        num11 = num10;
                    }
                    else if (num11 < 3)
                    {
                        num11 = num9;
                    }
                    else if (num11 < 9)
                    {
                        num11 = num8;
                    }
                    else if (num11 < 19)
                    {
                        num11 = num7;
                    }
                    else if (num11 < 34)
                    {
                        num11 = num6;
                    }
                    else if (num11 < 53)
                    {
                        num11 = num5;
                    }
                    else if (num11 < 75)
                    {
                        num11 = num4;
                    }
                    else
                    {
                        num11 = num3;
                    }
                    base.npc.ai[2] = (float)(1 + num11);
                }
                if (base.npc.ai[3] == 0f)
                {
                    base.npc.ai[3] = (float)Main.rand.Next(75, 111) * 0.01f;
                }
                base.npc.localAI[0] -= 1f;
                if (base.npc.localAI[0] <= 0f)
                {
                    base.npc.TargetClosest(true);
                    base.npc.localAI[0] = (float)Main.rand.Next(90, 240);
                    float num12 = Math.Abs(base.npc.Center.X - Main.player[base.npc.target].Center.X);
                    if (num12 > 700f && base.npc.localAI[3] == 0f)
                    {
                        float num13 = (float)Main.rand.Next(50, 151) * 0.01f;
                        if (num12 > 1000f)
                        {
                            num13 = (float)Main.rand.Next(150, 201) * 0.01f;
                        }
                        else if (num12 > 850f)
                        {
                            num13 = (float)Main.rand.Next(100, 151) * 0.01f;
                        }
                        int num14 = base.npc.direction * Main.rand.Next(100, 251);
                        int num15 = Main.rand.Next(-50, 51);
                        if (base.npc.position.Y > Main.player[base.npc.target].position.Y - 100f)
                        {
                            num15 -= Main.rand.Next(100, 251);
                        }
                        float num16 = num13 / (float)Math.Sqrt((double)(num14 * num14 + num15 * num15));
                        num = (float)num14 * num16;
                        num2 = (float)num15 * num16;
                    }
                    else
                    {
                        base.npc.localAI[3] = 1f;
                        float num17 = (float)Main.rand.Next(26, 301) * 0.01f;
                        int num18 = Main.rand.Next(-100, 101);
                        int num19 = Main.rand.Next(-100, 101);
                        float num20 = num17 / (float)Math.Sqrt((double)(num18 * num18 + num19 * num19));
                        num = (float)num18 * num20;
                        num2 = (float)num19 * num20;
                    }
                    base.npc.netUpdate = true;
                }
            }
            base.npc.scale = base.npc.ai[3];
            int num21 = 60;
            base.npc.velocity.X = (base.npc.velocity.X * (float)(num21 - 1) + num) / (float)num21;
            base.npc.velocity.Y = (base.npc.velocity.Y * (float)(num21 - 1) + num2) / (float)num21;
            if (base.npc.velocity.Y > 0f)
            {
                int num22 = 3;
                int num23 = (int)base.npc.Center.X / 16;
                int num24 = (int)base.npc.Center.Y / 16;
                int num25;
                for (int i = num24; i < num24 + num22; i = num25 + 1)
                {
                    if (Main.tile[num23, i] != null && ((Main.tile[num23, i].nactive() && Main.tileSolid[(int)Main.tile[num23, i].type]) || Main.tile[num23, i].liquid > 0))
                    {
                        num2 *= -1f;
                        if (base.npc.velocity.Y > 0f)
                        {
                            base.npc.velocity.Y = base.npc.velocity.Y * 0.9f;
                        }
                    }
                    num25 = i;
                }
            }
            if (base.npc.velocity.Y < 0f)
            {
                int num26 = 30;
                bool flag = false;
                int num27 = (int)base.npc.Center.X / 16;
                int num28 = (int)base.npc.Center.Y / 16;
                int num29;
                for (int j = num28; j < num28 + num26; j = num29 + 1)
                {
                    if (Main.tile[num27, j] != null && Main.tile[num27, j].nactive() && Main.tileSolid[(int)Main.tile[num27, j].type])
                    {
                        flag = true;
                    }
                    num29 = j;
                }
                if (!flag)
                {
                    num2 *= -1f;
                    if (base.npc.velocity.Y < 0f)
                    {
                        base.npc.velocity.Y = base.npc.velocity.Y * 0.9f;
                    }
                }
            }
            if (base.npc.localAI[1] > 0f)
            {
                base.npc.localAI[1] -= 1f;
            }
            else
            {
                base.npc.localAI[1] = 15f;
            }
            if (base.npc.collideX)
            {
                if (base.npc.velocity.X < 0f)
                {
                    num = Math.Abs(num);
                }
                else
                {
                    num = -Math.Abs(num);
                }
                base.npc.velocity.X = base.npc.velocity.X * -0.2f;
            }
            if (base.npc.velocity.X < 0f)
            {
                base.npc.direction = -1;
            }
            if (base.npc.velocity.X > 0f)
            {
                base.npc.direction = 1;
            }
            base.npc.ai[0] = num;
            base.npc.ai[1] = num2;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.npc.life <= 0)
            {
                for (int r = 0; r < 15; r++)
                {
                    Dust.NewDust(new Vector2((float)npc.position.X, (float)npc.position.Y), npc.width, npc.height, 183, 0f, 0f, 0, default(Color), Main.rand.NextFloat(0.9f, 1.6f));
                }
                return;
            }
            int num = 0;
            while ((double)num < damage / (double)base.npc.lifeMax * 50.0)
            {
                for (int r = 0; r < 4; r++)
                {
                    Dust.NewDust(new Vector2((float)npc.position.X, (float)npc.position.Y), npc.width, npc.height, 183, 0f, 0f, 0, default(Color), Main.rand.NextFloat(0.9f, 1.6f));
                }
                num++;
            }
            if (mplayer.LanternMoonWave != 35)
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
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (base.npc.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Vector2 value = new Vector2(base.npc.Center.X, base.npc.Center.Y);
            Vector2 vector = new Vector2((float)(Main.npcTexture[base.npc.type].Width / 2), (float)(Main.npcTexture[base.npc.type].Height / Main.npcFrameCount[base.npc.type] / 2));
            Vector2 vector2 = value - Main.screenPosition;
            vector2 -= new Vector2((float)base.mod.GetTexture("NPCs/LanternMoon/FireFlyGreen").Width, (float)(base.mod.GetTexture("NPCs/LanternMoon/FireFlyGreen").Height / Main.npcFrameCount[base.npc.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.npc.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.npc.alpha, 297 - base.npc.alpha, 297 - base.npc.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.mod.GetTexture("NPCs/LanternMoon/FireFlyGreen"), vector2, new Rectangle?(base.npc.frame), color, base.npc.rotation, vector, 1f, effects, 0f);
            return false;
        }
        public bool decide;
	}
}
