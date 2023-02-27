﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile4
{
	public class BrokenTusk : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("碎齿片");
            Main.projFrames[projectile.type] = 8;
		}
		public override void SetDefaults()
		{
			base.projectile.width = 24;
			base.projectile.height = 28;
			base.projectile.friendly = true;
			base.projectile.alpha = 0;
			base.projectile.penetrate = 1;
			base.projectile.tileCollide = true;
			base.projectile.timeLeft = 9000;
            projectile.damage = 0;

        }
        public float num2 = 0;
        public override void AI()
        {
            if(projectile.timeLeft == 8999)
            {
                projectile.timeLeft = Main.rand.Next(600, 1000);
                projectile.frame = Main.rand.Next(7);
            }
            if(num2 == 0)
            {
                num2 = Main.rand.Next(-100, 100) / 1000f;
            }
            if(projectile.velocity.Length() > 0.1f)
            {
                base.projectile.frameCounter++;
                if (base.projectile.frameCounter > 6)
                {
                    base.projectile.frame++;
                    base.projectile.frameCounter = 0;
                }
                if (base.projectile.frame > 7)
                {
                    base.projectile.frame = 0;
                }
            }
            projectile.rotation += num2;



            if (projectile.timeLeft > 60)
            {
                projectile.velocity.Y += 0.25f;
                projectile.velocity.X += (float)(Math.Sin(projectile.timeLeft / 30f)) * 0.035f;
            }
            if (projectile.timeLeft >= 60)
            {
                projectile.alpha = 0;
            }
            else
            {
                projectile.alpha = (int)((60 - projectile.timeLeft) / 60f * 255f);
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if(projectile.velocity.Length() < 2f)
            {
                projectile.timeLeft = 60;
                projectile.velocity *= 0;
            }
            else
            {
                if (base.projectile.velocity.X != oldVelocity.X)
                {
                    base.projectile.velocity.X = oldVelocity.X * 0.4f;
                }
                if (base.projectile.velocity.Y != oldVelocity.Y)
                {
                    base.projectile.velocity.Y = -oldVelocity.Y * 0.4f;
                }
            }
            return false;
        }
        /*public override Color? GetAlpha(Color lightColor)
        {
            if (projectile.timeLeft > 60)
            {
                return new Color?(new Color(1f,1f,1f,1f));
            }
            else
            {
                return new Color?(new Color(1f * projectile.timeLeft / 60f, 1f * projectile.timeLeft / 60f, 1f * projectile.timeLeft / 60f, 1f * projectile.timeLeft / 60f));
            }
        }*/
        /*public override void Kill(int timeLeft)
		{
            Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 37, 0.5f, 0f);
        }*/
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            Color color = Lighting.GetColor((int)(projectile.Center.X / 16d), (int)(projectile.Center.Y / 16d));
            color = projectile.GetAlpha(color) * ((255 - projectile.alpha) / 255f);
            int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
            int y = num * base.projectile.frame;
            Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY + projectile.height / 2f), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), color, base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}