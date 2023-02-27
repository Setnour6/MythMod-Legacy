using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
    public class CrackStar : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("爆炸星星");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 6;
			base.projectile.height = 6;
			base.projectile.hostile = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 80;
            base.projectile.friendly = false;
			this.cooldownSlot = 1;
		}
		public override void AI()
		{
			if(base.projectile.timeLeft < 80 && base.projectile.timeLeft > 60)
			{
				base.projectile.scale += 0.05f;
			}
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f);
			base.projectile.velocity *= 0f;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
		}
		public override void Kill(int timeLeft)
		{
			float m = (float)Main.rand.Next(0, 50000) / 25000f;
			Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 20, 1f, 0f);
			for (int k = 0; k <= 5; k++)
			{
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y,(float)Math.Sin(((float)k + (float)m) / 2.5f * Math.PI) * 5f, (float)Math.Cos(((float)k + (float)m) / 2.5f * Math.PI) * 5f, base.mod.ProjectileType("星散裂"), 555, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
			}
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
			int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
			int y = num * base.projectile.frame;
			Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
	}
}
