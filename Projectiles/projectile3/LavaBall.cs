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
			base.Projectile.width = 32;
			base.Projectile.height = 32;
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Melee;
			base.Projectile.penetrate = 1;
			base.Projectile.aiStyle = -1;
			base.Projectile.timeLeft = 600;
            base.Projectile.hostile = true;
		}
		public override void AI()
		{
            int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 174, 0f, 0f, 100, Color.White, 5f);
            Main.dust[num].noGravity = false;
            if(Projectile.timeLeft > 595 && !Projectile.lavaWet && Projectile.timeLeft < 598)
            {
               Projectile.active = false;
            }
            if (Projectile.lavaWet)
            {
                Projectile.timeLeft = 594;
            }
            Projectile.velocity.Y += 0.2f;
		}
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
            Projectile.Kill();
			return false;
		}
        public override void Kill(int timeLeft)
        {
            if(timeLeft != 0)
            {
                for (int i = 0; i < 65; i++)
                {
                    Vector2 v = new Vector2(0, Main.rand.NextFloat(0.5f, Projectile.velocity.Length() * 0.6f)).RotatedByRandom(Math.PI * 2);
                    int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 174, v.X, v.Y, 100, Color.White, 5f);
                    Main.dust[num].noGravity = false;
                }
            }
        }
        public override void PostDraw(Color lightColor)
        {
            if (Projectile.timeLeft >= 570)
            {
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile3/熔岩团Glow"), base.Projectile.Center - Main.screenPosition, null, new Color(255, 255, 255, 0), base.Projectile.rotation, new Vector2(16f, 16f), 1f, SpriteEffects.None, 0f);
            }
            else
            {
                spriteBatch.Draw(base.Mod.GetTexture("Projectiles/projectile3/熔岩团Glow"), base.Projectile.Center - Main.screenPosition, null, new Color(1, 1, 1, 0) * (Projectile.timeLeft / 570f), base.Projectile.rotation, new Vector2(16f, 16f), 1f, SpriteEffects.None, 0f);
            }
        }
    }
}
