using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
    public class Phalaenopsis : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("蝴蝶兰");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 20;
			base.projectile.friendly = true;
			base.projectile.melee = true;
			base.projectile.aiStyle = -1;
            base.projectile.penetrate = 1;
            base.projectile.timeLeft = 3600;
            base.projectile.hostile = false;
		}

        public override Color? GetAlpha(Color lightColor)
        {
            if (projectile.timeLeft < 3584)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color((3600 - projectile.timeLeft) / 14f, (3600 - projectile.timeLeft) / 14f, (3600 - projectile.timeLeft) / 14f, 0));
            }
        }
        public override void AI()
		{
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;
            if(projectile.timeLeft < 3584)
            {
                int r = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - base.projectile.velocity * 1.5f - new Vector2(4, 4), 0, 0, 107, 0, 0, 0, default(Color), 2f);
                Main.dust[r].velocity.X = 0;
                Main.dust[r].velocity.Y = 0;
                Main.dust[r].noGravity = true;
            }
        }
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    base.projectile.Kill();
			return false;
		}
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
        public override void Kill(int timeLeft)
        {
            float n = Main.rand.NextFloat(0.7f, 1.1f);
            float m = Main.rand.NextFloat(0, (float)Math.PI * 2f);
            for (int i = 0; i < 30; i++)
            {
                Vector2 v = new Vector2(0, 8).RotatedBy(Math.PI / 15d * (double)i) * n + new Vector2(0, 6.5f).RotatedBy(m) * n;
                Vector2 v2 = new Vector2(0, Main.rand.NextFloat(0.02f, 2.5f)).RotatedBy(m + Main.rand.NextFloat(-0.35f,0.35f) + Math.PI * 0.5f) * n;
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, mod.ProjectileType("Phalaenopsis1"), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, (v.Length() - 1.5f) / 14.5f, m);
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v2.X, v2.Y, mod.ProjectileType("PhalaenopsisDust"), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, 0, 0);
            }
            for (int i = 0; i < 30; i++)
            {
                Vector2 v = new Vector2(0, 8).RotatedBy(Math.PI / 15d * (double)i) * n + new Vector2(0, 6.5f).RotatedBy(m + Math.PI) * n;
                Vector2 v2 = new Vector2(0, Main.rand.NextFloat(0.02f, 2.5f)).RotatedBy(m + Main.rand.NextFloat(-0.35f, 0.35f) + Math.PI * 0.5f) * n;
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, v.X, v.Y, mod.ProjectileType("Phalaenopsis1"), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, (v.Length() - 1.5f) / 14.5f, m);
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, -v2.X, -v2.Y, mod.ProjectileType("PhalaenopsisDust"), base.projectile.damage, base.projectile.knockBack, Main.myPlayer, 0, 0);
            }
        }
        public int projTime = 15;
	}
}
