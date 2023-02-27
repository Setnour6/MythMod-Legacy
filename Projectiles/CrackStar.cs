using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
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
			base.Projectile.width = 6;
			base.Projectile.height = 6;
			base.Projectile.hostile = true;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 80;
            base.Projectile.friendly = false;
			this.CooldownSlot = 1;
		}
		public override void AI()
		{
			if(base.Projectile.timeLeft < 80 && base.Projectile.timeLeft > 60)
			{
				base.Projectile.scale += 0.05f;
			}
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f);
			base.Projectile.velocity *= 0f;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.Projectile.alpha));
		}
		public override void Kill(int timeLeft)
		{
			float m = (float)Main.rand.Next(0, 50000) / 25000f;
			SoundEngine.PlaySound(SoundID.Item20, new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
			for (int k = 0; k <= 5; k++)
			{
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y,(float)Math.Sin(((float)k + (float)m) / 2.5f * Math.PI) * 5f, (float)Math.Cos(((float)k + (float)m) / 2.5f * Math.PI) * 5f, base.Mod.Find<ModProjectile>("星散裂").Type, 555, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
			}
		}
		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
			int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
			int y = num * base.Projectile.frame;
			Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
	}
}
