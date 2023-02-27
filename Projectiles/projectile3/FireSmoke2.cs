using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class FireSmoke2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("烟火2");
        }
		public override void SetDefaults()
		{
			base.Projectile.width = 20;
			base.Projectile.height = 20;
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Melee;
			base.Projectile.penetrate = 1;
			base.Projectile.aiStyle = -1;
			base.Projectile.timeLeft = 60;
            base.Projectile.hostile = true;
		}
        private int T = 0;
        public override void AI()
		{
            if(T == 0)
            {
                T = Main.rand.Next(20, 150);
                Projectile.timeLeft = T;
            }
            if(Projectile.timeLeft %3 == 0)
            {
                Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, 0, -12 * Main.rand.NextFloat(0.8f,1.2f), Mod.Find<ModProjectile>("FireSmoke").Type, 100, 2f, Main.myPlayer, 0f, 0f);
            }
		}
	}
}
