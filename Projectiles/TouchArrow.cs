using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader.IO;
namespace MythMod.Projectiles
{
    //135596
    public class TouchArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("触须箭");
        }
        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.extraUpdates = 21;
            projectile.timeLeft = 1300;
            projectile.alpha = 0;
            projectile.penetrate = 2;
            projectile.scale = 1f;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 500;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, base.projectile.alpha));
        }
        public override void AI()
        {
            projectile.rotation = (float)
            System.Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;

            Vector2 vector = projectile.Center - new Vector2(4, 4);
            if (projectile.timeLeft % 6 == 2)
            {
                int num13 = Dust.NewDust(vector, 3, 3, 262, 0f, 0f, 200, Color.Yellow, 0.7f);
                Main.dust[num13].velocity *= 0.0f;
                Main.dust[num13].noGravity = true;
            }
            if (projectile.timeLeft % 6 == 5)
            {
                int num13 = Dust.NewDust(vector, 3, 3, mod.DustType("GoldGlitter"), 0f, 0f, 200, Color.Yellow, 1.68f);
                Main.dust[num13].velocity *= 0.0f;
                Main.dust[num13].noGravity = true;
            }
            float num2 = base.projectile.Center.X;
            float num3 = base.projectile.Center.Y;
            float num4 = 500f;
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
                else
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        base.projectile.velocity.X += (float)(Main.rand.Next(0, 4) / 14500f);
                        base.projectile.velocity.Y += (float)(Main.rand.Next(0, 4) / 14500f);
                    }
                    else
                    {
                        base.projectile.velocity.X -= (float)(Main.rand.Next(0, 4) / 14500f);
                        base.projectile.velocity.Y -= (float)(Main.rand.Next(0, 4) / 14500f);
                    }
                }
            }
            if (flag && projectile.timeLeft % 120 > 80)
            {
                float num8 = 20f;
                Vector2 vector3 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
                float num9 = num2 - vector3.X;
                float num10 = num3 - vector3.Y;
                float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                num11 = num8 / num11;
                num9 *= num11;
                num10 *= num11;
                base.projectile.velocity.X = (base.projectile.velocity.X * 40f + num9) / 41f;
                base.projectile.velocity.Y = (base.projectile.velocity.Y * 40f + num10) / 41f;
            }
            if (projectile.timeLeft < 120)
            {
                projectile.tileCollide = true;
            }
            if (!flag)
            {
                projectile.velocity.Y += 0.000675f;
            }
            if (projectile.velocity.Length() > 3.3f)
            {
                projectile.velocity *= 3.3f / projectile.velocity.Length();
            }
            if (projectile.velocity.Length() < 1.6f)
            {
                projectile.velocity *= 1.6f / projectile.velocity.Length();
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D t = mod.GetTexture("Projectiles/SulfurFlame");
            Vector2 drawOrigin = new Vector2(10, 10);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY) + new Vector2(8, -8).RotatedBy(Math.Atan2(projectile.velocity.Y, projectile.velocity.X));
                Color color = (new Color(1f, 1f, 1f, 0) * 0.1f) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(t, drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale * 0.08f, SpriteEffects.None, 0f);
            }
            return true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for (int m = 0; m < 20; m++)
            {
                int num = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, mod.DustType("GoldGlitter"), base.projectile.velocity.X * 0f, base.projectile.velocity.Y * 0f, 150, new Color(Main.DiscoR, 100, 255), 2.8f);
                Main.dust[num].noGravity = true;
            }
            for (int k = 0; k < 7; k++)
            {
                Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 14, 1f, 0f);
                Vector2 v = projectile.velocity.RotatedBy(k * Math.PI / 3.5);
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, base.mod.ProjectileType("PoisonArrow"), base.projectile.damage / 2, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
            target.AddBuff(70, 1200);
            target.AddBuff(69, 1200);
        }
    }
}