using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class HighPowerBubble : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("高能气泡");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 6;
			base.projectile.height = 6;
			base.projectile.hostile = false;
			base.projectile.friendly = true;
			base.projectile.ignoreWater = false;
			base.projectile.tileCollide = true;
			base.projectile.alpha = 255;
			base.projectile.penetrate = 1;
			base.projectile.extraUpdates = 1;
			base.projectile.timeLeft = 180;
			this.cooldownSlot = 1;
		}
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 0.05f / 255f, (float)(255 - base.projectile.alpha) * 0.5f / 255f);
			if (base.projectile.ai[0] == 0f)
			{
				base.projectile.ai[0] = 1f;
				Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 12, 1f, 0f);
			}
			if (base.projectile.alpha > 0)
			{
				base.projectile.alpha -= 25;
			}
			if (base.projectile.alpha < 0)
			{
				base.projectile.alpha = 0;
			}
			float num = 50f;
			float num2 = 1.5f;
			if (base.projectile.ai[1] == 0f)
			{
				base.projectile.localAI[0] += num2;
				if (base.projectile.localAI[0] > num)
				{
					base.projectile.localAI[0] = num;
					return;
				}
			}
			else
			{
				base.projectile.localAI[0] -= num2;
				if (base.projectile.localAI[0] <= 0f)
				{
					base.projectile.Kill();
				}
			}
            if(projectile.wet)
            {
                projectile.velocity.Y -= 0.3f;
            }
            else
            {
                projectile.timeLeft -= 1;
            }
            projectile.velocity *= 0.97f;
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 15; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0.5f, 4f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 29, 0f, 0f, 100, Color.White, 0.8f);
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(0, 105, 255, 0));
        }
	}
}
