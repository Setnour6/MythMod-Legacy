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
            // base.DisplayName.SetDefault("蝴蝶兰");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 20;
			base.Projectile.height = 20;
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Melee;
			base.Projectile.aiStyle = -1;
            base.Projectile.penetrate = 1;
            base.Projectile.timeLeft = 3600;
            base.Projectile.hostile = false;
		}

        public override Color? GetAlpha(Color lightColor)
        {
            if (Projectile.timeLeft < 3584)
            {
                return new Color?(new Color(255, 255, 255, 0));
            }
            else
            {
                return new Color?(new Color((3600 - Projectile.timeLeft) / 14f, (3600 - Projectile.timeLeft) / 14f, (3600 - Projectile.timeLeft) / 14f, 0));
            }
        }
        public override void AI()
		{
            base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) + 1.57f;
            if(Projectile.timeLeft < 3584)
            {
                int r = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - base.Projectile.velocity * 1.5f - new Vector2(4, 4), 0, 0, 107, 0, 0, 0, default(Color), 2f);
                Main.dust[r].velocity.X = 0;
                Main.dust[r].velocity.Y = 0;
                Main.dust[r].noGravity = true;
            }
        }
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    base.Projectile.Kill();
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
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("Phalaenopsis1").Type, base.Projectile.damage, base.Projectile.knockBack, Main.myPlayer, (v.Length() - 1.5f) / 14.5f, m);
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v2.X, v2.Y, Mod.Find<ModProjectile>("PhalaenopsisDust").Type, base.Projectile.damage, base.Projectile.knockBack, Main.myPlayer, 0, 0);
            }
            for (int i = 0; i < 30; i++)
            {
                Vector2 v = new Vector2(0, 8).RotatedBy(Math.PI / 15d * (double)i) * n + new Vector2(0, 6.5f).RotatedBy(m + Math.PI) * n;
                Vector2 v2 = new Vector2(0, Main.rand.NextFloat(0.02f, 2.5f)).RotatedBy(m + Main.rand.NextFloat(-0.35f, 0.35f) + Math.PI * 0.5f) * n;
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("Phalaenopsis1").Type, base.Projectile.damage, base.Projectile.knockBack, Main.myPlayer, (v.Length() - 1.5f) / 14.5f, m);
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, -v2.X, -v2.Y, Mod.Find<ModProjectile>("PhalaenopsisDust").Type, base.Projectile.damage, base.Projectile.knockBack, Main.myPlayer, 0, 0);
            }
        }
        public int projTime = 15;
	}
}
