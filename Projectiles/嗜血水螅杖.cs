using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
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
            // base.DisplayName.SetDefault("嗜血水螅杖");
            ProjectileID.Sets.MinionSacrificable[base.Projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[base.Projectile.type] = true;
            Main.projFrames[base.Projectile.type] = 5;
        }
        public override void SetDefaults()
        {
            base.Projectile.width = 26;
            base.Projectile.height = 28;
            base.Projectile.netImportant = true;
            base.Projectile.friendly = true;
            base.Projectile.minionSlots = 1f;
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
        public override void PostDraw(Color lightColor)
        {
            Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num17 = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
            int y = num17 * base.Projectile.frame;
            Vector2 origin = new Vector2(13f, 14f);
            spriteBatch.Draw(base.Mod.GetTexture("Projectiles/嗜血水螅杖Glow"), base.Projectile.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, y, texture2D.Width, num17)), Color.White, base.Projectile.rotation, origin, base.Projectile.scale, SpriteEffects.None, 0f);
        }
        public override void AI()
        {
            if (base.Projectile.frameCounter > 5)
            {
                num16 += 0.15f;
                base.Projectile.frame = (int)num16;
                base.Projectile.frameCounter = 0;
            }
            if (base.Projectile.frame > 4)
            {
                base.Projectile.frame = 0;
                num16 = 0;
            }
            bool flag2 = base.Projectile.type == base.Mod.Find<ModProjectile>("嗜血水螅杖").Type;
            Player player = Main.player[base.Projectile.owner];
            MythPlayer modPlayer = player.GetModPlayer<MythPlayer>();
            player.AddBuff(base.Mod.Find<ModBuff>("SXSXZ").Type, 3600, true);
            if (flag2)
            {
                if (player.dead)
                {
                    modPlayer.SXSXZ = false;
                }
                if (modPlayer.SXSXZ)
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
                    float num6 = Main.npc[j].position.Y - (float)(Main.npc[j].height / 2) - 150f;
                    float num14 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    float num7 = Math.Abs(base.Projectile.position.X + (float)(base.Projectile.width / 2) - num15) + Math.Abs(base.Projectile.position.Y + (float)(base.Projectile.height / 2) - num6);
                    if (num7 < num4)
                    {
                        num4 = num7;
                        num2 = num15;
                        num3 = num6;
                        flag = true;
                    }
                    float num20 = Projectile.wet ? 200f : 400f;
                    float num21 = Projectile.wet ? 14f : 30f;
                    if (num12 % num21 == 0 && num12 % (num21 * 6) != 0 && flag && num12 != 0 && num7 < num20)
                    {
                        float num13 = (float)Math.Sqrt((num5 - base.Projectile.Center.X) * (num5 - base.Projectile.Center.X) + (num14 - base.Projectile.Center.Y) * (num14 - base.Projectile.Center.Y));
                        Vector2 C = (new Vector2(num5, num14) - base.Projectile.Center) / num13 * 10f;
                        int i0 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, C.X + Main.npc[j].velocity.X / 2f, C.Y + Main.npc[j].velocity.Y / 12f, base.Mod.Find<ModProjectile>("胭脂射线2").Type, base.Projectile.damage, base.Projectile.knockBack, Main.myPlayer, 0f, 0f);
                        Main.projectile[i0].minion = true;
                    }
                    if (num12 % num21 == 0 && num12 % (num21 * 6) == 0 && flag && num12 != 0 && num7 < num20)
                    {
                        float num13 = (float)Math.Sqrt((num5 - base.Projectile.Center.X) * (num5 - base.Projectile.Center.X) + (num14 - base.Projectile.Center.Y) * (num14 - base.Projectile.Center.Y));
                        Vector2 C = (new Vector2(num5, num14) - base.Projectile.Center) / num13 * 10f;
                        int i0 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, C.X + Main.npc[j].velocity.X / 2f, C.Y + Main.npc[j].velocity.Y / 12f, base.Mod.Find<ModProjectile>("灿金射线3").Type, base.Projectile.damage, base.Projectile.knockBack, Main.myPlayer, 0f, 0f);
                        Main.projectile[i0].minion = true;
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
    }
}
