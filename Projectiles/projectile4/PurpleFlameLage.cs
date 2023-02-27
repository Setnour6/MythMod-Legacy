using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles.projectile4
{
    public class PurpleFlameLage : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("紫冥鬼火");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 12;
			base.projectile.height = 12;
            projectile.hostile = false;
            projectile.friendly = true;
            base.projectile.ignoreWater = true;
            base.projectile.tileCollide = false;
            base.projectile.alpha = 0;
			base.projectile.penetrate = -1;
			base.projectile.timeLeft = 900;
            projectile.extraUpdates = 1;
        }
        public float scal = 1f;
        public float scalMax = 1f;
        public float scalx = 1f;
        public override void AI()
		{
            if(projectile.timeLeft == 900)
            {
                Sca = Main.rand.NextFloat(0.15f, 0.6f);
            }
            projectile.velocity *= 0;
            float x = (float)Main.rand.NextFloat(-10, 11) * 0.75f;
            float y = (float)Main.rand.NextFloat(-10, 1) * 1.75f;
            if (projectile.timeLeft < 180)
            {
                scalx *= 0.96f;
            }
            if(Main.rand.Next(180) == 1)
            {
                int r2 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(8, 8), 8, 8, 21, 0, Main.rand.NextFloat(-4.5f, -0.5f), 0, default(Color), 1f);
                Main.dust[r2].noGravity = true;
            }
            Lighting.AddLight(base.projectile.Center + new Vector2(x, y), (float)(255 - base.projectile.alpha) * 0.4f / 255f * scalx, (float)(255 - base.projectile.alpha) * 0.2f / 255f * scalx, (float)(255 - base.projectile.alpha) * 0.7f / 255f * scalx);
        }
        public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(100, 100, 100, 0));
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(153, 300);
        }
        public float k = 0;
        public float m = 0;
        public float S = 0;
        public float Sca = 0;
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            k += 0.04f;
            m += 0.12f;
            if(Math.Abs(projectile.timeLeft - 450) > 390)
            {
                S = (float)((Math.Abs(projectile.timeLeft - 450) - 390) / 60f);
            }
            else
            {
                S = 0;
            }
            S = 1 - S;
            for (float x = 1.1f;x < 4;x += 0.01f)
            {
                float D = (float)(Math.Sin(24 / x + m) / x * (Math.Sin(x + k) / 3 + 1)) * 20;
                float C = 0;
                C = 4 * S - x;
                if(C <= 0)
                {
                    C = 0;
                }
                Main.spriteBatch.Draw(Main.projectileTexture[projectile.type], projectile.Center - Main.screenPosition + new Vector2(D * Sca, -x * 50 * Sca) + new Vector2(0, 20), null, new Color(0.01f, 0.01f, 0.01f, 0) * C, 0f, new Vector2(6, 9), scal * 4f / x * Sca, SpriteEffects.None, 0f);
            }
            return false;
        }
    }
}
