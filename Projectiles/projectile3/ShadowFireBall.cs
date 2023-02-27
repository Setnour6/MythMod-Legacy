using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class ShadowFireBall : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("影火球");
            Main.projFrames[Projectile.type] = 4;
        }
		public override void SetDefaults()
		{
			base.Projectile.width = 54;
			base.Projectile.height = 52;
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Melee;
			base.Projectile.aiStyle = -1;
            base.Projectile.penetrate = 1;
            base.Projectile.timeLeft = 3600;
            base.Projectile.hostile = false;
            Projectile.tileCollide = false;
        }
        public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            base.Projectile.rotation = (float)Math.Atan2((double)base.Projectile.velocity.Y, (double)base.Projectile.velocity.X) + 1.57f;
            if(Projectile.timeLeft < 3594)
            {
                Projectile.tileCollide = true;
                int r = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) + base.Projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.25f, 0.25f)) * 2f + new Vector2(4, 4), 0, 0, 27, 0, 0, 0, default(Color), 2f);
                Main.dust[r].noGravity = true;
                int r2 = Dust.NewDust(new Vector2(base.Projectile.Center.X, base.Projectile.Center.Y) + base.Projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.25f,0.25f)) * 2f - new Vector2(4, 4), 0, 0, 27, 0, 0, 0, default(Color), 2f);
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
            float num2 = base.Projectile.Center.X;
            float num3 = base.Projectile.Center.Y;
            float num4 = 400f;
            bool flag = false;
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(base.Projectile, false) && Collision.CanHit(base.Projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    float num7 = Math.Abs(base.Projectile.position.X + (float)(base.Projectile.width / 2) - num5) + Math.Abs(base.Projectile.position.Y + (float)(base.Projectile.height / 2) - num6);
                    if (num7 < num4)
                    {
                        num4 = num7;
                        num2 = num5;
                        num3 = num6;
                        flag = true;
                    }
                }
            }
            if (flag)
            {
                float num8 = 20f;
                Vector2 vector1 = new Vector2(base.Projectile.position.X + (float)base.Projectile.width * 0.5f, base.Projectile.position.Y + (float)base.Projectile.height * 0.5f);
                float num9 = num2 - vector1.X;
                float num10 = num3 - vector1.Y;
                float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                num11 = num8 / num11;
                num9 *= num11;
                num10 *= num11;
                base.Projectile.velocity.X = (base.Projectile.velocity.X * 20f + num9) / 21f;
                base.Projectile.velocity.Y = (base.Projectile.velocity.Y * 20f + num10) / 21f;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(153, 900);
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
                    num8 = 27;
                }
                else if (num8 == 1)
                {
                    num8 = 27;
                }
                else
                {
                    num8 = 27;
                }
                int num9 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, num8, 0f, 0f, 100, default(Color), 2f);
                Main.dust[num9].noGravity = true;
                Dust dust = Main.dust[num9];
                dust.position.X = dust.position.X + (float)Main.rand.Next(-10, 11);
                Dust dust2 = Main.dust[num9];
                dust2.position.Y = dust2.position.Y + (float)Main.rand.Next(-10, 11);
                num10++;
            }
            if (Projectile.damage > 300)
            {
                Projectile.NewProjectile(base.Projectile.Center.X, base.Projectile.Center.Y, 0, 0, base.Mod.Find<ModProjectile>("ShadowFireBallWave").Type, 0, 0, base.Projectile.owner, 0f, 0f);
            }
        }
        public int projTime = 15;
	}
}
