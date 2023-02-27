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
namespace MythMod.Projectiles
{
    //135596
    public class FireworkGreenGoldTrade : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("烟花火球绿金色尾迹");
        }
        //7359668
        public override void SetDefaults()
        {
            projectile.width = 6;
            projectile.height = 6;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.extraUpdates = 3;
            projectile.timeLeft = 1000;
            projectile.alpha = 0;
            projectile.penetrate = -1;
            projectile.scale = 1f;
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
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 1f / 255f * projectile.scale, (float)(255 - base.projectile.alpha) * 0.3f / 255f * projectile.scale, (float)(255 - base.projectile.alpha) * 0f / 255f *projectile.scale);
        }
        //14141414141414
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(24, 1200);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D t = base.mod.GetTexture("Projectiles/烟花火球金色尾迹");
             int frameHeight = 14;
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(1f, projectile.gfxOffY);
                Color color = (Color.Wheat * 0.2f) * ((float)(projectile.oldPos.Length - k * k / 90) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(t, drawPos, new Rectangle(0, frameHeight * projectile.frame,14, frameHeight), color, projectile.rotation, drawOrigin, projectile.scale * 0.5f, SpriteEffects.None, 0f);
            }
            if (projectile.timeLeft >= 300)
            {
                spriteBatch.Draw(base.mod.GetTexture("Projectiles/烟花火球绿light"), base.projectile.Center - Main.screenPosition, null, new Color(projectile.scale * (projectile.timeLeft - 700) / (2400f * z * z), projectile.scale * (projectile.timeLeft - 700) / (2400f * z * z), projectile.scale * (projectile.timeLeft - 700) / (2400f * z * z), 0), base.projectile.rotation, new Vector2(56f, 56f), 1 + (1200 - projectile.timeLeft) / 200f * z, SpriteEffects.None, 0f);
            }
            return true;
		}
    }
}