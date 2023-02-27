using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
    public class 嗜血水螅杖 : ModProjectile
    {
        private float num = 0;
        private float num16 = 0;
        private float num12 = 0;
        private int num18 = 0;
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("嗜血水螅杖");
            ProjectileID.Sets.MinionSacrificable[base.projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[base.projectile.type] = true;
            Main.projFrames[base.projectile.type] = 5;
        }
        public override void SetDefaults()
        {
            base.projectile.width = 26;
            base.projectile.height = 28;
            base.projectile.netImportant = true;
            base.projectile.friendly = true;
            base.projectile.minionSlots = 1f;
            base.projectile.timeLeft = 720000;
            base.projectile.aiStyle = 54;
            base.projectile.timeLeft *= 5;
            this.aiType = 317;
            base.projectile.penetrate = -1;
            base.projectile.minion = true;
            base.projectile.tileCollide = false;
            base.projectile.usesLocalNPCImmunity = true;
            base.projectile.localNPCHitCooldown = 10;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num17 = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
            int y = num17 * base.projectile.frame;
            Vector2 origin = new Vector2(13f, 14f);
            spriteBatch.Draw(base.mod.GetTexture("Projectiles/嗜血水螅杖Glow"), base.projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, y, texture2D.Width, num17)), Color.White, base.projectile.rotation, origin, base.projectile.scale, SpriteEffects.None, 0f);
        }
        public override void AI()
        {
            if (base.projectile.frameCounter > 5)
            {
                num16 += 0.15f;
                base.projectile.frame = (int)num16;
                base.projectile.frameCounter = 0;
            }
            if (base.projectile.frame > 4)
            {
                base.projectile.frame = 0;
                num16 = 0;
            }
            bool flag2 = base.projectile.type == base.mod.ProjectileType("嗜血水螅杖");
            Player player = Main.player[base.projectile.owner];
            MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            player.AddBuff(base.mod.BuffType("SXSXZ"), 3600, true);
            if (flag2)
            {
                if (player.dead)
                {
                    modPlayer.SXSXZ = false;
                }
                if (modPlayer.SXSXZ)
                {
                    base.projectile.timeLeft = 2;
                }
            }
            bool flag = false;
            float num2 = base.projectile.Center.X;
            float num3 = base.projectile.Center.Y;
            float num4 = 800f;
            if (projectile.wet)
            {
                num4 = 1600f;
            }
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num15 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2) + (float)Math.Sin(num12 / 120f) * 10f;
                    float num6 = Main.npc[j].position.Y - (float)(Main.npc[j].height / 2) - 150f;
                    float num14 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    float num7 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num15) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num6);
                    if (num7 < num4)
                    {
                        num4 = num7;
                        num2 = num15;
                        num3 = num6;
                        flag = true;
                    }
                    float num20 = projectile.wet ? 200f : 400f;
                    float num21 = projectile.wet ? 14f : 30f;
                    if (num12 % num21 == 0 && num12 % (num21 * 6) != 0 && flag && num12 != 0 && num7 < num20)
                    {
                        float num13 = (float)Math.Sqrt((num5 - base.projectile.Center.X) * (num5 - base.projectile.Center.X) + (num14 - base.projectile.Center.Y) * (num14 - base.projectile.Center.Y));
                        Vector2 C = (new Vector2(num5, num14) - base.projectile.Center) / num13 * 10f;
                        int i0 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, C.X + Main.npc[j].velocity.X / 2f, C.Y + Main.npc[j].velocity.Y / 12f, base.mod.ProjectileType("胭脂射线2"), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, 0f, 0f);
                        Main.projectile[i0].minion = true;
                    }
                    if (num12 % num21 == 0 && num12 % (num21 * 6) == 0 && flag && num12 != 0 && num7 < num20)
                    {
                        float num13 = (float)Math.Sqrt((num5 - base.projectile.Center.X) * (num5 - base.projectile.Center.X) + (num14 - base.projectile.Center.Y) * (num14 - base.projectile.Center.Y));
                        Vector2 C = (new Vector2(num5, num14) - base.projectile.Center) / num13 * 10f;
                        int i0 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, C.X + Main.npc[j].velocity.X / 2f, C.Y + Main.npc[j].velocity.Y / 12f, base.mod.ProjectileType("灿金射线3"), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, 0f, 0f);
                        Main.projectile[i0].minion = true;
                    }
                }
                else
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        base.projectile.velocity.X += (float)(Main.rand.Next(0, 4) / 150f);
                        base.projectile.velocity.Y += (float)(Main.rand.Next(0, 4) / 150f);
                    }
                    else
                    {
                        base.projectile.velocity.X -= (float)(Main.rand.Next(0, 4) / 150f);
                        base.projectile.velocity.Y -= (float)(Main.rand.Next(0, 4) / 150f);
                    }
                }
            }
            if (flag)
            {
                float num8 = 20f;
                Vector2 vector3 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
                float num9 = num2 - vector3.X;
                float num10 = num3 - vector3.Y;
                float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                num11 = num8 / num11;
                num9 *= num11;
                num10 *= num11;
                base.projectile.velocity.X = (base.projectile.velocity.X * 5f + num9) / 6f;
                base.projectile.velocity.Y = (base.projectile.velocity.Y * 5f + num10) / 6f;
                num12 += 1;
            }
            else
            {
                int num5 = (int)Player.FindClosest(base.projectile.Center, 1, 1);
                float num6 = (float)Math.Sqrt((Main.player[num5].Center.X - base.projectile.Center.X) * (Main.player[num5].Center.X - base.projectile.Center.X) + (Main.player[num5].Center.Y - base.projectile.Center.Y) * (Main.player[num5].Center.Y - base.projectile.Center.Y));
                if (num2 % 200 > 100 && num6 < 100f)
                {
                    if (Math.Abs(base.projectile.velocity.X) + Math.Abs(base.projectile.velocity.Y) < 10f)
                    {
                        base.projectile.velocity *= 1.2f;
                    }
                    if (Math.Abs(base.projectile.velocity.X) + Math.Abs(base.projectile.velocity.Y) > 12f)
                    {
                        base.projectile.velocity *= 0.96f;
                    }
                    if (num > 150)
                    {
                        num -= Main.rand.Next(0, 5);
                    }
                    else if (num < -150)
                    {
                        num += Main.rand.Next(0, 5);
                    }
                    else
                    {
                        num += Main.rand.Next(-5, 5);
                    }
                    projectile.velocity = projectile.velocity.RotatedBy(Math.PI * num / 1000f);
                }
                else
                {
                    if (Math.Abs(base.projectile.velocity.X) + Math.Abs(base.projectile.velocity.Y) < 10f)
                    {
                        base.projectile.velocity *= 1.2f;
                    }
                    if (Math.Abs(base.projectile.velocity.X) + Math.Abs(base.projectile.velocity.Y) > 12f)
                    {
                        base.projectile.velocity *= 0.96f;
                    }
                    projectile.velocity = projectile.velocity * 0.9f + (Main.player[num5].Center - base.projectile.Center) / num6 * 0.4f;
                }
            }
        }
    }
}
