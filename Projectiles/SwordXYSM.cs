using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles
{
    public class SwordXYSM : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("星渊水母剑气");
		}
        private int num = 0;
		public override void SetDefaults()
		{
			base.projectile.width = 48;
			base.projectile.height = 48;
			base.projectile.friendly = true;
            base.projectile.extraUpdates = 0;
			base.projectile.penetrate = 10;
			base.projectile.timeLeft = 3600;
			base.projectile.melee = true;
            base.projectile.aiStyle = 27;
		}
        public override void AI()
        {
            Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.7f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f);
            Vector2 vector = (base.projectile.Center - base.projectile.velocity * 4f - new Vector2(4, 4));
            Vector2 vector2 = (base.projectile.Center - base.projectile.velocity * 4f - new Vector2(4, 4) - base.projectile.velocity.RotatedBy(Math.PI / 4f + Math.PI * Math.Sin(num / 6f) / 5f) * 1.5f);
            Vector2 vector3 = (base.projectile.Center - base.projectile.velocity * 4f - new Vector2(4, 4) + base.projectile.velocity.RotatedBy(Math.PI / 4f + Math.PI * Math.Sin(num / 6f) / 5f) * 1.5f);
            int num12 = Dust.NewDust(vector, 0, 0, 183, 0f, 0f, 0, default(Color), 1.4f);
            Main.dust[num12].velocity *= 0.0f;
            Main.dust[num12].noGravity = true;
            int num13 = Dust.NewDust(vector2, 0, 0, 183, 0f, 0f, 0, default(Color), 1f);
            Main.dust[num13].velocity *= 0.0f;
            Main.dust[num13].noGravity = true;
            int num14 = Dust.NewDust(vector3, 0, 0, 183, 0f, 0f, 0, default(Color), 1f);
            Main.dust[num14].velocity *= 0.0f;
            Main.dust[num14].noGravity = true;
            base.projectile.localAI[0] += 1f;
            num++;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.projectile.penetrate--;
            if (base.projectile.penetrate <= 0)
            {
                base.projectile.Kill();
            }
            else
            {
                base.projectile.ai[0] += 0.1f;
                if (base.projectile.velocity.X != oldVelocity.X)
                {
                    base.projectile.velocity.X = -oldVelocity.X;
                }
                if (base.projectile.velocity.Y != oldVelocity.Y)
                {
                    base.projectile.velocity.Y = -oldVelocity.Y;
                }
                float num7 = (float)(Main.rand.Next(0, 2000) / 1000f * Math.PI);
                for (int i = 0; i < 10; i++)
                {
                    if(i % 2 == 0)
                    {
                        int num2 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos(((float)i / 5f) * Math.PI + num7) * 7 / 3 * 2.88f, (float)(0 - (float)Math.Sin(((float)i / 5f) * Math.PI + num7) * 7) / 3 * 2.88f, base.mod.ProjectileType("RougeRay2"), base.projectile.damage / 2, 0.2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num2].timeLeft = 100;
                    }
                    else
                    {
                        int num3 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)Math.Cos(((float)i / 5f) * Math.PI + num7) * 7 / 3 * 1.44f, (float)(0 - (float)Math.Sin(((float)i / 5f) * Math.PI + num7) * 7) / 3 * 1.44f, base.mod.ProjectileType("GlitterRay4"), base.projectile.damage / 2, 0.2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num3].timeLeft = 60;
                    }
                }
            }
            return false;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            spriteBatch.Draw(base.mod.GetTexture("Projectiles/星渊水母剑气Glow"), base.projectile.Center - Main.screenPosition, null, Color.White, base.projectile.rotation, new Vector2(48f, 0f), 1f, SpriteEffects.None, 0f);
        }
    }
}
