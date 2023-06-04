using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile2
{
	// Token: 0x02000A70 RID: 2672
    public class PoisonGasBubble : ModProjectile
	{
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
        }
        public override void SetDefaults()
		{
			base.Projectile.width = 20;
			base.Projectile.height = 20;
			base.Projectile.alpha = 0;
			base.Projectile.scale = 1f;
			base.Projectile.friendly = false;
            base.Projectile.hostile = true;

            base.Projectile.DamageType = DamageClass.Magic;
			base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 120;
            base.Projectile.ignoreWater = false;
            base.Projectile.tileCollide = true;
        }
        private bool c = false;
        private int o = 0;
        public override void AI()
        {
            base.Projectile.frameCounter++;
            if (base.Projectile.frameCounter > 3)
            {
                base.Projectile.frame++;
                base.Projectile.frameCounter = 0;
            }
            if (base.Projectile.frame > 3)
            {
                base.Projectile.frame = 0;
            }
            if (!c)
            {
                o = Main.rand.Next(0, 200);
                base.Projectile.scale = Main.rand.NextFloat(0.75f, 1.57f);
                base.Projectile.timeLeft = Main.rand.Next(20, 200);
                c = true;
            }
            o += 1;
            Projectile.velocity.X = (float)Math.Sin(o / 20f);
            if(Projectile.velocity.Y > -2f)
            {
                Projectile.velocity.Y -= 0.025f;
            }
		}
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(20, Projectile.timeLeft * 2, true);
            target.AddBuff(70, Projectile.timeLeft / 2, true);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.active = false;
            return false;
        }
        public override void Kill(int timeLeft)
		{
            for (int i = 0; i < 15; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0, 8f)).RotatedByRandom(MathHelper.TwoPi);
                int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, Mod.Find<ModDust>("Poison").Type, v.X, v.Y, 100, default(Color), 3f);
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
