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
namespace MythMod.Projectiles
{
    //135596
    public class FireworkRedToGreen : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("烟花火球红变绿");
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
            projectile.timeLeft = 300;
            projectile.alpha = 105;
            projectile.penetrate = -1;
            projectile.scale = 0.7f;
            this.cooldownSlot = 1;
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
            if (initialization)
            {
                X = (float)Math.Sqrt((double)projectile.velocity.X * (double)projectile.velocity.X + (double)projectile.velocity.Y * (double)projectile.velocity.Y);
                if (projectile.velocity.Length() >= 1)
                {
                    z = projectile.velocity.Length();
                }
                else
                {
                    z = 1;
                }
                b = Main.rand.Next(-25, 25);
                initialization = false;
                if (Main.rand.Next(0, 2) == 1)
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
            if (projectile.timeLeft < 295)
            {
                Vector2 vector = base.projectile.position;
                int num = Dust.NewDust(vector, 2, 2, 188, 0f, 0f, 0, default(Color), (float)projectile.scale);
                Main.dust[num].velocity *= 0.0f;
                Main.dust[num].noGravity = true;
                Main.dust[num].scale *= 1.2f;
                Main.dust[num].alpha = 200;
            }
            if (projectile.timeLeft < 300 && projectile.timeLeft >= 285)
            {
                if (Y < 1)
                {
                    projectile.scale *= (float)Y / (projectile.timeLeft / 285);
                }
                else
                {
                    projectile.scale *= (float)Y * projectile.timeLeft / 285;
                }
            }
            if (projectile.timeLeft < 280 && projectile.timeLeft >= 70 + (float)b)
            {
                projectile.scale *= (float)Y;
            }
            if (projectile.timeLeft < 70 + (float)b)
            {
                projectile.scale *= 0.95f;
            }
            if (projectile.timeLeft == 49 + (float)b)
            {
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, base.mod.ProjectileType("FireworkGreen2"), base.projectile.damage / 20, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
            }
            projectile.velocity.Y += 0.01f;
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 1f / 255f * projectile.scale, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f * projectile.scale);
        }
        //14141414141414
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(24, 1200);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height;
            Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 1f);
            spriteBatch.Draw(base.mod.GetTexture("Projectiles/烟花火球红light"), base.projectile.Center - Main.screenPosition, null, new Color(projectile.scale * (projectile.timeLeft) / (1200f * z * z), projectile.scale * (projectile.timeLeft) / (1200f * z * z), projectile.scale * (projectile.timeLeft) / (1200f * z * z), 0), base.projectile.rotation, new Vector2(56f, 56f), 1 + (500 - projectile.timeLeft) / 200f * z, SpriteEffects.None, 0f);
            return false;
        }
        public override void Kill(int timeLeft)
        {
        }
    }
}