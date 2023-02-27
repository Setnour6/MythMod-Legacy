using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile4
{
    public class HoneyBottle : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("HoneyBottle");
		}
        private float num = 0;
        public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 38;
			base.projectile.friendly = true;
			base.projectile.alpha = 0;
			base.projectile.penetrate = 1;
			base.projectile.tileCollide = true;
			base.projectile.timeLeft = 300;
            projectile.thrown = true;
            base.projectile.aiStyle = -1;
		}
        float timer = 0;
        static float j = 0;
        static float m = 0.15f;
        static float n = 0;
        private bool x = false;
        Vector2 pc2 = Vector2.Zero;

        public override void AI()
        {
            projectile.rotation = (float)System.Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f + num;
            if(projectile.timeLeft <= 250 && !x)
            {
                num += 0.15f;
            }
            if(x)
            {
                num += m;
                if(m > 0)
                {
                    m -= 0.005f;
                }
                else
                {
                    m = 0;
                }
            }
            if (projectile.velocity.Y < 15f && !x)
            {
                projectile.velocity.Y += 0.2f;
            }
            Dust.NewDust(new Vector2((float)projectile.Center.X, (float)projectile.Center.Y) + new Vector2(0,-10).RotatedBy(projectile.rotation), 0, 0, 102, 0f, 0f, 0, default(Color), 1f);
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 27, 1f, 0f);
            for (int i = 0; i < 25; i++)
            {
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 174, 0f, 0f, 100, default(Color), 2f);
                Main.dust[num].velocity *= 3f;
                if (Main.rand.Next(2) == 0)
                {
                    Main.dust[num].scale = 0.5f;
                    Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                }
            }
            for (int j = 0; j < 200; j++)
            {
                if (Main.npc[j].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                    float num7 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num5) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num6);
                    if (num7 < 250)
                    {
                        Main.npc[j].StrikeNPC((int)((projectile.damage * Main.rand.NextFloat(0.85f, 1.15f)) * (25 / (num7 + 10))), projectile.knockBack, projectile.direction, Main.rand.Next(200) > 150 ? true : false);
                        projectile.penetrate--;
                    }
                }
            }
            int pl = (int)Player.FindClosest(base.projectile.Center, 1, 1);
            if ((Main.player[pl].Center - projectile.Center).Length() < 120)
            {
                Main.player[pl].AddBuff(48,120);
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
	}
}
