using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
    public class PoisonGasBubbleF : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 4;
        }
        public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 20;
			base.projectile.alpha = 0;
			base.projectile.scale = 1f;
			base.projectile.friendly = true;
            base.projectile.hostile = false;

            base.projectile.magic = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 120;
            base.projectile.ignoreWater = false;
            base.projectile.tileCollide = true;
        }
        private bool c = false;
        private int o = 0;
        public override void AI()
		{
            base.projectile.frameCounter++;
            if (base.projectile.frameCounter > 3)
            {
                base.projectile.frame++;
                base.projectile.frameCounter = 0;
            }
            if (base.projectile.frame > 3)
            {
                base.projectile.frame = 0;
            }
            if (!c)
            {
                o = Main.rand.Next(0, 200);
                base.projectile.scale = Main.rand.NextFloat(0.75f, 1.57f);
                base.projectile.timeLeft = Main.rand.Next(20, 200);
                c = true;
            }
            o += 1;
            projectile.velocity.X = (float)Math.Sin(o / 20f);
            if(projectile.velocity.Y > -2f)
            {
                projectile.velocity.Y -= 0.025f;
            }
		}
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(20, projectile.timeLeft * 2, true);
            target.AddBuff(70, projectile.timeLeft / 2, true);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.active = false;
            return false;
        }
        public override void Kill(int timeLeft)
		{
            for (int i = 0; i < 15; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 8f)).RotatedByRandom(MathHelper.TwoPi);
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, mod.DustType("Poison"), v.X, v.Y, 100, default(Color), 3f);
                Main.dust[num].noGravity = true;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num].scale = 0.5f;

                    Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                }
            }
        }
	}
}
