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
namespace MythMod.Projectiles.projectile2
{
    //135596
    public class LanternBoomF : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("爆炸大灯笼");
        }
        //7359668
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.extraUpdates = 3;
            projectile.timeLeft = 1000;
            projectile.alpha = 0;
            projectile.penetrate = 2;
            projectile.scale = 1f;
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
        public override void AI()
        {
            if (initialization)
            {
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
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) - (float)Math.PI * 0.5f;
            projectile.velocity *= 0.995f;
            if (projectile.timeLeft < 995)
            {
                Vector2 vector = base.projectile.Center - new Vector2(4, 4);
                int num = Dust.NewDust(vector, 2, 2, 102, 0f, 0f, 0, default(Color), (float)projectile.scale * 1.8f);
                Main.dust[num].velocity *= 0.0f;
                Main.dust[num].noGravity = true;
                Main.dust[num].scale *=  1.2f;
                Main.dust[num].alpha = 200;
            }
            if (projectile.timeLeft < 600 && projectile.timeLeft >= 585)
            {
                if (Y < 1)
                {
                    projectile.scale *= (float)Y / (projectile.timeLeft / 585);
                }
                else
                {
                    projectile.scale *= (float)Y * projectile.timeLeft / 585;
                }
            }
            if (projectile.timeLeft < 580 && projectile.timeLeft >= 100 + (float)b)
            {
                projectile.scale *= (float)Y;
            }
            if (projectile.timeLeft < 100+ (float)b)
            {
                projectile.scale *= 0.95f;
            }
            projectile.velocity.Y += 0.01f;
            projectile.velocity.Y += 0.01f;
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.8f / 255f * projectile.scale, (float)(255 - base.projectile.alpha) * 0.2f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f * projectile.scale);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height;
			Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 1f);
			return false;
		}
        public override void Kill(int timeLeft)
        {
            if (timeLeft != 0)
            {
                int uo = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, 164, -10, 1, Main.myPlayer, 0f, 0f);
                Main.projectile[uo].friendly = true;
                Main.projectile[uo].hostile = false;
            }
        }
    }
}