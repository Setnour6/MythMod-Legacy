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
			base.Projectile.width = 48;
			base.Projectile.height = 48;
			base.Projectile.friendly = true;
            base.Projectile.extraUpdates = 0;
			base.Projectile.penetrate = 10;
			base.Projectile.timeLeft = 3600;
			base.Projectile.DamageType = DamageClass.Melee;
            base.Projectile.aiStyle = 27;
		}
        public override void AI()
        {
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.7f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f);
            Vector2 vector = (base.Projectile.Center - base.Projectile.velocity * 4f - new Vector2(4, 4));
            Vector2 vector2 = (base.Projectile.Center - base.Projectile.velocity * 4f - new Vector2(4, 4) - base.Projectile.velocity.RotatedBy(Math.PI / 4f + Math.PI * Math.Sin(num / 6f) / 5f) * 1.5f);
            Vector2 vector3 = (base.Projectile.Center - base.Projectile.velocity * 4f - new Vector2(4, 4) + base.Projectile.velocity.RotatedBy(Math.PI / 4f + Math.PI * Math.Sin(num / 6f) / 5f) * 1.5f);
            int num12 = Dust.NewDust(vector, 0, 0, 183, 0f, 0f, 0, default(Color), 1.4f);
            Main.dust[num12].velocity *= 0.0f;
            Main.dust[num12].noGravity = true;
            int num13 = Dust.NewDust(vector2, 0, 0, 183, 0f, 0f, 0, default(Color), 1f);
            Main.dust[num13].velocity *= 0.0f;
            Main.dust[num13].noGravity = true;
            int num14 = Dust.NewDust(vector3, 0, 0, 183, 0f, 0f, 0, default(Color), 1f);
            Main.dust[num14].velocity *= 0.0f;
            Main.dust[num14].noGravity = true;
            base.Projectile.localAI[0] += 1f;
            num++;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.Projectile.penetrate--;
            if (base.Projectile.penetrate <= 0)
            {
                base.Projectile.Kill();
            }
            else
            {
                base.Projectile.ai[0] += 0.1f;
                if (base.Projectile.velocity.X != oldVelocity.X)
                {
                    base.Projectile.velocity.X = -oldVelocity.X;
                }
                if (base.Projectile.velocity.Y != oldVelocity.Y)
                {
                    base.Projectile.velocity.Y = -oldVelocity.Y;
                }
                float num7 = (float)(Main.rand.Next(0, 2000) / 1000f * Math.PI);
                for (int i = 0; i < 10; i++)
                {
                    if(i % 2 == 0)
                    {
                        int num2 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos(((float)i / 5f) * Math.PI + num7) * 7 / 3 * 2.88f, (float)(0 - (float)Math.Sin(((float)i / 5f) * Math.PI + num7) * 7) / 3 * 2.88f, base.Mod.Find<ModProjectile>("RougeRay2").Type, base.Projectile.damage / 2, 0.2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num2].timeLeft = 100;
                    }
                    else
                    {
                        int num3 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos(((float)i / 5f) * Math.PI + num7) * 7 / 3 * 1.44f, (float)(0 - (float)Math.Sin(((float)i / 5f) * Math.PI + num7) * 7) / 3 * 1.44f, base.Mod.Find<ModProjectile>("GlitterRay4").Type, base.Projectile.damage / 2, 0.2f, Main.myPlayer, 0f, 0f);
                        Main.projectile[num3].timeLeft = 60;
                    }
                }
            }
            return false;
        }
        public override void PostDraw(Color lightColor)
        {
            spriteBatch.Draw(base.Mod.GetTexture("Projectiles/星渊水母剑气Glow"), base.Projectile.Center - Main.screenPosition, null, Color.White, base.Projectile.rotation, new Vector2(48f, 0f), 1f, SpriteEffects.None, 0f);
        }
    }
}
