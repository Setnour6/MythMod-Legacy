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
            Main.projFrames[projectile.type] = 4;
        }
		public override void SetDefaults()
		{
			base.projectile.width = 54;
			base.projectile.height = 52;
			base.projectile.friendly = true;
			base.projectile.melee = true;
			base.projectile.aiStyle = -1;
            base.projectile.penetrate = 1;
            base.projectile.timeLeft = 3600;
            base.projectile.hostile = false;
            projectile.tileCollide = false;
        }
        public override void AI()
		{
            Player player = Main.player[Main.myPlayer];
            base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;
            if(projectile.timeLeft < 3594)
            {
                projectile.tileCollide = true;
                int r = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) + base.projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.25f, 0.25f)) * 2f + new Vector2(4, 4), 0, 0, 27, 0, 0, 0, default(Color), 2f);
                Main.dust[r].noGravity = true;
                int r2 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) + base.projectile.velocity.RotatedBy(Main.rand.NextFloat(-0.25f,0.25f)) * 2f - new Vector2(4, 4), 0, 0, 27, 0, 0, 0, default(Color), 2f);
                Main.dust[r2].noGravity = true;
            }
            if(projectile.timeLeft % 6 == 0)
            {
                if(projectile.frame < 3)
                {
                    projectile.frame += 1;
                }
                else
                {
                    projectile.frame = 0;
                }
            }
            float num2 = base.projectile.Center.X;
            float num3 = base.projectile.Center.Y;
            float num4 = 400f;
            bool flag = false;
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    float num7 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num5) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num6);
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
                Vector2 vector1 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
                float num9 = num2 - vector1.X;
                float num10 = num3 - vector1.Y;
                float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
                num11 = num8 / num11;
                num9 *= num11;
                num10 *= num11;
                base.projectile.velocity.X = (base.projectile.velocity.X * 20f + num9) / 21f;
                base.projectile.velocity.Y = (base.projectile.velocity.Y * 20f + num10) / 21f;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(153, 900);
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
		    base.projectile.Kill();
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
                int num9 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, num8, 0f, 0f, 100, default(Color), 2f);
                Main.dust[num9].noGravity = true;
                Dust dust = Main.dust[num9];
                dust.position.X = dust.position.X + (float)Main.rand.Next(-10, 11);
                Dust dust2 = Main.dust[num9];
                dust2.position.Y = dust2.position.Y + (float)Main.rand.Next(-10, 11);
                num10++;
            }
            if (projectile.damage > 300)
            {
                Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, 0, 0, base.mod.ProjectileType("ShadowFireBallWave"), 0, 0, base.projectile.owner, 0f, 0f);
            }
        }
        public int projTime = 15;
	}
}
