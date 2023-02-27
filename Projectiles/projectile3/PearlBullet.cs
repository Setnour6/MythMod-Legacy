using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class PearlBullet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("珍珠弹");
			Main.projFrames[base.projectile.type] = 1;
		}
		public override void SetDefaults()
		{
			base.projectile.width = 10;
			base.projectile.height = 10;
			base.projectile.hostile = false;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 900;
            base.projectile.alpha = 0;
            base.projectile.friendly = true;
			this.cooldownSlot = 1;
		}
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 173f / 255f / 255f, (float)(255 - base.projectile.alpha) * 107f / 255f / 255f, (float)(255 - base.projectile.alpha) * 83f / 255f / 255f);
			base.projectile.spriteDirection = 1;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X);
            if(projectile.velocity.Length() < 12f)
            {
                projectile.velocity *= 12f / projectile.velocity.Length();
            }
            if(Main.rand.Next(150) == 1)
            {
                for(int i = 0;i < 4;i++)
                {
                    Vector2 v = projectile.velocity + new Vector2(0, Main.rand.NextFloat(0, 8)).RotatedByRandom(MathHelper.TwoPi);
                    Projectile.NewProjectile(projectile.Center, v, mod.ProjectileType("PearlBullet2"), projectile.damage, 1);
                }
                projectile.Kill();
            }
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
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
            for (int i = 0; i < 15; i++)
            {
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 51, projectile.velocity.X * 0.8f, projectile.velocity.Y * 0.8f, 100, default(Color), 1f);
            }
        }
    }
}
