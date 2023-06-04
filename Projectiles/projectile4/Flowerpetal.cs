using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile4
{
	public class Flowerpetal : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("落花");
            Main.projFrames[Projectile.type] = 8;
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 24;
			base.Projectile.height = 28;
			base.Projectile.friendly = true;
			base.Projectile.alpha = 0;
			base.Projectile.penetrate = 1;
			base.Projectile.tileCollide = true;
			base.Projectile.timeLeft = 9000;
		}
        public float num2 = 0;
        public override void AI()
        {
            if(Projectile.timeLeft == 8999)
            {
                Projectile.timeLeft = Main.rand.Next(600, 1000);
            }
            if(num2 == 0)
            {
                num2 = Main.rand.Next(-100, 100) / 1000f;
            }
            if(Projectile.velocity.Length() > 0.1f)
            {
                base.Projectile.frameCounter++;
                if (base.Projectile.frameCounter > 6)
                {
                    base.Projectile.frame++;
                    base.Projectile.frameCounter = 0;
                }
                if (base.Projectile.frame > 7)
                {
                    base.Projectile.frame = 0;
                }
            }
            Projectile.rotation += num2;
            if (Projectile.velocity.Length() < 3.6f && Projectile.timeLeft > 60)
            {
                Projectile.velocity.Y += 0.025f;
            }
            if (Projectile.timeLeft > 60)
            {
                Projectile.velocity.X += (float)(Math.Sin(Projectile.timeLeft / 30f)) * 0.035f;
            }
            if (Projectile.timeLeft >= 60)
            {
                Projectile.alpha = 0;
                Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.12f / 255f , (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0.12f / 255f);
            }
            else
            {
                Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.12f / 255f * Projectile.timeLeft / 60f, (float)(255 - base.Projectile.alpha) * 0f / 255f * Projectile.timeLeft / 60f, (float)(255 - base.Projectile.alpha) * 0.12f / 255f * Projectile.timeLeft / 60f);
                Projectile.alpha = (int)((60 - Projectile.timeLeft) / 60f * 255f);
            }
            if (Projectile.velocity.Length() > 3.6f)
            {
                Projectile.velocity *= 0.96f;
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.timeLeft = 60;
            Projectile.velocity *= 0;
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
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
		}
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
            int y = num * base.Projectile.frame;
            Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY + Projectile.height / 2f), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}
