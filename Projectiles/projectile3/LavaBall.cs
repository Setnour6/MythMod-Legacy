using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class LavaBall : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("熔岩团");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 32;
			base.projectile.height = 32;
			base.projectile.friendly = true;
			base.projectile.melee = true;
			base.projectile.penetrate = 1;
			base.projectile.aiStyle = -1;
			base.projectile.timeLeft = 600;
            base.projectile.hostile = true;
		}
		public override void AI()
		{
            int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 174, 0f, 0f, 100, Color.White, 5f);
            Main.dust[num].noGravity = false;
            if(projectile.timeLeft > 595 && !projectile.lavaWet && projectile.timeLeft < 598)
            {
               projectile.active = false;
            }
            if (projectile.lavaWet)
            {
                projectile.timeLeft = 594;
            }
            projectile.velocity.Y += 0.2f;
		}
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
            projectile.Kill();
			return false;
		}
        public override void Kill(int timeLeft)
        {
            if(timeLeft != 0)
            {
                for (int i = 0; i < 65; i++)
                {
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(0.5f, projectile.velocity.Length() * 0.6f)).RotatedByRandom(Math.PI * 2);
                    int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 174, v.X, v.Y, 100, Color.White, 5f);
                    Main.dust[num].noGravity = false;
                }
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (projectile.timeLeft >= 570)
            {
                spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile3/熔岩团Glow"), base.projectile.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), base.projectile.rotation, new Vector2(16f, 16f), 1f, SpriteEffects.None, 0f);
            }
            else
            {
                spriteBatch.Draw(base.mod.GetTexture("Projectiles/projectile3/熔岩团Glow"), base.projectile.Center - Main.screenPosition, null, new Color(1, 1, 1, 0) * (projectile.timeLeft / 570f), base.projectile.rotation, new Vector2(16f, 16f), 1f, SpriteEffects.None, 0f);
            }
        }
    }
}
