using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace MythMod.Projectiles.projectile3
{
	public class Storm : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("风暴");
			Main.projFrames[base.Projectile.type] = 6;
		}
		public override void SetDefaults()
		{
			base.Projectile.width = 162;
			base.Projectile.height = 44;
			base.Projectile.friendly = true;
			base.Projectile.tileCollide = false;
			base.Projectile.ignoreWater = true;
			base.Projectile.DamageType = DamageClass.Magic;
			base.Projectile.penetrate = -1;
			base.Projectile.alpha = 25;
			base.Projectile.timeLeft = 600;
			base.Projectile.usesLocalNPCImmunity = true;
			base.Projectile.localNPCHitCooldown = 8;
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
				Dust.NewDust(base.Projectile.position + base.Projectile.velocity, base.Projectile.width, base.Projectile.height, 33, base.Projectile.velocity.X * 0.5f, base.Projectile.velocity.Y * 0.5f, 100, new Color(53, Main.DiscoG, 255), 1f);
			}
			if (base.Projectile.velocity.X != 0f)
			{
				base.Projectile.direction = (base.Projectile.spriteDirection = -Math.Sign(base.Projectile.velocity.X));
			}
			base.Projectile.frameCounter++;
			if (base.Projectile.frameCounter > 2)
			{
				base.Projectile.frame++;
				base.Projectile.frameCounter = 0;
			}
			if (base.Projectile.frame >= 6)
			{
				base.Projectile.frame = 0;
			}
			if (base.Projectile.localAI[0] == 0f)
			{
				base.Projectile.localAI[0] = 1f;
				base.Projectile.position.X = base.Projectile.position.X + (float)(base.Projectile.width / 2);
				base.Projectile.position.Y = base.Projectile.position.Y + (float)(base.Projectile.height / 2);
				base.Projectile.scale = ((float)(num + num2) - base.Projectile.ai[1]) * num3 / (float)(num2 + num);
				base.Projectile.width = (int)((float)num4 * base.Projectile.scale);
				base.Projectile.height = (int)((float)num5 * base.Projectile.scale);
				base.Projectile.position.X = base.Projectile.position.X - (float)(base.Projectile.width / 2);
				base.Projectile.position.Y = base.Projectile.position.Y - (float)(base.Projectile.height / 2);
				base.Projectile.netUpdate = true;
			}
			if (base.Projectile.ai[1] != -1f)
			{
				base.Projectile.scale = ((float)(num + num2) - base.Projectile.ai[1]) * num3 / (float)(num2 + num);
				base.Projectile.width = (int)((float)num4 * base.Projectile.scale);
				base.Projectile.height = (int)((float)num5 * base.Projectile.scale);
			}
            if(Projectile.timeLeft >= 120)
            {
                if (Projectile.timeLeft >= 595)
                {
                    Projectile.alpha = 255;
                }
                else
                {
                    if (Projectile.scale >= 1.2f)
                    {
                        if (!Collision.SolidCollision(base.Projectile.position, base.Projectile.width, base.Projectile.height))
                        {
                            base.Projectile.alpha -= 3;
                            if (base.Projectile.alpha < 60)
                            {
                                base.Projectile.alpha = 60;
                            }
                        }
                        else
                        {
                            base.Projectile.alpha += 3;
                            if (base.Projectile.alpha > 150)
                            {
                                base.Projectile.alpha = 150;
                            }
                        }
                    }
                    else
                    {
                        if (!Collision.SolidCollision(base.Projectile.position, base.Projectile.width, base.Projectile.height))
                        {
                            base.Projectile.alpha -= 3;
                            if (base.Projectile.alpha < 60 + (int)((1.2 - Projectile.scale) * 50))
                            {
                                base.Projectile.alpha = 60 + (int)((1.2 - Projectile.scale) * 50);
                            }
                        }
                        else
                        {
                            base.Projectile.alpha += 3;
                            if (base.Projectile.alpha > 150 + (int)((1.2 - Projectile.scale) * 26))
                            {
                                base.Projectile.alpha = 150 + (int)((1.2 - Projectile.scale) * 26);
                            }
                        }
                    }
                }
            }
            else
            {
                Projectile.alpha += 2;
            }
			if (base.Projectile.ai[0] > 0f)
			{
				base.Projectile.ai[0] -= 1f;
			}
			if (base.Projectile.ai[0] == 1f && base.Projectile.ai[1] > 0f && base.Projectile.owner == Main.myPlayer)
			{
				base.Projectile.netUpdate = true;
				Vector2 center = base.Projectile.Center;
				center.Y -= (float)num5 * base.Projectile.scale / 2f;
				float num6 = ((float)(num + num2) - base.Projectile.ai[1] + 1f) * num3 / (float)(num2 + num);
				center.Y -= (float)num5 * num6 / 2f;
				center.Y += 2f;
				int z = Projectile.NewProjectile(center.X, center.Y, base.Projectile.velocity.X, base.Projectile.velocity.Y, base.Projectile.type, base.Projectile.damage, base.Projectile.knockBack, base.Projectile.owner, 10f, base.Projectile.ai[1] - 1f);
                Main.projectile[z].alpha = 255;
			}
			if (base.Projectile.ai[0] <= 0f)
			{
				float num7 = 0.104719758f;
				float num8 = (float)base.Projectile.width / 5f;
				num8 *= 2f;
				float num9 = (float)(Math.Cos((double)num7 * -(double)base.Projectile.ai[0]) - 0.5) * num8;
				base.Projectile.position.X = base.Projectile.position.X - num9 * -(float)base.Projectile.direction;
				base.Projectile.ai[0] -= 1f;
				num9 = (float)(Math.Cos((double)num7 * -(double)base.Projectile.ai[0]) - 0.5) * num8;
				base.Projectile.position.X = base.Projectile.position.X + num9 * -(float)base.Projectile.direction;
			}
		}
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture2D = TextureAssets.Projectile[base.Projectile.type].Value;
            int num = TextureAssets.Projectile[base.Projectile.type].Value.Height / Main.projFrames[base.Projectile.type];
            int y = num * base.Projectile.frame;
            Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), new Rectangle?(new Rectangle(0, y, texture2D.Width, num)), base.Projectile.GetAlpha(lightColor), base.Projectile.rotation, new Vector2((float)texture2D.Width / 2f, (float)num / 2f), base.Projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}
