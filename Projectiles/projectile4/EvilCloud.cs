using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MythMod.Projectiles.projectile4
{
    public class EvilCloud : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("魔雷云");
		}
		public override void SetDefaults()
		{
			projectile.width = 12;
			projectile.height = 12;
            projectile.hostile = true;
            projectile.friendly = false;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.alpha = 0;
			projectile.penetrate = -1;
			projectile.timeLeft = 900;
            projectile.extraUpdates = 12;
            projectile.tileCollide = true;
        }
        private float Y = 0;
        private float X = 0;
        private float ω = 0;
        private bool Orbit = false;
        public override void AI()
		{
            if(projectile.timeLeft >= 899)
            {
                Y = projectile.Center.Y - 380;
                X = projectile.Center.X;
            }
            if(projectile.Center.Y > Y)
            {
                if(!Orbit)
                {
                    if (Math.Abs(ω) < 0.03f)
                    {
                        ω += Main.rand.NextFloat(-0.005f, 0.005f);
                    }
                    else
                    {
                        ω *= 0.96f;
                    }
                    if (projectile.velocity.Y < 0.5f)
                    {
                        projectile.velocity = projectile.velocity.RotatedBy(ω);
                    }
                    else
                    {
                        projectile.velocity.Y -= 0.05f;
                        projectile.velocity.X *= 0.96f;
                    }
                }
            }
            else
            {
                Orbit = true;
            }
            if(Orbit)
            {
                float x = projectile.Center.X - X;
                float y = projectile.Center.Y - Y;
                if (x * x / 40000 + y * y / 2500 > 1)
                {
                    projectile.velocity *= 0.99f;
                    projectile.velocity += (new Vector2(X, Y) - projectile.Center) / 2000f;
                }
                else
                {
                    projectile.velocity = projectile.velocity.RotatedBy(ω);
                    if (Math.Abs(ω) < 0.03f)
                    {
                        ω += Main.rand.NextFloat(-0.005f, 0.005f);
                    }
                    else
                    {
                        ω *= 0.96f;
                    }
                    if(projectile.velocity.Y > 0.5f)
                    {
                        projectile.velocity.Y *= 0.98f;
                    }
                    if (projectile.velocity.Length() < 2f)
                    {
                        projectile.velocity *= 1.05f;
                    }
                }
            }
            if(projectile.timeLeft == 60)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("EvilLightingbolt"), 30, 0f, Main.myPlayer, 0f, 0f);
            }
            if(Main.rand.Next(100) < 3)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("EvilLightingbolt2"), 0, 0f, Main.myPlayer, Main.rand.Next(8, 60), 0f);
            }
            int num = Dust.NewDust(projectile.Center - new Vector2(4, 4) + new Vector2(0, 12).RotatedBy(projectile.timeLeft / 4f), 2, 2, 109, 0, 0, 0, default(Color), Main.rand.NextFloat(2.5f, 5f));
            Main.dust[num].noGravity = true;
            Main.dust[num].velocity = projectile.velocity;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            base.projectile.ai[0] += 0.1f;
            if (base.projectile.velocity.X != oldVelocity.X)
            {
                base.projectile.velocity.X = -oldVelocity.X;
            }
            if (base.projectile.velocity.Y != oldVelocity.Y)
            {
                base.projectile.velocity.Y = -oldVelocity.Y;
            }
            return false;
        }
        public override void Kill(int timeLeft)
        {
            if (timeLeft > 60)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("EvilLightingbolt"), 30, 0f, Main.myPlayer, 0f, 0f);
            }
        }
    }
}
