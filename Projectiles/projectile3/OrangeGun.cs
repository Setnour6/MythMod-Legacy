using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class OrangeGun : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("香橙子弹");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 12;
			base.Projectile.height = 12;
            Projectile.hostile = false;
            Projectile.friendly = true;
            base.Projectile.ignoreWater = true;
            base.Projectile.tileCollide = false;
            base.Projectile.alpha = 0;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 120;
		}
		public override void AI()
		{
            //projectile.timeLeft -= 1;
            if (base.Projectile.ai[0] == 0f)
            {
                base.Projectile.ai[0] = 1f;
            }
            float num = Projectile.timeLeft;
            if (base.Projectile.localAI[0] > num)
            {
                Projectile.ai[1] = 1;
            }
            float num2 = 1.5f;
            if (base.Projectile.ai[1] == 0f)
            {
                base.Projectile.localAI[0] += num2;
                if (base.Projectile.localAI[0] > num)
                {
                    Projectile.ai[1] = 1;
                    base.Projectile.localAI[0] = num;
                }
            }
            else
            {
                base.Projectile.localAI[0] -= num2;
                if (base.Projectile.localAI[0] <= 0f)
                {
                    base.Projectile.Kill();
                }
            }
            if(Projectile.timeLeft <= 0)
            {
                base.Projectile.Kill();
            }
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.35f / 255f, (float)(255 - base.Projectile.alpha) * 0.15f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f);
		}
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(100, 100, 100, 0));
		}
        public override bool PreDraw(ref Color lightColor)
        {
            Color color = Lighting.GetColor((int)((double)base.Projectile.position.X + (double)base.Projectile.width * 0.5) / 16, (int)(((double)base.Projectile.position.Y + (double)base.Projectile.height * 0.5) / 16.0));
            int num = 0;
            int num2 = 0;
            float num3 = (float)(TextureAssets.Projectile[base.Projectile.type].Value.Width - base.Projectile.width) * 0.5f + (float)base.Projectile.width * 0.5f;
            SpriteEffects effects = SpriteEffects.None;
            if (base.Projectile.spriteDirection == -1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Rectangle value = new Rectangle((int)Main.screenPosition.X - 500, (int)Main.screenPosition.Y - 500, Main.screenWidth + 1000, Main.screenHeight + 1000);
            if (base.Projectile.getRect().Intersects(value))
            {
                Vector2 value2 = new Vector2(base.Projectile.position.X - Main.screenPosition.X + num3 + (float)num2, base.Projectile.position.Y - Main.screenPosition.Y + (float)(base.Projectile.height / 2) + base.Projectile.gfxOffY);
                float num4 = 25f;
                if (base.Projectile.timeLeft < 60)
                {
                    num4 = 25f / 60f * (float)base.Projectile.timeLeft;
                }
                float scaleFactor = 1.5f;
                if (base.Projectile.ai[1] == 1f)
                {
                    num4 = (float)((int)base.Projectile.localAI[0]);
                }
                for (int i = 1; i <= (int)base.Projectile.localAI[0]; i++)
                {
                    Vector2 value3 = Vector2.Normalize(base.Projectile.velocity) * (float)i * scaleFactor;
                    Color color2 = base.Projectile.GetAlpha(color);
                    color2 *= (num4 - (float)i) / num4;
                    color2.A = 0;
                    Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, value2 - value3, null, color2, base.Projectile.rotation, new Vector2(num3, (float)(base.Projectile.height / 2 + num)), base.Projectile.scale, effects, 0f);
                }
            }
            return false;
        }
    }
}
