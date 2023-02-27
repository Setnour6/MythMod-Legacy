using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
    public class SoulBullet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("幽魂弹");
			Main.projFrames[base.projectile.type] = 1;
		}
		public override void SetDefaults()
		{
			base.projectile.width = 30;
            projectile.ranged = true;
            base.projectile.height = 10;
			base.projectile.hostile = false;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = true;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 800;
			base.projectile.alpha = 255;
            base.projectile.friendly = true;
            projectile.extraUpdates = 5;
            this.cooldownSlot = 1;
		}
		public override void AI()
		{
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 0.4f / 255f, (float)(255 - base.projectile.alpha) * 0.4f / 255f, (float)(255 - base.projectile.alpha) * 0.6f / 255f);
			base.projectile.spriteDirection = 1;
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X);
            if(projectile.timeLeft < 784)
            {
                int num90 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4) - base.projectile.velocity, 0, 0, 135, 0f, 0f, 100, default(Color), 1.6f);
                Main.dust[num90].noGravity = true;
                Main.dust[num90].velocity *= 0.0f;
            }
            else
            {
                int num90 = Dust.NewDust(new Vector2(base.projectile.Center.X, base.projectile.Center.Y) - new Vector2(4, 4) - base.projectile.velocity, 0, 0, 135, 0f, 0f, 100, default(Color), 1.6f * (795 - projectile.timeLeft) / 11f);
                Main.dust[num90].noGravity = true;
                Main.dust[num90].velocity *= 0.0f;
                if (projectile.velocity.Length() > 7f)
                {
                    projectile.velocity *= 0.9f;
                }
                projectile.alpha -= 10;
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
                base.projectile.velocity.X = (base.projectile.velocity.X * 60f + num9) / 61f;
                base.projectile.velocity.Y = (base.projectile.velocity.Y * 60f + num10) / 61f;
            }
        }
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 255, 255, base.projectile.alpha));
		}
		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height;
			Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, 0, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 1f);
			return false;
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(4) == 1)
            {
                if (target.type != 488)
                {
                     Projectile.NewProjectile(target.Center.X, target.position.Y + target.height / 20f, 0, 0, 305, 1000, 0, Main.myPlayer, 0, 1);
                }
            }
        }
        public override void Kill(int timeLeft)
		{
            for (int i = 0; i < 5; i++)
            {
                int num = Dust.NewDust(new Vector2(base.projectile.position.X, base.projectile.position.Y), base.projectile.width, base.projectile.height, 135, 0f, 0f, 100, default(Color), 2f);
                Main.dust[num].noGravity = true;
            }
        }
    }
}
