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
    public class BoneFeather : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("骨羽");
        }
        public override void SetDefaults()
        {
            projectile.width = 34;
            projectile.height = 34;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = true;
            projectile.magic = true;
            projectile.tileCollide = true;
            projectile.timeLeft = 1080;
            projectile.alpha = 0;
            projectile.penetrate = 12;
            projectile.scale = 1;
        }
        private bool initialization = true;
        private bool stick = false;
        private int u = 0;
        private NPC m = Main.npc[0];
        private Vector2 v = new Vector2(0, 0);
        private int r = 0;
        private float r2 = 0;
        public override void AI()
        {
            projectile.rotation = (float)(Math.Atan2(projectile.velocity.Y, projectile.velocity.X));
            projectile.velocity *= 1.01f;
            if(Main.rand.Next(6) == 1)
            {
                int num90 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(12, 12) - base.projectile.velocity, 16, 16, 4, 0f, 0f, 100, default(Color), 1.2f);
                Main.dust[num90].noGravity = true;
                Main.dust[num90].velocity *= 0.5f;
            }
            if (stick && m.active)
            {
                r += 1;
                float yz = m.Hitbox.Width * m.Hitbox.Width + m.Hitbox.Height * m.Hitbox.Height;
                yz = (float)(Math.Sqrt(yz)) / 3f;
                projectile.position = m.Center - v * yz / v.Length();
                if (r % 20 == 0)
                {
                    Projectile.NewProjectile(m.Center.X, m.Center.Y, 0, 0, mod.ProjectileType("伤害"), projectile.damage / 8, 0f, Main.myPlayer, 0f, 0f);
                }
            }
            if (stick && !m.active)
            {
                projectile.active = false;
            }
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
                base.projectile.velocity.X = (base.projectile.velocity.X * 90f + num9) / 91f;
                base.projectile.velocity.Y = (base.projectile.velocity.Y * 90f + num10) / 91f;
            }
        }
        public override void Kill(int timeLeft)
        {
            for (int j = 0; j < 15; j++)
            {
                int num2 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 4, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num2].noGravity = true;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            stick = true;
            v = projectile.position - target.position;
            projectile.friendly = false;
            m = target;
            target.defense = (int)(target.defense * 0.96f);
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