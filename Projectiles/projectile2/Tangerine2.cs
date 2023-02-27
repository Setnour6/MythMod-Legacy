using System;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MythMod.Projectiles.projectile2
{
    public class Tangerine2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("桔子");
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 12;
            base.Projectile.tileCollide = true;
            base.Projectile.height = 12;
			base.Projectile.friendly = false;
            base.Projectile.hostile = true;
            base.Projectile.penetrate = 1;
			base.Projectile.timeLeft = 600;
			base.Projectile.DamageType = DamageClass.Melee;
            base.Projectile.aiStyle = -1;
			base.Projectile.scale = 1f;
		}
		public override void AI()
		{
            Projectile.velocity.Y += 0.15f;
            if(Projectile.friendly)
            {
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
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
        public override void Kill(int timeLeft)
        {
            for(int i = 0; i < 25; i++)
            {
                int num3 = Dust.NewDust(base.Projectile.Center - new Vector2(4, 4), 0, 0, 174, 0, 0, 0, default(Color), 1f);
            }
        }
	}
}
