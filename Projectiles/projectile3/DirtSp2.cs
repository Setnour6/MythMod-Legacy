using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class DirtSp2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("");
		}
		public override void SetDefaults()
		{
			Projectile.width = 32;
			Projectile.height = 32;
			Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;
            Projectile.tileCollide = false;
        }
        public override void AI()
		{
            Projectile.velocity *= 0;
            int i = Dust.NewDust(Projectile.Center - new Vector2(16,3), 32, 6, 28, 0f, 0f, 0, default(Color), 1f);
            Main.dust[i].noGravity = true;
            int i2 = Dust.NewDust(Projectile.Center - new Vector2(16, 3), 32, 6, 28, 0f, 0f, 0, default(Color), 1f);
            Main.dust[i2].noGravity = true;
            int i3 = Dust.NewDust(Projectile.Center - new Vector2(16, 3), 32, 6, 28, 0f, 0f, 0, default(Color), 1f);
            Main.dust[i3].noGravity = true;
            if(Projectile.timeLeft < 240 && Projectile.timeLeft % 12 == 0)
            {
                int num4 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, Main.rand.NextFloat(-0.2f,0.2f), -11f, base.Mod.Find<ModProjectile>("DirtSp3").Type, base.Projectile.damage, base.Projectile.knockBack, base.Projectile.owner, 0f, 0);
            }
        }
	}
}
