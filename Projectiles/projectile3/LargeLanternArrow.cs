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
            // base.DisplayName.SetDefault("大灯笼箭");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 26;
			base.Projectile.height = 30;
			base.Projectile.friendly = true;
			base.Projectile.alpha = 65;
			base.Projectile.penetrate = 1;
			base.Projectile.tileCollide = true;
			base.Projectile.timeLeft = 600;
            base.Projectile.DamageType = DamageClass.Ranged;
            base.Projectile.aiStyle = 1;
            this.AIType = 1;
		}
        public override void AI()
        {
            int num3 = Dust.NewDust(base.Projectile.Center - base.Projectile.velocity - new Vector2(4, 4), 0, 0, 6, 0, 0, 0, default(Color), 2f);
            Main.dust[num3].noGravity = true;
            Lighting.AddLight(base.Projectile.Center, 0.8f,0.1f,0);
        }
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
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
                Dust.NewDust(base.Projectile.Center - base.Projectile.velocity * 4f - new Vector2(4, 4), 0, 0, 6, 0, 0, 0, default(Color), 1f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 188, 0, -0.5f, 201, default(Color), 1.5f);
            }
            for (int k = 0; k <= 15; k++)
            {
                float a = (float)Main.rand.Next(0, 720) / 360f * 3.141592653589793238f;
                float m = (float)Main.rand.Next(0, 50000);
                float l = (float)Main.rand.Next((int)m, 50000) / 1800f;
                int num4 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, (float)((float)l * Math.Cos((float)a)) * 0.08f, (float)((float)l * Math.Sin((float)a)) * 0.08f, base.Mod.Find<ModProjectile>("LanternBoomLiF").Type, base.Projectile.damage, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                Main.projectile[num4].scale = (float)Main.rand.Next(7000, 13000) / 10000f;
            }
        }
    }
}
