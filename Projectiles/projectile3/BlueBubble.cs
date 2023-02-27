using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class BlueBubble : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("海蓝气泡");
		}
		public override void SetDefaults()
		{
			base.projectile.width = 20;
			base.projectile.height = 20;
			base.projectile.hostile = false;
			base.projectile.friendly = true;
			base.projectile.ignoreWater = false;
			base.projectile.tileCollide = true;
			base.projectile.alpha = 255;
			base.projectile.penetrate = 1;
			base.projectile.extraUpdates = 1;
			base.projectile.timeLeft = 180;
			this.cooldownSlot = 1;
		}
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 0.05f / 255f, (float)(255 - base.projectile.alpha) * 0.5f / 255f);
			if (base.projectile.ai[0] == 0f)
			{
				base.projectile.ai[0] = 1f;
                projectile.scale = Main.rand.NextFloat(0.8f, 1.2f);
                //Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 12, 1f, 0f);
            }
			float num = 50f;
			float num20 = 1.5f;
			if (base.projectile.ai[1] == 0f)
			{
				base.projectile.localAI[0] += num20;
				if (base.projectile.localAI[0] > num)
				{
					base.projectile.localAI[0] = num;
					return;
				}
			}
			else
			{
				base.projectile.localAI[0] -= num20;
				if (base.projectile.localAI[0] <= 0f)
				{
					base.projectile.Kill();
				}
			}
            float num2 = base.projectile.Center.X;
            float num3 = base.projectile.Center.Y;
            float num4 = 200f;
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
            projectile.velocity *= 0.9f;
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 15; i++)
            {
                Vector2 v = new Vector2(0, Main.rand.NextFloat(0.5f, 4f)).RotatedByRandom(Math.PI * 2);
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 33, 0f, 0f, 100, Color.White, 0.8f);
            }
        }
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color?(new Color(115, 115, 115, 0));
        }
	}
}
