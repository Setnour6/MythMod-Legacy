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
            Main.projFrames[Projectile.type] = 1;
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 26;
			base.Projectile.height = 30;
			base.Projectile.friendly = true;
			base.Projectile.alpha = 65;
			base.Projectile.penetrate = 1;
			base.Projectile.tileCollide = false;
			base.Projectile.timeLeft = 300;
			base.Projectile.DamageType = DamageClass.Magic;
		}
        public override void AI()
        {
			if(base.Projectile.timeLeft <= 290)
			{
                Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.6f / 255f, (float)(255 - base.Projectile.alpha) * 0.001f / 255f, (float)(255 - base.Projectile.alpha) * 0.95f / 255f);
                if (Main.rand.Next(3) == 1)
                {
                    int num25 = Dust.NewDust(base.Projectile.position, base.Projectile.width, base.Projectile.height, 113, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 14, new Color(Main.DiscoR, 100, 255), 1.2f);
                    Main.dust[num25].velocity *= 0.8f;
                    Main.dust[num25].noGravity = true;
                }
			}
            float num2 = base.Projectile.Center.X;
            float num3 = base.Projectile.Center.Y;
            float num4 = 400f;
            bool flag = false;
            if (Projectile.timeLeft < 290)
            {
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
                base.Projectile.friendly = true;
            }
            else
            {
                base.Projectile.friendly = false;
            }
        }
		public override void Kill(int timeLeft)
		{
			base.Projectile.position.X = base.Projectile.position.X + (float)(base.Projectile.width / 2);
			base.Projectile.position.Y = base.Projectile.position.Y + (float)(base.Projectile.height / 2);
			base.Projectile.width = 50;
			base.Projectile.height = 50;
			base.Projectile.position.X = base.Projectile.position.X - (float)(base.Projectile.width / 2);
			base.Projectile.position.Y = base.Projectile.position.Y - (float)(base.Projectile.height / 2);
			for (int i = 0; i < 30; i++)
			{
                int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 113, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num].velocity *= 3f;
				if (Main.rand.Next(2) == 0)
				{
					Main.dust[num].scale = 0.5f;
					Main.dust[num].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
				}
			}
			for (int j = 0; j < 60; j++)
			{
                int num20 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 113, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num20].noGravity = true;
				Main.dust[num20].velocity *= 0.9f;
                num20 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 113, 0f, 0f, 100, default(Color), 1f);
				Main.dust[num20].velocity *= 0.9f;
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
            if (Projectile.velocity.Length() >= 7)
            {
                Projectile.velocity *= 0.99f;
            }
            if (Projectile.velocity.Length() <= 6.5f)
            {
                Projectile.velocity *= 1.01f;
            }
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
	}
}
