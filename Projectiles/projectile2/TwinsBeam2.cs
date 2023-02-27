using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
    public class TwinsBeam2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("双子魔眼剑气");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 28;
			base.Projectile.height = 28;
			base.Projectile.friendly = true;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 3600;
			base.Projectile.DamageType = DamageClass.Melee;
            base.Projectile.aiStyle = 27;
			base.Projectile.scale = 1.5f;
		}
		public override void AI()
		{
            Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 1.5f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f, (float)(255 - base.Projectile.alpha) * 0f / 255f);
            int num3 = Dust.NewDust(base.Projectile.Center - base.Projectile.velocity * 4f - new Vector2(4, 4), 0, 0, 183, 0, 0, 0, default(Color), 2f);
			float num = base.Projectile.Center.X;
			float num2 = base.Projectile.Center.Y;
			Main.dust[num3].noGravity = true;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			//target.AddBuff(39, 600, false);
		}
        public override void Kill(int timeLeft)
        {
            float num7 = (float)(Main.rand.Next(0, 2000) / 1000f * Math.PI);
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    int num2 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos(((float)i / 5f) * Math.PI + num7) * 7 / 1.5f * 2.88f, (float)(0 - (float)Math.Sin(((float)i / 5f) * Math.PI + num7) * 7) / 1.5f * 2.88f,100, base.Projectile.damage / 3 * 2, 0.2f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num2].timeLeft = 200;
                    Main.projectile[num2].hostile = false;
                    Main.projectile[num2].friendly = true;
                }
                else
                {
                    int num3 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)Math.Cos(((float)i / 5f) * Math.PI + num7) * 7 / 1.5f * 2.08f, (float)(0 - (float)Math.Sin(((float)i / 5f) * Math.PI + num7) * 7) / 1.5f * 1.44f, 83, base.Projectile.damage / 3, 0.2f, Main.myPlayer, 0f, 0f);
                    Main.projectile[num3].timeLeft = 200;
                    Main.projectile[num3].hostile = false;
                    Main.projectile[num3].friendly = true;
                }
            }
        }
	}
}
