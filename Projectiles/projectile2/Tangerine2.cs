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
			base.projectile.width = 12;
            base.projectile.tileCollide = true;
            base.projectile.height = 12;
			base.projectile.friendly = false;
            base.projectile.hostile = true;
            base.projectile.penetrate = 1;
			base.projectile.timeLeft = 600;
			base.projectile.melee = true;
            base.projectile.aiStyle = -1;
			base.projectile.scale = 1f;
		}
		public override void AI()
		{
            projectile.velocity.Y += 0.15f;
            if(projectile.friendly)
            {
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
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
		}
        public override void Kill(int timeLeft)
        {
            for(int i = 0; i < 25; i++)
            {
                int num3 = Dust.NewDust(base.projectile.Center - new Vector2(4, 4), 0, 0, 174, 0, 0, 0, default(Color), 1f);
            }
        }
	}
}
