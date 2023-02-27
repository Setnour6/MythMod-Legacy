using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using Terraria.ID;
namespace MythMod.Projectiles.projectile2
{
    //135596
    public class FireworkSliverMeteorBreak : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("烟花火球银流星散裂");
        }
        //7359668
        public override void SetDefaults()
        {
            projectile.width = 7;
            projectile.height = 7;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.extraUpdates = 3;
            projectile.timeLeft = 900;
            projectile.alpha = 0;
            projectile.penetrate = -1;
            projectile.scale = 1.4f;
            this.cooldownSlot = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 90;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }
        //55555
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(255, 255, 255, base.projectile.alpha));
        }
        private bool initialization = true;
        private double X;
        private float Y;
        private float b;
        private float z;
        public override void AI()
        {
            projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y,(double)projectile.velocity.X) + 1.57f;
            if (initialization)
            {
                if (projectile.velocity.Length() >= 1)
                {
                    z = projectile.velocity.Length();
                }
                else
                {
                    z = 1;
                }
                X = (float)Math.Sqrt((double)projectile.velocity.X * (double)projectile.velocity.X + (double)projectile.velocity.Y * (double)projectile.velocity.Y);
                b = Main.rand.Next(-50, 50);
                initialization = false;
                if(Main.rand.Next(0,2) == 1)
                {
                    Y = (float)Math.Sin((double)X / 5f * 3.1415926535f / 1f) / 1000 + 1;
                }
                else
                {
                    Y = (float)Math.Sin(-(double)X / 5f * 3.1415926535f / 1f) / 1000 + 1;
                }
            }
            if (projectile.timeLeft < 780)
            {
                if (Main.rand.Next(135) == 1)
                {
                    int num = Main.rand.Next(3, 5);
                    for (int u = 0; u < num; u++)
                    {
                        float a = (float)Main.rand.Next(0, 720) / 360 * 3.141592653589793238f;
                        float m = (float)Main.rand.Next(0, 15000);
                        float l = (float)Main.rand.Next((int)m, 50000) / 60000f * projectile.scale;
                        int num2 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) + base.projectile.velocity.X, (float)((float)l * Math.Sin((float)a)) + base.projectile.velocity.Y, base.mod.ProjectileType("FireworkSliverMeteor"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                        Main.projectile[num2].scale = projectile.scale * 0.75f;
                        Main.projectile[num2].timeLeft = 600;
                    }
                    Main.PlaySound(2, (int)base.projectile.Center.X, (int)base.projectile.Center.Y, 14, 0.6f, 0f);
                    projectile.velocity = new Vector2(0, 0);
                    projectile.timeLeft = 60;
                }
            }
            projectile.velocity *= 0.995f;
            NPC target = null;
            if (projectile.timeLeft < 700 && projectile.timeLeft >= 685)
            {
                if (Y < 1)
                {
                    projectile.scale *= (float)Y / (projectile.timeLeft / 685);
                }
                else
                {
                    projectile.scale *= (float)Y * projectile.timeLeft / 685;
                }
            }
            if (projectile.timeLeft < 685 && projectile.timeLeft >= 480 + (float)b)
            {
                projectile.scale *= (float)Y;
            }
            if (projectile.timeLeft < 480+ (float)b)
            {
                projectile.scale *= 0.994f;
            }
            projectile.velocity.Y += 0.01f;
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 1f / 255f * projectile.scale, (float)(255 - base.projectile.alpha) * 1f / 255f * projectile.scale, (float)(255 - base.projectile.alpha) * 1f / 255f *projectile.scale);
        }
        //14141414141414
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(24, 1200);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D t = base.mod.GetTexture("Projectiles/烟花火球金棕色尾迹");
             int frameHeight = 14;
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(1f, projectile.gfxOffY);
                Color color = new Color(255,255,255, 0) * ((float)(projectile.oldPos.Length - k * k / 90) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(t, drawPos, new Rectangle(0, frameHeight * projectile.frame,14, frameHeight), color, projectile.rotation, drawOrigin, projectile.scale * 0.5f, SpriteEffects.None, 0f);
            }
            if (projectile.timeLeft >= 300)
            {
                spriteBatch.Draw(base.mod.GetTexture("Projectiles/烟花火球银light"), base.projectile.Center - Main.screenPosition, null, new Color(projectile.scale * (projectile.timeLeft - 300) / (2400f * z * z), projectile.scale * (projectile.timeLeft - 300) / (2400f * z * z), projectile.scale * (projectile.timeLeft - 300) / (2400f * z * z), 0), base.projectile.rotation, new Vector2(56f, 56f), 1 + (800 - projectile.timeLeft) / 200f * z, SpriteEffects.None, 0f);
            }
            return true;
		}
    }
}