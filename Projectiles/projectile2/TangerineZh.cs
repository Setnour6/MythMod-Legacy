using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
    public class TangerineZh : ModProjectile
    {
        private float num = 0;
        private float num16 = 0;
        private float num12 = 0;
        private int num18 = 0;
        public override void SetStaticDefaults()
        {
            base.DisplayName.SetDefault("桔子");
            ProjectileID.Sets.MinionSacrificable[base.Projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[base.Projectile.type] = true;
            Main.projFrames[base.Projectile.type] = 1;
        }
        public override void SetDefaults()
        {
            base.Projectile.width = 36;
            base.Projectile.height = 36;
            base.Projectile.netImportant = true;
            base.Projectile.friendly = true;
            base.Projectile.minionSlots = 1f;
            base.Projectile.aiStyle = -1;
            base.Projectile.timeLeft = 720000;
            base.Projectile.aiStyle = 54;
            base.Projectile.timeLeft *= 5;
            this.AIType = 317;
            base.Projectile.penetrate = -1;
            base.Projectile.minion = true;
            base.Projectile.tileCollide = false;
            base.Projectile.usesLocalNPCImmunity = true;
            base.Projectile.localNPCHitCooldown = 10;
        }
        public override void AI()
        {
            if (Projectile.wet)
            {
                Projectile.damage = 256;
            }
            else
            {
                Projectile.damage = 160;
            }
            bool flag2 = base.Projectile.type == base.Mod.Find<ModProjectile>("TangerineZh").Type;
            Player player = Main.player[base.Projectile.owner];
            MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            player.AddBuff(base.Mod.Find<ModBuff>("NJFZ").Type, 3600, true);
            if (flag2)
            {
                if (player.dead)
                {
                    modPlayer.NJFZ = false;
                }
                if (modPlayer.NJFZ)
                {
                    base.Projectile.timeLeft = 2;
                }
            }
            bool flag = false;
            float num2 = base.Projectile.Center.X;
            float num3 = base.Projectile.Center.Y;
            float num4 = 800f;
            if (Projectile.wet)
            {
                num4 = 1600f;
            }
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(base.Projectile, false) && Collision.CanHit(base.Projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num15 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2) + (float)Math.Sin(num12 / 120f) * 10f;
                    float num6 = Main.npc[j].position.Y - (float)(Main.npc[j].height / 2) - 200;
                    float num14 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    float num7 = Math.Abs(base.Projectile.position.X + (float)(base.Projectile.width / 2) - num15) + Math.Abs(base.Projectile.position.Y + (float)(base.Projectile.height / 2) - num6);
                    if (num7 < num4)
                    {
                        num4 = num7;
                        num2 = num15;
                        num3 = num6;
                        flag = true;
                    }
                    float num20 = 250f;
                    float num21 = 5;
                    if (num12 % num21 == 0 && num12 % (num21 * 6) != 0 && flag && num12 != 0 && num7 < num20)
                    {
                        float num13 = (float)Math.Sqrt((num5 - base.Projectile.Center.X) * (num5 - base.Projectile.Center.X) + (num14 - base.Projectile.Center.Y) * (num14 - base.Projectile.Center.Y));
                        Vector2 C = (new Vector2(num5, num14) - base.Projectile.Center) / num13 * 10f + Main.npc[j].velocity / 2f;
                        C = C.RotatedBy(Main.rand.NextFloat(-0.5f, 0.5f));
                        int t = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, C.X, C.Y, base.Mod.Find<ModProjectile>("TenderGreenRay").Type, base.Projectile.damage, base.Projectile.knockBack, Main.myPlayer, 0f, 0f);
                        Main.projectile[t].timeLeft = 60;
                    }
                    if (num12 % num21 == 0 && num12 % (num21 * 6) == 0 && flag && num12 != 0 && num7 < num20)
                    {
                        float num13 = (float)Math.Sqrt((num5 - base.Projectile.Center.X) * (num5 - base.Projectile.Center.X) + (num14 - base.Projectile.Center.Y) * (num14 - base.Projectile.Center.Y));
                        Vector2 C = (new Vector2(num5, num14) - base.Projectile.Center) / num13 * 10f + Main.npc[j].velocity / 2f;
                        C = C.RotatedBy(Main.rand.NextFloat(-0.5f, 0.5f));
                        int t = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, C.X, C.Y, base.Mod.Find<ModProjectile>("TangerineRay").Type, base.Projectile.damage, base.Projectile.knockBack, Main.myPlayer, 0f, 0f);
                        Main.projectile[t].timeLeft = 60;
                    }
                }
                else
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        base.Projectile.velocity.X += (float)(Main.rand.Next(0, 4) / 150f);
                        base.Projectile.velocity.Y += (float)(Main.rand.Next(0, 4) / 150f);
                    }
                    else
                    {
                        base.Projectile.velocity.X -= (float)(Main.rand.Next(0, 4) / 150f);
                        base.Projectile.velocity.Y -= (float)(Main.rand.Next(0, 4) / 150f);
                    }
                }
            }
            if (flag)
            {
                float num8 = 20f;
                Vector2 vector3 = new Vector2(base.Projectile.position.X + (float)base.Projectile.width * 0.5f, base.Projectile.position.Y + (float)base.Projectile.height * 0.5f);
                float num9 = num2 - vector3.X;
                float num10 = num3 - vector3.Y;
                float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                num11 = num8 / num11;
                num9 *= num11;
                num10 *= num11;
                base.Projectile.velocity.X = (base.Projectile.velocity.X * 5f + num9) / 6f;
                base.Projectile.velocity.Y = (base.Projectile.velocity.Y * 5f + num10) / 6f;
                num12 += 1;
            }
            else
            {
                int num5 = (int)Player.FindClosest(base.Projectile.Center, 1, 1);
                float num6 = (float)Math.Sqrt((Main.player[num5].Center.X - base.Projectile.Center.X) * (Main.player[num5].Center.X - base.Projectile.Center.X) + (Main.player[num5].Center.Y - base.Projectile.Center.Y) * (Main.player[num5].Center.Y - base.Projectile.Center.Y));
                if (num2 % 200 > 100 && num6 < 100f)
                {
                    if (Math.Abs(base.Projectile.velocity.X) + Math.Abs(base.Projectile.velocity.Y) < 10f)
                    {
                        base.Projectile.velocity *= 1.2f;
                    }
                    if (Math.Abs(base.Projectile.velocity.X) + Math.Abs(base.Projectile.velocity.Y) > 12f)
                    {
                        base.Projectile.velocity *= 0.96f;
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
                    Projectile.velocity = Projectile.velocity.RotatedBy(Math.PI * num / 1000f);
                }
                else
                {
                    if (Math.Abs(base.Projectile.velocity.X) + Math.Abs(base.Projectile.velocity.Y) < 10f)
                    {
                        base.Projectile.velocity *= 1.2f;
                    }
                    if (Math.Abs(base.Projectile.velocity.X) + Math.Abs(base.Projectile.velocity.Y) > 12f)
                    {
                        base.Projectile.velocity *= 0.96f;
                    }
                    Projectile.velocity = Projectile.velocity * 0.9f + (Main.player[num5].Center - base.Projectile.Center) / num6 * 0.4f;
                }
            }
        }
        public override void PostDraw(Color lightColor)
        {
            spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile2/桔子ZhGlow"), base.Projectile.Center - Main.screenPosition, null, Color.White * 0.7f, base.Projectile.rotation, new Vector2(18f, 18f), 1f, SpriteEffects.None, 0f);
        }
    }
}
