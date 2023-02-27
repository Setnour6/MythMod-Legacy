using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MythMod.Projectiles.CorruptMoth
{
    public class CorruptMoth : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("腐化飞蛾");
			ProjectileID.Sets.MinionSacrificable[base.projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[base.projectile.type] = true;
			Main.projFrames[projectile.type] = 3;
		}
		public override void SetDefaults()
		{
			base.projectile.width = 12;
			base.projectile.height = 12;
			base.projectile.netImportant = true;
			base.projectile.friendly = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 600;
			base.projectile.tileCollide = true;
			base.projectile.usesLocalNPCImmunity = true;
		}
		public override void AI()
		{
            projectile.spriteDirection = projectile.velocity.X > 0 ? -1 : 1;
            float num2 = base.projectile.Center.X;
			float num3 = base.projectile.Center.Y;
			float num4 = 400f;
			bool flag = false;
            if(projectile.timeLeft == 899)
            {
                projectile.frame = Main.rand.Next(2);
                projectile.timeLeft -= Main.rand.Next(9);
            }
			for (int j = 0; j < 200; j++)
			{
                if (Main.npc[j].CanBeChasedBy(base.projectile, false) && Collision.CanHit(base.projectile.Center, 1, 1, Main.npc[j].Center, 1, 1))
                {
                    float num5 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                    float num6 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 20);
                    float num7 = Math.Abs(base.projectile.position.X + (float)(base.projectile.width / 2) - num5) + Math.Abs(base.projectile.position.Y + (float)(base.projectile.height / 2) - num6);
                    if (num7 < num4 && projectile.timeLeft > 120)
                    {
                        num4 = num7;
                        num2 = num5;
                        num3 = num6;
                        flag = true;
                    }
                }
                else
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        base.projectile.velocity.X += (float)(Main.rand.Next(0, 4) / 150f);
                        base.projectile.velocity.Y += (float)(Main.rand.Next(0, 4) / 150f);
                    }
                    else
                    {
                        base.projectile.velocity.X -= (float)(Main.rand.Next(0, 4) / 150f);
                        base.projectile.velocity.Y -= (float)(Main.rand.Next(0, 4) / 150f);
                    }
                }
			}
			if (flag && projectile.timeLeft % 30 > 15)
			{
				float num8 = 5f;
				Vector2 vector3 = new Vector2(base.projectile.position.X + (float)base.projectile.width * 0.5f, base.projectile.position.Y + (float)base.projectile.height * 0.5f);
				float num9 = num2 - vector3.X;
				float num10 = num3 - vector3.Y;
				float num11 = (float)Math.Sqrt((double)(num9 * num9 + num10 * num10));
				num11 = num8 / num11;
				num9 *= num11;
				num10 *= num11;
				base.projectile.velocity.X = (base.projectile.velocity.X * 10f + num9) / 11f;
				base.projectile.velocity.Y = (base.projectile.velocity.Y * 10f + num10) / 11f;
			}
            else
            {
                projectile.velocity = projectile.velocity.RotatedBy(Main.rand.Next(-20000, 20000) / 400000f);
            }
            if (projectile.timeLeft < 120)
			{
                projectile.tileCollide = false;
				flag = false;
                projectile.alpha = (int)(255 - 255 * (projectile.timeLeft / 120f));
                if (Main.rand.Next(10) == 1)
                {
                    Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 191, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 0, default(Color), 0.6f * (projectile.timeLeft / 120f));
                    if (Main.rand.Next(10) == 1)
                    {
                        Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 172, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 0, default(Color), 0.75f * (projectile.timeLeft / 120f));
                    }
                }
            }
            else
            {
                if (Main.rand.Next(10) == 1)
                {
                    Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 191, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 0, default(Color), 0.6f);
                    if (Main.rand.Next(10) == 1)
                    {
                        Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 172, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 0, default(Color), 0.75f);
                    }
                }
            }
            if (!flag)
			{
            }
			if (base.projectile.frame > 2)
			{
				base.projectile.frame = 0;
			}
			if(base.projectile.timeLeft % 10 == 0)
			{
				base.projectile.frame++;
			}
		}
        private int y = 0;
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
        }
        public override void Kill(int timeLeft)
        {
            if(timeLeft != 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 191, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 0, default(Color), 0.6f);
                }
            }
        }
    }
}
