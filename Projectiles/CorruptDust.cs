using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
    public class CorruptDust : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("鳞翅粉尘");
            Main.projFrames[projectile.type] = 1;
		}
		public override void SetDefaults()
		{
			base.projectile.width = 26;
			base.projectile.height = 30;
			base.projectile.friendly = true;
			base.projectile.alpha = 65;
			base.projectile.penetrate = 1;
			base.projectile.tileCollide = false;
			base.projectile.timeLeft = 300;
			base.projectile.magic = true;
		}
        public override void AI()
        {
			if(base.projectile.timeLeft <= 290)
			{
                Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.6f / 255f, (float)(255 - base.projectile.alpha) * 0.001f / 255f, (float)(255 - base.projectile.alpha) * 0.95f / 255f);
                if (Main.rand.Next(3) == 1)
                {
                    int num25 = Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 113, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 14, new Color(Main.DiscoR, 100, 255), 1.2f);
                    Main.dust[num25].velocity *= 0.8f;
                    Main.dust[num25].noGravity = true;
                }
			}
            float num2 = base.projectile.Center.X;
            float num3 = base.projectile.Center.Y;
            float num4 = 400f;
            bool flag = false;
            if (projectile.timeLeft < 290)
            {
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
                base.projectile.friendly = true;
            }
            else
            {
                base.projectile.friendly = false;
            }
        }
		public override void Kill(int timeLeft)
		{
			base.projectile.position.X = base.projectile.position.X + (float)(base.projectile.width / 2);
			base.projectile.position.Y = base.projectile.position.Y + (float)(base.projectile.height / 2);
			base.projectile.width = 50;
			base.projectile.height = 50;
			base.projectile.position.X = base.projectile.position.X - (float)(base.projectile.width / 2);
			base.projectile.position.Y = base.projectile.position.Y - (float)(base.projectile.height / 2);
			for (int i = 0; i < 30; i++)
			{
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 113, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num].velocity *= 3f;
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num].scale = 0.5f;
					Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
				}
			}
			for (int j = 0; j < 60; j++)
			{
                int num20 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 113, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num20].noGravity = true;
				Main.dust[num20].velocity *= 0.9f;
                num20 = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 113, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num20].velocity *= 0.9f;
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
            if (projectile.velocity.Length() >= 7)
            {
                projectile.velocity *= 0.99f;
            }
            if (projectile.velocity.Length() <= 6.5f)
            {
                projectile.velocity *= 1.01f;
            }
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
	}
}
