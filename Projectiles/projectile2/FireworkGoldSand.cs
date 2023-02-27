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
    public class FireworkGoldSand : ModProjectile
    {
        //4444444
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("烟花火球金沙");
        }
        //7359668
        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 2;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.extraUpdates = 3;
            projectile.timeLeft = 600;
            projectile.alpha = 105;
            projectile.penetrate = -1;
            projectile.scale = 1;
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
            projectile.velocity *= 0.995f;
            NPC target = null;
            if (projectile.timeLeft < 595)
            {
                Vector2 vector = base.projectile.position;
                int num = Dust.NewDust(vector, 2, 2, 108, 0f, 0f, 0, default(Color), (float)projectile.scale * 0.4f);
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
            if(projectile.timeLeft < 480)
            {
                if(Main.rand.Next(15) == 1)
                {
                    projectile.timeLeft = 0;
                }
            }
            if (projectile.timeLeft < 580 && projectile.timeLeft >= 100+ (float)b)
            {
                projectile.scale *= (float)Y;
            }
            if (projectile.timeLeft < 100+ (float)b)
            {
                projectile.scale *= 0.95f;
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
			return false;
        }
        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 100; k++)
            {
                Vector2 v = new Vector2(0, 150).RotatedByRandom(Math.PI * 2f);
                v = v * Main.rand.Next(0, 200) / 40000f * projectile.scale;
                int num6 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y), 0, 0, 55, v.X, v.Y, 0, Color.White, 0.9f);
                Main.dust[num6].noGravity = false;
                Main.dust[num6].scale *= 0.8f;
                Main.dust[num6].velocity *= 0.975f;
                int num7 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y), 0, 0, 87, v.X, v.Y, 0, Color.White, 0.9f);
                Main.dust[num7].noGravity = false;
                Main.dust[num7].scale *= 0.8f;
                Main.dust[num7].velocity *= 0.975f;
            }
            Main.PlaySound(2, (int)base.projectile.Center.X, (int)base.projectile.Center.Y, 14, 0.6f, 0f);
        }
    }
}