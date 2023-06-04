using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class HighPowerBubble : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("高能气泡");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 6;
			base.Projectile.height = 6;
			base.Projectile.hostile = false;
			base.Projectile.friendly = true;
			base.Projectile.ignoreWater = false;
			base.Projectile.tileCollide = true;
			base.Projectile.alpha = 255;
			base.Projectile.penetrate = 1;
			base.Projectile.extraUpdates = 1;
			base.Projectile.timeLeft = 180;
			this.CooldownSlot = 1;
		}
		public override void AI()
		{
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0.05f / 255f, (float)(255 - base.Projectile.alpha) * 0.5f / 255f);
			if (base.Projectile.ai[0] == 0f)
			{
				base.Projectile.ai[0] = 1f;
				SoundEngine.PlaySound(SoundID.Item12, new Vector2(base.Projectile.position.X, base.Projectile.position.Y));
			}
			if (base.Projectile.alpha > 0)
			{
				base.Projectile.alpha -= 25;
			}
			if (base.Projectile.alpha < 0)
			{
				base.Projectile.alpha = 0;
			}
			float num = 50f;
			float num2 = 1.5f;
			if (base.Projectile.ai[1] == 0f)
			{
				base.Projectile.localAI[0] += num2;
				if (base.Projectile.localAI[0] > num)
				{
					base.Projectile.localAI[0] = num;
					return;
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
            if(Projectile.wet)
            {
                Projectile.velocity.Y -= 0.3f;
            }
            else
            {
                Projectile.timeLeft -= 1;
            }
            Projectile.velocity *= 0.97f;
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 15; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0.5f, 4f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 29, 0f, 0f, 100, Color.White, 0.8f);
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(0, 105, 255, 0));
        }
	}
}
