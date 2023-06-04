using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles.projectile3
{
    public class PoisonSummon : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            // base.DisplayName.SetDefault("毒气弹");
			Main.projFrames[base.Projectile.type] = 1;
		}
        public override void SetDefaults()
		{
			base.Projectile.width = 34;
			base.Projectile.height = 34;
			base.Projectile.hostile = false;
            base.Projectile.friendly = false;
            base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = true;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 600;
			base.Projectile.alpha = 0;
			this.CooldownSlot = 1;
            ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 50;
            ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
        }
		public override void Kill(int timeLeft)
		{
            for(int g = 0; g < 30;g++)
            {
                Vector2 v = new Vector2(0, 30).RotatedBy(Math.PI / 15f * g);
                Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, v.X, v.Y, Mod.Find<ModProjectile>("PoisonGasF").Type, (int)(Projectile.ai[0]), 0f, Main.myPlayer, 0f, 0f);
            }
            if(Projectile.ai[1] > 10)
            {
                Projectile.NewProjectile(Projectile.Center.X - 15, Projectile.Center.Y - 25, 0, 9, Mod.Find<ModProjectile>("PoisonGasF").Type, (int)(Projectile.ai[0]), 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(Projectile.Center.X + 15, Projectile.Center.Y - 25, 0, 9, Mod.Find<ModProjectile>("PoisonGasF").Type, (int)(Projectile.ai[0]), 0f, Main.myPlayer, 0f, 0f);
            }
            if (Projectile.ai[1] > 20)
            {
                Projectile.NewProjectile(Projectile.Center.X - 30, Projectile.Center.Y - 25, 0, 9, Mod.Find<ModProjectile>("PoisonGasF").Type, (int)(Projectile.ai[0]), 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(Projectile.Center.X + 30, Projectile.Center.Y - 25, 0, 9, Mod.Find<ModProjectile>("PoisonGasF").Type, (int)(Projectile.ai[0]), 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(Projectile.Center.X - 45, Projectile.Center.Y - 25, 0, 9, Mod.Find<ModProjectile>("PoisonGasF").Type, (int)(Projectile.ai[0]), 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(Projectile.Center.X + 45, Projectile.Center.Y - 25, 0, 9, Mod.Find<ModProjectile>("PoisonGasF").Type, (int)(Projectile.ai[0]), 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(Projectile.Center.X - 60, Projectile.Center.Y - 25, 0, 9, Mod.Find<ModProjectile>("PoisonGasF").Type, (int)(Projectile.ai[0]), 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(Projectile.Center.X + 60, Projectile.Center.Y - 25, 0, 9, Mod.Find<ModProjectile>("PoisonGasF").Type, (int)(Projectile.ai[0]), 0f, Main.myPlayer, 0f, 0f);
            }
        }
	}
}
