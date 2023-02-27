using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MythMod.Projectiles
{
	// Token: 0x0200057F RID: 1407
    public class 炼狱火尘 : ModProjectile
	{
		// Token: 0x06001EC3 RID: 7875 RVA: 0x0000C81D File Offset: 0x0000AA1D
		public override void SetStaticDefaults()
		{
            base.DisplayName.SetDefault("炼狱火尘");
			Main.projFrames[base.projectile.type] = 4;
		}

		// Token: 0x06001EC4 RID: 7876 RVA: 0x0018A990 File Offset: 0x00188B90
		public override void SetDefaults()
		{
			base.projectile.width = 18;
			base.projectile.height = 18;
			base.projectile.hostile = true;
			base.projectile.ignoreWater = true;
			base.projectile.tileCollide = false;
			base.projectile.penetrate = 1;
			base.projectile.timeLeft = 90;
			this.cooldownSlot = 1;
		}

		// Token: 0x06001EC5 RID: 7877 RVA: 0x0018AA00 File Offset: 0x00188C00
		public override void AI()
		{
			if (Math.Abs(base.projectile.velocity.X) + Math.Abs(base.projectile.velocity.Y) < 16f)
			{
				base.projectile.velocity *= 1.0f;
			}
			base.projectile.rotation = (float)Math.Atan2((double)base.projectile.velocity.Y, (double)base.projectile.velocity.X) + 1.57f;
			base.projectile.frameCounter++;
			if (base.projectile.frameCounter > 4)
			{
				base.projectile.frame++;
				base.projectile.frameCounter = 0;
			}
			if (base.projectile.frame > 3)
			{
				base.projectile.frame = 0;
			}
			Lighting.AddLight(base.projectile.Center, (float)(255 - base.projectile.alpha) * 1f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f, (float)(255 - base.projectile.alpha) * 0f / 255f);
		}

		// Token: 0x06001EC6 RID: 7878 RVA: 0x0000C841 File Offset: 0x0000AA41
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color?(new Color(255, 0, 0, base.projectile.alpha));
		}
        // Token: 0x0600298B RID: 10635 RVA: 0x00213848 File Offset: 0x00211A48
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)base.projectile.position.X, (int)base.projectile.position.Y, 20, 1f, 0f);
            float num = 0.2088f;
            double num2 = Math.Atan2((double)base.projectile.velocity.X, (double)base.projectile.velocity.Y) - (double)(num / 2f);
            double num3 = (double)(num / 30f);
            if (base.projectile.owner == Main.myPlayer)
            {
                for (int i = 0; i < 10; i++)
                {
                    double num4 = num2 + num3 * (double)(i + i * i) / 2.0 + (double)(32f * (float)i);
                    Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)(Math.Sin(num4) * 6.0), (float)(Math.Cos(num4) * 6.0), base.mod.ProjectileType("炼狱火渣"), 405, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                }
            }
            for (int j = 0; j <= 10; j++)
            {
                Dust.NewDust(base.projectile.position + base.projectile.velocity, base.projectile.width, base.projectile.height, 205, base.projectile.oldVelocity.X * 0.5f, base.projectile.oldVelocity.Y * 0.5f, 0, default(Color), 1f);
            }
        }
		// Token: 0x06001EC7 RID: 7879 RVA: 0x0000C861 File Offset: 0x0000AA61
		// Token: 0x06001EC8 RID: 7880 RVA: 0x0018AB58 File Offset: 0x00188D58
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
