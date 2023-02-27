using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles.projectile3
{
    public class FreezeFeather : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("冰羽");
        }
        public override void SetDefaults()
        {
            projectile.width = 34;
            projectile.height = 34;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.magic = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.timeLeft = 1080;
            projectile.alpha = 0;
            projectile.penetrate = 1;
            projectile.scale = 1;
        }
        private bool initialization = true;
        private double X;
        private float Omega;
        private float b;
        public override void AI()
        {
            projectile.rotation = (float)(Math.Atan2(projectile.velocity.Y, projectile.velocity.X));
            projectile.velocity *= 1.01f;
            int num90 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4) - base.projectile.velocity, 0, 0, 88, 0f, 0f, 100, default(Color), 1.2f);
            Main.dust[num90].noGravity = true;
            Main.dust[num90].velocity *= 0.0f;
            float num2 = base.projectile.Center.X;
            float num3 = base.projectile.Center.Y;
            float num4 = 400f;
            bool flag = false;
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    float num7 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num5) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num6);
                    if (num7 < num4)
                    {
                        num4 = num7;
                        num2 = num5;
                        num3 = num6;
                        flag = true;
                    }
                }
            }
            if (flag)
            {
                float num8 = 20f;
                Vector2 vector1 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
                float num9 = num2 - vector1.X;
                float num10 = num3 - vector1.Y;
                float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                num11 = num8 / num11;
                num9 *= num11;
                num10 *= num11;
                base.projectile.velocity.X = (base.projectile.velocity.X * 200f + num9) / 201f;
                base.projectile.velocity.Y = (base.projectile.velocity.Y * 200f + num10) / 201f;
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27, 1f, 0f);
            for (int k = 0; k <= 5; k++)
            {
                float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                float m = (float)Main.rand.Next(0, 50000);
                float l = (float)Main.rand.Next((int)m, 50000) / 1800f;
                int num4 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.06f, (float)((float)l * Math.Sin((float)a)) * 0.06f, base.mod.ProjectileType("FreezeBallBrake"), base.projectile.damage / 5, base.projectile.knockBack, base.projectile.owner, 0f, 20);
                Main.projectile[num4].timeLeft = (int)(projectile.damage * Main.rand.NextFloat(0.2f, 0.7f));
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            if (projectile.timeLeft > 60)
            {
                return new Color?(new Color(255, 255, 255, 100));
            }
            else
            {
                return new Color?(new Color((float)projectile.timeLeft / 60f, (float)projectile.timeLeft / 60f, (float)projectile.timeLeft / 60f, (float)projectile.timeLeft / 60f * 100f / 255f));
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Mod mod = ModLoader.GetMod("MythMod");
            Texture2D texture = Main.projectileTexture[projectile.type];
            Main.spriteBatch.Draw(texture, projectile.Center - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), null, projectile.GetAlpha(drawColor), projectile.rotation, new Vector2(17, 7), projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}