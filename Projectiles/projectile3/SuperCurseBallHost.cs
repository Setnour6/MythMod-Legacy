using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class SuperCurseBallHost : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("超级咒火球");
            Main.projFrames[Projectile.type] = 4;
        }
		public override void SetDefaults()
		{
			base.Projectile.width = 54;
			base.Projectile.height = 52;
			base.Projectile.friendly = false;
			base.Projectile.DamageType = DamageClass.Melee;
			base.Projectile.aiStyle = -1;
            base.Projectile.penetrate = 1;
            base.Projectile.timeLeft = 3600;
            base.Projectile.hostile = true;
            Projectile.tileCollide = false;
        }
        public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) + 1.57f;
            if(Projectile.timeLeft < 3599)
            {
                Projectile.tileCollide = true;
                int r = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - new Vector2(Main.rand.NextFloat(0,24), 0).RotatedByRandom(MathHelper.TwoPi) - new Vector2(8, 8), 0, 0, 75, 0, 0, 0, default(Color), 3f);
                Main.dust[r].velocity.X = 0;
                Main.dust[r].velocity.Y = 0;
                Main.dust[r].noGravity = true;
                int r2 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) - base.Projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.25f,0.25f)) * 0.15f - new Vector2(Main.rand.NextFloat(0, 24), 0).RotatedByRandom(MathHelper.TwoPi) - new Vector2(8, 8), 0, 0, 75, 0, 0, 0, default(Color), 5f);
                Main.dust[r2].velocity.X = 0;
                Main.dust[r2].velocity.Y = 0;
                Main.dust[r2].noGravity = true;
            }
            if(Projectile.timeLeft % 6 == 0)
            {
                if(Projectile.frame < 3)
                {
                    Projectile.frame += 1;
                }
                else
                {
                    Projectile.frame = 0;
                }
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(39, 3600);
            Projectile.Kill();
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    base.Projectile.Kill();
			return false;
		}
        public override void Kill(int timeLeft)
        {
            int num10 = 0;
            while ((float)num10 < 400)
            {
                float num4 = (float)Main.rand.Next(-25, 26);
                float num5 = (float)Main.rand.Next(-25, 26);
                float num6 = (float)Main.rand.Next(2, 6);
                float num7 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
                num7 = num6 / num7;
                num4 *= num7 * 1.2f;
                num5 *= num7 * 1.2f;
                int num8 = Main.rand.Next(3);
                if (num8 == 0)
                {
                    num8 = 75;
                }
                else if (num8 == 1)
                {
                    num8 = 75;
                }
                else
                {
                    num8 = 75;
                }
                int num9 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, num8, 0f, 0f, 100, default(Color), 6f);
                Main.dust[num9].noGravity = true;
                Main.dust[num9].position.X = base.Projectile.Center.X;
                Main.dust[num9].position.Y = base.Projectile.Center.Y;
                Dust dust = Main.dust[num9];
                dust.position.X = dust.position.X + (float)Main.rand.Next(-10, 11);
                Dust dust2 = Main.dust[num9];
                dust2.position.Y = dust2.position.Y + (float)Main.rand.Next(-10, 11);
                Main.dust[num9].velocity.X = num4 * 1.8f;
                Main.dust[num9].velocity.Y = num5 * 1.8f;
                num10++;
            }

                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("SuperCurseBallWave").Type, 0, 0, base.Projectile.owner, 0f, 0f);

            for (int k = 0; k <= 10; k++)
            {
                Vector2 v = new Vector2(0, 40).RotatedByRandom(Math.PI * 2);
                int num4 = Projectile.NewProjectile(base.Projectile.Center.X + v.X, base.Projectile.Center.Y + v.Y, 0, 0, base.Mod.Find<ModProjectile>("GreenFireGas").Type, base.Projectile.damage / 10, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                Vector2 v2 = new Vector2(0, 9).RotatedByRandom(Math.PI * k / 5d);
                int num6 = Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, v2.X, v2.Y, 96, base.Projectile.damage / 10, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f);
                Main.projectile[num4].friendly = false;
                Main.projectile[num4].hostile = true;
                Main.projectile[num6].friendly = false;
                Main.projectile[num6].hostile = true;
                Main.projectile[num6].tileCollide = false;
            }
        }
        public int projTime = 15;
	}
}
