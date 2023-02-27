using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.NPCs.LanternMoon
{
    public class FireFly : ModNPC
    {
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("FireButterfly");
            Main.npcFrameCount[base.NPC.type] = 3;
            base.DisplayName.AddTranslation(GameCulture.English, "花火蝶");
        }

        public override void SetDefaults()
        {
            base.NPC.lifeMax = 1200;
            base.NPC.width = 10;
            base.NPC.height = 10;
            base.NPC.aiStyle = -1;
            base.NPC.noGravity = true;
            NPC.damage = 100;
            NPC.friendly = false;
            base.NPC.scale = 1f;
            base.NPC.HitSound = SoundID.NPCHit1;
            base.NPC.DeathSound = SoundID.NPCDeath1;
            this.AIType = 356;
            this.AnimationType = 444;
        }
        private int k0 = 0;
        public override void AI()
        {
            k0 += 1;
            if(k0 % 300 == 0)
            {
                SoundEngine.PlaySound(SoundID.Item14.WithVolumeScale(0.36f), new Vector2(base.NPC.position.X, base.NPC.position.Y));
                float num6 = (float)Main.rand.Next(0, 10000);
                double num8 = Main.rand.Next(-1000, 1000) / 100d;
                double num9 = (double)Math.Sqrt(100 - (int)num8 * (int)num8);
                Vector2 v1 = Vector2.Normalize(new Vector2((float)num8, (float)num9)) * 5;
                Vector2 mc = Main.screenPosition + new Vector2((float)num8, (float)num9);
                for (int i = 0; i < 15; i++)
                {
                    v1 = v1.RotatedBy(Math.PI / 7.5f);
                    Vector2 v2 = new Vector2(v1.X * (float)num6 / 10000, v1.Y);
                    int p = Dust.NewDust(NPC.Center, 0, 0, Mod.Find<ModDust>("Redfire").Type, v1.X * 5f, v1.Y * 5f, 0, default(Color), Main.rand.NextFloat(0.9f, 1.6f));
                    Main.dust[p].velocity = v2.RotatedBy(Math.Atan2((float)num8, (float)num9)) *5f;
                    Main.dust[p].fadeIn = 1.4f;
                }
            }
            Lighting.AddLight(base.NPC.position, 0.3f, 0f, 0f);
            int j0 = Dust.NewDust(new Vector2((float)NPC.Center.X, (float)NPC.Center.Y) + new Vector2(0, 15).RotatedBy(Main.time / 10f), 0, 0, 183, 0f, 0f, 0, default(Color), Main.rand.NextFloat(0.9f, 1.6f));
            Main.dust[j0].noGravity = true;
            Main.dust[j0].velocity *= 0.15f;
            float num = base.NPC.ai[0];
            float num2 = base.NPC.ai[1];
            if (Main.netMode != 1)
            {
                if (base.NPC.ai[2] == 0f)
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
                    base.NPC.ai[2] = (float)(1 + num11);
                }
                if (base.NPC.ai[3] == 0f)
                {
                    base.NPC.ai[3] = (float)Main.rand.Next(75, 111) * 0.01f;
                }
                base.NPC.localAI[0] -= 1f;
                if (base.NPC.localAI[0] <= 0f)
                {
                    base.NPC.TargetClosest(true);
                    base.NPC.localAI[0] = (float)Main.rand.Next(90, 240);
                    float num12 = Math.Abs(base.NPC.Center.X - Main.player[base.NPC.target].Center.X);
                    if (num12 > 700f && base.NPC.localAI[3] == 0f)
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
                        int num14 = base.NPC.direction * Main.rand.Next(100, 251);
                        int num15 = Main.rand.Next(-50, 51);
                        if (base.NPC.position.Y > Main.player[base.NPC.target].position.Y - 100f)
                        {
                            num15 -= Main.rand.Next(100, 251);
                        }
                        float num16 = num13 / (float)Math.Sqrt((double)(num14 * num14 + num15 * num15));
                        num = (float)num14 * num16;
                        num2 = (float)num15 * num16;
                    }
                    else
                    {
                        base.NPC.localAI[3] = 1f;
                        float num17 = (float)Main.rand.Next(26, 301) * 0.01f;
                        int num18 = Main.rand.Next(-100, 101);
                        int num19 = Main.rand.Next(-100, 101);
                        float num20 = num17 / (float)Math.Sqrt((double)(num18 * num18 + num19 * num19));
                        num = (float)num18 * num20;
                        num2 = (float)num19 * num20;
                    }
                    base.NPC.netUpdate = true;
                }
            }
            base.NPC.scale = base.NPC.ai[3];
            int num21 = 60;
            base.NPC.velocity.X = (base.NPC.velocity.X * (float)(num21 - 1) + num) / (float)num21;
            base.NPC.velocity.Y = (base.NPC.velocity.Y * (float)(num21 - 1) + num2) / (float)num21;
            if (base.NPC.velocity.Y > 0f)
            {
                int num22 = 3;
                int num23 = (int)base.NPC.Center.X / 16;
                int num24 = (int)base.NPC.Center.Y / 16;
                int num25;
                for (int i = num24; i < num24 + num22; i = num25 + 1)
                {
                    if (Main.tile[num23, i] != null && ((Main.tile[num23, i].HasUnactuatedTile && Main.tileSolid[(int)Main.tile[num23, i].TileType]) || Main.tile[num23, i].LiquidAmount > 0))
                    {
                        num2 *= -1f;
                        if (base.NPC.velocity.Y > 0f)
                        {
                            base.NPC.velocity.Y = base.NPC.velocity.Y * 0.9f;
                        }
                    }
                    num25 = i;
                }
            }
            if (base.NPC.velocity.Y < 0f)
            {
                int num26 = 30;
                bool flag = false;
                int num27 = (int)base.NPC.Center.X / 16;
                int num28 = (int)base.NPC.Center.Y / 16;
                int num29;
                for (int j = num28; j < num28 + num26; j = num29 + 1)
                {
                    if (Main.tile[num27, j] != null && Main.tile[num27, j].HasUnactuatedTile && Main.tileSolid[(int)Main.tile[num27, j].TileType])
                    {
                        flag = true;
                    }
                    num29 = j;
                }
                if (!flag)
                {
                    num2 *= -1f;
                    if (base.NPC.velocity.Y < 0f)
                    {
                        base.NPC.velocity.Y = base.NPC.velocity.Y * 0.9f;
                    }
                }
            }
            if (base.NPC.localAI[1] > 0f)
            {
                base.NPC.localAI[1] -= 1f;
            }
            else
            {
                base.NPC.localAI[1] = 15f;
            }
            if (base.NPC.collideX)
            {
                if (base.NPC.velocity.X < 0f)
                {
                    num = Math.Abs(num);
                }
                else
                {
                    num = -Math.Abs(num);
                }
                base.NPC.velocity.X = base.NPC.velocity.X * -0.2f;
            }
            if (base.NPC.velocity.X < 0f)
            {
                base.NPC.direction = -1;
            }
            if (base.NPC.velocity.X > 0f)
            {
                base.NPC.direction = 1;
            }
            base.NPC.ai[0] = num;
            base.NPC.ai[1] = num2;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            MythPlayer mplayer = Main.player[Main.myPlayer].GetModPlayer<MythPlayer>();
            if (base.NPC.life <= 0)
            {
                for (int r = 0; r < 15; r++)
                {
                    Dust.NewDust(new Vector2((float)NPC.position.X, (float)NPC.position.Y), NPC.width, NPC.height, 183, 0f, 0f, 0, default(Color), Main.rand.NextFloat(0.9f, 1.6f));
                }
                return;
            }
            int num = 0;
            while ((double)num < damage / (double)base.NPC.lifeMax * 50.0)
            {
                for (int r = 0; r < 4; r++)
                {
                    Dust.NewDust(new Vector2((float)NPC.position.X, (float)NPC.position.Y), NPC.width, NPC.height, 183, 0f, 0f, 0, default(Color), Main.rand.NextFloat(0.9f, 1.6f));
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
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            SpriteEffects effects = SpriteEffects.None;
            if (base.NPC.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Vector2 value = new Vector2(base.NPC.Center.X, base.NPC.Center.Y);
            Vector2 vector = new Vector2((float)(TextureAssets.Npc[base.NPC.type].Value.Width / 2), (float)(TextureAssets.Npc[base.NPC.type].Value.Height / Main.npcFrameCount[base.NPC.type] / 2));
            Vector2 vector2 = value - Main.screenPosition;
            vector2 -= new Vector2((float)base.Mod.GetTexture("NPCs/LanternMoon/FireFly").Width, (float)(base.Mod.GetTexture("NPCs/LanternMoon/FireFly").Height / Main.npcFrameCount[base.NPC.type])) * 1f / 2f;
            vector2 += vector * 1f + new Vector2(0f, 4f + base.NPC.gfxOffY);
            Color color = Utils.MultiplyRGBA(new Color(297 - base.NPC.alpha, 297 - base.NPC.alpha, 297 - base.NPC.alpha, 0), Color.White);
            Main.spriteBatch.Draw(base.Mod.GetTexture("NPCs/LanternMoon/FireFly"), vector2, new Rectangle?(base.NPC.frame), color, base.NPC.rotation, vector, 1f, effects, 0f);
            return false;
        }
        public bool decide;
	}
}
