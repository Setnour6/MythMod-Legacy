using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile4
{
    public class StarSail : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("星帆");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 28;
			base.projectile.height = 28;
			base.projectile.friendly = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 3600;
			base.projectile.melee = true;
            base.projectile.aiStyle = 27;
			base.projectile.scale = 1.5f;
		}
		public override void AI()
		{
            int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, mod.DustType("Star"), 0f, 0f, 100, default(Color), 0.8f);
            if (Main.rand.Next(2) == 0)
            {
                Main.dust[num].scale = 0.5f;
                Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
            }
            //Main.dust[num3].velocity = new Vector2(0, 0);
        }
        public override Color? GetAlpha(Color lightColor)
        {
            int R0 = (int)(73 + (Math.Sin(projectile.timeLeft / 40f) + 1) * 70.5);
            int G0 = (int)(170 - (Math.Sin(projectile.timeLeft / 40f) + 1) * 52);
            return new Color?(new Color(R0, G0, 255, 0));
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(153, 300);
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 30; i++)
            {
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, mod.DustType("Star"), 0f, 0f, 100, default(Color), 1f);
                Main.dust[num].velocity *= 3f;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num].scale = 0.5f;
                    Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                }
            }
        }
	}
}
