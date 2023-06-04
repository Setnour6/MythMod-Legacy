using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles
{
    public class 紫点海葵粒子 : ModProjectile
	{
		private bool num1 = true;
		private bool num4 = true;
		private float num = 0;
		private float num2 = 0;
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("海葵粒子");

            Main.projFrames[base.Projectile.type] = 1;
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 34;
            base.Projectile.scale = 1;
            base.Projectile.height = 34;
			base.Projectile.hostile = false;
            base.Projectile.friendly = true;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = -1;
			base.Projectile.timeLeft = 90;
			this.CooldownSlot = 1;
			ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 100;
            ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
		}
        private float num100 = 0;
		public override void AI()
		{
            if(Projectile.timeLeft == 85)
            {
                num100 = Main.rand.Next(-100,101) / 1000f;
            }
            if (Projectile.timeLeft == 70)
            {
                num100 = Main.rand.Next(-100, 101) / 1000f;
            }
            if (Projectile.timeLeft == 55)
            {
                num100 = Main.rand.Next(-100, 101) / 1000f;
            }
            if (Projectile.timeLeft < 90)
            {
                Projectile.scale *= 0.95f;
            }
            if (Projectile.timeLeft < 90 && Projectile.timeLeft > 50)
            {
                Projectile.velocity.Y += 0.1f;
            }
            if (Projectile.timeLeft < 75 && Projectile.timeLeft > 30)
            {
                Projectile.velocity = Projectile.velocity.RotatedBy(num100);
            }
            if (Projectile.timeLeft < 80)
			{
				base.Projectile.scale = (float)Projectile.timeLeft / 90;
				base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) + 1.57f;
			    Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.2f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0.9f / 255f);
			}
            else
			{
			    base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) + 1.57f;
			    Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.2f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0.9f / 255f);
			}
		}
        public override void Kill(int timeLeft)
		{
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(105, 50, 255, 0));
		}
        public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
			int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
			int y = num * base.Projectile.frame;
			SpriteEffects effects = SpriteEffects.None;
            if (base.Projectile.spriteDirection == 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
			int frameHeight = 34;
            Vector2 value = new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y);
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            Vector2 vector2 = value - Main.screenPosition;
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
				Vector2 drawPos = Projectile.oldPos[k / 6] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/紫点海葵粒子光效"), drawPos, new Rectangle(0, frameHeight * Projectile.frame, base.Mod.GetTexture("Projectiles/渊海磷光光效").Width, frameHeight), color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
		}
	}
}
