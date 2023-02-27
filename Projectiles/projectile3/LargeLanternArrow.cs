using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class LargeLanternArrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("大灯笼箭");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 26;
			base.projectile.height = 30;
			base.projectile.friendly = true;
			base.projectile.alpha = 65;
			base.projectile.penetrate = 1;
			base.projectile.tileCollide = true;
			base.projectile.timeLeft = 600;
            base.projectile.ranged = true;
            base.projectile.aiStyle = 1;
            this.aiType = 1;
		}
        public override void AI()
        {
            int num3 = Dust.NewDust(base.projectile.Center - base.projectile.velocity - new Vector2(4, 4), 0, 0, 6, 0, 0, 0, default(Color), 2f);
            Main.dust[num3].noGravity = true;
            Lighting.AddLight(base.projectile.Center, 0.8f,0.1f,0);
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            if (Main.rand.Next(3) == 1)
            {
                target.AddBuff(24, 180, false);
            }
		}
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 12; i++)
            {
                Dust.NewDust(base.projectile.Center - base.projectile.velocity * 4f - new Vector2(4, 4), 0, 0, 6, 0, 0, 0, default(Color), 1f);
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 188, 0, -0.5f, 201, default(Color), 1.5f);
            }
            for (int k = 0; k <= 15; k++)
            {
                float a = (float)Main.rand.Next(0, 720) / 360f * 3.141592653589793238f;
                float m = (float)Main.rand.Next(0, 50000);
                float l = (float)Main.rand.Next((int)m, 50000) / 1800f;
                int num4 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.08f, (float)((float)l * Math.Sin((float)a)) * 0.08f, base.mod.ProjectileType("LanternBoomLiF"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[num4].scale = (float)Main.rand.Next(7000, 13000) / 10000f;
            }
        }
    }
}
