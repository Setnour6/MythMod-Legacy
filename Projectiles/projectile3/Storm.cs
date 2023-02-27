using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
	public class Storm : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("风暴");
			Main.projFrames[base.projectile.type] = 6;
		}
		public override void SetDefaults()
		{
			base.projectile.width = 162;
			base.projectile.height = 44;
			base.projectile.friendly = true;
			base.projectile.tileCollide = false;
			base.projectile.ignoreWater = true;
			base.projectile.magic = true;
			base.projectile.penetrate = -1;
			base.projectile.alpha = 25;
			base.projectile.timeLeft = 600;
			base.projectile.usesLocalNPCImmunity = true;
			base.projectile.localNPCHitCooldown = 8;
		}
		public override void AI()
		{
			int num = 16;
			int num2 = 16;
			float num3 = 1.5f;
			int num4 = 150;
			int num5 = 42;
			if (Main.rand.Next(15) == 0)
			{
				Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 33, base.projectile.velocity.X * 0.5f, base.projectile.velocity.Y * 0.5f, 100, new Color(53, Main.DiscoG, 255), 1f);
			}
			if (base.projectile.velocity.X != 0f)
			{
				base.projectile.direction = (base.projectile.spriteDirection = -Math.Sign(base.projectile.velocity.X));
			}
			base.projectile.frameCounter++;
			if (base.projectile.frameCounter > 2)
			{
				base.projectile.frame++;
				base.projectile.frameCounter = 0;
			}
			if (base.projectile.frame >= 6)
			{
				base.projectile.frame = 0;
			}
			if (base.projectile.localAI[0] == 0f)
			{
				base.projectile.localAI[0] = 1f;
				base.projectile.position.X = base.projectile.position.X + (float)(base.projectile.width / 2);
				base.projectile.position.Y = base.projectile.position.Y + (float)(base.projectile.height / 2);
				base.projectile.scale = ((float)(num + num2) - base.projectile.ai[1]) * num3 / (float)(num2 + num);
				base.projectile.width = (int)((float)num4 * base.projectile.scale);
				base.projectile.height = (int)((float)num5 * base.projectile.scale);
				base.projectile.position.X = base.projectile.position.X - (float)(base.projectile.width / 2);
				base.projectile.position.Y = base.projectile.position.Y - (float)(base.projectile.height / 2);
				base.projectile.netUpdate = true;
			}
			if (base.projectile.ai[1] != -1f)
			{
				base.projectile.scale = ((float)(num + num2) - base.projectile.ai[1]) * num3 / (float)(num2 + num);
				base.projectile.width = (int)((float)num4 * base.projectile.scale);
				base.projectile.height = (int)((float)num5 * base.projectile.scale);
			}
            if(projectile.timeLeft >= 120)
            {
                if (projectile.timeLeft >= 595)
                {
                    projectile.alpha = 255;
                }
                else
                {
                    if (projectile.scale >= 1.2f)
                    {
                        if (!Collision.SolidCollision(base.projectile.position, base.projectile.width, base.projectile.height))
                        {
                            base.projectile.alpha -= 3;
                            if (base.projectile.alpha < 60)
                            {
                                base.projectile.alpha = 60;
                            }
                        }
                        else
                        {
                            base.projectile.alpha += 3;
                            if (base.projectile.alpha > 150)
                            {
                                base.projectile.alpha = 150;
                            }
                        }
                    }
                    else
                    {
                        if (!Collision.SolidCollision(base.projectile.position, base.projectile.width, base.projectile.height))
                        {
                            base.projectile.alpha -= 3;
                            if (base.projectile.alpha < 60 + (int)((1.2 - projectile.scale) * 50))
                            {
                                base.projectile.alpha = 60 + (int)((1.2 - projectile.scale) * 50);
                            }
                        }
                        else
                        {
                            base.projectile.alpha += 3;
                            if (base.projectile.alpha > 150 + (int)((1.2 - projectile.scale) * 26))
                            {
                                base.projectile.alpha = 150 + (int)((1.2 - projectile.scale) * 26);
                            }
                        }
                    }
                }
            }
            else
            {
                projectile.alpha += 2;
            }
			if (base.projectile.ai[0] > 0f)
			{
				base.projectile.ai[0] -= 1f;
			}
			if (base.projectile.ai[0] == 1f && base.projectile.ai[1] > 0f && base.projectile.owner == Main.myPlayer)
			{
				base.projectile.netUpdate = true;
				Vector2 center = base.projectile.Center;
				center.Y -= (float)num5 * base.projectile.scale / 2f;
				float num6 = ((float)(num + num2) - base.projectile.ai[1] + 1f) * num3 / (float)(num2 + num);
				center.Y -= (float)num5 * num6 / 2f;
				center.Y += 2f;
				int z = Projectile.NewProjectile(center.X, center.Y, base.projectile.velocity.X, base.projectile.velocity.Y, base.projectile.type, base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 10f, base.projectile.ai[1] - 1f);
                Main.projectile[z].alpha = 255;
			}
			if (base.projectile.ai[0] <= 0f)
			{
				float num7 = 0.104719758f;
				float num8 = (float)base.projectile.width / 5f;
				num8 *= 2f;
				float num9 = (float)(Math.Cos((double)num7 * -(double)base.projectile.ai[0]) - 0.5) * num8;
				base.projectile.position.X = base.projectile.position.X - num9 * -(float)base.projectile.direction;
				base.projectile.ai[0] -= 1f;
				num9 = (float)(Math.Cos((double)num7 * -(double)base.projectile.ai[0]) - 0.5) * num8;
				base.projectile.position.X = base.projectile.position.X + num9 * -(float)base.projectile.direction;
			}
		}
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D = Main.projectileTexture[base.projectile.type];
            int num = Main.projectileTexture[base.projectile.type].Height / Main.projFrames[base.projectile.type];
            int y = num * base.projectile.frame;
            Main.spriteBatch.Draw(texture2D, base.projectile.Center - Main.screenPosition + new Vector2(0f, base.projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.projectile.GetAlpha(lightColor), base.projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}
